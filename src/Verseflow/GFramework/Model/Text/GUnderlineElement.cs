namespace VerseFlow.GFramework.Model.Text
{
    public class GUnderlineElement : GTextElement
    {
        #region Constructor

        public GUnderlineElement()
        {
        }

        #endregion

        #region Properties

        public override string TagName
        {
            get
            {
                return GTextDocument.UnderlineNodeName;
            }
        }

        #endregion
    }
}
