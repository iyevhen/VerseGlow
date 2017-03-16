using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Eto.Forms;

using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using Form = System.Windows.Forms.Form;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using TextBox = System.Windows.Forms.TextBox;

namespace EtoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Get native control for the panel
            // passing true so that we can embed, otherwise we just get a reference to the control
            var nativeView = new MyEtoPanel().ToNative(true);
            // set where we want it, size, dock attributes, etc.
            nativeView.Location = new Point(100, 100);
            //nativeView.Dock = DockStyle.Fill;

            Controls.Add(nativeView);
        }
    }

    
}
