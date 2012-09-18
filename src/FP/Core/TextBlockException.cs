using System;

namespace FreePresenter.Core
{
	class TextBlockException : FreePresenterException
	{
		public TextBlockException(string message) : base(message) { }

		public static Exception InvalidTextBlock(string expected, string original)
		{
			throw new TextBlockException(string.Format("Expected TextBlock is [{0}] but was [{1}]", expected, original));
		}
	}
}