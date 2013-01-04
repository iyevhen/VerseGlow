using System;
using System.IO;
using System.Text;
using VerseFlow.UI;

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

			string inifile = DirectoryHelp.GetFile(fromFolderPath, BibleQuoteIni.INI);

			if (string.IsNullOrEmpty(inifile))
				throw new BibleQuoteImportException(string.Format("Expected to find '{0}' file in '{1}'", BibleQuoteIni.INI, fromFolderPath));

			var ini = new BibleQuoteIni(
					Path.GetDirectoryName(inifile),
					encoding,
					File.ReadAllLines(inifile, encoding));

			return ImportImpl(ini);
		}

		protected abstract string ImportImpl(BibleQuoteIni ini);
	}
}