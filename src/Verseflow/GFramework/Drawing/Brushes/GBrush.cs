namespace VerseFlow.GFramework.Drawing.Brushes
{
    public abstract class GBrush : GDrawingAttribute
    {
        #region Constructor

        public GBrush()
        {
        }

        #endregion

        public abstract BrushType BrushType
        {
            get;
        }
    }
}
