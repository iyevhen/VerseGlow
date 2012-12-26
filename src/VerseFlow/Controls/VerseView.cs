﻿using System;
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
		private bool refreshVerses;
		private List<VerseItem> verses = new List<VerseItem>();
		private int versesWidth;
		private int width;
		private int charHeight;
		private int lineInterval;
		private bool needRecalc;

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

		/// <summary>
		/// Font
		/// </summary>
		/// <remarks>Use only monospaced font</remarks>
		[DefaultValue(typeof(Font), "Courier New, 9.75")]
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

				//clac size
				SizeF size = GetCharSize(base.Font, 'M');

				CharWidth = (int)(size.Width);
				CharHeight = lineInterval + (int)(size.Height);

				//				CharWidth = (int)Math.Round(size.Width * 1f /*0.85*/) - 1 /*0*/;
				//				CharHeight = lineInterval + (int)Math.Round(size.Height * 1f /*0.9*/) - 1 /*0*/;
				//
				needRecalc = true;
				Invalidate();
			}
		}

		/// <summary>
		/// Width of char in pixels
		/// </summary>
		[Description("Width of char in pixels")]
		public int CharWidth { get; private set; }

		[Description("Height of char in pixels")]
		public int CharHeight
		{
			get { return charHeight; }
			private set
			{
				charHeight = value;
				OnCharSizeChanged();
			}
		}

		/// <summary>
		/// Interval between lines (in pixels)
		/// </summary>
		[Description("Interval between lines in pixels")]
		[DefaultValue(0)]
		public int LineInterval
		{
			get { return lineInterval; }
			set
			{
				lineInterval = value;
				Font = Font;
				Invalidate();
			}
		}

		protected virtual void OnCharSizeChanged()
		{
			VerticalScroll.SmallChange = charHeight;
			VerticalScroll.LargeChange = 10 * charHeight;
		}

		private static SizeF GetCharSize(Font font, char c)
		{
			Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
			Size sz3 = TextRenderer.MeasureText("<>", font);

			//			return new SizeF(sz2.Width - sz3.Width + 1, /*sz2.Height*/font.Height);
			return new SizeF(sz2.Width - sz3.Width, /*sz2.Height*/font.Height);
		}

		public void Populate(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			verses = strings.ConvertAll(s => new VerseItem(s));
			refreshVerses = true;
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e) { }

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (Size.Width != width)
				refreshVerses = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			lock (candy)
			{
				width = Size.Width;

				Stopwatch sw = Stopwatch.StartNew();
				Debug.WriteLine("Paint START{0}----------------------------------------------{1}", e.ClipRectangle, DateTime.Now);
				DoPaint(e.Graphics, ClientRectangle);
				sw.Stop();
				Debug.WriteLine("Paint DONE in {0}", sw.Elapsed);
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
			if (backColorBrush == null)
				backColorBrush = new SolidBrush(BackColor);

			if (linePen == null)
				linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

			int scrollPosY = AutoScrollPosition.Y * -1;

			graph.FillRectangle(backColorBrush, rect);

			if (refreshVerses)
			{
				RecalcVerses(rect.Height);
				refreshVerses = false;
			}

			int cursor = 0;
			int y = 0;
			bool visible = false;

			visibleVerses.Clear();

			foreach (VerseItem verse in verses)
			{
				if (!visible)
				{
					int verHeight = verse.Height;

					if ((cursor + verHeight) < scrollPosY)
					{
						cursor += verHeight;
						continue;
					}

					y = cursor - scrollPosY;
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
			Stopwatch sw = Stopwatch.StartNew();

			int versesHeigth = 0;
			versesWidth = Width - 1;
			bool verticalScrollExcluded = false;
			int charsInLine = (versesWidth / CharWidth) - 1;

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
					charsInLine = (versesWidth / CharWidth) - 1;
					verticalScrollExcluded = true;
				}
			}

			AutoScrollMinSize = new Size(versesWidth, versesHeigth + 1);

			sw.Stop();
			Debug.WriteLine("REFRESHED in {0} - Size - {1}", sw.Elapsed, AutoScrollMinSize);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			Debug.WriteLine("OnMouseWheel={0}", e.Delta);
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