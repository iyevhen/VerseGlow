using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	class TextGlowStrategy : ITextStrategy
	{
		private bool m_bClrText;
		private Brush m_brushText;
		private Color m_clrOutline;
		private Color m_clrText;
		private int m_nThickness;

		public TextGlowStrategy()
		{
			m_nThickness = 2;
			m_brushText = null;
			m_bClrText = true;
		}

		public bool DrawString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int fontSize, string strText, Point ptDraw, StringFormat strFormat)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int) fontStyle, fontSize, ptDraw, strFormat);

			for (int i = 1; i <= m_nThickness; ++i)
			{
				var pen = new Pen(m_clrOutline, i);
				pen.LineJoin = LineJoin.Round;
				graphics.DrawPath(pen, path);
			}

			if (m_bClrText)
			{
				var brush = new SolidBrush(m_clrText);
				graphics.FillPath(brush, path);
			}
			else
				graphics.FillPath(m_brushText, path);

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

			for (int i = 1; i <= m_nThickness; ++i)
			{
				var pen = new Pen(m_clrOutline, i);
				pen.LineJoin = LineJoin.Round;
				graphics.DrawPath(pen, path);
			}

			if (m_bClrText)
			{
				var brush = new SolidBrush(m_clrText);
				graphics.FillPath(brush, path);
			}
			else
				graphics.FillPath(m_brushText, path);

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
			b = GDIPath.ConvertToPixels(graphics, m_nThickness, 0.0f, ref pixelThick, ref pixelThick2);

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
			b = GDIPath.ConvertToPixels(graphics, m_nThickness, 0.0f, ref pixelThick, ref pixelThick2);

			if (false == b)
				return false;

			fDestWidth += pixelThick;
			fDestHeight += pixelThick;

			return true;
		}


		public void Init(
			Color clrText,
			Color clrOutline,
			int nThickness)
		{
			m_clrText = clrText;
			m_bClrText = true;
			m_clrOutline = clrOutline;
			m_nThickness = nThickness;
		}

		public void Init(
			Brush brushText,
			Color clrOutline,
			int nThickness)
		{
			m_brushText = brushText;
			m_bClrText = false;
			m_clrOutline = clrOutline;
			m_nThickness = nThickness;
		}
	}
}