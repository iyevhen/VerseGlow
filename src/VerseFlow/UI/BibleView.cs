using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.Core;
using VerseFlow.Properties;

namespace VerseFlow.UI
{
	public partial class BibleView : UserControl
	{
		private IBible bible;
		private Dictionary<string, BibleBook> bookMap;
		private int comboIndexText;

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

				if (bible != null)
				{
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
							bookMap[book.Name] = book;
							cmbNavigate.Items.Add(book.Name);

							foreach (string shortcut in book.Shortcuts)
								bookMap[shortcut] = book;
						}

						var random = new Random();
						int bookIdx = random.Next(0, books.Count - 1);
						cmbNavigate.SetCue(string.Format("Sample: {0} {1}:1", books[bookIdx].Name, random.Next(1, books[bookIdx].ChaptersCount)));
					}
					finally
					{
						cmbNavigate.EndUpdate();
					}

				}
			}
		}


		private void cmbNavigate_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string searchText = cmbNavigate.Text.Trim();

				string[] args = searchText
					.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

				BibleBook book = null;
				int chapter = 0;
				int verse = 0;

				if (args.Length > 0)
				{
					book = bookMap.Find(args[0]);

					if (args.Length > 1)
						chapter = args[1].TryGetInt32();

					if (args.Length > 2)
						verse = args[2].TryGetInt32();
				}

				List<BibleVerse> verses;

				if (book == null)
				{
					verses = searchText.Length == 0
						? new List<BibleVerse>()
						: bible.FindVerses(searchText);

					verseView.Fill(verses.ConvertAll(v => v.Text));
					verseView.HighlightText = searchText;
				}
				else
				{
					verses = bible.OpenChapter(book, chapter == 0 ? "1" : chapter.ToString());
					verseView.Fill(verses.ConvertAll(v => v.Text));

					if (verse > 0)
						verseView.SelectItem(verse);
				}

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

			combo.Select(combo.Text.Length, 0);
//			combo.SelectedText = combo.Text;
//			{
//				combo.Text = comboIndexText;
////				combo.Select(comboIndexText.Length, 0);
//				comboIndexText = null;
//				return;
//			}

//			comboIndexText = combo.SelectedIndex;
//			combo.SelectedIndex = -1;
//			combo.SelectedItem = null;
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

		private void cmbNavigate_TextChanged(object sender, EventArgs e)
		{
			var combo = sender as ComboBox;

			if (combo == null)
				return;


			Debug.WriteLine(combo.Text);
		}
		
	}

	public static class Extensions
	{
		public static TValue Find<TKey, TValue>(this Dictionary<TKey, TValue> target, TKey key)
		{
			TValue value;
			return target.TryGetValue(key, out value) ? value : default(TValue);
		}

		public static Int32 TryGetInt32(this string text)
		{
			Int32 number;
			return Int32.TryParse(text, out number) ? number : 0;
		}
	}

}