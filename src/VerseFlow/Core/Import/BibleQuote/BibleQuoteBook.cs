using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace VerseFlow.Core.Import.BibleQuote
{
	[DebuggerDisplay("{FullName}, {ChapterQty}")]
	public class BibleQuoteBook
	{
		private readonly BibleQuoteIni ini;
		private string pathName;
		private string fullName;
		private string shortName;
		private string chapterQty;
		private IEnumerable<BibleQuoteVerse> verses;

		public BibleQuoteBook(BibleQuoteIni ini)
		{
			if (ini == null)
				throw new ArgumentNullException("ini");

			this.ini = ini;
			
		}

		public static bool IsNewBook(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			return key.Equals(Tags.PathName, StringComparison.OrdinalIgnoreCase);
		}

		public bool Parse(string key, string value)
		{
			if (key.Equals(Tags.PathName, StringComparison.OrdinalIgnoreCase))
			{
				pathName = Path.Combine(ini.ParentFolder, value);
				return true;
			}

			if (key.Equals(Tags.FullName, StringComparison.OrdinalIgnoreCase))
			{
				fullName = value;
				return true;
			}

			if (key.Equals(Tags.ShortName, StringComparison.OrdinalIgnoreCase))
			{
				shortName = value;
				return true;
			}

			if (key.Equals(Tags.ChapterQty, StringComparison.OrdinalIgnoreCase))
			{
				chapterQty = value;
				return true;
			}

			return false;
		}

		public string FullName
		{
			get { return fullName; }
		}

		public string ShortName
		{
			get { return shortName; }
		}

		public string ChapterQty
		{
			get { return chapterQty; }
		}

		public IEnumerable<BibleQuoteVerse> Verses
		{
			get
			{
				int chapter = 0;
				int verseNum = 0;

				using (var reader = new StreamReader(pathName, ini.Encoding))
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();

						if (ini.IsChapter(line))
						{
							chapter++;
							verseNum = 0;
						}
						else if (ini.IsVerse(line))
						{
							verseNum++;
							yield return new BibleQuoteVerse(chapter, verseNum, ini.Verse(line));
						}
					}
				}
			}
		}

		static class Tags
		{
			public const string PathName = "PathName";
			public const string FullName = "FullName";
			public const string ShortName = "ShortName";
			public const string ChapterQty = "ChapterQty";
		}
	}
}