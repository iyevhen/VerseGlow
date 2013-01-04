using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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
	}
}