using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VerseFlow.GFramework.Interop
{
	public class GHdcWrapper : IDisposable
	{
		internal IntPtr m_ClipRegion;
		internal int m_DCState;
		internal Graphics m_Graphics;
		internal int m_GraphicsMode;
		internal IntPtr m_Hdc;
		internal GGdi32.XFORM m_OldTransform;
		internal IntPtr m_OrigRegion;
		internal GGdi32.XFORM m_Transform;
		internal bool m_UseTransform;

		public GHdcWrapper(Graphics g, bool useTransfrom)
		{
			m_Graphics = g;

			Region rg = g.Clip;
			m_ClipRegion = rg.GetHrgn(g);
			rg.Dispose();

			m_UseTransform = useTransfrom;
			if (m_UseTransform)
			{
				Matrix m = g.Transform;
				m_Transform = GGdi32.XFORM.FromMatrix(m);
			}
		}

		public IntPtr GetHdc()
		{
			m_Hdc = m_Graphics.GetHdc();
			m_DCState = GGdi32.SaveDC(m_Hdc);

			if (m_UseTransform)
			{
				m_GraphicsMode = GGdi32.SetGraphicsMode(m_Hdc, GGdi32.GM_ADVANCED);
				GGdi32.GetWorldTransform(m_Hdc, ref m_OldTransform);
				GGdi32.ModifyWorldTransform(m_Hdc, ref m_Transform, GGdi32.MWT_LEFTMULTIPLY);
			}

			if (m_ClipRegion != IntPtr.Zero)
			{
				m_OrigRegion = GGdi32.CreateRectRgn(0, 0, 0, 0);
				int result = GGdi32.GetClipRgn(m_Hdc, m_OrigRegion);

				if (result == 1)
				{
					GGdi32.CombineRgn(m_ClipRegion, m_OrigRegion, m_ClipRegion, 1);
				}

				GGdi32.SelectClipRgn(m_Hdc, m_ClipRegion);
			}

			return m_Hdc;
		}
	
		public void Dispose()
		{
			if (m_Hdc == IntPtr.Zero)
				return;

			GGdi32.RestoreDC(m_Hdc, m_DCState);

			if (m_UseTransform)
			{
				GGdi32.SetGraphicsMode(m_Hdc, m_GraphicsMode);
				GGdi32.SetWorldTransform(m_Hdc, ref m_OldTransform);
			}

			if (m_ClipRegion != IntPtr.Zero)
			{
				GGdi32.DeleteObject(m_ClipRegion);
				GGdi32.DeleteObject(m_OrigRegion);
			}

			m_Graphics.ReleaseHdc(m_Hdc);

			m_Graphics = null;
			m_Hdc = IntPtr.Zero;
			m_ClipRegion = IntPtr.Zero;
			m_OrigRegion = IntPtr.Zero;
		}
	}
}