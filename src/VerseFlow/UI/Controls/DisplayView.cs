using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls
{
	public partial class DisplayView : UserControl
	{
		public DisplayView()
		{
			InitializeComponent();
			Load += DisplayView_Load;
		}

		public Size LiveDisplaySize
		{
			get { return display1.Etalon; }
			set { display1.Etalon = value; }
		}

		void DisplayView_Load(object sender, EventArgs e)
		{
			
		}
	}
}
