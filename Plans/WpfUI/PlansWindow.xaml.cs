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

		public PlansWindow(User user)
		{
			User = user;
			InitializeComponent();
			UserLbl.Content = User.FirstName + " " + User.LastName;
			UserPlans = Controller.LoadPlans(user);
			foreach (Plan plan in UserPlans)
			{
				Plan_Created.Items.Add(plan.ToString());
			}
		}

        private void CreatePlansBtn_Click(object sender, RoutedEventArgs e)
        {
			MessageBox.Show(User.FirstName);
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
