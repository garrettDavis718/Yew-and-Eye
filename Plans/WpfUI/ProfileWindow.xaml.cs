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
using System.Windows.Shapes;
using PlansLib.Objects;
using PlansLib;
using WpfUI.Properties;

namespace WpfUI
{
    /// <summary>
    /// Display the user's Profile
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public User User { get; set; }
        //The object retrieves the data from the create profile class
        public ProfileWindow(User user)
        {
            User = user;
            InitializeComponent();
            //the data store in the properties will display in the labels and textblock
            userNameLabel.Content = User.FirstName + " " + User.LastName;
            cityLabel.Content = User.City;
            bioTextBlock.Text = User.Bio;
        }

        //This will display the main window when the welcome To Plans button is clicked 
        private void welcomeToPlansButton_Click(object sender, RoutedEventArgs e)
        {
            PlansWindow mainWindow = new PlansWindow(User);
            this.Hide();
            mainWindow.Show();
        }


    }
}

