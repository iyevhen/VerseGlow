using System.Collections.Generic;
using System.Drawing;


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

		public void NewLine(int fromIndex, int lineLength, int lineHeight)
		{
			if (fromIndex == 0 && lineLength == 0)
				return;

			lineIdx.Add(fromIndex);
			lineLen.Add(lineLength);
			height += lineHeight;
		}

		public IEnumerable<string> EnumLines()
		{
			for (int i = 0; i < lineIdx.Count; i++)
			{
				yield return text.Substring(lineIdx[i], lineLen[i]);
			}
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