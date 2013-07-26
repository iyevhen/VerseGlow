using System;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private IDisplay display;
		private bool openLoaded;
		private IBible bible;
		private string appNameAndVersion;

		public FrmMain()
		{
			InitializeComponent();

		    KeyPreview = true;
		}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


		private void FrmMain_Load(object sender, EventArgs e)
		{
			appNameAndVersion = string.Format("{0} - v{1}", Options.AppName, Options.AppVersion.ToString(3));
			Text = appNameAndVersion;
		}

		private void tsAbout_Click(object sender, EventArgs e)
		{
			using (var f = new FrmAbout())
			{
				f.Icon = Icon;
				f.Text = Options.AppName;
				f.ShowDialog(this);
			}
		}

		private void tsOpen_DropDownOpening(object sender, EventArgs e)
		{
			if (!openLoaded)
			{
				openToolStripMenuItem.DropDownItems.Clear();

				foreach (IBible b in Options.BibleRepository.OpenAll())
				{
                    openToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(b.Name()) { Tag = b });
				}

				openLoaded = true;
			}
		}

		private void tsOpen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var item = e.ClickedItem;

			if (item != null && item.Tag != null)
			{
				bible = (IBible)item.Tag;

				Text = string.Format("{0} - {1}", appNameAndVersion, item.Text);

				bibleView1.CurrentBible = bible;
			}
		}

		private void tsFont_Click(object sender, EventArgs e)
		{
			using (var fd = new FontDialog())
			{
				fd.Font = bibleView1.Font;

				if (DialogResult.OK == fd.ShowDialog(this))
				{
					bibleView1.Font = fd.Font;
				}
			}
		}

		private void bibleFromBibleQuoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var f = new FrmImportBibleQuote { Icon = Icon })
			{
				f.Font = Font;
				f.ShowDialog(this);
				openLoaded = false;
			}
		}

		private void tsGoLive_Click(object sender, EventArgs e)
		{
			if (tsGoLive.Checked)
			{
				display = new FrmDisplay { Icon = Icon };
				display.Activate();
			}
			else
			{
				if (display != null)
				{
					display.Deactivate();
					((Form)display).Dispose();
				}

				tsBlack.Checked = false;
				tsFreeze.Checked = false;
			}
		}

		private void tsHighlight_Click(object sender, EventArgs e)
		{
//			bibleView1.Highlight(txtHighlight.Text);
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("find");
		}

        private void tsSearch_Click(object sender, EventArgs e)
        {
//            bibleView1.FindVerses(txtHighlight.Text);
        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

	    private void toolStripButton4_Click(object sender, EventArgs e)
        {
//            splitContainerLeft.Panel1Collapsed = !tsFind.Checked;
        }

        private void managedPanel1_Click(object sender, EventArgs e)
        {

        }

        private void tabList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
