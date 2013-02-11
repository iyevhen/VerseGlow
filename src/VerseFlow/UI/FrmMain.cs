using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private IDisplay display;
		private bool openLoaded;
		private Bible bible;
		private BibleBook bibleBook;

		public FrmMain()
		{
			InitializeComponent();

			toolsLeftNavigation.Visible = false;
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			Font = System.Drawing.SystemFonts.MessageBoxFont;
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

		private void tsOpen_DropDownOpening(object sender, EventArgs e)
		{
			if (!openLoaded)
			{
				foreach (Bible bib in AppGlobal.Bibles())
				{
					miOpen.DropDownItems.Add(new ToolStripMenuItem(bib.FullName) { Tag = bib });
				}

				openLoaded = true;
			}
		}

		private void tsOpen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var item = e.ClickedItem;

			if (item != null && item.Tag != null)
			{
				bible = (Bible)item.Tag;

				tsFullName.Text = bible.FullName;

				if (!toolsLeftNavigation.Visible)
				{
					toolsLeftNavigation.Visible = true;
					bibleView1.Visible = true;
				}

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
	}
}
