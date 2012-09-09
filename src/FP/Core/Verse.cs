using System;
using System.Diagnostics;
using FreePresenter.Core;
using FreePresenter.Convertion;

namespace FreePresenter.Core
{
	[DebuggerDisplay("verse:{Id}")]
	public class Verse : TextSentence
	{
		public Verse(int number, string text) : base(number, text) { }

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			enumerator.OnVerse(this);
		}
	}
}