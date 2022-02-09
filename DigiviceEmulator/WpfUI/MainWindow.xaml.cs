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
using DigiviceEmulatorLib;

namespace WpfUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
            Monster monster;              
            InitializeComponent();
            /*if (monster == null)         
            {
                //TODO - code monster egg system here
            }
            else
            {
                monster =  *grab users monster from their database*
            }
            */
		}
        
        //TODO - add functionality to buttons as their functions are made
        private void Button_Click_Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Dance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Clean_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Feed_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
