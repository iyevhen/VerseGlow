namespace Verseflow.Database
{
	public interface IDatabaseFactory
	{
		IDatabase NewBibleDatabase();
	}
}