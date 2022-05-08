using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlansLib.Objects;

namespace PlansLib
{
	/// <summary>
	/// Controller Class to control the logic of the program
	/// </summary>
    public class Controller
    {
		/// <summary>
		/// Create User Method for creating and saving a user into the db
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static bool CreateUser(User user)
		{
			string passwordHash = SecurityOps.HashString(user.PasswordHash);

			if (DatabaseOps.OpenConnection())
			{
				if (DatabaseOps.GetPasswordHash(user).Equals(string.Empty))
				{
					
					bool result = DatabaseOps.CreateUser(user);
					DatabaseOps.CloseConnection();
					return result;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// Updates the user's plans property
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static bool UpdateUserPlans(User user)
		{
			if (DatabaseOps.OpenConnection())
			{
				bool results = DatabaseOps.UpdateUserPlans(user);
				DatabaseOps.CloseConnection();
				return results;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// Updates the plan's user property
		/// </summary>
		/// <param name="plan"></param>
		/// <returns></returns>
		public static bool UpdatePlanUsers(Plan plan)
		{
			if (DatabaseOps.OpenConnection())
			{
				bool results = DatabaseOps.UpdatePlanUsers(plan);
				DatabaseOps.CloseConnection();
				return results;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Method to Write Create Plan
		/// </summary>
		/// <param name="plan"></param>
		/// <returns></returns>
		public static bool CreatePlan(Plan plan)
		{
			if (DatabaseOps.OpenConnection())
			{
				bool results = DatabaseOps.WritePlan(plan);
				DatabaseOps.CloseConnection();
				return results;
			}
			else { return false; }
		}

		/// <summary>
		/// Method to load user from userdb
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static User LoadUser(User user)
		{
			bool results = false;
			User output = new User();
			if (DatabaseOps.OpenConnection())
			{
				string passwordHash = DatabaseOps.GetPasswordHash(user);
				results = SecurityOps.VerifyHash(passwordHash, user.PasswordHash);
				if (results == false)
				{
					output = null;
				}
				else
				{
					output = DatabaseOps.GetUser(user);
				}
			}
			DatabaseOps.CloseConnection();
			return output;
		}
		/// <summary>
		/// Method to get the username from a given userid
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		public static string GetUsername(int userid)
		{
			string output = "";
			if (DatabaseOps.OpenConnection())
			{
				try
				{
					output = DatabaseOps.GetUsername(userid);
				}
				catch (Exception ex)
				{
					output = "no username available";
				}
			}
			DatabaseOps.CloseConnection();
			return output;
		}
		//Load Plan From Date
		public static List<Plan> LoadPlans(string date)
		{
			List<Plan> plans = new List<Plan>();
			if (DatabaseOps.OpenConnection())
			{
				plans = DatabaseOps.GetPlans(date);
			}
			DatabaseOps.CloseConnection();

			return plans;
		}
		//Load Plan Overload(Load with userid)
		public static List<Plan> LoadPlans(int userid)
		{
			List<Plan> plans = new List<Plan>();
			if (DatabaseOps.OpenConnection())
			{
				plans = DatabaseOps.GetPlans(userid);
			}
			DatabaseOps.CloseConnection();

			return plans;
		}
		//Load Plan Overload(Load with userid)
		public static Plan LoadPlanFromPlanID(int planID)
		{
			Plan plan = new Plan();
			if (DatabaseOps.OpenConnection())
			{
				plan = DatabaseOps.GetPlansFromPlanID(planID);
			}
			DatabaseOps.CloseConnection();

			return plan;
		}
		public static List<Plan> LoadPlanFromCity(string city)
		{
			List<Plan> plans = new List<Plan>();
			if (DatabaseOps.OpenConnection())
			{
				plans = DatabaseOps.GetPlansFromCity(city);
			}
			DatabaseOps.CloseConnection();

			return plans;
		}







	}
}
