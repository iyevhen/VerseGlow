using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VerseGlow.Core;
using VerseGlow.Core.Import.BibleQuote;
using VerseGlow.Properties;
using VerseGlow.UI.Controls;

namespace VerseGlow.UI
{
    public partial class FrmMain : Form
    {
        private HashSet<string> openedBibles;

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
            Text = string.Format("{0} - v{1}", Options.AppName, Options.AppVersion.ToString(3));

            IBible[] bibles = Options.BibleRepository.OpenAll();

            foreach (IBible b in bibles)
                tsBibles.DropDownItems.Insert(0, new ToolStripMenuItem(b.Name) { Tag = b });

            openedBibles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (bibles.Length > 0)
                OpenBible(bibles[0]);

            //Dispays
            tsDisplay.DropDownItems.Clear();
            Screen[] screens = Screen.AllScreens;
            string[] screensNames = new string[screens.Length];
            int secondary = 0;

            for (int i = 0; i < screens.Length; i++)
            {
                Screen screen = screens[i];
                var dd = new DISPLAY_DEVICE();
                dd.cb = Marshal.SizeOf(dd);

                screensNames[i] = EnumDisplayDevices(screen.DeviceName, 0, ref dd, 0)
                    ? dd.DeviceString
                    : screen.DeviceName;

                tsDisplay.DropDownItems.Add(screensNames[i]).Tag = screen;

                if (!screen.Primary)
                    secondary = i;
            }

            displayView.SetDevice(screens[secondary], screensNames[secondary]);
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
                OpenBible((IBible)item.Tag);
        }

        private void OpenBible(IBible bible)
        {
            if (!openedBibles.Contains(bible.Name))
            {
                var bview = new BibleView();
                bview.CloseRequested += OnBibleViewCloseRequested;
                bview.SelectedVerseChanged += OnBibleViewSelectedVerseChanged;
                bview.Bible = bible;

                AddView(bview);
                openedBibles.Add(bible.Name);
            }
        }

        private void OnBibleViewSelectedVerseChanged(BibleVerse v)
        {
            displayView.DisplayVerse(v);
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

        private void OnBibleViewCloseRequested(object sender, EventArgs e)
        {
            var bview = sender as BibleView;

            if (bview == null)
                return;

            int column = tblBibles.GetColumn(bview);

            tblBibles.SuspendLayout();

            tblBibles.Controls.Remove(bview);
            bview.CloseRequested -= OnBibleViewCloseRequested;
            bview.SelectedVerseChanged -= OnBibleViewSelectedVerseChanged;
            bview.Dispose();

            for (int i = column + 1; i < tblBibles.ColumnCount; i++)
            {
                Control ctr = tblBibles.GetControlFromPosition(i, 0);
                tblBibles.SetColumn(ctr, i - 1);
            }

            tblBibles.ColumnStyles.RemoveAt(tblBibles.ColumnCount - 1);
            tblBibles.ColumnCount -= 1;

            tblBibles.ResumeLayout();

            openedBibles.Remove(bview.Bible.Name);
        }

        private void miBibleQuote_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = Resources.SelectBibleQuoteIniFile;
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                //ofd.InitialDirectory = browseDir;
                ofd.Filter = $"BibleQuote INI File|{BqtIni.INI}";

                if (DialogResult.OK == ofd.ShowDialog(this))
                {
                    string bqtini = ofd.FileName;

                    using (var f = new FrmImportBibleQuote(bqtini) { Icon = Icon })
                    {
                        if (DialogResult.OK == f.ShowDialog(this))
                        {
                            IBible imported = f.ImportedBible;

                            if (imported != null)
                                tsBibles.DropDownItems.Insert(0, new ToolStripMenuItem(imported.Name) { Tag = imported });
                        }
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice,
            uint dwFlags);

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

        private void tsDisplay_DropDownOpening(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var f = new FrmImportPowerPoint())
            {
                f.ShowDialog(this);
            }
        }
    }

    class DisplayDevice
    {
        private readonly Screen screen;
        private readonly string deviceName;

        private DisplayDevice(Screen screen, string deviceName)
        {
            this.screen = screen;
            this.deviceName = deviceName;
        }

        public static List<DisplayDevice> GetAll()
        {
            var result = new List<DisplayDevice>();
            Screen[] screens = Screen.AllScreens;

            for (int i = 0; i < screens.Length; i++)
            {
                Screen screen = screens[i];
                var dd = new DISPLAY_DEVICE();
                dd.cb = Marshal.SizeOf(dd);

                string name = EnumDisplayDevices(screen.DeviceName, 0, ref dd, 0)
                    ? dd.DeviceString
                    : screen.DeviceName;
                result.Add(new DisplayDevice(screen, name));
            }

            return result;
        }

        [DllImport("user32.dll")]
        private static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice,
            uint dwFlags);

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