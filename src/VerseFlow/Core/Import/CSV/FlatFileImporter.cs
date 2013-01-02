using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VerseFlow.Core.Database;
using VerseFlow.Core.Database.SQLite;

namespace VerseFlow.Core.Import.CSV
{
	public class FlatFileImporter
	{
		private FlatFile<FlatBibleLine> file;

		public FlatFileImporter(string filepath)
		{
			file = new FlatFile<FlatBibleLine>(filepath, Encoding.Unicode, '\t');
		}

		public void ImportBible(FlatFile<FlatBibleLine> flatFile)
		{
			string book = null;
			int bookid = 0;
			int chapters = 0;

			IDatabase db = AppGlobal.DatabaseFactory().NewBibleDatabase();
			var bookLines = new List<FlatBibleLine>();

			foreach (FlatBibleLine line in flatFile)
			{
				if (!line.BookName.Equals(book, StringComparison.OrdinalIgnoreCase))
				{
					if (bookLines.Count > 0)
					{
						db.ExecuteNonQuery("UPDATE Bible SET chapterscount = ? WHERE bookid = ?", chapters, bookid);

						using (var con = db.GetNewConnection())
						{
							using (db.ExecuteInBulk(con))
							{
								IDbCommand cmdVerse = con.CreateCommand();
								cmdVerse.CommandText = "INSERT INTO BibleContent (bookid, chapternum, versenum, versetext) VALUES (?, ?, ?, ?)";
								cmdVerse.Prepare();

								foreach (FlatBibleLine l in bookLines)
								{
									db.ExecuteNonQuery(cmdVerse, bookid, l.ChapterNumber, l.VerseNumber, l.VerseText);
								}
							}
						}
					}

					db.ExecuteNonQuery("INSERT INTO Bible (bookname) VALUES (?)", line.BookName);

					bookid = db.GetRowID<int>("Bible");
					book = line.BookName;
					bookLines = new List<FlatBibleLine>();
				}

				chapters = line.ChapterNumber;
				bookLines.Add(line);
			}
		}
	}
}