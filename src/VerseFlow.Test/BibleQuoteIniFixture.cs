﻿using System.IO;
using System.Text;
using NUnit.Framework;
using VerseFlow.Core.Import.BibleQuote;

namespace VerseFlow.Test
{
	[TestFixture]
	public class BibleQuoteIniFixture
	{
		private BibleQuoteIni ini;

		[SetUp]
		public void SetUp()
		{
			ini = new BibleQuoteIni("folder", Encoding.Default, new string[0]);
		}

		[Test]
		public void Verse()
		{
			Assert.AreEqual("verse text ref goes here", ini.Verse("<p>verse text <a href=\"go rststrong 1 1 1\">ref</a> goes here</p>"));
			Assert.AreEqual("verse text ref goes here", ini.Verse("<p>verse text <a href=\"go rststrong 1 1 1\"\\>ref goes here</p>"));
			Assert.AreEqual("verse text goes here", ini.Verse(@"<p>verse text goes here</p>"));
			Assert.AreEqual("verse text goes here", ini.Verse(@"<p>verse text goes here"));
			Assert.AreEqual("verse,... ?  text  \"\" ref : goes here", ini.Verse("<p>verse,... ?  text  \"\" ref : goes here"));
		}

		[Test]
		public void Verse_when_no_tags()
		{
			Assert.AreEqual("verse text ref goes here", ini.Verse("verse text ref goes here"));
		}

		[Test]
		public void Verse_removes_non_letters_from_the_beginning()
		{
			Assert.AreEqual("verse text goes here", ini.Verse(@"123.@ # verse text goes here"));
		}
	}
}