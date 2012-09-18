using System.Diagnostics;
using FreePresenter.Core;

namespace FreePresenter.Core
{
	[DebuggerDisplay("bible: {Id}")]
	public class Bible : TextContainer<Book>
	{
		public Bible(string name) : base(name) { }

		public int CodePage { get; set; }

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			enumerator.OnBible(this);
			base.EnumerateWith(enumerator);
		}

		public override string Link
		{
			get { return string.Empty; }
		}
	}
}