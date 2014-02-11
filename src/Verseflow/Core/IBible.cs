﻿using System.Collections.Generic;

namespace VerseFlow.Core
{
	public interface IBible
	{
		string Name { get; }

		List<BibleBook> OpenBooks();
		List<BibleVerse> OpenChapter(BibleBook book, string chapter);
		List<BibleVerse> FindVerses(string searchText);
	}
}