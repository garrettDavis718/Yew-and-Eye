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
        }

        private void CreatePlanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text != string.Empty && LocationBox.Text != string.Empty)
            {
                Plan plan = new Plan(DescriptionBox.Text, DateTime, LocationBox.Text, User.UserID);
                if (Controller.CreatePlan(plan))
                {
                    MessageBox.Show("Plan created for :" + plan.Date);
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
    }
}
