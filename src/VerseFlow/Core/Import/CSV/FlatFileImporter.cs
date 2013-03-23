using System;
using System.Collections.Generic;
using System.Text;

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
		}
	}
}