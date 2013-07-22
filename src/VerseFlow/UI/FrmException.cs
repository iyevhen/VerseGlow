using System;
using System.Text;
using System.Windows.Forms;
using VerseFlow.CrashReport;

namespace VerseFlow.UI
{
    public partial class FrmException : Form
    {
        private readonly Exception exception;
        private readonly ICrashReportSender crashReportSender;

        public FrmException(Exception exception, ICrashReportSender crashReportSender)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            this.exception = exception;
            this.crashReportSender = crashReportSender;

            InitializeComponent();

            if (crashReportSender == null)
            {
                btnSendCrashReport.Visible = false;
                AcceptButton = btnClose;
            }

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
            textException.Select(0,0);
        }

        private void btnSendCrashReport_Click(object sender, EventArgs e)
        {
            crashReportSender.Send(exception);
        }
    }
}
