namespace VerseFlow.GFramework.Model.Text
{
    public class GStringElement : GTextElement
    {
        public GStringElement()
        {
        }

        #region Properties

        public override string TagName
        {
            get
            {
                return GTextDocument.TextNodeName;
            }
        }

        public override bool ContainsText
        {
            get
            {
                return true;
            }
        }

        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                m_Text = value;
            }
        }

        #endregion

        #region Fields

        internal string m_Text;

        #endregion
    }
}
