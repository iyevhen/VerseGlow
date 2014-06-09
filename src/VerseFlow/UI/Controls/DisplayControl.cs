using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.Properties;

namespace VerseFlow.UI.Controls
{
	public class DisplayControl : Control
	{
		private readonly Size defaultSize;
		private Size proportionSize;

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

		protected override void OnPaint(PaintEventArgs e)
		{
#if DEBUG
			Stopwatch sw = Stopwatch.StartNew();
#endif
			Rectangle rect = ClientRectangle;

			using (var brush = new SolidBrush(BackColor))
				e.Graphics.FillRectangle(brush, rect);

			int w = rect.Width;
			int h = rect.Height;

			float myWidth = 1.0f * h * proportionSize.Width / proportionSize.Height;
			float myHeight = 1.0f * w * proportionSize.Height / proportionSize.Width;

			if (myHeight > h)
				myHeight = h;

			float y = 0f;
			float x = (w - myWidth) / 2.0f;

			var drawRect = new RectangleF(x, y, myWidth, myHeight);

			e.Graphics.FillRectangle(Brushes.Black, drawRect);
//			var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

			Bitmap logo = Resources.logo_big_rus;

			Size ls = logo.Size;
			e.Graphics.DrawImage(logo, 
				drawRect.Left + (drawRect.Width - ls.Width) / 2, 
				drawRect.Top + (drawRect.Height - ls.Height) / 2, 
				ls.Width, ls.Height);

			//			using (var font = new Font(FontFamily.GenericSansSerif, Font.Size))
			//				e.Graphics.DrawString("No slide", font, Brushes.White, drawRect, format);

			base.OnPaint(e);

#if DEBUG
			sw.Stop();
			Debug.WriteLine("Painted display in {0}", sw.Elapsed);
#endif
		}
	}
}