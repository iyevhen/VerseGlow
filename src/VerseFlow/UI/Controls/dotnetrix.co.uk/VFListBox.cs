using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls.dotnetrix.co.uk
{
	class VFListBox : System.Windows.Forms.ListBox
	{
		private const int LB_GETCURSEL = 0x188;
		private const int LB_GETSELITEMS = 0x191;
		private const int LB_GETSELCOUNT = 0x190;
		private const int LB_GETTEXT = 0x189;
		private const int LB_GETTEXTLEN = 0x18A;
		private const int LB_SETCURSEL = 0x186;
		private const int LB_SETSEL = 0x185;

		private const int LBS_NOTIFY = 0x0001;
		private const int LBS_SORT = 0x0002;
		private const int LBS_NOREDRAW = 0x0004;
		private const int LBS_MULTIPLESEL = 0x0008;
		private const int LBS_OWNERDRAWFIXED = 0x0010;
		private const int LBS_OWNERDRAWVARIABLE = 0x0020;
		private const int LBS_HASSTRINGS = 0x0040;
		private const int LBS_USETABSTOPS = 0x0080;
		private const int LBS_NOINTEGRALHEIGHT = 0x0100;
		private const int LBS_MULTICOLUMN = 0x0200;
		private const int LBS_WANTKEYBOARDINPUT = 0x0400;
		private const int LBS_EXTENDEDSEL = 0x0800;
		private const int LBS_DISABLENOSCROLL = 0x1000;
		private const int LBS_NODATA = 0x2000;
		private const int LB_GETCOUNT = 0x018B;
		private const int LB_SETCOUNT = 0x01A7;

		private StringFormat stringFormat = new StringFormat { LineAlignment = StringAlignment.Center };
		private StringFormat stringFormatLineNumber = new StringFormat { LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.DirectionRightToLeft };
		private SizeF lineNumberSize;
		private int count;

		public VFListBox()
		{
			SetStyle(
				//				ControlStyles.UserPaint
				 ControlStyles.AllPaintingInWmPaint
				| ControlStyles.DoubleBuffer
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw, true);
		}


		//		protected override void OnPaint(PaintEventArgs e)
		//		{
		//			e.Graphics.DrawString("Hello world", Font, Brushes.HotPink, e.ClipRectangle);
		//		}
		//
		//		protected override void OnPaintBackground(PaintEventArgs pevent)
		//		{
		//			pevent.Graphics.FillRectangle(Brushes.WhiteSmoke, pevent.ClipRectangle);
		//		}



		/// <summary>
		/// Sets up the <see cref="CreateParams" /> object to tell 
		/// Windows how the VFListBox control should be created.  In 
		/// this instance the default configuration is modified to 
		/// remove <c>LBS_HASSTRINGS</c> and <c>LBS_SORT</c> 
		/// styles and to add <c>LBS_NODATA</c>and LBS_OWNERDRAWFIXED 
		/// styles. This converts the VFListBox into a Virtual VFListBox.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams defParams = base.CreateParams;
				defParams.Style = defParams.Style & ~LBS_HASSTRINGS;
				defParams.Style = defParams.Style & ~LBS_SORT;
				defParams.Style = defParams.Style | LBS_OWNERDRAWFIXED | LBS_NODATA;
				return defParams;
			}
		}

		/// <summary>
		/// Gets or sets the number of virtual items in the VFListBox.
		/// </summary>
		public int Count
		{
			get { return SendMessage(this.Handle, LB_GETCOUNT, 0, IntPtr.Zero); }
			set
			{
				SendMessage(this.Handle, LB_SETCOUNT, value, IntPtr.Zero);
				//				lineNumberSize = Graphics.FromHwnd(Handle).MeasureString(value.ToString(), Font, 1000, stringFormat);
				//				ItemHeight = Convert.ToInt32(lineNumberSize.Height);
				//				count = value;
			}
		}

		/// <summary>
		/// Throws an exception.  All the items for a Virtual VFListBox 
		/// are externally managed.
		/// </summary>
		/// <remarks>The selected index can be obtained using 
		/// the <see cref="SelectedIndex"/> and
		/// <see cref="SelectedIndices"/> properties.
		/// </remarks>
		[Browsable(false)]
		public new SelectedObjectCollection SelectedItems
		{
			get
			{
				throw new InvalidOperationException(
				   "A Virtual VFListBox does not have a " +
				   "SelectedObject collection");
			}
		}

		/// <summary>
		/// Gets/sets the selected index in the control.  If the 
		/// control has the multi-select style, then the first 
		/// selected item is returned.
		/// </summary>
		public new int SelectedIndex
		{
			get
			{
				int selIndex = -1;
				if (SelectionMode == SelectionMode.One)
				{
					selIndex = SendMessage(this.Handle,
					   LB_GETCURSEL, 0, IntPtr.Zero);
				}
				else if ((SelectionMode == SelectionMode.MultiExtended) ||
				   (SelectionMode == SelectionMode.MultiSimple))
				{
					int selCount = SendMessage(this.Handle,
					   LB_GETSELCOUNT, 0, IntPtr.Zero);
					if (selCount > 0)
					{
						IntPtr buf = Marshal.AllocCoTaskMem(4);
						SendMessage(this.Handle, LB_GETSELITEMS, 1, buf);
						selIndex = Marshal.ReadInt32(buf);
						Marshal.FreeCoTaskMem(buf);
					}
				}
				return selIndex;
			}
			set
			{
				if (SelectionMode == SelectionMode.One)
				{
					SendMessage(this.Handle,
					   LB_SETCURSEL, value, IntPtr.Zero);
				}
				else if ((SelectionMode == SelectionMode.MultiExtended) ||
				   (SelectionMode == SelectionMode.MultiSimple))
				{
					// clear any existing selection:
					SendMessage(this.Handle, LB_SETSEL, 0, new IntPtr(-1));
					// set the requested selection
					SendMessage(this.Handle, LB_SETSEL, 1, (IntPtr)value);
				}
			}
		}

		/// <summary>
		/// Gets/sets the selected index in the control.  If the 
		/// control has the multi-select style, then the first 
		/// selected item is returned.
		/// </summary>
		public int[] SelectedIndexes
		{
			get
			{
				if ((SelectionMode == SelectionMode.MultiExtended) ||
				   (SelectionMode == SelectionMode.MultiSimple))
				{
					int selCount = SendMessage(Handle, LB_GETSELCOUNT, 0, IntPtr.Zero);
					if (selCount > 0)
					{
						var intsize = sizeof(Int32);
						IntPtr buf = Marshal.AllocCoTaskMem(intsize * selCount);
						SendMessage(this.Handle, LB_GETSELITEMS, selCount, buf);

						int[] result = new int[selCount];

						for (int i = 0; i < selCount; i++)
						{
							result[i] = Marshal.ReadInt32(buf, i * intsize);
						}

						Marshal.FreeCoTaskMem(buf);

						return result;
					}
				}
				return new int[0];
			}
		}



		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.Graphics.DrawString(e.Index.ToString(), Font, Brushes.Black, e.Bounds, stringFormat);
		}

		[DllImport("user32", CharSet = CharSet.Auto)]
		private extern static int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
	}
}
