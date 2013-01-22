using System;
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
