using System.Collections.Generic;
using System.Drawing;

namespace VerseFlow.UI.Controls
{
    internal class VerseItem
    {
        private readonly List<Line> lines = new List<Line>();

        private readonly string text;
        private int height;
        private int y;

        public VerseItem(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }

        public bool IsSelected { get; set; }

        public int Height
        {
            get { return height; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public bool IsInside(Point point)
        {
            return y <= point.Y && y + height >= point.Y;
        }

        public void NewLine(int fromIndex, int lineLength, int lineHeight)
        {
            if (fromIndex == 0 && lineLength == 0)
                return;

            lines.Add(new Line(fromIndex, lineLength));
            height += lineHeight;
        }

        public IEnumerable<string> Lines()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                yield return text.Substring(lines[i].index, lines[i].len);
            }
        }

        public void DropLines()
        {
            lines.Clear();
            height = 0;
        }

        public Rectangle Rect(int x, int width)
        {
            return new Rectangle(x, y, width, height);
        }

        private struct Line
        {
            public readonly int index;
            public readonly int len;

            public Line(int index, int len)
            {
                this.index = index;
                this.len = len;
            }
        }
    }
}