using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class FakeDisplay : Control
	{
		private readonly Size size43 = new Size(4, 3);
		private Size proportionSize = new Size(4, 3);

		public FakeDisplay()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse
					 | ControlStyles.Opaque // will not call OnPaintBackground
					 | ControlStyles.StandardClick
					 | ControlStyles.StandardDoubleClick, true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		public Size ProportionSize
		{
			get { return proportionSize; }
			set
			{
				proportionSize = value == default(Size) ? size43 : value;
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
			var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

			using (var font = new Font(FontFamily.GenericSansSerif, Font.Size))
				e.Graphics.DrawString("No slide", font, Brushes.White, drawRect, format);

			base.OnPaint(e);

#if DEBUG
			sw.Stop();
			Debug.WriteLine("Painted display in {0}", sw.Elapsed);
#endif
		}
	}
}