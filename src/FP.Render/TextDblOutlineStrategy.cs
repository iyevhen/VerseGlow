using System.Drawing;
using System.Drawing.Drawing2D;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	public class TextDblOutlineStrategy : ITextStrategy
	{
		protected bool m_bClrText;
		protected Brush m_brushText;
		protected Color m_clrOutline1;
		protected Color m_clrOutline2;
		protected Color m_clrText;
		protected int m_nThickness1;
		protected int m_nThickness2;

		public TextDblOutlineStrategy()
		{
			m_nThickness1 = 2;
			m_nThickness2 = 2;
			m_brushText = null;
			m_bClrText = true;
		}

		#region ITextStrategy Members

		public bool DrawString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int fontSize, string strText, Point ptDraw, StringFormat strFormat)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int)fontStyle, fontSize, ptDraw, strFormat);

			using (var pen2 = new Pen(m_clrOutline2, m_nThickness1 + m_nThickness2) { LineJoin = LineJoin.Round })
				graphics.DrawPath(pen2, path);

			using (var pen1 = new Pen(m_clrOutline1, m_nThickness1) { LineJoin = LineJoin.Round })
				graphics.DrawPath(pen1, path);

			if (m_bClrText)
			{
				using (var brush = new SolidBrush(m_clrText))
					graphics.FillPath(brush, path);
			}
			else
				graphics.FillPath(m_brushText, path);

			return true;
		}


		public bool DrawString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int fontSize, string strText, Rectangle rtDraw, StringFormat strFormat)
		{
			var path = new GraphicsPath();
			path.AddString(strText, fontFamily, (int)fontStyle, fontSize, rtDraw, strFormat);

			var pen2 = new Pen(m_clrOutline2, m_nThickness1 + m_nThickness2) { LineJoin = LineJoin.Round };
			graphics.DrawPath(pen2, path);

			var pen1 = new Pen(m_clrOutline1, m_nThickness1) { LineJoin = LineJoin.Round };
			graphics.DrawPath(pen1, path);

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
			path.AddString(strText, fontFamily, (int)fontStyle, fontSize, ptDraw, strFormat);

			fDestWidth = ptDraw.X;
			fDestHeight = ptDraw.Y;
			bool b = GDIPath.MeasureGraphicsPath(graphics, path, ref fDestWidth, ref fDestHeight);

			if (false == b)
				return false;

			float pixelThick = 0.0f;
			float pixelThick2 = 0.0f;
			b = GDIPath.ConvertToPixels(graphics, m_nThickness1 + m_nThickness2, 0.0f, ref pixelThick, ref pixelThick2);

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
			b = GDIPath.ConvertToPixels(graphics, m_nThickness1 + m_nThickness2, 0.0f, ref pixelThick, ref pixelThick2);

			if (false == b)
				return false;

			fDestWidth += pixelThick;
			fDestHeight += pixelThick;

			return true;
		}

		#endregion

		public void Init(
			Color clrText,
			Color clrOutline1,
			Color clrOutline2,
			int nThickness1,
			int nThickness2)
		{
			m_clrText = clrText;
			m_bClrText = true;
			m_clrOutline1 = clrOutline1;
			m_clrOutline2 = clrOutline2;
			m_nThickness1 = nThickness1;
			m_nThickness2 = nThickness2;
		}

		public void Init(
			Brush brushText,
			Color clrOutline1,
			Color clrOutline2,
			int nThickness1,
			int nThickness2)
		{
			m_brushText = brushText;
			m_bClrText = false;
			m_clrOutline1 = clrOutline1;
			m_clrOutline2 = clrOutline2;
			m_nThickness1 = nThickness1;
			m_nThickness2 = nThickness2;
		}
	}
}