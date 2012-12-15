using System.Drawing;
using VerseFlow.GFramework.Drawing;
using VerseFlow.GFramework.Drawing.Brushes;
using VerseFlow.GFramework.Drawing.Fonts;
using VerseFlow.GFramework.Drawing.Pens;

namespace VerseFlow.GFramework.View.Text
{
    public class GTextStyle
    {
        #region Constructor

        internal GTextStyle()
        {
            m_ScaleX = 1F;
            m_ScaleY = 1F;
        }
        internal GTextStyle(GTextStyle source)
        {
            m_Font = new GFont(source.m_Font);
            m_Brush = new GSolidBrush(source.m_Brush.Color);
            if (source.m_Pen != null)
            {
                m_Pen = new GPen(source.m_Pen.Color, source.m_Pen.Width);
            }
            if (source.m_Shadow != null)
            {
                m_Shadow = new GShadow(source.m_Shadow);
            }
            m_ScaleX = source.m_ScaleX;
            m_ScaleY = source.m_ScaleY;
        }

        #endregion

        #region Methods

        internal static GTextStyle NewDefaultStyle()
        {
            GTextStyle style = new GTextStyle();
            style.m_Font = new GFont(GFont.DefaultFace, GFont.DefaultSize);
            style.m_Brush = new GSolidBrush(Color.Black);

            return style;
        }

        #endregion

        #region Fields
        
        internal GFont m_Font;
        internal GSolidBrush m_Brush;
        internal GPen m_Pen;
        internal GShadow m_Shadow;
        internal float m_ScaleX;
        internal float m_ScaleY;

        #endregion
    }
}
