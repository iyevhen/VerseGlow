using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class Display : Control
	{
		private readonly Size size43 = new Size(4, 3);
		private Size etalon = new Size(4, 3);

		public Display()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse
					 | ControlStyles.Opaque // will not call OnPaintBackground
					 | ControlStyles.StandardClick
					 | ControlStyles.StandardDoubleClick
					 , true);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		public Size Etalon
		{
			get { return etalon; }
			set
			{
				etalon = value == default(Size) ? size43 : value;
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
			
			int clipWidth = rect.Width;
			int clipHeight = rect.Height;

			float myWidth = 1.0f * clipHeight * etalon.Width / etalon.Height;
			float myHeight = 1.0f * clipWidth * etalon.Height / etalon.Width;
			float y = (clipHeight - myHeight) / 2.0f;
			float x = (clipWidth - myWidth) / 2.0f;

			var myRect = new RectangleF(x, y, myWidth, myHeight);

			e.Graphics.FillRectangle(Brushes.Black, myRect);

			if (etalon == size43)
			{
				var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

				using (var font = new Font(FontFamily.GenericSansSerif, Font.Size))
					e.Graphics.DrawString("No slide", font, Brushes.White, myRect, format);
			}

			base.OnPaint(e);

#if DEBUG
			sw.Stop();
			Debug.WriteLine("Painted display in {0}", sw.Elapsed);
#endif
		}
	}
}