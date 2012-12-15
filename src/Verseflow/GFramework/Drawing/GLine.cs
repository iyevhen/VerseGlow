using System.Drawing;

namespace VerseFlow.GFramework.Drawing
{
    public class GLine
    {
        public GLine()
        {
        }
        public GLine(GLine prototype)
        {
            Color = prototype.Color;
            StartX = prototype.StartX;
            StartY = prototype.StartY;
            EndX = prototype.EndX;
            EndY = prototype.EndY;
        }

        public Color Color;
        public float StartX;
        public float StartY;
        public float EndX;
        public float EndY;
    }
}
