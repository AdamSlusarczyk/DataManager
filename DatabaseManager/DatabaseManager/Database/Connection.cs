using MySql.Data.MySqlClient;
using System;

namespace DatabaseManager.Connection
{
    static class Connection
    {
        public static string Message { get; private set; }
        private static MySqlConnection connection;
        private static string ConnectionString { get; set; }
        public static bool TryConnect(string connectionString)
        {
            try
            {
                ConnectionString = connectionString;
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
        internal static void Disconnect()
        {
            connection.Close();
            ConnectionString = "";
        }
    }
}

// connection string do bazy danych
// Server=localhost;Database=mydatabase;Uid=admin;Pwd=password;