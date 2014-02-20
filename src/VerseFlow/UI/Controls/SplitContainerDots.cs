using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class SplitContainerDots : SplitContainer
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);

			var points = new Point[3];
			Rectangle rect = ClientRectangle;
			var w = rect.Width;
			var h = rect.Height;
			var sd = SplitterDistance;
			var sw = SplitterWidth;

			//calculate the position of the points'
			if (Orientation == Orientation.Horizontal)
			{
				points[0] = new Point((w / 2), sd + (sw / 2));
				points[1] = new Point(points[0].X - 10, points[0].Y);
				points[2] = new Point(points[0].X + 10, points[0].Y);
			}
			else
			{
				points[0] = new Point(sd + (sw / 2), (h / 2));
				points[1] = new Point(points[0].X, points[0].Y - 10);
				points[2] = new Point(points[0].X, points[0].Y + 10);
			}

			foreach (Point p in points)
			{
				p.Offset(-2, -2);
				e.Graphics.FillEllipse(SystemBrushes.ControlDarkDark,
					new Rectangle(p, new Size(3, 3)));

				p.Offset(1, 1);
				e.Graphics.FillEllipse(SystemBrushes.ControlLight,
					new Rectangle(p, new Size(3, 3)));
			}
		}
	}
}