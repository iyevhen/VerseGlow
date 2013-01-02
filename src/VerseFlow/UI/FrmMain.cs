using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Core.Import.BibleQuote;
using VerseFlow.Properties;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			delim = 0;
			var strings = new List<string>();

			if (!string.IsNullOrEmpty(textBoxPath.Text) && File.Exists(textBoxPath.Text))
			{

				using (var reader = new StreamReader(textBoxPath.Text))
				{
					int i = 1;
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						if (line != null)
						{
							strings.Add(string.Format("{0}. {1}", i, line));
							i++;
						}
					}
				}

			}
			else
			{
				int count;
				if (!int.TryParse(textBox1.Text, out count))
					textBox1.Text = "NOT VALID VALUE";

				int maxVerse;
				if (!int.TryParse(textBox2.Text, out maxVerse))
					textBox1.Text = "NOT VALID VALUE";

				for (int i = 0; i < count; i++)
				{
					string randomString = RandomString(random.Next(2, maxVerse));
					strings.Add(string.Format("{0}_{1}", i, randomString));
				}
			}

			Populate(strings);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Populate(new List<string>
			{ 
				"Ελληνική Καινή Διαθήκη", 
				"新約全書", 
				"«алдыњда кубанычка бљлљйсєњ турасыњар Силердин жаныњардан асманга кљтљрєлєп кеткен бул Ыйса, љзєњљр кљргљндљй, асманга кандай кљтљрєлєп кетсе, ошондой эле кайра келет»",
				"Покај се, дакле! Ако ли не, доћи ћу ти скоро и војеваћу с њима мачем уста својих.",
				"עִבְרִיתבְּרֵאשִׁית  7225 בָּרָא  1254 אֱלֹהִים  430 אֵת  853 הַשָּׁמַיִם  8064 וְאֵת  853 הָאָרֶץ  776 "
			});
		}

		private void Populate(List<string> strings)
		{
			var sw = Stopwatch.StartNew();

			verseView1.Fill(strings);

			sw.Stop();

			statLblDebug.Text = "Pupulated in " + sw.Elapsed;
		}

		private static readonly Random random = new Random((int)DateTime.Now.Ticks); //thanks to McAden
		private static readonly string[] delimiters = new[] { " ", "- ", "\t", ": ", "; ", ", ", ". ", " «", "» " };
		private static long delim;
		private IDisplay display;

		private string RandomString(int size)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < size; i++)
			{
				char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);

				int _break = random.Next(1, 30);
				if ((i % _break) == 0)
				{
					delim++;

					builder.Append(delimiters[delim % (delimiters.Length - 1)]);

					//					if ((_break % 2) == 0)
					//						builder.Append(' ');
					//					else
					//						builder.Append('\n');
				}
			}
			builder.Append(" END!");

			return builder.ToString();
		}

		private void buttonHightlihght_Click(object sender, EventArgs e)
		{
			verseView1.HighlightText = textBoxHighlight.Text;
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			Text = string.Format("{0} - v{1}", AppGlobal.AppName, AppGlobal.AppVersion);

			if (AppGlobal.BiblesFolderExists)
			{
				foreach (string file in Directory.GetFiles(AppGlobal.BiblesFolder))
				{
					var item = tsBibles.DropDownItems.Add(Path.GetFileNameWithoutExtension(file));
					item.Click += OpenBibleHandler;
				}
			}
		}

		private void OpenBibleHandler(object sender, EventArgs e)
		{
			MessageBox.Show("Open bible");
		}

		private void tsAbout_Click(object sender, EventArgs e)
		{
			using (var f = new FrmAbout())
			{
				f.Icon = Icon;
				f.Text = AppGlobal.AppName;
				f.ShowDialog(this);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			display = new FrmDisplay { Icon = Icon };
			display.Activate();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			display.Deactivate();
			((Form)display).Dispose();
		}

		private void bibleQuoteBibleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string folder;
			using (var fb = new FolderBrowserDialog())
			{
				fb.Description = Resources.SelectBibleQuoteBibleFolder;

				if (DialogResult.OK != fb.ShowDialog(this))
					return;

				folder = fb.SelectedPath;
			}

			try
			{
				new BibleQuoteBibleImporter().Import(folder);
			}
			catch (Exception exception)
			{
				MessageBox.Show(this, exception.Message, AppGlobal.AppName, MessageBoxButtons.OK);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			statLblDebug.Text = NetInterface.MAC();

		}
	}
}
