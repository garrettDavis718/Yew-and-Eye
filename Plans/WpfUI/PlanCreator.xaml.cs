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
using PlansLib;
using PlansLib.Objects;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for PlanCreator.xaml
    /// </summary>
    public partial class PlanCreator : Window
    {
        public User User { get; set; }
        public DateTime DateTime { get; set; }

        public PlanCreator(User user, DateTime dateTime)
        {
            User = user;
            DateTime = dateTime;
            InitializeComponent();
            DateSelect.Text = dateTime.ToString();
        }

        private void CreatePlanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text != string.Empty && LocationBox.Text != string.Empty)
            {
                Plan plan = new Plan(DescriptionBox.Text, DateTime.ToShortDateString(), DateTime.ToShortTimeString(), LocationBox.Text, User.UserID, User.UserID.ToString() + ",", User.City);
                if (Controller.CreatePlan(plan))
                {
                    MessageBox.Show("Plan created for :" + plan.Date);
                    SchedulerWindow schedulerWindow = new SchedulerWindow(User);
                    this.Hide();
                    schedulerWindow.Show();
                }
                else 
                {
                    MessageBox.Show("Error");
                }
            }
            else 
            {
                MessageBox.Show("Error, You must provide a Location and Description.");
            }
        }

        private void CreatePlanBtn_Copy_Click(object sender, RoutedEventArgs e)
        {            
            SchedulerWindow schedulerWindow = new SchedulerWindow(User);
            this.Close();
            schedulerWindow.Show();
        }
    }
}
