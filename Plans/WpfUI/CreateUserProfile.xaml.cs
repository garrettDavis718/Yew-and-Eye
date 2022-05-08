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
            //The cursor will start in the first name textbox. Tab to the next textbox
            firstNameTextBox.Focus();
        }

        private void createProfileButton_Click(object sender, RoutedEventArgs e)
        {

            //Object will get and set the information inputted in to each textbox in the Create User Profile window
            //CreateProfile createProfile = new CreateProfile();

            //createProfile.FirstName = firstNameTextBox.Text;
            //createProfile.LastName = lastNameTextBox.Text;
            //createProfile.City = cityTextBox.Text;
            //createProfile.Bio = bioTextBox.Text;

            if (passwordBox.Password == confirmPasswordBox.Password && firstNameTextBox.Text != String.Empty &&
                lastNameTextBox.Text != String.Empty && cityTextBox.Text != String.Empty &&
                passwordBox.Password != String.Empty)
            {
                User NewUser = new User();
                NewUser.FirstName = firstNameTextBox.Text;
                NewUser.LastName = lastNameTextBox.Text;
                NewUser.City = cityTextBox.Text;
                NewUser.Bio = bioTextBox.Text;
                NewUser.Email = emailTextBox.Text;
                NewUser.PasswordHash = SecurityOps.HashString(passwordBox.Password);
                NewUser.Username = userNameTextBox.Text;

                if (Controller.CreateUser(NewUser))
                {
                    MessageBox.Show("User " + NewUser.FirstName + " " + NewUser.LastName + " has been created!");
                    ProfileWindow userProfile = new ProfileWindow(NewUser);
                    this.Hide();
                    userProfile.ShowDialog();
                }
                else

                {
                    MessageBox.Show("User couldn't be created.");
                }
            }
            else { MessageBox.Show("Please ensure all fields are filled out and your passwords match!"); }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }
    }
}

