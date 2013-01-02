using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Core.Import.BibleQuote;
using VerseFlow.Properties;

namespace VerseFlow.UI
{
	public partial class FrmImportBibleQuote : Form
	{
		private string inifile;

		public FrmImportBibleQuote()
		{
			InitializeComponent();
			btnImport.Enabled = false;
		}

		private void FrmImportBibleQuote_Load(object sender, EventArgs e)
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

			Array.Sort(infos2, (i1, i2) => String.Compare(i1.DisplayNameEx, i2.DisplayNameEx, StringComparison.Ordinal));

//			cmbEnc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//			cmbEnc.AutoCompleteSource = AutoCompleteSource.ListItems;

			cmbEnc.DataSource = infos2;
			cmbEnc.DisplayMember = "DisplayNameEx";

			cmbEnc.Enabled = !cboxDefault.Checked;
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

		private void txtFolder_TextChanged(object sender, EventArgs e)
		{
			string folder = txtFolder.Text;
			inifile = null;

			if (Directory.Exists(folder) &&
				(inifile = Directory.EnumerateFiles(folder).FirstOrDefault(
							  f =>
							  {
								  var name = Path.GetFileName(f);
								  return name != null && name.Equals(BibleQuoteIni.INI, StringComparison.OrdinalIgnoreCase);
							  })) != null)
			{
				btnImport.Enabled = true;
				Preview();
			}
			else
			{
				btnImport.Enabled = false;
			}
		}

		private void cboxDefault_CheckedChanged(object sender, EventArgs e)
		{
			cmbEnc.Enabled = !cboxDefault.Checked;
			Preview();
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

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				new BibleQuoteBibleImporter().Import(txtFolder.Text, GetEncoding());
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
