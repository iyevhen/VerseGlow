using System;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow
{
	public class TextView : ScrollableControl
	{
		private string textString;
		private const TextFormatFlags tff = TextFormatFlags.WordBreak
			| TextFormatFlags.WordEllipsis
			| TextFormatFlags.EndEllipsis;

		public TextView()
		{
			SetStyle(ControlStyles.DoubleBuffer 
				| ControlStyles.ResizeRedraw 
				| ControlStyles.AllPaintingInWmPaint
				| ControlStyles.ContainerControl
				| ControlStyles.UserPaint, true);
		}

		public string TextString
		{
			get { return textString; } 
			set {
				textString = value;
				
				using (var graph = CreateGraphics())
				{
					AutoScrollMinSize = TextRenderer.MeasureText(graph, textString, Font, new Size(Width, 1), tff);
					DoPaint(graph);
				}

				
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DoPaint(e.Graphics);
		}

		private void DoPaint(Graphics graph)
		{
			TextRenderer.DrawText(graph, textString, Font, ClientRectangle, ForeColor, tff);
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
		}
	}
}