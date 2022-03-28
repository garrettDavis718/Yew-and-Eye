using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlansLib;


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
        /// <summary>
        /// Login Button click event method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;
            User user = new User(email, password);
            MessageBox.Show(SecurityOps.HashString(password));
            MessageBox.Show(Controller.LoadUser(user).ToString());
        }

        private void Create_User_Button_Click(object sender, RoutedEventArgs e)
        {

            CreateUserWindow createUserWindow = new CreateUserWindow();
            this.Hide();
            createUserWindow.ShowDialog();

        }
    }
}
