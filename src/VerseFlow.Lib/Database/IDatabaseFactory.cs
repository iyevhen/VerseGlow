namespace VerseFlow.Lib.Database
{
	public interface IDatabaseFactory
	{
		IDatabase NewBibleDatabase();
	}
}