using System;

namespace VerseFlow.Core.Import.BibleQuote
{
	public class BibleQuoteVerse
	{
		private readonly int chapter;
		private readonly int verseNum;
		private readonly string text;

		public BibleQuoteVerse(int chapter, int verseNum, string text)
		{
			if (chapter <= 0)
				throw new ArgumentException("chapter cannot be negative or equals zero");

			if (verseNum <= 0)
				throw new ArgumentException("verseNum cannot be negative or equals zero");

			this.chapter = chapter;
			this.verseNum = verseNum;
			this.text = text;
		}

		public int Chapter
		{
			get { return chapter; }
		}

		public int VerseNum
		{
			get { return verseNum; }
		}

		public string Text
		{
			get { return text; }
		}
	}
}