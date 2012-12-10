using System;
using System.Collections.Generic;
using System.Data;
using VerseFlow.Lib.Database;
using VerseFlow.Lib.Database.SQLite;

namespace VerseFlow.Lib.Import
{
	public class FlatFileImporter
	{
		public void ImportWords(FlatFile<FlatBibleLine> flatFile)
		{
			var words = new Dictionary<string, long>();
			var separator = new[] { ' ' };

			foreach (FlatBibleLine line in flatFile)
			{
				foreach (string word in line.VerseText.Split(separator, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!words.ContainsKey(word))
						words.Add(word, 0);

					words[word] += 1;
				}
			}

			IDatabase db = new SqliteDatabaseFactory(string.Format(@"D:\{0}_words.db", flatFile.Name)).NewWordsDatabase();

			using (var con = db.GetNewConnection())
			{
				using (db.ExecuteInBulk(con))
				{
					IDbCommand cmd = con.CreateCommand();
					cmd.CommandText = "INSERT INTO Words (word, wordCount) VALUES (?, ?)";
					cmd.Prepare();

					foreach (var pair in words)
					{
						db.ExecuteNonQuery(cmd, pair.Key, pair.Value);
					}
				}
			}
		}

		public void ImportBible(FlatFile<FlatBibleLine> flatFile)
		{
			string book = null;
			int bookid = 0;
			int chapters = 0;

			IDatabase db = new SqliteDatabaseFactory(string.Format(@"D:\{0}.db", flatFile.Name)).NewBibleDatabase();
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