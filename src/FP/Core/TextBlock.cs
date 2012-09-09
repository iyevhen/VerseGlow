using FreePresenter.Core;

namespace FreePresenter.Core
{
	public abstract class TextBlock
	{
		int id;
		readonly string text;
		string link;
		protected TextBlock parent;
		protected string separator = ":";

		protected TextBlock() : this(string.Empty) { }
		protected TextBlock(string text) : this(-1, text) { }
		protected TextBlock(int id, string text)
		{
			this.id = id;
			this.text = text;
		}

		public string Text
		{
			get { return text; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public abstract TextBlock this[string name] { get; }

		public abstract TextBlock[] Children { get; }

		public abstract int ChildrenCount { get; }

		public TextBlock Parent
		{
			get { return parent; }
		}

		public virtual string Link
		{
			get
			{
				return link ?? (link = parent != null && !string.IsNullOrEmpty(parent.Link)
				? string.Format("{0}{1}{2}", parent.Link, separator, id)
				: id.ToString());
			}
		}

		public virtual string Description { get; set; }

		public virtual TextBlock Add(TextBlock block)
		{
			AddChild(block);
			block.parent = this;

			return this;
		}

		protected abstract void AddChild(TextBlock block);

		public virtual void Remove(TextBlock block)
		{
			RemoveChild(block);
			block.parent = null;
		}

		protected abstract void RemoveChild(TextBlock block);

		public virtual void Delete()
		{
			foreach (TextBlock text in Children)
			{
				text.Delete();
			}

			if (Parent != null)
				Parent.Remove(this);
		}

		public abstract void EnumerateWith(ITextEnumerator enumerator);
	}
}