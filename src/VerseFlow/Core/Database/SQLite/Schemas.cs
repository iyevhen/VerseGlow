namespace VerseFlow.Core.Database.SQLite
{
	static class Schemas
	{
		public const string BibleSchema = @"

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

--CREATE INDEX `IDX_BibleContent_versetext` ON `BibleContent` (`versetext` COLLATE UTF8CI)
";
	}
}