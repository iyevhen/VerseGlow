using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.Drawing.DeviceContexts
{
	/// <summary>
	///     A .NET Bitmap wrapper using direct pointers to access/modify bitmap data fast
	/// </summary>
	public class GBitmap : GDisposableObject
	{
		internal const ulong StateLocked = StateHasUnmanagedResources << 1;
		internal const ulong StateOwnBitmap = StateLocked << 1;
		internal Bitmap m_Bitmap;
		internal BitmapData m_Data;
		internal int m_Height;
		internal int m_StrideWidth;
		internal int m_Width;

		public GBitmap(int width, int height)
		{
			m_Width = width;
			m_Height = height;
			m_Bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			bitStates[StateOwnBitmap] = true;

			Lock();
		}

		public GBitmap(Bitmap bitmap)
		{
			m_Width = bitmap.Width;
			m_Height = bitmap.Height;
			m_Bitmap = bitmap;

			Lock();
		}

		protected override void DisposeManagedResources()
		{
			base.DisposeManagedResources();

			Unlock();

			if (bitStates[StateOwnBitmap])
			{
				m_Bitmap.Dispose();
			}
		}

		public Color GetPixel(Int32 x, Int32 y)
		{
			Color c;

			unsafe
			{
				byte* b = (byte*) m_Data.Scan0 + (y*m_StrideWidth) + (x*4);
				c = Color.FromArgb(*(b + 3), *(b + 2), *(b + 1), *b);
			}

			return c;
		}

		public void SetPixel(Int32 x, Int32 y, Color c)
		{
			unsafe
			{
				Byte* b = (Byte*) m_Data.Scan0 + (y*m_StrideWidth) + (x*4);
				*b = c.B;
				*(b + 1) = c.G;
				*(b + 2) = c.R;
				*(b + 3) = c.A;
			}
		}

		public void DrawText(string text, Font f, Brush br, TextRenderingHint hint)
		{
			Unlock();

			Graphics g = Graphics.FromImage(m_Bitmap);
			g.TextRenderingHint = hint;
			g.DrawString(text, f, br, PointF.Empty, StringFormat.GenericDefault);
			g.Dispose();

			Lock();
		}

		public void DrawStrokedText(string text, float pixelSize, Font f, Brush br, Pen pen)
		{
			Unlock();

			Graphics g = Graphics.FromImage(m_Bitmap);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			var path = new GraphicsPath();
			path.AddString(text, f.FontFamily, (int) f.Style, pixelSize, Point.Empty, StringFormat.GenericTypographic);

			g.FillPath(br, path);
			g.DrawPath(pen, path);
			RectangleF r = path.GetBounds();

			path.Dispose();
			g.Dispose();

			Lock();
		}

		public void DrawTextShadow(string text, Font f, Color c, TextRenderingHint hint, int blurX, int blurY)
		{
			Unlock();

			Graphics g = Graphics.FromImage(m_Bitmap);
			g.TextRenderingHint = hint;

			using (var br = new SolidBrush(c))
			{
				g.DrawString(text, f, br, PointF.Empty, StringFormat.GenericDefault);
			}

			g.Dispose();

			Lock();

			//calculate the alpha
			//if text rendering hint is ClearType, reduce alpha by additional 50
			//because when rendered on a bitmap, ClearType does not calculate pixels' alpha (transparent is treated as Black)
			int alpha;
			if (hint == TextRenderingHint.ClearTypeGridFit)
			{
				alpha = Math.Max(20, c.A - 50);
			}
			else
			{
				alpha = c.A;
			}
			Blur(blurX, blurY, alpha);
		}

		public void Blur(int dx, int dy, int alpha)
		{
			// horizontal blur
			int hLength = dx*2 + 1;
			var weights = new Single[hLength];
			Single weightsum;

			for (int i = 0; i < hLength; i++)
			{
				Single y = Gauss(-dx + i, 0, dx);
				weights[i] = y;
			}

			for (int row = 0; row < m_Height; row++)
			{
				for (int col = 0; col < m_Width; col++)
				{
					Double a = 0;
					Double r = 0;
					Double g = 0;
					Double b = 0;
					weightsum = 0;
					for (int i = 0; i < hLength; i++)
					{
						int x = col - dx + i;
						if (x < 0)
						{
							i += -x;
							x = 0;
						}
						if (x > m_Width - 1)
						{
							break;
						}
						Color c = GetPixel(x, row);
						a += Math.Min(alpha, c.A)*weights[i];
						r += c.R*weights[i];
						g += c.G*weights[i];
						b += c.B*weights[i];
						weightsum += weights[i];
					}
					a /= weightsum;
					r /= weightsum;
					g /= weightsum;
					b /= weightsum;
					var ba = (Byte) Math.Round(a);
					var br = (Byte) Math.Round(r);
					var bg = (Byte) Math.Round(g);
					var bb = (Byte) Math.Round(b);
					if (ba > 255)
					{
						ba = 255;
					}
					if (br > 255)
					{
						br = 255;
					}
					if (br > 255)
					{
						br = 255;
					}
					if (bg > 255)
					{
						bg = 255;
					}
					if (bb > 255)
					{
						bb = 255;
					}
					SetPixel(col, row, Color.FromArgb(ba, br, bg, bb));
				}
			}

			// vertical blur
			int vLength = dy*2 + 1;
			weights = new Single[vLength];
			for (int i = 0; i < vLength; i++)
			{
				Single y = Gauss(-dy + i, 0, dy);
				weights[i] = y;
			}

			for (int col = 0; col < m_Width; col++)
			{
				for (int row = 0; row < m_Height; row++)
				{
					Double a = 0;
					Double r = 0;
					Double g = 0;
					Double b = 0;
					weightsum = 0;
					for (int i = 0; i < vLength; i++)
					{
						int y = row - dy + i;
						if (y < 0)
						{
							i += -y;
							y = 0;
						}
						if (y > m_Height - 1)
						{
							break;
						}
						Color c = GetPixel(col, y);
						a += Math.Min(alpha, c.A)*weights[i];
						r += c.R*weights[i];
						g += c.G*weights[i];
						b += c.B*weights[i];
						weightsum += weights[i];
					}
					a /= weightsum;
					r /= weightsum;
					g /= weightsum;
					b /= weightsum;
					var ba = (Byte) Math.Round(a);
					var br = (Byte) Math.Round(r);
					var bg = (Byte) Math.Round(g);
					var bb = (Byte) Math.Round(b);
					if (ba > 255)
					{
						ba = 255;
					}
					if (br > 255)
					{
						br = 255;
					}
					if (br > 255)
					{
						br = 255;
					}
					if (bg > 255)
					{
						bg = 255;
					}
					if (bb > 255)
					{
						bb = 255;
					}
					SetPixel(col, row, Color.FromArgb(ba, br, bg, bb));
				}
			}
		}

		public Padding GetPadding()
		{
			//left padding - examine columns, starting from left one
			int left = -1;

			for (int x = 0; x < m_Width; x++)
			{
				for (int y = 0; y < m_Height; y++)
				{
					if (GetPixel(x, y).A > 0)
					{
						left = x;
						break;
					}
				}

				if (left != -1)
				{
					break;
				}
			}

			//top padding - examine rows, starting from top one
			int top = -1;
			for (int y = 0; y < m_Height; y++)
			{
				for (int x = 0; x < m_Width; x++)
				{
					if (GetPixel(x, y).A > 0)
					{
						top = y;
						break;
					}
				}

				if (top != -1)
				{
					break;
				}
			}

			//right padding - examine columns, starting from right one
			int right = -1;
			for (int x = m_Width - 1; x >= 0; x--)
			{
				for (int y = 0; y < m_Height; y++)
				{
					if (GetPixel(x, y).A > 0)
					{
						right = m_Width - x - 1;
						break;
					}
				}

				if (right != -1)
				{
					break;
				}
			}

			//bottom padding - examine rows, starting from bottom one
			int bottom = -1;
			for (int y = m_Height - 1; y >= 0; y--)
			{
				for (int x = 0; x < m_Width; x++)
				{
					if (GetPixel(x, y).A > 0)
					{
						bottom = m_Height - y - 1;
						break;
					}
				}

				if (bottom != -1)
				{
					break;
				}
			}

			return new Padding(left, top, right, bottom);
		}

		public Bitmap ToBitmap()
		{
			Unlock();
			var newBitmap = new Bitmap(m_Bitmap);
			Lock();

			return newBitmap;
		}

		private Single Gauss(Single x, Single middle, Single width)
		{
			if (width == 0)
			{
				return 1F;
			}

			Double t = -(1.0/width)*((middle - x)*(middle - x));
			return (Single) Math.Pow(Math.E, t);
		}

		private void Lock()
		{
			if (bitStates[StateLocked])
			{
				return;
			}

			var dataBounds = new Rectangle(0, 0, m_Width, m_Height);
			m_Data = m_Bitmap.LockBits(dataBounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			m_StrideWidth = m_Data.Stride;

			bitStates[StateLocked] = true;
		}

		private void Unlock()
		{
			if (bitStates[StateLocked] == false)
			{
				return;
			}

			m_Bitmap.UnlockBits(m_Data);

			bitStates[StateLocked] = false;
		}
	}
}