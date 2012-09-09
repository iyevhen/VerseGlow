using System;
using System.Diagnostics;
using System.Text;
using FreePresenter.Core;
using FreePresenter.Convertion;

namespace FreePresenter.Core
{
	[DebuggerDisplay("book:{Id} [{ChildrenCount}]")]
	public class Book : TextContainer<TextContainer<TextSentence>>
	{
		public Book(string text)
			: base(text)
		{
		}
		

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			enumerator.OnBook(this);
			base.EnumerateWith(enumerator);
		}

		public string Code { get; set; }
	}
}