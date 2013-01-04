using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class VerseView : ScrollableControl
	{
		private readonly object candy = new object();

		private readonly Blend blend = new Blend { Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 }, Factors = new[] { 1, .8f, .4f, .4f, 0.8f, 1 } };
		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private List<VerseItem> allverses = new List<VerseItem>();

		private readonly Color highlightLightenColor;
		private SolidBrush backColorBrush;
		private int charHeight;
		private int charWidth;
		private Pen linePen;
		private bool recalcVerses;
		private int paintedWidth;
		private string highlightText;
		private bool highlight;

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

			highlightLightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 15);
		}

		public void Fill(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			allverses = strings.ConvertAll(s => new VerseItem(s));
			recalcVerses = true;
			Invalidate();
		}

		private static SizeF GetCharSize(Font font, char c)
		{
			Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
			Size sz3 = TextRenderer.MeasureText("<>", font);

			return new SizeF(sz2.Width - sz3.Width, font.Height);
		}

		protected override void OnPaintBackground(PaintEventArgs e) { }

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (Width != paintedWidth)
			{
				recalcVerses = true;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				paintedWidth = Width;

				if (backColorBrush == null)
					backColorBrush = new SolidBrush(BackColor);

				if (linePen == null)
					linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

				Rectangle rect = ClientRectangle;

				if (recalcVerses)
				{
					Stopwatch sw1 = Stopwatch.StartNew();

					RecalcVerses(rect.Height, Width - 1);
					recalcVerses = false;

					sw1.Stop();
					Debug.WriteLine(string.Format("REFRESHED in {0} - Size - {1}", sw1.Elapsed, AutoScrollMinSize));
				}

				Stopwatch sw2 = Stopwatch.StartNew();

				DoPaint(e.Graphics, rect);

				sw2.Stop();
				Debug.WriteLine(string.Format("Painted in {0}", sw2.Elapsed));
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
			int scrollPosY = AutoScrollPosition.Y * -1;

			graph.SmoothingMode = SmoothingMode.AntiAlias;
			graph.FillRectangle(backColorBrush, rect);

			int cursor = 0;
			int y = 0;
			bool visible = false;

			visibleVerses.Clear();

			foreach (VerseItem verse in allverses)
			{
				if (!visible)
				{
					cursor += verse.Height;

					if (cursor < scrollPosY)
						continue;

					y = cursor - verse.Height - scrollPosY;
					visible = true;
				}

				if (y > rect.Height)
				{
					// do not draw not visible area
					break;
				}

				var point = new Point(0, y);

				if (verse.IsSelected)
				{
					verse.Y = point.Y;

					Rectangle r = verse.Rect(rect.Width);

					using (var brush = new LinearGradientBrush(r, SystemColors.Highlight, highlightLightenColor, LinearGradientMode.Vertical))
					{
						brush.Blend = blend;
						graph.FillRectangle(brush, r);
					}

					foreach (string line in verse.EnumLines())
					{
						TextRenderer.DrawText(graph, line, Font, point, SystemColors.HighlightText);
						point.Y += charHeight;
					}

					graph.DrawRectangle(SystemPens.Highlight, r);
				}
				else
				{
					verse.Y = point.Y;

					foreach (string line in verse.EnumLines())
					{
						if (highlight)
						{
							int linelen = line.Length;
							int lightlen = highlightText.Length;
							int lightwidth = lightlen * charWidth;
							int cur = 0;

							while (cur < linelen)
							{
								int found = line.IndexOf(highlightText, cur, StringComparison.OrdinalIgnoreCase);

								if (found > -1)
								{
									int normal = found - cur;
									TextRenderer.DrawText(graph, line.Substring(cur, normal), Font, point, SystemColors.ControlText);
									point.X += (normal * charWidth);

									TextRenderer.DrawText(graph, line.Substring(found, lightlen), Font, point, Color.Red, Color.LightPink);
									point.X += lightwidth;

									cur = found + lightlen;
								}
								else
								{
									TextRenderer.DrawText(graph, line.Substring(cur), Font, point, SystemColors.ControlText);
									cur = linelen;
								}
							}

							point.Y += charHeight;
							point.X = 0;
						}
						else
						{
							TextRenderer.DrawText(graph, line, Font, point, SystemColors.ControlText);
							point.Y += charHeight;
						}
					}

					graph.DrawLine(linePen, point.X, point.Y, paintedWidth, point.Y);
				}

				visibleVerses.Add(verse);
				y = point.Y;
			}
		}

		private void RecalcVerses(int visibleHeight, int visibleWidth)
		{
			bool scrolled = false;
			int versesHeigth;
			bool recalc;

			do
			{
				recalc = false;
				versesHeigth = 0;
				int charsInLine = (visibleWidth / charWidth) - 1;

				if (charsInLine == 0)
					return;

				for (int i = 0; i < allverses.Count; i++)
				{
					VerseItem verse = allverses[i];
					verse.DropLines();

					int start = 0;
					int end = verse.Text.Length;
					int marker = charsInLine;

					while (marker < end)
					{
						int idx = verse.Text.LastIndexOf(' ', marker, charsInLine);

						if (idx > -1)
						{
							int count = (idx - start);

							verse.NewLine(start, count, charHeight);
							count++;
							start += count;
							marker += count;
						}
						else
						{
							verse.NewLine(start, charsInLine, charHeight);
							start += charsInLine;
							marker += charsInLine;
						}
					}

					if (end > start)
						verse.NewLine(start, end - start, charHeight);

					versesHeigth += verse.Height;

					if (!scrolled && versesHeigth > visibleHeight)
					{
						visibleWidth -= SystemInformation.VerticalScrollBarWidth;
						scrolled = true;
						recalc = true;
						break;
					}
				}

			} while (recalc);

			AutoScrollMinSize = new Size(visibleWidth, versesHeigth);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			Invalidate(ClientRectangle);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (e.Button == MouseButtons.Left)
			{
				foreach (VerseItem vb in visibleVerses)
				{
					if (vb.IsInside(e.Location))
					{
						vb.IsSelected = !vb.IsSelected;
						Invalidate();
						return;
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

		[DefaultValue(typeof(Font), "Courier New, 10.75")]
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

				SizeF size = GetCharSize(base.Font, 'M');

				charWidth = (int)(size.Width);
				charHeight = (int)(size.Height);

				recalcVerses = true;
				Invalidate();
			}
		}

		public string HighlightText
		{
			get { return highlightText; }
			set
			{
				highlightText = value;
				highlight = !string.IsNullOrEmpty(value);
				Invalidate();
			}
		}
	}
}