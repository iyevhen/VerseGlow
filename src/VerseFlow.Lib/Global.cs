using System;
using VerseFlow.Lib.Database;
using VerseFlow.Lib.Database.SQLite;

namespace VerseFlow.Lib
{
	public static class Global
	{
		private static IDatabaseFactory dbFactory;

		public static IDatabaseFactory DatabaseFactory()
		{
			if (dbFactory == null)
			{
				string databaseFolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "VerseFlow");
				dbFactory = new SqliteDatabaseFactory(databaseFolderPath);
			}
			return dbFactory;
		}
	}
}