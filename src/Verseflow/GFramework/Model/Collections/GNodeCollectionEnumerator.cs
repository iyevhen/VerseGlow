using System.Collections;
using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Collections
{
    public class GNodeCollectionEnumerator : IEnumerator
    {
        #region Constructor

        public GNodeCollectionEnumerator(GNodeCollectionBase collection)
        {
            m_Collection = collection;
        }

        #endregion

        #region IEnumerator

        public object Current
        {
            get
            {
                return m_CurrentNode;
            }
        }
        public bool MoveNext()
        {
            if (m_MoveNextIterations >= 0 && m_MoveNextIterations < m_Collection.Count)
            {
                m_CurrentNode = m_Collection.gnodes[m_MoveNextIterations];
            }

            m_MoveNextIterations++;

            return m_CurrentNode != null;
        }
        public void Reset()
        {
            m_CurrentNode = null;
            m_MoveNextIterations = 0;
        }

        #endregion

        #region Fields

        internal int m_MoveNextIterations;
        internal GNode m_CurrentNode;
        internal GNodeCollectionBase m_Collection;

        #endregion
    }
}
