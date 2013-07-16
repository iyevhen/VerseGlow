using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace VerseFlow.UI.Controls
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

		public static Color HexToColor(string hexColor)
		{
			//Remove # if present
			if (hexColor.IndexOf('#') != -1)
				hexColor = hexColor.Replace("#", "");

			byte red = 0;
			byte green = 0;
			byte blue = 0;

			if (hexColor.Length == 8)
			{
				//We need to remove the preceding FF
				hexColor = hexColor.Substring(2);
			}

			if (hexColor.Length == 6)
			{
				//#RRGGBB
				red = byte.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
				green = byte.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
				blue = byte.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
			}
			else if (hexColor.Length == 3)
			{
				//#RGB
				red = byte.Parse(hexColor[0].ToString() + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
				green = byte.Parse(hexColor[1].ToString() + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
				blue = byte.Parse(hexColor[2].ToString() + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
			}

			return Color.FromArgb(255, red, green, blue);
		}

		public static Color InvertColor(Color value, int alpha = 255)
		{
			return Color.FromArgb(alpha, (byte)~value.R, (byte)~value.G, (byte)~value.B);
		}
	}
}