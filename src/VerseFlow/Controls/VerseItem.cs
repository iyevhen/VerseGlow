using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VerseFlow.Controls
{
	internal class VerseItem
	{
		private readonly string text;
//		private RectangleF rect;
		private List<int> lineIdx = new List<int>();
		private List<int> lineLen = new List<int>();

		public VerseItem(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public SizeF SizeF { get; set; }

		public bool Selected { get; set; }

		public bool In(Point location)
		{
//			return rect.Y <= location.Y && rect.Bottom >= location.Y;
			return false;
		}

//		public RectangleF RectFrom(PointF location)
//		{
//			rect = new RectangleF(location, SizeF);
//			return rect;
//		}

		public void NewLine(int index, int count)
		{
			lineIdx.Add(index);
			lineLen.Add(count);
		}

		public IEnumerable<string> EnumLines()
		{
			return lineIdx.Select((t, i) => text.Substring(t, lineLen[i]));
		}

		public int LinesCount
		{
			get { return lineIdx.Count; }
		}

		public void DropLines()
		{
			lineIdx.Clear();
			lineLen.Clear();
		}
	}
}