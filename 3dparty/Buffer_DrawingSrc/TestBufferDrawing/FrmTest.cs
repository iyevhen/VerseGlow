using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestBufferDrawing
{
    

    public partial class FrmTest : Form
    {
        static System.Random gen = new System.Random();
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            TmrBackground.Start();
            TmrRectangles.Start();
            TmrCircles.Start();
            usrcontrol.uselayers = false;
        }
        private void FrmTest_Resize(object sender, EventArgs e)
        {
            usrcontrol.Width = this.Width - usrcontrol.Left * 3;
            usrcontrol.Height = this.Height - usrcontrol.Top * 3;
        }
        private void TmrCircles_Tick(object sender, EventArgs e)
        {
            if (usrcontrol.dotwidth == 7)
                usrcontrol.dotwidth = 1;
            else
                usrcontrol.dotwidth++;
            LblTimePaint.Text = (usrcontrol.timeused.TotalMilliseconds / usrcontrol.paintiterations).ToString();
        }

        private void TmrBackground_Tick(object sender, EventArgs e)
        {
            int R = gen.Next(255);
            int G = gen.Next(255);
            int B = gen.Next(255);
            usrcontrol.ColorBackGround = Color.FromArgb(R, G, B);
        }

        private void TmrRectangles_Tick(object sender, EventArgs e)
        {
            int R = gen.Next(255);
            int G = gen.Next(255);
            int B = gen.Next(255);
            usrcontrol.ColorRectangle = Color.FromArgb(R, G, B);
        }

        private void ChkMultipleLayers_CheckedChanged(object sender, EventArgs e)
        {
            usrcontrol.uselayers = ChkMultipleLayers.Checked;
            usrcontrol.InitIter();
        }
    }
}
