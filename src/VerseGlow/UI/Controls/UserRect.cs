using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VerseGlow.UI.Controls
{
	public class UserRect
	{
		public bool allowDeformingDuringMovement = false;
		private int angle = 30;
		private Control control;
		private Bitmap mBmp;
		private bool mIsClick;
		private bool mMove;
		private PosSizableRect nodeSelected = PosSizableRect.None;
		private int oldX;
		private int oldY;
		public Rectangle rect;
		private int sizeNodeRect = 5;

		public UserRect(Rectangle r)
		{
			rect = r;
			mIsClick = false;
		}

		public void Draw(Graphics g)
		{
			g.DrawRectangle(new Pen(Color.Red), rect);

			foreach (PosSizableRect pos in Enum.GetValues(typeof (PosSizableRect)))
			{
				g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
			}
		}

		public void SetBitmapFile(string filename)
		{
			mBmp = new Bitmap(filename);
		}

		public void SetBitmap(Bitmap bmp)
		{
			mBmp = bmp;
		}

		public void SetControl(Control p)
		{
			control = p;
			control.MouseDown += mPictureBox_MouseDown;
			control.MouseUp += mPictureBox_MouseUp;
			control.MouseMove += mPictureBox_MouseMove;
			control.Paint += mPictureBox_Paint;
		}

		private void mPictureBox_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e.Graphics);
			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp);
			}
		}

		private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			mIsClick = true;

			nodeSelected = PosSizableRect.None;
			nodeSelected = GetNodeSelectable(e.Location);

			if (rect.Contains(new Point(e.X, e.Y)))
			{
				mMove = true;
			}
			oldX = e.X;
			oldY = e.Y;
		}

		private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			mIsClick = false;
			mMove = false;
		}

		private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			ChangeCursor(e.Location);
			if (mIsClick == false)
			{
				return;
			}

			Rectangle backupRect = rect;

			switch (nodeSelected)
			{
				case PosSizableRect.LeftUp:
					rect.X += e.X - oldX;
					rect.Width -= e.X - oldX;
					rect.Y += e.Y - oldY;
					rect.Height -= e.Y - oldY;
					break;
				case PosSizableRect.LeftMiddle:
					rect.X += e.X - oldX;
					rect.Width -= e.X - oldX;
					break;
				case PosSizableRect.LeftBottom:
					rect.Width -= e.X - oldX;
					rect.X += e.X - oldX;
					rect.Height += e.Y - oldY;
					break;
				case PosSizableRect.BottomMiddle:
					rect.Height += e.Y - oldY;
					break;
				case PosSizableRect.RightUp:
					rect.Width += e.X - oldX;
					rect.Y += e.Y - oldY;
					rect.Height -= e.Y - oldY;
					break;
				case PosSizableRect.RightBottom:
					rect.Width += e.X - oldX;
					rect.Height += e.Y - oldY;
					break;
				case PosSizableRect.RightMiddle:
					rect.Width += e.X - oldX;
					break;

				case PosSizableRect.UpMiddle:
					rect.Y += e.Y - oldY;
					rect.Height -= e.Y - oldY;
					break;

				default:
					if (mMove)
					{
						rect.X = rect.X + e.X - oldX;
						rect.Y = rect.Y + e.Y - oldY;
					}
					break;
			}
			oldX = e.X;
			oldY = e.Y;

			if (rect.Width < 5 || rect.Height < 5)
			{
				rect = backupRect;
			}

			TestIfRectInsideArea();

			control.Invalidate();
		}

		private void TestIfRectInsideArea()
		{
			// Test if rectangle still inside the area.
			if (rect.X < 0)
				rect.X = 0;
			if (rect.Y < 0)
				rect.Y = 0;
			if (rect.Width <= 0)
				rect.Width = 1;
			if (rect.Height <= 0)
				rect.Height = 1;

			if (rect.X + rect.Width > control.Width)
			{
				rect.Width = control.Width - rect.X - 1; // -1 to be still show 
				if (allowDeformingDuringMovement == false)
				{
					mIsClick = false;
				}
			}
			if (rect.Y + rect.Height > control.Height)
			{
				rect.Height = control.Height - rect.Y - 1; // -1 to be still show 
				if (allowDeformingDuringMovement == false)
				{
					mIsClick = false;
				}
			}
		}

		private Rectangle CreateRectSizableNode(int x, int y)
		{
			return new Rectangle(x - sizeNodeRect/2, y - sizeNodeRect/2, sizeNodeRect, sizeNodeRect);
		}

		private Rectangle GetRect(PosSizableRect p)
		{
			switch (p)
			{
				case PosSizableRect.LeftUp:
					return CreateRectSizableNode(rect.X, rect.Y);

				case PosSizableRect.LeftMiddle:
					return CreateRectSizableNode(rect.X, rect.Y + +rect.Height/2);

				case PosSizableRect.LeftBottom:
					return CreateRectSizableNode(rect.X, rect.Y + rect.Height);

				case PosSizableRect.BottomMiddle:
					return CreateRectSizableNode(rect.X + rect.Width/2, rect.Y + rect.Height);

				case PosSizableRect.RightUp:
					return CreateRectSizableNode(rect.X + rect.Width, rect.Y);

				case PosSizableRect.RightBottom:
					return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height);

				case PosSizableRect.RightMiddle:
					return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height/2);

				case PosSizableRect.UpMiddle:
					return CreateRectSizableNode(rect.X + rect.Width/2, rect.Y);
				default:
					return new Rectangle();
			}
		}

		private PosSizableRect GetNodeSelectable(Point p)
		{
			foreach (PosSizableRect r in Enum.GetValues(typeof (PosSizableRect)))
			{
				if (GetRect(r).Contains(p))
				{
					return r;
				}
			}
			return PosSizableRect.None;
		}

		private void ChangeCursor(Point p)
		{
			control.Cursor = GetCursor(GetNodeSelectable(p));
		}

		/// <summary>
		///     Get cursor for the handle
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private Cursor GetCursor(PosSizableRect p)
		{
			switch (p)
			{
				case PosSizableRect.LeftUp:
					return Cursors.SizeNWSE;

				case PosSizableRect.LeftMiddle:
					return Cursors.SizeWE;

				case PosSizableRect.LeftBottom:
					return Cursors.SizeNESW;

				case PosSizableRect.BottomMiddle:
					return Cursors.SizeNS;

				case PosSizableRect.RightUp:
					return Cursors.SizeNESW;

				case PosSizableRect.RightBottom:
					return Cursors.SizeNWSE;

				case PosSizableRect.RightMiddle:
					return Cursors.SizeWE;

				case PosSizableRect.UpMiddle:
					return Cursors.SizeNS;
				default:
					return Cursors.Default;
			}
		}

		#region Nested type: PosSizableRect

		private enum PosSizableRect
		{
			UpMiddle,
			LeftMiddle,
			LeftBottom,
			LeftUp,
			RightUp,
			RightMiddle,
			RightBottom,
			BottomMiddle,
			None
		};

		#endregion
	}
}