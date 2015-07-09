using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Application = Microsoft.Office.Interop.PowerPoint.Application;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;

namespace VerseFlow.UI
{
    public partial class FrmImportPowerPoint : Form
    {
        public FrmImportPowerPoint()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file;

            using (var dialog = new OpenFileDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog(this))
                {
                    file = dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            Application powerpointApp = null;
            Presentation presentation = null;
            var builder = new StringBuilder();

            try
            {
                powerpointApp = new Application();
                presentation = powerpointApp.Presentations.Open(file,
                    MsoTriState.msoTrue, WithWindow: MsoTriState.msoFalse);

                foreach (Slide slide in presentation.Slides)
                {
                    builder.AppendLine("*******");
                    foreach (Shape shape in slide.Shapes)
                    {
                        try
                        {
                            TextRange trange = shape.TextFrame.TextRange;
                            builder.AppendLine(trange.Text);
                        }
                        catch (Exception ee)
                        {
                            Debug.WriteLine(ee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                builder.Append(ex);
            }
            finally
            {
                if (presentation != null)
                    presentation.Close();

                if (powerpointApp != null)
                    powerpointApp.Quit();
            }

            textBox1.Text = builder.ToString();
        }
    }
}
