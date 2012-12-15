using VerseFlow.GFramework.Events;

namespace VerseFlow.GFramework.Model.Collections
{
    public class GCollectionEventData : GEventData
    {
        #region Constructor

        public GCollectionEventData(object element, int index1, int index2, CollectionNotification notification)
        {
            m_Notification = notification;
            m_Element = element;
            m_Index1 = index1;
            m_Index2 = index2;
        }

        #endregion

        #region Properties

        public CollectionNotification Notification
        {
            get
            {
                return m_Notification;
            }
        }
        public object Element
        {
            get
            {
                return m_Element;
            }
        }
        public int Index1
        {
            get
            {
                return m_Index1;
            }
        }
        public int Index2
        {
            get
            {
                return m_Index2;
            }
        }

        #endregion

        #region Fields

        internal CollectionNotification m_Notification;
        internal object m_Element;
        internal int m_Index1;
        internal int m_Index2;

        #endregion
    }
}
