using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using VerseFlow.Core.Import;

namespace VerseFlow.Core
{
	public class XmlBible : IBible
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

		private readonly string file;
		private string fullName;

		public XmlBible(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			this.file = file;
		}

		public string Title()
		{
			if (string.IsNullOrEmpty(fullName))
			{
				using (var stream = new StreamReader(file, false))
				{
					using (XmlReader reader = XmlReader.Create(stream))
					{
						while (reader.Read())
						{
							if (reader.IsStartElement() && reader.Name == elementBible)
							{
								fullName = reader[attributeName];
								break;
							}
						}
					}
				}
			}
			return fullName;
		}

		public List<BibleBook> OpenBooks()
		{
			var books = new List<BibleBook>();

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					while (reader.Read())
					{
						if (reader.IsStartElement() && reader.Name == elementBook)
						{
							string name = reader[attributeName];
							string refs = reader[attributeRef];
							string chaptersString = reader[attributeChapters];

							int chapters;
							if (!int.TryParse(chaptersString, out chapters))
								throw new XmlSchemaException("'chapters' attribute expected to be of type Int32");

							books.Add(new BibleBook(name, refs, chapters));
						}
					}
				}
			}

			return books;
		}

		public List<BibleVerse> OpenChapter(BibleBook book, string chapter)
		{
			var result = new List<BibleVerse>();
			bool bookFound = false;
			bool chapterFound = false;

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					while (reader.Read())
					{
						if (reader.IsStartElement())
						{
							if (!bookFound)
							{
								if (reader.Name == elementBook && reader[attributeName] == book.Name)
								{
									bookFound = true;
								}
							}
							else
							{
								if (!chapterFound)
								{
									if (reader.Name == elementChapter && reader[attributeId] == chapter)
									{
										chapterFound = true;
									}
								}
								else
								{
									if (reader.Name == elementVerse)
									{
										string id = reader[attributeId];

										if (reader.Read())
											result.Add(new BibleVerse(id, reader.Value));
									}
									else
									{
										break;
									}
								}
							}
						}
					}
				}
			}

			return result;
		}

		public List<BibleVerse> OpenVerses(string text)
		{
			if (string.IsNullOrEmpty(text))
				throw new ArgumentNullException("text");

			var found = new List<BibleVerse>();

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					while (reader.Read())
					{
						string refs;
						string chapter;

						if (reader.IsStartElement() && reader.Name == elementBook)
						{
							refs = reader[attributeRef];
						}

						if (reader.IsStartElement() && reader.Name == elementChapter)
						{
							chapter = reader[attributeId];
						}

						if (reader.IsStartElement() && reader.Name == elementVerse)
						{
							string id = reader[attributeId];

							if (reader.Read())
							{
								string value = reader.Value;

								if (value.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
								{
									found.Add(new BibleVerse(id, value));
								}
							}
						}
					}
				}
			}

			return found;
		}

		public static IBibleWriter NewWriter(string contentFolder)
		{
			return new XmlBibleWriter(contentFolder);
		}

		private class XmlBibleWriter : IBibleWriter
		{
			private readonly string destinationFolder;

			public XmlBibleWriter(string destinationFolder)
			{
				if (string.IsNullOrEmpty(destinationFolder))
					throw new ArgumentNullException("destinationFolder");

				this.destinationFolder = destinationFolder;
			}

			public IBible Write(IBibleImportAdapter adapter)
			{
				if (adapter == null)
					throw new ArgumentNullException("adapter");

				string filePath = Path.Combine(destinationFolder, string.Format("Bible_{0}.xml", adapter.BibleShortName()));
				string folderPath = Path.GetDirectoryName(filePath);

				if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath))
				{
					Directory.CreateDirectory(folderPath);
				}

				using (var streamWriter = new StreamWriter(filePath, false))
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
						writer.WriteAttributeString(attributeId, adapter.BibleShortName());
						writer.WriteAttributeString(attributeName, adapter.BibleName());
						writer.WriteAttributeString(attributeBooks, adapter.TotalBooksCount().ToString(CultureInfo.InvariantCulture));
						writer.WriteAttributeString(attributeEncodingName, adapter.Encoding().EncodingName);
						writer.WriteAttributeString(attributeCodePage, adapter.Encoding().CodePage.ToString(CultureInfo.InvariantCulture));

						foreach (IBibleBook book in adapter.Books())
						{
							writer.WriteStartElement(elementBook);
							writer.WriteAttributeString(attributeId, "");
							writer.WriteAttributeString(attributeName, book.Name());
							writer.WriteAttributeString(attributeRef, string.Join(" ", book.Shortcuts()));
							writer.WriteAttributeString(attributeChapters, book.ChaptersCount().ToString(CultureInfo.InvariantCulture));

							int chapter = 0;
							foreach (IBibleVerse verse in book.Verses())
							{
								if (verse.Chapter() != chapter)
								{
									if (chapter > 0)
										writer.WriteEndElement();

									writer.WriteStartElement(elementChapter);
									writer.WriteAttributeString(attributeId, verse.Chapter().ToString(CultureInfo.InvariantCulture));
									chapter = verse.Chapter();
								}

								writer.WriteStartElement(elementVerse);
								writer.WriteAttributeString(attributeId, verse.Num().ToString(CultureInfo.InvariantCulture));
								writer.WriteString(verse.Text());
								writer.WriteEndElement();
							}

							if (chapter > 0)
								writer.WriteEndElement();

							writer.WriteEndElement();
						}

						writer.WriteEndElement();
					}
				}

				return new XmlBible(filePath);
			}

			public void Dispose()
			{
			}
		}
	}
}