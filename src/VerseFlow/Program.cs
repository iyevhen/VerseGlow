using System;
using System.Data.SQLite;
using System.Windows.Forms;
using VerseFlow.Lib.Database.SQLite;

namespace VerseFlow
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			SQLiteFunction.RegisterFunction(typeof(SqliteCaseInsensitiveCollation));

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain());
		}
	}
}
