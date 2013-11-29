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
        private const TextFormatFlags Tff = TextFormatFlags.NoClipping
                                            | TextFormatFlags.NoFullWidthCharacterBreak
                                            | TextFormatFlags.NoPadding
                                            | TextFormatFlags.NoPrefix;

        private const int paragraph = 10;

        private readonly Blend blend = new Blend
            {
                Positions = new[] { .0f, .2f, .4f, .6f, .8f, 1 },
                Factors = new[] { 1, .8f, .3f, .3f, 0.8f, 1 }
            };

        private readonly Color highlightLightenColor;

        private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
        private List<VerseItem> allverses = new List<VerseItem>();

        private SolidBrush backColorBrush;
        private BufferedGraphics[] buffergraphs;
        private int calcWidth;
        private Dictionary<char, int> charWidthes = new Dictionary<char, int>();
        private bool highlight;
        private string highlightText;
        private int lineHeight;
        private Pen linePen;
        private SolidBrush paddingColorBrush;
        private int verseWidth;
        private Rectangle versesRect;

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

            highlightLightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 10);
        }
        
        public bool DrawSeparatorLine { get; set; }

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

        public void Fill(List<string> strings)
        {
            if (strings == null)
                throw new ArgumentNullException("strings");

            allverses = strings.ConvertAll(s => new VerseItem(s));
            calcWidth = -1;
            Invalidate();
        }
	
	    protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (backColorBrush == null)
                backColorBrush = new SolidBrush(BackColor);

            if (paddingColorBrush == null)
                paddingColorBrush = new SolidBrush(GraphicsTools.DarkenColor(BackColor, 5));

            if (linePen == null)
                linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

            //                Rectangle clientRectangle = ClientRectangle;
            var clientRectangle = new Rectangle(0, 0, Size.Width, Size.Height);


#if DEBUG
            Stopwatch sw = Stopwatch.StartNew();
#endif
            if (calcWidth != Width)
            {
                calcWidth = Width;
                Debug.WriteLine("Recalculating verses width=" + calcWidth);

                int visibleWidth = clientRectangle.Width - Padding.Right - Padding.Left;
                int visibleHeight = clientRectangle.Height - Padding.Bottom - Padding.Top;
                
                verseWidth = RecalcVerses(visibleHeight, visibleWidth, e.Graphics);
//                versesRect = new Rectangle(Padding.Left, Padding.Top, verseWidth, visibleHeight);
            }

            DoPaint(e.Graphics, clientRectangle);
            
#if DEBUG
//            e.Graphics.DrawRectangle(Pens.Blue, versesRect);
            sw.Stop();
            Debug.WriteLine(string.Format("Painted in {0}", sw.Elapsed));
#endif

            base.OnPaint(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            calcWidth = -1;
            base.OnFontChanged(e);
        }

        private void DoPaint(Graphics graphics, Rectangle rect)
        {
	        int scrollPosY = AutoScrollPosition.Y * -1;
            graphics.FillRectangle(backColorBrush, rect);

			Debug.WriteLine("Y={0}", scrollPosY);

            int cursor = 0;
            int y = 0;
            bool visible = false;
            visibleVerses.Clear();

            foreach (VerseItem verse in allverses)
            {
                //Get to visible verses
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
                    //EXIT. do not draw not visible area
                    break;
                }

                var point = new Point(Padding.Left + paragraph, y);
                Font font = Font;

                if (verse.IsSelected)
                {
                    verse.Y = point.Y;

                    Rectangle vrect = verse.Rect(0, rect.Width);

                    using (var brush = new LinearGradientBrush(
                        vrect, 
                        SystemColors.Highlight, 
                        highlightLightenColor,
                        LinearGradientMode.Vertical))
                    {
                        brush.Blend = blend;
                        graphics.FillRectangle(brush, vrect);
                    }

                    foreach (string line in verse.Lines())
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

                                    TextRenderer.DrawText(graphics, before, font, point, SystemColors.HighlightText, Tff);
                                    point.X += GetWidthOf(graphics, before);

                                    string highligten = line.Substring(found, lightlen);

                                    TextRenderer.DrawText(graphics, highligten, font, point,
                                                          GraphicsTools.InvertColor(SystemColors.HighlightText, 100),
                                                          GraphicsTools.InvertColor(SystemColors.Highlight, 100), Tff);
                                    point.X += GetWidthOf(graphics, highligten);

                                    cur = found + lightlen;
                                }
                                else
                                {
                                    TextRenderer.DrawText(graphics, line.Substring(cur), font, point,
                                                          SystemColors.HighlightText, Tff);
                                    cur = linelen;
                                }
                            }
                        }
                        else
                        {
                            TextRenderer.DrawText(graphics, line, font, point, SystemColors.HighlightText, Tff);
                        }

                        point.Y += lineHeight;
                        point.X = Padding.Left;
                    }

                    graphics.DrawRectangle(SystemPens.Highlight, vrect);
                }
                else
                {
                    verse.Y = point.Y;

                    foreach (string line in verse.Lines())
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

                                    TextRenderer.DrawText(graphics, before, font, point, SystemColors.ControlText, Tff);
                                    point.X += GetWidthOf(graphics, before);

                                    string highligten = line.Substring(found, lightlen);

                                    TextRenderer.DrawText(graphics, highligten, font, point, Color.Red, Color.LightPink,
                                                          Tff);
                                    point.X += GetWidthOf(graphics, highligten);

                                    cur = found + lightlen;
                                }
                                else
                                {
                                    TextRenderer.DrawText(graphics, line.Substring(cur), font, point,
                                                          SystemColors.ControlText, Tff);
                                    cur = linelen;
                                }
                            }
                        }
                        else
                        {
                            TextRenderer.DrawText(graphics, line, font, point, SystemColors.ControlText, Tff);
                        }

                        point.Y += lineHeight;
                        point.X = Padding.Left;
                    }

                    if (DrawSeparatorLine)
                    {
                        graphics.DrawLine(linePen, point.X, point.Y, verseWidth, point.Y);
                    }
                }

                visibleVerses.Add(verse);
                y = point.Y;
            }
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

        private int GetWidthOf(Graphics g, string text)
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
                    Size size = TextRenderer.MeasureText(g, new string(c, 1), Font, new Size(), Tff);

                    charWidth = size.Width;
                    charWidthes.Add(c, charWidth);
                }

                result += charWidth;
            }

            return result;
        }

        private int RecalcVerses(int visibleHeight, int visibleWidth, Graphics g)
        {
            charWidthes = new Dictionary<char, int>();
            lineHeight = 0;
            Font font = Font;

            bool verticalScrollBarDisplayed = false;

            int spaceIndex = 0;
            int versesHeigth = 0;

            for (int i = 0; i < allverses.Count; i++)
            {
                VerseItem verse = allverses[i];
                verse.DropLines();

                int start = 0;
                int lineWidth = paragraph;
                int end = verse.Text.Length;
                int j;

                for (j = 0; j < end; j++)
                {
                    char c = verse.Text[j];
                    int charWidth;

                    if (!charWidthes.TryGetValue(c, out charWidth))
                    {
                        Size size = TextRenderer.MeasureText(g, new string(c, 1), font, new Size(), Tff);

                        charWidth = size.Width;
                        charWidthes.Add(c, charWidth);

                        if (lineHeight < size.Height)
                            lineHeight = size.Height;
                    }

                    if (c == ' ')
                    {
                        spaceIndex = j;
                    }

                    lineWidth += charWidth;

                    if (lineWidth >= visibleWidth)
                    {
                        if (spaceIndex == 0)
                        {
                            verse.NewLine(start, j - start, lineHeight);
                            start = j;
                        }
                        else
                        {
                            verse.NewLine(start, spaceIndex - start, lineHeight);

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
                    verse.NewLine(start, j - start, lineHeight);
                    spaceIndex = 0;
                    versesHeigth += lineHeight;
                }

                if (versesHeigth > visibleHeight && !verticalScrollBarDisplayed)
                {
                    verticalScrollBarDisplayed = true;
                    visibleWidth -= SystemInformation.VerticalScrollBarWidth;
                    i = -1;
                    versesHeigth = 0;
                }
            }

            AutoScrollMinSize = new Size(visibleWidth, versesHeigth);

            return visibleWidth;
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
                    if (vb.IsInside(e.Location))
                    {
                        vb.IsSelected = !vb.IsSelected;
                        Invalidate();
                        return;
                    }
                }
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);

			if (se.ScrollOrientation == ScrollOrientation.VerticalScroll && se.OldValue != se.NewValue)
                Invalidate();
        }
    }
}