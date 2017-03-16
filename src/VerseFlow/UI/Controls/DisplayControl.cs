using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using VerseGlow.Properties;

namespace VerseGlow.UI.Controls
{
    public class DisplayControl : Control
    {
        private readonly Size defaultSize;
        private Size proportionSize;
        private readonly IDrawTheme defaultTheme = new LogoOnly();

        private StringFormat centeredString = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public DisplayControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.UserPaint
                     | ControlStyles.UserMouse
                     | ControlStyles.Opaque // will not call OnPaintBackground
                     | ControlStyles.StandardClick
                     | ControlStyles.StandardDoubleClick, true);

            defaultSize = new Size(4, 3);
            proportionSize = defaultSize;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public Size ProportionSize
        {
            get { return proportionSize; }
            set
            {
                proportionSize = value == default(Size)
                    ? defaultSize
                    : value;
                Invalidate();
            }
        }

        public IDrawTheme Theme { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
#if DEBUG
            Stopwatch sw = Stopwatch.StartNew();
#endif
            Rectangle clientRect = ClientRectangle;

            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, clientRect);
            }

            int cw = clientRect.Width;
            int ch = clientRect.Height;

            float myWidth = 1.0f * ch * proportionSize.Width / proportionSize.Height;
            float myHeight = 1.0f * cw * proportionSize.Height / proportionSize.Width;

            if (myHeight > ch)
                myHeight = ch;

            float y = 0f;
            float x = (cw - myWidth) / 2.0f;
            var drawRect = new RectangleF(x, y, myWidth, myHeight);

            var theme = Theme ?? defaultTheme;
            theme.DrawSlide(e.Graphics, drawRect);
            //            using (var font = new Font(FontFamily.GenericSansSerif, Font.Size))
            //            {
            //                e.Graphics.DrawString("No slide", font, Brushes.White, drawRect, format);
            //            }

            base.OnPaint(e);

#if DEBUG
            sw.Stop();
            Debug.WriteLine("Painted display in {0}", sw.Elapsed);
#endif
        }
    }

    internal class LogoOnly : IDrawTheme
    {
        public void DrawSlide(Graphics graphics, RectangleF inRect)
        {
            graphics.FillRectangle(Brushes.Black, inRect);
            Bitmap logo = Resources.logo_big_rus;
            Size logSize = logo.Size;
            graphics.DrawImage(logo,
                inRect.Left + (inRect.Width - logSize.Width) / 2,
                inRect.Top + (inRect.Height - logSize.Height) / 2,
                logSize.Width, logSize.Height);
        }
    }

    public interface IDrawTheme
    {
        void DrawSlide(Graphics graphics, RectangleF inRect);
    }
}