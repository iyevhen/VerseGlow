using System;
using System.Runtime.InteropServices;

namespace VerseGlow.UI
{
    //Refer SharpDevelop, Source Code @ src\Libraries\ICSharpCode.TextEditor\Project\Src\Gui\Caret.cs
    public class Caret
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBmp, int w, int h);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetCaretPos(int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowCaret(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyCaret();
        [DllImport("User32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);
    }
}