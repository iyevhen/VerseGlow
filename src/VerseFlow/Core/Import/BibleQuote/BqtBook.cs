using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace VerseFlow.Core.Import.BibleQuote
{
	[DebuggerDisplay("{Name}, {ChaptersCount}")]
	public class BqtBook : IBibleBook
	{
		private const string iniPathName = "PathName";
		private const string iniFullName = "FullName";
		private const string iniShortName = "ShortName";
		private const string iniChapterQty = "ChapterQty";

		private readonly BqtIni ini;
		private int chaptersCount;
		private string name;
		private string pathName;
		private string[] shortcuts = new string[0];

		public BqtBook(BqtIni ini)
		{
			if (ini == null)
				throw new ArgumentNullException("ini");

			this.ini = ini;
		}

		public string Name()
		{
			return name;
		}

		public string[] Shortcuts()
		{
			return shortcuts;
		}

		public int ChaptersCount()
		{
			return chaptersCount;
		}

		public IEnumerable<IBibleVerse> Verses()
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
						if (chapter > 0)
						{
							verseNum++;
							yield return new BqtVerse(chapter, verseNum, ini.Verse(line));
						}
					}
				}
			}
		}

		public static bool IsNewBook(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			return key.Equals(iniPathName, StringComparison.OrdinalIgnoreCase);
		}

		public bool Parse(string key, string value)
		{
			if (key.Equals(iniPathName, StringComparison.OrdinalIgnoreCase))
			{
				pathName = Path.Combine(ini.ParentFolder, value);
				return true;
			}

			if (key.Equals(iniFullName, StringComparison.OrdinalIgnoreCase))
			{
				name = value;
				return true;
			}

			if (key.Equals(iniShortName, StringComparison.OrdinalIgnoreCase))
			{
				shortcuts = value.Split(new[] {' ', ';', '\t', ','}, StringSplitOptions.RemoveEmptyEntries);
				return true;
			}

			if (key.Equals(iniChapterQty, StringComparison.OrdinalIgnoreCase))
			{
				int count;
				if (!int.TryParse(value, out count))
					throw new BqtImportException(string.Format("Cannot parse [{0}] from [{1}]", iniChapterQty, value));

				chaptersCount = count;
				return true;
			}

			return false;
		}
	}
}