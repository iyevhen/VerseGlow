using System.Diagnostics;
using FreePresenter.Core;
using FreePresenter.Convertion;

namespace FreePresenter.Core
{
	[DebuggerDisplay("chapter:{Id} [{ChildrenCount}]")]
	public class Chapter : TextContainer<TextSentence>
	{
		public Chapter(string text)
			: base(text)
		{
			separator = " ";
		}

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			enumerator.OnChapter(this);
			base.EnumerateWith(enumerator);
		}
	}
}