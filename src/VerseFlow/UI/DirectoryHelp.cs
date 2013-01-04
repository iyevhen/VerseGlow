using System;
using System.IO;
using VerseFlow.Core.Import.BibleQuote;

namespace VerseFlow.UI
{
	public static class DirectoryHelp
	{
		public static string GetFile(string dir, string fileName)
		{
			string[] files = Directory.GetFiles(dir);

			foreach (string file in files)
			{
				var name = Path.GetFileName(file);

				if (name != null && name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
					return name;
			}

			return null;
		}
	}
}