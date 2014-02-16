using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private IDisplay display;
		private IBible bible;
		private string appNameAndVersion;
		private HashSet<string> opened;

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

			opened = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
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

				if (opened.Contains(bible.Name))
				{

					//					tabControl.SelectedTab = tabControl.TabPages[bible.Name];
				}
				else
				{
					tableLayoutTop.SuspendLayout();
					
					tableLayoutTop.ColumnCount += 1;

					int idx = tableLayoutTop.Controls.Count > 0
						? tableLayoutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f))
						: 0;

					var bibleView = new BibleView();
					tableLayoutTop.Controls.Add(bibleView, idx, 0);

					bibleView.Anchor =
						AnchorStyles.Bottom |
						AnchorStyles.Left |
						AnchorStyles.Top |
						AnchorStyles.Right;

					bibleView.Bible = bible;

					tableLayoutTop.ResumeLayout();
				}
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

		private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
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

		private void tabControl_MouseClick(object sender, MouseEventArgs e)
		{
			var tabcon = sender as TabControl;

			if (tabcon == null)
				return;

			TabPage page = null;
			if (e.Button == MouseButtons.Middle)
			{
				for (var i = 0; i < tabcon.TabCount; i++)
				{
					if (!tabcon.GetTabRect(i).Contains(e.Location))
						continue;
					page = tabcon.TabPages[i];
					break;
				}

				if (page != null)
					tabcon.TabPages.Remove(page);
			}
		}


	}
}
