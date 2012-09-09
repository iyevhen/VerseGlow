using System.Diagnostics;
using FreePresenter.Core;
using FreePresenter.Convertion;

namespace FreePresenter.Core
{
	[DebuggerDisplay("song:{Text} [{ChildrenCount}]")]
	public class Song : TextContainer<TextSentence>
	{
		public Song(string name)
			: base(name)
		{
		}

		public Song(int number, string name)
			: base(number, name)
		{
		}

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			enumerator.OnSong(this);
			base.EnumerateWith(enumerator);
		}
	}
}