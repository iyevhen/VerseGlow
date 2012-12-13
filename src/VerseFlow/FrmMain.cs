using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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

		private void decreaseFontToolStripMenuItem_Click(object sender, System.EventArgs e)
		{

		}

		private void panelVerses_MouseHover(object sender, System.EventArgs e)
		{
		}

		private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			delim = 0;

			int count;
			if (!int.TryParse(textBox1.Text, out count))
				textBox1.Text = "NOT VALID VALUE";

			int maxVerse;
			if (!int.TryParse(textBox2.Text, out maxVerse))
				textBox1.Text = "NOT VALID VALUE";

			var strings = new List<string>();
			long totalCharacters = 0;

			for (int i = 0; i < count; i++)
			{
				string randomString = RandomString(random.Next(2, maxVerse));
				totalCharacters += randomString.Length;
				strings.Add(string.Format("{0}_{1}", i, randomString));
			}

			Populate(strings, totalCharacters);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Populate(new List<string>());
		}

		private void Populate(List<string> strings, long total = 0)
		{
			verseView1.Populate(strings);
			label1.Text = string.Format("Total Strings={0}, Chars={1}", strings.Count.ToString("N0"), total.ToString("N0"));
		}

		private static readonly Random random = new Random((int)DateTime.Now.Ticks); //thanks to McAden
		private static readonly string[] delimiters = new[] { " ", "\r\n", "- ", "\t", ": ", "; ", ", ", ". " };
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
