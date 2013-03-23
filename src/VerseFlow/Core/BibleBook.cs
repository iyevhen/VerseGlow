using System;

namespace VerseFlow.Core
{
	public class BibleBook
	{
		private readonly string name;
		private readonly string refs;
		private readonly int chaptersCount;

		public BibleBook(string name, string refs, int chaptersCount)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (string.IsNullOrEmpty(refs))
				throw new ArgumentNullException("refs");

			if (chaptersCount <= 0)
				throw new ArgumentException("chaptersCount cannot be negative or equals 0");

			this.name = name;
			this.refs = refs;
			this.chaptersCount = chaptersCount;
		}

		public int ChaptersCount
		{
			get { return chaptersCount; }
		}

		public string Refs
		{
			get { return refs; }
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