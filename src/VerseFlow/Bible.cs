using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace VerseFlow
{
	public class Bible
	{
		private readonly string file;
		private string fullName;

		public Bible(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			this.file = file;
		}

		public string FullName
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
								if (reader.IsStartElement())
								{
									if (reader.Name == "bible")
									{
										fullName = reader["name"];
										break;
									}
								}
							}
						}
					}
				}

				return fullName;
			}
		}

		public List<string> ReadAllVerses()
		{
			var result = new List<string>();

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					while (reader.Read())
					{
						if (reader.IsStartElement())
						{
							if (reader.Name == "v")
							{
								string id = reader["id"];

								if (reader.Read())
									result.Add(reader.Value);
							}
						}
					}
				}
			}

			return result;
		}

		public List<BibleBook> ReadBooks()
		{
			var result = new List<BibleBook>();

			using (var stream = new StreamReader(file, false))
			{
				using (XmlReader reader = XmlReader.Create(stream))
				{
					while (reader.Read())
					{
						if (reader.IsStartElement())
						{
							if (reader.Name == "book")
							{
								string name = reader["name"];
								string refs = reader["ref"];
								string chaptersString = reader["chapters"];

								int chapters;
								if (!int.TryParse(chaptersString, out chapters))
									throw new XmlSchemaException("'chapters' attribute expected to be of type Int32");

								result.Add(new BibleBook(name, refs, chapters));
							}
						}
					}
				}
			}

			return result;
		}

		public List<BibleVerse> ReadChapter(BibleBook book, int chapterNumber)
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
								if (reader.Name == "book" && reader["name"] == book.Name)
								{
									bookFound = true;
								}
							}
							else
							{
								if (!chapterFound)
								{
									if (reader.Name == "ch" && reader["id"] == chapterNumber.ToString())
									{
										chapterFound = true;
									}
								}
								else
								{
									if (reader.Name == "v")
									{
										string id = reader["id"];

										if (reader.Read())
											result.Add(new BibleVerse(reader.Value));
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
	}
}