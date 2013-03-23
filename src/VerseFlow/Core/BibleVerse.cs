namespace VerseFlow.Core
{
	public class BibleVerse
	{
		private readonly string id;
		private readonly string text;

		public BibleVerse(string id, string text)
		{
			this.id = id;
			this.text = text;
		}

		public string Id
		{
			get { return id; }
		}

		public string Text
		{
			get { return text; }
		}
	}
}