using System;
using System.Collections.Generic;
using System.IO;
using VerseFlow.Core.Import;

namespace VerseFlow.Core
{
	class XmlBibleRepository : IBibleRepository
	{
		private readonly string contentFolder;

		public XmlBibleRepository(string contentFolder)
		{
			if (string.IsNullOrEmpty(contentFolder))
				throw new ArgumentNullException("contentFolder");

			this.contentFolder = contentFolder;
		}

		public IBible Open(string title)
		{
			throw new System.NotImplementedException();
		}

		public IBible[] OpenAll()
		{
			var bibles = new List<IBible>();

			if (Directory.Exists(contentFolder))
			{
				foreach (string file in Directory.GetFiles(contentFolder, "Bible_*.xml"))
					bibles.Add(new XmlBible(file));
			}

			return bibles.ToArray();
		}

		public IBibleWriter New()
		{
			return XmlBible.NewWriter(contentFolder);
		}
	}
}