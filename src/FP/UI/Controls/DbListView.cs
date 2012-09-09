using System;
using System.Windows.Forms;
using FreePresenter.UI;

namespace FreePresenter.UI.Controls
{
	public class DbListView : ListView
	{
//		private StringFormat format;

		public DbListView()
		{
			// Enable internal ListView double-buffering
			SetStyle(ControlStyles.OptimizedDoubleBuffer 
				| ControlStyles.AllPaintingInWmPaint
				| ControlStyles.ResizeRedraw, true);
			// Disable default CommCtrl painting on non-XP systems
			if (!NativeInterop.IsWinXP)
				SetStyle(ControlStyles.UserPaint, true);

//			OwnerDraw = true;
			//format = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
//			format = StringFormat.GenericTypographic;
//			format.FormatFlags |= StringFormatFlags.LineLimit;
		}

//
//		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
//		{
//			e.DrawDefault = true;
			//base.OnDrawColumnHeader(e);
//		}
//
//		protected override void OnDrawItem(DrawListViewItemEventArgs e)
//		{
			//e.DrawDefault = true;
//
//			if (e.Item.Focused)
//				e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
//
//			base.OnDrawItem(e);
//		}
//
//		protected override void OnPaintBackground(PaintEventArgs pevent)
//		{
			// We can do a better job of predicting where nodes will paint the background
			// and what area is left, so just disable background painting.  See OnPaint().
			//base.OnPaintBackground(pevent);
//		}
//
//		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
//		{
//			Graphics g = e.Graphics;
//
			//g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
//			g.SmoothingMode = SmoothingMode.HighSpeed;
//
//			if ((e.ItemState & ListViewItemStates.Selected) != 0)
//			{
				//g.FillRectangle(SystemBrushes.Highlight, e.Bounds);
//				e.DrawFocusRectangle(e.Bounds);
//
//				using (var b = new SolidBrush(ForeColor))
//					g.DrawString(e.SubItem.Text, Font, b, e.Bounds, format);
//			}
//			else
//			{
//				using (var b = new SolidBrush(ForeColor))
//					g.DrawString(e.SubItem.Text, Font, b, e.Bounds, format);
//			}
//		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (GetStyle(ControlStyles.UserPaint))
			{
				Message m = new Message();
				m.HWnd = Handle;
				m.Msg = NativeInterop.WM_PRINTCLIENT;
				m.WParam = e.Graphics.GetHdc();
				m.LParam = (IntPtr)NativeInterop.PRF_CLIENT;
				DefWndProc(ref m);
				e.Graphics.ReleaseHdc(m.WParam);
			}
			base.OnPaint(e);
		}
	}
}
