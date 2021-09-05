using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data;

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

        public static ObservableCollection<string> GetTableNames()
        {
            MySqlCommand command = new("SHOW Tables", connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            ObservableCollection<string> result = new();

            while (dataReader.Read())
                result.Add((string)dataReader.GetValue(0));
                  
            dataReader.Close();
            return result;
        }

        internal static DataTable GetData(string selectedTable)
        {
            DataTable result = new();
            MySqlCommand command = new MySqlCommand("SELECT * FROM " + selectedTable + ";", connection);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(result);
            return result;
        }
    }
}

// connection string do bazy danych
// Server=localhost;Database=mydatabase;Uid=admin;Pwd=password;