using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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
        private Size size;
        private string highlightText;
        private RowRenderer rowRenderer;
        private int selectedIndex = -1;
        private int visibleStartIdx;
        private int visibleEndIdx;

        public VerseViewPresenter(VerseViewColorTheme colorTheme, Font font)
        {
            if (font == null)
                throw new ArgumentNullException(nameof(font));

            this.colorTheme = colorTheme ?? throw new ArgumentNullException(nameof(colorTheme));
            this.rowRenderer = new RegularRowRenderer(new Renderer(font), new VerseViewColorTheme());
            this.Font = font;
        }

        public void Fill(List<VerseItem> items)
        {
            verses = items ?? throw new ArgumentNullException(nameof(items));
        }

        public VerseItem this[int index] => verses[index];

        public int VerseCount => verses.Count;

        public Font Font
        {
            get => font;
            set
            {
                font = value ?? throw new ArgumentNullException(nameof(value));
                renderer = new Renderer(value);
                rowRenderer.Renderer = renderer;
            }
        }

        public Size Size => size;

        public string HighlightText
        {
            get => highlightText;
            set
            {
                highlightText = value;

                if (value == null)
                    rowRenderer = new RegularRowRenderer(renderer, colorTheme);
                else
                    rowRenderer = new HighlightRowRenderer(renderer, colorTheme, value);
            }
        }

        public bool Focused { get; set; }

        public int FocusedIndex
        {
            get => focusedIndex;
            set
            {
                var v = value >= VerseCount ? VerseCount - 1 : value;
                focusedIndex = v < 0 ? 0 : v;
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value == selectedIndex || value < 0 || value >= verses.Count)
                    selectedIndex = -1;
                else
                    selectedIndex = value;
            }
        }

        public BibleVerse SelectedVerse => selectedIndex == -1
            ? null
            : verses[selectedIndex].Bverse;

        public void DoPaint(Graphics graphics, Rectangle rect, Point scrollPosition)
        {
            Debug.WriteLine("Paint verses: " + rect.Size);

            graphics.FillRectangle(colorTheme.BackColorBrush, rect);

            int offsetY = scrollPosition.Y;
            int i = FindVerseIndex(new Point(0, -scrollPosition.Y));

            if (i < 0)
            {
                i = 0;
            }

            visibleStartIdx = i;

            for (; i < verses.Count; i++)
            {
                visibleEndIdx = i;
                VerseItem vi = verses[i];

                if (!vi.IsVisible(rect.Height, offsetY))
                {
                    visibleEndIdx--;
                    break;
                }

                Rectangle vrect = vi.Rect();
                vrect.Offset(0, offsetY);

//                if (vrect.Y > rect.Height)
//                {
//                    visibleEndIdx--;
//                    break;
//                }

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
                    point.Offset(0, offsetY + linesHeight);

                    rowRenderer.DrawLine(graphics, line, point);
                    linesHeight += renderer.RowHeight;
                }

                if (focusedIndex == i && Focused)
                {
                    renderer.DrawFocusRectangle(graphics, vrect);
                }
            }
        }

        public Size MeasureSize(Graphics graphics, Rectangle rect, Padding padding, CancellationToken token = default(CancellationToken))
        {
            int width = rect.Width - padding.Right - padding.Left;

            int y = padding.Top;
            int x = padding.Left;

            for (int i = 0; i < verses.Count; i++)
            {
                token.ThrowIfCancellationRequested();

                VerseItem vi = verses[i];
                vi.Refresh(graphics, width, renderer, new Point(x, y));
                y += vi.Size.Height;
            }

            y += padding.Bottom;
            size = new Size(width, y);
            return size;
        }

        internal int FindVerseIndex(Point point)
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