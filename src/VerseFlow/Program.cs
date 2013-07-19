using System;
using System.Threading;
using System.Windows.Forms;
using VerseFlow.UI;

namespace VerseFlow
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.ThreadException += OnThreadException;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmMain());
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowThreadExceptionDialog(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            ShowThreadExceptionDialog((Exception)args.ExceptionObject);
        }

        private static void ShowThreadExceptionDialog(Exception exception)
        {
            using (var frm = new FrmException(exception))
            {
                var rsx = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
                frm.Icon = ((System.Drawing.Icon)(rsx.GetObject("$this.Icon")));


                frm.ShowDialog();
            }
        }
    }
}
