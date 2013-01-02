using System.Collections.Generic;
using System.Data;
using System.Text;
using VerseFlow.Core.Database;
using VerseFlow.Core.Database.SQLite;

namespace VerseFlow.Core.Import.BibleQuote
{
	public class BibleQuoteBibleImporter : BibleQuoteImporter
	{
		protected override string ImportImpl(BibleQuoteIni ini)
		{
			if (!ini.IsBible)
				return null;

			foreach (BibleQuoteBook book in ini.Books)
			{
				foreach (BibleQuoteBookChapter chapter in book.Chapters)
				{
				}
			}

			return null;
		}
	}
}
