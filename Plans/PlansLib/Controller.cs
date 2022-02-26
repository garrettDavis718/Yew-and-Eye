using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public static bool CreateUser(string email, string password)
		{
			string passwordHash = SecurityOps.HashString(password);

			if (DatabaseOps.OpenConnection())
			{
				bool result = DatabaseOps.CreateUser(new User(email,
															  passwordHash));
				DatabaseOps.CloseConnection();
				return result;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Method to load user from userdb
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static void LoadUser(User user)
		{
			if (DatabaseOps.OpenConnection())
			{
				string passwordHash = DatabaseOps.GetPasswordHash(user);
			}
		}
	}
}
