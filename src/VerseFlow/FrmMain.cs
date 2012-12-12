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
			Stopwatch sw = Stopwatch.StartNew();
			verseView1.Populate(strings);
			sw.Stop();
			label1.Text = string.Format("In={0}; Chars={1}", sw.Elapsed.ToString(), total);
		}

		private static readonly Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden

		private string RandomString(int size)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < size; i++)
			{
				char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);

				if ((i % random.Next(1, 30)) == 0)
				{
					builder.Append(' ');
				}
			}
			builder.Append('.');

			return builder.ToString();
		}
	}
}
