using VerseFlow.Core.Import;

namespace VerseFlow.Core
{
	public interface IBibleRepository
	{
		IBible[] OpenAll();
		IBible Open(string title);
		IBibleWriter New();
	}
}