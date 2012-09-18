using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	public class ExtrudeStrategy : ITextStrategy
	{
		protected bool m_bClrText;
		protected Brush m_brushText;
		protected Color m_clrOutline;
		protected Color m_clrText;
		protected int m_nOffsetX;
		protected int m_nOffsetY;
		protected int m_nThickness;

		public ExtrudeStrategy()
		{
			m_nThickness = 2;
			m_brushText = null;
			m_bClrText = true;
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
			int nOffset = Math.Abs(m_nOffsetX);
			if (Math.Abs(m_nOffsetX) == Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetX);
			}
			else if (Math.Abs(m_nOffsetX) > Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetY);
			}
			else if (Math.Abs(m_nOffsetX) < Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetX);
			}

			for (int i = 0; i < nOffset; ++i)
			{
				var path = new GraphicsPath();
				path.AddString(
					strText,
					fontFamily,
					(int)fontStyle,
					fontSize,
					new Point(ptDraw.X + ((i * (-m_nOffsetX)) / nOffset), ptDraw.Y + ((i * (-m_nOffsetY)) / nOffset)),
					strFormat);

				var pen = new Pen(m_clrOutline, m_nThickness);
				pen.LineJoin = LineJoin.Round;
				graphics.DrawPath(pen, path);

				if (m_bClrText)
				{
					var brush = new SolidBrush(m_clrText);
					graphics.FillPath(brush, path);
				}
				else
					graphics.FillPath(m_brushText, path);
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
			int nOffset = Math.Abs(m_nOffsetX);
			if (Math.Abs(m_nOffsetX) == Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetX);
			}
			else if (Math.Abs(m_nOffsetX) > Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetY);
			}
			else if (Math.Abs(m_nOffsetX) < Math.Abs(m_nOffsetY))
			{
				nOffset = Math.Abs(m_nOffsetX);
			}

			for (int i = 0; i < nOffset; ++i)
			{
				var path = new GraphicsPath();
				path.AddString(
					strText,
					fontFamily,
					(int)fontStyle,
					fontSize,
					new Rectangle(
						rtDraw.X + ((i * (-m_nOffsetX)) / nOffset),
						rtDraw.Y + ((i * (-m_nOffsetY)) / nOffset),
						rtDraw.Width,
						rtDraw.Height),
					strFormat);

				var pen = new Pen(m_clrOutline, m_nThickness);
				pen.LineJoin = LineJoin.Round;
				graphics.DrawPath(pen, path);

				if (m_bClrText)
				{
					var brush = new SolidBrush(m_clrText);
					graphics.FillPath(brush, path);
				}
				else
					graphics.FillPath(m_brushText, path);
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
			path.AddString(strText, fontFamily, (int)fontStyle, fontSize, ptDraw, strFormat);

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
			path.AddString(strText, fontFamily, (int)fontStyle, fontSize, rtDraw, strFormat);

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

		#endregion

		public void Init(
			Color clrText,
			Color clrOutline,
			int nThickness,
			int nOffsetX,
			int nOffsetY)
		{
			m_clrText = clrText;
			m_bClrText = true;
			m_clrOutline = clrOutline;
			m_nThickness = nThickness;
			m_nOffsetX = nOffsetX;
			m_nOffsetY = nOffsetY;
		}

		public void Init(
			Brush brushText,
			Color clrOutline,
			int nThickness,
			int nOffsetX,
			int nOffsetY)
		{
			m_brushText = brushText;
			m_bClrText = false;
			m_clrOutline = clrOutline;
			m_nThickness = nThickness;
			m_nOffsetX = nOffsetX;
			m_nOffsetY = nOffsetY;
		}
	}
}