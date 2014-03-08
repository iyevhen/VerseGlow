using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	class VerseViewPresenter
	{
		private readonly VerseViewColorTheme colorTheme;
		private Renderer renderer;
		private List<VerseItem> verses = new List<VerseItem>();
		private Font font;
		private int focusedIndex;
		private bool focused;

		private Size size;
		private string highlightText;

		public VerseViewPresenter(VerseViewColorTheme colorTheme)
		{
			if (colorTheme == null)
				throw new ArgumentNullException("colorTheme");

			this.colorTheme = colorTheme;
		}

		public void Fill(List<VerseItem> items)
		{
			if (items == null)
				throw new ArgumentNullException("items");

			verses = items;
		}

		public VerseItem this[int index]
		{
			get { return verses[index]; }
		}

		public Font Font
		{
			get { return font; }
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				font = value;
				renderer = new Renderer(value);
			}
		}

		public Size Size
		{
			get { return size; }
		}

		public string HighlightText
		{
			get { return highlightText; }
			set { highlightText = value; }
		}

		public bool Focused
		{
			get { return focused; }
			set { focused = value; }
		}

		public int FocusedIndex
		{
			get { return focusedIndex; }
			set { focusedIndex = value; }
		}

		public void DoPaint(Graphics graphics, Rectangle rect, Point scrollPosition)
		{
			Debug.WriteLine("Paint verses: " + rect.Size);

			graphics.FillRectangle(colorTheme.BackColorBrush, rect);

			int offset = scrollPosition.Y;

			for (int i = 0; i < verses.Count; i++)
			{
				VerseItem vi = verses[i];

				if ((offset + vi.Position.Y + vi.Size.Height) < 0)
				{
					continue;
				}

				if (focusedIndex == -1)
				{
					focusedIndex = i;
				}

				var vrect = vi.Rect();
				vrect.Offset(0, offset);

				if (vrect.Y > rect.Height)
				{
					//Debug.WriteLine("Stop paint [{0}]: {1}", i + 1, vrect.Location);
					break;
				}

				//Debug.WriteLine("Paint [{0}]: {1} - {2}", i + 1, vrect.Location, vrect.Size);

				if (vi.IsSelected)
				{
					using (var brush = colorTheme.NewHighlightBrush(vrect))
						graphics.FillRectangle(brush, vrect);

					graphics.DrawRectangle(colorTheme.HighlightColorPen, vrect);
				}
				else if (i % 2 == 0)
				{
					graphics.FillRectangle(colorTheme.BackColorDarkerBrush, vrect);
				}

				int linesHeight = 0;

				foreach (string line in vi.Lines())
				{
					Point point = vi.TextPosition;
					point.Offset(0, offset + linesHeight);

					if (!string.IsNullOrEmpty(highlightText))
					{
						int linelen = line.Length;
						int lightlen = highlightText.Length;

						int cur = 0;

						while (cur < linelen)
						{
							int found = line.IndexOf(highlightText, cur, StringComparison.OrdinalIgnoreCase);

							if (found > -1)
							{
								int normal = found - cur;
								string before = line.Substring(cur, normal);

								renderer.DrawText(graphics, before, point, colorTheme.TextColor);
								point.X += renderer.MeasureTextWidth(graphics, before);

								string highligten = line.Substring(found, lightlen);

								renderer.DrawText(graphics, highligten, point, colorTheme.TextHighlightColor, colorTheme.TextHighlightBackColor);
								point.X += renderer.MeasureTextWidth(graphics, highligten);

								cur = found + lightlen;
							}
							else
							{
								renderer.DrawText(graphics, line.Substring(cur), point, colorTheme.TextColor);
								cur = linelen;
							}
						}
					}
					else
					{
						renderer.DrawText(graphics, line, point, colorTheme.TextColor);
					}

					linesHeight += renderer.LineHeight;
				}

				if (focusedIndex == i && focused)
				{
					renderer.DrawFocusRectangle(graphics, vrect);
				}
			}
		}

		public void Refresh(Graphics graphics, Rectangle clientRectangle, Padding padding)
		{
			int clipWidth = clientRectangle.Width - padding.Right - padding.Left;

			int y = padding.Top;
			int x = padding.Left;

			for (int i = 0; i < verses.Count; i++)
			{
				VerseItem vi = verses[i];
				vi.Refresh(graphics, clipWidth, renderer, new Point(x, y));
				y += vi.Size.Height;
			}

			y += padding.Bottom;
			size = new Size(clipWidth, y);
		}

		internal int FindIndex(Point point)
		{
			int begin = 0;
			int end = verses.Count - 1;

			while (begin <= end)
			{
				int i = (begin + end) / 2;

				if (verses[i].Position.Y > point.Y)
					end = i - 1;
				else if (verses[i].Position.Y + verses[i].Size.Height < point.Y)
					begin = i + 1;
				else
					return i;
			}


			return -1;
		}
	}
}