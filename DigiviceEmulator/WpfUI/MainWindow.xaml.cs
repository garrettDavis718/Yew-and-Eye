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
            InitializeComponent();
            Monster monster;
            /*
            TextBlock_Hunger.Text = "0";
            TextBlock_Hygiene.Text = "0";
            Textblock_Mood.Text = "0";
            TextBlock_Output.Text = " ";
            */
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

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
