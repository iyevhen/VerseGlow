using System;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model.Collections;

namespace VerseFlow.GFramework.Model.Nodes
{
	public class GRootElement : GElement
	{
		[NonSerialized] private readonly GNodeCollection eventListeners;
		[NonSerialized] internal int initializeLock;

		public GRootElement()
		{
			eventListeners = new GNodeCollection(this);
		}

		public GNodeCollection EventListeners
		{
			get { return eventListeners; }
		}

		public virtual void BeginInit()
		{
			initializeLock++;
		}

		public virtual void EndInit()
		{
			initializeLock--;
			initializeLock = Math.Max(0, initializeLock);

			if (initializeLock > 0)
			{
				return;
			}

			OnEndInit();
		}

		protected virtual void OnEndInit()
		{
			int count = children.Count;
			for (int i = 0; i < count; i++)
			{
				children[i].SetRoot(this);
			}
		}

		protected internal override void OnCollectionNotification(GEventArgs e)
		{
			base.OnCollectionNotification(e);

			if (initializeLock > 0)
			{
				return;
			}

			var data = (GCollectionEventData) e.m_Data;

			switch (data.m_Notification)
			{
				case CollectionNotification.ElementAdded:
				case CollectionNotification.ElementInserted:
					((GNode) data.m_Element).SetRoot(this);
					break;
				case CollectionNotification.ElementRemoved:
					((GNode) data.m_Element).SetRoot(null);
					break;
			}
		}
	}
}