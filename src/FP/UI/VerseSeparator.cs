using System;
using System.Collections.Generic;
using FreePresenter.Core;

namespace FreePresenter.UI
{
	public class VerseSeparator : ITextEnumerator
	{
		//private readonly string searchText;
		private readonly List<Verse> verses = new List<Verse>();
		private readonly Dictionary<TextBlock, List<TextMatch>> versesMatches = new Dictionary<TextBlock, List<TextMatch>>();
		private readonly bool search;
		private readonly string[] strings;

		public VerseSeparator() { }

		public VerseSeparator(string searchText)
		{
			if (!string.IsNullOrEmpty(searchText))
			{
				strings = searchText.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				search = true;
			}
		}

		void ITextEnumerator.OnBible(Bible bible) { }

		void ITextEnumerator.OnBook(Book book) { }

		void ITextEnumerator.OnChapter(Chapter chapter) { }
		void ITextEnumerator.OnSong(Song song) { }

		void ITextEnumerator.OnVerse(Verse verse)
		{
			if (search)
			{
				int wordRight = 0;
				int wordIndex = 0;

				var matches = new List<TextMatch>();

				while (wordIndex < strings.Length)
				{
					int wordLeft = verse.Text.IndexOf(strings[wordIndex], wordRight, IgnoreCase
																	? StringComparison.OrdinalIgnoreCase
																	: StringComparison.Ordinal);
					// nothing found
					if (wordLeft == -1)
						return;

					wordRight = wordLeft + strings[wordIndex].Length;

					if (MatchSctrictWord)
					{
						bool leftOk = wordLeft == 0
							|| !Char.IsLetter(verse.Text[wordLeft - 1]);

						bool rightOk = wordRight == verse.Text.Length
							|| !Char.IsLetter(verse.Text[wordRight]);

						if (leftOk && rightOk)
						{
							wordIndex++;
							matches.Add(new TextMatch(wordLeft, wordRight));
						}
					}
					else
					{
						wordIndex++;
						matches.Add(new TextMatch(wordLeft, wordRight));
					}

					// move to next word
					while (wordRight != verse.Text.Length && Char.IsLetter(verse.Text[wordRight]))
						wordRight++;
				}

				if (wordIndex == strings.Length)
				{
					verses.Add(verse);

					if (matches.Count > 0)
						versesMatches.Add(verse, matches);
				}

				return;
			}

			verses.Add(verse);
		}

		bool ITextEnumerator.Break
		{
			get { return false; }
		}

		public int VersesCount
		{
			get { return verses.Count; }
		}

		public bool IgnoreCase { get; set; }

		public bool MatchSctrictWord { get; set; }

		public TextBlock GetVerse(int itemIndex)
		{
			return verses[itemIndex];
		}

		public List<TextMatch> GetMatch(TextBlock textBlock)
		{
			List<TextMatch> matches;
			return versesMatches.TryGetValue(textBlock, out matches) ? matches : null;
		}
	}

	public struct TextMatch
	{
		private int from;
		private int to;

		public TextMatch(int from, int to)
		{
			if (from > to)
				throw new ArgumentException(string.Format("value [{0}] should be less then [{1}]", from, to));

			this.from = from;
			this.to = to;
		}

		public int From
		{
			get { return from; }
		}

		public int To
		{
			get { return to; }
		}

		public int Length
		{
			get { return to - from; }
		}
	}
}