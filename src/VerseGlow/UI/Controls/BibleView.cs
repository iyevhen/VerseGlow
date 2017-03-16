using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using VerseGlow.Common;
using VerseGlow.Core;
using VerseGlow.Properties;

namespace VerseGlow.UI.Controls
{
	public partial class BibleView : UserControl
	{
		private IBible bible;
		private Dictionary<string, BibleBook> bookMap;
		public event EventHandler CloseRequested;
		public event Action<BibleVerse> SelectedVerseChanged;

		public BibleView()
		{
			InitializeComponent();

			cmbNavigate.SetCue("Type search text and press Enter...");
			verseView.SelectedVerseChanged += verseView_SelectedVerseChanged;
		}

		void verseView_SelectedVerseChanged(BibleVerse obj)
		{
			Action<BibleVerse> handler = SelectedVerseChanged;

			if (handler != null)
				handler(obj);
		}

		public IBible Bible
		{
			get { return bible; }
			set
			{
				bible = value;

				if (bible != null)
				{
					lblTitle.Text = bible.Name;

					bookMap = new Dictionary<string, BibleBook>(StringComparer.CurrentCultureIgnoreCase);
					List<BibleBook> books = bible.OpenBooks();

					cmbNavigate.BeginUpdate();

					try
					{
						cmbNavigate.Items.Clear();

						if (books.Count == 0)
							return;

						foreach (BibleBook book in books)
						{
							var trimmed = new StringBuilder();
							foreach (char c in book.Name)
							{
								if (Char.IsNumber(c) && trimmed.Length > 0)
									break;

								if (c != ' ')
									trimmed.Append(c);
							}

							bookMap[book.Name] = book;
							bookMap[trimmed.ToString()] = book;
							
							cmbNavigate.Items.Add(book.Name);

							foreach (string shortcut in book.Shortcuts)
								bookMap[shortcut] = book;
						}
					}
					finally
					{
						cmbNavigate.EndUpdate();
					}

					cmbNavigate.SelectedIndex = 0;
				}
				else
				{
					DisableAll();
				}
			}
		}

		private void DisableAll()
		{
			tblCombos.Enabled = false;
			verseView.Enabled = false;

			tsFont.Enabled = false;
			tsLblChapter.Enabled = false;
			btnClose.Enabled = false;
		}

		protected virtual void OnCloseRequested()
		{
			EventHandler handler = CloseRequested;

			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		private void cmbNavigate_KeyDown(object sender, KeyEventArgs e)
		{
			var combo = sender as ComboBox;

			if (combo == null)
				return;

			if (e.KeyCode == Keys.Enter)
			{
				GoTo(combo.Text.Trim());

				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void cmbNavigate_SelectedIndexChanged(object sender, EventArgs e)
		{
			var combo = sender as ComboBox;

			if (combo == null)
				return;

			if (combo.SelectedIndex == -1)
				return;

			combo.Text += " 1";

			GoTo(combo.Text.Trim());
		}

		private void GoTo(string searchfor)
		{
			bool startsExclamation = searchfor.Length > 0 && searchfor[0] == '!';
			verseView.HighlightText = null;

			if (!startsExclamation)
			{
				var trim = new StringBuilder();
				int i = 0;
				for (; i < searchfor.Length; i++)
				{
					char c = searchfor[i];

					if (Char.IsNumber(c) && trim.Length > 0)
						break;

					if (c != ' ')
						trim.Append(c);
				}

				BibleBook book = bookMap.Find(trim.ToString());

				if (book != null)
				{
					tsBook.Text = book.Name;

					string[] args = searchfor
						.Substring(i)
						.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

					int chapter = 0;
					int verse = 0;

					if (args.Length > 0)
					{
						chapter = args[0].TryGetInt32();

						if (args.Length > 1)
							verse = args[1].TryGetInt32();
					}

					string chap = chapter == 0
						? "1"
						: chapter.ToString(CultureInfo.InvariantCulture);

					var opened = bible.OpenChapter(book, chap);
					verseView.Fill(opened.ConvertAll(v => new VerseItem(v)));

					tsLblChapter.Text = chap;
					verseView.SelectedIndex(verse - 1);

					return;
				}
			}

			if (startsExclamation)
				searchfor = searchfor.TrimStart('!');

			List<BibleVerse> found = searchfor.Length == 0
				? new List<BibleVerse>()
				: bible.FindVerses(searchfor);

			verseView.Fill(found.ConvertAll(v => new VerseItem(v)));
			verseView.HighlightText = searchfor;
			tsLblChapter.Text = string.Format("Found {0} verses", found.Count);
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
					Settings.Default.Save();
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

//		private void cmbChapter_TextChanged(object sender, EventArgs e)
//		{
//			var combo = sender as ComboBox;
//
//			if (combo == null)
//				return;
//
//			int chap = combo.Text.TryGetInt32();
//
//			if (chap == 0)
//			{
//				//				tsPrev.Enabled = false;
//				//				tsNext.Enabled = false;
//			}
//			else
//			{
//				//				tsPrev.Enabled = true;
//				//				tsNext.Enabled = true;
//			}
//		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			OnCloseRequested();
		}

		private void tsFind_Click(object sender, EventArgs e)
		{
			cmbNavigate.Visible = tsFind.Checked;
		}
	}
}