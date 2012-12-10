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
			string longstring = string.Empty;


			for (int i = 0; i < 200; i++)
			{
				longstring += textView1.TextString + "\r\n\r\n";
			}


			Stopwatch sw = Stopwatch.StartNew();
			textView1.TextString = longstring;
			sw.Stop();
			label1.Text = sw.Elapsed.ToString();
		}
	}
}
