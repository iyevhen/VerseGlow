using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class TextCursor
	{
		[DllImport("user32.dll", EntryPoint = "CreateIconIndirect")]
		private static extern IntPtr CreateIconIndirect(IntPtr iconInfo);

		private struct IconInfo
		{
			public bool fIcon;
			public IntPtr hbmColor;
			public IntPtr hbmMask;
			public Int32 xHotspot;
			public Int32 yHotspot;
		}

		private readonly Cursor[] mycursor = new Cursor[1];
		private Int32 _cHeight = 24;
		private Int32 _cWidth = 24;
		private String cursortext = "Text Cursor";
		private Font font = new Font(FontFamily.GenericSerif, 10);
		private Boolean gooddrop;

		public TextCursor()
		{
			SetupCursor();
		}

		/// <summary>
		/// To change the text of your cursor - just change the .CursorText property
		/// </summary>
		public String CursorText
		{
			get { return cursortext; }
			set
			{
				if (cursortext != value)
				{
					cursortext = value;

					var imgColor = new Bitmap(_cWidth, _cHeight, PixelFormat.Format32bppArgb);
					using (Graphics g = Graphics.FromImage(imgColor))
					{
						SizeF size = g.MeasureString(cursortext, font);
						_cWidth = (Int32) size.Width;
						_cHeight = (Int32) size.Height;
						g.Flush();
					}

					SetupCursor();
				}
			}
		}

		/// <summary>
		/// This is the font used for the Text displayed
		/// </summary>
		public Font Font
		{
			get { return font; }
			set
			{
				if (font != value)
				{
					font = value;
				}
			}
		}

		/// <summary>
		/// Whenever your cursor is over a good drop location, set this to True
		/// </summary>
		public Boolean GoodDrop
		{
			get { return gooddrop; }
			set
			{
				if (gooddrop != value)
				{
					gooddrop = value;
					SetupCursor();
				}
			}
		}


		/// <summary>
		/// Public method that returns a valid cursor
		/// </summary>
		/// <returns></returns>
		public Cursor GetCursor()
		{
			if (mycursor[0] != null)
				return mycursor[0];

			return Cursors.Default;
		}

		#region Private functions

		private void SetupCursor()
		{
			mycursor[0] = CreateCursor();
		}

		private Cursor CreateCursor()
		{
			var imgColor = new Bitmap(_cWidth, _cHeight + 16, PixelFormat.Format32bppArgb);
			var rect = new RectangleF(0, 0, _cWidth, _cHeight);
			Color xwhite = Color.FromArgb(0, 255, 255, 255);

			var gp = new GraphicsPath();
			gp.AddRectangle(rect);

			var pgb = new PathGradientBrush(gp);
			pgb.CenterPoint = new PointF(_cWidth/2, _cHeight/2);
			pgb.CenterColor = Color.Black;
			pgb.SurroundColors = new[] {xwhite};

			string s = cursortext;
			using (Graphics g = Graphics.FromImage(imgColor))
			{
				// Draw the text BELOW the icon
				g.DrawString(s, font, pgb, 0, 0);

				//
				// I never got this to work for reasons unknown to me - but certainly has something to do
				// with my novice understanding of C# at this time.
				//
				// The DLL compiles without error but whenever I try to USE this DLL inside another 
				// project, I get some kind of resource error.  That makes me believe I have the wrong
				// 'name' in quotes - but I tried everything I could come up with... nothing worked.
				// That tells me its probably a combination of several things... but regardless, I'll leave
				// the code in for now and come back to it at a later date when I have the time.

				// ResourceManager rm = new ResourceManager("XCursor", this.GetType().Assembly);
				// Image icon = new Bitmap(20, 26);
				// if (gooddrop == true)
				// {
				//    icon = (Bitmap)rm.GetObject("GoodDrop");
				//    g.DrawImage(icon, ((_cWidth / 2) - 6), ((_cHeight / 2) - 3));
				// }
				// else
				// {
				//    icon = (Bitmap)rm.GetObject("BadDrop");
				//    g.DrawImage(icon, ((_cWidth / 2) - 1), ((_cHeight / 2) - 0));
				// }


				g.Flush();
			}
			imgColor.MakeTransparent(Color.White);

			var cursorinfo = new IconInfo();
			cursorinfo.fIcon = false;
			cursorinfo.xHotspot = (_cWidth/2);
			cursorinfo.yHotspot = (_cHeight/2);
			cursorinfo.hbmMask = imgColor.GetHbitmap();
			cursorinfo.hbmColor = imgColor.GetHbitmap();
			unsafe
			{
				var cursorinfoPtr = new IntPtr(&cursorinfo);
				IntPtr curPtr = CreateIconIndirect(cursorinfoPtr);
				return new Cursor(curPtr);
			}
		}

		#endregion
	}
}