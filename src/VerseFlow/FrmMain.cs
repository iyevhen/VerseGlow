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
			var strings = new List<string>();


			int count = 10;

			for (int i = 0; i < count; i++)
			{
				strings.Add(string.Format("{0}{1}", i, RandomString(random.Next(2, 300))));
			}


			Stopwatch sw = Stopwatch.StartNew();
			verseView1.Populate(strings);
			sw.Stop();
			//			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString("h'h 'm'm 's's' 'fff"));
			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString());
			//			("mm':'ss':'fff");
			//			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString("hh:mm:ss.fffffff"));
		}

		private static readonly Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden

		private string RandomString(int size)
		{
			var builder = new StringBuilder();
			for (int i = 0; i < size; i++)
			{
				char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);

				if ((i % random.Next(1, 20)) == 0)
				{
					builder.Append(' ');
				}
			}

			return builder.ToString();
		}
	}
}
