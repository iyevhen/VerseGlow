using System;
using System.Drawing;

namespace FreePresenter.Render
{
	public interface IOutlineText
	{
		void TextGlow(Color clrText, Color clrOutline, int nThickness);

		void TextGlow(Brush brushText, Color clrOutline, int nThickness);

		void TextOutline(Color clrText, Color clrOutline, int nThickness);

		void TextOutline(Brush brushText, Color clrOutline, int nThickness);

		void TextDblOutline(Color clrText, Color clrOutline1, Color clrOutline2, int nThickness1, int nThickness2);

		void TextDblOutline(Brush brushText, Color clrOutline1, Color clrOutline2, int nThickness1, int nThickness2);

		void SetShadowBkgd(Bitmap pBitmap);

		void SetShadowBkgd(Color clrBkgd, int nWidth, int nHeight);

		void SetNullShadow();

		void EnableShadow(bool bEnable);

		void Shadow(Color color, int nThickness, Point ptOffset);

		bool DrawString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int nfontSize, string strText, Point ptDraw, StringFormat strFormat);

		bool DrawString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int nfontSize, string strText, Rectangle rtDraw, StringFormat pStrFormat);

		bool MeasureString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int nfontSize, string strText, Point ptDraw, StringFormat strFormat, ref float fDestWidth, ref float fDestHeight);

		bool MeasureString(Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, int nfontSize, string strText, Rectangle rtDraw, StringFormat strFormat, ref float fDestWidth, ref float fDestHeight);
	}
}