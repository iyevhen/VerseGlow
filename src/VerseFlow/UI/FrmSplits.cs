using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TableSplitControl;

namespace VerseFlow.UI
{
	public partial class FrmSplits : Form
	{
		private TableSplitPanel table;

		public FrmSplits()
		{
			InitializeComponent();

			SuspendLayout();

			// На форме есть 4 контрола, которые нужно вставить в TableSplitPanel.
			// Соберем их в массив 2x2:
			Control[,] controls = new Control[2, 2]
			{
				{ new BibleView(), new DataGrid() }, 
				{ new ListView(), new TextBox() }
			};

			// Вызовем конструктор TableSplitPanel
			table = new TableSplitPanel(controls,
				new[] { new TableSplitControl.RowStyle(SizeMode.Relative, 0.2), new TableSplitControl.RowStyle() },
				new[] { new TableSplitControl.ColumnStyle(SizeMode.Relative, 0.4), new TableSplitControl.ColumnStyle() },
				BorderStyle.Fixed3D);
			table.Dock = DockStyle.Fill;

			// Можно задать названия панелей
			table.Panels[0, 0].Caption = "aasdasd";
			table.Panels[1, 0].Caption = "Панель";
			table.Panels[1, 1].Caption = "Контрол";
			// Добавим TableSplitPanel на форму.
			Controls.Add(table);

			table.BringToFront();

			ResumeLayout();
		}
	}
}
