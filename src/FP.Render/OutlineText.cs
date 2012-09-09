using System;
using System.Drawing;
using System.Drawing.Imaging;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	public class OutlineText : IOutlineText
	{
		private bool diffuseShadow;
		private bool enableShadow;
		private bool extrudeShadow;
		private Color shadowColor = Color.FromArgb(0, 0, 0);
		private int shadowThickness = 2;
		private Bitmap backgroundImage;
		private ITextStrategy fontBodyShadow;
		private ITextStrategy shadowStrategy;
		private ITextStrategy textStrategy;
		private Point shadowOffset;

		public void TextGlow(
			Color clrText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextGlowStrategy();
			pStrat.Init(clrText, clrOutline, nThickness);

			textStrategy = pStrat;
		}

		public void TextGlow(
			Brush brushText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextGlowStrategy();
			pStrat.Init(brushText, clrOutline, nThickness);

			textStrategy = pStrat;
		}

		public void TextOutline(
			Color clrText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(clrText, clrOutline, nThickness);

			textStrategy = pStrat;
		}

		public void TextOutline(
			Brush brushText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(brushText, clrOutline, nThickness);

			textStrategy = pStrat;
		}

		public void TextDblOutline(
			Color clrText,
			Color clrOutline1,
			Color clrOutline2,
			int nThickness1,
			int nThickness2)
		{
			var pStrat = new TextDblOutlineStrategy();
			pStrat.Init(clrText, clrOutline1, clrOutline2, nThickness1, nThickness2);

			textStrategy = pStrat;
		}

		public void TextDblOutline(
			Brush brushText,
			Color clrOutline1,
			Color clrOutline2,
			int nThickness1,
			int nThickness2)
		{
			var pStrat = new TextDblOutlineStrategy();
			pStrat.Init(brushText, clrOutline1, clrOutline2, nThickness1, nThickness2);

			textStrategy = pStrat;
		}

		public void SetShadowBkgd(Bitmap pBitmap)
		{
			backgroundImage = pBitmap;
		}

		public void SetShadowBkgd(Color clrBkgd, int nWidth, int nHeight)
		{
			backgroundImage = new Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);

			Graphics graphics = Graphics.FromImage(backgroundImage);
			var brush = new SolidBrush(clrBkgd);
			graphics.FillRectangle(brush, 0, 0, backgroundImage.Width, backgroundImage.Height);
		}


		public void SetNullShadow()
		{
			fontBodyShadow = null;
			shadowStrategy = null;
		}


		public void EnableShadow(bool bEnable)
		{
			enableShadow = bEnable;
		}


		public void Shadow(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness);

			shadowColor = color;

			var pFontBodyShadow = new TextOutlineStrategy();
			pFontBodyShadow.Init(Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0, 0), 0);
			fontBodyShadow = pFontBodyShadow;

			shadowOffset = ptOffset;
			shadowStrategy = pStrat;
			diffuseShadow = false;
		}


		public bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat)
		{
			if (enableShadow && shadowStrategy != null)
			{
				shadowStrategy.DrawString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Point(ptDraw.X + shadowOffset.X, ptDraw.Y + shadowOffset.Y),
					strFormat);
			}

			if (enableShadow && backgroundImage != null && fontBodyShadow != null)
			{
				RenderFontShadow(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Point(ptDraw.X + shadowOffset.X, ptDraw.Y + shadowOffset.Y),
					strFormat);
			}

			if (textStrategy != null)
			{
				return textStrategy.DrawString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					ptDraw,
					strFormat);
			}

			return false;
		}


		public bool DrawString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat)
		{
			if (enableShadow && shadowStrategy != null)
			{
				shadowStrategy.DrawString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Rectangle(rtDraw.X + shadowOffset.X, rtDraw.Y + shadowOffset.Y, rtDraw.Width, rtDraw.Height),
					strFormat);
			}

			if (enableShadow && backgroundImage != null && fontBodyShadow != null)
			{
				RenderFontShadow(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Rectangle(rtDraw.X + shadowOffset.X, rtDraw.Y + shadowOffset.Y, rtDraw.Width, rtDraw.Height),
					strFormat);
			}

			if (textStrategy != null)
			{
				return textStrategy.DrawString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					rtDraw,
					strFormat);
			}

			return false;
		}

		public bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight)
		{
			float fDestWidth1 = 0.0f;
			float fDestHeight1 = 0.0f;
			bool b = textStrategy.MeasureString(
				graphics,
				fontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat,
				ref fDestWidth1,
				ref fDestHeight1);

			if (!b)
				return false;

			float fDestWidth2 = 0.0f;
			float fDestHeight2 = 0.0f;
			if (enableShadow)
			{
				b = shadowStrategy.MeasureString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					ptDraw,
					strFormat,
					ref fDestWidth2,
					ref fDestHeight2);

				if (b)
				{
					float fDestWidth3 = 0.0f;
					float fDestHeight3 = 0.0f;
					b = GDIPath.ConvertToPixels(
						graphics,
						shadowOffset.X,
						shadowOffset.Y,
						ref fDestWidth3,
						ref fDestHeight3);
					if (b)
					{
						fDestWidth2 += fDestWidth3;
						fDestHeight2 += fDestHeight3;
					}
				}
				else
					return false;
			}

			if (fDestWidth1 > fDestWidth2 || fDestHeight1 > fDestHeight2)
			{
				fDestWidth = fDestWidth1;
				fDestHeight = fDestHeight1;
			}
			else
			{
				fDestWidth = fDestWidth2;
				fDestHeight = fDestHeight2;
			}

			return true;
		}


		public bool MeasureString(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat,
			ref float fDestWidth,
			ref float fDestHeight)
		{
			float fDestWidth1 = 0.0f;
			float fDestHeight1 = 0.0f;
			bool b = textStrategy.MeasureString(
				graphics,
				fontFamily,
				fontStyle,
				nfontSize,
				strText,
				rtDraw,
				strFormat,
				ref fDestWidth1,
				ref fDestHeight1);

			if (!b)
				return false;

			float fDestWidth2 = 0.0f;
			float fDestHeight2 = 0.0f;
			if (enableShadow)
			{
				b = shadowStrategy.MeasureString(
					graphics,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					rtDraw,
					strFormat,
					ref fDestWidth2,
					ref fDestHeight2);

				if (b)
				{
					float fDestWidth3 = 0.0f;
					float fDestHeight3 = 0.0f;
					b = GDIPath.ConvertToPixels(
						graphics,
						shadowOffset.X,
						shadowOffset.Y,
						ref fDestWidth3,
						ref fDestHeight3);
					if (b)
					{
						fDestWidth2 += fDestWidth3;
						fDestHeight2 += fDestHeight3;
					}
				}
				else
					return false;
			}

			if (fDestWidth1 > fDestWidth2 || fDestHeight1 > fDestHeight2)
			{
				fDestWidth = fDestWidth1;
				fDestHeight = fDestHeight1;
			}
			else
			{
				fDestWidth = fDestWidth2;
				fDestHeight = fDestHeight2;
			}

			return true;
		}

		~OutlineText()
		{
			textStrategy = null;
			shadowStrategy = null;
			fontBodyShadow = null;
		}

		public void DiffusedShadow(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new DiffusedShadowStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness, true);

			shadowColor = color;

			var pFontBodyShadow = new DiffusedShadowStrategy();
			pFontBodyShadow.Init(Color.FromArgb(color.A, 255, 255), Color.FromArgb(0, 0, 0, 0), 0, true);
			fontBodyShadow = pFontBodyShadow;

			shadowOffset = ptOffset;
			shadowStrategy = pStrat;
			diffuseShadow = true;
			extrudeShadow = false;
			shadowThickness = nThickness;
		}

		public void Extrude(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new ExtrudeStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness, ptOffset.X, ptOffset.Y);

			shadowColor = color;

			var pFontBodyShadow = new ExtrudeStrategy();
			pFontBodyShadow.Init(Color.FromArgb(color.A, 255, 255), Color.FromArgb(0, 0, 0, 0), 0, ptOffset.X, ptOffset.Y);
			fontBodyShadow = pFontBodyShadow;

			shadowOffset = ptOffset;
			shadowStrategy = pStrat;
			extrudeShadow = true;
			diffuseShadow = false;
			shadowThickness = nThickness;
		}

		void RenderFontShadow(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat)
		{
			var rectbmp = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);
			Bitmap pBmpMask = backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Bitmap pBmpFontBodyBackup = backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Graphics graphicsMask = Graphics.FromImage(pBmpMask);
			var brushBlack = new SolidBrush(Color.FromArgb(0, 0, 0));
			graphicsMask.FillRectangle(brushBlack, 0, 0, backgroundImage.Width, backgroundImage.Height);

			Bitmap pBmpDisplay =
				backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);
			Graphics graphicsBkgd = Graphics.FromImage(pBmpDisplay);

			graphicsMask.CompositingMode = graphics.CompositingMode;
			graphicsMask.CompositingQuality = graphics.CompositingQuality;
			graphicsMask.InterpolationMode = graphics.InterpolationMode;
			graphicsMask.SmoothingMode = graphics.SmoothingMode;
			graphicsMask.TextRenderingHint = graphics.TextRenderingHint;
			graphicsMask.PageUnit = graphics.PageUnit;
			graphicsMask.PageScale = graphics.PageScale;

			graphicsBkgd.CompositingMode = graphics.CompositingMode;
			graphicsBkgd.CompositingQuality = graphics.CompositingQuality;
			graphicsBkgd.InterpolationMode = graphics.InterpolationMode;
			graphicsBkgd.SmoothingMode = graphics.SmoothingMode;
			graphicsBkgd.TextRenderingHint = graphics.TextRenderingHint;
			graphicsBkgd.PageUnit = graphics.PageUnit;
			graphicsBkgd.PageScale = graphics.PageScale;

			fontBodyShadow.DrawString(
				graphicsMask,
				fontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			shadowStrategy.DrawString(
				graphicsBkgd,
				fontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			unsafe
			{
				UInt32* pixelsSrc = null;
				UInt32* pixelsDest = null;
				UInt32* pixelsMask = null;

				var bitmapDataSrc = new BitmapData();
				var bitmapDataDest = new BitmapData();
				var bitmapDataMask = new BitmapData();
				var rect = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);

				pBmpFontBodyBackup.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataSrc);

				pBmpDisplay.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDest);

				pBmpMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataMask);

				// Write to the temporary buffer provided by LockBits.
				pixelsSrc = (UInt32*) (bitmapDataSrc.Scan0);
				pixelsDest = (UInt32*) (bitmapDataDest.Scan0);
				pixelsMask = (UInt32*) (bitmapDataMask.Scan0);

				if (pixelsSrc == null || pixelsDest == null || pixelsMask == null)
					return;

				UInt32 col = 0;
				int stride = bitmapDataDest.Stride >> 2;
				if (diffuseShadow && extrudeShadow == false)
				{
					for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
					{
						for (col = 0; col < bitmapDataDest.Width; ++col)
						{
							var index = (UInt32) (row * stride + col);
							var nAlpha = (Byte) (pixelsMask[index] & 0xff);
							var clrShadow = 0xff000000 | (UInt32)(shadowColor.R << 0x10) | (UInt32)(shadowColor.G << 0x8) | shadowColor.B;
							if (nAlpha > 0)
							{
								UInt32 clrtotal = clrShadow;
								for (int i = 2; i <= shadowThickness; ++i)
									pixelsSrc[index] = Alphablend(pixelsSrc[index], clrtotal, shadowColor.A);

								pixelsDest[index] = pixelsSrc[index];
							}
						}
					}
				}
				else
				{
					for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
					{
						for (col = 0; col < bitmapDataDest.Width; ++col)
						{
							var index = (UInt32) (row * stride + col);
							var nAlpha = (Byte) (pixelsMask[index] & 0xff);
							var clrShadow = 0xff000000 | (UInt32)(shadowColor.R << 0x10) | (UInt32)(shadowColor.G << 0x8) | shadowColor.B;
							if (nAlpha > 0)
								pixelsDest[index] = Alphablend(pixelsSrc[index], clrShadow, shadowColor.A);
						}
					}
				}

				pBmpMask.UnlockBits(bitmapDataMask);
				pBmpDisplay.UnlockBits(bitmapDataDest);
				pBmpFontBodyBackup.UnlockBits(bitmapDataSrc);

				graphics.DrawImage(pBmpDisplay, 0, 0, pBmpDisplay.Width, pBmpDisplay.Height);
			}
		}

		void RenderFontShadow(
			Graphics graphics,
			FontFamily fontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string pszText,
			Rectangle rtDraw,
			StringFormat strFormat)
		{
			var rectbmp = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);
			Bitmap pBmpMask =
				backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Bitmap pBmpFontBodyBackup =
				backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Graphics graphicsMask = Graphics.FromImage(pBmpMask);
			var brushBlack = new SolidBrush(Color.FromArgb(0, 0, 0));
			graphicsMask.FillRectangle(brushBlack, 0, 0, backgroundImage.Width, backgroundImage.Height);

			Bitmap pBmpDisplay =
				backgroundImage.Clone(rectbmp, PixelFormat.Format32bppArgb);
			Graphics graphicsBkgd = Graphics.FromImage(pBmpDisplay);

			graphicsMask.CompositingMode = graphics.CompositingMode;
			graphicsMask.CompositingQuality = graphics.CompositingQuality;
			graphicsMask.InterpolationMode = graphics.InterpolationMode;
			graphicsMask.SmoothingMode = graphics.SmoothingMode;
			graphicsMask.TextRenderingHint = graphics.TextRenderingHint;
			graphicsMask.PageUnit = graphics.PageUnit;
			graphicsMask.PageScale = graphics.PageScale;

			graphicsBkgd.CompositingMode = graphics.CompositingMode;
			graphicsBkgd.CompositingQuality = graphics.CompositingQuality;
			graphicsBkgd.InterpolationMode = graphics.InterpolationMode;
			graphicsBkgd.SmoothingMode = graphics.SmoothingMode;
			graphicsBkgd.TextRenderingHint = graphics.TextRenderingHint;
			graphicsBkgd.PageUnit = graphics.PageUnit;
			graphicsBkgd.PageScale = graphics.PageScale;

			fontBodyShadow.DrawString(
				graphicsMask,
				fontFamily,
				fontStyle,
				nfontSize,
				pszText,
				rtDraw,
				strFormat);

			shadowStrategy.DrawString(
				graphicsBkgd,
				fontFamily,
				fontStyle,
				nfontSize,
				pszText,
				rtDraw,
				strFormat);

			unsafe
			{
				UInt32* pixelsSrc = null;
				UInt32* pixelsDest = null;
				UInt32* pixelsMask = null;

				var bitmapDataSrc = new BitmapData();
				var bitmapDataDest = new BitmapData();
				var bitmapDataMask = new BitmapData();
				var rect = new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height);

				pBmpFontBodyBackup.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataSrc);

				pBmpDisplay.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDest);

				pBmpMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataMask);

				// Write to the temporary buffer provided by LockBits.
				pixelsSrc = (UInt32*) (bitmapDataSrc.Scan0);
				pixelsDest = (UInt32*) (bitmapDataDest.Scan0);
				pixelsMask = (UInt32*) (bitmapDataMask.Scan0);

				if (pixelsSrc == null || pixelsDest == null || pixelsMask == null)
					return;

				UInt32 col = 0;
				int stride = bitmapDataDest.Stride >> 2;
				if (diffuseShadow && extrudeShadow == false)
				{
					for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
					{
						for (col = 0; col < bitmapDataDest.Width; ++col)
						{
							var index = (UInt32) (row * stride + col);
							var nAlpha = (Byte) (pixelsMask[index] & 0xff);
							var clrShadow = 0xff000000 | (UInt32)(shadowColor.R << 0x10) | (UInt32)(shadowColor.G << 0x8) | shadowColor.B;
							if (nAlpha > 0)
							{
								UInt32 clrtotal = clrShadow;
								for (int i = 2; i <= shadowThickness; ++i)
									pixelsSrc[index] = Alphablend(pixelsSrc[index], clrtotal, shadowColor.A);

								pixelsDest[index] = pixelsSrc[index];
							}
						}
					}
				}
				else
				{
					for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
					{
						for (col = 0; col < bitmapDataDest.Width; ++col)
						{
							var index = (UInt32) (row * stride + col);
							var nAlpha = (Byte) (pixelsMask[index] & 0xff);
							var clrShadow = 0xff000000 | (UInt32)(shadowColor.R << 0x10) | (UInt32)(shadowColor.G << 0x8) | shadowColor.B;
							if (nAlpha > 0)
								pixelsDest[index] = Alphablend(pixelsSrc[index], clrShadow, shadowColor.A);
						}
					}
				}

				pBmpMask.UnlockBits(bitmapDataMask);
				pBmpDisplay.UnlockBits(bitmapDataDest);
				pBmpFontBodyBackup.UnlockBits(bitmapDataSrc);

				graphics.DrawImage(pBmpDisplay, 0, 0, pBmpDisplay.Width, pBmpDisplay.Height);
			}
		}

		UInt32 Alphablend(UInt32 dest, UInt32 source, Byte nAlpha)
		{
			if (0 == nAlpha)
				return dest;

			if (255 == nAlpha)
				return source;

			var nInvAlpha = (Byte) (~nAlpha);

			var nSrcRed = (Byte) ((source & 0xff0000) >> 16);
			var nSrcGreen = (Byte) ((source & 0xff00) >> 8);
			var nSrcBlue = (Byte) ((source & 0xff));

			var nDestRed = (Byte) ((dest & 0xff0000) >> 16);
			var nDestGreen = (Byte) ((dest & 0xff00) >> 8);
			var nDestBlue = (Byte) (dest & 0xff);

			var nRed = (Byte) ((nSrcRed * nAlpha + nDestRed * nInvAlpha) >> 8);
			var nGreen = (Byte) ((nSrcGreen * nAlpha + nDestGreen * nInvAlpha) >> 8);
			var nBlue = (Byte) ((nSrcBlue * nAlpha + nDestBlue * nInvAlpha) >> 8);

			return 0xff000000 | (UInt32)(nRed << 0x10) | (UInt32)(nGreen << 0x8) | nBlue;
		}
	}
}