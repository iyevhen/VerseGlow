using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FreePresenter.Convertion;
using FreePresenter.Core;

namespace FreePresenter.UI.ImportTool
{
	public partial class SongCSVImportControl : UserControl
	{
		public SongCSVImportControl()
		{
			InitializeComponent();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			EncodingInfo[] encodingInfos = Encoding.GetEncodings();
			Array.Sort(encodingInfos, (e1, e2) => e1.DisplayName.CompareTo(e2.DisplayName));

			comboBoxEncoding.DataSource = encodingInfos;
			comboBoxEncoding.DisplayMember = "DisplayName";
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			btnImport.Enabled = false;
			btnSelectFile.Enabled = false;

			Encoding fromEncoding = ((EncodingInfo)comboBoxEncoding.SelectedItem).GetEncoding();

			string inputFilePath = txtBoxInputFile.Text;

			try
			{
				var book = new Book(Path.GetFileNameWithoutExtension(inputFilePath));

				using (var reader = new StreamReader(inputFilePath, fromEncoding))
				{
					Song song = null;
					int verseNumber = 0;
					int songNumbers = 0;

					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();

						if (string.IsNullOrEmpty(line))
							continue;

						int songNumber;
						string trim = line.Trim();

						if (int.TryParse(trim, out songNumber))
						{
							if (song != null)
							{
								book.Add(song);
							}

							song = new Song(++songNumbers, reader.ReadLine());
							verseNumber = 0;
						}
						else if (song != null)
						{
							song.Add(new Verse(++verseNumber, trim));
						}
					}
				}


				string outputFilePath = Path.Combine("Content", book.Text + ".xml");

				new XmlFile<Book>(outputFilePath).Write(book);

			}
			catch (FreePresenterException exception)
			{
				MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				btnSelectFile.Enabled = true;
				btnImport.Enabled = true;
			}

			MessageBox.Show(string.Format("File [{0}] was converted successfully!", inputFilePath), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnSelectFile_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				if (DialogResult.OK == ofd.ShowDialog(this))
				{
					txtBoxInputFile.Text = ofd.FileName;
				}
			}
		}

		private void EnableImport_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnImport.Enabled = File.Exists(txtBoxInputFile.Text);
		}
	}
}
