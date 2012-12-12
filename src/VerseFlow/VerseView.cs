using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		private int width;

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

			if (Size.Width != width)
			{
				refreshVerseHeight = true;
			}
			else
			{
				Debug.WriteLine("Width is the same");
			}
		}

		//		protected override void OnResize(EventArgs e)
		//		{
		//			base.OnResize(e);
		//			refreshVerseHeight = true;
		//		}


		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				width = Size.Width;

				var sw = Stopwatch.StartNew();
				Debug.WriteLine("DoPaint rect={0}----------------------------------------------{1}", e.ClipRectangle, DateTime.Now);
				DoPaint(e.Graphics, e.ClipRectangle);
				sw.Stop();
				Debug.WriteLine("DoPaint rect={0} DONE in {1}", e.ClipRectangle, sw.Elapsed);
			}
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			graph.FillRectangle(SystemBrushes.Control, rect);

			if (refreshVerseHeight)
			{
				Debug.WriteLine("refreshVerseHeight");
				var sw = Stopwatch.StartNew();

				int visibleHeigth = 0;
				int visibleWidth = Width - 1;
				bool vScrollExcluded = false;

				for (int i = 0; i < verses.Count; i++)
				{
					VerseBox vb = verses[i];
					vb.SizeF = new SizeF(visibleWidth, graph.MeasureString(vb.Text, Font, visibleWidth, stringFormat).Height);

					visibleHeigth += vb.HeightInt32;

					if (!vScrollExcluded && visibleHeigth > rect.Height)
					{
						i = -1;
						visibleHeigth = 0;
						visibleWidth -= SystemInformation.VerticalScrollBarWidth;
						vScrollExcluded = true;
					}
				}

				AutoScrollMinSize = new Size(visibleWidth, visibleHeigth);

				refreshVerseHeight = false;

				sw.Stop();
				Debug.WriteLine("refreshVerseHeight DONE in {0}", sw.Elapsed);
			}

			Debug.WriteLine("drawing");
			var sw2 = Stopwatch.StartNew();


			int yPosition = AutoScrollPosition.Y;
			graph.TranslateTransform(0, yPosition);

			float y = 0;

			foreach (VerseBox vbox in verses)
			{
				if (y > rect.Height)
					break;

				var rr = new RectangleF(new PointF(0, y), vbox.SizeF);
				graph.DrawString(vbox.Text, Font, SystemBrushes.ControlText, rr, stringFormat);
				graph.DrawRectangles(SystemPens.Highlight, new[] { rr });

				y += rr.Height;
			}

			sw2.Stop();
			Debug.WriteLine("drawing DONE in {0}", sw2.Elapsed);
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

			if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
				Invalidate(ClientRectangle);
		}
	}

	internal class VerseBox
	{
		private readonly string text;
		private SizeF sizeF;
		private int heightInt32;

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
				heightInt32 = (int)(sizeF.Height + 1f); // hack for rounding to ceiling Int32
			}
		}

		public int HeightInt32
		{
			get { return heightInt32; }
		}
	}
}