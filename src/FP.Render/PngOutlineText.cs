using System;
using System.Drawing;
using System.Drawing.Imaging;
using FreePresenter.Render;

namespace FreePresenter.Render
{
	public class PngOutlineText : IOutlineText
	{
		protected bool m_bDiffuseShadow;
		protected bool m_bEnableShadow;
		protected bool m_bExtrudeShadow;
		protected Color m_clrShadow;
		protected int m_nShadowThickness;
		protected Bitmap m_pBkgdBitmap;
		protected ITextStrategy m_pFontBodyShadow;
		protected ITextStrategy m_pFontBodyShadowMask;
		protected Bitmap m_pPngBitmap;
		protected ITextStrategy m_pShadowStrategy;
		protected ITextStrategy m_pShadowStrategyMask;
		protected ITextStrategy m_pTextStrategy;
		protected ITextStrategy m_pTextStrategyMask;
		protected Point m_ptShadowOffset;

		public PngOutlineText()
		{
			m_pTextStrategy = null;
			m_pTextStrategyMask = null;
			m_pShadowStrategy = null;
			m_pShadowStrategyMask = null;
			m_pFontBodyShadow = null;
			m_pFontBodyShadowMask = null;
			m_pBkgdBitmap = null;
			m_pPngBitmap = null;
			m_clrShadow = Color.FromArgb(0, 0, 0);
			m_bEnableShadow = false;
			m_bDiffuseShadow = false;
			m_nShadowThickness = 2;
		}

		#region IOutlineText Members

		public void TextGlow(
			Color clrText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextGlowStrategy();
			pStrat.Init(clrText, clrOutline, nThickness);

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextGlowStrategy();
			pStrat2.Init(
				Color.FromArgb(clrText.A, 255, 255, 255),
				Color.FromArgb(clrOutline.A, 255, 255, 255),
				nThickness);

			m_pTextStrategyMask = pStrat2;
		}

		public void TextGlow(
			Brush brushText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextGlowStrategy();
			pStrat.Init(brushText, clrOutline, nThickness);

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextGlowStrategy();
			pStrat2.Init(
				Color.FromArgb(255, 255, 255, 255),
				Color.FromArgb(clrOutline.A, 255, 255, 255),
				nThickness);

			m_pTextStrategyMask = pStrat2;
		}

		public void TextOutline(
			Color clrText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(clrText, clrOutline, nThickness);

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextOutlineStrategy();
			pStrat2.Init(
				Color.FromArgb(clrText.A, 255, 255, 255),
				Color.FromArgb(clrOutline.A, 255, 255, 255),
				nThickness);

			m_pTextStrategyMask = pStrat2;
		}

		public void TextOutline(
			Brush brushText,
			Color clrOutline,
			int nThickness)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(brushText, clrOutline, nThickness);

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextOutlineStrategy();
			pStrat2.Init(
				Color.FromArgb(255, 255, 255, 255),
				Color.FromArgb(clrOutline.A, 255, 255, 255),
				nThickness);

			m_pTextStrategyMask = pStrat2;
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

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextDblOutlineStrategy();
			pStrat2.Init(
				Color.FromArgb(clrText.A, 255, 255, 255),
				Color.FromArgb(clrOutline1.A, 255, 255, 255),
				Color.FromArgb(clrOutline2.A, 255, 255, 255),
				nThickness1,
				nThickness2);

			m_pTextStrategyMask = pStrat2;
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

			m_pTextStrategy = pStrat;

			var pStrat2 = new TextDblOutlineStrategy();
			pStrat2.Init(
				Color.FromArgb(255, 255, 255, 255),
				Color.FromArgb(clrOutline1.A, 255, 255, 255),
				Color.FromArgb(clrOutline2.A, 255, 255, 255),
				nThickness1,
				nThickness2);

			m_pTextStrategyMask = pStrat2;
		}

		public void SetShadowBkgd(Bitmap pBitmap)
		{
			m_pBkgdBitmap = pBitmap;
		}

		public void SetShadowBkgd(Color clrBkgd, int nWidth, int nHeight)
		{
			m_pBkgdBitmap = new Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);

			Graphics graphics = Graphics.FromImage(m_pBkgdBitmap);
			var brush = new SolidBrush(clrBkgd);
			graphics.FillRectangle(brush, 0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height);
		}

		public void SetNullShadow()
		{
			m_pFontBodyShadow = null;
			m_pShadowStrategy = null;
		}

		public void EnableShadow(bool bEnable)
		{
			m_bEnableShadow = bEnable;
		}

		public void Shadow(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new TextOutlineStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness);

			m_ptShadowOffset = ptOffset;
			m_pShadowStrategy = pStrat;

			var pStrat2 = new TextOutlineStrategy();
			pStrat2.Init(
				Color.FromArgb(0, 0, 0, 0),
				Color.FromArgb(color.A, 255, 255, 255),
				nThickness);

			m_pShadowStrategyMask = pStrat2;

			m_clrShadow = color;

			var pFontBodyShadow = new TextOutlineStrategy();
			pFontBodyShadow.Init(Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0, 0), 0);
			m_pFontBodyShadow = pFontBodyShadow;

			var pFontBodyShadowMask = new TextOutlineStrategy();
			pFontBodyShadowMask.Init(Color.FromArgb(color.A, 255, 255, 255), Color.FromArgb(0, 0, 0, 0), 0);
			m_pFontBodyShadowMask = pFontBodyShadowMask;
			m_bDiffuseShadow = false;
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
			if (graphics == null)
				return false;

			Graphics pGraphicsDrawn = null;
			Bitmap pBmpDrawn = null;

			if (m_bEnableShadow && m_pBkgdBitmap != null && m_pFontBodyShadow != null && m_pShadowStrategy != null &&
				m_pShadowStrategyMask != null)
			{
				Graphics pGraphicsMask = null;
				Bitmap pBmpMask = null;

				bool b = RenderTransShadowA(graphics, ref pGraphicsMask, ref pBmpMask, ref pGraphicsDrawn, ref pBmpDrawn);

				if (!b)
					return false;

				b = RenderFontShadow(
					pGraphicsDrawn,
					pGraphicsMask,
					pBmpDrawn,
					pBmpMask,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Point(ptDraw.X + m_ptShadowOffset.X, ptDraw.Y + m_ptShadowOffset.Y),
					strFormat);

				if (!b)
				{

					return false;
				}

				b = RenderTransShadowB(graphics, pGraphicsMask, pBmpMask, pGraphicsDrawn, pBmpDrawn);

				if (!b)
					return false;
			}

			if (m_pTextStrategy != null && m_pTextStrategyMask != null)
			{
				Graphics pGraphicsPng = Graphics.FromImage(m_pPngBitmap);

				pGraphicsPng.CompositingMode = graphics.CompositingMode;
				pGraphicsPng.CompositingQuality = graphics.CompositingQuality;
				pGraphicsPng.InterpolationMode = graphics.InterpolationMode;
				pGraphicsPng.SmoothingMode = graphics.SmoothingMode;
				pGraphicsPng.TextRenderingHint = graphics.TextRenderingHint;
				pGraphicsPng.PageUnit = graphics.PageUnit;
				pGraphicsPng.PageScale = graphics.PageScale;

				bool b = m_pTextStrategy.DrawString(
					pGraphicsPng,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					ptDraw,
					strFormat);

				if (!b)
					return false;
			}

			return true;
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
			if (graphics == null)
				return false;

			Graphics pGraphicsDrawn = null;
			Bitmap pBmpDrawn = null;

			if (m_bEnableShadow && m_pBkgdBitmap != null && m_pFontBodyShadow != null && m_pShadowStrategy != null &&
				m_pShadowStrategyMask != null)
			{
				Graphics pGraphicsMask = null;
				Bitmap pBmpMask = null;

				bool b = RenderTransShadowA(graphics, ref pGraphicsMask, ref pBmpMask, ref pGraphicsDrawn, ref pBmpDrawn);

				if (!b)
					return false;

				b = RenderFontShadow(
					pGraphicsDrawn,
					pGraphicsMask,
					pBmpDrawn,
					pBmpMask,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					new Rectangle(rtDraw.X + m_ptShadowOffset.X, rtDraw.Y + m_ptShadowOffset.Y, rtDraw.Width, rtDraw.Height),
					strFormat);

				if (!b)
				{
					return false;
				}

				b = RenderTransShadowB(graphics, pGraphicsMask, pBmpMask, pGraphicsDrawn, pBmpDrawn);

				if (!b)
					return false;
			}

			if (m_pTextStrategy != null && m_pTextStrategyMask != null)
			{
				Graphics pGraphicsPng = Graphics.FromImage(m_pPngBitmap);

				pGraphicsPng.CompositingMode = graphics.CompositingMode;
				pGraphicsPng.CompositingQuality = graphics.CompositingQuality;
				pGraphicsPng.InterpolationMode = graphics.InterpolationMode;
				pGraphicsPng.SmoothingMode = graphics.SmoothingMode;
				pGraphicsPng.TextRenderingHint = graphics.TextRenderingHint;
				pGraphicsPng.PageUnit = graphics.PageUnit;
				pGraphicsPng.PageScale = graphics.PageScale;

				bool b = m_pTextStrategy.DrawString(
					pGraphicsPng,
					fontFamily,
					fontStyle,
					nfontSize,
					strText,
					rtDraw,
					strFormat);

				if (!b)
					return false;
			}

			return true;
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
			bool b = m_pTextStrategy.MeasureString(
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
			if (m_bEnableShadow)
			{
				b = m_pShadowStrategy.MeasureString(
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
						m_ptShadowOffset.X,
						m_ptShadowOffset.Y,
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
			bool b = m_pTextStrategy.MeasureString(
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
			if (m_bEnableShadow)
			{
				b = m_pShadowStrategy.MeasureString(
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
						m_ptShadowOffset.X,
						m_ptShadowOffset.Y,
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

		#endregion

		~PngOutlineText()
		{
			m_pTextStrategy = null;
			m_pTextStrategyMask = null;
			m_pShadowStrategy = null;
			m_pShadowStrategyMask = null;
			m_pFontBodyShadow = null;
			m_pFontBodyShadowMask = null;
		}

		public void DiffusedShadow(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new DiffusedShadowStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness, false);

			m_ptShadowOffset = ptOffset;
			m_pShadowStrategy = pStrat;

			var pStrat2 = new DiffusedShadowStrategy();
			pStrat2.Init(Color.FromArgb(0, 0, 0, 0), Color.FromArgb(color.A, 255, 255, 255), nThickness, true);

			m_pShadowStrategyMask = pStrat2;
			m_clrShadow = color;

			var pFontBodyShadow = new DiffusedShadowStrategy();
			pFontBodyShadow.Init(Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0, 0), nThickness, false);

			m_pFontBodyShadow = pFontBodyShadow;

			var pFontBodyShadowMask = new DiffusedShadowStrategy();
			pFontBodyShadowMask.Init(Color.FromArgb(color.A, 255, 255, 255), Color.FromArgb(0, 0, 0, 0), nThickness, false);

			m_pFontBodyShadowMask = pFontBodyShadowMask;
			m_bDiffuseShadow = true;
			m_bExtrudeShadow = false;
			m_nShadowThickness = nThickness;
		}

		public void Extrude(
			Color color,
			int nThickness,
			Point ptOffset)
		{
			var pStrat = new ExtrudeStrategy();
			pStrat.Init(Color.FromArgb(0, 0, 0, 0), color, nThickness, ptOffset.X, ptOffset.Y);

			m_ptShadowOffset = ptOffset;
			m_pShadowStrategy = pStrat;

			var pStrat2 = new ExtrudeStrategy();
			pStrat2.Init(
				Color.FromArgb(0, 0, 0, 0),
				Color.FromArgb(color.A, 255, 255, 255),
				nThickness,
				ptOffset.X,
				ptOffset.Y);

			m_pShadowStrategyMask = pStrat2;

			m_clrShadow = color;

			var pFontBodyShadow = new ExtrudeStrategy();
			pFontBodyShadow.Init(Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0, 0), nThickness, ptOffset.X, ptOffset.Y);

			m_pFontBodyShadow = pFontBodyShadow;

			var pFontBodyShadowMask = new ExtrudeStrategy();
			pFontBodyShadowMask.Init(
				Color.FromArgb(color.A, 255, 255, 255),
				Color.FromArgb(0, 0, 0, 0),
				nThickness,
				ptOffset.X,
				ptOffset.Y);

			m_pFontBodyShadowMask = pFontBodyShadowMask;
			m_bExtrudeShadow = true;
			m_bDiffuseShadow = false;
			m_nShadowThickness = nThickness;
		}

		public void SetPngImage(Bitmap pBitmap)
		{
			m_pPngBitmap = pBitmap;
		}

		public Bitmap GetPngImage()
		{
			return m_pPngBitmap;
		}

		bool RenderTransShadowA(
			Graphics pGraphics,
			ref Graphics ppGraphicsMask,
			ref Bitmap ppBmpMask,
			ref Graphics ppGraphicsDrawn,
			ref Bitmap ppBmpDrawn)
		{
			if (pGraphics == null)
				return false;

			var rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
			ppBmpMask =
				m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

			ppGraphicsMask = Graphics.FromImage(ppBmpMask);
			var brushBlack = new SolidBrush(Color.FromArgb(0, 0, 0));
			ppGraphicsMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

			ppGraphicsMask.CompositingMode = pGraphics.CompositingMode;
			ppGraphicsMask.CompositingQuality = pGraphics.CompositingQuality;
			ppGraphicsMask.InterpolationMode = pGraphics.InterpolationMode;
			ppGraphicsMask.SmoothingMode = pGraphics.SmoothingMode;
			ppGraphicsMask.TextRenderingHint = pGraphics.TextRenderingHint;
			ppGraphicsMask.PageUnit = pGraphics.PageUnit;
			ppGraphicsMask.PageScale = pGraphics.PageScale;

			ppBmpDrawn =
				m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

			ppGraphicsDrawn = Graphics.FromImage(ppBmpDrawn);
			var brushWhite = new SolidBrush(Color.FromArgb(255, 255, 255));
			ppGraphicsDrawn.FillRectangle(brushWhite, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

			ppGraphicsDrawn.CompositingMode = pGraphics.CompositingMode;
			ppGraphicsDrawn.CompositingQuality = pGraphics.CompositingQuality;
			ppGraphicsDrawn.InterpolationMode = pGraphics.InterpolationMode;
			ppGraphicsDrawn.SmoothingMode = pGraphics.SmoothingMode;
			ppGraphicsDrawn.TextRenderingHint = pGraphics.TextRenderingHint;
			ppGraphicsDrawn.PageUnit = pGraphics.PageUnit;
			ppGraphicsDrawn.PageScale = pGraphics.PageScale;

			return true;
		}

		bool RenderTransShadowB(
			Graphics pGraphics,
			Graphics pGraphicsMask,
			Bitmap pBmpMask,
			Graphics pGraphicsDrawn,
			Bitmap pBmpDrawn)
		{
			if (pGraphics == null || pGraphicsMask == null || pBmpMask == null || pGraphicsDrawn == null || pBmpDrawn == null)
				return false;

			unsafe
			{
				UInt32* pixelsDest = null;
				UInt32* pixelsMask = null;
				UInt32* pixelsDrawn = null;

				var bitmapDataDest = new BitmapData();
				var bitmapDataMask = new BitmapData();
				var bitmapDataDrawn = new BitmapData();
				var rect = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

				m_pPngBitmap.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDest);

				pBmpMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataMask);

				pBmpDrawn.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDrawn);

				// Write to the temporary buffer provided by LockBits.
				pixelsDest = (UInt32*)bitmapDataDest.Scan0;
				pixelsMask = (UInt32*)bitmapDataMask.Scan0;
				pixelsDrawn = (UInt32*)bitmapDataDrawn.Scan0;

				if (pixelsDest == null || pixelsMask == null || pixelsDrawn == null)
				{
					return false;
				}

				UInt32 col = 0;
				int stride = bitmapDataDest.Stride >> 2;
				for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
				{
					for (col = 0; col < bitmapDataDest.Width; ++col)
					{
						var index = (UInt32)(row * stride + col);
						var nAlpha = (Byte)(pixelsMask[index] & 0xff);
						if (nAlpha > 0)
						{
							var nDrawn = (UInt32)
										 (nAlpha << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
							nDrawn &= 0x00ffffff;
							pixelsDest[index] = nDrawn | (UInt32)(nAlpha << 24);
						}
					}
				}

				pBmpDrawn.UnlockBits(bitmapDataDrawn);
				pBmpMask.UnlockBits(bitmapDataMask);
				m_pPngBitmap.UnlockBits(bitmapDataDest);
			}
			return true;
		}

		bool RenderFontShadow(
			Graphics pGraphicsDrawn,
			Graphics pGraphicsMask,
			Bitmap pBitmapDrawn,
			Bitmap pBitmapMask,
			FontFamily pFontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Point ptDraw,
			StringFormat strFormat)
		{
			if (pGraphicsDrawn == null || pGraphicsMask == null || pBitmapDrawn == null || pBitmapMask == null)
				return false;

			var rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
			Bitmap pBitmapShadowMask =
				m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Graphics pGraphicsShadowMask = Graphics.FromImage(pBitmapShadowMask);
			var brushBlack = new SolidBrush(Color.FromArgb(0, 0, 0));
			pGraphicsShadowMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

			pGraphicsShadowMask.CompositingMode = pGraphicsDrawn.CompositingMode;
			pGraphicsShadowMask.CompositingQuality = pGraphicsDrawn.CompositingQuality;
			pGraphicsShadowMask.InterpolationMode = pGraphicsDrawn.InterpolationMode;
			pGraphicsShadowMask.SmoothingMode = pGraphicsDrawn.SmoothingMode;
			pGraphicsShadowMask.TextRenderingHint = pGraphicsDrawn.TextRenderingHint;
			pGraphicsShadowMask.PageUnit = pGraphicsDrawn.PageUnit;
			pGraphicsShadowMask.PageScale = pGraphicsDrawn.PageScale;

			bool b = false;

			b = m_pFontBodyShadowMask.DrawString(
				pGraphicsMask,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pShadowStrategyMask.DrawString(
				pGraphicsShadowMask,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pFontBodyShadow.DrawString(
				pGraphicsDrawn,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pShadowStrategy.DrawString(
				pGraphicsDrawn,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				ptDraw,
				strFormat);

			if (!b)
				return false;

			unsafe
			{
				UInt32* pixelsDest = null;
				UInt32* pixelsMask = null;
				UInt32* pixelsShadowMask = null;

				var bitmapDataDest = new BitmapData();
				var bitmapDataMask = new BitmapData();
				var bitmapDataShadowMask = new BitmapData();
				var rect = new Rectangle(0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height);

				pBitmapDrawn.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDest);

				pBitmapMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataMask);

				pBitmapShadowMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataShadowMask);

				pixelsDest = (UInt32*)(bitmapDataDest.Scan0);
				pixelsMask = (UInt32*)(bitmapDataMask.Scan0);
				pixelsShadowMask = (UInt32*)(bitmapDataShadowMask.Scan0);

				if (pixelsDest == null || pixelsMask == null || pixelsShadowMask == null)
					return false;

				UInt32 col = 0;
				int stride = bitmapDataDest.Stride >> 2;
				for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
				{
					for (col = 0; col < bitmapDataDest.Width; ++col)
					{
						var index = (UInt32)(row * stride + col);
						var nAlpha = (Byte)(pixelsMask[index] & 0xff);
						var nAlphaShadow = (Byte)(pixelsShadowMask[index] & 0xff);
						if (nAlpha > 0 && nAlpha > nAlphaShadow)
						{
							pixelsDest[index] = (UInt32)(0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
						}
						else if (nAlphaShadow > 0)
						{
							pixelsDest[index] = (UInt32)(0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
							pixelsMask[index] = pixelsShadowMask[index];
						}
					}
				}

				pBitmapShadowMask.UnlockBits(bitmapDataShadowMask);
				pBitmapMask.UnlockBits(bitmapDataMask);
				pBitmapDrawn.UnlockBits(bitmapDataDest);

			}

			return true;
		}

		bool RenderFontShadow(
			Graphics pGraphicsDrawn,
			Graphics pGraphicsMask,
			Bitmap pBitmapDrawn,
			Bitmap pBitmapMask,
			FontFamily pFontFamily,
			FontStyle fontStyle,
			int nfontSize,
			string strText,
			Rectangle rtDraw,
			StringFormat strFormat)
		{
			if (pGraphicsDrawn == null || pGraphicsMask == null || pBitmapDrawn == null || pBitmapMask == null)
				return false;

			var rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
			Bitmap pBitmapShadowMask =
				m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

			Graphics pGraphicsShadowMask = Graphics.FromImage(pBitmapShadowMask);
			var brushBlack = new SolidBrush(Color.FromArgb(0, 0, 0));
			pGraphicsShadowMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

			pGraphicsShadowMask.CompositingMode = pGraphicsDrawn.CompositingMode;
			pGraphicsShadowMask.CompositingQuality = pGraphicsDrawn.CompositingQuality;
			pGraphicsShadowMask.InterpolationMode = pGraphicsDrawn.InterpolationMode;
			pGraphicsShadowMask.SmoothingMode = pGraphicsDrawn.SmoothingMode;
			pGraphicsShadowMask.TextRenderingHint = pGraphicsDrawn.TextRenderingHint;
			pGraphicsShadowMask.PageUnit = pGraphicsDrawn.PageUnit;
			pGraphicsShadowMask.PageScale = pGraphicsDrawn.PageScale;

			bool b = false;

			b = m_pFontBodyShadowMask.DrawString(
				pGraphicsMask,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				rtDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pShadowStrategyMask.DrawString(
				pGraphicsShadowMask,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				rtDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pFontBodyShadow.DrawString(
				pGraphicsDrawn,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				rtDraw,
				strFormat);

			if (!b)
				return false;

			b = m_pShadowStrategy.DrawString(
				pGraphicsDrawn,
				pFontFamily,
				fontStyle,
				nfontSize,
				strText,
				rtDraw,
				strFormat);

			if (!b)
				return false;

			unsafe
			{
				UInt32* pixelsDest = null;
				UInt32* pixelsMask = null;
				UInt32* pixelsShadowMask = null;

				var bitmapDataDest = new BitmapData();
				var bitmapDataMask = new BitmapData();
				var bitmapDataShadowMask = new BitmapData();
				var rect = new Rectangle(0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height);

				pBitmapDrawn.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataDest);

				pBitmapMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataMask);

				pBitmapShadowMask.LockBits(
					rect,
					ImageLockMode.WriteOnly,
					PixelFormat.Format32bppArgb,
					bitmapDataShadowMask);

				pixelsDest = (UInt32*)(bitmapDataDest.Scan0);
				pixelsMask = (UInt32*)(bitmapDataMask.Scan0);
				pixelsShadowMask = (UInt32*)(bitmapDataShadowMask.Scan0);

				if (pixelsDest == null || pixelsMask == null || pixelsShadowMask == null)
					return false;

				UInt32 col = 0;
				int stride = bitmapDataDest.Stride >> 2;
				for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
				{
					for (col = 0; col < bitmapDataDest.Width; ++col)
					{
						var index = (UInt32)(row * stride + col);
						var nAlpha = (Byte)(pixelsMask[index] & 0xff);
						var nAlphaShadow = (Byte)(pixelsShadowMask[index] & 0xff);
						if (nAlpha > 0 && nAlpha > nAlphaShadow)
						{
							pixelsDest[index] = (UInt32)(0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
						}
						else if (nAlphaShadow > 0)
						{
							pixelsDest[index] = (UInt32)(0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
							pixelsMask[index] = pixelsShadowMask[index];
						}
					}
				}

				pBitmapShadowMask.UnlockBits(bitmapDataShadowMask);
				pBitmapMask.UnlockBits(bitmapDataMask);
				pBitmapDrawn.UnlockBits(bitmapDataDest);
			}

			return true;
		}

		UInt32 Alphablend(UInt32 dest, UInt32 source, Byte nAlpha)
		{
			if (0 == nAlpha)
				return dest;

			if (255 == nAlpha)
				return source;

			var nInvAlpha = (Byte)(~nAlpha);

			var nSrcRed = (Byte)((source & 0xff0000) >> 16);
			var nSrcGreen = (Byte)((source & 0xff00) >> 8);
			var nSrcBlue = (Byte)((source & 0xff));

			var nDestRed = (Byte)((dest & 0xff0000) >> 16);
			var nDestGreen = (Byte)((dest & 0xff00) >> 8);
			var nDestBlue = (Byte)(dest & 0xff);

			var nRed = (Byte)((nSrcRed * nAlpha + nDestRed * nInvAlpha) >> 8);
			var nGreen = (Byte)((nSrcGreen * nAlpha + nDestGreen * nInvAlpha) >> 8);
			var nBlue = (Byte)((nSrcBlue * nAlpha + nDestBlue * nInvAlpha) >> 8);

			return 0xff000000 | (UInt32)(nRed << 0x10) | (UInt32)(nGreen << 0x8) | nBlue;
		}
	}
}