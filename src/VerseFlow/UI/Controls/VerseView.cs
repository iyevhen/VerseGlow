using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI.Controls
{
    public class VerseView : ScrollableControl
    {
        //Buffer1: Verses 
        //Buffer2: Verses and Selected Verses 
        //Buffer3: Verses and Selected Verses and Highlighted words 
        //Buffer4: Verses and Selected Verses and Highlighted words and MouseOver words

        private readonly List<VerseItem> allverses = new List<VerseItem>();
        private int prevWidth;
        private int focusedItem = -1;
        private bool readOnly;
        private readonly VerseViewPresenter presenter;
        private readonly VerseViewColorTheme colorTheme;
        public event Action<BibleVerse> SelectedVerseChanged;

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

            colorTheme = new VerseViewColorTheme();
            presenter = new VerseViewPresenter(colorTheme, Font);
        }

        private void OnSelectedVerseChanged(BibleVerse obj)
        {
            Action<BibleVerse> handler = SelectedVerseChanged;
            if (handler != null) handler(obj);
        }

        public string HighlightText
        {
            get { return presenter.HighlightText; }
            set
            {
                presenter.HighlightText = value;
                Invalidate();
            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        public void Fill(List<VerseItem> items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            presenter.Fill(items);

            //			allverses = strings.ConvertAll(s => new VerseItem(s));
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
                    presenter.SelectedIndex = focusedItem;
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
            var rect = ClientRectangle;

            if (prevWidth != rect.Width)
            {
                prevWidth = rect.Width;
                Debug.WriteLine("Recalculating verses width=" + Width);

                presenter.SetBounds(e.Graphics, rect, Padding);
                AutoScrollMinSize = presenter.Size;
            }

            presenter.DoPaint(e.Graphics, rect, AutoScrollPosition);

            base.OnPaint(e);

#if DEBUG
            sw.Stop();
            Debug.WriteLine("Painted verses in {0}", sw.Elapsed);
#endif
        }

        protected override void OnFontChanged(EventArgs e)
        {

            base.OnFontChanged(e);

            prevWidth = -1;
            presenter.Font = Font;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            presenter.Focused = true;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            presenter.Focused = false;
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            colorTheme.BackColor = BackColor;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (colorTheme != null)
                colorTheme.Dispose();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (readOnly)
                return;

            if (e.Button == MouseButtons.Left)
            {
                Point location = e.Location;
                location.Offset(0, -AutoScrollPosition.Y);

                int index = presenter.FindIndex(location);
                SelectedIndex(index);
            }
        }

        public void SelectedIndex(int index)
        {
            presenter.SelectedIndex = index;
            OnSelectedVerseChanged(presenter.SelectedVerse);
            Invalidate();
        }
    }
}





