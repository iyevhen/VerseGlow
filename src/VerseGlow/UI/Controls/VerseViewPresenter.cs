using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using VerseGlow.Core;
using VerseGlow.UI.Controls.LineRenderers;

namespace VerseGlow.UI.Controls
{
    class VerseViewPresenter
    {
        private readonly VerseViewColorTheme colorTheme;
        private Renderer renderer;
        private List<VerseItem> verses = new List<VerseItem>();
        private Font font;
        private int focusedIndex;
        private bool focused;
        private Size size;
        private string highlightText;
        private RowRenderer rowRenderer;
        private int selectedIndex = -1;

        public VerseViewPresenter(VerseViewColorTheme colorTheme, Font font)
        {
            if (colorTheme == null)
                throw new ArgumentNullException("colorTheme");

            if (font == null)
                throw new ArgumentNullException("colorTheme");

            this.colorTheme = colorTheme;
            rowRenderer = new RegularRowRenderer(new Renderer(font), new VerseViewColorTheme());
            Font = font;
        }

        public void Fill(List<VerseItem> items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            verses = items;
        }

        public VerseItem this[int index]
        {
            get { return verses[index]; }
        }

        public Font Font
        {
            get { return font; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                font = value;
                renderer = new Renderer(value);
                rowRenderer.Renderer = renderer;
            }
        }

        public Size Size
        {
            get { return size; }
        }

        public string HighlightText
        {
            get { return highlightText; }
            set
            {
                highlightText = value;

                if (value == null)
                    rowRenderer = new RegularRowRenderer(renderer, colorTheme);
                else
                    rowRenderer = new HighlightRowRenderer(renderer, colorTheme, value);
            }
        }

        public bool Focused
        {
            get { return focused; }
            set { focused = value; }
        }

        public int FocusedIndex
        {
            get { return focusedIndex; }
            set
            {
                if (value < 0 || value >= verses.Count)
                    focusedIndex = -1;
                else
                    focusedIndex = value;
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value == selectedIndex || value < 0 || value >= verses.Count)
                    selectedIndex = -1;
                else
                    selectedIndex = value;
            }
        }

        public BibleVerse SelectedVerse
        {
            get
            {
                return selectedIndex == -1
                    ? null
                    : verses[selectedIndex].Bverse;
            }
        }

        public void DoPaint(Graphics graphics, Rectangle rect, Point scrollPosition)
        {
            Debug.WriteLine("Paint verses: " + rect.Size);

            graphics.FillRectangle(colorTheme.BackColorBrush, rect);

            int offset = scrollPosition.Y;

            for (int i = 0; i < verses.Count; i++)
            {
                VerseItem vi = verses[i];

                if ((offset + vi.Position.Y + vi.Size.Height) < 0)
                {
                    continue;
                }

                if (focusedIndex == -1)
                {
                    focusedIndex = i;
                }

                Rectangle vrect = vi.Rect();
                vrect.Offset(0, offset);

                if (vrect.Y > rect.Height)
                {
                    break;
                }

                if (i == selectedIndex)
                {
                    using (var brush = colorTheme.NewHighlightBrush(vrect))
                    {
                        graphics.FillRectangle(brush, vrect);
                    }

                    var edge = vrect;
                    edge.Offset(-1, -1);
                    graphics.DrawRectangle(colorTheme.HighlightColorPen, edge);
                }
                else if (i % 2 == 0)
                {
                    graphics.FillRectangle(colorTheme.BackColorDarkerBrush, vrect);
                }

                int linesHeight = 0;

                foreach (string line in vi.Rows())
                {
                    Point point = vi.TextPosition;
                    point.Offset(0, offset + linesHeight);

                    rowRenderer.DrawLine(graphics, line, point);
                    linesHeight += renderer.RowHeight;
                }

                if (focusedIndex == i && focused)
                {
                    renderer.DrawFocusRectangle(graphics, vrect);
                }
            }
        }

        public void SetBounds(Graphics graphics, Rectangle rect, Padding padding)
        {
            int width = rect.Width - padding.Right - padding.Left;

            int y = padding.Top;
            int x = padding.Left;

            for (int i = 0; i < verses.Count; i++)
            {
                VerseItem vi = verses[i];
                vi.Refresh(graphics, width, renderer, new Point(x, y));
                y += vi.Size.Height;
            }

            y += padding.Bottom;
            size = new Size(width, y);
        }

        internal int FindIndex(Point point)
        {
            int begin = 0;
            int end = verses.Count - 1;

            while (begin <= end)
            {
                int i = (begin + end) / 2;

                if (verses[i].Position.Y > point.Y)
                    end = i - 1;
                else if (verses[i].Position.Y + verses[i].Size.Height < point.Y)
                    begin = i + 1;
                else
                    return i;
            }

            return -1;
        }
    }
}