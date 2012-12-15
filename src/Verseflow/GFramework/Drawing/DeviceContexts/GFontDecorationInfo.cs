using System.Collections.Generic;

namespace VerseFlow.GFramework.Drawing.DeviceContexts
{
    internal class GFontDecorationInfo
    {
        internal GFontDecorationInfo()
        {
            Lines = new LinkedList<GLine>();
        }

        internal float Offset;
        internal float Thickness;
        internal LinkedList<GLine> Lines;
    }
}
