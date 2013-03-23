﻿using System.Collections.Generic;

namespace VerseFlow.Core.Import
{
	public interface IBibleBook
	{
		string[] Shortcuts();
		string Name();
		int ChaptersCount();
		IEnumerable<IBibleVerse> Verses();
	}
}