using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VerseFlow.Core.Import
{
	public interface IBibleImportAdapter
	{
		string BibleName();
		string BibleShortName();
		CultureInfo Culture();
		Encoding Encoding();
		bool HasOldTestement();
		bool HasNewTestement();
		bool HasApocrypha();
		int TotalBooksCount();
		IList<IBibleBook> Books();
	}
}
