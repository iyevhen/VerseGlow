using System;
using System.IO;
using System.Reflection;

using VerseGlow.Core;
using VerseGlow.Properties;

namespace VerseGlow
{
	public static class Options
	{
		private static readonly string appName;
		private static readonly Version appVersion;
		private static IBibleRepository bibleRepository;

		static Options()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			var attr = (AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute));
			appName = attr.Product;
			appVersion = assembly.GetName().Version;
		}

		public static string AppName
		{
			get { return appName; }
		}

		public static Version AppVersion
		{
			get { return appVersion; }
		}

		public static IBibleRepository BibleRepository
		{
			get { return bibleRepository ?? (bibleRepository = new XmlBibleRepository(AppFolder())); }
		}

		public static string AppFolder()
		{
			return string.IsNullOrEmpty(Settings.Default.AppFolder)
				? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), AppName)
				: Settings.Default.AppFolder;
		}
	}
}