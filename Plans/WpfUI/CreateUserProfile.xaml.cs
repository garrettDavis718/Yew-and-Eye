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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for CreateUserProfile.xaml
    /// </summary>
    public partial class CreateUserProfile : Window
    {
        public CreateUserProfile()
        {
            InitializeComponent();
        }

        private void createProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //The cursor will start in the first name textbox. Tab to the next textbox
            firstNameTextBox.Focus();
            lastNameTextBox.Focus();
            ageTextBox.Focus();
            cityTextBox.Focus();
            bioTextBox.Focus();

            //Object will get and set the information inputted in to each textbox in the Create User Profile window
            CreateProfile createProfile = new CreateProfile();

            createProfile.FirstName = firstNameTextBox.Text;
            createProfile.LastName = lastNameTextBox.Text;
            createProfile.Age = int.Parse(ageTextBox.Text);
            createProfile.City = cityTextBox.Text;
            createProfile.Bio = bioTextBox.Text;

            //Will display the user profile window
            UserProfile userProfile = new UserProfile(createProfile);
            this.Hide();
            userProfile.ShowDialog();


        }

    }
}

