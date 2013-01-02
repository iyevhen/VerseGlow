using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FreePresenter.Core;
using VerseFlow.Properties;

namespace FreePresenter.UI.UserControls
{
	public partial class TextViewerControl : UserControl
	{
		private readonly TextBlock text;
		private ImageList images;
		private VerseSeparator navigatorVerseSeparator;
		private VerseSeparator searchVerseSeparator;
		private TreeNodeProvider treeProvider;
		private TextBlock selectedSearchTextBlock;

		private const TextFormatFlags tff =
			TextFormatFlags.VerticalCenter
			| TextFormatFlags.WordEllipsis
			| TextFormatFlags.EndEllipsis
			| TextFormatFlags.SingleLine
			| TextFormatFlags.NoPadding;

		public TextViewerControl(TextBlock text)
		{
			Is.NotNull(text, "bible");
			this.text = text;

			InitializeComponent();
			InitializeComponentCustom();
		}

		public TreeNodeProvider TreeProvider
		{
			get { return treeProvider; }
			set
			{
				treeProvider = value;

				try
				{
					if (treeProvider == null)
						return;

//					treeProvider.Fill(tree, text);
//					tree.SelectedNode = tree.Nodes[0];
				}
				finally
				{
//					tree.EndUpdate();
//					tree.Refresh();
				}
			}
		}

		public string CurrentText
		{
			get
			{
				if (listViewVerses.SelectedIndices.Count > 0)
					return ((TextBlock)listViewVerses.Items[listViewVerses.SelectedIndices[0]].Tag).Text;

				return string.Empty;
			}
		}

		public ToolStripRenderer Renderer
		{
			get { return bar.Renderer; }
			set { bar.Renderer = value; }
		}

		private void InitializeComponentCustom()
		{
			images = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
			images.Images.Add(Resources.book16);
			images.Images.Add(Resources.song16);

//			tree.ImageList = images;

			listViewSearchResults.VirtualMode = true;
			listViewSearchResults.VirtualListSize = 0;
			listViewSearchResults.RetrieveVirtualItem += listViewSearchResults_RetrieveVirtualItem;

			listViewSearchResults.OwnerDraw = true;
			listViewSearchResults.DrawColumnHeader += listView_DrawColumnHeader;
			listViewSearchResults.DrawItem += listView_DrawItem;
			listViewSearchResults.DrawSubItem += listView_DrawSubItem;

			listViewVerses.VirtualMode = true;
			listViewVerses.VirtualListSize = 0;
			listViewVerses.RetrieveVirtualItem += listViewVerses_RetrieveVirtualItem;

			listViewVerses.OwnerDraw = true;
			listViewVerses.DrawColumnHeader += listView_DrawColumnHeader;
			listViewVerses.DrawItem += listView_DrawItem;
			listViewVerses.DrawSubItem += listView_DrawSubItem;
		}

		void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			//			using (var brush = new SolidBrush(listViewVerses.BackColor))
			//				e.Graphics.FillRectangle(brush, e.Bounds);

			// draw item/subitem text
			bool selected = (e.ItemState & ListViewItemStates.Selected) != 0 || e.Item.Tag == selectedSearchTextBlock;

			if (selected)
			{
				e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
				e.Item.Focused = true;
			}

			var text = e.ColumnIndex == 0 ? e.Item.Text : e.SubItem.Text;

			var matches = e.SubItem.Tag as List<TextMatch>;
			var hasNoMatches = matches == null;

			bool isFromSearch = e.Item.ListView == listViewSearchResults;

			if (e.ColumnIndex == 0 || (isFromSearch && e.ColumnIndex == 1))
			{
				TextRenderer.DrawText(e.Graphics,
				text,
				e.Item.Font,
				e.Bounds,
				selected ? SystemColors.HighlightText : Color.Gray,
				tff);

				return;
			}

			if (hasNoMatches)
			{
				TextRenderer.DrawText(e.Graphics,
				text,
				e.Item.Font, e.Bounds,
				selected ? SystemColors.HighlightText : e.Item.ForeColor,
				tff);

				return;
			}

			var initSize = e.Bounds.Size;
			Point cursorGraphic = e.Bounds.Location;
			int cursorText = 0;

			foreach (var match in matches)
			{
				int subLength = match.From - cursorText;

				if (subLength > 0)
				{
					string sub = text.Substring(cursorText, subLength);
					Size size = TextRenderer.MeasureText(e.Graphics, sub, e.Item.Font, initSize, tff);
					size.Height = initSize.Height;

					var rect = new Rectangle(cursorGraphic, size);
					TextRenderer.DrawText(e.Graphics, sub, e.Item.Font, rect, selected ? SystemColors.HighlightText : e.Item.ForeColor, tff);

					cursorGraphic.X += size.Width;
					initSize.Width -= size.Width;
				}

				string matchTxt = text.Substring(match.From, match.Length);
				Size matchSize = TextRenderer.MeasureText(e.Graphics, matchTxt, e.Item.Font, initSize, tff);
				matchSize.Height = initSize.Height;

				var matchRect = new Rectangle(cursorGraphic, matchSize);
				e.Graphics.FillRectangle(selected ? Brushes.LightSkyBlue : Brushes.LightYellow, matchRect);
				TextRenderer.DrawText(e.Graphics, matchTxt, e.Item.Font, matchRect, selected ? Color.ForestGreen : Color.Red, tff);

				cursorGraphic.X += matchSize.Width;
				initSize.Width -= matchSize.Width;

				cursorText = match.To;
			}

			if (cursorText < text.Length)
			{
				var rect = new Rectangle(cursorGraphic, initSize);
				TextRenderer.DrawText(e.Graphics, text.Substring(cursorText), e.Item.Font, rect, selected ? SystemColors.HighlightText : e.Item.ForeColor, tff);
			}
		}

		void listView_DrawItem(object sender, DrawListViewItemEventArgs e) { }

		void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void listViewSearchResults_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			TextBlock v = searchVerseSeparator.GetVerse(e.ItemIndex);

			int i = e.ItemIndex + 1;
			e.Item = new ListViewItem(i.ToString()) { Tag = v };

			e.Item.SubItems.Add(v.Link);
			e.Item.SubItems.Add(v.Text).Tag = searchVerseSeparator.GetMatch(v);
		}

		private void listViewVerses_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			TextBlock v = navigatorVerseSeparator.GetVerse(e.ItemIndex);

			int i = e.ItemIndex + 1;
			e.Item = new ListViewItem(i.ToString()) { Tag = v };
			e.Item.SubItems.Add(v.Text);
		}

		private void listViewSearchResults_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewSearchResults.SelectedIndices.Count > 0)
			{
				var selectedIndex = listViewSearchResults.SelectedIndices[0];
				selectedSearchTextBlock = (TextBlock)listViewSearchResults.Items[selectedIndex].Tag;
				TreeNode tn = treeProvider.GetNode(selectedSearchTextBlock.Parent);
//				tree.SelectedNode = tn;
			}
		}

		private void listViewVerses_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView.SelectedIndexCollection indexes = listViewVerses.SelectedIndices;

			if (indexes.Count > 0)
			{
				selectedSearchTextBlock = null;

				columnVersesText.Text = navigatorVerseSeparator.GetVerse(indexes[0]).Link;
				listViewVerses.Refresh();

				var builder = new StringBuilder();

				foreach (int index in indexes)
					builder.AppendLine(navigatorVerseSeparator.GetVerse(index).Text);

				OnOnSelectedTextChanged(builder);
			}
		}

		public event Action<StringBuilder> OnSelectedTextChanged;

		private void OnOnSelectedTextChanged(StringBuilder builder)
		{
			Action<StringBuilder> handler = OnSelectedTextChanged;
			if (handler != null)
				handler(builder);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			searchVerseSeparator = new VerseSeparator(cbSearchText.Text)
			{
				IgnoreCase = tsCaseSensative.Checked,
				MatchSctrictWord = tsStrictWord.Checked
			};

			text.EnumerateWith(searchVerseSeparator);
			listViewSearchResults.VirtualListSize = searchVerseSeparator.VersesCount;

			listViewSearchResults.Refresh();
			tsBtnSearchResults.Checked = true;

			if (searchVerseSeparator.VersesCount > 0 && !cbSearchText.Items.Contains(cbSearchText.Text))
				cbSearchText.Items.Add(cbSearchText.Text);
		}

		private void tsStrictWord_Clicked(object sender, EventArgs e)
		{
			tsAnyWord.Checked = !tsStrictWord.Checked;
		}

		private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
//			var selectedBlock = (TextBlock)tree.SelectedNode.Tag;
			navigatorVerseSeparator = new VerseSeparator();
//			selectedBlock.EnumerateWith(navigatorVerseSeparator);

//			columnSearchVerse.Text = selectedBlock.Link;
			listViewVerses.VirtualListSize = navigatorVerseSeparator.VersesCount;
			listViewVerses.Refresh();
		}

		private void tsBtnFont_Click(object sender, EventArgs e)
		{
			using (var fd = new FontDialog())
			{
				fd.Font = listViewSearchResults.Font;
				fd.ShowEffects = false;

				if (DialogResult.OK == fd.ShowDialog(this))
				{
					listViewSearchResults.Font = fd.Font;
					listViewVerses.Font = fd.Font;
				}
			}
		}

		private void tsSearchResults_CheckedChanged(object sender, EventArgs e)
		{
			tsBtnSearchResults.Image = tsBtnSearchResults.Checked
										? Resources.toggle_minus
										: Resources.toggle_plus;

			listViewSearchResults.Visible = tsBtnSearchResults.Checked;
			splitterHorisontal.Visible = tsBtnSearchResults.Checked;
		}

		private void cbSearchText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				btnSearch_Click(sender, e);
				e.Handled = true;
			}
		}
	}
}
