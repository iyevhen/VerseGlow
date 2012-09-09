using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FreePresenter.UI
{
	public partial class FrmAbout : Form
	{
		public FrmAbout()
		{
			InitializeComponent();
			lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			linkLabelWeb.Links.Add(0, linkLabelWeb.Text.Length, linkLabelWeb.Text);
			linkLabelIcons.Links.Add(0, linkLabelIcons.Text.Length, linkLabelIcons.Text);
			linkLabelEmail.Links.Add(0, linkLabelEmail.Text.Length, linkLabelEmail.Text);
		}

		private void linkLabelWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
		}

		private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(string.Format("mailto:{0}", e.Link.LinkData));
		}
	}
}
