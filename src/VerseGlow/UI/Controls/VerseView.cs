using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using VerseGlow.Core;

namespace VerseGlow.UI.Controls
{
    public class VerseView : ScrollableControl
    {
        //Buffer1: Verses 
        //Buffer2: Verses and Selected Verses 
        //Buffer3: Verses and Selected Verses and Highlighted words 
        //Buffer4: Verses and Selected Verses and Highlighted words and MouseOver words

        private int prevWidth;
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
            handler?.Invoke(obj);
        }

        public string HighlightText
        {
            get => presenter.HighlightText;
            set
            {
                presenter.HighlightText = value;
                Invalidate();
            }
        }

        public bool ReadOnly { get; set; }

        public void Fill(List<VerseItem> items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            presenter.Fill(items);

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


            if (ReadOnly)
            {
                return;
            }

            switch (e.KeyData)
            {
                case Keys.Down:
                    presenter.FocusedIndex += 1;
                    Invalidate();
                    break;
                case Keys.Up:
                    presenter.FocusedIndex -= 1;
                    Invalidate();
                    break;
                case Keys.Down | Keys.Control:
                    AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y - VerticalScroll.SmallChange));
                    Invalidate();
                    break;
                case Keys.Up | Keys.Control:
                    AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y + VerticalScroll.SmallChange));
                    Invalidate();
                    break;
                case Keys.Space:
                    presenter.SelectedIndex = presenter.FocusedIndex;
                    Invalidate();
                    break;
                case Keys.End:
                    AutoScrollPosition = new Point(0, AutoScrollMinSize.Height);
                    Invalidate();
                    break;
                case Keys.Home:
                    AutoScrollPosition = new Point(0, 0);
                    Invalidate();
                    break;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        CancellationTokenSource cts = null;
        readonly StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap)
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

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

                cts?.Cancel();
                cts = new CancellationTokenSource();

                var task = Task.Factory
                    .StartNew(() =>
                    {
                        using (var b = new Bitmap(1, 1))
                        {
                            using (var g = Graphics.FromImage(b))
                            {
                                return presenter.MeasureSize(g, rect, Padding, cts.Token);
                            }
                        }
                    }, cts.Token);
                task.ContinueWith(t =>
                {
                    Debug.WriteLine($"MeasureSize : {t.Status}");
                }, TaskContinuationOptions.OnlyOnCanceled);
                task.ContinueWith(t =>
                    {
                        cts = null;
                        AutoScrollMinSize = t.Result;
                        Invalidate();
                    }, cts.Token, TaskContinuationOptions.NotOnCanceled, TaskScheduler.FromCurrentSynchronizationContext());
            }

            if (cts != null)
            {
                e.Graphics.FillRectangle(SystemBrushes.Control, rect);
                e.Graphics.DrawString("Calculating...", Font, SystemBrushes.ControlText, rect, fmt);
            }
            else
            {
                presenter.DoPaint(e.Graphics, rect, AutoScrollPosition);
            }

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

            colorTheme?.Dispose();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (ReadOnly)
                return;

            if (e.Button == MouseButtons.Left)
            {
                Point location = e.Location;
                location.Offset(0, -AutoScrollPosition.Y);

                int index = presenter.FindVerseIndex(location);
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





