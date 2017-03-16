using System.Text;

namespace VerseGlow.Core.Import.CSV
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