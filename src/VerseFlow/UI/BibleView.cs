using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI
{
	public partial class BibleView : UserControl
	{
		private BibleBook bibleBook;
		private Bible currentBible;

		public BibleView()
		{
			InitializeComponent();
		}

		public Bible CurrentBible
		{
			get { return currentBible; }
			set
			{
				currentBible = value;

				cmbContents.Items.Clear();

				if (currentBible != null)
				{

					foreach (BibleBook book in currentBible.ReadBooks())
					{
						cmbContents.Items.Add(book);
					}
					cmbContents.SelectedIndex = 0;
				}
			}
		}

		private void cmbContents_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CurrentBible == null)
			{
				return;
			}

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
			if (CurrentBible == null || bibleBook == null)
			{
				return;
			}

			List<BibleVerse> verses = CurrentBible.ReadChapter(bibleBook, cmbChapters.SelectedIndex + 1);
			verseView1.Fill(verses.ConvertAll(v => v.Text));
		}
	}
}
