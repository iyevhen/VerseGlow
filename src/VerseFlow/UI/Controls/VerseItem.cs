using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	internal class VerseItem
	{
		private const TextFormatFlags tff = TextFormatFlags.NoClipping
											| TextFormatFlags.NoFullWidthCharacterBreak
											| TextFormatFlags.NoPadding
											| TextFormatFlags.NoPrefix;

		private static readonly Dictionary<char, int> glyphs = new Dictionary<char, int>();

		private readonly List<Line> lines = new List<Line>();
		private readonly string text;
		private Size size;
		private Point location;

		public VerseItem(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public bool IsSelected { get; set; }

		public Size Size
		{
			get { return size; }
		}

		public Point Location
		{
			get { return location; }
			set { location = value; }
		}

		public bool IsInside(Point point)
		{
			return point.Y > location.Y && point.Y < location.Y + size.Height;
		}

		public void NewLine(int fromIndex, int lineLength, int lineHeight)
		{
			if (fromIndex == 0 && lineLength == 0)
				return;

			lines.Add(new Line(fromIndex, lineLength));
		}

		public IEnumerable<string> Lines()
		{
			for (int i = 0; i < lines.Count; i++)
			{
				yield return text.Substring(lines[i].index, lines[i].len);
			}
		}

		public void DropLines()
		{
			lines.Clear();
			size = Size.Empty;
		}

		public Rectangle Rect(int yoffset)
		{
			return new Rectangle(location.X, location.Y + yoffset, size.Width, size.Height);
		}

		private struct Line
		{
			public readonly int index;
			public readonly int len;

			public Line(int index, int len)
			{
				this.index = index;
				this.len = len;
			}
		}

		private int GetWidthOf(Graphics g, string str, Font font)
		{
			int result = 0;

			int end = str.Length;
			int j;

			for (j = 0; j < end; j++)
			{
				char c = str[j];
				int charWidth;

				if (!glyphs.TryGetValue(c, out charWidth))
				{
					Size measured = TextRenderer.MeasureText(g, new string(c, 1), font, new Size(), tff);
					glyphs[c] = measured.Width;
					charWidth = measured.Width;
				}

				result += charWidth;
			}

			return result;
		}

		public void SetBounds(Graphics graphics, int width, VerseViewTextTheme verseViewTextTheme)
		{
			int start = 0;
			int lineWidth = 0;
			int space = 0;

			int end = text.Length;
			int j;
			const int interval = 3;

			lines.Clear();
			int height = 0;
			height += interval;

			for (j = 0; j < end; j++)
			{
				char c = text[j];
				int cwidth = verseViewTextTheme.MeasureSymbolWidth(graphics, c);

				if (c == ' ')
					space = j;

				lineWidth += cwidth;

				if (lineWidth >= width)
				{
					if (space == 0)
					{
						NewLine(start, j - start, verseViewTextTheme.LineHeight);
						start = j;
					}
					else
					{
						NewLine(start, space - start, verseViewTextTheme.LineHeight);

						j = space;
						space++; // NOT SURE WHY this needed

						start = space;
					}

					space = 0;
					lineWidth = 0;

					height += verseViewTextTheme.LineHeight;
				}
			}

			if (lineWidth > 0)
			{
				NewLine(start, j - start, verseViewTextTheme.LineHeight);
				height += verseViewTextTheme.LineHeight;
			}

			height += interval;
			size = new Size(width, height);
		}

		public void Draw(Graphics graphics, VerseViewColorTheme pbox, int offset)
		{
			var vrect = new Rectangle(location.X, location.Y + offset, size.Width, size.Height);

			if (IsSelected)
			{
				using (var brush = new LinearGradientBrush(vrect,
					SystemColors.Highlight,
					highlightLightenColor,
					LinearGradientMode.Vertical))
				{
					brush.Blend = blend;
					graphics.FillRectangle(brush, vrect);
				}

				graphics.DrawRectangle(SystemPens.Highlight, vrect);
			}
			else if (i % 2 == 1)
			{
				graphics.FillRectangle(backColorDarkerBrush, vrect);
			}

			foreach (string line in Lines())
			{
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

							TextRenderer.DrawText(graphics, before, font, point, ForeColor, Tff);
							point.X += GetWidthOf(graphics, before, font);

							string highligten = line.Substring(found, lightlen);

							TextRenderer.DrawText(graphics, highligten, font, point, Color.Red, Color.LightPink, Tff);
							point.X += GetWidthOf(graphics, highligten, font);

							cur = found + lightlen;
						}
						else
						{
							TextRenderer.DrawText(graphics, line.Substring(cur), font, point, ForeColor, Tff);
							cur = linelen;
						}
					}
				}
				else
				{
					TextRenderer.DrawText(graphics, line, font, point, ForeColor, Tff);
				}

				point.Y += lineHeight;
				point.X = Padding.Left;
			}
		}

		public static void ClearGlyphs()
		{
			glyphs.Clear();
		}
	}
}