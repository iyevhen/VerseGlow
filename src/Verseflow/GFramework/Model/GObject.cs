using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using VerseFlow.GFramework.DataStructure;
using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.Model
{
	public abstract class GObject
	{
		internal const ulong StateCanRaiseEvents = 1;
		public const int PropertyChangingEventKey = 1;
		public const int PropertyChangedEventKey = PropertyChangingEventKey + 1;
		internal const int DefaultEventRange = 100;
		internal const int GObjectLastEventKey = DefaultEventRange;
		[NonSerialized] internal GBitVector64 bitStates;
		[NonSerialized] internal int eventLocks;
		[NonSerialized] internal GEventStorage events;
		internal GPropertyStorage propertyStorage;
		[NonSerialized] internal object tag;

		protected GObject()
		{
			propertyStorage = new GPropertyStorage();
			bitStates = new GBitVector64();
			bitStates[StateCanRaiseEvents] = true;
		}

		protected GEventStorage Events
		{
			get { return events ?? (events = new GEventStorage()); }
		}

		protected GPropertyStorage PropertyStorage
		{
			get { return propertyStorage; }
		}
		
		[DefaultValue(true)]
		public bool CanRaiseEvents
		{
			get { return bitStates[StateCanRaiseEvents]; }
			set { bitStates[StateCanRaiseEvents] = value; }
		}

		/// <summary>
		///     Gets or sets the additional data associated with the object.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object Tag
		{
			get { return tag; }
			set { tag = value; }
		}

		public event GEventHandler PropertyChanging
		{
			add { Events.AddHandler(PropertyChangingEventKey, value); }
			remove { Events.RemoveHandler(PropertyChangingEventKey, value); }
		}

		public event GEventHandler PropertyChanged
		{
			add { Events.AddHandler(PropertyChangedEventKey, value); }
			remove { Events.RemoveHandler(PropertyChangedEventKey, value); }
		}

		protected object GetPropertyValue(int propertyKey)
		{
			bool found;
			object value = propertyStorage.GetEntry(propertyKey, out found);

			if (found)
			{
				return value;
			}

			return GetDefaultPropertyValue(propertyKey);
		}

		public object GetLocalPropertyValue(int propertyKey)
		{
			bool found;
			object value = propertyStorage.GetEntry(propertyKey, out found);

			if (found)
			{
				return value;
			}

			return null;
		}

		public bool ContainsLocalProperty(int propertyKey)
		{
			return GetLocalPropertyValue(propertyKey) != null;
		}

		protected void ResetPropertyValue(int propertyKey)
		{
			if (ContainsLocalProperty(propertyKey) == false)
			{
				return;
			}

			SetPropertyValue(propertyKey, null);
		}

		public void SuspendEvents()
		{
			eventLocks++;
		}

		public void ResumeEvents()
		{
			eventLocks--;
			eventLocks = Math.Max(0, eventLocks);
		}

		protected virtual bool GetCanRaiseEvents()
		{
			if (bitStates[StateCanRaiseEvents] == false)
			{
				return false;
			}

			if (eventLocks > 0)
			{
				return false;
			}

			return true;
		}

		protected virtual object GetDefaultPropertyValue(int propertyKey)
		{
			return null;
		}

		[OnDeserialized]
		protected virtual void OnDeserialized()
		{
			propertyStorage = new GPropertyStorage();
			bitStates[StateCanRaiseEvents] = true;
		}

		protected virtual void RaiseEvent(GEventArgs args)
		{
			if (bitStates[StateCanRaiseEvents] == false || eventLocks > 0)
			{
				return;
			}

			var handler = Events[args.m_Key] as GEventHandler;
			if (handler != null)
			{
				handler(args);
			}
		}

		protected virtual EventResult OnPropertyValueChanging(int propertyKey, object newValue)
		{
			if (GetCanRaiseEvents() == false)
			{
				return EventResult.Unspecified;
			}

			var data = new GPropertyChangingEventData(propertyKey, newValue);
			var e = new GEventArgs(this, data, PropertyChangingEventKey, EventPropagation.Bubble);

			RaiseEvent(e);

			return e.m_Result;
		}

		protected virtual void OnPropertyValueChanged(int propertyKey)
		{
			if (GetCanRaiseEvents() == false)
			{
				return;
			}

			var data = new GPropertyEventData(propertyKey);
			var e = new GEventArgs(this, data, PropertyChangedEventKey, EventPropagation.Both);

			RaiseEvent(e);
		}

		protected virtual void SetPropertyValue(int propertyKey, object value)
		{
			EventResult result = OnPropertyValueChanging(propertyKey, value);
			if ((result & EventResult.Cancel) == EventResult.Cancel)
			{
				return;
			}

			if (value == null)
			{
				if (propertyStorage.ContainsEntry(propertyKey))
				{
					propertyStorage.RemoveEntry(propertyKey);
				}
			}
			else
			{
				propertyStorage.SetEntry(propertyKey, value);
			}

			OnPropertyValueChanged(propertyKey);
		}
	}
}