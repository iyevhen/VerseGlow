using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private IDisplay display;
		private IBible bible;
		private string appNameAndVersion;
		private HashSet<string> opened;

		public FrmMain()
		{
			InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.F))
			{
				MessageBox.Show("What the Ctrl+F?");
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			display = new FrmDisplay { Icon = Icon };
			display.SizeChanged += DisplayOnSizeChanged;

			appNameAndVersion = string.Format("{0} - v{1}", Options.AppName, Options.AppVersion.ToString(3));
			Text = appNameAndVersion;

			foreach (IBible b in Options.BibleRepository.OpenAll())
				tsBibles.DropDownItems.Add(new ToolStripMenuItem(b.Name) { Tag = b });

			opened = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		}

		private void tsAbout_Click(object sender, EventArgs e)
		{
			using (var f = new FrmAbout())
			{
				f.Icon = Icon;
				f.Text = Options.AppName;
				f.ShowDialog(this);
			}
		}

		private void tsBibles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			var item = e.ClickedItem;

			if (item != null && item.Tag != null)
			{
				bible = (IBible)item.Tag;

				if (opened.Contains(bible.Name))
				{

				}
				else
				{
					tableLayoutTop.SuspendLayout();

					tableLayoutTop.ColumnCount += 1;

					int idx = tableLayoutTop.Controls.Count > 0
						? tableLayoutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f))
						: 0;

					var bibleView = new BibleView
					{
						Anchor = AnchorStyles.Bottom |
								 AnchorStyles.Left |
								 AnchorStyles.Top |
								 AnchorStyles.Right,

						Bible = bible
					};

					tableLayoutTop.Controls.Add(bibleView, idx, 0);

					tableLayoutTop.ResumeLayout();
				}
			}
		}

		private void tsGoLive_Click(object sender, EventArgs e)
		{
			if (tsGoLive.Checked)
			{
				display.Activate();
				SetDisplayProportions(display);
			}
			else
			{
				display.Deactivate();
			}
		}

		private void DisplayOnSizeChanged(object sender, EventArgs eventArgs)
		{
			var disp = sender as IDisplay;

			if (disp != null)
			{
				SetDisplayProportions(disp);
			}
		}

		private void SetDisplayProportions(IDisplay disp)
		{
			displayViewPreview.Etalon = disp.Size;
			displayViewLive.Etalon = disp.Size;
		}

		private void miBibleQuote_Click(object sender, EventArgs e)
		{
			using (var f = new FrmImportBibleQuote { Icon = Icon })
			{
				if (DialogResult.OK == f.ShowDialog(this))
				{
					IBible imported = f.ImportedBible;

					if (imported != null)
						tsBibles.DropDownItems.Add(new ToolStripMenuItem(imported.Name) { Tag = imported });
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			display.Dispose();

			base.Dispose(disposing);
		}

	}
}
