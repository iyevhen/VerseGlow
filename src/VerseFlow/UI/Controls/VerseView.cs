using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class VerseView : ScrollableControl
	{
		//Buffer1: Verses 
		//Buffer2: Verses and Selected Verses 
		//Buffer3: Verses and Selected Verses and Highlighted words 
		//Buffer4: Verses and Selected Verses and Highlighted words and MouseOver words

		private const TextFormatFlags Tff = TextFormatFlags.NoClipping
											| TextFormatFlags.NoFullWidthCharacterBreak
											| TextFormatFlags.NoPadding
											| TextFormatFlags.NoPrefix;

		const int interval = 3;

		private readonly Blend blend = new Blend
			{
				Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
				Factors = new[] { 1, .8f, .3f, .3f, 0.8f, 1 }
			};

		private readonly Color highlightLightenColor;

		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private List<VerseItem> allverses = new List<VerseItem>();

		private SolidBrush backColorBrush;
		private SolidBrush backColorVerseBrush;
		private int prevWidth;
		private Dictionary<char, int> charWidthes = new Dictionary<char, int>();
		private bool highlight;
		private string highlightText;
		private int lineHeight;
		private bool focused;
		private int focusedItem = -1;
		private bool readOnly;
		private VerseDispatcher dispatcher;

		public VerseView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse
					 | ControlStyles.Selectable
					 | ControlStyles.Opaque // will not call OnPaintBackground
					 | ControlStyles.StandardClick
					 | ControlStyles.StandardDoubleClick
					 , true);

			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;

			VerticalScroll.Enabled = true;
			VerticalScroll.Visible = true;

			highlightLightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 25);
		}

		public string HighlightText
		{
			get { return highlightText; }
			set
			{
				highlightText = value;
				highlight = !string.IsNullOrEmpty(value);
				Invalidate();
			}
		}

		public bool ReadOnly
		{
			get { return readOnly; }
			set { readOnly = value; }
		}

		public void SelectItem(int index)
		{
			if (index > -1 && index < allverses.Count)
			{
				allverses[index].IsSelected = !allverses[index].IsSelected;
			}
		}

		public void SetFocusedItem(int index)
		{
			if (index > -1 && index < allverses.Count)
				focusedItem = index;
		}

		public void Fill(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			dispatcher = new VerseDispatcher(strings);
			allverses = strings.ConvertAll(s => new VerseItem(s));
			prevWidth = -1;
			AutoScrollPosition = new Point(0, 0);
			Invalidate();
		}

		

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Down || keyData == Keys.Up)
				return true;
			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
				e.Handled = true;

			base.OnKeyDown(e);
		}

		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			//			base.OnPreviewKeyDown(e);

			if (readOnly)
				return;

			if (e.KeyCode == Keys.Down)
			{
				if (e.Modifiers == Keys.Control)
					AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y - VerticalScroll.SmallChange));
				else if (focusedItem + 1 < allverses.Count)
					focusedItem++;

				Invalidate();
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (e.Modifiers == Keys.Control)
					AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y + VerticalScroll.SmallChange));
				else if (focusedItem - 1 > -1)
					focusedItem--;

				Invalidate();
			}
			else if (e.KeyData == Keys.Space)
			{
				if (focusedItem > -1)
				{
					allverses[focusedItem].IsSelected = !allverses[focusedItem].IsSelected;
					Invalidate();
				}
			}
			else if (e.KeyData == Keys.End)
			{
				AutoScrollPosition = new Point(0, AutoScrollMinSize.Height);
				Invalidate();
			}
			else if (e.KeyData == Keys.Home)
			{
				AutoScrollPosition = new Point(0, 0);
				Invalidate();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{

#if DEBUG
			Stopwatch sw = Stopwatch.StartNew();
#endif
			if (backColorBrush == null)
				backColorBrush = new SolidBrush(BackColor);

			if (backColorVerseBrush == null)
				backColorVerseBrush = new SolidBrush(GraphicsTools.DarkenColor(BackColor, 7));

			var clientRectangle = new Rectangle(0, 0, Size.Width, Size.Height);

			if (prevWidth != Width) // start re-calculation only if width changed
			{
				prevWidth = Width;
				Debug.WriteLine("Recalculating verses width=" + Width);

				int versesWidth = clientRectangle.Width - Padding.Right - Padding.Left;
				int versesHeight = clientRectangle.Height - Padding.Bottom - Padding.Top;

				AutoScrollMinSize = RecalculateVersesSize(versesHeight, versesWidth, e.Graphics, Font);
			}


			DoPaint(e.Graphics, clientRectangle);

			base.OnPaint(e);

#if DEBUG
			sw.Stop();
			Debug.WriteLine("Painted verses in {0}", sw.Elapsed);
#endif
		}

		private Size RecalculateVersesSize(int versesHeight, int versesWidth, Graphics graphics, Font font)
		{
			bool verticalScrollBarDisplayed = false;
			int spaceIndex = 0;
			int versesHeigth = 0;

			for (int i = 0; i < allverses.Count; i++)
			{
				VerseItem vi = allverses[i];
				vi.DropLines();

				versesHeigth += interval;

				int start = 0;
				int lineWidth = 0;
				int end = vi.Text.Length;
				int j;

				for (j = 0; j < end; j++)
				{
					char verseChar = vi.Text[j];
					int verseCharWidth;

					if (!charWidthes.TryGetValue(verseChar, out verseCharWidth))
					{
						Size size = TextRenderer.MeasureText(graphics, new string(verseChar, 1), font, new Size(), Tff);

						verseCharWidth = size.Width;
						charWidthes.Add(verseChar, verseCharWidth);

						if (lineHeight < size.Height)
							lineHeight = size.Height;
					}

					if (verseChar == ' ')
					{
						spaceIndex = j;
					}

					lineWidth += verseCharWidth;

					if (lineWidth >= versesWidth)
					{
						if (spaceIndex == 0)
						{
							vi.NewLine(start, j - start, lineHeight);
							start = j;
						}
						else
						{
							vi.NewLine(start, spaceIndex - start, lineHeight);

							j = spaceIndex;
							spaceIndex++; // NOT SURE WHY this needed

							start = spaceIndex;
						}

						spaceIndex = 0;
						lineWidth = 0;

						versesHeigth += lineHeight;
					}
				}

				if (lineWidth > 0)
				{
					vi.NewLine(start, j - start, lineHeight);
					spaceIndex = 0;
					versesHeigth += lineHeight;
				}

				if (versesHeigth > versesHeight && !verticalScrollBarDisplayed)
				{
					verticalScrollBarDisplayed = true;
					versesWidth -= SystemInformation.VerticalScrollBarWidth;
					i = -1;
					versesHeigth = 0;
				}
				else
				{
					versesHeigth += interval;
				}
			}

			return new Size(versesWidth, versesHeigth);
		}

		private void DoPaint(Graphics graphics, Rectangle rect)
		{
			int scrollYTop = -AutoScrollPosition.Y;

			int verseIndex = FindVerse(-AutoScrollPosition.Y);

			int cursor = 0;
			int y = 0;
			bool visible = false;
			Font font = Font;
			visibleVerses.Clear();

			graphics.FillRectangle(backColorBrush, rect);

			for (int i = 0; i < allverses.Count; i++)
			{
				VerseItem vi = allverses[i];

				if (!visible)
				{
					cursor += interval + vi.Height + interval;

					if (cursor < scrollYTop)
						continue;

					y = cursor - interval - vi.Height - interval - scrollYTop;
					visible = true;
				}

				if (y > rect.Height)
				{
					Debug.WriteLine("Break");
					break;
				}

				var point = new Point(Padding.Left, y + interval);

				if (focusedItem == -1)
					focusedItem = i;

				vi.Y = point.Y;

				Rectangle vrect = vi.Rect(AutoScrollMinSize.Width + Padding.Left + Padding.Right);
				vrect.Inflate(0, interval);

				if (vi.IsSelected)
				{
					using (var brush = new LinearGradientBrush(vrect,
						SystemColors.Highlight,
						highlightLightenColor,
						LinearGradientMode.Vertical))
					{
						brush.Blend = blend;
						graphics.FillRectangle(brush, vrect);
					}

					graphics.DrawRectangle(SystemPens.Highlight, vrect);
				}
				else if (i % 2 == 1)
				{
					graphics.FillRectangle(backColorVerseBrush, vrect);
				}

				foreach (string line in vi.Lines())
				{
					if (highlight)
					{
						int linelen = line.Length;
						int lightlen = highlightText.Length;

						int cur = 0;

						while (cur < linelen)
						{
							int found = line.IndexOf(highlightText, cur, StringComparison.OrdinalIgnoreCase);

							if (found > -1)
							{
								int normal = found - cur;
								string before = line.Substring(cur, normal);

								TextRenderer.DrawText(graphics, before, font, point, ForeColor, Tff);
								point.X += GetWidthOf(graphics, before, font);

								string highligten = line.Substring(found, lightlen);

								TextRenderer.DrawText(graphics, highligten, font, point, Color.Red, Color.LightPink, Tff);
								point.X += GetWidthOf(graphics, highligten, font);

								cur = found + lightlen;
							}
							else
							{
								TextRenderer.DrawText(graphics,
									line.Substring(cur),
									font,
									point,
									ForeColor,
									Tff);

								cur = linelen;
							}
						}
					}
					else
					{
						TextRenderer.DrawText(graphics, line, font, point, ForeColor, Tff);
					}

					point.Y += lineHeight;
					point.X = Padding.Left;
				}

				if (focusedItem == i && (focused || readOnly))
				{
					Rectangle frect = vi.Rect(AutoScrollMinSize.Width + Padding.Left + Padding.Right);
					ControlPaint.DrawFocusRectangle(graphics, frect);
				}

				visibleVerses.Add(vi);
				y = point.Y + interval;
			}
		}

		protected override void OnFontChanged(EventArgs e)
		{
			charWidthes = new Dictionary<char, int>();
			lineHeight = 0;
			prevWidth = -1;

			base.OnFontChanged(e);
		}

		private int FindVerse(int yPosition)
		{
			//			 int position = allverses.Count / 2;
			//    int stepSize = position / 2;
			//
			//    while (true) {
			//        if (stepSize == 0) {
			//            // Couldn't find it.
			//            return 0;
			//        }
			//
			//        if (allverses[position].High < number) {
			//            // Search down.
			//            position -= stepSize;
			//
			//        } else if (RangeGroups[position].Low > number) {
			//            // Search up.
			//            position += stepSize;
			//
			//        } else {
			//            // Found it!
			//            return RangeGroups[position];
			//        }
			//
			//        stepSize /= 2;
			//    }

			//			verses.

			return 0;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			focused = true;
			Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);

			focused = false;
			Invalidate();
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			backColorBrush = null;
			backColorVerseBrush = null;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (backColorBrush != null)
				backColorBrush.Dispose();

			if (backColorVerseBrush != null)
				backColorVerseBrush.Dispose();
		}

		private int GetWidthOf(Graphics g, string text, Font font)
		{
			int result = 0;

			int end = text.Length;
			int j;

			for (j = 0; j < end; j++)
			{
				char c = text[j];
				int charWidth;

				if (!charWidthes.TryGetValue(c, out charWidth))
				{
					Size size = TextRenderer.MeasureText(g, new string(c, 1), font, new Size(), Tff);

					charWidth = size.Width;
					charWidthes.Add(c, charWidth);
				}

				result += charWidth;
			}

			return result;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (readOnly)
				return;

			if (e.Button == MouseButtons.Left)
			{
				foreach (VerseItem vb in visibleVerses)
				{
					if (vb.IsInside(e.Location))
					{
						vb.IsSelected = !vb.IsSelected;
						Invalidate();
						return;
					}
				}
			}
		}
	}

	class VerseDispatcher
	{
//		private List<VerseItem> allverses;

		public VerseDispatcher(List<string> strings)
		{
//			if (strings == null)
//				throw new ArgumentNullException("strings");
//
//			allverses = strings.ConvertAll(s => new VerseItem(s));
		}
	}
}





