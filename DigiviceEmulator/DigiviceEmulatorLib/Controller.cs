using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// class for controlling all game actions. all game logic is here. 
	/// </summary>
	public static class Controller
	{
		/// <summary>
		/// create user for application.
		/// </summary>
		/// <param name="email">email address to associate with user.</param>
		/// <param name="password">password to be hashed & associated with 
		/// user. password should NOT be hashed beforehand. all security 
		/// operations are handled internally.</param>
		/// <returns>true if user successfully created, false otherwise.</returns>
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
		/// delete user from application.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <param name="password">password to be hashed & associated with
		/// user. password should NOT be hashed beforehand. all security 
		/// operations are handled internally.</param>
		/// <returns>true if successful, false otherwise.</returns>
		public static bool DeleteUser(string email, string password)
		{
			string passwordHash = SecurityOps.HashString(password);
			if (DatabaseOps.OpenConnection())
			{
				bool result = DatabaseOps.DeleteUser(new User(email,
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
		/// update password hash for user associated with email address.
		/// </summary>
		/// <param name="email">email associated with user to update.</param>
		/// <param name="password">password to be hashed & saved. password
		/// should NOT be hashed beforehand. all security operations are 
		/// handled internally.</param>
		/// <returns>true if user successfully updated, false otherwise.</returns>
		public static bool UpdatePassword(string email, string password)
		{
			string passwordHash = SecurityOps.HashString(password);
			if (DatabaseOps.OpenConnection())
			{
				bool result = DatabaseOps.UpdateUser(new User(email,
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
		/// authorize user based on email & password. 
		/// </summary>
		/// <param name="email">email associated with user.</param>
		/// <param name="password">password to be hashed & compared with stored
		/// hash. password should NOT be hashed beforehand. all security 
		/// operations are handled internally.</param>
		/// <returns>true if user is authorized, false otherwise.</returns>
		public static bool Login(string email, string password)
		{
			string storedHash,
				   enteredHash;

			if (DatabaseOps.OpenConnection())
			{
				storedHash = DatabaseOps.GetPasswordHash(email);
				DatabaseOps.CloseConnection();
			}
			else
			{
				return false;
			}

			enteredHash = SecurityOps.HashString(password);
			return SecurityOps.VerifyHash(enteredHash, storedHash);
		}
	}
}
