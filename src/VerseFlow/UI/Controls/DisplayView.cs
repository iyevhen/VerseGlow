using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public partial class DisplayView : UserControl
	{
		public DisplayView()
		{
			InitializeComponent();
			Load += DisplayView_Load;
		}

		void DisplayView_Load(object sender, EventArgs e)
		{
			tsDisplay.DropDownItems.Clear();
			foreach (Screen screen in Screen.AllScreens)
			{
				var dd = new DISPLAY_DEVICE();
				dd.cb = Marshal.SizeOf(dd);
				string monitorName = screen.DeviceName;

				if (EnumDisplayDevices(screen.DeviceName, 0, ref dd, 0))
				{
					string[] splits = dd.DeviceString.Split(',');
					monitorName = splits.Length > 0 ? splits[0] : dd.DeviceString;
				}

				tsDisplay.DropDownItems.Add(monitorName).Tag = screen;
				tsDisplay.Text = monitorName;
			}
		}

		private void tsDisplay_DropDownOpening(object sender, EventArgs e)
		{
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

		[Flags]
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
