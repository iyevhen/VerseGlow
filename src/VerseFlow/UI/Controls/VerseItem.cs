using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VerseFlow.UI.Controls
{
	internal class VerseItem
	{
		private readonly List<int> lineIdx = new List<int>();
		private readonly List<int> lineLen = new List<int>();
		private readonly string text;
		private int height;
		private int y;

		public VerseItem(string text)
		{
			this.text = text;
		}

		public bool IsInside(Point point)
		{
			return y <= point.Y && y + height >= point.Y;
		}

		public void NewLine(int index, int count, int lineHeight)
		{
			if (index == 0 && count == 0)
				return;

			lineIdx.Add(index);
			lineLen.Add(count);
			height += lineHeight;
		}

		public IEnumerable<string> EnumLines()
		{
			return lineIdx.Select((index, i) => text.Substring(index, lineLen[i]));
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

		public string Text
		{
			get { return text; }
		}

		public bool IsSelected { get; set; }

		public int Height
		{
			get { return height; }
		}

		public int Y
		{
			get { return y; }
			set { y = value; }
		}
	}
}