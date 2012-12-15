using System.Drawing;
using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.View.Events
{
    public class GInvalidatedEventData : GEventData
    {
        #region Constructor

        public GInvalidatedEventData(RectangleF[] invalidRects)
        {
            m_InvalidRects = invalidRects;
        }
        public GInvalidatedEventData(Region invalid)
        {
            m_InvalidRegion = invalid;
        }

        #endregion

        #region Properties

        public RectangleF[] InvalidRects
        {
            get
            {
                return m_InvalidRects;
            }
        }
        public Region InvalidRegion
        {
            get
            {
                return m_InvalidRegion;
            }
        }

        #endregion

        #region Fields

        internal RectangleF[] m_InvalidRects;
        internal Region m_InvalidRegion;

        #endregion
    }
}
