using System;
using FreePresenter.Core;
using FreePresenter.UI;

namespace FreePresenter.Convertion
{
	class FlatBibleConverter : ObjectConverter<Bible, FlatFile<FlatBibleLine>>
	{
		public override Bible Convert(FlatFile<FlatBibleLine> flatFile)
		{
			var factory = IoC.Resolve<ITextFactory>();
			var bible = factory.Bible(flatFile.Name);

			foreach (FlatBibleLine line in flatFile)
			{
				TextBlock book = bible[line.BookName];

				if (book == null)
				{
					book = factory.Book(line.BookName);
					bible.Add(book);
				}

				string chapterName = line.ChapterNumber.ToString();
				TextBlock chapter = book[chapterName];

				if (chapter == null)
				{
					chapter = factory.Chapter(chapterName);
					book.Add(chapter);
				}

				chapter.Add(factory.Verse(line.VerseNumber, line.VerseText));
			}

			return (Bible)bible;
		}

		public override FlatFile<FlatBibleLine> Convert(Bible @in)
		{
			throw new NotImplementedException();
		}
	}
}