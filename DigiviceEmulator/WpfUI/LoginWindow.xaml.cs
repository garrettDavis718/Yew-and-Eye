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
using DigiviceEmulatorLib;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            this.Hide();
            createUserWindow.ShowDialog();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;
            if (Controller.Login(email, password) == true)
            {
                MessageBox.Show("Logged in as " + email);          
                //Controller.user = new User(email, SecurityOps.HashString(password));
                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to login");
            }
        }

        private void Create_User_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            this.Hide();
            createUserWindow.ShowDialog();
        }
    }
}
