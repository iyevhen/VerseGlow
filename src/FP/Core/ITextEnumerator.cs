using FreePresenter.Core;

namespace FreePresenter.Core
{
	public interface ITextEnumerator
	{
		void OnBible(Bible bible);
		void OnBook(Book book);
		void OnChapter(Chapter chapter);
		void OnVerse(Verse verse);
		void OnSong(Song song);

		bool Break { get; }
	}
}