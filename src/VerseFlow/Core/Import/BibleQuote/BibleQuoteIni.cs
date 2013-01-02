using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VerseFlow.Core.Import.BibleQuote
{
	/// <summary>
	/// http://bqt.ru/OpisanieFormataModulejj?v=xqh
	/// </summary>
	public class BibleQuoteIni
	{
		public const string INI = "bibleqt.ini";

		private readonly List<BibleQuoteBook> books = new List<BibleQuoteBook>();
		private readonly Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		private readonly string filePath;

		public BibleQuoteIni(string filePath, Encoding encoding)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException("filePath");

			this.filePath = filePath;

			BibleQuoteBook book = null;

			foreach (string line in File.ReadLines(filePath, encoding))
			{
				string li = line.Trim();

				if (string.IsNullOrEmpty(li))
					continue;

				if (li.StartsWith("//"))
					continue;

				string[] pair = li.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

				if (pair.Length != 2)
					continue;

				string key = pair[0].Trim();
				string value = pair[1].Trim();

				if (BibleQuoteBook.IsNewBook(key))
				{
					book = new BibleQuoteBook(this);
					books.Add(book);
				}

				if (book != null && book.Parse(key, value))
					continue;

				if (values.ContainsKey(key))
					throw new BibleQuoteImportException(string.Format("'{0}' contains dublicated KEY - '{1}'", INI, key));

				values.Add(key, value);
			}
		}

		public IEnumerable<BibleQuoteBook> Books
		{
			get { return books.ToArray(); }
		}

		public string FilePath
		{
			get { return filePath; }
		}

		public string BibleName
		{
			get { return GetString(Tags.BibleName); }
		}

		public string BibleShortName
		{
			get { return GetString(Tags.BibleShortName); }
		}

		public bool IsBible
		{
			get { return GetBool(Tags.Bible); }
		}

		public bool HasOldTestament
		{
			get { return GetBool(Tags.OldTestament); }
		}

		public bool HasNewTestament
		{
			get { return GetBool(Tags.NewTestament); }
		}

		public bool HasApocrypha
		{
			get { return GetBool(Tags.Apocrypha); }
		}

		public bool IsGreek
		{
			get { return GetBool(Tags.Greek); }
		}

		public string HTMLFilter
		{
			get { return GetString(Tags.HTMLFilter); }
		}

		public string Language
		{
			get { return GetString(Tags.Language); }
		}

		public string Alphabet
		{
			get { return GetString(Tags.Alphabet); }
		}

		public string DesiredFontName
		{
			get { return GetString(Tags.DesiredFontName); }
		}

		public int DesiredFontCharset
		{
			get { return GetInt32(Tags.DesiredFontCharset); }
		}

		public string ChapterSign
		{
			get { return GetString(Tags.ChapterSign); }
		}

		public string VerseSign
		{
			get { return GetString(Tags.VerseSign); }
		}

		public int BookQty
		{
			get { return GetInt32(Tags.BookQty); }
		}

		private bool GetBool(string tag)
		{
			string value;
			return values.TryGetValue(tag, out value)
				   && value.Equals("Y", StringComparison.OrdinalIgnoreCase);
		}

		private int GetInt32(string tag)
		{
			int int32 = 0;
			string value;

			if (!values.TryGetValue(tag, out value))
				return int32;

			Int32.TryParse(value, out int32);
			return int32;
		}

		private string GetString(string tag)
		{
			string value;
			return values.TryGetValue(tag, out value) ? value : null;
		}

		static class Tags
		{
			public const string BibleName = "BibleName";
			public const string BibleShortName = "BibleShortName";
			public const string Bible = "Bible";
			public const string OldTestament = "OldTestament";
			public const string NewTestament = "NewTestament";
			public const string Apocrypha = "Apocrypha";
			public const string Greek = "Greek";
			public const string HTMLFilter = "HTMLFilter";
			public const string Language = "Language";
			public const string Alphabet = "Alphabet";
			public const string DesiredFontName = "DesiredFontName";
			public const string DesiredFontCharset = "DesiredFontCharset";
			public const string ChapterSign = "ChapterSign";
			public const string VerseSign = "VerseSign";
			public const string BookQty = "BookQty";
		}
	}
}