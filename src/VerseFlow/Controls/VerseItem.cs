using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VerseFlow.Controls
{
	internal class VerseItem
	{
		private readonly string text;
		private readonly List<int> lineIdx = new List<int>();
		private readonly List<int> lineLen = new List<int>();
		private int y;
		private int height;

		public VerseItem(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public bool Selected { get; set; }

		public bool In(Point location)
		{
			return y <= location.Y && y + height >= location.Y;
		}

		public int Height
		{
			get { return height; }
		}

		public void NewLine(int index, int count, int lineHeight)
		{
			lineIdx.Add(index);
			lineLen.Add(count);
			height += lineHeight;
		}

		public IEnumerable<string> EnumLines()
		{
			return lineIdx.Select((index, i) => text.Substring(index, lineLen[i]));
		}

		public int LinesCount
		{
			get { return lineIdx.Count; }
		}

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		public void DropLines()
		{
			lineIdx.Clear();
			lineLen.Clear();
			height = 0;
		}

		public Rectangle Rect(int width)
		{
			return new Rectangle(0, y, width, height);
		}
	}
}