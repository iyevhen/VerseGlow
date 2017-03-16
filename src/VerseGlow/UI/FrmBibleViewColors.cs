using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VerseGlow.UI
{
	public partial class FrmBibleViewColors : Form
	{
		public FrmBibleViewColors()
		{
			InitializeComponent();

			verseView1.ReadOnly = true;
		}

		private void FrmBibleViewColors_Load(object sender, EventArgs e)
		{
			var strings = new List<string>
			{
				@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla at mi porta turpis facilisis tempor at vel massa. Proin quis posuere augue. Sed tellus nisl, facilisis quis ante ut, interdum eleifend erat. Mauris sit amet neque quis eros elementum convallis eget eu nibh. Donec at metus tincidunt, auctor leo vel, lobortis augue. Morbi adipiscing semper quam eget porttitor. Nulla eu sollicitudin justo. Praesent pharetra enim at luctus mattis. Nunc non pellentesque eros. Nullam feugiat eleifend ligula vel consectetur. Praesent fringilla feugiat dolor, quis rhoncus justo laoreet et.",
				@"Curabitur eleifend, augue vitae euismod rhoncus, justo elit posuere ipsum, non tincidunt urna nisi nec arcu. Proin a tincidunt lacus, eu fringilla nisi. Sed bibendum tortor odio, ut porta leo luctus at. Nam ac urna nibh. Praesent pretium ipsum at nisl imperdiet facilisis. Praesent dictum, erat tristique posuere blandit, urna tellus porttitor purus, a adipiscing metus felis eget nulla. Aliquam vitae massa rhoncus, adipiscing dolor hendrerit, consequat ligula. Nullam consectetur interdum egestas. Vestibulum mattis porta nunc sit amet pretium. Nullam egestas lacinia libero, non blandit ante ultrices eget."
			};

//			List<VerseItem> items = new List<VerseItem> { new VerseItem()};
//			verseView1.Fill(items);
//			verseView1.SelectedIndex(0);
//			verseView1.SetFocusedItem(1);
//			verseView1.HighlightText = "ipsum";
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
			DialogResult = DialogResult.OK;
		}
	}
}
