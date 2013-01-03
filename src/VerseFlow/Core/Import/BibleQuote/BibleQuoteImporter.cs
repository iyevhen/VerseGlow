using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VerseFlow.Core.Import.BibleQuote
{
	public abstract class BibleQuoteImporter
	{
		public string Import(string fromFolderPath, Encoding encoding)
		{
			if (string.IsNullOrEmpty(fromFolderPath))
				throw new ArgumentNullException("fromFolderPath");

			if (!Directory.Exists(fromFolderPath))
				throw new DirectoryNotFoundException(fromFolderPath);

			string inifile = Directory.EnumerateFiles(fromFolderPath)
									  .FirstOrDefault(file => Path.GetFileName(file).Equals(BibleQuoteIni.INI, StringComparison.OrdinalIgnoreCase));

			if (string.IsNullOrEmpty(inifile))
				throw new BibleQuoteImportException(string.Format("Expected to find '{0}' file in '{1}'", BibleQuoteIni.INI, fromFolderPath));

			var ini = new BibleQuoteIni(
					Path.GetDirectoryName(inifile),
					encoding,
					File.ReadLines(inifile, encoding));

			return ImportImpl(ini);
		}

		protected abstract string ImportImpl(BibleQuoteIni ini);
	}
}