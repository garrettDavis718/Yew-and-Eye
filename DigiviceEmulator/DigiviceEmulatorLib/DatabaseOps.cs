using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// sqlite database class.
	/// </summary>
	public static class DatabaseOps
	{
		/// <summary>
		/// open connection to database.
		/// </summary>
		/// <param name="databasePath">path to database, used for creating
		/// connection string.</param>
		/// <returns>true if successful. false otherwise.</returns>
		public static bool OpenConnection()
		{
			string connectionString = $"Data Source={Path.GetFullPath(DatabasePath)}";
			Connection = new SQLiteConnection(connectionString);
			Connection.Open();
			return Connection.State is ConnectionState.Open;
		}

		/// <summary>
		/// close connection to database.
		/// </summary>
		/// <returns>true if successful. false otherwise.</returns>
		public static bool CloseConnection()
		{
			if (Connection.State is ConnectionState.Open)
			{
				Connection.Close();
				return Connection.State is ConnectionState.Closed;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// create entry in user table.
		/// </summary>
		/// <param name="user">user to be stored.</param>
		/// <returns>true if successful, false otherwise.</returns>
		public static bool CreateUser(User user)
		{
			string query = $"INSERT INTO user (email, password_hash) VALUES ('{user.Email}', '{user.PasswordHash}');";
			return InsertQuery(query) is 1;
		}

		/// <summary>
		/// update password in user table.
		/// </summary>
		/// <param name="user">user to be updated.</param>
		/// <returns>true if successful, false otherwise.</returns>
		public static bool UpdateUser(User user)
		{
			string query = $"UPDATE user SET password_hash = '{user.PasswordHash}' WHERE email = '{user.Email}';";
			return UpdateQuery(query) is 1;
		}

		/// <summary>
		/// delete entry from user table.
		/// </summary>
		/// <param name="user">user to be removed.</param>
		/// <returns>true if successful, false otherwise.</returns>
		public static bool DeleteUser(User user)
		{
			string query = $"DELETE FROM user WHERE email = '{user.Email}' AND password_hash = '{user.PasswordHash}';";
			return DeleteQuery(query) is 1;
		}

		/// <summary>
		/// set monster attribute in db table. 
		/// </summary>
		/// <param name="attribute">monster attribute to set.</param>
		/// <param name="value">value to insert into attribute.</param>
		/// <returns>true if successful, false if not. </returns>
		public static bool SetMonsterAttribute(Monster.Attributes attribute, int value)
		{
			string query = $"UPDATE monster SET {attribute} = {value};";
			return UpdateQuery(query) is 1;
		}

		/// <summary>
		/// set monster attribute in db table. 
		/// </summary>
		/// <param name="attribute">monster attribute to set.</param>
		/// <param name="value">value to insert into attribute.</param>
		/// <returns>true if successful, false if not. </returns>
		public static bool SetMonsterAttribute(Monster.Attributes attribute, string value)
		{
			string query = $"UPDATE monster SET {attribute} = '{value}';";
			return UpdateQuery(query) is 1;
		}

		/// <summary>
		/// set monster attribute in db table. 
		/// </summary>
		/// <param name="attribute">monster attribute to set.</param>
		/// <param name="value">value to insert into attribute.</param>
		/// <returns>true if successful, false if not. </returns>
		public static bool SetMonsterAttribute(Monster.Attributes attribute, DateTime value)
		{
			string query = $"UPDATE monster SET {attribute} = '{value}';";
			return UpdateQuery(query) is 1;
		}

		/// <summary>
		/// get monster attribute from db table.
		/// </summary>
		/// <typeparam name="T">int, string, or DateTime.</typeparam>
		/// <param name="attribute">monster attribute to get.</param>
		/// <returns>attribute as text, int, or DateTime.</returns>
		public static dynamic GetMonsterAttribute<T>(Monster.Attributes attribute)
		{
			string query = $"SELECT {attribute} FROM monster;";
			using (SQLiteDataReader dataReader = SelectQuery(query))
			{
				if (dataReader.Read())
				{
					if ((int)attribute < 2)
					{
						return dataReader.GetString(0);
					}
					else if ((int)attribute < 7)
					{
						return dataReader.GetInt32(0);
					}
					else
					{
						return DateTime.Parse(dataReader.GetString(0));
					}
				}
				else
				{
					return "RECORD NOT FOUND.";
				}
			}
		}

		/// <summary>
		/// get password hash for selected user using email.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <returns>password hash associated with user.</returns>
		public static string GetPasswordHash(string email)
		{
			string output = string.Empty;
			string query = $"SELECT password_hash FROM user WHERE email = '{email}';";
			using (SQLiteDataReader dataReader = SelectQuery(query))
			{
				while (dataReader.Read())
				{
					output = dataReader.GetString(0);
				}
			}
			return output;
		}

		/// <summary>
		/// execute update query on database. 
		/// </summary>
		/// <param name="query">SQLite update query to execute.</param>
		/// <returns>number of rows updated by query.</returns>
		private static int UpdateQuery(string query)
		{
			int updatedRowCount = 0;
			// var to hold # of updated rows. used to check for successful 
			// updates.

			using (SQLiteCommand command = new SQLiteCommand(query, Connection))
			{
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter { UpdateCommand = command })
				{
					updatedRowCount = adapter.UpdateCommand.ExecuteNonQuery();
				}
			}
			// create command object & data adapter object using command obj &
			// execute query. stores updated row count to confirm row is
			// successfully udpated. all database objects used are
			// automatically disposed of. 

			return updatedRowCount;
			// return number of updated rows.
		}

		/// <summary>
		/// execute insert query on database.
		/// </summary>
		/// <param name="query">SQLite query to be executed.</param>
		/// <returns>number of rows inserted.</returns>
		private static int InsertQuery(string query)
		{
			int insertedRowCount = 0;
			// var to hold # of inserted rows. used to check for successful 
			// insertions.

			using (SQLiteCommand command = new SQLiteCommand(query, Connection))
			{
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter { InsertCommand = command })
				{
					insertedRowCount = adapter.InsertCommand.ExecuteNonQuery();
				}
			}
			// create command object & data adapter object using command obj &
			// execute query. stores inserted row count to confirm row is
			// successfully inserted. all database objects used are
			// automatically disposed of. 

			return insertedRowCount;
			// return number of inserted rows.
		}

		/// <summary>
		/// execute delete query on database.
		/// </summary>
		/// <param name="query">sqlite query to be executed.</param>
		/// <returns>number of rows deleted.</returns>
		private static int DeleteQuery(string query)
		{
			int deletedRowCount = 0;
			// var to hold # of deleted rows. used to check for successful 
			// deletions.

			using (SQLiteCommand command = new SQLiteCommand(query, Connection))
			{
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter { DeleteCommand = command })
				{
					deletedRowCount = adapter.DeleteCommand.ExecuteNonQuery();
				}
			}
			// create command object & data adapter object using command obj &
			// execute query. stores deleted row count to confirm row is
			// successfully deleted. all database objects used are
			// automatically disposed of. 

			return deletedRowCount;
			// return number of deleted rows.
		}

		/// <summary>
		/// execute select query on database.
		/// </summary>
		/// <param name="query">SQLite query to execute.</param>
		/// <returns>SQLiteDataReader object.</returns>
		private static SQLiteDataReader SelectQuery(string query)
		{
			using (SQLiteCommand command = new SQLiteCommand(query, Connection))
			{
				return command.ExecuteReader();
			}
		}

		/// <summary>
		/// relative path to database.
		/// </summary>
		public static string DatabasePath { get; set; } = @"../../DigiviceDB.db";

		/// <summary>
		/// sql connection obj to be used in queries.
		/// </summary>
		private static SQLiteConnection Connection { get; set; }
	}
}