using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Verseflow.Database;

namespace Verseflow
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static ILog log = new Logger(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "VerseFlow.log"));

		public static ILog Log
		{
			get
			{
				return log;
			}
		}
	}

	internal class Logger : ILog
	{
		private readonly string file;

		public Logger(string file)
		{
			if (string.IsNullOrEmpty(file))
				throw new ArgumentNullException("file");

			this.file = file;
		}

		public void Error(Exception exception, string message)
		{
			Debug.WriteLine(string.Format("ERROR: {0}. {1}", message, exception.Message));
		}
	}
}
