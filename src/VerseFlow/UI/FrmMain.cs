using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VerseFlow.Core;
using VerseFlow.UI.Controls;

namespace VerseFlow.UI
{
	public partial class FrmMain : Form
	{
		private string appNameAndVersion;
		private IBible bible;
		private IDisplay display;
		private HashSet<string> opened;

		public FrmMain()
		{
			InitializeComponent();

			tableLayoutTop.ColumnCount = 0;
			tableLayoutTop.ColumnStyles.Clear();
			tableLayoutTop.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
			tableLayoutTop.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
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
			display = new FrmDisplay {Icon = Icon};
			display.SizeChanged += DisplayOnSizeChanged;

			appNameAndVersion = string.Format("{0} - v{1}", Options.AppName, Options.AppVersion.ToString(3));
			Text = appNameAndVersion;

			foreach (IBible b in Options.BibleRepository.OpenAll())
				tsBibles.DropDownItems.Add(new ToolStripMenuItem(b.Name) {Tag = b});

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
			ToolStripItem item = e.ClickedItem;

			if (item != null && item.Tag != null)
			{
				bible = (IBible) item.Tag;

				if (opened.Contains(bible.Name))
				{
				}
				else
				{
					var bibleView = new BibleView
					{
						Bible = bible
					};

					bibleView.CloseRequested += bibleView_CloseRequested;

					AddView(bibleView);

					opened.Add(bible.Name);
				}
			}
		}

		private void AddView(Control control)
		{
			tableLayoutTop.SuspendLayout();
			int idx = tableLayoutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			tableLayoutTop.ColumnCount += 1;
			control.Anchor = AnchorStyles.Bottom |
			                 AnchorStyles.Left |
			                 AnchorStyles.Top |
			                 AnchorStyles.Right;
			tableLayoutTop.Controls.Add(control, idx, 0);
			tableLayoutTop.ResumeLayout();
		}

		private void bibleView_CloseRequested(object sender, EventArgs e)
		{
			var bview = sender as BibleView;

			if (bview == null)
				return;

			int column = tableLayoutTop.GetColumn(bview);

			tableLayoutTop.SuspendLayout();

			tableLayoutTop.Controls.Remove(bview);
			bview.CloseRequested -= bibleView_CloseRequested;
			bview.Dispose();

			for (int i = column + 1; i < tableLayoutTop.ColumnCount; i++)
			{
				Control ctr = tableLayoutTop.GetControlFromPosition(i, 0);
				tableLayoutTop.SetColumn(ctr, i - 1);
			}

			tableLayoutTop.ColumnStyles.RemoveAt(tableLayoutTop.ColumnCount - 1);
			tableLayoutTop.ColumnCount -= 1;

			tableLayoutTop.ResumeLayout();

			opened.Remove(bview.Bible.Name);
		}

		private void tsGoLive_Click(object sender, EventArgs e)
		{
			//			if (tsGoLive.Checked)
			//			{
			//				display.Activate();
			//				SetDisplayProportions(display);
			//			}
			//			else
			//			{
			//				display.Deactivate();
			//			}
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
			//			displayViewPreview.Etalon = disp.Size;
			//			displayViewLive.Etalon = disp.Size;
		}

		private void miBibleQuote_Click(object sender, EventArgs e)
		{
			using (var f = new FrmImportBibleQuote {Icon = Icon})
			{
				if (DialogResult.OK == f.ShowDialog(this))
				{
					IBible imported = f.ImportedBible;

					if (imported != null)
						tsBibles.DropDownItems.Add(new ToolStripMenuItem(imported.Name) {Tag = imported});
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

		private void tsPreview_Click(object sender, EventArgs e)
		{
		}

		private void tsLive_Click(object sender, EventArgs e)
		{
			AddView(new DisplayLiveView());
		}
	}
}