using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VerseGlow.UI
{
	public static class WindowsAPI
	{
		private const int SM_CXSCREEN = 0;
		private const int SM_CYSCREEN = 1;
		private const int SWP_SHOWWINDOW = 64; // 0x0040

		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int which);

		[DllImport("user32.dll")]
		private static extern void SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int X, int Y, int width, int height, uint flags);

		public static void SetFullScreen(Form form)
		{
			if (form == null)
				throw new ArgumentNullException("form");

			SetWindowPos(form.Handle, IntPtr.Zero, 0, 0, GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN), SWP_SHOWWINDOW);
		}
	}
}