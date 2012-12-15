using System.Drawing;
using VerseFlow.GFramework.Drawing.DeviceContexts;

namespace VerseFlow.GFramework.View.Text
{
    public class GTextViewPaintContext : GPaintContext
    {
	    public GTextViewPaintContext(GDeviceContext context, RectangleF viewBounds)
            : base(context)
        {
            ViewBounds = viewBounds;
            LineStart = viewBounds.Y;
        }

	    public RectangleF ViewBounds;
        public float LineStart;
    }
}
