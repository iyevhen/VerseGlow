namespace FreePresenter.Core
{
	class TextFactory : ITextFactory
	{
		public TextBlock Bible(string name)
		{
			return new Bible(name);
		}

		public TextBlock Book(string name)
		{
			return new Book(name);
		}

		public TextBlock Chapter(string name)
		{
			return new Chapter(name);
		}

		public TextBlock Verse(int number, string name)
		{
			return new Verse(number, name);
		}
	}
}