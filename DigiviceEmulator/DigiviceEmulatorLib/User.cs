using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// object for users.
	/// </summary>
	public static class User
	{
		/// <summary>
		/// user attributes.
		/// </summary>
		public enum Attributes
		{
			email,
			password_hash,
		}

		/// <summary>
		/// email address associated with user.
		/// </summary>
		public static string Email
		{
			get
			{
				string output = null;
				if (DatabaseOps.OpenConnection())
				{
					output = DatabaseOps.GetUserAttribute(User.Attributes.email);
					DatabaseOps.CloseConnection();
				}
				return output;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetUserAttribute(User.Attributes.email, value);
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// password hash associated with user.
		/// </summary>
		public static string PasswordHash
		{
			get
			{
				string output = null;
				if (DatabaseOps.OpenConnection())
				{
					output = DatabaseOps.GetUserAttribute(User.Attributes.password_hash);
					DatabaseOps.CloseConnection();
				}
				return output;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetUserAttribute(User.Attributes.password_hash, value);
					DatabaseOps.CloseConnection();
				}
			}
		}
	}
}
