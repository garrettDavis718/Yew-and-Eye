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
            SelectedDate = DateTime.Now;
            DateSelect.Text = DateTime.Now.ToString();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(1);
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
            plans = Controller.LoadPlans(SelectedDate.ToShortDateString());

            PlansBox.Items.Clear();

            if (plans.Count > 0)
            {
                PlansBox.Items.Add("Plans for " + date + ":\n");
                foreach (Plan plan in plans)
                {
                    PlansBox.Items.Add(plan.ToString());
                }
            }
            else
            { PlansBox.Items.Add("No plans for : " + date); }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<Plan> plans = Controller.LoadPlans(SelectedDate.ToShortDateString());
            try
            {
                string chosenPlan = PlansBox.SelectedItem.ToString();
                foreach (Plan plan in plans)
                {
                    if (plan.ToString().Equals(chosenPlan))
                    {
                        User.Plans += plan.PlanID.ToString() + ",";
                        plan.Users += User.UserID.ToString() + ",";
                        try
                        {
                            Controller.UpdateUserPlans(User);
                            Controller.UpdatePlanUsers(plan);
                            MessageBox.Show(chosenPlan + "\nSaved!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a plan before saving.");
            } 
        }

        private void MakeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedDate = DateTime.Parse(DateSelect.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Date/Time Input");
            }
            PlanCreator planCreator = new PlanCreator(User, SelectedDate);
            this.Hide();
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
