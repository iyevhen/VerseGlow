using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace VerseFlow.Core.Database.SQLite
{
	public class SqliteDatabaseFactory : IDatabaseFactory
	{
		private readonly string databaseFolderPath;

		static SqliteDatabaseFactory()
		{
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			SQLiteFunction.RegisterFunction(typeof(SqliteCaseInsensitiveCollation));
		}

		public SqliteDatabaseFactory(string databaseFolderPath)
		{
			if (string.IsNullOrEmpty(databaseFolderPath))
				throw new ArgumentNullException("databaseFolderPath");

			this.databaseFolderPath = databaseFolderPath;
		}

		public IDatabase NewBibleDatabase()
		{
			var db = new Database(new SqliteDatabaseAdapter(databaseFolderPath));

			if (!File.Exists(databaseFolderPath) || new FileInfo(databaseFolderPath).Length == 0)
				db.ExecuteNonQuery(Schemas.BibleSchema);

			return db;
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			if (args.Name.StartsWith("System.Data.SQLite, ", StringComparison.OrdinalIgnoreCase))
			{
				string myLocation = Assembly.GetAssembly(typeof(SqliteDatabaseFactory)).Location;
				string myParentFolder = Path.GetDirectoryName(myLocation);

				AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;

				if (!string.IsNullOrEmpty(myParentFolder))
				{
					string dir = Path.Combine(myParentFolder, IntPtr.Size == 8 ? "x64" : "x86");
					return Assembly.LoadFile(Path.Combine(dir, "System.Data.SQLite.dll"));
				}
			}

			return null;
		}
	}
}