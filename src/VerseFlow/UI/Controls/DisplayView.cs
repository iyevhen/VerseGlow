using System;
using System.Drawing;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI.Controls
{
	public partial class DisplayView : UserControl, IDisplay
	{
		private IDisplay live;

		public DisplayView()
		{
			InitializeComponent();
			live = new FrmDisplay();
			live.SizeChanged += DisplayOnSizeChanged;

			Load += DisplayView_Load;
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

		public Size LiveDisplaySize
		{
			get { return preview.ProportionSize; }
			set { preview.ProportionSize = value; }
		}

		void DisplayView_Load(object sender, EventArgs e)
		{
			var parent = FindForm();

			if (parent != null)
				((Form)live).Icon = parent.Icon;
		}

		private void DisplayOnSizeChanged(object sender, EventArgs eventArgs)
		{
			var disp = sender as IDisplay;

			if (disp != null)
				preview.ProportionSize = disp.Size;
		}


		public void DisplayVerse(BibleVerse bibleVerse)
		{
			live.DisplayText = bibleVerse == null
				? null
				: bibleVerse.Text;
		}

		public string DisplayText { get; set; }

		public bool FullScreen
		{
			get { return live.FullScreen; }
			set { live.FullScreen = value; }
		}
		public bool IsActive { get; private set; }
		public bool IsPlaying { get; private set; }
		public bool IsPaused { get; private set; }
		public bool IsStoped { get; private set; }
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
