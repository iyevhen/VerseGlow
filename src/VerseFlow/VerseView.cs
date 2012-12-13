using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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
		private SolidBrush backColorBrush;

		private readonly Blend blend = new Blend
		{
			Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
			Factors = new float[] { 1, .8f, .4f, .4f, 0.8f, 1 }
		};

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
		}


		public void Populate(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = strings.ConvertAll(s => new VerseBox(s));
			refreshVerseHeight = true;
			Invalidate();
		}

		//		protected override void OnPaintBackground(PaintEventArgs e)
		//		{
		//			//						base.OnPaintBackground(e);
		//		}

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
				Debug.WriteLine("Paint START{0}----------------------------------------------{1}", e.ClipRectangle, DateTime.Now);
				DoPaint(e.Graphics, ClientRectangle);
				sw.Stop();
				Debug.WriteLine("Paint DONE in {0}", sw.Elapsed);
			}

			base.OnPaint(e);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			backColorBrush = null;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (backColorBrush != null)
				backColorBrush.Dispose();
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			int yPosition = AutoScrollPosition.Y * -1;

			if (backColorBrush == null)
				backColorBrush = new SolidBrush(BackColor);

			graph.FillRectangle(backColorBrush, rect);

			if (refreshVerseHeight)
			{
				Debug.WriteLine("REFRESH heights");
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
				Debug.WriteLine("REFRESH heights DONE in {0}", sw.Elapsed);
			}

			float yCursor = 0;
			float yDraw = 0;
			bool scrollReached = false;

			//			graph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			//			graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			//			graph.CompositingQuality = CompositingQuality.HighQuality;
			//			graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
			//			graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
			//			graph.CompositingQuality = CompositingQuality.HighQuality;
			//			graph.CompositingMode = CompositingMode.SourceOver;

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


				//				using (var paintBrush = new LinearGradientBrush(rr, LightenColor(BackColor, 50), BackColor, LinearGradientMode.Vertical))
				//				{
				//					//We want a sharp change in the colors so define a Blend for the brush
				//					paintBrush.Blend = blend;
				//
				//					//Draw the Button Background
				//					graph.FillRectangle(paintBrush, rr);
				//				}

				//				TextRenderer.DrawText(graph, vbox.Text, Font, rr, ForeColor, textFormatFlags);

				graph.DrawString(vbox.Text, Font, SystemBrushes.ControlText, rr, stringFormat);
				graph.DrawRectangles(SystemPens.ControlDarkDark, new[] { rr });

				yDraw += rr.Height;
			}
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



		private Color LightenColor(Color colorIn, int percent)
		{
			//This method returns White if you lighten by 100%

			if (percent < 0 || percent > 100)
				throw new ArgumentOutOfRangeException("percent");

			int a, r, g, b;

			a = colorIn.A;
			r = colorIn.R + (int)(((255f - colorIn.R) / 100f) * percent);
			g = colorIn.G + (int)(((255f - colorIn.G) / 100f) * percent);
			b = colorIn.B + (int)(((255f - colorIn.B) / 100f) * percent);

			return Color.FromArgb(a, r, g, b);
		}




		private void DrawText(string text)
		{
			using (Graphics g = this.CreateGraphics())
			{
				float width = this.ClientRectangle.Width;
				float height = this.ClientRectangle.Width;

				float emSize = height;

				using (var font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular))
				{
					using (Font fitFont = FindBestFitFont(g, text, font, ClientRectangle.Size))
					{
						SizeF fitSize = g.MeasureString(text, font);
						g.DrawString(text, fitFont, new SolidBrush(Color.Black), (width - fitSize.Width) / 2, 0);
					}
				}
			}
		}

		private Font FindBestFitFont(Graphics g, String text, Font font, Size proposedSize)
		{
			// Compute actual size, shrink if needed
			while (true)
			{
				SizeF size = g.MeasureString(text, font);

				// It fits, back out
				if (size.Height <= proposedSize.Height &&
					 size.Width <= proposedSize.Width) { return font; }

				// Try a smaller font (90% of old size)
				Font oldFont = font;
				font = new Font(font.Name, (float)(font.Size * .9), font.Style);
				oldFont.Dispose();
			}
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