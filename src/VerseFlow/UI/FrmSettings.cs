using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI
{
	public partial class FrmSettings : Form
	{
		private ImportBibleQuote importBibleQuote;

		public FrmSettings()
		{
			InitializeComponent();
		}

		private void treeSettings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			e.Node.Expand();

			if (e.Node.Name == "ndBibleImportBQT")
			{
				SetRightControl(ImportBibleQuote);
			}
		}

		private void SetRightControl(Control control)
		{
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.Panel2.Controls.Clear();
			splitContainer1.Panel2.Controls.Add(control);
			control.Dock = DockStyle.Fill;
			splitContainer1.Panel2.ResumeLayout();
		}

		ImportBibleQuote ImportBibleQuote
		{
			get { return importBibleQuote ?? (importBibleQuote = new ImportBibleQuote()); }
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);

			if (importBibleQuote != null)
				importBibleQuote.Dispose();
		}

		private void FrmSettings_Load(object sender, EventArgs e)
		{
			treeSettings.SelectedNode = treeSettings.Nodes[0];
		}
	}
}
