using System.Drawing;
using System.Drawing.Drawing2D;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	internal class DiffusedShadowStrategy : ITextStrategy
	{
		private Brush brushText;
		private bool clrText;
		private Color colorOutline;
		private Color colorText;
		private bool isOutline;
		private int thickness;

		public DiffusedShadowStrategy()
		{
			thickness = 8;
			isOutline = false;
			brushText = null;
			clrText = true;
		}

		#region ITextStrategy Members

		public bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat)
		{
			using (var path = new GraphicsPath())
			{
				path.AddString(strText, fontFamily, (int) fontStyle, fontSize, ptDraw, strFormat);

				for (int i = 1; i <= thickness; ++i)
				{
					using (var pen = new Pen(colorOutline, i))
					{
						pen.LineJoin = LineJoin.Round;
						graphics.DrawPath(pen, path);
					}
				}

				if (isOutline == false)
				{
					for (int i = 1; i <= thickness; ++i)
					{
						if (clrText)
						{
							using (var brush = new SolidBrush(colorText))
								graphics.FillPath(brush, path);
						}
						else
							graphics.FillPath(brushText, path);
					}
				}
				else
				{
					if (clrText)
					{
						using (var brush = new SolidBrush(colorText))
							graphics.FillPath(brush, path);
					}
					else
						graphics.FillPath(brushText, path);
				}
			}

			return true;
		}


		public bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int) fontStyle, fontSize, rtDraw, strFormat);

			for (int i = 1; i <= thickness; ++i)
			{
				var pen = new Pen(colorOutline, i);
				pen.LineJoin = LineJoin.Round;
				graphics.DrawPath(pen, path);
			}

			if (isOutline == false)
			{
				for (int i = 1; i <= thickness; ++i)
				{
					if (clrText)
					{
						var brush = new SolidBrush(colorText);
						graphics.FillPath(brush, path);
					}
					else
						graphics.FillPath(brushText, path);
				}
			}
			else
			{
				if (clrText)
				{
					var brush = new SolidBrush(colorText);
					graphics.FillPath(brush, path);
				}
				else
					graphics.FillPath(brushText, path);
			}

			return true;
		}


		public bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int) fontStyle, fontSize, ptDraw, strFormat);

			fDestWidth = ptDraw.X;
			fDestHeight = ptDraw.Y;
			bool b = GDIPath.MeasureGraphicsPath(graphics, path, ref fDestWidth, ref fDestHeight);

			if (false == b)
				return false;

			float pixelThick = 0.0f;
			float pixelThick2 = 0.0f;
			b = GDIPath.ConvertToPixels(graphics, thickness, 0.0f, ref pixelThick, ref pixelThick2);

			if (false == b)
				return false;

			fDestWidth += pixelThick;
			fDestHeight += pixelThick;

			return true;
		}

		public bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int) fontStyle, fontSize, rtDraw, strFormat);

			fDestWidth = rtDraw.Width;
			fDestHeight = rtDraw.Height;
			bool b = GDIPath.MeasureGraphicsPath(graphics, path, ref fDestWidth, ref fDestHeight);

			if (false == b)
				return false;

			float pixelThick = 0.0f;
			float pixelThick2 = 0.0f;
			b = GDIPath.ConvertToPixels(graphics, thickness, 0.0f, ref pixelThick, ref pixelThick2);

			if (false == b)
				return false;

			fDestWidth += pixelThick;
			fDestHeight += pixelThick;

			return true;
		}

		#endregion

		public void Init(
			Color clrText,
			Color clrOutline,
			int nThickness,
			bool bOutlinetext)
		{
			colorText = clrText;
			this.clrText = true;
			colorOutline = clrOutline;
			thickness = nThickness;
			isOutline = bOutlinetext;
		}

		public void Init(
			Brush brushText,
			Color clrOutline,
			int nThickness,
			bool bOutlinetext)
		{
			this.brushText = brushText;
			clrText = false;
			colorOutline = clrOutline;
			thickness = nThickness;
			isOutline = bOutlinetext;
		}
	}
}