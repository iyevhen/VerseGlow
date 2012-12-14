using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace VerseFlow.Controls
{
	public class VerseView : ScrollableControl
	{
		private static readonly StringFormat stringFormat = new StringFormat();

		private readonly Blend blend = new Blend
			{
				Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
				Factors = new[] { 1, .8f, .4f, .4f, 0.8f, 1 }
			};

		private readonly object candy = new object();
		private readonly Color lightenColor;
		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private SolidBrush backColorBrush;
		private Pen linePen;
		private bool refreshVerses;
		private List<VerseItem> verses = new List<VerseItem>();
		private int visibleWidth;
		private int width;

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

			stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			stringFormat.LineAlignment = StringAlignment.Center;
			lightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 20);
		}

		public void Populate(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = strings.ConvertAll(s => new VerseItem(s));
			refreshVerses = true;
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e) { }

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (Size.Width != width)
				refreshVerses = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				width = Size.Width;

				Stopwatch sw = Stopwatch.StartNew();
				//				Debug.WriteLine("Paint START{0}----------------------------------------------{1}", e.ClipRectangle, DateTime.Now);
				DoPaint(e.Graphics, ClientRectangle);
				sw.Stop();
				//				Debug.WriteLine("Paint DONE in {0}", sw.Elapsed);
			}

			base.OnPaint(e);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			backColorBrush = null;
			linePen = null;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (backColorBrush != null)
				backColorBrush.Dispose();

			if (linePen != null)
				linePen.Dispose();
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			graph.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			if (backColorBrush == null)
				backColorBrush = new SolidBrush(BackColor);

			if (linePen == null)
				linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 10));

			int yPosition = AutoScrollPosition.Y * -1;

			graph.FillRectangle(backColorBrush, rect);

			if (refreshVerses)
			{
				Stopwatch sw = Stopwatch.StartNew();

				double visibleHeigth = 0;
				visibleWidth = Width - 1;
				bool vScrollExcluded = false;

				for (int i = 0; i < verses.Count; i++)
				{
					VerseItem vb = verses[i];
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
				refreshVerses = false;

				sw.Stop();
				Debug.WriteLine("REFRESHED in {0}", sw.Elapsed);
			}

			float yCursor = 0;
			float yDraw = 0;
			bool scrollReached = false;

			visibleVerses.Clear();

			foreach (VerseItem vbox in verses)
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

				RectangleF vrect = vbox.RectFrom(new PointF(0, yDraw));

				if (vbox.Selected)
				{
					using (var brush = new LinearGradientBrush(vrect, SystemColors.Highlight, lightenColor, LinearGradientMode.Vertical))
					{
						brush.Blend = blend;
						graph.FillRectangle(brush, vrect);
					}
					graph.DrawString(vbox.Text, Font, SystemBrushes.HighlightText, vrect, stringFormat);
					graph.DrawRectangles(SystemPens.Highlight, new[] { vrect });
				}
				else
				{
					graph.DrawString(vbox.Text, Font, SystemBrushes.ControlText, vrect, stringFormat);
					graph.DrawLine(linePen, vrect.Left + 5, vrect.Bottom, vrect.Left + vrect.Width - 5, vrect.Bottom);
				}

				visibleVerses.Add(vbox);
				yDraw += vrect.Height;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			//			Debug.WriteLine("OnMouseWheel={0}", e.Delta);
			Invalidate(ClientRectangle);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (e.Button == MouseButtons.Left)
			{
				foreach (VerseItem vb in visibleVerses)
				{
					if (vb.In(e.Location))
					{
						vb.Selected = !vb.Selected;
						Invalidate();
						break;
					}
				}
			}
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);

			if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
				Invalidate(ClientRectangle);
		}

		//		private void DrawText(string text)
		//		{
		//			using (Graphics g = CreateGraphics())
		//			{
		//				float width = ClientRectangle.Width;
		//				float height = ClientRectangle.Width;
		//
		//				float emSize = height;
		//
		//				using (var font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular))
		//				{
		//					using (Font fitFont = FindBestFitFont(g, text, font, ClientRectangle.Size))
		//					{
		//						SizeF fitSize = g.MeasureString(text, font);
		//						g.DrawString(text, fitFont, new SolidBrush(Color.Black), (width - fitSize.Width)/2, 0);
		//					}
		//				}
		//			}
		//		}
		//
		//		private Font FindBestFitFont(Graphics g, String text, Font font, Size proposedSize)
		//		{
		//			// Compute actual size, shrink if needed
		//			while (true)
		//			{
		//				SizeF size = g.MeasureString(text, font);
		//
		//				// It fits, back out
		//				if (size.Height <= proposedSize.Height &&
		//				    size.Width <= proposedSize.Width)
		//				{
		//					return font;
		//				}
		//
		//				// Try a smaller font (90% of old size)
		//				Font oldFont = font;
		//				font = new Font(font.Name, (float) (font.Size*.9), font.Style);
		//				oldFont.Dispose();
		//			}
		//		}
	}
}