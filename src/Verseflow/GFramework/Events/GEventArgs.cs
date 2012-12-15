using System;

namespace VerseFlow.GFramework.Events
{
    public class GEventArgs : EventArgs
    {
        #region Constructor

        public GEventArgs(object originator, GEventData data, int eventKey, EventPropagation propagation)
        {
            m_Originator = originator;
            m_Data = data;
            m_Key = eventKey;
            m_Propagation = propagation;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int Key
        {
            get
            {
                return m_Key;
            }
        }
        public GEventData Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }
        public object Originator
        {
            get
            {
                return m_Originator;
            }
        }
        public object Sender
        {
            get
            {
                return m_Sender;
            }
            set
            {
                m_Sender = value;
            }
        }
        public EventResult Result
        {
            get
            {
                return m_Result;
            }
            set
            {
                m_Result = value;
            }
        }
        public EventPropagation Propagation
        {
            get
            {
                return m_Propagation;
            }
            set
            {
                m_Propagation = value;
            }
        }

        #endregion

        #region Fields

        internal object m_Originator;
        internal object m_Sender;
        internal GEventData m_Data;
        internal EventResult m_Result;
        internal EventPropagation m_Propagation;
        internal int m_Key;

        #endregion

        #region Static
        #endregion
    }
}
