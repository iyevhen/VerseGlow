using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace VerseFlow.Lib.Database.SQLite
{
	public class SqliteDatabaseFactory : IDatabaseFactory
	{
		private readonly string databaseFolderPath;

		private const string schema = @"

CREATE TABLE [Bible] (
[bookid] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[bookname] NVARCHAR(100) NOT NULL,
[bookref] NVARCHAR(10) NULL,
[bookcode] VARCHAR(3)  NULL,
[newtestament] BOOLEAN DEFAULT 0 NULL,
[chapterscount] INTEGER DEFAULT 1 NOT NULL
);

CREATE TABLE [BibleContent] (
[bookid] INTEGER  NOT NULL,
[chapternum] INTEGER  NOT NULL,
[versenum] INTEGER  NOT NULL,
[versetext] NVARCHAR(400) NOT NULL COLLATE UTF8CI,
PRIMARY KEY (bookid, chapternum, versenum)
);

CREATE TABLE [BibleInfo] (
[biblename] NVARCHAR(200)  NOT NULL,
[description] TEXT  NULL,
[biblecode] VARCHAR(3)  NULL
);

CREATE INDEX `IDX_BibleContent_versetext` ON `BibleContent` (`versetext` COLLATE UTF8CI)
";

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
				db.ExecuteNonQuery(schema);

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