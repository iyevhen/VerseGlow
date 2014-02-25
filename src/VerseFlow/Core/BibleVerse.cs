namespace VerseFlow.Core
{
	public class BibleVerse
	{
		private readonly ushort id;
		private readonly string text;

		public BibleVerse(ushort id, string text)
		{
			this.id = id;
			this.text = text;
		}

		public ushort Id
		{
			get { return id; }
		}

		public string Text
		{
			get { return text; }
		}
	}
}