using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow
{
	public class VerseView : ScrollableControl
	{
		private List<VerseBox> verses = new List<VerseBox>();
		private static StringFormat stringFormat;


		public VerseView()
		{
			SetStyle(ControlStyles.DoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.ContainerControl
					 | ControlStyles.UserPaint, true);
		}


		public void Populate(IList<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = new List<VerseBox>();
			int heigth = 0;

			Size proposedSize = ClientRectangle.Size;

			using (Graphics graph = CreateGraphics())
			{
				for (int i = 0; i < strings.Count; i++)
				{
					Size size = TextRenderer.MeasureText(graph, strings[i], Font, proposedSize);
					verses.Add(new VerseBox(strings[i], size, heigth));

					heigth += size.Height;
				}

				AutoScrollMinSize = new Size(proposedSize.Width, heigth);

				Invalidate();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.LightGray, e.ClipRectangle);
			//			base.OnPaintBackground(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DoPaint(e.Graphics, e.ClipRectangle);
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			float y = 0;

			foreach (VerseBox vbox in verses)
			{
				if (y > rect.Height)
					return;
				var size = MeasureDisplayString(graph, vbox.Text, Font, rect.Width);
				var rr = new RectangleF(new PointF(0, y), size);

				graph.DrawString(vbox.Text, Font, Brushes.Black, rr, stringFormat);
				graph.DrawRectangles(Pens.Blue, new[] { rr });
				y += rr.Height;
			}
		}

		private static SizeF MeasureDisplayString(Graphics graphics, string text, Font font, int width)
		{
			stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
			var rect = new RectangleF(0, 0, width, 1000);
			CharacterRange[] ranges = { new CharacterRange(0, text.Length) };

			stringFormat.SetMeasurableCharacterRanges(ranges);

			Region[] regions = graphics.MeasureCharacterRanges(text, font, rect, stringFormat);
			rect = regions[0].GetBounds(graphics);

			return rect.Size;
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
		}
	}

	internal class VerseBox
	{
		private readonly int position;
		private readonly Size size;
		private readonly string text;

		public VerseBox(string text, Size size, int position)
		{
			this.text = text;
			this.size = size;
			this.position = position;
		}

		public int Position
		{
			get { return position; }
		}

		public string Text
		{
			get { return text; }
		}

		public Size Size
		{
			get { return size; }
		}
	}
}