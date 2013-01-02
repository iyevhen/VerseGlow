using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VerseFlow.Core.Import
{
	public class FlatFile<T> : IEnumerable<T>
		where T : FlatFileLine, new()
	{
		readonly string filePath;

		readonly Encoding encoding;

		readonly char separator;

		public FlatFile(string filePath, Encoding encoding, char separator)
		{
			this.filePath = filePath;
			this.encoding = encoding;
			this.separator = separator;
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

		public IEnumerable<T> Read()
		{
			return this;
		}

		public void Write(T line)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			using (var reader = new StreamReader(filePath, encoding))
			{
				string line = reader.ReadLine();

				while (!string.IsNullOrEmpty(line) && !reader.EndOfStream)
				{
					var t = new T();
					t.SetValues(line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries));
					yield return t;

					line = reader.ReadLine();
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}