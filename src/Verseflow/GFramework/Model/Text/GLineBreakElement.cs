namespace VerseFlow.GFramework.Model.Text
{
    public class GLineBreakElement : GTextElement
    {
	    public override string TagName
        {
            get { return GTextDocument.LineBreakNodeName; }
        }
        public override bool IsLineBreak
        {
            get { return true; }
        }
    }
}
