using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlansLib
{
	/// <summary>
	/// object for users.
	/// </summary>
	public class User
	{

		public User()
		{

		}
		public User(string email, string password)
		{
			Email = email;
			PasswordHash = SecurityOps.HashString(password);
		}
		/// <summary>
		/// object for users.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <param name="passwordHash">password hash associated with user.</param>
		public User(string email, string password, string first_name, string last_name)
		{
			Email = email;
			PasswordHash = SecurityOps.HashString(password);
			FirstName = first_name;
			LastName = last_name;
		}
		/// <summary>
		/// object for users.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <param name="passwordHash">password hash associated with user.</param>
		public User (string email, string password, string first_name, string last_name, int userID)
		{
			Email = email;
			PasswordHash = SecurityOps.HashString(password);
			FirstName = first_name; 
			LastName = last_name;
			UserID = userID;
		}
		/// <summary>
		/// User object for use in program, doesn't pass arorund the password hash
		/// </summary>
		/// <param name="email"></param>
		/// <param name="first_name"></param>
		/// <param name="last_name"></param>
		public User(string email, string first_name, string last_name, int userid)
		{
			Email = email;
			FirstName = first_name;
			LastName = last_name;
			UserID = userid;
		}
		/// <summary>
		/// Fields and Properties
		/// </summary>
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int UserID { get; set; }

	}
}
