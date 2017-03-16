using System;

namespace VerseGlow.Core.Import.BibleQuote
{
	public class BqtImportException : Exception
	{
		public BqtImportException(string message) : base(message) { }
	}
}