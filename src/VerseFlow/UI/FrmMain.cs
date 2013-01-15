﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private static readonly Random random = new Random((int)DateTime.Now.Ticks); //thanks to McAden
		private static readonly string[] delimiters = new[] { " ", "- ", "\t", ": ", "; ", ", ", ". ", " «", "» " };
		private static long delim;
		private IDisplay display;
		private bool biblesLoaded;

		public FrmMain()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			delim = 0;
			var strings = new List<string>();


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

			Populate(strings);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Populate(new List<string>
			{ 
				"Ελληνική Καινή Διαθήκη δωρεαν ελάβετε, δωρεαν δότε", 
				"新約全書", 
				"«алдыњда кубанычка бљлљйсєњ турасыњар Силердин жаныњардан асманга кљтљрєлєп кеткен бул Ыйса, љзєњљр кљргљндљй, асманга кандай кљтљрєлєп кетсе, ошондой эле кайра келет»",
				"Покај се, дакле! Ако ли не, доћи ћу ти скоро и војеваћу с њима мачем уста својих.",
				"אבגדהוזחטיכךלמםנןסעפףצץקרשת",
				"ԱՍՏՈՒԱԾԱՇՈՒՆՉ"
			});
		}

		private void Populate(List<string> strings)
		{
			verseView1.Fill(strings);
		}

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

		private void tsSettings_Click(object sender, EventArgs e)
		{
			using (var fb = new FrmSettings())
			{
				fb.Icon = Icon;
				fb.ShowDialog(this);
			}
		}

		private void tsBibles_DropDownOpening(object sender, EventArgs e)
		{
			if (!biblesLoaded)
			{
				foreach (Bible bible in AppGlobal.Bibles())
				{
					var item = new ToolStripMenuItem(bible.FullName) { Tag = bible };
					item.Click += Bible_Click;

					tsBibles.DropDownItems.Add(item);
				}

				biblesLoaded = true;
			}
		}

		void Bible_Click(object sender, EventArgs e)
		{
			var item = sender as ToolStripMenuItem;

			if (item != null && item.Tag != null)
			{
				var bible = (Bible)item.Tag;
				Populate(bible.ReadAllVerses());
//								Populate(bible.ReadBookNames());
			}
		}
	}
}
