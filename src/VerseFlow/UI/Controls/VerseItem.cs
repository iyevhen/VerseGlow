using System;
using System.Collections.Generic;
using System.Drawing;
using VerseFlow.Core;

namespace VerseFlow.UI.Controls
{
	public class VerseItem
	{
		private const int interval = 2;
		private readonly List<Line> lines = new List<Line>();
		private readonly BibleVerse bverse;
		private Point textPosition;
		private Point position;
		private Size size;

		public VerseItem(BibleVerse bverse)
		{
			if (bverse == null)
				throw new ArgumentNullException("bverse");

			this.bverse = bverse;
		}

		public IEnumerable<string> Lines()
		{
			for (int i = 0; i < lines.Count; i++)
			{
				yield return bverse.Text.Substring(lines[i].index, lines[i].len);
			}
		}

		public Rectangle Rect()
		{
			return new Rectangle(position, size);
		}

		public void Refresh(Graphics graphics, int width, Renderer renderer, Point position)
		{
			lines.Clear();

			this.position = position;
			textPosition = new Point(position.X + interval, position.Y + interval);

			const char space = ' ';
			int lineLimit = width - interval - interval;
			int start = 0;
			int lineWidth = 0;
			int spaceIdx = 0;
			int end = bverse.Text.Length;
			int height = interval;
			int j;

			for (j = 0; j < end; j++)
			{
				char c = bverse.Text[j];
				int cwidth = renderer.MeasureSymbolWidth(graphics, c);

				if (c == space)
					spaceIdx = j;

				lineWidth += cwidth;

				if (lineWidth >= lineLimit)
				{
					if (spaceIdx == 0)
					{
						lines.Add(new Line(start, j - start));
						start = j;
					}
					else
					{
						lines.Add(new Line(start, spaceIdx - start));
						j = spaceIdx;
						spaceIdx++; // NOT SURE WHY this needed
						start = spaceIdx;
					}

					spaceIdx = 0;
					lineWidth = 0;
					height += renderer.LineHeight;
				}
			}

			if (lineWidth > 0)
			{
				lines.Add(new Line(start, j - start));
				height += renderer.LineHeight;
			}

			height += interval;
			size = new Size(width, height);
		}

		public bool IsSelected
		{
			get;
			set;
		}

		public Size Size
		{
			get { return size; }
		}

		public Point Position
		{
			get { return position; }
		}

		public Point TextPosition
		{
			get { return textPosition; }
		}

		#region Nested type: Line

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

		#endregion
	}
}