using System.Collections.Generic;
using VerseFlow.GFramework.Model.Nodes;

namespace VerseFlow.GFramework.Model.Text
{
    internal class GTextDocumentParseContext
    {
        #region Constructor

        internal GTextDocumentParseContext(GTextElementFactory factory)
        {
            m_Elements = new Stack<GElement>();
            m_Factory = factory;
        }

        #endregion

        #region Fields

        internal Stack<GElement> m_Elements;
        internal GTextElementFactory m_Factory;

        #endregion
    }
}
