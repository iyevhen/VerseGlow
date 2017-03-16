namespace VerseGlow.Core.Import
{
	public interface IBibleVerse
	{
		int Chapter();
		int Num();
		string Text();
	}
}