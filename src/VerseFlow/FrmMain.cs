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
			var strings = new List<string>();


			int count = 300;

			for (int i = 0; i < count; i++)
			{
				strings.Add(i + "   " + "In this case, FocusPoint is a PointF structure that holds the coordinates in the bitmap which the user is focused on (for example, when they mouse wheel to zoom in they are focusing on the current mouse location at that time). This functionality works for the most part.");
			}


			Stopwatch sw = Stopwatch.StartNew();
			verseView1.Populate(strings);
			sw.Stop();
//			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString("h'h 'm'm 's's' 'fff"));
			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString());
//			("mm':'ss':'fff");
//			label1.Text = string.Format("Populated {0} verses in {1}", count, sw.Elapsed.ToString("hh:mm:ss.fffffff"));
		}
 	}
}
