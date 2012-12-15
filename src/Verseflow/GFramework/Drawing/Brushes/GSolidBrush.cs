using System.Drawing;

namespace VerseFlow.GFramework.Drawing.Brushes
{
    public class GSolidBrush : GBrush
    {
        #region Constructor

        public GSolidBrush(Color c)
        {
            m_Color = c;
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return m_Color.ToArgb();
        }
        public override bool Equals(object obj)
        {
            GSolidBrush brush = obj as GSolidBrush;
            if (brush == null)
            {
                return false;
            }

            return brush.m_Color == m_Color;
        }

        #endregion

        #region Properties

        public Color Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        public override BrushType BrushType
        {
            get
            {
                return BrushType.Solid;
            }
        }

        #endregion

        #region Fields

        internal Color m_Color;

        #endregion
    }
}
