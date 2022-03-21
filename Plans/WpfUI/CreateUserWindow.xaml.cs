using System;
using PlansLib;
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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for the Create New User Button, currently has some messageBoxes attached for testing purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User(CreateEmailBox.Text,
                                    CreatePassBox.Password);
            if (CreatePassBox.Password == ConfirmCreatePassBox.Password)
            {
                if (Controller.CreateUser(newUser))
                {
                    MessageBox.Show("User " + newUser.Email);
                }
                else
                {
                    MessageBox.Show("Cannot Create User");
                }
            }
            else
            {
                MessageBox.Show("Password and Cofirm Password Do not match");
                CreatePassBox.Clear();
                ConfirmCreatePassBox.Clear();
            }
        }

        /// <summary>
        /// Back Button method, takes user back to login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.ShowDialog();
        }
    }
}
