using System.Collections.Generic;

namespace VerseFlow.Core
{
	public interface IBible
	{
		string Title();

		List<BibleBook> OpenBooks();
		List<BibleVerse> OpenChapter(BibleBook book, string chapter);
		List<BibleVerse> OpenVerses(string text);
	}
}