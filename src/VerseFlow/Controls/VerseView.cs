using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace VerseFlow.Controls
{
	public class VerseView : ScrollableControl
	{
		private const int minLeftIndent = 8;
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
		private int charHeight;
		private int lineInterval;
		private bool needRecalc;

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

		/// <summary>
		/// Font
		/// </summary>
		/// <remarks>Use only monospaced font</remarks>
		[DefaultValue(typeof(Font), "Courier New, 9.75")]
		public override Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				//check monospace font
				SizeF sizeM = GetCharSize(base.Font, 'M');
				SizeF sizeDot = GetCharSize(base.Font, '.');

				if (sizeM != sizeDot)
					base.Font = new Font("Courier New", base.Font.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);

				//clac size
				SizeF size = GetCharSize(base.Font, 'M');

				CharWidth = (int)(size.Width);
				CharHeight = lineInterval + (int)(size.Height);

//				CharWidth = (int)Math.Round(size.Width * 1f /*0.85*/) - 1 /*0*/;
//				CharHeight = lineInterval + (int)Math.Round(size.Height * 1f /*0.9*/) - 1 /*0*/;
				//
				needRecalc = true;
				Invalidate();
			}
		}

		/// <summary>
		/// Width of char in pixels
		/// </summary>
		[Description("Width of char in pixels")]
		public int CharWidth { get; private set; }

		[Description("Height of char in pixels")]
		public int CharHeight
		{
			get { return charHeight; }
			private set
			{
				charHeight = value;
				OnCharSizeChanged();
			}
		}

		/// <summary>
		/// Interval between lines (in pixels)
		/// </summary>
		[Description("Interval between lines in pixels")]
		[DefaultValue(0)]
		public int LineInterval
		{
			get { return lineInterval; }
			set
			{
				lineInterval = value;
				Font = Font;
				Invalidate();
			}
		}

		protected virtual void OnCharSizeChanged()
		{
			VerticalScroll.SmallChange = charHeight;
			VerticalScroll.LargeChange = 10 * charHeight;
			HorizontalScroll.SmallChange = CharWidth;
		}

		public static SizeF GetCharSize(Font font, char c)
		{
			Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
			Size sz3 = TextRenderer.MeasureText("<>", font);

//			return new SizeF(sz2.Width - sz3.Width + 1, /*sz2.Height*/font.Height);
			return new SizeF(sz2.Width - sz3.Width, /*sz2.Height*/font.Height);
		}

		private void Recalc()
		{
			if (!needRecalc)
				return;

#if debug
            var sw = Stopwatch.StartNew();
#endif

			needRecalc = false;
			//calc min left indent
			//			LeftIndent = LeftPadding;
			//			long maxLineNumber = LinesCount + lineNumberStartValue - 1;
			//			int charsForLineNumber = 2 + (maxLineNumber > 0 ? (int)Math.Log10(maxLineNumber) : 0);
			//			if (Created)
			//			{
			//				if (ShowLineNumbers)
			//					LeftIndent += charsForLineNumber * CharWidth + minLeftIndent + 1;
			//			}
			//			else
			//				needRecalc = true;
			//			//calc max line length and count of wordWrapLines
			//			wordWrapLinesCount = 0;
			//
			//			maxLineLength = RecalcMaxLineLength();
			//
			//			//adjust AutoScrollMinSize
			//			int minWidth;
			//			CalcMinAutosizeWidth(out minWidth, ref maxLineLength);
			//
			//			AutoScrollMinSize = new Size(minWidth, wordWrapLinesCount * CharHeight + Paddings.Top + Paddings.Bottom);

#if debug
            sw.Stop();
            Console.WriteLine("Recalc: " + sw.ElapsedMilliseconds);
#endif
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
				Debug.WriteLine("REFRESHED_OLD in {0} - Size - {1}", sw.Elapsed, AutoScrollMinSize);

				REFRESH_NEW(verses, rect);
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
					//					using (var brush = new LinearGradientBrush(vrect, SystemColors.Highlight, lightenColor, LinearGradientMode.Vertical))
					//					{
					//						brush.Blend = blend;
					//						graph.FillRectangle(brush, vrect);
					//					}


					graph.FillRectangle(SystemBrushes.Highlight, vrect);
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

		private void REFRESH_NEW(List<VerseItem> verseItems, Rectangle rect)
		{
			Stopwatch sw = Stopwatch.StartNew();

			int charsInLine = visibleWidth / CharWidth;

			double visibleHeigth = 0;
			visibleWidth = Width - 1;
			bool vScrollExcluded = false;

			for (int i = 0; i < verseItems.Count; i++)
			{
				VerseItem vb = verseItems[i];
				vb.DropLines();

				int start = 0;
				int end = vb.Text.Length;
				int marker = charsInLine;

				do
				{
					if (marker >= end)
					{
						vb.NewLine(start, end - start);
						break;
					}

					int idx = vb.Text.LastIndexOf(' ', marker, charsInLine);
					int count = idx > -1 ? (idx - start) : charsInLine;

					vb.NewLine(start, count);

					start += count;
					marker += count;

				} while (true);

				visibleHeigth += vb.Lines * CharHeight;

				if (!vScrollExcluded && visibleHeigth > rect.Height)
				{
					i = -1;
					visibleHeigth = 0;
					visibleWidth -= SystemInformation.VerticalScrollBarWidth;
					charsInLine = visibleWidth / CharWidth;
					vScrollExcluded = true;
				}
			}

			AutoScrollMinSize = new Size(visibleWidth, (int)(visibleHeigth + 1));
			refreshVerses = false;

			sw.Stop();
			Debug.WriteLine("REFRESHED_NEW in {0} - Size - {1}", sw.Elapsed, AutoScrollMinSize);
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