using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FreePresenter.Properties;
using FreePresenter.UI;
using FreePresenter.Convertion;
using FreePresenter.Core;

namespace FreePresenter.UI
{
	internal partial class FrmMain : Form
	{
		private readonly Dictionary<string, TextBlock> opened = new Dictionary<string, TextBlock>(StringComparer.OrdinalIgnoreCase);
		private readonly ImageList images;
		private IDisplay display;
		private bool paused;
		private UserRect rect;

		public FrmMain()
		{
			InitializeComponent();

			images = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
			images.Images.Add(Resources.book16);
			images.Images.Add(Resources.song16);

			rect = new UserRect(new Rectangle(10, 10, 100, 100));
			rect.SetControl(body.Panel2);
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
//			foreach (string file in Directory.GetFiles("", "*.xml"))
//				btnOpen.DropDownItems.Add(Path.GetFileNameWithoutExtension(file)).Tag = file;
//
//			Text = AppConfig.Instance.AppName;
			RefreshDisplayButtons();
		}

		private void tsBtnOpen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
//			var bible = Open<Bible>(e.ClickedItem.Tag.ToString());
//
//			foreach (TextBlock book in bible.Children)
//			{
//				cmbBooks.Items.Add(book.Text);
//			}
//
//			foreach (TextBlock chapter in bible.Children[0].Children)
//			{
//				cmdChapters.Items.Add(chapter.Text);
//			}
//
//			textBox1.Text = string.Empty;
//
//			foreach (TextBlock verse in bible.Children[0].Children[0].Children)
//			{
//				textBox1.AppendText(verse.Text + "\r\n");
//			}
		}

		private IDisplay Display
		{
			get
			{
				if (display == null)
				{
					display = new FrmDisplay
								{
									Icon = Icon
								};
					display.ActivationChanged += f_VisibleChanged;
				}

				return display;
			}
		}

		private T Open<T>(string filePath)
			where T : TextBlock
		{
			TextBlock block;

			if (!opened.TryGetValue(filePath, out block))
			{
				T text = new XmlFile<T>(filePath).Read();

				if (text == null)
				{
					MessageBox.Show(this,
									string.Format("Cannot open file [{0}]. File format is not supported.", filePath),
									Text,
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);

					return null;
				}
				block = text;
			}

			return (T)block;
		}

		private void RefreshDisplayButtons()
		{
			if (paused)
				paused &= Display.IsActive;

//			btnPlay.Enabled = !Display.IsActive || paused;
//			btnPause.Enabled = Display.IsActive && !paused;
//			btnStop.Enabled = Display.IsActive || paused;
		}

		private void f_VisibleChanged(object sender, EventArgs e)
		{
			RefreshDisplayButtons();
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			using (var frm = new FrmAbout { Icon = Icon })
			{
				frm.ShowDialog(this);
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			paused = true;
			RefreshDisplayButtons();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if (!Display.IsActive)
				Display.Activate();

			paused = false;
			RefreshDisplayButtons();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			if (Display.IsActive)
				Display.Deactivate();

			paused = false;
			RefreshDisplayButtons();
		}

		private void btnDisplay_Click(object sender, EventArgs e)
		{
//			body.Panel2Collapsed = !btnDisplay.Checked;
		}
	}
}