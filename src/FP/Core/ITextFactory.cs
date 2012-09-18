using System.Xml;

namespace FreePresenter.Core
{
	interface ITextFactory
	{
		TextBlock Bible(string name);

		TextBlock Book(string name);

		TextBlock Chapter(string name);

		TextBlock Verse(int number, string name);
	}
}