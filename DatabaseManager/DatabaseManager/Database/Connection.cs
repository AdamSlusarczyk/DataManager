using DatabaseManager.Model.Database;
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
            MySqlCommand command = new("SELECT * FROM " + selectedTable + ";", connection);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new(command);
            adapter.Fill(result);
            return result;
        }

        internal static bool TryDeleteCascade()
        {
            throw new NotImplementedException();
        }

        internal static bool TryDelete(string tableName, string tablePrimaryKeyName, string rowID, out string outMessage)
        {
            if (String.IsNullOrEmpty(tablePrimaryKeyName))
            {
                outMessage = "Selected table does not have primary key.";
                return false;
                //TODO: add deleting by combination of column values.
            }
            else
            {
                MySqlCommand command = new("DELETE FROM " + tableName + " WHERE " + tablePrimaryKeyName + " = " + rowID + ";", connection);
                var result = command.ExecuteReader();
                outMessage = "Operation complete. Affected rows: " + result.RecordsAffected;
                result.Close();
                return true;
            }
        }

        public static ColumnInfoCollection GetColumnsInfo(string selectedTable)
        {
            ColumnInfoCollection columnInfoCollection = new();
            MySqlCommand command = new("SHOW columns FROM " + selectedTable, connection);
            MySqlDataReader result = command.ExecuteReader();
            ColumnInfo newElement;

            while (result.Read())
            {
                newElement = new();
                newElement.ColumnName = (string)result.GetValue(0);
                newElement.ColumnType = (string)result.GetValue(1);
                if (result.GetString(2) == "YES")
                    newElement.Nullable = true;
                else
                    newElement.Nullable = false;
                if ((string)result.GetValue(3) == "PRI")
                    newElement.KeyType = KeyTypeEnum.PRIMARY;
                else if ((string)result.GetValue(3) == "MUL")
                    newElement.KeyType = KeyTypeEnum.FOREIGN;
                else
                    newElement.KeyType = KeyTypeEnum.NONE;

                columnInfoCollection.ColumnInfoList.Add(newElement);
            }
            result.Close();
            return columnInfoCollection;
        }

        internal static void MakeTemp(string selectedTable, out int index, string message)
        {
            index = 0;
        }
    }
}

// connection string do bazy danych
// Server=localhost;Database=mydatabase;Uid=admin; Password=password;