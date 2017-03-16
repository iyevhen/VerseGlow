using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EtoForm
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // initialize eto forms after native app is initialized
            new Eto.Forms.Application(new Eto.WinForms.Platform()).Attach();

            Application.Run(new Form1());
        }
    }
}
