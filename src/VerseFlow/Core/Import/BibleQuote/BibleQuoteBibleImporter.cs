using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace VerseFlow.Core.Import.BibleQuote
{
	public class BibleQuoteBibleImporter : BibleQuoteImporter
	{
		private const string elementBible = "bible";
		private const string elementBook = "book";
		private const string elementChapter = "ch";
		private const string elementVerse = "v";

		private const string attributeName = "name";
		private const string attributeId = "id";
		private const string attributeCodePage = "codepage";
		private const string attributeEncodingName = "encoding";
		private const string attributeBooks = "books";
		private const string attributeRef = "ref";
		private const string attributeChapters = "chapters";

		protected override void ImportImpl(BibleQuoteIni ini)
		{
			if (!ini.IsBible)
				return;

			string path = Path.Combine(AppGlobal.AppDataFolder, string.Format("Bible_{0}.xml", ini.BibleShortName));

			string folder = Path.GetDirectoryName(path);

			if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			using (var streamWriter = new StreamWriter(path, false))
			{
				using (XmlWriter writer = XmlWriter.Create(streamWriter, new XmlWriterSettings
					{
						Indent = true,
						IndentChars = " ",
						NewLineChars = Environment.NewLine
					}))
				{
					writer.WriteProcessingInstruction("xml", "version=\"1.0\"");
					writer.WriteStartElement(elementBible);
					writer.WriteAttributeString(attributeId, ini.BibleShortName);
					writer.WriteAttributeString(attributeName, ini.BibleName);
					writer.WriteAttributeString(attributeBooks, ini.BookQty.ToString(CultureInfo.InvariantCulture));
					writer.WriteAttributeString(attributeEncodingName, ini.Encoding.EncodingName);
					writer.WriteAttributeString(attributeCodePage, ini.Encoding.CodePage.ToString(CultureInfo.InvariantCulture));

					foreach (BibleQuoteBook book in ini.Books)
					{
						writer.WriteStartElement(elementBook);
						writer.WriteAttributeString(attributeId, "");
						writer.WriteAttributeString(attributeName, book.FullName);
						writer.WriteAttributeString(attributeRef, book.ShortName);
						writer.WriteAttributeString(attributeChapters, book.ChapterQty);

						int chapter = 0;
						foreach (BibleQuoteVerse verse in book.Verses)
						{
							if (verse.Chapter != chapter)
							{
								if (chapter > 0)
									writer.WriteEndElement();

								writer.WriteStartElement(elementChapter);
								writer.WriteAttributeString(attributeId, verse.Chapter.ToString(CultureInfo.InvariantCulture));
								chapter = verse.Chapter;
							}

							writer.WriteStartElement(elementVerse);
							writer.WriteAttributeString(attributeId, verse.VerseNum.ToString(CultureInfo.InvariantCulture));
							writer.WriteString(verse.Text);
							writer.WriteEndElement();
						}

						if (chapter > 0)
							writer.WriteEndElement();

						writer.WriteEndElement();
					}

					writer.WriteEndElement();
				}
			}
		}
	}
}
