using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Connection
{
    static class Connection
    {
        public static string ConnectionString { get; set; }
        public static string Message { get; private set; }
        public static MySqlConnection connection;
        public static bool TryConnect()
        {
            try
            {
                connection = new MySqlConnection(ConnectionString);
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Message = "Error occured. Exception code:\n " + e.Message;
                return false;
            }
        }
    }
}

// connection string do bazy danych
// Server=localhost;Database=mydatabase;Uid=admin;Pwd=password;