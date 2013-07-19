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
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			Font = System.Drawing.SystemFonts.MessageBoxFont;
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
				miOpen.DropDownItems.Clear();

				foreach (IBible b in Options.BibleRepository.OpenAll())
				{
					miOpen.DropDownItems.Add(new ToolStripMenuItem(b.Name()) { Tag = b });
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

		private void tsHighlight_Click(object sender, EventArgs e)
		{
			bibleView1.Highlight(txtHighlight.Text);
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("find");
		}

        private void tsSearch_Click(object sender, EventArgs e)
        {
            bibleView1.FindVerses(txtHighlight.Text);

        }
	}
}
