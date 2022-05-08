using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlansLib.Objects
{
    //Plan Object Class
    public class Plan
    {   
        //Fields and properties
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public int UserID { get; set; }
        public int PlanID { get; set; }
        public string Users { get; set; }
        public string City { get; set; }

        public Plan()
        {
            
        }
        /// <summary>
        /// Plan Creation Object
        /// </summary>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="location"></param>
        /// <param name="userid"></param>
        public Plan(string description, string date, string time, string location, int userid, string users, string city)
        {
            Description = description;
            Date = date;
            Time = time;
            Location = location;
            UserID = userid;
            Users = users;
            City = city;
        }
        /// <summary>
        /// Plan Retrieval Object
        /// </summary>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="location"></param>
        /// <param name="userid"></param>
        /// <param name="planid"></param>
        public Plan(string description, string date, string time, string location, int userid, int planid, string users, string city)
        {
            Description = description;
            Date = date;
            Location = location;
            UserID = userid;
            PlanID = planid;
            Users = users;
            City = city;
        }
        public override string ToString()
        {
            string creatorUsername = Controller.GetUsername(this.UserID);
            return this.Description + "\n" + "Location: " + this.Location + "\n" + "Date: " + this.Date + " at " + this.Time + "\nCreated By: " + creatorUsername;
        }
    }
}
