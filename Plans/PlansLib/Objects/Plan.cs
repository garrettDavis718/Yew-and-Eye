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
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int UserID { get; set; }
        public int PlanID { get; set; }

        public Plan()
        {
            
        }
        public Plan(string description, DateTime date, string location, int userid)
        {
            Description = description;
            Date = date;
            Location = location;
            UserID = userid;
        }
        public Plan(string description, DateTime date, string location, int userid, int planid)
        {
            Description = description;
            Date = date;
            Location = location;
            UserID = userid;
            PlanID = planid;
        }
        public override string ToString()
        {
            return this.Description + "\n" + "Location: " + this.Location + "\n" + "Date: " + this.Date.ToString() + "\n";
        }
    }
}
