using System;
using System.Drawing;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model.Nodes;
using VerseFlow.GFramework.Utils;
using VerseFlow.GFramework.View.Events;

namespace VerseFlow.GFramework.View
{
	public abstract class GVisualElement : GElement
	{
		protected const int VisiblePropertyKey = 1;
		protected const int InvalidatedEventKey = GElementLastEventKey + 1;
		internal const int GVisualElementLastEventKey = InvalidatedEventKey + DefaultEventRange;
		internal RectangleF bounds;
		internal int invalidateLock;

		protected GVisualElement()
		{
			bounds = Rectangle.Empty;
		}

		/// <summary>
		///     Determines whether the element is visible (may be visualized on a device context).
		/// </summary>
		public virtual bool Visible
		{
			get
			{
				var vparent = parent as GVisualElement;

				if (vparent != null && vparent.Visible == false)
					return false;

				return (bool)GetPropertyValue(VisiblePropertyKey);
			}
			set
			{
				if (Visible == value)
					return;

				SetPropertyValue(VisiblePropertyKey, value);
			}
		}

		/// <summary>
		///     Gets the smallest rectangle that encapsulates this visual.
		/// </summary>
		public RectangleF Bounds
		{
			get { return bounds; }
		}

		public event GEventHandler Invalidated
		{
			add { Events.AddHandler(InvalidatedEventKey, value); }
			remove { Events.RemoveHandler(InvalidatedEventKey, value); }
		}

		public void SuspendInvalidate()
		{
			invalidateLock++;
		}

		public void ResumeInvalidate()
		{
			invalidateLock--;
			invalidateLock = Math.Max(0, invalidateLock);
		}

		public void Invalidate()
		{
			InvalidateCore(new[] { bounds });
		}

		public void Invalidate(RectangleF[] rects)
		{
			InvalidateCore(rects);
		}

		public void SetBounds(RectangleF rect, bool invalidate = false)
		{
			rect = GLayoutHelper.NormalizeRect(rect);

			if (bounds == rect)
				return;

			RectangleF prevBounds = bounds;
			SetBoundsCore(rect);

			if (invalidate)
			{
				InvalidateCore(new[] { prevBounds, rect });
			}
		}

		public virtual bool HitTest(PointF point)
		{
			return bounds.Contains(point);
		}

		public virtual bool HitTest(RectangleF rect)
		{
			return bounds.Contains(rect);
		}

		public virtual void Paint(GPaintContext context)
		{
			if (Visible == false)
				return;

			PaintContent(context);
		}

		protected virtual void PaintContent(GPaintContext context)
		{
			PaintChildren(context);
		}

		protected virtual void PaintChildren(GPaintContext context)
		{
			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				var child = children[i] as GVisualElement;

				if (child != null)
					child.Paint(context);
			}
		}

		protected virtual void SetBoundsCore(RectangleF bounds)
		{
			this.bounds = bounds;
		}

		protected virtual void InvalidateCore(RectangleF[] rects)
		{
			if (invalidateLock > 0)
			{
				return;
			}

			bool allEmpty = true;
			int length = rects.Length;
			for (int i = 0; i < length; i++)
			{
				if (rects[i].IsEmpty == false)
				{
					allEmpty = false;
					break;
				}
			}

			//all rects are empty, no need to proceed
			if (allEmpty)
			{
				return;
			}

			var data = new GInvalidatedEventData(rects);
			var args = new GEventArgs(this, data, InvalidatedEventKey, EventPropagation.None);

			RaiseEvent(args);
		}

		protected override object GetDefaultPropertyValue(int propertyKey)
		{
			switch (propertyKey)
			{
				case VisiblePropertyKey:
					return true;
			}

			return base.GetDefaultPropertyValue(propertyKey);
		}
	}
}