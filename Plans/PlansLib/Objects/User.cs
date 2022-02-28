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
		/// <summary>
		/// object for users.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <param name="passwordHash">password hash associated with user.</param>
		public User (string email, string passwordHash)
		{
			Email = email;
			PasswordHash = passwordHash;
		}

		/// <summary>
		/// email address associated with user.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// password hash associated with user.
		/// </summary>
		public string PasswordHash { get; set; }
		
		/// <summary>
		/// list to plans currently created by user 
		/// </summary>
		public string items { get; set; }

	}
}
