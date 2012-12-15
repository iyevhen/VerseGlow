namespace VerseFlow.GFramework.Model.Text
{
    public class GItalicElement : GTextElement
    {
        #region Constructor

        public GItalicElement()
        {
        }

        #endregion

        #region Properties

        public override string TagName
        {
            get
            {
                return GTextDocument.ItalicNodeName;
            }
        }

        #endregion
    }
}
