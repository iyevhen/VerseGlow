namespace VerseFlow.GFramework.DataStructure
{
    public struct GBitVector64
    {
        #region Constructor

        public GBitVector64(GBitVector64 source)
        {
            m_Data = source.m_Data;
        }

        #endregion

        #region Public Methods

        public bool this[ulong key]
        {
            get
            {
                return (m_Data & key) == key;
            }
            set
            {
                if (value)
                {
                    m_Data |= key;
                }
                else
                {
                    m_Data &= ~key;
                }
            }
        }

        #endregion

        #region Public Overrides

        public override bool Equals(object obj)
        {
            if ((obj is GBitVector64) == false)
            {
                return false;
            }

            return (GBitVector64)obj == this;
        }
        public override int GetHashCode()
        {
            return m_Data.GetHashCode();
        }

        #endregion

        #region Operators

        public static bool operator ==(GBitVector64 vector1, GBitVector64 vector2)
        {
            return vector1.m_Data == vector2.m_Data;
        }
        public static bool operator !=(GBitVector64 vector1, GBitVector64 vector2)
        {
            return vector1.m_Data != vector2.m_Data;
        }

        #endregion

        #region Fields

        internal ulong m_Data;

        #endregion
    }
}
