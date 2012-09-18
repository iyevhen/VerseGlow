using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace FreePresenter.Render
{
	static class ImageServices
	{
		public static Image ResizeImage(string imagePath, int width, int height)
		{
			using (Image src = Image.FromFile(imagePath))
			{
				var dst = new Bitmap(width, height);

				using (Graphics g = Graphics.FromImage(dst))
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					g.DrawImage(src, 0, 0, dst.Width, dst.Height);
				}

				return dst;
			}
		}
	}
}
