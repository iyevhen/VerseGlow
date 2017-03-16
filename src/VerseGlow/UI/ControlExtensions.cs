using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VerseGlow.UI
{
	public static class ControlExtensions
	{
		private const int EM_SETCUEBANNER = 0x1501; //Windows XP
		private const int CB_SETCUEBANNER = 0x1703; //Windows 7

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		public static void SetCue(this TextBox target, string cue)
		{
			SendMessage(target.Handle, EM_SETCUEBANNER, 0, cue);
		}

		public static void SetCue(this ComboBox target, string cue)
		{
			SendMessage(target.Handle, CB_SETCUEBANNER, 01, cue);
		}
	}


}


