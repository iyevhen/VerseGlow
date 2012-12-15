using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;

namespace VerseFlow.GFramework.View.Text
{
    public class GTextViewPaintContext : GPaintContext
    {
        #region Constructor

        public GTextViewPaintContext(GDeviceContext context, RectangleF viewBounds)
            : base(context)
        {
            ViewBounds = viewBounds;
            LineStart = viewBounds.Y;
            ClipMode = TextViewClipMode.Bounds;
        }

        #endregion

        #region Fields

        public RectangleF ViewBounds;
        public float LineStart;
        public TextViewClipMode ClipMode;

        #endregion
    }
}
