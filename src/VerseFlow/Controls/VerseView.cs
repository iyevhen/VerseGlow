using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace VerseFlow.Controls
{
	public class VerseView : ScrollableControl
	{
		private const int minLeftIndent = 8;
		private static readonly StringFormat stringFormat = new StringFormat();

		private readonly Blend blend = new Blend
			{
				Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
				Factors = new[] { 1, .8f, .4f, .4f, 0.8f, 1 }
			};

		private readonly object candy = new object();
		private readonly Color lightenColor;
		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private SolidBrush backColorBrush;
		private Pen linePen;
		private bool recalcVerses;
		private List<VerseItem> verses = new List<VerseItem>();
		private int versesWidth;
		private int width;
		private int charHeight;
		private int lineInterval;
		private bool needRecalc;
		private int charWidth;

		public VerseView()
		{
			SetStyle(ControlStyles.DoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse, true);

			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;

			VerticalScroll.Enabled = true;
			VerticalScroll.Visible = true;

			stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			stringFormat.LineAlignment = StringAlignment.Center;
			lightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 20);
		}

		[DefaultValue(typeof(Font), "Courier New, 10.75")]
		public override Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;

				//check monospace font
				SizeF sizeM = GetCharSize(base.Font, 'M');
				SizeF sizeDot = GetCharSize(base.Font, '.');

				if (sizeM != sizeDot)
					base.Font = new Font("Courier New", base.Font.SizeInPoints, FontStyle.Regular, GraphicsUnit.Point);

				SizeF size = GetCharSize(base.Font, 'M');

				charWidth = (int)(size.Width);
				charHeight = lineInterval + (int)(size.Height);

				recalcVerses = true;
				Invalidate();
			}
		}

		private static SizeF GetCharSize(Font font, char c)
		{
			Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
			Size sz3 = TextRenderer.MeasureText("<>", font);

			return new SizeF(sz2.Width - sz3.Width, font.Height);
		}

		public void Populate(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = strings.ConvertAll(s => new VerseItem(s));

			recalcVerses = true;
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e) { }

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (Width != width)
			{
				recalcVerses = true;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				width = Width;

				if (backColorBrush == null)
					backColorBrush = new SolidBrush(BackColor);

				if (linePen == null)
					linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

				Rectangle rect = ClientRectangle;

				if (recalcVerses)
				{
					Stopwatch sw1 = Stopwatch.StartNew();

					RecalcVerses(rect.Height);
					recalcVerses = false;

					sw1.Stop();
					Debug.WriteLine("REFRESHED in {0} - Size - {1}", sw1.Elapsed, AutoScrollMinSize);
				}

				Stopwatch sw2 = Stopwatch.StartNew();

				DoPaint(e.Graphics, rect);

				sw2.Stop();
				Debug.WriteLine("Painted in {0}", sw2.Elapsed);
			}

			base.OnPaint(e);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			backColorBrush = null;
			linePen = null;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (backColorBrush != null)
				backColorBrush.Dispose();

			if (linePen != null)
				linePen.Dispose();
		}

		private void DoPaint(Graphics graph, Rectangle rect)
		{
			int scrollPosY = AutoScrollPosition.Y * -1;

			graph.FillRectangle(backColorBrush, rect);

			int cursor = 0;
			int y = 0;
			bool visible = false;

			visibleVerses.Clear();

			foreach (VerseItem verse in verses)
			{
				if (!visible)
				{
					cursor += verse.Height;

					if (cursor < scrollPosY)
						continue;

					y = cursor - verse.Height - scrollPosY;
					visible = true;
				}

				if (y > rect.Height)
				{
					// do not draw not visible area
					break;
				}

				var point = new Point(0, y);

				if (verse.Selected)
				{
					verse.Y = point.Y;

					graph.FillRectangle(SystemBrushes.Highlight, verse.Rect(rect.Width));

					foreach (string line in verse.EnumLines())
					{
						TextRenderer.DrawText(graph, line, Font, point, SystemColors.HighlightText);
						point.Y += charHeight;
					}
				}
				else
				{
					verse.Y = point.Y;

					foreach (string line in verse.EnumLines())
					{
						TextRenderer.DrawText(graph, line, Font, point, SystemColors.ControlText);
						point.Y += charHeight;
					}

					graph.DrawLine(linePen, point.X, point.Y, versesWidth, point.Y);
				}

				visibleVerses.Add(verse);
				y = point.Y;
			}
		}

		private void RecalcVerses(int visibleHeight)
		{
			int versesHeigth = 0;
			versesWidth = Width - 1;
			bool verticalScrollExcluded = false;
			int charsInLine = (versesWidth / charWidth) - 1;

			for (int i = 0; i < verses.Count; i++)
			{
				VerseItem vb = verses[i];
				vb.DropLines();

				int start = 0;
				int end = vb.Text.Length;
				int marker = charsInLine;

				while (marker < end)
				{
					int idx = vb.Text.LastIndexOf(' ', marker, charsInLine);
					int count = idx > -1 ? (idx - start) : charsInLine;

					vb.NewLine(start, count, charHeight);

					start += count;
					marker += count;
				}

				if (end > start)
					vb.NewLine(start, end - start, charHeight);

				versesHeigth += vb.Height;

				if (!verticalScrollExcluded && versesHeigth > visibleHeight)
				{
					i = -1;
					versesHeigth = 0;
					versesWidth -= SystemInformation.VerticalScrollBarWidth;
					charsInLine = (versesWidth / charWidth) - 1;
					verticalScrollExcluded = true;
				}
			}

			AutoScrollMinSize = new Size(versesWidth, versesHeigth + 1);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			Invalidate(ClientRectangle);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (e.Button == MouseButtons.Left)
			{
				foreach (VerseItem vb in visibleVerses)
				{
					if (vb.In(e.Location))
					{
						vb.Selected = !vb.Selected;
						Invalidate();
						break;
					}
				}
			}
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);

			if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
				Invalidate(ClientRectangle);
		}
	}
}