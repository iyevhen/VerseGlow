using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI
{
	public partial class FrmBibleViewColors : Form
	{
		public FrmBibleViewColors()
		{
			InitializeComponent();

			verseView1.ReadOnly = true;
		}

		private void FrmBibleViewColors_Load(object sender, EventArgs e)
		{
			var strings = new List<string>
			{
				@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ultricies sagittis orci, nec consequat dolor consequat ac.",
				@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ultricies sagittis orci, nec consequat dolor consequat ac."
			};


			verseView1.Fill(strings);
			verseView1.SelectItem(0);
			verseView1.SetFocusedItem(1);
			verseView1.HighlightText = "ipsum";
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
			DialogResult = DialogResult.OK;
		}

		private void colorButton2_SelectedColorChanged(object sender, EventArgs e)
		{
			verseView1.BackColor = colorButton2.Color;
		}
	}

	//Please help me add a Size and Style Picker
//	public class FontListBox : ListBox
//	{
//		private List<Font> _fonts = new List<Font>();
//		private Brush _foreBrush;
//
//		public FontListBox()
//		{
//			DrawMode = DrawMode.OwnerDrawFixed;
//			ItemHeight = 20;
//			foreach (FontFamily ff in FontFamily.Families)
//			{
//				// determine the first available style, as all fonts don't support all styles
//				FontStyle? availableStyle = null;
//				foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
//				{
//					if (ff.IsStyleAvailable(style))
//					{
//						availableStyle = style;
//						break;
//					}
//				}
//
//				if (availableStyle.HasValue)
//				{
//					Font font = null;
//					try
//					{
//						// do your own Font initialization here
//						// discard the one you don't like :-)
//						font = new Font(ff, 12, availableStyle.Value);
//					}
//					catch
//					{
//					}
//					if (font != null)
//					{
//						_fonts.Add(font);
//						Items.Add(font);
//					}
//				}
//			}
//		}
//
//		protected override void Dispose(bool disposing)
//		{
//			base.Dispose(disposing);
//			if (_fonts != null)
//			{
//				foreach (Font font in _fonts)
//				{
//					font.Dispose();
//				}
//				_fonts = null;
//			}
//			if (_foreBrush != null)
//			{
//				_foreBrush.Dispose();
//				_foreBrush = null;
//			}
//		}
//
//		public override Color ForeColor
//		{
//			get
//			{
//				return base.ForeColor;
//			}
//			set
//			{
//				base.ForeColor = value;
//				if (_foreBrush != null)
//				{
//					_foreBrush.Dispose();
//				}
//				_foreBrush = null;
//			}
//		}
//
//		private Brush ForeBrush
//		{
//			get
//			{
//				if (_foreBrush == null)
//				{
//					_foreBrush = new SolidBrush(ForeColor);
//				}
//				return _foreBrush;
//			}
//		}
//
//		protected override void OnDrawItem(DrawItemEventArgs e)
//		{
//			base.OnDrawItem(e);
//			if (e.Index < 0)
//				return;
//
//			e.DrawBackground();
//			e.DrawFocusRectangle();
//			Rectangle bounds = e.Bounds;
//			Font font = (Font)Items[e.Index];
//			e.Graphics.DrawString(font.Name, font, ForeBrush, bounds.Left, bounds.Top);
//		}
//	}
//
//	public partial class MyFontDialog : Form
//	{
//		private FontListBox _fontListBox;
//		private ListBox _fontSizeListBox;
//
//		public MyFontDialog()
//		{
//			//InitializeComponent();
//
//			_fontListBox = new FontListBox();
//			_fontListBox.SelectedIndexChanged += OnfontListBoxSelectedIndexChanged;
//			_fontListBox.Size = new Size(200, Height);
//			Controls.Add(_fontListBox);
//
//			_fontSizeListBox = new ListBox();
//			_fontSizeListBox.Location = new Point(_fontListBox.Width, 0);
//
//			Controls.Add(_fontSizeListBox);
//		}
//
//		private void OnfontListBoxSelectedIndexChanged(object sender, EventArgs e)
//		{
//			_fontSizeListBox.Items.Clear();
//			Font font = _fontListBox.SelectedItem as Font;
//			if (font != null)
//			{
//				foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
//				{
//					if (font.FontFamily.IsStyleAvailable(style))
//					{
//						_fontSizeListBox.Items.Add(style);
//					}
//				}
//			}
//		}
//	}

}
