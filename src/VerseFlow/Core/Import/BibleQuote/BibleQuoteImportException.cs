using System;

namespace VerseFlow.Core.Import.BibleQuote
{
	public class BibleQuoteImportException : Exception
	{
		public BibleQuoteImportException(string message) : base(message) { }
	}
}