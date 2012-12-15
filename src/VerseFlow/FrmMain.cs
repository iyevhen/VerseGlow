using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Controls.VerseRect;

namespace VerseFlow
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
			long totalCharacters = 0;

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
							totalCharacters += line.Length;
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
					totalCharacters += randomString.Length;
					strings.Add(string.Format("{0}_{1}", i, randomString));
				}
			}

			Populate(strings, totalCharacters);

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Populate(new List<string>
			{ 
				"Ελληνική Καινή Διαθήκη", 
				"新約全書", 
				"«алдыњда кубанычка бљлљйсєњ турасыњар Силердин жаныњардан асманга кљтљрєлєп кеткен бул Ыйса, љзєњљр кљргљндљй, асманга кандай кљтљрєлєп кетсе, ошондой эле кайра келет»",
				"Покај се, дакле! Ако ли не, доћи ћу ти скоро и војеваћу с њима мачем уста својих.",
				"בְּרֵאשִׁית  7225 בָּרָא  1254 אֱלֹהִים  430 אֵת  853 הַשָּׁמַיִם  8064 וְאֵת  853 הָאָרֶץ  776 "
			});
		}

		private void Populate(List<string> strings, long total = 0)
		{
			verseView1.Populate(strings);
		}

		private static readonly Random random = new Random((int)DateTime.Now.Ticks); //thanks to McAden
		private static readonly string[] delimiters = new[] { " ", "\r\n", "- ", "\t", ": ", "; ", ", ", ". ", " «", "» " };
		private static long delim = 0;

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
	}
}
