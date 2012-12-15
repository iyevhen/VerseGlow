namespace VerseFlow.GFramework.Model.Text
{
    public class GBoldElement : GTextElement
    {
        #region Constructor

        public GBoldElement()
        {
        }

        #endregion

        #region Properties

        public override string TagName
        {
            get
            {
                return GTextDocument.BoldNodeName;
            }
        }

        #endregion
    }
}
