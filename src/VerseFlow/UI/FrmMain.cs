using System;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private IDisplay display;
		private IBible bible;
		private string appNameAndVersion;

		public FrmMain()
		{
			InitializeComponent();
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

			foreach (IBible b in Options.BibleRepository.OpenAll())
				tsBibles.DropDownItems.Add(new ToolStripMenuItem(b.Name) { Tag = b });
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

		private void tsBibles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var item = e.ClickedItem;

			if (item != null && item.Tag != null)
			{
				bible = (IBible)item.Tag;

				Text = string.Format("{0} - {1}", appNameAndVersion, item.Text);

				if (tabControl1.TabPages.ContainsKey(bible.Name))
				{
					tabControl1.SelectedTab = tabControl1.TabPages[bible.Name];
				}
				else
				{
					var bibleView = new BibleView();
					tabControl1.SuspendLayout();
					tabControl1.TabPages.Insert(0, bible.Name, bible.Name);
					TabPage page = tabControl1.TabPages[0];
					page.SuspendLayout();
					page.Controls.Add(bibleView);
					bibleView.Dock = DockStyle.Fill;
					bibleView.CurrentBible = bible;
					page.ResumeLayout(false);

					tabControl1.SelectedTab = page;
					tabControl1.ResumeLayout(false);
				}

			}
		}

		//		private void tsFont_Click(object sender, EventArgs e)
		//		{
		//			using (var fd = new FontDialog())
		//			{
		//				fd.Font = bibleView1.Font;
		//
		//				if (DialogResult.OK == fd.ShowDialog(this))
		//				{
		//					bibleView1.Font = fd.Font;
		//				}
		//			}
		//		}



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

		private void miBibleQuote_Click(object sender, EventArgs e)
		{
			using (var f = new FrmImportBibleQuote { Icon = Icon })
			{
				if (DialogResult.OK == f.ShowDialog(this))
				{
					IBible imported = f.ImportedBible;

					if (imported != null)
						tsBibles.DropDownItems.Add(new ToolStripMenuItem(imported.Name) { Tag = imported });
				}
			}
		}

		private void tabControl1_MouseClick(object sender, MouseEventArgs e)
		{
			var tabControl = sender as TabControl;

			if (tabControl == null)
				return;

			TabPage tabPageCurrent = null;
			if (e.Button == MouseButtons.Middle)
			{
				for (var i = 0; i < tabControl.TabCount; i++)
				{
					if (!tabControl.GetTabRect(i).Contains(e.Location))
						continue;
					tabPageCurrent = tabControl.TabPages[i];
					break;
				}
				if (tabPageCurrent != null)
					tabControl.TabPages.Remove(tabPageCurrent);
			}
		}
	}
}
