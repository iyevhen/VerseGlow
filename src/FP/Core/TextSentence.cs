namespace FreePresenter.Core
{
	public abstract class TextSentence : TextBlock
	{
		private static readonly TextBlock[] Empty = new TextBlock[0];

		protected TextSentence(int number, string text)
			: base(number, text)
		{
		}

		public override TextBlock this[string childName]
		{
			get { return null; }
		}

		public override TextBlock[] Children { get { return Empty; } }

		public override int ChildrenCount { get { return 0; } }

		protected override void AddChild(TextBlock child)
		{
			throw new InvalidTextSentenceOperationException("Cannot add text block to sentence block");
		}

		protected override void RemoveChild(TextBlock child)
		{
			throw new InvalidTextSentenceOperationException("Cannot remove child text blcok from sentence block");
		}
	}

	class InvalidTextSentenceOperationException : FreePresenterException
	{
		public InvalidTextSentenceOperationException(string message)
			: base(message)
		{ }
	}
}