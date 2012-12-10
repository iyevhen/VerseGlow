using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
			var values = new List<string>();


			for (int i = 0; i < 200; i++)
			{
				string s = i.ToString(CultureInfo.InvariantCulture);
				string res = string.Empty;

				for (int j = 0; j < 50; j++)
				{
					res += s + " ";
				}
				values.Add(res);
			}


			Stopwatch sw = Stopwatch.StartNew();
			panelVerses.SuspendLayout();
			panelVerses.Controls.Clear();

			foreach (var value in values)
			{
				var verseRect = new VerseRect { Text = value, Dock = DockStyle.Top, Parent = panelVerses };
				panelVerses.Controls.Add(verseRect);
			}
			panelVerses.ResumeLayout();
			sw.Stop();
			label1.Text = sw.Elapsed.ToString();
		}
	}
}
