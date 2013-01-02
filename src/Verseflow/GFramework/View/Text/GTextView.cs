using System;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.GFramework.Drawing.DeviceContexts;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.Model.Text;
using VerseFlow.GFramework.View.Events;

namespace VerseFlow.GFramework.View.Text
{
	public sealed class GTextView : GTextVisual
	{
		private const ulong StateNeedRebuild = StateNeedLayout << 1;
		private const int ClipModePropertyKey = GTextVisualLastPropKey + 1;
		private const int ParagraphAlignPropertyKey = ClipModePropertyKey + 1;
		private const int AnchorClickedEventKey = GInputElementLastEventKey + 1;
		private readonly GTextDocument textDocument;
		private GAnchor hotAnchor;
		private SizeF lastMeasuredSize;

		public GTextView()
		{
			textDocument = new GTextDocument();
			bitStates[StateNeedRebuild] = true;
		}

		/// <summary>
		///     Gets or sets the text of the view.
		/// </summary>
		public string Text
		{
			get { return textDocument.Text; }
			set
			{
				if (Text == value)
				{
					return;
				}

				textDocument.Text = value;
				InvalidateLayout();
			}
		}

		/// <summary>
		///     Gets or sets the align to be used for the default paragraph.
		/// </summary>
		public ParagraphAlign ParagraphAlign
		{
			get { return (ParagraphAlign)GetPropertyValue(ParagraphAlignPropertyKey); }
			set
			{
				if (ParagraphAlign == value)
				{
					return;
				}

				SetPropertyValue(ParagraphAlignPropertyKey, value);
				InvalidateLayout();
				Invalidate();
			}
		}

		public event GEventHandler AnchorClicked
		{
			add { Events.AddHandler(AnchorClickedEventKey, value); }
			remove { Events.RemoveHandler(AnchorClickedEventKey, value); }
		}

		public SizeF GetPreferredSize(GDeviceContext context, SizeF availableSize)
		{
			if (availableSize == SizeF.Empty)
			{
				availableSize = new SizeF(float.MaxValue, float.MaxValue);
			}

			if (lastMeasuredSize.Width == availableSize.Width)
			{
				return lastMeasuredSize;
			}

			LayoutInternal(context, new RectangleF(PointF.Empty, availableSize));

			return lastMeasuredSize;
		}

		protected override object GetDefaultPropertyValue(int propertyKey)
		{
			switch (propertyKey)
			{
				case ClipModePropertyKey:
					return TextViewClipMode.Bounds;
				case ParagraphAlignPropertyKey:
					return ParagraphAlign.Left;
			}

			return base.GetDefaultPropertyValue(propertyKey);
		}

		public override void Layout(GTextViewLayoutContext context)
		{
			//rebuild the document if needed
			if (bitStates[StateNeedRebuild])
			{
				Rebuild(context.DeviceContext);
				bitStates[StateNeedRebuild] = false;
			}

			base.Layout(context);
		}

		public override void InvalidateLayout()
		{
			base.InvalidateLayout();

			bitStates[StateNeedRebuild] = true;
			lastMeasuredSize = SizeF.Empty;
		}

		private void Rebuild(GDeviceContext context)
		{
			children.Clear();

			if (string.IsNullOrEmpty(textDocument.Text))
				return;

			if (!textDocument.IsValidMarkup)
			{
				var element = new GStringElement { Text = textDocument.Text };
				textDocument.children.Add(element);
			}

			var parser = new GTextDocumentParser(context, this);
			parser.ProcessCollection(textDocument.children);
		}

		protected override bool WantsMouseEvent(GMouseEventData mouseData)
		{
			return true;
		}

		protected override void PaintContent(GPaintContext context)
		{
			if (lastMeasuredSize.Width != bounds.Width)
			{
				LayoutInternal(context.deviceContext, bounds);
			}

			var paintContext = new GTextViewPaintContext(context.deviceContext, bounds);

			//paint children
			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				if (paintContext.LineStart >= bounds.Bottom)
				{
					break;
				}
				var viewElement = (GTextVisual)children[i];
				viewElement.Paint(paintContext);
			}
		}

		protected override void LayoutCore(GTextViewLayoutContext context)
		{
			int count = children.Count;

			for (int i = 0; i < count; i++)
			{
				var visual = (GTextVisual)children[i];
				visual.InvalidateLayout();
				visual.Layout(context);
			}
		}

		protected override void OnMouseMove(GEventArgs args, GMouseEventData mouseData)
		{
			base.OnMouseMove(args, mouseData);

			var paragraph = ChildFromPoint(mouseData.m_HitPoint, true) as GParagraph;
			GAnchor anchor = paragraph == null ? null : paragraph.AnchorFromPoint(mouseData.m_HitPoint);

			SetHotAnchor(anchor);
		}

		protected override void OnMouseEnter(GEventArgs args, GMouseEventData mouseData)
		{
			base.OnMouseEnter(args, mouseData);

			var paragraph = ChildFromPoint(mouseData.m_HitPoint, true) as GParagraph;
			GAnchor anchor = paragraph == null ? null : paragraph.AnchorFromPoint(mouseData.m_HitPoint);

			SetHotAnchor(anchor);
		}

		protected override void OnMouseClick(GEventArgs args, GMouseEventData mouseData)
		{
			base.OnMouseClick(args, mouseData);

			if (hotAnchor == null || mouseData.m_Button != MouseButtons.Left)
			{
				return;
			}

			var data = new GAnchorClickEventData(hotAnchor.anchorElement.Text, hotAnchor.anchorElement.Href);
			var clickArgs = new GEventArgs(this, data, AnchorClickedEventKey, EventPropagation.None);

			RaiseEvent(clickArgs);
		}

		protected override void OnMouseLeave(GEventArgs args, GMouseEventData mouseData)
		{
			base.OnMouseLeave(args, mouseData);

			SetHotAnchor(null);
		}

		private void LayoutInternal(GDeviceContext context, RectangleF bounds)
		{
			GTextViewLayoutContext layoutContext = CreateLayoutContext(context, bounds);

			bitStates[StateNeedLayout] = true;
			Layout(layoutContext);

			lastMeasuredSize = new SizeF(bounds.Width, layoutContext.Y - bounds.Y);
		}

		private GTextViewLayoutContext CreateLayoutContext(GDeviceContext context, RectangleF bounds)
		{
			var layoutContext = new GTextViewLayoutContext(context)
				{
					ViewBounds = bounds,
					AvailableSize = bounds.Size,
					X = bounds.X,
					Y = bounds.Y,
					Align = ParagraphAlign
				};

			return layoutContext;
		}

		private void SetHotAnchor(GAnchor anchor)
		{
			RectangleF invalid1 = RectangleF.Empty;
			RectangleF invalid2 = RectangleF.Empty;

			if (hotAnchor != null && hotAnchor != anchor)
			{
				invalid1 = hotAnchor.SetMouseState(InputElementMouseState.None);
			}

			if (anchor != null)
			{
				invalid2 = anchor.SetMouseState(InputElementMouseState.Hot);
				CursorOnMouseHover = anchor.anchorElement.Cursor;
			}
			else
			{
				ResetPropertyValue(CursorPropertyKey);
			}

			hotAnchor = anchor;
			Invalidate(new[] { invalid1, invalid2 });
		}
	}
}