using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using www.obolonchurch.org.freepresenter.config;
using www.obolonchurch.org.freepresenter.convertion;
using www.obolonchurch.org.freepresenter.core;
using www.obolonchurch.org.freepresenter.ui;

namespace www.obolonchurch.org.freepresenter.ui
{
	partial class FrmMain : Form
	{
//		private readonly Dictionary<string, TextViewerControl> openedFiles = new Dictionary<string, TextViewerControl>(StringComparer.OrdinalIgnoreCase);
		private readonly Dictionary<string, TextBlock> openedFiles = new Dictionary<string, TextBlock>(StringComparer.OrdinalIgnoreCase);
		private readonly ImageList images;
		private IDisplay display;
		private bool paused;

		public FrmMain()
		{
			InitializeComponent();

			images = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
			images.Images.Add(Properties.Resources.book16);
			images.Images.Add(Properties.Resources.song16);
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			foreach (string file in Directory.GetFiles(AppConfig.Instance.BibleFolder, "*.xml"))
				btnOpen.DropDownItems.Add(Path.GetFileNameWithoutExtension(file)).Tag = file;

			foreach (string file in Directory.GetFiles(AppConfig.Instance.SongsFolder, "*.xml"))
				btnOpen.DropDownItems.Add(Path.GetFileNameWithoutExtension(file)).Tag = file;

			Text = AppConfig.Instance.AppName;
			RefreshDisplayButtons();
		}

		private void tsBtnOpen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			OpenFile<Bible>(e.ClickedItem.Tag.ToString(), new BibleTreeProvider(0));
		}

		private void tsBtnSongs_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			OpenFile<Book>(e.ClickedItem.Tag.ToString(), new SongsTreeProvider(1));
		}

		IDisplay Display
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

		void OpenFile<T>(string filePath, TreeNodeProvider treeProvider)
			where T : TextBlock
		{
			TextBlock txt;

			if (!openedFiles.TryGetValue(filePath, out txt))
			{
				T text = new XmlFile<T>(filePath).Read();

				if (text == null)
				{
					MessageBox.Show(this,
									string.Format("Cannot open file [{0}]. File format is not supported.", filePath),
									Text,
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);

					return;
				}
				txt = text;

//				viewer = new TextViewerControl(text)
//				{
//					Dock = DockStyle.Fill,
//					TreeProvider = treeProvider
//				};

//				viewer.OnSelectedTextChanged += viewer_OnSelectedTextChanged;
				openedFiles.Add(filePath, txt);

				var btn = new ToolStripButton(Path.GetFileNameWithoutExtension(filePath))
							{
								CheckOnClick = true,
								Checked = true,
								Margin = new Padding(2),
								Image = Properties.Resources.book16,
							};

				toolStripNavigate.Items.Add(btn);
//
//				body.Panel1.SuspendLayout();
//				body.Panel1.Controls.Add(viewer);
//				body.Panel1.ResumeLayout();
			}

			var sb = new StringBuilder();
			sb.AppendLine("<html>");
			sb.AppendLine("<head>");
			sb.AppendLine("<link rel=\"Stylesheet\" href=\"property:obolonchurch.Bridge.StyleSheet\" />");
			sb.AppendLine("</head>");
			sb.AppendLine("<body>");

			foreach (TextBlock child in txt.Children[0].Children[0].Children)
			{
				sb.AppendLine(string.Format("<div class=\"verse\"><b>{0}</b> {1}</div>",child.Id, child.Text));
			}
			
			sb.AppendLine("</body>");
			sb.AppendLine("</html>");

			html.Text = sb.ToString();

//			viewer.BringToFront();
		}

		void viewer_OnSelectedTextChanged(System.Text.StringBuilder builder)
		{
			if (Display.IsActive && !paused)
				Display.DrawText(builder.ToString());
		}

		void RefreshDisplayButtons()
		{
			if (paused)
				paused &= Display.IsActive;

			btnPlay.Enabled = !Display.IsActive || paused;
			btnPause.Enabled = Display.IsActive && !paused;
			btnStop.Enabled = Display.IsActive || paused;
		}

		void f_VisibleChanged(object sender, EventArgs e)
		{
			RefreshDisplayButtons();
		}

		private void tsBtnBackgroundColor_Click(object sender, EventArgs e)
		{
			using (var of = new ColorDialog())
			{
				of.AllowFullOpen = true;
				of.AnyColor = true;
				of.FullOpen = true;

				if (DialogResult.OK == of.ShowDialog(this))
				{
					Display.DrawBackground(of.Color);
				}
			}
		}

		private void tsBtnBackgroundPicture_Click(object sender, EventArgs e)
		{
			using (var of = new OpenFileDialog())
			{
				of.Multiselect = false;
				of.Filter = "Images|*.jpeg;*.jpg;*.png;*.bmp;*.gif|All Files|*.*";
				of.FilterIndex = 0;

				if (DialogResult.OK == of.ShowDialog(this))
				{
					var img = Image.FromFile(of.FileName);
					Display.DrawBackground(img);
				}
			}
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
	}
}