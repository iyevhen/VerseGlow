using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FreePresenter.Convertion;
using Verseflow.Import;

namespace Verseflow
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
//			var flatFile = new FlatFile<FlatBibleLine>(@"D:\rus_Bible.txt", Encoding.GetEncoding(1251), '\t');
			var flatFile = new FlatFile<FlatBibleLine>(@"D:\eng_Bible.txt", Encoding.UTF8, '\t');
			new FlatFileImporter().ImportWords(flatFile);
			new FlatFileImporter().ImportBible(flatFile);

			MessageBox.Show("Done");
		}
	}
}
