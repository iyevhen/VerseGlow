namespace VerseFlow.GFramework.Drawing.Fonts
{
    public struct GFontMetric
    {
        #region Constructor

        public GFontMetric(int lineSpacing, int emHeight, int cellAscent, int cellDescent)
        {
            LineSpacing = lineSpacing;
            EmHeight = emHeight;
            CellAscent = cellAscent;
            CellDescent = cellDescent;
        }

        #endregion

        #region Public Overrides
        #endregion

        #region Fields

        public int LineSpacing;
        public int EmHeight;
        public int CellAscent;
        public int CellDescent;

        #endregion
    }
}
