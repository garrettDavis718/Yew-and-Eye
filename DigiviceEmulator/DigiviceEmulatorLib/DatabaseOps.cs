using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;

/*
 * This Class is created to house operations for our database(s)
*/
namespace DigiviceEmulatorLib
{
    public static class DatabaseOps
    {

        //Open Connection Method
        public static bool OpenConnection(string databasePath)
        {

            //Create connection string 
            string connectionString = $"Data Source ={Path.GetFullPath(databasePath)}";

            //Create Set Connection Object
            Connection = new SQLiteConnection(connectionString);

            //Open Connection
            Connection.Open();

            //Return connectionstate as open
            return Connection.State is ConnectionState.Open;
        }

        //Method for Closing Connection after query
        public static bool CloseConnection()
        {

            //If connection state is open
            if (Connection.State is ConnectionState.Open)
            {

                //Close connection
                Connection.Close();

                //Return connectionstate as closed
                return Connection.State is ConnectionState.Closed;
            }

            //else return false
            else
            {
                return false;
            }
        }

        //Method to query our database and return a list of output
        private static List<string> QueryDatabase(string query)
        {
            //declare output list to hold query results
            List<string> output = new List<string>();
            
            //Create command object using the query string and connection
            SQLiteCommand command = new SQLiteCommand(query, Connection);

            //Create data reader object to house query results
            SQLiteDataReader dataReader = command.ExecuteReader();

            //While loop to execute while we're still reading from databse
            while (dataReader.Read())
            {
                //read records and add values to output list
                output.Add(dataReader.GetString(0));
            }

            //close objects
            dataReader.Close();
            command.Dispose();

            //return results
            return output;
        }

        //Get and Set our SQLite ConnectionString
        private static SQLiteConnection Connection { get; set; }
    }
}
