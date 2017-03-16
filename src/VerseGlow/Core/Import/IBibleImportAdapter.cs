using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VerseGlow.Core.Import
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
