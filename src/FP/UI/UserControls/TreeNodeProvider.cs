using System.Collections.Generic;
using System.Windows.Forms;
using FreePresenter.Core;

namespace FreePresenter.UI
{
	public abstract class TreeNodeProvider
	{
		protected readonly int imageIndex;
		protected readonly Dictionary<TextBlock, TreeNode> nodes = new Dictionary<TextBlock, TreeNode>();

		protected TreeNodeProvider(int imageIndex)
		{
			this.imageIndex = imageIndex;
		}

		public int ImageIndex
		{
			get { return imageIndex; }
		}

		public virtual TreeNode GetNode(TextBlock textBlock)
		{
			if (textBlock == null)
				return null;

			TreeNode node;
			return nodes.TryGetValue(textBlock, out node) ? node : null;
		}

		public abstract void Fill(TreeView tree, TextBlock text);
	}

	class BibleTreeProvider : TreeNodeProvider
	{
		public BibleTreeProvider(int imageIndex) : base(imageIndex) { }

		public override void Fill(TreeView tree, TextBlock text)
		{
			foreach (var book in text.Children)
			{
				var bookNode = new TreeNode(book.Link, imageIndex, imageIndex) { Tag = book };
				tree.Nodes.Add(bookNode);
				nodes.Add(book, bookNode);

				foreach (var chap in book.Children)
				{
					var chapNode = new TreeNode(chap.Link, imageIndex, imageIndex) { Tag = chap };
					bookNode.Nodes.Add(chapNode);
					nodes.Add(chap, chapNode);
				}
			}
		}
	}

	class SongsTreeProvider : TreeNodeProvider
	{
		public SongsTreeProvider(int imageIndex) : base(imageIndex) { }

		public override void Fill(TreeView tree, TextBlock text)
		{
			foreach (var song in text.Children)
			{
				var songNode = new TreeNode(string.Format("{0} - {1}", song.Id, song.Text),
					imageIndex, imageIndex)
				{
					Tag = song
				};

				tree.Nodes.Add(songNode);
				nodes.Add(song, songNode);
			}
		}
	}
}