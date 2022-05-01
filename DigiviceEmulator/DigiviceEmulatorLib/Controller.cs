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
			User.Email = email;
			User.PasswordHash = passwordHash;
			return User.Email == email && User.PasswordHash == passwordHash;
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
			storedHash = User.PasswordHash;
			enteredHash = SecurityOps.HashString(password);
			return email == User.Email && SecurityOps.VerifyHash(enteredHash, storedHash);
		}

		/// <summary>
		/// kill monster & send death certificate via email, replacing it with new egg.
		/// </summary>
		public static void Die()
		{
			const string DeathCertSubject = "",
						 DeathCertBody = "";

			EmailOps.SendEmail(subject: DeathCertSubject,
							   body: DeathCertBody,
							   recipients: new string[]{User.Email},
							   isBodyHtml: true);
			Controller.Reset();
		}

		/// <summary>
		/// replace current monster with new egg. 
		/// </summary>
		public static void Reset()
		{
			throw new NotImplementedException();
		}
	}
}
