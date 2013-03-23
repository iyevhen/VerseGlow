using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace VerseFlow.Core.Import.BibleQuote
{
	public class BqtBibleAdapter : IBibleImportAdapter
	{
		private readonly Encoding encoding;
		private readonly string iniFilePath;
		private BqtIni ini;

		public BqtBibleAdapter(string iniFilePath, Encoding encoding)
		{
			if (string.IsNullOrEmpty(iniFilePath))
				throw new ArgumentNullException("iniFilePath");

			if (encoding == null)
				throw new ArgumentNullException("encoding");

			this.iniFilePath = iniFilePath;
			this.encoding = encoding;
		}

		public string BibleName()
		{
			return BqtIni().BibleName;
		}

		public string BibleShortName()
		{
			return BqtIni().BibleShortName;
		}

		public CultureInfo Culture()
		{
			return new CultureInfo(BqtIni().Language);
		}

		public Encoding Encoding()
		{
			return encoding;
		}

		public bool HasOldTestement()
		{
			return BqtIni().HasOldTestament;
		}

		public bool HasNewTestement()
		{
			return BqtIni().HasNewTestament;
		}

		public bool HasApocrypha()
		{
			return BqtIni().HasApocrypha;
		}

		public int TotalBooksCount()
		{
			return BqtIni().BookQty;
		}

		public IEnumerable<IBibleBook> Books()
		{
			var result = new List<IBibleBook>();

			foreach (BqtBook book in BqtIni().Books)
				result.Add(book);

			return result;
		}

		private BqtIni BqtIni()
		{
			if (ini == null)
			{
				if (!File.Exists(iniFilePath))
					throw new FileNotFoundException(iniFilePath);

				ini = new BqtIni(
					Path.GetDirectoryName(iniFilePath),
					encoding,
					File.ReadAllLines(iniFilePath, encoding));
			}

			return ini;
		}
	}
}