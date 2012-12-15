using System.Drawing;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.Drawing.DeviceContexts
{
    internal class GGdiPlusFontInfo : GDisposableObject
    {
        #region Constructor

        internal GGdiPlusFontInfo(GFont font, GGdiPlusDeviceContext context)
        {
            Font = font;

            InitNativeFont();
            InitMetric();
            InitDeviceMetric(context);
        }

        #endregion

        #region Protected Overrides

        protected override void DisposeManagedResources()
        {
            base.DisposeManagedResources();

            if (NativeFont != null)
            {
                NativeFont.Dispose();
                NativeFont = null;
            }
        }

        #endregion

        #region Internal Implementation

        internal void InitNativeFont()
        {
            FontStyle style = FontStyle.Regular;
            //only bold and italic will be handled by the native font
            //underline or strike-through will be handled by the device itself
            if (Font.Bold)
            {
                style |= FontStyle.Bold;
            }
            if (Font.Italic)
            {
                style |= FontStyle.Italic;
            }

            NativeFont = new Font(Font.Face, Font.Size, style);
        }
        internal void InitMetric()
        {
            FontFamily family = NativeFont.FontFamily;
            FontStyle style = NativeFont.Style;

            int lineSpacing = family.GetLineSpacing(style);
            int emHeight = family.GetEmHeight(style);
            int cellAscent = family.GetCellAscent(style);
            int cellDescent = family.GetCellDescent(style);

            Metric = new GFontMetric(lineSpacing, emHeight, cellAscent, cellDescent);
        }
        internal void InitDeviceMetric(GDeviceContext context)
        {
            float pointsSize = NativeFont.SizeInPoints;
            float pixelSize = context.DpiY * pointsSize / 72;
            float scale = pixelSize / (float)Metric.EmHeight;

            DeviceMetric = new GFontDeviceMetric();
            DeviceMetric.NativeFontSizeInPixels = pixelSize;
            DeviceMetric.EmHeight = (float)Metric.EmHeight * scale;
            DeviceMetric.CellAscent = (float)Metric.CellAscent * scale;
            DeviceMetric.CellDescent = (float)Metric.CellDescent * scale;
            DeviceMetric.LineSpacing = (float)Metric.LineSpacing * scale;
            DeviceMetric.NativeFontSizeInPoints = NativeFont.SizeInPoints;
            DeviceMetric.DecorationThickness = DeviceMetric.EmHeight * Font.DecorationThickness;
            DeviceMetric.UnderlinePosition = DeviceMetric.EmHeight * Font.UnderlinePosition;
            DeviceMetric.NativeFontHeight = NativeFont.GetHeight(context.DpiY);
        }

        #endregion

        #region Fields

        public Font NativeFont;
        public GFont Font;
        public GFontMetric Metric;
        public GFontDeviceMetric DeviceMetric;

        internal const string PADDING_TEXT = "MQqp[]|i";

        #endregion
    }
}
