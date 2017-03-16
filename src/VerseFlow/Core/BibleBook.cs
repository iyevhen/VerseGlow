using System;
using System.Text.RegularExpressions;

namespace VerseGlow.Core
{
	public class BibleBook
	{
		private readonly string name;
		private readonly string shortcuts;
		private readonly int chaptersCount;
		private string shortcut;

		//http://stackoverflow.com/questions/150033/regular-expression-to-match-non-english-characters
		private static readonly Regex nonenglish = new Regex("[^\x00-\x7F]+", RegexOptions.Compiled);

		public BibleBook(string name, string shortcuts, int chaptersCount)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (string.IsNullOrEmpty(shortcuts))
				throw new ArgumentNullException("shortcuts");

			if (chaptersCount <= 0)
				throw new ArgumentException("chaptersCount cannot be negative or equals 0");

			this.name = name;
			this.shortcuts = shortcuts;
			this.chaptersCount = chaptersCount;
		}

		public int ChaptersCount
		{
			get { return chaptersCount; }
		}

		public string Name
		{
			get { return name; }
		}

		public string[] Shortcuts
		{
			get { return shortcuts.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries); }
		}

		public string Shortcut
		{
			get
			{
				if (string.IsNullOrEmpty(shortcut))
				{
					string[] all = Shortcuts;
					Array.Sort(all, (s1, s2) => s1.Length.CompareTo(s2.Length));
					shortcut = all[0];

					if (nonenglish.IsMatch(name))
					{
						for (int i = 0; i < all.Length; i++)
						{
							if (nonenglish.IsMatch(all[i]))
							{
								shortcut = all[i];
								break;
							}
						}
					}
				}
				return shortcut;
			}
		}

		public override string ToString()
		{
			return name;
		}
	}
}