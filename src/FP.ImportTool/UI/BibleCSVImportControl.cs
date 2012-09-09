using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FreePresenter.Convertion;
using FreePresenter.Core;

namespace FreePresenter.UI.ImportTool
{
	public partial class BibleCSVImportControl : UserControl
	{
		private char separator;

		public BibleCSVImportControl()
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

			comboBoxSeparator.Items.Add(@"\t");
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

		private void EnableBtnConvert_Handler(object sender, EventArgs e)
		{
			btnImport.Enabled = File.Exists(txtBoxInputFile.Text);

			if (!btnImport.Enabled)
				return;

			bool isTab = comboBoxSeparator.Text == @"\t";

			if (isTab)
			{
				btnImport.Enabled = true;
				separator = '\t';
				return;
			}

			if (comboBoxSeparator.Text.ToCharArray().Length == 1)
			{
				separator = comboBoxSeparator.Text.ToCharArray()[0];
				btnImport.Enabled = true;
			}
			else
			{
				btnImport.Enabled = false;
			}
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			btnImport.Enabled = false;
			btnSelectFile.Enabled = false;

			Encoding fromEncoding = ((EncodingInfo)comboBoxEncoding.SelectedItem).GetEncoding();

			string inputFilePath = txtBoxInputFile.Text;

			try
			{
				var flatConverter = IoC.Resolve<ObjectConverter<Bible, FlatFile<FlatBibleLine>>>();
				var flatFile = new FlatFile<FlatBibleLine>(inputFilePath, fromEncoding, separator);

				var bible = flatConverter.Convert(flatFile);
				bible.CodePage = fromEncoding.CodePage;
				bible.Description = txtBoxDescription.Text;

				string outputFilePath = Path.Combine("Content", bible.Text + ".xml");

				new XmlFile<Bible>(outputFilePath).Write(bible);

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
	}
}