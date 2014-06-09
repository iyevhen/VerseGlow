using System;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI.Controls
{
	public partial class DisplayView : UserControl, IDisplay
	{
		private readonly IDisplay live;

		public DisplayView()
		{
			InitializeComponent();

			live = new FrmDisplay();

			live.SizeChanged += (s, args) =>
			{
				var disp = s as IDisplay;

				if (disp != null)
					preview.ProportionSize = disp.Size;
			};

			Load += (s, args) =>
			{
				var parent = FindForm();

				if (parent != null)
					((Form)live).Icon = parent.Icon;
			};
		}
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			if (live != null)
				live.Dispose();

			base.Dispose(disposing);
		}

		private void tsGoLive_Click(object sender, EventArgs e)
		{
			var btn = sender as ToolStripButton;

			if (btn == null)
				return;

			if (btn.Checked)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
		}


		public void DisplayVerse(BibleVerse bibleVerse)
		{
			if (bibleVerse == null)
			{
				live.DrawVerse(null, null);
			}
			else
			{
				live.DrawVerse(bibleVerse.Text, bibleVerse.Reference);
			}
		}

		public void DrawVerse(string content, string reference)
		{
			live.DrawVerse(content, reference);
		}

		public bool FullScreen
		{
			get { return live.FullScreen; }
			set { live.FullScreen = value; }
		}
		public bool IsActive { get; private set; }
		public bool IsPlaying { get; private set; }
		public bool IsPaused { get; private set; }
		public bool IsStoped { get; private set; }

		public string DisplayName
		{
			get { return lblDispName.Text; } 
			set { lblDispName.Text = value; }
		}

		public event EventHandler ActivationChanged;

		public void Activate()
		{
			live.Activate();
			preview.ProportionSize = live.Size;
		}

		public void Deactivate()
		{
			live.Deactivate();
			
		}
	}
}
