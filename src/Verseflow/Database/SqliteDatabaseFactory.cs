using System;
using System.IO;
using System.Reflection;

namespace Verseflow.Database
{
	public class SqliteDatabaseFactory : IDatabaseFactory
	{
		private readonly string databaseFilePath;

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
[versetext] NVARCHAR(400)  NOT NULL,
PRIMARY KEY (bookid, chapternum, versenum)
);

CREATE TABLE [BibleInfo] (
[biblename] NVARCHAR(200)  NOT NULL,
[description] TEXT  NULL,
[biblecode] VARCHAR(3)  NULL
);

";

		private const string schema_words = @"
CREATE TABLE [Words] (
[word] NVARCHAR(100)  NULL,
[wordCount] INTEGER  NULL
);

CREATE INDEX [IDX_WORDS_WORD] ON [Words](
[word]  ASC
);
";

		static SqliteDatabaseFactory()
		{
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}

		public SqliteDatabaseFactory(string databaseFilePath)
		{
			if (string.IsNullOrEmpty(databaseFilePath))
				throw new ArgumentNullException("databaseFilePath");

			this.databaseFilePath = databaseFilePath;
		}

		public IDatabase NewWordsDatabase()
		{
			var db = new Database(new SqliteDatabaseAdapter(databaseFilePath));

			if (!File.Exists(databaseFilePath) || new FileInfo(databaseFilePath).Length == 0)
				db.ExecuteNonQuery(schema_words);

			return db;
		}

		public IDatabase NewBibleDatabase()
		{
			var db = new Database(new SqliteDatabaseAdapter(databaseFilePath));

			if (!File.Exists(databaseFilePath) || new FileInfo(databaseFilePath).Length == 0)
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