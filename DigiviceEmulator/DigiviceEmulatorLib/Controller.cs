using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.Json;
using System.Text.Json.Serialization;

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
			Controller.Reset();
		}

		/// <summary>
		/// replace current monster with new egg. 
		/// </summary>
		public static void Reset()
		{
			Monster.DateOfBirth = DateTime.UtcNow;
			string query = "SELECT type, animation FROM bestiary WHERE type = 0;";
			if (DatabaseOps.OpenConnection())
			{
				if (DatabaseOps.GetEvolution(query, out int type, out string animations))
				{
					Monster.Type = (Monster.Types)type;
					Monster.Animations = JsonSerializer.Deserialize<AnimationSet>(animations);
				}
				DatabaseOps.CloseConnection();
			}
		}

		public static void Evolve()
		{
			bool entryFound = false;
			string query = $"SELECT type, animation FROM bestiary WHERE evolves_from = {(int)Monster.Type} AND req_health <= {Monster.Health} AND req_mood <= {Monster.Mood} AND req_hygiene <= {Monster.Hygiene} ORDER BY RANDOM() LIMIT 1;",
				   alternateQuery = "SELECT type, animation FROM bestiary WHERE type = 11;";
			if (DatabaseOps.OpenConnection())
			{
				if (DatabaseOps.GetEvolution(query, out int type, out string animations))
				{
					Monster.Type = (Monster.Types)type;
					Monster.Animations = JsonSerializer.Deserialize<AnimationSet>(animations);
				}
				else if (DatabaseOps.GetEvolution(alternateQuery, out int altType, out string altAnimations))
				{
					Monster.Type = (Monster.Types)altType;
					Monster.Animations = JsonSerializer.Deserialize<AnimationSet>(altAnimations);
				}
				DatabaseOps.CloseConnection();
			}
		}

		public static void Feed()
		{
			if ((int)Monster.Type > 0)
			{
				Monster.State = Monster.States.eating;
				Monster.HealthIncrements += 3;
			}
		}

		public static void Play()
		{
			if ((int)Monster.Type > 0)
			{
				Monster.State = Monster.States.playing;
				Monster.MoodIncrements += 3;
			}
		}

		public static void Clean()
		{
			if ((int)Monster.Type > 0)
			{
				Monster.HygieneIncrements += 3;
			}
		}

		public static void Dance()
		{
			if ((int)Monster.Type > 6
			   && (int)Monster.Type < 11)
			{
				Monster.State = Monster.States.dancing;
				Monster.HygieneIncrements += 3;
				Monster.HealthIncrements += 3;
				Monster.MoodIncrements += 3;
			}
		}
	}
}
