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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class PlansWindow : Window
	{
		public User User { get; set; }
		public List<Plan> UserPlans { get; set; }
		public List<Plan> PlansAttending { get; set; }
		public List<Plan> AvailablePlans { get; set; }

		public PlansWindow(User user)
		{
			User = user;
			UserPlans = Controller.LoadPlans(User.UserID);
			PlansAttending = User.GetPlansAttending();
			AvailablePlans = User.GetAvailablePlans();
			InitializeComponent();
			UserLbl.Content = User.FirstName + " " + User.LastName;
			PopulatePlanBoxes();
		}

		/// <summary>
		/// Method to populate the various plan item boxes on this page.
		/// </summary>
		private void PopulatePlanBoxes()
		{
			
			foreach (Plan plan in UserPlans)
			{
				Plan_Created.Items.Add(plan.Description + "\n");
			}

			foreach (Plan plan in PlansAttending)
			{
				Plan_Booked.Items.Add(plan.Description + "\n");
			}
			foreach (Plan plan in AvailablePlans)
			{
				Plan_Available.Items.Add(plan.Description + "\n");
			}
		}

        private void CreatePlansBtn_Click(object sender, RoutedEventArgs e)
        {
			SchedulerWindow scheduler = new SchedulerWindow(User);
			this.Hide();
			scheduler.Show();
		}

        private void SearchPlansBtn_Click(object sender, RoutedEventArgs e)
        {
			MapsWindow mapsWindow = new MapsWindow(User);
			this.Hide();
			mapsWindow.Show();
		}

        private void ReturnProfileBtn_Click(object sender, RoutedEventArgs e)
        {
			ProfileWindow profileWindow = new ProfileWindow(User);
			this.Hide();
			profileWindow.ShowDialog();
		}
    }
}
