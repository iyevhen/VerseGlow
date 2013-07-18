using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VerseFlow.UI
{
    public partial class FrmException : Form
    {
        public FrmException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            InitializeComponent();

            lblMessage.Text = exception.Message;

            Exception e = exception;
            var trace = new StringBuilder();

            while (e != null)
            {
                trace.AppendLine(e.ToString());
                e = e.InnerException;

                if (e != null)
                    trace.AppendLine("INNER:");
            }


            textException.Text = trace.ToString();
        }

        private void btnSendCrashReport_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
