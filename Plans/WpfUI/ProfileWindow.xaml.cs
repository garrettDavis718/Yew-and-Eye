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
        //The object retrieves the data from the create profile class
        public ProfileWindow(CreateProfile createProfile)
        {
            InitializeComponent();
            
            //the data store in the properties will display in the labels and textblock
            userNameLabel.Content = createProfile.FirstName + " " + createProfile.LastName + ", " + createProfile.Age;
            cityLabel.Content = createProfile.City;
            bioTextBlock.Text = createProfile.Bio;
        }

        //This will display the main window when the welcome To Plans button is clicked 
        private void welcomeToPlansButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            PlansWindow mainWindow = new PlansWindow(newUser);
            mainWindow.Show();
        }


    }
}

