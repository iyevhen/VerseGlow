﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VerseFlow.Controls
{
	static class GraphicsTools
	{
		public static Color LightenColor(Color colorIn, int percent)
		{
			if (percent < 0 || percent > 100)
				throw new ArgumentOutOfRangeException("percent");

			int a, r, g, b;

			a = colorIn.A;
			r = colorIn.R + (int)(((255f - colorIn.R) / 100f) * percent);
			g = colorIn.G + (int)(((255f - colorIn.G) / 100f) * percent);
			b = colorIn.B + (int)(((255f - colorIn.B) / 100f) * percent);

			return Color.FromArgb(a, r, g, b);
		}

		public static Color DarkenColor(Color colorIn, int percent)
		{
			//This method returns Black if you Darken by 100%

			if (percent < 0 || percent > 100)
				throw new ArgumentOutOfRangeException("percent");

			int a, r, g, b;

			a = colorIn.A;
			r = colorIn.R - (int)((colorIn.R / 100f) * percent);
			g = colorIn.G - (int)((colorIn.G / 100f) * percent);
			b = colorIn.B - (int)((colorIn.B / 100f) * percent);

			return Color.FromArgb(a, r, g, b);
		}

		public static GraphicsPath RoundRectangle(Rectangle r, int radius, Corners corners)
		{
			//Make sure the Path fits inside the rectangle
			r.Width -= 1;
			r.Height -= 1;

			//Scale the radius if it's too large to fit.
			if (radius > (r.Width))
				radius = r.Width;
			if (radius > (r.Height))
				radius = r.Height;

			var path = new GraphicsPath();

			if (radius <= 0)
				path.AddRectangle(r);
			else if ((corners & Corners.TopLeft) == Corners.TopLeft)
				path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
			else
				path.AddLine(r.Left, r.Top, r.Left, r.Top);

			if ((corners & Corners.TopRight) == Corners.TopRight)
				path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
			else
				path.AddLine(r.Right, r.Top, r.Right, r.Top);

			if ((corners & Corners.BottomRight) == Corners.BottomRight)
				path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
			else
				path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);

			if ((corners & Corners.BottomLeft) == Corners.BottomLeft)
				path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
			else
				path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);

			path.CloseFigure();

			return path;
		}
	}
}