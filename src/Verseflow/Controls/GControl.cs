using System.Windows.Forms;
using VerseFlow.GFramework.Model;

namespace VerseFlow.Controls
{
    public class GControl : Control
    {
        public GControl()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public static Cursor CursorFromPredefinedCursor(PredefinedCursors cursor)
        {
            switch (cursor)
            {
                case PredefinedCursors.Hand:
                    return Cursors.Hand;
                default:
                    return Cursors.Default;
            }
        }
    }
}
