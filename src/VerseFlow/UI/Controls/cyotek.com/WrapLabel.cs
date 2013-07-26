using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VerseFlow.UI.Controls.cyotek.com
{
    public class WrapLabel : Label
    {
        public WrapLabel()
        {
            this.AutoSize = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.FitToContents();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            this.FitToContents();
        }

        protected virtual void FitToContents()
        {
            Size size = this.GetPreferredSize(new Size(this.Width, 0));
            this.Height = size.Height;
        }

        [DefaultValue(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
    }
}