using System;
using System.Windows.Forms;
using VerseFlow.Core;

namespace VerseFlow.UI.Controls
{
	public partial class DisplayView : UserControl, IDisplay
	{
		private readonly IDisplay live;
		private bool isPlaying;
		private bool isPaused;

		public DisplayView()
		{
			InitializeComponent();

			live = new FrmDisplay();

			live.SizeChanged += (s, args) =>
			{
				var disp = s as IDisplay;

				if (disp != null)
					liveSpy.ProportionSize = disp.Size;
			};

			live.ActivationChanged += (s, args) =>
			{
				var disp = s as IDisplay;

				if (disp != null)
				{
					tsPlay.Checked = disp.IsPlaying;
					tsStop.Enabled = disp.IsPlaying || disp.IsPaused;
					tsPause.Enabled = !disp.IsStoped && !disp.IsPaused;
				}
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

		private void tsPlay_Click(object sender, EventArgs e)
		{
			var btn = sender as ToolStripButton;

			if (btn == null)
				return;

			if (btn.Checked)
			{
				Play();
			}
			else
			{
				Stop();
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

		public bool IsPlaying
		{
			get { return isPlaying; }
			private set
			{
				isPlaying = value;

				if (value)
					isPaused = false;
			}
		}

		public bool IsPaused
		{
			get { return isPaused; }
			private set
			{
				isPaused = value;

				if (value)
					isPlaying = false;
			}
		}

		public bool IsStoped
		{
			get { return !isPlaying && !isPaused; }
			private set
			{
				if (value)
				{
					IsPlaying = false;
					IsPaused = false;
				}
			}
		}

		public event EventHandler ActivationChanged;

		public void SetDevice(Screen screen, string deviceName)
		{
			lblDispName.Text = deviceName;
			liveSpy.ProportionSize = screen.WorkingArea.Size;
		}

		public void Play()
		{
			live.Play();
			IsPlaying = true;
			liveSpy.ProportionSize = live.Size;
		}

		public void Stop()
		{
			live.Stop();
			IsStoped = true;
		}

		public void Pause()
		{
			live.Pause();
			IsPaused = true;
		}
	}
}
