using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
    public class VerseView : ScrollableControl
    {
        BufferedGraphics[] buffergraphs;

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
        private bool highlight;
        private string highlightText;
        private int lineHeight;
        private Pen linePen;
        private SolidBrush paddingColorBrush;
        private Dictionary<char, int> charWidthes = new Dictionary<char, int>();
        private bool verticalScrollBarDisplayed;
        private int sepLineX;
        private int calcWidth;

        public VerseView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.UserPaint
                     | ControlStyles.UserMouse, true);

            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;

            VerticalScroll.Enabled = true;
            VerticalScroll.Visible = true;

            highlightLightenColor = GraphicsTools.LightenColor(SystemColors.Highlight, 10);
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

//        protected override void OnSizeChanged(EventArgs e)
//        {
//            base.OnSizeChanged(e);
//
//            if (Width != calcWidth)
//            {
//                Debug.WriteLine("Width changed");
//                
//               
//                recalc = true;
//            }
//        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //            lock (candy)
            {
//                int myWidth = Width;

                if (backColorBrush == null)
                    backColorBrush = new SolidBrush(BackColor);

                if (paddingColorBrush == null)
                    paddingColorBrush = new SolidBrush(GraphicsTools.DarkenColor(BackColor, 5));

                if (linePen == null)
                    linePen = new Pen(GraphicsTools.DarkenColor(BackColor, 15));

                Rectangle rect = ClientRectangle;

#if DEBUG
                Stopwatch sw = Stopwatch.StartNew();
#endif

                if (calcWidth != Width)
                {
                    calcWidth = Width;
                    Debug.WriteLine("Recalculating verses");

                    int visibleWidth = calcWidth - (Padding.Left + Padding.Right);
                    int visibleHeight = rect.Height - (Padding.Top + Padding.Bottom);

                    RecalcVerses(visibleHeight, visibleWidth, e.Graphics);
                  

                    sepLineX = calcWidth - Padding.Right;

                    if (verticalScrollBarDisplayed)
                        sepLineX -= -SystemInformation.VerticalScrollBarWidth;
                }

                DoPaint(e.Graphics, rect);
#if DEBUG
                sw.Stop();
                Debug.WriteLine(string.Format("Painted in {0}", sw.Elapsed));
#endif

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

        private void DoPaint(Graphics graphics, Rectangle rect)
        {
            int scrollPosY = AutoScrollPosition.Y * -1;

            graphics.FillRectangle(backColorBrush, rect);

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

                if (verse.IsSelected)
                {
                    verse.Y = point.Y;

                    Rectangle r = verse.Rect(rect.Width, 0);

                    using (var brush = new LinearGradientBrush(r, SystemColors.Highlight, highlightLightenColor, LinearGradientMode.Vertical))
                    {
                        brush.Blend = blend;
                        graphics.FillRectangle(brush, r);
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

                                    TextRenderer.DrawText(graphics, before, Font, point, SystemColors.HighlightText, Tff);
                                    point.X += GetWidthOf(graphics, before);

                                    string highligten = line.Substring(found, lightlen);

                                    TextRenderer.DrawText(graphics, highligten, Font, point, GraphicsTools.InvertColor(SystemColors.HighlightText, 100), GraphicsTools.InvertColor(SystemColors.Highlight, 100), Tff);
                                    point.X += GetWidthOf(graphics, highligten);

                                    cur = found + lightlen;
                                }
                                else
                                {
                                    TextRenderer.DrawText(graphics, line.Substring(cur), Font, point, SystemColors.HighlightText, Tff);
                                    cur = linelen;
                                }
                            }
                        }
                        else
                        {
                            TextRenderer.DrawText(graphics, line, Font, point, SystemColors.HighlightText, Tff);
                        }

                        point.Y += lineHeight;
                        point.X = Padding.Left;
                    }

                    graphics.DrawRectangle(SystemPens.Highlight, r);
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

                                    TextRenderer.DrawText(graphics, before, Font, point, SystemColors.ControlText, Tff);
                                    point.X += GetWidthOf(graphics, before);

                                    string highligten = line.Substring(found, lightlen);

                                    TextRenderer.DrawText(graphics, highligten, Font, point, Color.Red, Color.LightPink, Tff);
                                    point.X += GetWidthOf(graphics, highligten);

                                    cur = found + lightlen;
                                }
                                else
                                {
                                    TextRenderer.DrawText(graphics, line.Substring(cur), Font, point, SystemColors.ControlText, Tff);
                                    cur = linelen;
                                }
                            }
                        }
                        else
                        {
                            TextRenderer.DrawText(graphics, line, Font, point, SystemColors.ControlText, Tff);
                        }

                        point.Y += lineHeight;
                        point.X = Padding.Left;
                    }

                    if (DrawSeparatorLine)
                    {
                        graphics.DrawLine(linePen, point.X, point.Y, sepLineX, point.Y);
                    }
                }

                visibleVerses.Add(verse);
                y = point.Y;
            }
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

        private void RecalcVerses(int visibleHeight, int visibleWidth, Graphics g)
        {
            charWidthes = new Dictionary<char, int>();
            lineHeight = 0;
            int spaceIndex = 0;
            verticalScrollBarDisplayed = false;
            int versesHeigth = 0;

            int vw = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;

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
                        Size size = TextRenderer.MeasureText(g, new string(c, 1), Font, new Size(), Tff);

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
                            spaceIndex++;
                            j = spaceIndex;
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

            if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
                Invalidate(ClientRectangle);
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                calcWidth = -1;
                Invalidate();
            }
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
    }
}