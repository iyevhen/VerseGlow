namespace VerseFlow.GFramework.Events
{
    public class GPropertyEventData : GEventData
    {
        #region Constructor

        public GPropertyEventData(int propertyKey)
        {
            m_Key = propertyKey;
        }

        #endregion

        #region Properties

        public int Key
        {
            get
            {
                return m_Key;
            }
        }

        #endregion

        #region Fields

        internal int m_Key;

        #endregion
    }
}
