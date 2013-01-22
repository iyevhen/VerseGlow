﻿using System;
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

//		private readonly Blend blend = new Blend { Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 }, Factors = new[] { 1, .8f, .4f, .4f, 0.8f, 1 } };
		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private List<VerseItem> allverses = new List<VerseItem>();
		const int xPadding = 50;
		const int xVersePadding = 5;

		private readonly Color highlightLightenColor;
		private SolidBrush backColorBrush;
		private SolidBrush paddingColorBrush;
		private Pen linePen;
		private bool recalcVerses;
		private int paintedWidth;
		private string highlightText;
		private bool highlight;
		private int lineHeight;

		private const TextFormatFlags tff = TextFormatFlags.NoClipping
											| TextFormatFlags.NoFullWidthCharacterBreak
											| TextFormatFlags.NoPadding
											| TextFormatFlags.NoPrefix;

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

				if (paddingColorBrush == null)
					paddingColorBrush = new SolidBrush(GraphicsTools.DarkenColor(BackColor, 5));

				if (linePen == null)
					linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

				Rectangle rect = ClientRectangle;
				Stopwatch sw = Stopwatch.StartNew();

				if (recalcVerses)
				{
					Debug.WriteLine("Recalculating verses");

					RecalcVerses(rect.Height, Width - (SystemInformation.VerticalScrollBarWidth * 2) - xPadding - xVersePadding, e.Graphics);
					recalcVerses = false;
				}

				DoPaint(e.Graphics, rect);

				sw.Stop();
				Debug.WriteLine(string.Format("Painted in {0}", sw.Elapsed));
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

//			graph.SmoothingMode = SmoothingMode.AntiAlias;

			graph.FillRectangle(backColorBrush, rect);
			graph.FillRectangle(paddingColorBrush, new Rectangle(0, 0, xPadding, rect.Height));


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

				var point = new Point(xPadding + xVersePadding, y);

				if (verse.IsSelected)
				{
					verse.Y = point.Y;

					Rectangle r = verse.Rect(rect.Width, xPadding);

//					using (var brush = new LinearGradientBrush(r, SystemColors.Highlight, highlightLightenColor, LinearGradientMode.Vertical))
					{
//						brush.Blend = blend;
						graph.FillRectangle(SystemBrushes.Highlight, r);
					}

					foreach (string line in verse.EnumLines())
					{
						TextRenderer.DrawText(graph, line, Font, point, SystemColors.HighlightText, tff);
						point.Y += lineHeight;
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
							//							int lightwidth = lightlen * monoCharWidth;
							int cur = 0;

							while (cur < linelen)
							{
								int found = line.IndexOf(highlightText, cur, StringComparison.OrdinalIgnoreCase);

								if (found > -1)
								{
									int normal = found - cur;
									TextRenderer.DrawText(graph, line.Substring(cur, normal), Font, point, SystemColors.ControlText);
									//									point.X += (normal * monoCharWidth);

									TextRenderer.DrawText(graph, line.Substring(found, lightlen), Font, point, Color.Red, Color.LightPink);
									//									point.X += lightwidth;

									cur = found + lightlen;
								}
								else
								{
									TextRenderer.DrawText(graph, line.Substring(cur), Font, point, SystemColors.ControlText);
									cur = linelen;
								}
							}

							point.Y += lineHeight;
							point.X = 0;
						}
						else
						{
							TextRenderer.DrawText(graph, line, Font, point, SystemColors.ControlText, tff);
							point.Y += lineHeight;
						}
					}

					graph.DrawLine(linePen, point.X, point.Y, paintedWidth, point.Y);
				}

				visibleVerses.Add(verse);
				y = point.Y;
			}
		}

		private void RecalcVerses(int visibleHeight, int visibleWidth, Graphics g)
		{
			bool scrolled = false;
			int versesHeigth;
			bool recalc;

			var charWidthDict = new Dictionary<char, int>();
			lineHeight = 0;
			int lineWidth = 0;

			int spaceIndex = 0;
			int lineWidthLastSpace = 0;

			recalc = false;
			versesHeigth = 0;

			for (int i = 0; i < allverses.Count; i++)
			{
				VerseItem verse = allverses[i];
				verse.DropLines();

				int start = 0;
				int end = verse.Text.Length;
				int j;

				for (j = 0; j < end; j++)
				{
					char c = verse.Text[j];
					int charWidth;

					if (!charWidthDict.TryGetValue(c, out charWidth))
					{
						Size size = TextRenderer.MeasureText(g, new string(c, 1), Font, new Size(), tff);

						charWidth = size.Width;
						charWidthDict.Add(c, charWidth);

						if (lineHeight < size.Height)
							lineHeight = size.Height;
					}

					if (c == ' ')
					{
						spaceIndex = j;
					}

					lineWidth += charWidth;

					if (lineWidth >= visibleWidth)
					{
						if (spaceIndex == 0)
						{
							verse.NewLine(start, j - start, lineHeight);
							start = j;
						}
						else
						{
							verse.NewLine(start, spaceIndex - start, lineHeight);
							spaceIndex++;
							j = spaceIndex;
							start = spaceIndex;
						}

						spaceIndex = 0;
						lineWidth = 0;

						versesHeigth += lineHeight;
					}
				}

				if (lineWidth > 0)
				{
					verse.NewLine(start, j - start, lineHeight);

					spaceIndex = 0;
					lineWidth = 0;
					versesHeigth += lineHeight;
				}
			}

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
				//				SizeF sizeM = GetCharSize(base.Font, 'M');
				//				SizeF sizeDot = GetCharSize(base.Font, '.');

				//				if (sizeM != sizeDot)
				//					base.Font = new Font("Courier New", base.Font.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);

				//				SizeF size = GetCharSize(base.Font, 'M');

				//				monoCharWidth = (int)(size.Width);
				//				monoCharHeight = (int)(size.Height);

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