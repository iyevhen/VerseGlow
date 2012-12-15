using VerseFlow.GFramework.Model;

namespace VerseFlow.GFramework.View.Text
{
	public class GTextViewLayoutContextState
	{
		public float X;
		public float Indent;
		public float Right;
		public TextWrap Wrap = TextWrap.WordAndChar;
		public ParagraphAlign Align = ParagraphAlign.Left;
	}
}