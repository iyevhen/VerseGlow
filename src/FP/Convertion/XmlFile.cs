using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using FreePresenter.Core;

namespace FreePresenter.Convertion
{
	public class XmlFile<T>
		where T : TextBlock
	{
		readonly string filePath;

		public XmlFile(string filePath)
		{
			Is.NotNullOrEmpty(filePath, "filePath");

			this.filePath = filePath;
		}

		public string Name
		{
			get { return System.IO.Path.GetFileNameWithoutExtension(filePath); }
		}

		public string Path
		{
			get { return filePath; }
		}

		public bool Exists
		{
			get { return File.Exists(filePath); }
		}

		public T Read()
		{
			string fileFolderPath = System.IO.Path.GetDirectoryName(filePath);

			if (!string.IsNullOrEmpty(fileFolderPath) && !Directory.Exists(fileFolderPath))
				throw new DirectoryNotFoundException(fileFolderPath);

			using (var s = new StreamReader(filePath, false))
			{
				using (XmlReader reader = XmlReader.Create(s))
				{
					return new XmlTextBlockReader(reader).Read();
				}
			}
		}

		public void Write(T textBlock)
		{
			string parentFolder = System.IO.Path.GetDirectoryName(filePath);

			if (!string.IsNullOrEmpty(parentFolder) && !Directory.Exists(parentFolder))
				Directory.CreateDirectory(parentFolder);

			using (var s = new StreamWriter(filePath, false))
			{
				var settings = new XmlWriterSettings
								{
									Indent = true,
									IndentChars = " ",
									NewLineChars = Environment.NewLine
								};

				using (XmlWriter writer = XmlWriter.Create(s, settings))
				{
					writer.WriteProcessingInstruction("xml", "version=\"1.0\"");
					new XmlTextBlockWriter(writer).Write(textBlock);
				}
			}
		}

		#region Helpers

		class XmlTextInputOutput
		{
			protected Bible currentBible;
			protected Book currentBook;
			protected Chapter currentChapter;
			protected Song currentSong;
			protected Verse currentVerse;
			protected int verseCounter;

			protected const string elementBible = "Bible";
			protected const string elementBook = "book";
			protected const string elementChapter = "ch";
			protected const string elementVerse = "v";
			protected const string elementSong = "s";

			protected const string attributeName = "name";
			protected const string attributeCodePage = "CodePage";
			protected const string attributeCount = "c";
			protected const string attributeNumber = "n";
		}

		class XmlTextBlockWriter : XmlTextInputOutput, ITextEnumerator
		{
			readonly XmlWriter writer;

			public XmlTextBlockWriter(XmlWriter writer)
			{
				this.writer = writer;
			}

			public void Write(T textBlock)
			{
				if (textBlock == null)
					throw new ArgumentNullException("textBlock");

				textBlock.EnumerateWith(this);
				Flush();
			}

			void ITextEnumerator.OnBible(Bible bible)
			{
				if (currentBible != null)
					writer.WriteEndElement();

				currentBible = bible;

				writer.WriteStartElement(elementBible);
				writer.WriteAttributeString(attributeName, bible.Text);
				writer.WriteAttributeString(attributeCodePage, bible.CodePage.ToString());

//				writer.WriteStartElement(elementDescription);
//				writer.WriteString(bible.Description);
//				writer.WriteEndElement();
			}

			void ITextEnumerator.OnBook(Book book)
			{
				if (currentBook != null)
				{
					if (currentChapter != null)
					{
						writer.WriteEndElement();
						currentChapter = null;
					}

					if (currentSong != null)
					{
						writer.WriteEndElement();
						currentSong = null;
					}

					writer.WriteEndElement();
				}

				currentBook = book;

				writer.WriteStartElement(elementBook);
				writer.WriteAttributeString(attributeName, book.Text);
				writer.WriteAttributeString(attributeCount, book.ChildrenCount.ToString());
			}

			void ITextEnumerator.OnChapter(Chapter chapter)
			{
				if (currentChapter != null)
					writer.WriteEndElement();

				currentChapter = chapter;
				verseCounter = 1;

				writer.WriteStartElement(elementChapter);
				writer.WriteAttributeString(attributeNumber, chapter.Text);
				writer.WriteAttributeString(attributeCount, chapter.ChildrenCount.ToString());
			}


			void ITextEnumerator.OnSong(Song song)
			{
				if (currentSong != null)
					writer.WriteEndElement();

				currentSong = song;
				verseCounter = 1;

				writer.WriteStartElement(elementSong);
				writer.WriteAttributeString(attributeNumber, song.Id.ToString());
				writer.WriteAttributeString(attributeName, song.Text);
				writer.WriteAttributeString(attributeCount, song.ChildrenCount.ToString());
			}

			void ITextEnumerator.OnVerse(Verse verse)
			{
				writer.WriteStartElement(elementVerse);
				writer.WriteAttributeString(attributeNumber, verseCounter.ToString());
				writer.WriteString(verse.Text);
				writer.WriteEndElement();
				verseCounter++;
			}

			bool ITextEnumerator.Break
			{
				get { return false; }
			}

			void Flush()
			{
				if (currentChapter != null)
				{
					writer.WriteEndElement();
					currentChapter = null;
				}

				if (currentSong != null)
				{
					writer.WriteEndElement();
					currentSong = null;
				}

				if (currentBook != null)
				{
					writer.WriteEndElement();
					currentBook = null;
				}

				if (currentBible != null)
				{
					writer.WriteEndElement();
					currentBible = null;
				}
			}
		}

		class XmlTextBlockReader : XmlTextInputOutput
		{
			readonly XmlReader reader;

			public XmlTextBlockReader(XmlReader reader)
			{
				this.reader = reader;
			}

			public T Read()
			{
				while (reader.Read())
				{
					if (reader.IsStartElement())
					{
						switch (reader.Name)
						{
							case elementBible:

								string bibleName = reader[attributeName];

								if (string.IsNullOrEmpty(bibleName))
									throw new XmlSchemaException(string.Format("Expected attribute [{0}] with value on the element [{1}]", attributeName, elementBible));

								currentBible = new Bible(bibleName);

								string codePageString = reader[attributeCodePage];

								if (!string.IsNullOrEmpty(codePageString))
								{
									int codePage;
									if (!int.TryParse(codePageString, out codePage))
										throw new XmlSchemaValidationException(string.Format("Attribute [{0}] should be a number", attributeCodePage));

									currentBible.CodePage = codePage;
								}

								break;

							case elementBook:

								string bookName = reader[attributeName];

								if (string.IsNullOrEmpty(bookName))
									throw new XmlSchemaException(string.Format("Expected attribute [{0}] with value on the element [{1}]", attributeName, elementBook));

								currentBook = new Book(bookName);

								if (currentBible != null)
									currentBible.Add(currentBook);

								break;

							case elementChapter:

								string chapterNumberString = reader[attributeNumber];

								if (string.IsNullOrEmpty(chapterNumberString))
									throw new XmlSchemaException(string.Format("Expected attribute [{0}] with value on the element [{1}]", attributeNumber, elementChapter));

								uint chapterNumber;
								if (!uint.TryParse(chapterNumberString, out chapterNumber))
									throw new XmlSchemaValidationException(string.Format("Attribute [{0}] should be a number > 0", attributeNumber));

								currentChapter = new Chapter(chapterNumber.ToString());
								verseCounter = 0;

								if (currentBook != null)
									currentBook.Add(currentChapter);

								break;

							case elementSong:

								string songNumberString = reader[attributeNumber];

								if (string.IsNullOrEmpty(songNumberString))
									throw new XmlSchemaException(string.Format("Expected attribute [{0}] with value on the element [{1}]", attributeNumber, elementSong));

								int songNumber;
								if (!int.TryParse(songNumberString, out songNumber))
									throw new XmlSchemaValidationException(string.Format("Attribute [{0}] should be a number", attributeNumber));

								if (songNumber <= 0)
									throw new XmlSchemaValidationException(string.Format("Attribute [{0}] should be a number > 0", attributeNumber));

								currentSong = new Song(songNumber, reader[attributeName]);
								verseCounter = 0;

								if (currentBook != null)
									currentBook.Add(currentSong);

								break;

							case elementVerse:

								if (reader.Read())
									currentVerse = new Verse(++verseCounter, reader.Value);

								if (currentChapter != null)
									currentChapter.Add(currentVerse);

								if (currentSong != null)
									currentSong.Add(currentVerse);

								break;
						}
					}
				}

				var bible = currentBible as T;

				if (bible != null)
					return bible;

				var book = currentBook as T;

				if (book != null)
					return book;

				var chapter = currentChapter as T;

				if (chapter != null)
					return chapter;

				var song = currentSong as T;

				if (song != null)
					return song;

				var verse = currentVerse as T;

				if (verse != null)
					return verse;

				return null;
			}
		}

		#endregion
	}
}