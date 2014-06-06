using System;
using System.Windows.Forms;
using VerseFlow.Mvp.Core;

namespace VerseFlow.Mvp.Views.CommandBindings
{
	public class ControlCommandBinding : PresenterCommandBinding<Control>
	{
		public ControlCommandBinding(Control control, PresenterCommand command)
			: base(control, command)
		{
			control.Click += ControlClick;
		}

		private void ControlClick(object sender, EventArgs e)
		{
			Command.Execute(null);
		}
	}

	public class ToolStripMenuItemCommandBinding : PresenterCommandBinding<ToolStripMenuItem>
	{
		public ToolStripMenuItemCommandBinding(ToolStripMenuItem menuItem, PresenterCommand presenterCommand)
			: base(menuItem, presenterCommand)
		{
			menuItem.Click += (sender, args) => Command.Execute(null);
		}

		protected override void OnCommandCanExecuteChanged()
		{
			Target.Enabled = Command.CanExecute();
		}
	}

	public class ToolStripButtonCommandBinding : PresenterCommandBinding<ToolStripButton>
	{
		public ToolStripButtonCommandBinding(ToolStripButton toolStripButton, PresenterCommand presenterCommand)
			: base(toolStripButton, presenterCommand)
		{
			toolStripButton.Click += (sender, args) => Command.Execute(null);
		}

		protected override void OnCommandCanExecuteChanged()
		{
			Target.Enabled = Command.CanExecute();
		}
	}
}