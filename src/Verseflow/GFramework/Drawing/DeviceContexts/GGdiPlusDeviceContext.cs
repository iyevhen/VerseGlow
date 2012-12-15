using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using VerseFlow.GFramework.Drawing.Brushes;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Drawing.Pens;
using VerseFlow.GFramework.Interop;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.View.Text;

namespace VerseFlow.GFramework.Drawing.DeviceContexts
{
	public class GGdiPlusDeviceContext : GDeviceContext
	{
		public static readonly Graphics MeasurementGraphics;
		[NonSerialized] internal Hashtable m_BrushCache;
		[NonSerialized] internal Hashtable m_FontCache;
		[NonSerialized] internal TextFormatFlags m_FormatFlags;
		[NonSerialized] internal Graphics m_Graphics;
		[NonSerialized] internal StringFormat m_MeasureStringFormat;
		[NonSerialized] internal StringFormat m_PaintStringFormat;
		[NonSerialized] internal Hashtable m_PenCache;

		static GGdiPlusDeviceContext()
		{
			var bmp = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
			MeasurementGraphics = Graphics.FromImage(bmp);
		}

		public GGdiPlusDeviceContext()
		{
			m_MeasureStringFormat = new StringFormat
				{
					FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap |
					              StringFormatFlags.FitBlackBox,
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Near,
					Trimming = StringTrimming.None,
					HotkeyPrefix = HotkeyPrefix.None
				};

			m_PaintStringFormat = new StringFormat
				{
					FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox,
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Near,
					Trimming = StringTrimming.None,
					HotkeyPrefix = HotkeyPrefix.None
				};

			m_FormatFlags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix |
			                TextFormatFlags.PreserveGraphicsClipping |
			                TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.SingleLine |
			                TextFormatFlags.NoClipping | TextFormatFlags.Left | TextFormatFlags.Top;

			m_FontCache = new Hashtable();
			m_BrushCache = new Hashtable();
			m_PenCache = new Hashtable();
		}

		#region Public Methods

		public void Attach(Graphics g)
		{
			m_Graphics = g;
		}

		public Graphics Detach()
		{
			Graphics old = m_Graphics;
			m_Graphics = null;

			return old;
		}

		public void ClearFontCache()
		{
			IEnumerator en = m_FontCache.GetEnumerator();
			GGdiPlusFontInfo info;

			while (en.MoveNext())
			{
				info = (GGdiPlusFontInfo) ((DictionaryEntry) en.Current).Value;
				info.Dispose();
			}

			m_FontCache.Clear();
		}

		public void ClearBrushCache()
		{
			IEnumerator en = m_BrushCache.GetEnumerator();
			Brush nativeBrush;

			while (en.MoveNext())
			{
				nativeBrush = (Brush) ((DictionaryEntry) en.Current).Value;
				nativeBrush.Dispose();
			}

			m_BrushCache.Clear();
		}

		public void ClearPenCache()
		{
			IEnumerator en = m_PenCache.GetEnumerator();
			Pen nativePen;

			while (en.MoveNext())
			{
				nativePen = (Pen) ((DictionaryEntry) en.Current).Value;
				nativePen.Dispose();
			}

			m_PenCache.Clear();
		}

		public Font GetNativeFont(GFont font)
		{
			return GetFontInfo(font).NativeFont;
		}

		public Brush GetNativeBrush(GBrush brush)
		{
			if (m_BrushCache.ContainsKey(brush))
			{
				return (Brush) m_BrushCache[brush];
			}

			Brush nativeBrush = CreateNativeBrush(brush);
			//add the newly created brush to the cache
			m_BrushCache.Add(brush, nativeBrush);

			return nativeBrush;
		}

		public Pen GetNativePen(GPen pen)
		{
			if (pen == null)
			{
				return null;
			}

			if (m_PenCache.ContainsKey(pen))
			{
				return (Pen) m_PenCache[pen];
			}

			Pen nativePen = CreateNativePen(pen);
			//add the newly created brush to the cache
			m_PenCache.Add(pen, nativePen);

			return nativePen;
		}

		#endregion

		#region Public Overrides

		public override SizeF MeasureString(string s, GFont f)
		{
			return MeasureString(s, f, -1);
		}

		public override SizeF MeasureString(string s, GFont font, int maxWidth)
		{
			ValidateGraphics();

			Font nativeFont = GetNativeFont(font);
			int width = maxWidth > 0 ? maxWidth : Int32.MaxValue;
			SizeF szf = TextRenderer.MeasureText(m_Graphics, s, nativeFont, Size.Empty, m_FormatFlags);

			return szf;
		}

		public override GWordMetric MeasureWord(GWord word)
		{
			ValidateGraphics();

			//create new metric object to pass to the measured word
			var metric = new GWordMetric();
			Font nativeFont = GetNativeFont(word.m_Style.m_Font);

			//measure word size
			SizeF textSize = m_Graphics.MeasureString(word.m_Text, nativeFont, PointF.Empty, StringFormat.GenericDefault);

			GBitmap bitmap;
			Size bitmapSize;

			//check whether we have a stroked word
			if (word.m_Style.m_Pen != null)
			{
				bitmapSize = Size.Round(textSize);

				Brush nativeBrush = GetNativeBrush(word.m_Style.m_Brush);
				Pen nativePen = GetNativePen(word.m_Style.m_Pen);
				bitmap = new GBitmap(bitmapSize.Width, bitmapSize.Height);
				bitmap.DrawStrokedText(word.m_Text, word.m_FontMetric.NativeFontSizeInPixels, nativeFont, nativeBrush, nativePen);
				//copy this bitmap for later use
				word.m_PathBitmap = bitmap.ToBitmap();
			}
			else
			{
				int clearTypeOffset = 2;
				bitmapSize = new Size((int) (textSize.Width + .5F) + clearTypeOffset, (int) textSize.Height);

				//measure the internal padding (used for providing pixel-perfect layout)
				Brush nativeBrush = GetNativeBrush(word.m_Style.m_Brush);
				bitmap = new GBitmap(bitmapSize.Width, bitmapSize.Height);
				bitmap.DrawText(word.m_Text, nativeFont, System.Drawing.Brushes.Black, m_Graphics.TextRenderingHint);
			}

			metric.Size = bitmapSize;
			Padding padding = bitmap.GetPadding();
			metric.Padding = padding;
			metric.BlackBox = new SizeF(bitmapSize.Width - padding.Horizontal, bitmapSize.Height - padding.Vertical);

			//clean-up bitmap resources
			bitmap.Dispose();

			//assign the metric to the word
			word.m_Metric = metric;

			return metric;
		}

		public override void PaintWord(GWord word)
		{
			ValidateGraphics();

			PointF location = word.m_Location;

			//get native drawing primitives
			Font nativeFont = GetNativeFont(word.m_Style.m_Font);
			Brush nativeBrush = GetNativeBrush(word.m_Style.m_Brush);

			//check whether shadow is needed
			if (word.m_Style.m_Shadow != null)
			{
				var bounds = new RectangleF(location, word.m_Metric.Size);
				PaintWordShadow(word, bounds, nativeFont);
			}

			//we have a stroked text, paint it using a graphics path
			if (word.m_Style.m_Pen != null)
			{
				m_Graphics.DrawImage(word.m_PathBitmap, Point.Round(location));
			}
			else
			{
				m_Graphics.DrawString(word.m_Text, nativeFont, nativeBrush, location, StringFormat.GenericDefault);
			}
		}

		public override GFontMetric GetFontMetric(GFont font)
		{
			return GetFontInfo(font).Metric;
		}

		public override GFontDeviceMetric GetFontDeviceMetric(GFont font)
		{
			return GetFontInfo(font).DeviceMetric;
		}

		public override void DrawLine(GPen pen, PointF start, PointF end)
		{
			ValidateGraphics();

			Pen nativePen = GetNativePen(pen);
			m_Graphics.DrawLine(nativePen, start, end);
		}

		#endregion

		#region Protected Overrides

		protected override void DisposeManagedResources()
		{
			base.DisposeManagedResources();

			ClearFontCache();
			ClearBrushCache();

			m_MeasureStringFormat.Dispose();
			m_PaintStringFormat.Dispose();
		}

		#endregion

		#region Internal Implementation

		internal GGdiPlusFontInfo GetFontInfo(GFont font)
		{
			if (m_FontCache.ContainsKey(font))
			{
				return (GGdiPlusFontInfo) m_FontCache[font];
			}

			var info = new GGdiPlusFontInfo(font, this);
			m_FontCache.Add(font, info);

			info.DeviceMetric.WhiteSpaceWidth =
				TextRenderer.MeasureText(m_Graphics, new string(' ', 1), info.NativeFont, Size.Empty, m_FormatFlags).Width;
			//get the native GDI text metric
			info.DeviceMetric.TextMetric = GetTextMetric(info.NativeFont);

			return info;
		}

		internal GGdi32.TEXTMETRIC GetTextMetric(Font font)
		{
			//get the TEXTMETRIC for the font info
			var tm = new GGdi32.TEXTMETRIC();
			IntPtr hdc = m_Graphics.GetHdc();
			IntPtr hFont = font.ToHfont();
			IntPtr hOldObject = GGdi32.SelectObject(hdc, hFont);

			GGdi32.GetTextMetrics(hdc, ref tm);

			//clean-up
			GGdi32.SelectObject(hdc, hOldObject);
			GGdi32.DeleteObject(hFont);
			m_Graphics.ReleaseHdc(hdc);

			return tm;
		}

		internal Brush CreateNativeBrush(GBrush brush)
		{
			Brush br = null;

			switch (brush.BrushType)
			{
				case BrushType.Solid:
					br = new SolidBrush(((GSolidBrush) brush).Color);
					break;
			}

			return br;
		}

		internal Pen CreateNativePen(GPen pen)
		{
			var nativePen = new Pen(pen.Color, pen.Width);
			return nativePen;
		}

		internal SizeF GetStrokedWordSize(GWord word, Font font)
		{
			var path = new GraphicsPath();
			float sizeInPixel = word.m_FontMetric.NativeFontSizeInPixels;

			path.AddString(word.m_Text, font.FontFamily, (int) font.Style, sizeInPixel, Point.Empty,
			               StringFormat.GenericTypographic);

			SizeF sz = path.GetBounds().Size;
			path.Dispose();

			return sz;
		}

		internal void PaintWordShadow(GWord word, RectangleF bounds, Font font)
		{
			GShadow shadow = word.m_Style.m_Shadow;
			bounds.Offset(shadow.m_Offset);

			switch (shadow.m_Style)
			{
				case ShadowStyle.Solid:
					using (var br = new SolidBrush(shadow.m_Color))
					{
						m_Graphics.DrawString(word.m_Text, font, br, bounds.Location, StringFormat.GenericDefault);
					}
					break;
				case ShadowStyle.Blurred:
					//check whether the shadow bitmap needs to be initialized
					if (word.m_ShadowBitmap == null)
					{
						var width = (int) (bounds.Width);
						var height = (int) (bounds.Height);
						var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
						var bitmap = new GBitmap(bmp);

						bitmap.DrawTextShadow(word.m_Text, font, shadow.m_Color, m_Graphics.TextRenderingHint, shadow.m_Strength.X,
						                      shadow.m_Strength.Y);
						bitmap.Dispose();

						word.m_ShadowBitmap = bmp;
					}

					InterpolationMode oldMode = m_Graphics.InterpolationMode;
					m_Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					m_Graphics.DrawImage(word.m_ShadowBitmap, bounds);
					m_Graphics.InterpolationMode = oldMode;
					break;
			}
		}

		internal void ValidateGraphics()
		{
			if (m_Graphics == null)
			{
				throw new ArgumentNullException("Graphics");
			}
		}

		#endregion

		#region Properties

		public bool IsAttached
		{
			get { return m_Graphics != null; }
		}

		public override float DpiX
		{
			get
			{
				if (m_Graphics == null)
				{
					return 0;
				}

				return m_Graphics.DpiX;
			}
		}

		public override float DpiY
		{
			get
			{
				if (m_Graphics == null)
				{
					return 0;
				}

				return m_Graphics.DpiY;
			}
		}

		public override RectangleF ClipBounds
		{
			get
			{
				if (m_Graphics != null)
				{
					return m_Graphics.ClipBounds;
				}

				return RectangleF.Empty;
			}
		}

		#endregion
	}
}