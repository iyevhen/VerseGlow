using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VerseFlow
{
	public class VerseView : ScrollableControl
	{
		private List<VerseBox> verses = new List<VerseBox>();
		private static readonly StringFormat stringFormat = new StringFormat();
		private readonly object candy = new object();
		private bool refreshVerseHeight;

		public VerseView()
		{
			SetStyle(ControlStyles.DoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint, true);

			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;

			VerticalScroll.Enabled = true;
			VerticalScroll.Visible = true;
		}


		public void Populate(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = strings.ConvertAll(s => new VerseBox(s));
			refreshVerseHeight = true;
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//						base.OnPaintBackground(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			ShowScrollBar(this.Handle, SB_HORZ, false);
			refreshVerseHeight = true;
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				DoPaint(e.Graphics, e.ClipRectangle);
			}
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			graph.FillRectangle(SystemBrushes.Control, rect);

			if (refreshVerseHeight)
			{
				int width = Width;

				if (VScroll)
					width -= SystemInformation.VerticalScrollBarWidth;

				int heigth = 0;

				foreach (VerseBox vb in verses)
				{
					vb.SizeF = new SizeF(width, graph.MeasureString(vb.Text, Font, width, stringFormat).Height);
					heigth += vb.AproxHeight;
				}

				refreshVerseHeight = false;

				AutoScrollMinSize = new Size(width, heigth);
			}

			int yPosition = AutoScrollPosition.Y;
			graph.TranslateTransform(0, yPosition);

			float y = 0;

			foreach (VerseBox vbox in verses)
			{
				if (y > rect.Height)
					return;

				//				var size = graph.MeasureString(vbox.Text, Font, rect.Width, stringFormat);
				var rr = new RectangleF(new PointF(0, y), vbox.SizeF);

				graph.DrawString(vbox.Text, Font, SystemBrushes.ControlText, rr, stringFormat);
				graph.DrawRectangles(SystemPens.Highlight, new[] { rr });
				y += rr.Height;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			//			VScroll;
			//
			//			if (e.Delta > 0)
			//			{
			//				VScrollBar.Value = (int)Math.Max(VScrollBar.Value - (VScrollBar.SmallChange * e.Delta), 0);
			//				OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, xOldValue, VScrollBar.Value, ScrollOrientation.VerticalScroll));
			//			}
			//			else
			//			{
			//				VScrollBar.Value = (int)Math.Min(VScrollBar.Value - (VScrollBar.SmallChange * e.Delta), VScrollBar.Maximum - (VScrollBar.LargeChange - 1));
			//				OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, xOldValue, VScrollBar.Value, ScrollOrientation.VerticalScroll));
			//			}
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
		}


		private const int SB_HORZ = 0;

		[DllImport("user32.dll")]
		static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
	}

	internal class VerseBox
	{
		private readonly string text;
		private SizeF sizeF;
		private int height;

		public VerseBox(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public SizeF SizeF
		{
			get { return sizeF; }
			set
			{
				sizeF = value;
				height = (int)(sizeF.Height + .5f); // hack for rounding to ceiling Int32
			}
		}

		public int AproxHeight
		{
			get { return height; }
		}
	}
}