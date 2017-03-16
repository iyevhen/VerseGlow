using VerseGlow.Core.Import;

namespace VerseGlow.Core
{
	public interface IBibleRepository
	{
		IBible[] OpenAll();
		IBible Open(string title);
		IBibleWriter New();
	}
}