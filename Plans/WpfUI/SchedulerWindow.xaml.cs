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
using PlansLib;
using PlansLib.Objects;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for .xaml
    /// </summary>
    public partial class SchedulerWindow : Window
    {
        public DateTime SelectedDate { get; set; }
        public User User { get; set; }

        public SchedulerWindow(User user)
        {
            User = user;
            InitializeComponent();
            UserName.Text = user.FirstName;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string date;
            try
            {
                //shows popup window of selected date
                date = Plans1.SelectedDate.Value.Date.ToString();
            }
            catch (Exception ex)
            {
                date = DateTime.Now.ToString();
            }

            SelectedDate = DateTime.Parse(date);
            List<Plan> plans = new List<Plan>();
            plans = Controller.LoadPlans(SelectedDate);

            PlansTextBlock.Clear();

            foreach (Plan plan in plans)
            {
                PlansTextBlock.Text += plan.ToString() + "\n";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button should save Plan to User Profile", "Merge User Profile");
        }

        private void MakeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedDate = Plans1.SelectedDate.Value.Date;
            }
            catch (Exception ex)
            {
                SelectedDate = DateTime.Now;
            }
            PlanCreator planCreator = new PlanCreator(User, SelectedDate);
            planCreator.Show();

        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            MapsWindow mapsWindow = new MapsWindow(User);
            this.Hide();
            mapsWindow.Show();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWIndow = new ProfileWindow(User);
            this.Hide();
            profileWIndow.Show();
        }

        private void PlansButton_Click(object sender, RoutedEventArgs e)
        {
            PlansWindow plansWindow = new PlansWindow(User);
            this.Hide();
            plansWindow.Show();
        }
    }
}
