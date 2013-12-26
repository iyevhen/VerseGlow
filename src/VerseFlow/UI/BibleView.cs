using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	public partial class BibleView : UserControl
	{
		private BibleBook book;
		private IBible bible;

		public BibleView()
		{
			InitializeComponent();

			pnlReadTop.Enabled = false;
			pnlFindTop.Enabled = false;
		}

		public IBible Bible
		{
			get { return bible; }
			set
			{
				bible = value;

				Enabled = value != null;
				pnlReadTop.Enabled = Enabled;
				pnlFindTop.Enabled = Enabled;

				cmbBooks.Items.Clear();

				if (bible != null)
				{
					foreach (BibleBook bb in bible.OpenBooks())
						cmbBooks.Items.Add(bb);

					cmbBooks.SelectedIndex = 0;
				}
			}
		}

		private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bible == null)
				return;

			book = cmbBooks.SelectedItem as BibleBook;

			if (book == null)
				return;

			cmbChapters.Items.Clear();

			for (int i = 1; i <= book.ChaptersCount; i++)
				cmbChapters.Items.Add(i);

			cmbChapters.SelectedIndex = 0;
		}

		private void SetNextPrevious(int chapter)
		{
			btnPrevious.Enabled = chapter > 1;
			btnNext.Enabled = chapter < book.ChaptersCount;
		}

		private void cmbChapters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bible == null || book == null)
				return;

			int chapter = cmbChapters.SelectedIndex + 1;
			List<BibleVerse> verses = bible.OpenChapter(book, chapter.ToString(CultureInfo.InvariantCulture));
			verseViewRead.Fill(verses.ConvertAll(v => v.Text));
			SetNextPrevious(chapter);
		}

		private void tsFont_Click(object sender, EventArgs e)
		{
			using (var fd = new FontDialog())
			{
				fd.Font = verseViewRead.Font;

				Form parent = FindForm();

				if (parent != null)
				{
					fd.FontMustExist = true;
					fd.AllowVerticalFonts = false;
					fd.ShowColor = false;
					fd.ShowEffects = false;

					if (DialogResult.OK == fd.ShowDialog(parent))
					{
						verseViewRead.Font = fd.Font;
						verseViewFind.Font = fd.Font;

						Properties.Settings.Default.Save();
					}
				}
			}
		}

		private void tsFind_Click(object sender, EventArgs e)
		{
			if (tsFind.Checked)
			{
				tsRead.Checked = false;
				SuspendLayout();
				pnlRead.Visible = false;
				pnlFind.Visible = true;
				ResumeLayout();
			}
		}

		private void tsColors_Click(object sender, EventArgs e)
		{
			using (var frm = new FrmBibleViewColors())
			{
				Form parent = FindForm();

				if (parent != null)
				{
					frm.Icon = parent.Icon;
					frm.ShowDialog(parent);
				}
			}
		}

		private void tsRead_CheckedChanged(object sender, EventArgs e)
		{
			if (tsRead.Checked)
			{
				tsFind.Checked = false;
				SuspendLayout();
				pnlRead.Visible = true;
				pnlFind.Visible = false;
				ResumeLayout();
			}
		}

		private void tsRead_Click(object sender, EventArgs e)
		{
			if (!tsRead.Checked)
				tsRead.Checked = true;
		}

		private void cmbFind_TextChanged(object sender, EventArgs e)
		{
			btnFind.Enabled = !string.IsNullOrEmpty(cmbFind.Text);
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			if (bible == null)
				return;

			List<BibleVerse> verses = bible.OpenVerses(cmbFind.Text);
			verseViewFind.Fill(verses.ConvertAll(v => v.Text));
			verseViewFind.HighlightText = cmbFind.Text;
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			cmbChapters.SelectedIndex += 1;
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			cmbChapters.SelectedIndex -= 1;
		}


	}
}
