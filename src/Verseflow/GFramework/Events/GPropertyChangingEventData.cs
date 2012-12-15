namespace VerseFlow.GFramework.Events
{
    public class GPropertyChangingEventData : GPropertyEventData
    {
        public GPropertyChangingEventData(int propertyKey, object newValue)
            : base(propertyKey)
        {
            m_Value = newValue;
        }

        public object Value
        {
            get
            {
                return m_Value;
            }
        }

        #region Fields

        internal object m_Value;

        #endregion
    }
}
