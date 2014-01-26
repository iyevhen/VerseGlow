using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	//http://stackoverflow.com/questions/11780558/c-sharp-winforms-combobox-dynamic-autocomplete
	public partial class BibleView : UserControl
	{
		private BibleBook book;
		private IBible bible;

		public BibleView()
		{
			InitializeComponent();
		}

		public IBible Bible
		{
			get { return bible; }
			set
			{
				bible = value;

				Enabled = value != null;

				cmbNavigate.Items.Clear();

				if (bible != null)
				{
					foreach (BibleBook bb in bible.OpenBooks())
						cmbNavigate.Items.Add(bb);

					cmbNavigate.SelectedIndex = 0;
				}
			}
		}

		private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bible == null)
				return;

			book = cmbNavigate.SelectedItem as BibleBook;

			if (book == null)
				return;

			List<BibleVerse> verses = bible.OpenChapter(book, "1");
			verseView.Fill(verses.ConvertAll(v => v.Text));
		}


		private void tsFont_Click(object sender, EventArgs e)
		{
			using (var fd = new FontDialog())
			{
				fd.Font = verseView.Font;

				Form parent = FindForm();

				if (parent == null)
					return;

				fd.FontMustExist = true;
				fd.AllowVerticalFonts = false;
				fd.ShowColor = false;
				fd.ShowEffects = false;

				if (DialogResult.OK == fd.ShowDialog(parent))
				{
					verseView.Font = fd.Font;
					Properties.Settings.Default.Save();
				}
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
	}
}
