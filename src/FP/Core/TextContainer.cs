using System;
using System.Collections.Generic;
using FreePresenter.Core;
using FreePresenter.Convertion;

namespace FreePresenter.Core
{
	public abstract class TextContainer<T> : TextContainer
		where T : TextBlock
	{
		protected TextContainer(string text) : base(text) { }
		protected TextContainer(int id, string text) : base(id, text) { }

		protected override void AddChild(TextBlock block)
		{
			if (!typeof(T).IsAssignableFrom(block.GetType()))
				throw TextBlockException.InvalidTextBlock(typeof(T).Name, block.GetType().Name);

			base.AddChild(block);
		}

		protected override void RemoveChild(TextBlock block)
		{
			if (!typeof(T).IsAssignableFrom(block.GetType()))
				throw TextBlockException.InvalidTextBlock(typeof(T).Name, block.GetType().Name);

			base.RemoveChild(block);
		}

		public override TextBlock this[string name]
		{
			get
			{
				TextBlock child;
				return children.TryGetValue(name, out child) ? child : null;
			}
		}

		public override void EnumerateWith(ITextEnumerator enumerator)
		{
			if (ChildrenCount <= 0)
				return;

			foreach (var child in Children)
			{
				if (enumerator.Break)
					return;

				child.EnumerateWith(enumerator);
			}
		}
	}

	public abstract class TextContainer : TextBlock
	{
		protected readonly Dictionary<string, TextBlock> children = new Dictionary<string, TextBlock>(StringComparer.OrdinalIgnoreCase);

		protected TextContainer(string text)
			: base(text)
		{
		}

		protected TextContainer(int id, string text)
			: base(id, text)
		{
		}

		public override int ChildrenCount
		{
			get { return children.Count; }
		}

		protected override void AddChild(TextBlock block)
		{
			try
			{
				if (block.Id == -1)
					children.Add(block.Text, block);
				else
					children.Add(block.Id.ToString(), block);

				if (block.Parent != null)
					block.Parent.Remove(block);
			}
			catch (ArgumentException)
			{
				throw new NameCollisionException(this, block);
			}
		}

		protected override void RemoveChild(TextBlock block)
		{
			children.Remove(block.Text);
		}

		public override TextBlock[] Children
		{
			get
			{
				var result = new TextBlock[children.Count];
				children.Values.CopyTo(result, 0);
				return result;
			}
		}
	}

	class NameCollisionException : TextBlockException
	{
		public NameCollisionException(TextBlock parent, TextBlock added) :
			base(string.Format("There is already exists an object with id [{0}] in [{1}]", added.Id, parent.Link)) { }
	}
}