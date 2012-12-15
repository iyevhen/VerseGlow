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
    /// <summary>
    /// A container element, which visualizes text.
    /// The view is responsible for parsing, layouting and rendering operations.
    /// </summary>
    public class GTextView : GTextVisual
    {
        #region Constructor

        public GTextView()
        {
            m_Document = new GTextDocument();
            bitStates[StateNeedRebuild] = true;
        }

        #endregion

        #region Events

        public event GEventHandler AnchorClicked
        {
            add
            {
                Events.AddHandler(AnchorClickedEventKey, value);
            }
            remove
            {
                Events.RemoveHandler(AnchorClickedEventKey, value);
            }
        }

        #endregion

        #region Public Methods

        public virtual SizeF GetPreferredSize(GDeviceContext context, SizeF availableSize)
        {
            if (availableSize == SizeF.Empty)
            {
                availableSize = new SizeF(float.MaxValue, float.MaxValue);
            }

            if (m_LastMeasuredSize.Width == availableSize.Width)
            {
                return m_LastMeasuredSize;
            }

            LayoutInternal(context, new RectangleF(PointF.Empty, availableSize));

            return m_LastMeasuredSize;
        }
        public virtual void ResetCache()
        {
            m_LastMeasuredSize = SizeF.Empty;
        }

        #endregion

        #region Public Overrides

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
            m_LastMeasuredSize = SizeF.Empty;
        }

        #endregion

        #region Protected Overridables

        protected virtual void Rebuild(GDeviceContext context)
        {
            children.Clear();

            if (string.IsNullOrEmpty(m_Document.Text))
            {
                return;
            }

            if (m_Document.IsValidMarkup == false)
            {
                GStringElement element = new GStringElement();
                element.Text = m_Document.Text;
                m_Document.children.Add(element);
            }

            GTextDocumentParser parser = new GTextDocumentParser(context, this);
            parser.ProcessCollection(m_Document.children);
        }

        #endregion

        #region Protected Overrides

        protected override bool WantsMouseEvent(GMouseEventData mouseData)
        {
            return true;
        }
        protected override void PaintContent(GPaintContext context)
        {
            if (m_LastMeasuredSize.Width != bounds.Width)
            {
                LayoutInternal(context.deviceContext, bounds);
            }

            GTextViewPaintContext paintContext = new GTextViewPaintContext(context.deviceContext, bounds);
            paintContext.ClipMode = ClipMode;

            //paint children
            int count = children.Count;
            GTextVisual viewElement;

            for (int i = 0; i < count; i++)
            {
                if (paintContext.LineStart >= bounds.Bottom)
                {
                    break;
                }
                viewElement = (GTextVisual)children[i];
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

            GParagraph paragraph = ChildFromPoint(mouseData.m_HitPoint, true) as GParagraph;
            GAnchor anchor = paragraph == null ? null : paragraph.AnchorFromPoint(mouseData.m_HitPoint);

            SetHotAnchor(anchor);
        }
        protected override void OnMouseEnter(GEventArgs args, GMouseEventData mouseData)
        {
            base.OnMouseEnter(args, mouseData);

            GParagraph paragraph = ChildFromPoint(mouseData.m_HitPoint, true) as GParagraph;
            GAnchor anchor = paragraph == null ? null : paragraph.AnchorFromPoint(mouseData.m_HitPoint);

            SetHotAnchor(anchor);
        }
        protected override void OnMouseClick(GEventArgs args, GMouseEventData mouseData)
        {
            base.OnMouseClick(args, mouseData);

            if (m_HotAnchor == null || mouseData.m_Button != MouseButtons.Left)
            {
                return;
            }

            GAnchorClickEventData data = new GAnchorClickEventData(m_HotAnchor.anchorElement.Text, m_HotAnchor.anchorElement.Href);
            GEventArgs clickArgs = new GEventArgs(this, data, AnchorClickedEventKey, EventPropagation.None);

            RaiseEvent(clickArgs);
        }
        protected override void OnMouseLeave(GEventArgs args, GMouseEventData mouseData)
        {
            base.OnMouseLeave(args, mouseData);

            SetHotAnchor(null);
        }

        #endregion

        #region Internal Implementation

        internal void LayoutInternal(GDeviceContext context, RectangleF bounds)
        {
            GTextViewLayoutContext layoutContext = CreateLayoutContext(context, bounds);

            bitStates[StateNeedLayout] = true;
            Layout(layoutContext);

            m_LastMeasuredSize = new SizeF(bounds.Width, layoutContext.Y - bounds.Y);
        }
        internal GTextViewLayoutContext CreateLayoutContext(GDeviceContext context, RectangleF bounds)
        {
            GTextViewLayoutContext layoutContext = new GTextViewLayoutContext(context);
            layoutContext.ViewBounds = bounds;
            layoutContext.AvailableSize = bounds.Size;
            layoutContext.X = bounds.X;
            layoutContext.Y = bounds.Y;
            layoutContext.Align = ParagraphAlign;

            return layoutContext;
        }

        internal void SetHotAnchor(GAnchor anchor)
        {
            RectangleF invalid1 = RectangleF.Empty;
            RectangleF invalid2 = RectangleF.Empty;

            if (m_HotAnchor != null && m_HotAnchor != anchor)
            {
                invalid1 = m_HotAnchor.SetMouseState(InputElementMouseState.None);
            }

            if (anchor != null)
            {
                invalid2 = anchor.SetMouseState(InputElementMouseState.Hot);
                Cursor = anchor.anchorElement.Cursor;
            }
            else
            {
                ResetPropertyValue(CursorPropertyKey);
            }

            m_HotAnchor = anchor;
            Invalidate(new RectangleF[] { invalid1, invalid2 });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the text of the view.
        /// </summary>
        public string Text
        {
            get
            {
                return m_Document.Text;
            }
            set
            {
                if (Text == value)
                {
                    return;
                }

                m_Document.Text = value;
                InvalidateLayout();
            }
        }
        /// <summary>
        /// Gets or sets the clipping mode of the view.
        /// TODO: Not yet implemented
        /// </summary>
        public TextViewClipMode ClipMode
        {
            get
            {
                return (TextViewClipMode)GetPropertyValue(ClipModePropertyKey);
            }
            set
            {
                if (ClipMode == value)
                {
                    return;
                }

                SetPropertyValue(ClipModePropertyKey, value);
            }
        }
        /// <summary>
        /// Gets or sets the align to be used for the default paragraph.
        /// </summary>
        public ParagraphAlign ParagraphAlign
        {
            get
            {
                return (ParagraphAlign)GetPropertyValue(ParagraphAlignPropertyKey);
            }
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

        #endregion

        #region Fields

        [NonSerialized]
        internal GTextDocument m_Document;
        [NonSerialized]
        internal SizeF m_LastMeasuredSize;
        [NonSerialized]
        internal GAnchor m_HotAnchor;

        #endregion

	    internal const ulong StateNeedRebuild = StateNeedLayout << 1;

	    #region Property Constants

        public const int ClipModePropertyKey = GTextVisualLastPropKey + 1;
        public const int ParagraphAlignPropertyKey = ClipModePropertyKey + 1;

        #endregion

        #region Event Constants

        public const int AnchorClickedEventKey = GInputElement.GInputElementLastEventKey + 1;

        internal const int GTextViewLastEventKey = AnchorClickedEventKey + DefaultEventRange;

        #endregion
    }
}
