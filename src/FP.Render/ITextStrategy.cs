using System.Drawing;

namespace FreePresenter.Render
{
	public interface ITextStrategy
	{
		bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat);

		bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat);

		bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string pszText,
			Point ptDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight);

		bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int fontSize,
			string pszText,
			Rectangle rtDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight);
	}
}