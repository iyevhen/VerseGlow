using VerseFlow.Common;

namespace VerseFlow.Mvp.Core
{
	public abstract class PresenterCommandBinding<T> where T : class
	{
		private readonly PresenterCommand command;
		private readonly T target;

		protected PresenterCommandBinding(T target, PresenterCommand command)
		{
			Is.NotNull(target, "target");
			Is.NotNull(command, "command");

			this.target = target;
			this.command = command;
			this.command.CanExecuteChanged += (sender, args) => OnCommandCanExecuteChanged();
		}

		public T Target
		{
			get { return target; }
		}

		public PresenterCommand Command
		{
			get { return command; }
		}

		protected virtual void OnCommandCanExecuteChanged() { }
	}

	// USAGE SAMPLE
	//	 public class Form1 : Form
	//{
	//  
	//  // ----------------------------------------------------------------------
	//  public Form1()
	//  {      
	//    new ToolStripMenuItemCommandBinding( italicToolStripMenuItem, italicCommand );
	//    new ToolStripButtonCommandBinding( italicToolStripButton, italicCommand );
	//  
	//    this.italicCommand.IsChecked = false;
	//    //this.italicCommand.IsAvailable = false; // test disabled state
	//  } // Form1
	//  
	//  // ----------------------------------------------------------------------
	//  // members
	//  private CheckedCommand italicCommand = new CheckedCommand();
	//  
	//} // class Form1

}