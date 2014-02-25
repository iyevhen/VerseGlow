using System;

namespace VerseFlow.Core
{
	public class BibleBook
	{
		private readonly string name;
		private readonly string shortcuts;
		private readonly ushort chaptersCount;

		public BibleBook(string name, string shortcuts, ushort chaptersCount)
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

		public string[] Shortcuts
		{
			get { return shortcuts.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries); }
		}


		public string Name
		{
			get { return name; }
		}

		public override string ToString()
		{
			return name;
		}
	}
}