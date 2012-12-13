using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
		private int visibleWidth;

		public VerseView()
		{
			SetStyle(ControlStyles.DoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse, true);

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
			int yPosition = AutoScrollPosition.Y * -1;

			//			graph.TranslateTransform(0, yPosition);
			graph.FillRectangle(Brushes.GhostWhite, rect);


			if (refreshVerseHeight)
			{
				Debug.WriteLine("refreshVerseHeight");
				var sw = Stopwatch.StartNew();

				double visibleHeigth = 0;
				visibleWidth = Width - 1;
				bool vScrollExcluded = false;

				for (int i = 0; i < verses.Count; i++)
				{
					VerseBox vb = verses[i];
					vb.SizeF = new SizeF(visibleWidth, graph.MeasureString(vb.Text, Font, visibleWidth, stringFormat).Height);

					visibleHeigth += vb.SizeF.Height;

					if (!vScrollExcluded && visibleHeigth > rect.Height)
					{
						i = -1;
						visibleHeigth = 0;
						visibleWidth -= SystemInformation.VerticalScrollBarWidth;
						vScrollExcluded = true;
					}
				}

				AutoScrollMinSize = new Size(visibleWidth, (int)(visibleHeigth + 1));
				refreshVerseHeight = false;

				sw.Stop();
				Debug.WriteLine("refreshVerseHeight DONE in {0}", sw.Elapsed);
			}

			Debug.WriteLine("drawing");
			var sw2 = Stopwatch.StartNew();

			float yCursor = 0;
			float yDraw = 0;
			bool scrollReached = false;

			foreach (VerseBox vbox in verses)
			{
				if (!scrollReached)
				{
					if ((yCursor + vbox.SizeF.Height) < yPosition)
					{
						yCursor += vbox.SizeF.Height;
						continue;
					}

					yDraw = yCursor - yPosition;
					scrollReached = true;
				}

				if (yDraw > rect.Height)
					break;

				var rr = new RectangleF(new PointF(0, yDraw), vbox.SizeF);
//				var rr2 = new RectangleF(new PointF(0, yDraw), vbox.PossibleSizeF);
				graph.DrawString(vbox.Text, Font, SystemBrushes.ControlText, rr, stringFormat);
				graph.DrawRectangles(SystemPens.Highlight, new[] { rr });

//				using (var brush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.BurlyWood))
//				using (var pen = new Pen(brush))
//					graph.DrawRectangles(pen, new[] { rr2 });

				yDraw += rr.Height;
			}

			sw2.Stop();
			Debug.WriteLine("drawing DONE in {0}", sw2.Elapsed);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			Debug.WriteLine("OnMouseWheel={0}", e.Delta);
			Invalidate(ClientRectangle);
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

		public VerseBox(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public SizeF SizeF { get; set; }
	}
}