using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public class VerseView : ScrollableControl
	{
		//Buffer1: Verses 
		//Buffer2: Verses and Selected Verses 
		//Buffer3: Verses and Selected Verses and Highlighted words 
		//Buffer4: Verses and Selected Verses and Highlighted words and MouseOver words


		private readonly List<VerseItem> visibleVerses = new List<VerseItem>();
		private List<VerseItem> allverses = new List<VerseItem>();


		private int prevWidth;

		private int focusedItem = -1;
		private bool readOnly;
		private VerseViewPresenter viewPresenter;
		private readonly VerseViewColorTheme theme;

		public VerseView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer
					 | ControlStyles.ResizeRedraw
					 | ControlStyles.AllPaintingInWmPaint
					 | ControlStyles.UserPaint
					 | ControlStyles.UserMouse
					 | ControlStyles.Selectable
					 | ControlStyles.Opaque // will not call OnPaintBackground
					 | ControlStyles.StandardClick
					 | ControlStyles.StandardDoubleClick
					 , true);

			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;

			VerticalScroll.Enabled = true;
			VerticalScroll.Visible = true;

			theme = new VerseViewColorTheme(BackColor);
		}

		public string HighlightText
		{
			get { return viewPresenter.HighlightText; }
			set
			{
				viewPresenter.HighlightText = value;
				Invalidate();
			}
		}

		public bool ReadOnly
		{
			get { return readOnly; }
			set { readOnly = value; }
		}

		public void SelectItem(int index)
		{
			if (index > -1 && index < allverses.Count)
			{
				allverses[index].IsSelected = !allverses[index].IsSelected;
			}
		}

		public void SetFocusedItem(int index)
		{
			if (index > -1 && index < allverses.Count) { }
			//				focusedItem = index;
		}

		public void Fill(List<string> strings)
		{
			if (strings == null)
				throw new ArgumentNullException("strings");

			viewPresenter = new VerseViewPresenter(strings, theme);
			allverses = strings.ConvertAll(s => new VerseItem(s));
			prevWidth = -1;
			AutoScrollPosition = new Point(0, 0);
			Invalidate();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Down || keyData == Keys.Up)
				return true;
			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
				e.Handled = true;

			base.OnKeyDown(e);
		}

		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			//			base.OnPreviewKeyDown(e);

			if (readOnly)
				return;

			if (e.KeyCode == Keys.Down)
			{
				if (e.Modifiers == Keys.Control)
					AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y - VerticalScroll.SmallChange));
				else if (focusedItem + 1 < allverses.Count)
					focusedItem++;

				Invalidate();
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (e.Modifiers == Keys.Control)
					AutoScrollPosition = new Point(0, -(AutoScrollPosition.Y + VerticalScroll.SmallChange));
				else if (focusedItem - 1 > -1)
					focusedItem--;

				Invalidate();
			}
			else if (e.KeyData == Keys.Space)
			{
				if (focusedItem > -1)
				{
					allverses[focusedItem].IsSelected = !allverses[focusedItem].IsSelected;
					Invalidate();
				}
			}
			else if (e.KeyData == Keys.End)
			{
				AutoScrollPosition = new Point(0, AutoScrollMinSize.Height);
				Invalidate();
			}
			else if (e.KeyData == Keys.Home)
			{
				AutoScrollPosition = new Point(0, 0);
				Invalidate();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{

#if DEBUG
			Stopwatch sw = Stopwatch.StartNew();
#endif
			//			if (backColorBrush == null)
			//				backColorBrush = new SolidBrush(BackColor);
			//
			//			if (backColorDarkerBrush == null)
			//				backColorDarkerBrush = new SolidBrush(GraphicsTools.DarkenColor(BackColor, 7));

			var myRect = new Rectangle(0, 0, Size.Width, Size.Height);

			if (prevWidth != Width) // start re-calculation only if width changed
			{
				prevWidth = Width;
				Debug.WriteLine("Recalculating verses width=" + Width);

				viewPresenter.SetBounds(e.Graphics, myRect, Padding);
				AutoScrollMinSize = viewPresenter.Size;
			}

			viewPresenter.DoPaint(e.Graphics, myRect, AutoScrollPosition.Y);

			base.OnPaint(e);

#if DEBUG
			sw.Stop();
			Debug.WriteLine("Painted verses in {0}", sw.Elapsed);
#endif
		}

		protected override void OnFontChanged(EventArgs e)
		{

			base.OnFontChanged(e);

			prevWidth = -1;
			viewPresenter.Font = Font;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			viewPresenter.Focused = true;
			Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);

			viewPresenter.Focused = false;
			Invalidate();
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);
			theme.BackColor = BackColor;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (theme != null)
				theme.Dispose();
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (readOnly)
				return;

			if (e.Button == MouseButtons.Left)
			{
				foreach (VerseItem vb in visibleVerses)
				{
					if (vb.IsInside(e.Location))
					{
						vb.IsSelected = !vb.IsSelected;
						Invalidate();
						return;
					}
				}
			}
		}
	}
}





