using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Core.Import.BibleQuote;
using VerseFlow.Properties;

namespace VerseFlow.UI
{
	public partial class ImportBibleQuote : UserControl
	{
		private string inifile;

		public ImportBibleQuote()
		{
			InitializeComponent();
			btnImport.Enabled = false;
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

			foreach (EncodingInfoEx ei in infos2)
				ei.SetPadding(padding);

			cmbEnc.DataSource = infos2;
			cmbEnc.DisplayMember = "DisplayNameEx";

			cmbEnc.Enabled = !cboxDefault.Checked;
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				new BibleQuoteBibleImporter().Import(txtFolder.Text, GetEncoding());
				MessageBox.Show(this, "Imported", AppGlobal.AppName, MessageBoxButtons.OK);
			}
			catch (Exception exception)
			{
				MessageBox.Show(this, exception.Message, AppGlobal.AppName, MessageBoxButtons.OK);
			}
		}

		private Encoding GetEncoding()
		{
			if (cboxDefault.Checked || cmbEnc.SelectedItem == null)
				return Encoding.Default;

			return ((EncodingInfoEx)cmbEnc.SelectedItem).Encoding;
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
				txtPreview.Text = File.ReadAllText(inifile, GetEncoding());
		}

		private void cboxDefault_CheckedChanged(object sender, EventArgs e)
		{
			cmbEnc.Enabled = !cboxDefault.Checked;
			Preview();
		}

		private void txtFolder_TextChanged(object sender, EventArgs e)
		{
			string folder = txtFolder.Text;
			inifile = null;

			if (Directory.Exists(folder))
			{
				inifile = DirectoryHelp.GetFile(folder, BibleQuoteIni.INI);

				if (inifile != null)
				{
					btnImport.Enabled = true;
					Preview();
					return;
				}
			}

			btnImport.Enabled = false;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (var fb = new FolderBrowserDialog())
			{
				fb.Description = Resources.SelectBibleQuoteBibleFolder;

				if (DialogResult.OK != fb.ShowDialog(this))
					return;

				txtFolder.Text = fb.SelectedPath;
			}
		}

		class EncodingInfoEx
		{
			private readonly EncodingInfo ei;
			private string displayNameEx;

			public EncodingInfoEx(EncodingInfo ei)
			{
				this.ei = ei;
			}

			public void SetPadding(int padding)
			{
				displayNameEx = string.Format("{0}  {1}", ei.DisplayName.PadRight(padding, ' '), ei.Name);
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
