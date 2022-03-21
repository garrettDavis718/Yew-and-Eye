using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlansLib
{
	/// <summary>
	/// sqlite database class.
	/// </summary>
	public static class DatabaseOps
	{
		/// <summary>
		/// open connection to database.
		/// </summary>
		/// connection string.</param>
		/// <returns>true if successful. false otherwise.</returns>
		public static bool OpenConnection()
		{
			string connectionString = $"Data Source={GetDBPath()}";
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
		/// get password hash for selected user using email.
		/// </summary>
		/// <param name="email">email address associated with user.</param>
		/// <returns>password hash associated with user.</returns>
		public static string GetPasswordHash(User user)
		{
			string output = string.Empty;
			string query = $"SELECT password_hash FROM user WHERE email = '{user.Email}'";
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
		/// Database path string, return string path for db file
		/// </summary>
		public static string GetDBPath()
		{
			return Path.GetFullPath(@"..\PlansDB.db");			
		}
		/// <summary>
		/// sql connection obj to be used in queries.
		/// </summary>
		private static SQLiteConnection Connection { get; set; }
		
	}
}