using System.Drawing;

namespace VerseFlow.Controls
{
	internal class VerseItem
	{
		private readonly string text;
		private PointF rectFrom;
		private RectangleF rect;
		private int lines;

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
			return rect.Y <= location.Y && rect.Bottom >= location.Y;
		}

		public RectangleF RectFrom(PointF location)
		{
			rect = new RectangleF(location, SizeF);
			return rect;
		}

		public void NewLine(int index, int count)
		{
			lines++;
		}

		public int Lines
		{
			get { return lines; }
		}

		public void DropLines()
		{
			lines = 0;
		}
	}
}