using FreePresenter.Core;
using NUnit.Framework;
using FreePresenter.UI;

namespace FreePresenter.UI.Test
{
	[TestFixture]
	public class VerseSeparatorFixture
	{
		private int verseCounter;

		[SetUp]
		public void SetUp()
		{
			verseCounter = 0;
		}

		[Test]
		public void Find_at_start()
		{
			TextBlock block = Text("i have such text");
			VerseSeparator separator = Find("i have su", block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_in_midle()
		{
			TextBlock block = Text("asdfsdf i have such text");
			VerseSeparator separator = Find("i have su", block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_at_the_end()
		{
			TextBlock block = Text("asdfsdf i have su");
			VerseSeparator separator = Find("i have su", block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_ignore_case_at_start()
		{
			TextBlock block = Text("i have such text");
			var onBlock = Text();
			
			onBlock
				.Add(Text("absdf i have sjkf alskdfj"))
				.Add(Text("88 sjdl;kj sdaf jasdlfjkd"))
				.Add(Text("utioe d fi i have s"))
				.Add(block);

			VerseSeparator separator = Find("I Have su", true, onBlock);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_ignore_case_in_midle()
		{
			TextBlock block = Text("jjjffjjkd dkjdjf;k ld i have such, textsdf as sd sd ");
			var onBlock = Text();

			onBlock
				.Add(Text("absdf i have sjkf alskdfj"))
				.Add(Text("88 sjdl;kj sdaf jasdlfjkd"))
				.Add(Text("utioe d fi i have s"))
				.Add(block);

			VerseSeparator separator = Find("I Have su", true, onBlock);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_ignore_case_at_the_end()
		{
			TextBlock block = Text("jjjffjjkd dkjdjfi have su");
			var onBlock = Text();

			onBlock
				.Add(Text("absdf i have sjkf alskdfj"))
				.Add(Text("88 sjdl;kj sdaf jasdlfjkd"))
				.Add(Text("utioe d fi i have s"))
				.Add(block);

			VerseSeparator separator = Find("I Have su", true, onBlock);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_strict_at_start()
		{
			TextBlock block = Text("i have su ch text");
			VerseSeparator separator = Find("i have su", false, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_strict_in_the_midle()
		{
			TextBlock block = Text("oijqword;éj s i word have su ch text");
			VerseSeparator separator = Find("word", false, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Do_not_Find_strict_at_the_end()
		{
			TextBlock block = Text("oijqword;éj s i wORd have suword ch text wor");
			VerseSeparator separator = Find("word", false, true, block);

			Assert.AreEqual(0, separator.VersesCount);
		}

		[Test]
		public void Find_strict_at_the_end()
		{
			TextBlock block = Text("oijqword;éj s i worsdfd have suword ch text word");
			VerseSeparator separator = Find("word", false, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Search_only_one_request_per_word()
		{
			TextBlock block = Text("1ab");
			VerseSeparator separator = Find("aa ab bb", block);

			Assert.AreEqual(0, separator.VersesCount);
		}

		[Test]
		public void Find_ignore_case_strict_at_start()
		{
			TextBlock block = Text("WoRd i have such text");
			VerseSeparator separator = Find("worD", true, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Find_ignore_case_strict_in_the_midle()
		{
			TextBlock block = Text("oijqword;éj s i word have su ch text");
			VerseSeparator separator = Find("wORd", true, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		[Test]
		public void Do_not_Find_ignore_case_strict_at_the_end()
		{
			TextBlock block = Text("oijqword;éj s i waord have suword ch text wor");
			VerseSeparator separator = Find("wORd", true, true, block);

			Assert.AreEqual(0, separator.VersesCount);
		}

		[Test]
		public void Find_ignore_case_strict_at_the_end()
		{
			TextBlock block = Text("oijqword;éj s i word have suword ch text word");
			VerseSeparator separator = Find("wORd", true, true, block);

			Assert.AreEqual(1, separator.VersesCount);
			Assert.AreSame(block, separator.GetVerse(0));
		}

		VerseSeparator Find(string searchText, TextBlock onBlock)
		{
			return Find(searchText, false, onBlock);
		}

		VerseSeparator Find(string searchText, bool ignoreCase, TextBlock onBlock)
		{
			return Find(searchText, ignoreCase, false, onBlock);
		}

		VerseSeparator Find(string searchText, bool ignoreCase, bool strict, TextBlock onBlock)
		{
			var separator = new VerseSeparator(searchText) { IgnoreCase = ignoreCase, MatchSctrictWord = strict};
			onBlock.EnumerateWith(separator);
			return separator;
		}

		TextBlock Text(string text)
		{
			return new Verse(++verseCounter, text);
		}

		TextBlock Text()
		{
			return new Chapter("Test");
		}
	}
}