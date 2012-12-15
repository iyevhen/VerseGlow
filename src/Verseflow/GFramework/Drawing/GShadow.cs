using System.Drawing;
using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.Drawing
{
    public class GShadow : GDrawingAttribute
    {
        #region Constructor

        public GShadow()
        {
            m_Color = Color.Black;
            m_Offset = new PointF(1, 1);
            m_Style = ShadowStyle.Solid;
        }
        public GShadow(GShadow source)
        {
            m_Color = source.m_Color;
            m_Offset = source.m_Offset;
            m_Style = source.m_Style;
            m_Strength = source.m_Strength;
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
        public PointF Offset
        {
            get
            {
                return m_Offset;
            }
            set
            {
                m_Offset = value;
            }
        }
        public Point Strength
        {
            get
            {
                return m_Strength;
            }
            set
            {
                m_Strength = value;
            }
        }
        public ShadowStyle Style
        {
            get
            {
                return m_Style;
            }
            set
            {
                m_Style = value;
            }
        }

        #endregion

        #region Fields

        internal Color m_Color;
        internal ShadowStyle m_Style;
        internal PointF m_Offset;
        internal Point m_Strength;

        #endregion
    }
}
