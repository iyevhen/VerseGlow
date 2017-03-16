using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

using VerseGlow.Common;
using VerseGlow.Core;
using VerseGlow.Core.Import;
using VerseGlow.Core.Import.BibleQuote;

namespace VerseGlow.UI
{
	public partial class FrmImportBibleQuote : Form
	{
		private readonly string bqtini;
		private IBible importedBible;

		public FrmImportBibleQuote(string bqtini)
		{
			Is.NotNullOrEmpty(bqtini, "bqtini");

			InitializeComponent();

			this.bqtini = bqtini;
		}

		public IBible ImportedBible
		{
			get { return importedBible; }
		}

		private void ImportBibleQuote_Load(object sender, EventArgs e)
		{
			EncodingInfo[] infos = Encoding.GetEncodings();
			
			Array.Sort(infos, (e1, e2) => e1.DisplayName.CompareTo(e2.DisplayName));
			cmbEnc.DataSource = infos;
			cmbEnc.DisplayMember = "DisplayName";
			cmbEnc.Enabled = !cboxUtf8.Checked;
			Preview();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				IBibleImportAdapter adapter = new BqtBibleAdapter(bqtini, GetEncoding());
				
				using (IBibleWriter bibleWriter = Options.BibleRepository.New())
					importedBible = bibleWriter.Write(adapter);

				DialogResult = DialogResult.OK;
			}
			catch (Exception exception)
			{
				MessageBox.Show(this, exception.Message, Options.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private Encoding GetEncoding()
		{
			return cboxUtf8.Checked || cmbEnc.SelectedItem == null
					   ? Encoding.UTF8
					   : ((EncodingInfo)cmbEnc.SelectedItem).GetEncoding();
		}
	
		private void Preview()
		{
			txtPreview.Text = File.ReadAllText(bqtini, GetEncoding());
		}

		private void cboxDefault_CheckedChanged(object sender, EventArgs e)
		{
			cmbEnc.Enabled = !cboxUtf8.Checked;
			Preview();
		}

		private void cmbEnc_SelectedIndexChanged(object sender, EventArgs e)
		{
			Preview();
		}
	}
}
