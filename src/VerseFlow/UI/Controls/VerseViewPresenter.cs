using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	class VerseViewPresenter
	{
		private readonly VerseViewColorTheme colorTheme;
		private VerseViewTextTheme textTheme;
		private readonly List<VerseItem> verses;
		private Font font;
		private int focusedItem;
		private bool focused;

		private Size size;
		private string highlightText;

		public VerseViewPresenter(List<string> strings, VerseViewColorTheme colorTheme)
		{

			if (strings == null)
				throw new ArgumentNullException("strings");

			if (colorTheme == null)
				throw new ArgumentNullException("colorTheme");

			this.colorTheme = colorTheme;
			verses = strings.ConvertAll(s => new VerseItem(s));
		}

		public Font Font
		{
			get { return font; }
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				font = value;
				textTheme = new VerseViewTextTheme(value);
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

		public bool Focused { get; set; }

		public void SetBounds(Graphics graphics, Rectangle clientRectangle, Padding padding)
		{
			int clipWidth = clientRectangle.Width - padding.Right - padding.Left;
			int clipHeigth = clientRectangle.Height - padding.Bottom - padding.Top;

			bool withScroll = false;
			int y = 0;
			int x = padding.Left;

			for (int i = 0; i < verses.Count; i++)
			{
				VerseItem vi = verses[i];
				vi.Location = new Point(x, y);
				vi.SetBounds(graphics, clipWidth, textTheme);
				y += vi.Size.Height;

				if (!withScroll && y > clipHeigth)
				{
					clipWidth -= SystemInformation.VerticalScrollBarWidth;

					withScroll = true;
					i = -1;
					y = 0;
				}
			}

			size = new Size(clipWidth, y);
		}

		public void DoPaint(Graphics graphics, Rectangle rect, int yScroll)
		{
			graphics.FillRectangle(colorTheme.BackColorBrush, rect);

			int y = 0;
			int offset = +1;

			for (int i = 0; i < verses.Count; i++)
			{
				VerseItem vi = verses[i];

				if (offset > 0)
				{
					int diff = vi.Location.Y + yScroll;

					if (diff < -vi.Size.Height)
						continue;

					offset = yScroll - diff;
				}

				if (y > rect.Height)
				{
					break;
				}

				if (focusedItem == -1)
				{
					focusedItem = i;
				}

				vi.Draw(graphics, colorTheme, offset);

				if (focusedItem == i && focused)
				{
					ControlPaint.DrawFocusRectangle(graphics, vi.Rect(offset));
				}

				y += vi.Size.Height;
			}
		}

		private int FindVerse(int yPosition)
		{
			int position = verses.Count / 2;
			int stepSize = position / 2;

			while (true)
			{
				if (stepSize == 0)
				{
					// Couldn't find it.
					return 0;
				}

				if (verses[position].Location.Y < yPosition)
				{
					// Search down.
					position -= stepSize;

				}
				else if (verses[position].Location.Y + verses[position].Size.Height > yPosition)
				{
					// Search up.
					position += stepSize;

				}
				else
				{
					// Found it!
					return position;
				}

				stepSize /= 2;
			}
		}
	}
}