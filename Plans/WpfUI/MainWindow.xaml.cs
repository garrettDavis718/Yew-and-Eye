using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlansLib;

namespace WpfUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(User user)
		{
				
			InitializeComponent();
			UserLbl.Content = user.FirstName + " " + user.LastName;
		}

        private void CreatePlansBtn_Click(object sender, RoutedEventArgs e)
        {
			MapsWindow mapsWindow = new MapsWindow();
			mapsWindow.Show();
        }
    }
}
