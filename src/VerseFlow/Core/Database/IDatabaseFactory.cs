namespace VerseFlow.Core.Database
{
	public interface IDatabaseFactory
	{
		IDatabase NewBibleDatabase();
	}
}