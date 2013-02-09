namespace VerseFlow
{
	public class BibleVerse
	{
		private readonly string text;

		public BibleVerse(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}
	}
}