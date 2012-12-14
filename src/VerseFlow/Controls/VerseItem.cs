using System.Drawing;

namespace VerseFlow.Controls
{
	internal class VerseItem
	{
		private readonly string text;
		private PointF rectFrom;
		private RectangleF rect;

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
	}
}