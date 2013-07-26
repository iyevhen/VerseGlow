using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
    public partial class BibleView : UserControl
    {
        private BibleBook bibleBook;
        private IBible currentBible;

        public BibleView()
        {
            InitializeComponent();
        }

        public IBible CurrentBible
        {
            get { return currentBible; }
            set
            {
                currentBible = value;
                Enabled = value != null;

                cmbContents.Items.Clear();

                if (currentBible != null)
                {
                    foreach (BibleBook book in currentBible.OpenBooks())
                    {
                        cmbContents.Items.Add(book);
                    }
                    cmbContents.SelectedIndex = 0;
                }
            }
        }

        public void Highlight(string text)
        {
            verseView1.HighlightText = text;
        }

        private void cmbContents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentBible == null)
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
            if (currentBible == null || bibleBook == null)
            {
                return;
            }

            List<BibleVerse> verses = currentBible.OpenChapter(bibleBook, (cmbChapters.SelectedIndex + 1).ToString());
            verseView1.Fill(verses.ConvertAll(v => v.Text));
        }

        public void FindVerses(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                throw new ArgumentNullException("txt");

            if (currentBible == null)
                return;

            List<BibleVerse> verses = currentBible.OpenVerses(txt);
            verseView1.Fill(verses.ConvertAll(v => v.Text));
            verseView1.HighlightText = txt;
        }
    }
}
