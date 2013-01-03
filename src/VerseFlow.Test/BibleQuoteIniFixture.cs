using System.IO;
using System.Text;
using NUnit.Framework;
using VerseFlow.Core.Import.BibleQuote;

namespace VerseFlow.Test
{
	[TestFixture]
	public class BibleQuoteIniFixture
	{

		[Test]
		public void Verse()
		{
			var ini = new BibleQuoteIni("folder", Encoding.Default, new string[0]);
			Assert.AreEqual("verse text ref goes here", ini.Verse("<p>verse text <a href=\"go rststrong 1 1 1\">ref</a> goes here</p>"));
			Assert.AreEqual("verse text ref goes here", ini.Verse("<p>verse text <a href=\"go rststrong 1 1 1\"\\>ref goes here</p>"));
			Assert.AreEqual("verse text goes here", ini.Verse(@"<p>verse text goes here</p>"));
			Assert.AreEqual("verse text goes here", ini.Verse(@"<p>verse text goes here"));
		}
	}
}