using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Core;
using VerseFlow.Core.Import;
using VerseFlow.Core.Import.BibleQuote;
using VerseFlow.Properties;

namespace VerseFlow.UI
{
	public partial class FrmImportBibleQuote : Form
	{
		private string inifile;
		private string browseDir;
		private IBible importedBible;

		public FrmImportBibleQuote()
		{
			InitializeComponent();
			btnImport.Enabled = false;
		}

		public IBible ImportedBible
		{
			get { return importedBible; }
		}

		private void ImportBibleQuote_Load(object sender, EventArgs e)
		{
			EncodingInfo[] infos = Encoding.GetEncodings();
			EncodingInfoEx[] infos2 = new EncodingInfoEx[infos.Length];

			int padding = 0;

			for (int i = 0; i < infos.Length; i++)
			{
				infos2[i] = new EncodingInfoEx(infos[i]);

				if (infos[i].DisplayName.Length > padding)
					padding = infos[i].DisplayName.Length;
			}

			cmbEnc.DataSource = infos2;
			cmbEnc.DisplayMember = "DisplayNameEx";

			cmbEnc.Enabled = !cboxDefault.Checked;
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				IBibleImportAdapter adapter = new BqtBibleAdapter(txtIniFilePath.Text, GetEncoding());

				using (IBibleWriter bibleWriter = Options.BibleRepository.New())
				{
					importedBible = bibleWriter.Write(adapter);
				}

				MessageBox.Show(this,
					string.Format("Successfully imported '{0}'.", adapter.BibleName()),
					Options.AppName,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception exception)
			{
				MessageBox.Show(this, exception.Message, Options.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private Encoding GetEncoding()
		{
			return cboxDefault.Checked || cmbEnc.SelectedItem == null
					   ? Encoding.Default
					   : ((EncodingInfoEx)cmbEnc.SelectedItem).Encoding;
		}

		private void cmbEnc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!cboxDefault.Checked)
			{
				Preview();
			}
		}

		private void Preview()
		{
			if (!string.IsNullOrEmpty(inifile))
			{
				txtPreview.Text = File.ReadAllText(inifile, GetEncoding());
			}
		}

		private void cboxDefault_CheckedChanged(object sender, EventArgs e)
		{
			cmbEnc.Enabled = !cboxDefault.Checked;
			Preview();
		}

		private void txtFolder_TextChanged(object sender, EventArgs e)
		{
			inifile = null;

			if (File.Exists(txtIniFilePath.Text))
			{
				inifile = txtIniFilePath.Text;

				btnImport.Enabled = true;
				Preview();
				return;
			}

			btnImport.Enabled = false;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.Title = Resources.SelectBibleQuoteIniFile;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.InitialDirectory = browseDir;
				ofd.Filter = string.Format("BibleQuote INI File|{0}", BqtIni.INI);

				if (DialogResult.OK == ofd.ShowDialog(this))
				{
					txtIniFilePath.Text = ofd.FileName;
					browseDir = Path.GetDirectoryName(ofd.FileName);
				}
			}
		}

		class EncodingInfoEx
		{
			private readonly EncodingInfo ei;
			private readonly string displayNameEx;

			public EncodingInfoEx(EncodingInfo ei)
			{
				this.ei = ei;
				displayNameEx = string.Format("{0}  [{1}]", ei.DisplayName, ei.Name);
			}

			public Encoding Encoding
			{
				get { return ei.GetEncoding(); }
			}

			public string DisplayNameEx
			{
				get { return displayNameEx; }
			}
		}
	}
}
