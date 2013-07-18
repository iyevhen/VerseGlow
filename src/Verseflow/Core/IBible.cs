using System.Collections.Generic;

namespace VerseFlow.Core
{
	public interface IBible
	{
		string Name();

		List<BibleBook> OpenBooks();
		List<BibleVerse> OpenChapter(BibleBook book, string chapter);
		List<BibleVerse> OpenVerses(string searchText);
	}
}