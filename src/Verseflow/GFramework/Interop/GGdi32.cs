using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using VerseFlow.GFramework.Drawing.Fonts;

namespace VerseFlow.GFramework.Interop
{
	public static class GGdi32
	{
		private const string Native_Library = "Gdi32.dll";

		[DllImport(Native_Library)]
		public static extern bool GetCharABCWidths(IntPtr hdc, int firstChar, int lastChar, ref ABCARRAY abc);

		[DllImport(Native_Library)]
		public static extern bool GetTextExtentPoint32(IntPtr hdc, string text, int charCount, ref Size size);

		[DllImport(Native_Library)]
		public static extern bool GetCharABCWidths(IntPtr hdc, int firstChar, int lastChar, ref ABC abc);

		[DllImport(Native_Library)]
		public static extern bool GetCharABCWidthsFloat(IntPtr hdc, int firstChar, int lastChar, ref ABCFLOAT abcFloat);

		[DllImport(Native_Library)]
		public static extern int GetKerningPairs(IntPtr hdc, int pairsNum, IntPtr pairs);

		[DllImport(Native_Library)]
		public static extern int GetKerningPairs(IntPtr hdc, int pairsNum, out IntPtr pairs);

		[DllImport(Native_Library)]
		public static extern int GetKerningPairs(IntPtr hdc, int pairsNum, ref GKerningPair pair);

		[DllImport(Native_Library)]
		public static extern IntPtr DeleteObject(IntPtr hObject);

		[DllImport(Native_Library)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport(Native_Library)]
		public static extern bool TextOut(IntPtr hDC, int x, int y, string text, int charLength);

		[DllImport(Native_Library)]
		public static extern bool ExtTextOut(IntPtr hDC, int x, int y, int flags, IntPtr rect, string text, int charCount,
											 IntPtr dx);

		[DllImport(Native_Library)]
		public static extern int ModifyWorldTransform(IntPtr hdc, ref XFORM xForm, int mode);

		[DllImport(Native_Library)]
		public static extern int GetWorldTransform(IntPtr hdc, ref XFORM xForm);

		[DllImport(Native_Library)]
		public static extern int SetWorldTransform(IntPtr hdc, ref XFORM xForm);

		[DllImport(Native_Library)]
		public static extern IntPtr CreateRectRgn(int X1, int Y1, int X2, int Y2);

		[DllImport(Native_Library)]
		public static extern int CombineRgn(IntPtr hDestRgn, IntPtr hSrcRgn1, IntPtr hSrcRgn2, int nCombineMode);

		[DllImport(Native_Library)]
		public static extern int GetClipRgn(IntPtr hDC, IntPtr hrgn);

		[DllImport(Native_Library)]
		public static extern int SaveDC(IntPtr hDC);

		[DllImport(Native_Library)]
		public static extern IntPtr RestoreDC(IntPtr hDC, int savedDC);

		[DllImport(Native_Library)]
		public static extern int SetGraphicsMode(IntPtr hdc, int iMode);

		[DllImport(Native_Library)]
		public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);

		[DllImport(Native_Library)]
		public static extern bool GetTextMetrics(IntPtr hdc, ref TEXTMETRIC tm);

		#region Structures

		[StructLayout(LayoutKind.Sequential)]
		public struct ABC
		{
			public int A;
			public int B;
			public int C;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ABCARRAY
		{
			public int A1;
			public int B1;
			public int C1;
			public int A2;
			public int B2;
			public int C2;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct ABCFLOAT
		{
			public float A;
			public float B;
			public float C;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct SIZE
		{
			public int width;
			public int height;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TEXTMETRIC
		{
			public int tmHeight;
			public int tmAscent;
			public int tmDescent;
			public int tmInternalLeading;
			public int tmExternalLeading;
			public int tmAveCharWidth;
			public int tmMaxCharWidth;
			public int tmWeight;
			public int tmOverhang;
			public int tmDigitizedAspectX;
			public int tmDigitizedAspectY;
			public char tmFirstChar;
			public char tmLastChar;
			public char tmDefaultChar;
			public char tmBreakChar;
			public byte tmItalic;
			public byte tmUnderlined;
			public byte tmStruckOut;
			public byte tmPitchAndFamily;
			public byte tmCharSet;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct XFORM
		{
			public XFORM(float m11, float m12, float m21, float m22, float dx, float dy)
			{
				eM11 = m11;
				eM12 = m12;
				eM21 = m21;
				eM22 = m22;
				eDx = dx;
				eDy = dy;
			}

			public float eM11;
			public float eM12;
			public float eM21;
			public float eM22;
			public float eDx;
			public float eDy;

			public static XFORM FromMatrix(Matrix m)
			{
				float[] elements = m.Elements;
				float m11 = elements[0];
				float m12 = elements[1];
				float m21 = elements[2];
				float m22 = elements[3];
				float dx = elements[4];
				float dy = elements[5];

				return new XFORM(m11, m12, m21, m22, dx, dy);
			}

			public static XFORM Identity = new XFORM(1, 0, 0, 1, 0, 0);
		}

		#endregion

		#region Constants

		#region SetGraphicsMode

		public const int GM_COMPATIBLE = 1;
		public const int GM_ADVANCED = 2;

		#endregion

		#region World Transform

		public const int MWT_IDENTITY = 1;
		public const int MWT_LEFTMULTIPLY = 2;
		public const int MWT_RIGHTMULTIPLY = 3;

		#endregion

		#region ExtTextOut

		public const int ETO_OPAQUE = 0x0002;
		public const int ETO_CLIPPED = 0x0004;
		public const int ETO_GLYPH_INDEX = 0x0010;
		public const int ETO_RTLREADING = 0x0080;
		public const int ETO_NUMERICSLOCAL = 0x0400;
		public const int ETO_NUMERICSLATIN = 0x0800;
		public const int ETO_IGNORELANGUAGE = 0x1000;

		#endregion

		#endregion
	}
}