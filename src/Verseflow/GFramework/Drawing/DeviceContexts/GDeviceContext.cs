using System.Drawing;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Drawing.Pens;
using VerseFlow.GFramework.Model;
using VerseFlow.GFramework.View.Text;

namespace VerseFlow.GFramework.Drawing.DeviceContexts
{
	public abstract class GDeviceContext : GDisposableObject
	{
		public abstract SizeF MeasureString(string s, GFont f);
		public abstract SizeF MeasureString(string s, GFont f, int maxWidth);

		public abstract GWordMetric MeasureWord(GWord word);
		public abstract void PaintWord(GWord word);

		public abstract GFontMetric GetFontMetric(GFont font);
		public abstract GFontDeviceMetric GetFontDeviceMetric(GFont font);

		public abstract void DrawLine(GPen pen, PointF start, PointF end);

		public abstract RectangleF ClipBounds
		{
			get;
		}
		public abstract float DpiX
		{
			get;
		}
		public abstract float DpiY
		{
			get;
		}

		public const float AntialiasOffset = 2F;
	}
}
