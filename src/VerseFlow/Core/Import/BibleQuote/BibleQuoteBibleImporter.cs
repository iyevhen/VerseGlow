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

			IDatabase db = AppGlobal.DatabaseFactory().NewBibleDatabase();

			foreach (BibleQuoteBook book in ini.Books)
			{
				db.ExecuteNonQuery("INSERT INTO Bible (bookname, chapterscount) VALUES (?, ?)", book.FullName, book.ChapterQty);
				int bookid = db.GetRowID<int>("Bible");

				using (var con = db.GetNewConnection())
				{
					using (db.ExecuteInBulk(con))
					{
						IDbCommand cmd = con.CreateCommand();
						cmd.CommandText = "INSERT INTO BibleContent (bookid, chapternum, versenum, versetext) VALUES (?, ?, ?, ?)";
						cmd.Prepare();

						foreach (BibleQuoteVerse verse in book.Verses)
						{
							db.ExecuteNonQuery(cmd, bookid, verse.Chapter, verse.VerseNum, verse.Text);
						}
					}
				}
			}

			return null;
		}
	}
}
