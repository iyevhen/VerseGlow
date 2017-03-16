using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Schema;

using VerseGlow.Core.Import;

namespace VerseGlow.Core
{
	public class XmlBible : IBible
	{
		private const string elementBible = "bible";
		private const string elementBook = "book";
		private const string elementChapter = "ch";
		private const string elementVerse = "v";

		private const string attributeName = "name";
		private const string attributeId = "id";
		private const string attributeBooks = "books";
		private const string attributeShortcuts = "shortcuts";
		private const string attributeChapters = "chapters";

		private readonly string file;
		private string fullName;

		public XmlBible(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			this.file = file;
		}

		public string Name
		{
			get
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
							string refs = reader[attributeShortcuts];
							string chaptersString = reader[attributeChapters];

							ushort chapters;
							if (!ushort.TryParse(chaptersString, out chapters))
								throw new XmlSchemaException(string.Format("'{0}' attribute expected to be of type UInt16", attributeChapters));

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
									if (reader.Name == elementChapter)
									{
										if (reader[attributeId] == chapter)
											chapterFound = true;
									}
									else if (reader.Name != elementVerse)
									{
										break;
									}
								}
								else
								{
									if (reader.Name == elementVerse)
									{
										ushort id;
										if (!ushort.TryParse(reader[attributeId], out id))
											throw new XmlSchemaException(string.Format("'{0}' attribute expected to be of type UInt16", attributeId));

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

		public List<BibleVerse> FindVerses(string searchText)
		{
			if (string.IsNullOrEmpty(searchText))
				throw new ArgumentNullException("searchText");

			var found = new List<BibleVerse>();

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					string bookName = string.Empty;
					string chapter = string.Empty;

					while (reader.Read())
					{
						if (reader.IsStartElement() && reader.Name == elementBook)
						{
							bookName = reader[attributeName];
						}

						if (reader.IsStartElement() && reader.Name == elementChapter)
						{
							chapter = reader[attributeId];
						}

						if (reader.IsStartElement() && reader.Name == elementVerse)
						{
							ushort id;
							if (!ushort.TryParse(reader[attributeId], out id))
								throw new XmlSchemaException(string.Format("'{0}' attribute expected to be of type UInt16", attributeId));

							if (reader.Read())
							{
								string val = reader.Value;
								string verse = string.Format("({0} {1}:{2})   {3}",
									bookName, chapter, id, val);

								if (val.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
								{
									found.Add(new BibleVerse(id, verse));
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

						for (int i = 0; i < adapter.Books().Count; i++)
						{
							IBibleBook book = adapter.Books()[i];
							writer.WriteStartElement(elementBook);
							writer.WriteAttributeString(attributeId, (i + 1).ToString(CultureInfo.InvariantCulture));
							writer.WriteAttributeString(attributeName, book.Name());
							writer.WriteAttributeString(attributeShortcuts, string.Join(" ", book.Shortcuts()));
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