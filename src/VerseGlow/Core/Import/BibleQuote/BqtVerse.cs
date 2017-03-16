using System;

namespace VerseGlow.Core.Import.BibleQuote
{
	public class BqtVerse : IBibleVerse
	{
		private readonly int chapter;
		private readonly string text;
		private readonly int verseNum;

		public BqtVerse(int chapter, int verseNum, string text)
		{
			if (chapter <= 0)
				throw new ArgumentException("chapter cannot be negative or equals zero");

			if (verseNum <= 0)
				throw new ArgumentException("verseNum cannot be negative or equals zero");

			this.chapter = chapter;
			this.verseNum = verseNum;
			this.text = text;
		}

		public int Chapter()
		{
			return chapter;
		}

		public int Num()
		{
			return verseNum;
		}

		public string Text()
		{
			return text;
		}
	}
}