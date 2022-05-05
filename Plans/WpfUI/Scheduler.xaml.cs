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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for .xaml
    /// </summary>
    public partial class Scheduler : Window
    {
        public Scheduler()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            //shows popup window of selected date
            string date = Plans1.SelectedDate.Value.Date.ToString();
            DateTime planNOW = DateTime.Parse(date);

            //DateTime planNOW = DateTime.Today;

            // PLANS Placeholders til merge
            DateTime planONE = new DateTime(2022, 5, 4, 0, 0, 0);
            DateTime planTWO = new DateTime(2022, 5, 9, 0, 0, 0);
            DateTime planTHREE = new DateTime(2022, 5, 13, 0, 0, 0);
            DateTime planFOUR = new DateTime(2022, 5, 20, 0, 0, 0);

            int result = DateTime.Compare(planNOW, planONE);

            string relationship;
            Boolean plan = false;

            if (planNOW == planONE)
            {
                relationship = " There is a Plan for today!  ";
                plan = true;
                MessageBox.Show(relationship, "PLANS STATUS " + planNOW.ToShortDateString());

            }
            else if (planNOW == planTWO)
            {
                relationship = " There is a Plan for today!  ";
                plan = true;
                MessageBox.Show(relationship, "PLANS STATUS " + planNOW.ToShortDateString());
            }
            else if (planNOW == planTHREE)
            {
                relationship = " There is a Plan for today!  ";
                plan = true;
                MessageBox.Show(relationship, "PLANS STATUS " + planNOW.ToShortDateString());

            }
            else if (planNOW == planFOUR)
            {
                relationship = " There is a Plan for today!  ";
                plan = true;
                MessageBox.Show(relationship, "PLANS STATUS " + planNOW.ToShortDateString());

            }
            else
            {
                PlansTextBlock.Text = " There are no plans today ";
            }


            if (plan == true)
            {
                if (planNOW == planONE)
                {
                    PlansTextBlock.Text = "Plans for " + planONE.ToShortDateString() + "\n" + "\tUser: May Charle" + "\n" + "\tLocation: B & B Bowling" + "\n" + "\tTime: 12 - 3PM";

                }
                else if (planNOW == planTWO)
                {
                    PlansTextBlock.Text = "Plans for " + planTWO.ToShortDateString() + "\n" + "\tUser: Fred Flint" + "\n" + "\tLocation: Comics central" + "\n" + "\tTime: 3 - 4PM";
                }
                else if (planNOW == planTHREE)
                {
                    PlansTextBlock.Text = "Plans for " + planTHREE.ToShortDateString() + "\n" + "\tUser: June Race" + "\n" + "\tLocation: Parks Pier" + "\n" + "\tTime: 1 - 3PM";
                }
                else if (planNOW == planFOUR)
                {
                    PlansTextBlock.Text = "Plans for " + planFOUR.ToShortDateString() + "\n" + "\tUser: Susie Rink" + "\n" + "\tLocation: Kellies Krafts" + "\n" + "\tTime: 5 - 7PM";
                }

            }



        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button should save Plan to User Profile", "Merge User Profile");
        }

        private void MakeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button should let User make Plan", "Merge User Profile");
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button should let User return to Maps", "Merge Maps");
            MapsWindow mapsWindow = new MapsWindow();
            mapsWindow.Show();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button should let User return to Profile", "Merge User Profile");
            
            //MainWindow mainwindow = new MainWindow();
            //mainwindow.Show();
        }
    }
}
