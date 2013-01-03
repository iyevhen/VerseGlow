using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace VerseFlow
{
	public static class AppGlobal
	{
		private static string appDataFolder;
		private static string appName;
		private static Version appVersion;
		private static string biblesFolder;

		public static string AppName
		{
			get
			{
				if (string.IsNullOrEmpty(appName))
					PupulateAppNameAndVersion();

				return appName;
			}
		}

		public static Version AppVersion
		{
			get
			{
				if (appVersion == null)
					PupulateAppNameAndVersion();

				return appVersion;
			}
		}

		private static void PupulateAppNameAndVersion()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();

			var attr = (AssemblyProductAttribute)Attribute.GetCustomAttribute(executingAssembly, typeof(AssemblyProductAttribute));
			appName = attr.Product;
			appVersion = executingAssembly.GetName().Version;
		}

		public static string AppDataFolder
		{
			get
			{
				if (string.IsNullOrEmpty(appDataFolder))
					appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), AppName);

				return appDataFolder;
			}
		}

		public static string BiblesFolder
		{
			get
			{
				if (string.IsNullOrEmpty(biblesFolder))
					biblesFolder = Path.Combine(AppDataFolder, "Bibles");

				return biblesFolder;
			}
		}

		public static bool BiblesFolderExists
		{
			get { return Directory.Exists(BiblesFolder); }
		}

		public static IEnumerable<string> Bibles()
		{
			var names = new List<string>();

			foreach (string file in Directory.EnumerateFiles(AppDataFolder, "Bible_*.xml"))
			{
				using (var s = new StreamReader(file, false))
				{
					using (XmlReader reader = XmlReader.Create(s))
					{
						while (reader.Read())
						{
							if (reader.IsStartElement())
							{
								if (reader.Name == "bible")
								{
									names.Add(reader["name"]);
									break;
								}
							}
						}
					}
				}
			}

			return names;
		}
	}
}