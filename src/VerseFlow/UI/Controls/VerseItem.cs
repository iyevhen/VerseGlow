using System;
using System.Collections.Generic;
using System.Drawing;

using VerseGlow.Core;

namespace VerseGlow.UI.Controls
{
    public class VerseItem
    {
        private const int interval = 2;
        private readonly List<Slice> rows = new List<Slice>();
        private readonly BibleVerse bverse;
        private Point textPosition;
        private Point position;
        private Size size;

        public VerseItem(BibleVerse bverse)
        {
            if (bverse == null)
                throw new ArgumentNullException("bverse");

            this.bverse = bverse;
        }

        public BibleVerse Bverse
        {
            get { return bverse; }
        }

        public IEnumerable<string> Rows()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                yield return bverse.Text.Substring(rows[i].index, rows[i].len);
            }
        }

        public Rectangle Rect()
        {
            return new Rectangle(position, size);
        }

        public void Refresh(Graphics graphics, int width, Renderer renderer, Point position)
        {
            rows.Clear();

            this.position = position;
            textPosition = new Point(position.X + interval, position.Y + interval);

            const char space = ' ';
            int rowLimit = width - interval - interval;
            UInt16 start = 0;
            int rowWidth = 0;
            UInt16 spaceIdx = 0;
            int end = bverse.Text.Length;
            int height = interval;
            UInt16 j;

            for (j = 0; j < end; j++)
            {
                char c = bverse.Text[j];
                int cwidth = renderer.MeasureSymbolWidth(graphics, c);

                if (c == space)
                    spaceIdx = j;

                rowWidth += cwidth;

                if (rowWidth >= rowLimit)
                {
                    if (spaceIdx == 0)
                    {
                        rows.Add(new Slice(start, (UInt16)(j - start)));
                        start = j;
                    }
                    else
                    {
                        rows.Add(new Slice(start, (UInt16)(spaceIdx - start)));
                        j = spaceIdx;
                        spaceIdx++; // NOT SURE WHY this needed
                        start = spaceIdx;
                    }

                    spaceIdx = 0;
                    rowWidth = 0;
                    height += renderer.RowHeight;
                }
            }

            if (rowWidth > 0)
            {
                rows.Add(new Slice(start, (UInt16)(j - start)));
                height += renderer.RowHeight;
            }

            height += interval;
            size = new Size(width, height);
        }

        public Size Size => size;

        public Point Position => position;

        public Point TextPosition => textPosition;

        #region Nested type

        private struct Slice
        {
            public readonly UInt16 index;
            public readonly UInt16 len;

            public Slice(UInt16 index, UInt16 len)
            {
                this.index = index;
                this.len = len;
            }
        }

        #endregion
    }
}