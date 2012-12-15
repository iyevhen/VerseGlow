using VerseFlow.GFramework.Interop;

namespace VerseFlow.GFramework.Drawing.Fonts
{
    public struct GFontDeviceMetric
    {
        public float EmHeight;
        public float LineSpacing;
        public float CellAscent;
        public float CellDescent;
        public float WhiteSpaceWidth;
        public float NativeFontSizeInPoints;
        public float NativeFontSizeInPixels;
        public float NativeFontHeight;
        public float DecorationThickness;
        public float UnderlinePosition;
        public GGdi32.TEXTMETRIC TextMetric;
    }
}
