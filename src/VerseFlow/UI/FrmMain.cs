using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
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

			tblBibles.ColumnCount = 0;
			tblBibles.ColumnStyles.Clear();
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
			tblBibles.SuspendLayout();
			int idx = tblBibles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			tblBibles.ColumnCount += 1;
			control.Anchor = AnchorStyles.Bottom |
			                 AnchorStyles.Left |
			                 AnchorStyles.Top |
			                 AnchorStyles.Right;
			control.Margin = new Padding(0);
			tblBibles.Controls.Add(control, idx, 0);
			tblBibles.ResumeLayout();
		}

		private void bibleView_CloseRequested(object sender, EventArgs e)
		{
			var bview = sender as BibleView;

			if (bview == null)
				return;

			int column = tblBibles.GetColumn(bview);

			tblBibles.SuspendLayout();

			tblBibles.Controls.Remove(bview);
			bview.CloseRequested -= bibleView_CloseRequested;
			bview.Dispose();

			for (int i = column + 1; i < tblBibles.ColumnCount; i++)
			{
				Control ctr = tblBibles.GetControlFromPosition(i, 0);
				tblBibles.SetColumn(ctr, i - 1);
			}

			tblBibles.ColumnStyles.RemoveAt(tblBibles.ColumnCount - 1);
			tblBibles.ColumnCount -= 1;

			tblBibles.ResumeLayout();

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

		private void tsDisplay_DropDownOpening(object sender, EventArgs e)
		{
			tsDisplay.DropDownItems.Clear();

			var d = new DISPLAY_DEVICE();
			d.cb = Marshal.SizeOf(d);
			try
			{
				for (uint id = 0; EnumDisplayDevices(null, id, ref d, 0); id++)
				{
//					Debug.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", id, d.DeviceName, d.DeviceString, d.StateFlags, d.DeviceID, d.DeviceKey);
					d.cb = Marshal.SizeOf(d);

					var dd = new DISPLAY_DEVICE();
					dd.cb = Marshal.SizeOf(dd);
					string monitorName = d.DeviceString;

					if (EnumDisplayDevices(d.DeviceName, 0, ref dd, 0))
						monitorName = dd.DeviceString;

					tsDisplay.DropDownItems.Add(monitorName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

//			foreach (Screen screen in Screen.AllScreens)
//			{
//				var dd = new DISPLAY_DEVICE();
//				dd.cb = Marshal.SizeOf(dd);
//				string monitorName = screen.DeviceName;
//
//				if (EnumDisplayDevices(screen.DeviceName, 0, ref dd, 0))
//					monitorName = dd.DeviceString;
//
//				tsDisplay.DropDownItems.Add(monitorName);
//			}
			
		}

		[DllImport("user32.dll")]
		static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct DISPLAY_DEVICE
		{
			[MarshalAs(UnmanagedType.U4)]
			public int cb;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DeviceName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceString;
			[MarshalAs(UnmanagedType.U4)]
			public DisplayDeviceStateFlags StateFlags;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceID;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceKey;
		}

		[Flags()]
		public enum DisplayDeviceStateFlags : int
		{
			/// <summary>The device is part of the desktop.</summary>
			AttachedToDesktop = 0x1,
			MultiDriver = 0x2,
			/// <summary>The device is part of the desktop.</summary>
			PrimaryDevice = 0x4,
			/// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
			MirroringDriver = 0x8,
			/// <summary>The device is VGA compatible.</summary>
			VGACompatible = 0x10,
			/// <summary>The device is removable; it cannot be the primary display.</summary>
			Removable = 0x20,
			/// <summary>The device has more display modes than its output devices support.</summary>
			ModesPruned = 0x8000000,
			Remote = 0x4000000,
			Disconnect = 0x2000000
		}
	}
}