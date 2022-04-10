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
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        public UserProfile(CreateProfile createProfile)
        {
            InitializeComponent();

            //This will display the user input 
            fNameLabel.Content = createProfile.FirstName;
            lNameLabel.Content = createProfile.LastName;
            ageLabel.Content = createProfile.Age;
            cityLabel.Content = createProfile.City;
            bioLabel.Content = createProfile.Bio;

        }

        private void welcomeToPlansButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
           
                MainWindow mainWindow = new MainWindow(newUser);
                mainWindow.Show();
        }


    }
}

