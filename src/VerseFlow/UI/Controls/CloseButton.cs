using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization.Advanced;

namespace VerseFlow.UI.Controls
{
	public partial class CloseButton : UserControl
	{
		private int edge = 22;

		public CloseButton()
		{
			SetStyle(ControlStyles.DoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse
					 | ControlStyles.Selectable
					 | ControlStyles.Opaque // will not call OnPaintBackground
					 | ControlStyles.StandardClick
					 | ControlStyles.StandardDoubleClick
					 , true);

			Size = new Size(edge, edge);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			var size = Size;

			if (size.Width == size.Height)
				return;

			int shortest = size.Width > size.Height ? size.Height : size.Width;
			int longest = size.Width > size.Height ? size.Width : size.Height;

			if (shortest == edge)
				edge = longest;
			else
				edge = shortest;

//			edge = shortest;

			Size = new Size(edge, edge);
		}


		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(SystemBrushes.Control, e.ClipRectangle);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			ControlPaint.DrawCaptionButton(e.Graphics,
				ClientRectangle, 
				CaptionButton.Close, 
				ButtonState.Normal);
		}
	}

	public class SplitContainerDots : SplitContainer
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);

			var points = new Point[3];
			var w = e.ClipRectangle.Width;
			var h = e.ClipRectangle.Height;
			var d = SplitterDistance;
			var sW = SplitterWidth;

			//calculate the position of the points'
			if (Orientation == Orientation.Horizontal)
			{
				points[0] = new Point((w / 2), d + (sW / 2));
				points[1] = new Point(points[0].X - 10, points[0].Y);
				points[2] = new Point(points[0].X + 10, points[0].Y);
			}
			else
			{
				points[0] = new Point(d + (sW / 2), (h / 2));
				points[1] = new Point(points[0].X, points[0].Y - 10);
				points[2] = new Point(points[0].X, points[0].Y + 10);
			}

			foreach (Point p in points)
			{
				p.Offset(-2, -2);
				e.Graphics.FillEllipse(SystemBrushes.ControlDark,
					new Rectangle(p, new Size(3, 3)));

				p.Offset(1, 1);
				e.Graphics.FillEllipse(SystemBrushes.ControlLight,
					new Rectangle(p, new Size(3, 3)));
			}
		}
	}
}
