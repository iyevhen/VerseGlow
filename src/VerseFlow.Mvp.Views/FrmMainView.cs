using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VerseFlow.Mvp.Core;
using VerseFlow.Mvp.Views.Base;

namespace VerseFlow.Mvp.Views
{
	public partial class FrmMainView : ViewForm<IFrmMainPresenter>, IFrmMainView
	{
		public FrmMainView()
		{
			InitializeComponent();
		}

		public void AddChildView(IView view)
		{
			
		}

		public void RemoveChildView(IView view)
		{
			throw new NotImplementedException();
		}
	}
}
