using System.Drawing;
using System.Windows.Forms;
using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.View.Events
{
    public class GMouseEventData : GEventData
    {
        #region Constructor

        public GMouseEventData(MouseEvent ev, int delta, int clicks, Point hit, MouseButtons button)
        {
            m_Event = ev;
            m_WheelDelta = delta;
            m_Clicks = clicks;
            m_HitPoint = hit;
            m_Button = button;
        }

        #endregion

        #region Properties

        public MouseEvent Event
        {
            get
            {
                return m_Event;
            }
        }
        public int WheelDelta
        {
            get
            {
                return m_WheelDelta;
            }
        }
        public int Clicks
        {
            get
            {
                return m_Clicks;
            }
        }
        public Point HitPoint
        {
            get
            {
                return m_HitPoint;
            }
        }
        public MouseButtons Button
        {
            get
            {
                return m_Button;
            }
        }

        #endregion

        #region Fields

        internal MouseEvent m_Event;
        internal int m_WheelDelta;
        internal int m_Clicks;
        internal Point m_HitPoint;
        internal MouseButtons m_Button;

        #endregion
    }
}
