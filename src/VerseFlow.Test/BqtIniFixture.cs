using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using VerseFlow.Core.Import.BibleQuote;

namespace VerseFlow.Test
{
    [TestFixture]
    public class BqtIniFixture
    {
        private BqtIni ini;

        [SetUp]
        public void SetUp()
        {
            ini = new BqtIni("folder", Encoding.Default, new string[0]);
        }

        [Test]
        public void Verse()
        {
            Assert.AreEqual(
                @"«Так кто же Ты?» — спросили они Его. «Тот, кем Я себя называл с самого начала, — ответил Иисус. —",
                ini.GetVerseLine(
                    @"<sup>25</sup>  «Так кто же Ты?» — спросили они Его. «Тот, кем Я себя называл с самого начала, — ответил Иисус. —"));

            Assert.AreEqual("verse text ref goes here",
                            ini.GetVerseLine("<p>verse text <a href=\"go rststrong 1 1 1\">ref</a> goes here</p>"));
            Assert.AreEqual("verse text ref goes here",
                            ini.GetVerseLine("<p>verse text <a href=\"go rststrong 1 1 1\"\\>ref goes here</p>"));
            Assert.AreEqual("verse text goes here", ini.GetVerseLine(@"<p>verse text goes here</p>"));
            Assert.AreEqual("verse text goes here", ini.GetVerseLine(@"<p>verse text goes here"));
            Assert.AreEqual("verse,... ? text \"\" ref : goes here", ini.GetVerseLine("<p>verse,... ?  text  \"\" ref : goes here"));
        }

        [Test]
        public void Verse_when_no_tags()
        {
            Assert.AreEqual("verse text ref goes here", ini.GetVerseLine("verse text ref goes here"));
        }

        [Test]
        public void Verse_trimmes_digits_from_the_beginning()
        {
            Assert.AreEqual(".@ # verse text goes here", ini.GetVerseLine(@"123.@ # verse text goes here"));
        }

        [Test]
        public void Verse_trimmes_non_letters_from_the_beginning_except_for_specific()
        {
            Assert.IsTrue(Char.IsPunctuation('«'));
            Assert.AreEqual("«verse text goes here", ini.GetVerseLine(@" «verse text goes here  "));
            Assert.AreEqual("\"verse text goes here", ini.GetVerseLine(" \"verse text goes here"));
        }

        [Test]
        public void Verse_trimmes_end()
        {
            Assert.AreEqual(".@ # verse text goes here", ini.GetVerseLine(@"123.@ # verse text goes here		"));
        }

        [Test]
        public void Verse_replaces_anpersant_quote()
        {
            Assert.AreEqual("asd 1 \"verse\" text goes here		\"",
                            ini.GetVerseLine(@"asd 1 &quot;verse&quot; text goes here		&quot;"));
        }

        [Test]
        public void Only_one_space_between_words()
        {
            string line = ini.GetVerseLine(@"   first   word:   goes here 	");
            Assert.AreEqual("first word: goes here", line);
        }

        [Test]
        public void Skips_numbers_in_rects()
        {
            string line = ini.GetVerseLine(@"first [1] second [12] third[123] ");
            Assert.AreEqual("first second third", line);
        }

    }
}