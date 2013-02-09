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
			lblOpened.Text = "";
			toolsLeftNavigation.Visible = false;
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

		private void tsOpen_DropDownOpening(object sender, EventArgs e)
		{
			if (!openLoaded)
			{
				foreach (Bible bible in AppGlobal.Bibles())
				{
					tsOpen.DropDownItems.Add(new ToolStripMenuItem(bible.FullName) { Tag = bible });
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
				lblOpened.Text = bible.FullName;

				if (!toolsLeftNavigation.Visible)
					toolsLeftNavigation.Visible = true;

				cmbContents.Items.Clear();

				foreach (BibleBook book in bible.ReadBooks())
				{
					cmbContents.Items.Add(book);
				}

				cmbContents.SelectedIndex = 0;
			}
		}

		private void cmbContents_SelectedIndexChanged(object sender, EventArgs e)
		{
			bibleBook = cmbContents.SelectedItem as BibleBook;

			if (bibleBook == null)
			{
				return;
			}

			cmbChapters.Items.Clear();

			for (int i = 1; i <= bibleBook.ChaptersCount; i++)
			{
				cmbChapters.Items.Add(i);
			}

			cmbChapters.SelectedIndex = 0;
		}

		private void cmbChapters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bible == null || bibleBook == null)
			{
				return;
			}

			List<BibleVerse> verses = bible.ReadChapter(bibleBook, cmbChapters.SelectedIndex + 1);
			verseView1.Fill(verses.ConvertAll(v => v.Text));
		}

		private void tsFont_Click(object sender, EventArgs e)
		{
			using (var fd = new FontDialog())
			{
				fd.Font = verseView1.Font;

				if (DialogResult.OK == fd.ShowDialog(this))
				{
					verseView1.Font = fd.Font;
				}
			}
		}

		private void bibleFromBibleQuoteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var f = new FrmImportBibleQuote { Icon = Icon })
			{
				f.ShowDialog(this);
				openLoaded = false;
			}
		}

		private void tsColor_Click(object sender, EventArgs e)
		{
			using (var cd = new ColorDialog())
			{
				cd.Color = verseView1.BackColor;

				if (DialogResult.OK == cd.ShowDialog(this))
				{
					verseView1.BackColor = cd.Color;
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
	}
}
