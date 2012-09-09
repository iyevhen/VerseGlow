using System;
using System.Runtime.InteropServices;

namespace FreePresenter.UI
{
	public class NativeInterop
	{
		const int SM_CXSCREEN = 0;
		const int SM_CYSCREEN = 1;
		const int SWP_SHOWWINDOW = 64; // 0x0040
		private const int WM_NCLBUTTONDOWN = 0xA1;
		private const int HT_CAPTION = 0x2;
		static readonly IntPtr HWND_TOP = IntPtr.Zero;
		public const int WM_PRINTCLIENT = 0x0318;
		public const int PRF_CLIENT = 0x00000004;

		internal const int WM_GRAPHNOTIFY = 0x00008001; // message from graph

		internal const int WS_CHILD = 0x40000000; // attributes for video window
		internal const int WS_CLIPCHILDREN = 0x02000000;
		internal const int WS_CLIPSIBLINGS = 0x04000000;

		public static int ScreenX
		{
			get { return GetSystemMetrics(SM_CXSCREEN); }
		}

		public static int ScreenY
		{
			get { return GetSystemMetrics(SM_CYSCREEN); }
		}

		[DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
		public static extern int GetSystemMetrics(int which);

		[DllImport("user32.dll")]
		public static extern void
			SetWindowPos(
			IntPtr hwnd,
			IntPtr hwndInsertAfter,
			int X,
			int Y,
			int width,
			int height,
			uint flags);

		public static void SetWinFullScreen(IntPtr hwnd)
		{
			SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
		}

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public static void HandlerMouseDown(IntPtr hWnd)
		{
			ReleaseCapture();
			SendMessage(hWnd, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
		}

		public static bool IsWinXP
		{
			get
			{
				OperatingSystem OS = Environment.OSVersion;
				return (OS.Platform == PlatformID.Win32NT) &&
					((OS.Version.Major > 5) || ((OS.Version.Major == 5) && (OS.Version.Minor == 1)));
			}
		}

		public static bool IsWinVista
		{
			get
			{
				OperatingSystem OS = Environment.OSVersion;
				return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
			}
		}
	}
}