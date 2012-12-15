using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VerseFlow.GFramework.Events;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.View;
using VerseFlow.GFramework.View.Events;
using VerseFlow.GFramework.View.Text;

namespace VerseFlow.Controls
{
	public class GMarkupLabel : GControl
	{
		private static readonly object AnchorClickedEventKey;
		private readonly GTextView m_TextView;
		private TextRenderingHint m_RenderingHint;

		static GMarkupLabel()
		{
			AnchorClickedEventKey = new object();
		}

		public GMarkupLabel()
		{
			m_TextView = new GTextView();
			m_RenderingHint = TextRenderingHint.SystemDefault;
			m_TextView.Invalidated += OnTextViewInvalidated;
			m_TextView.PropertyChanged += OnTextViewPropertyChanged;
			m_TextView.AnchorClicked += OnTextViewAnchorClicked;
		}

		protected override Size DefaultSize
		{
			get { return new Size(150, 30); }
		}

		public override string Text
		{
			get { return base.Text; }
			set
			{
				base.Text = value;

				if (m_TextView != null)
				{
					m_TextView.Text = value;
					m_TextView.InvalidateLayout();
				}

				Invalidate();
			}
		}

		/// <summary>
		///     Gets or sets the hint to be used when rendering text.
		/// </summary>
		[DefaultValue(TextRenderingHint.SystemDefault)]
		public TextRenderingHint RenderingHint
		{
			get { return m_RenderingHint; }
			set
			{
				if (m_RenderingHint == value)
				{
					return;
				}

				m_RenderingHint = value;
				m_TextView.InvalidateLayout();
				Invalidate();
			}
		}

		/// <summary>
		///     Gets or sets the alignment of the default paragraph.
		/// </summary>
		[DefaultValue(ParagraphAlign.Left)]
		public ParagraphAlign ParagraphAlign
		{
			get { return m_TextView.ParagraphAlign; }
			set
			{
				if (m_TextView.ParagraphAlign == value)
				{
					return;
				}

				m_TextView.ParagraphAlign = value;
			}
		}

		public event GEventHandler AnchorClicked
		{
			add { Events.AddHandler(AnchorClickedEventKey, value); }
			remove { Events.RemoveHandler(AnchorClickedEventKey, value); }
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);

			Point mousePos = PointToClient(MousePosition);
			var mouseArgs = new MouseEventArgs(MouseButtons, 0, mousePos.X, mousePos.Y, 0);

			DelegateMouseEvent(MouseEvent.Enter, mouseArgs);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			DelegateMouseEvent(MouseEvent.Move, e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			Point mousePos = PointToClient(MousePosition);
			var mouseArgs = new MouseEventArgs(MouseButtons, 0, mousePos.X, mousePos.Y, 0);

			DelegateMouseEvent(MouseEvent.Leave, mouseArgs);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			DelegateMouseEvent(MouseEvent.ButtonClick, e);
		}

		protected override void OnPaddingChanged(EventArgs e)
		{
			base.OnPaddingChanged(e);

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;
			g.TextRenderingHint = m_RenderingHint;
			Globals.GdiPlusDevice.Attach(g);

			var context = new GPaintContext(Globals.GdiPlusDevice);
			m_TextView.Paint(context);

			Globals.GdiPlusDevice.Detach();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			m_TextView.SetBounds(GetTextViewBounds());
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_TextView.Dispose();
			}
			base.Dispose(disposing);
		}

		protected virtual void OnTextViewInvalidated(GEventArgs args)
		{
			var data = (GInvalidatedEventData) args.Data;
			foreach (RectangleF rect in data.InvalidRects)
			{
				Invalidate(Rectangle.Ceiling(rect));
			}
		}

		protected virtual RectangleF GetTextViewBounds()
		{
			Padding padding = Padding;
			return new RectangleF(padding.Left, padding.Top, Width - padding.Horizontal, Height - padding.Vertical);
		}

		internal void DelegateMouseEvent(MouseEvent mouseEvent, MouseEventArgs e)
		{
			var eventData = new GMouseEventData(mouseEvent, e.Delta, e.Clicks, new Point(e.X, e.Y), e.Button);
			var args = new GEventArgs(this, eventData, GInputElement.MouseEventKey, EventPropagation.Both);

			m_TextView.PreviewMouseEvent(args);
			if (args.Result == EventResult.Process)
			{
				m_TextView.OnMouseEvent(args);
			}
		}

		private void OnTextViewPropertyChanged(GEventArgs args)
		{
			var data = (GPropertyEventData) args.Data;
			if (data.Key == GInputElement.CursorPropertyKey)
			{
				UpdateCursor();
			}
		}

		private void OnTextViewAnchorClicked(GEventArgs args)
		{
			var eh = Events[AnchorClickedEventKey] as GEventHandler;
			if (eh != null)
			{
				args.Sender = this;
				eh(args);
			}
		}

		private void UpdateCursor()
		{
			switch (m_TextView.Cursor)
			{
				case PredefinedCursors.Hand:
					Cursor = Cursors.Hand;
					break;
				default:
					Cursor = Cursors.Default;
					break;
			}
		}
	}
}