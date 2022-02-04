using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginControls
{
    public class Login
    {
        public static string CreateConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }
        public static string LoginToProgram(string username, string password)
        {
            
            List<string> user = new List<string>();
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                //var output = cnn.Query<string>("SELECT Username From Users", new DynamicParameters());
                var output = cnn.Query<string>("SELECT Username FROM Users WHERE Username Like @Name AND Password Like @Password", new { Name = username, Password = password });
                user = output.ToList();

                if (user.Count > 0)
                {
                    return user[0];
                }
                else
                {
                    return "no user";
                }
            }
            
        }
    }
}
