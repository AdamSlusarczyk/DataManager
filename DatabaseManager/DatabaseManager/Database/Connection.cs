using DatabaseManager.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

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

        public static ObservableCollection<string> GetTableNames(out string outMessage)
        {
            MySqlCommand command = new("SHOW Tables", connection);
            ObservableCollection<string> result = new();
            try
            {
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                    result.Add((string)dataReader.GetValue(0));

                dataReader.Close();
                outMessage = "OK";
                return result;
            }
            catch(Exception e)
            {
                outMessage = "Could not load data. Reason:\n" + e.Message;
                return result;
            }
        }

        internal static DataTable GetData(string selectedTable, out string outMessage)
        {
            DataTable result = new();
            MySqlCommand command = new("SELECT * FROM " + selectedTable + ";", connection);
            try
            {
                command.ExecuteNonQuery();
                MySqlDataAdapter adapter = new(command);
                adapter.Fill(result);
                outMessage = "OK";
                return result;
            }
            catch(Exception e)
            {
                outMessage = "Could not load data. Reason:\n" + e.Message;
                return result;
            }
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
                try
                {
                    MySqlCommand command = new("DELETE FROM " + tableName + " WHERE " + tablePrimaryKeyName + " = " + rowID + ";", connection);
                    var result = command.ExecuteReader();
                    outMessage = "Operation complete. Affected rows: " + result.RecordsAffected;
                    result.Close();
                    return true;
                }
                catch(Exception e)
                {
                    outMessage = "Could not delete data. Reason:\n" + e.Message;
                    return false;
                }
            }
        }

        internal static bool Modify(string tableName, string tablePrimaryKeyName, RowInfo row, out string outMessage)
        {
            string primaryKeyValue = row.FieldInfoList.Where(n => n.FieldName == tablePrimaryKeyName).ToArray()[0].FieldValue;
            string cmdText = "";
            cmdText = "UPDATE " + tableName + " SET ";

            for (int i = 0; i < row.FieldInfoList.Count; i++)
            {
                if (row.FieldInfoList[i].FieldName != tablePrimaryKeyName)
                    cmdText += row.FieldInfoList[i].FieldName + " = '" +  row.FieldInfoList[i].FieldValue + "'";

                if (i < row.FieldInfoList.Count - 1 && row.FieldInfoList[i].KeyType != KeyTypeEnum.PRIMARY)
                    cmdText += ", ";
            }

            cmdText += " WHERE " + tablePrimaryKeyName + " = " + primaryKeyValue + ";" ;

            MySqlCommand command = new(cmdText, connection);
            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    outMessage = "Data updated.";
                    return true;
                }
                else
                {
                    outMessage = "Could not modify data.";
                    return false;
                }
            }
            catch(Exception e)
            {
                outMessage = "Could not modify data. Reason:\n" + e.Message;
                return false;
            }
        }

        internal static bool Insert(string tableName, RowInfo rowInfo, out string outMessage)
        {
            string cmdText = "INSERT INTO " + tableName + " (";
            for (int i = 0; i < rowInfo.FieldInfoList.Count; i++)
            {
                cmdText += rowInfo.FieldInfoList[i].FieldName;

                if (i < rowInfo.FieldInfoList.Count - 1)
                    cmdText += ", ";
            }
            cmdText += ") VALUES (";

            for (int i = 0; i < rowInfo.FieldInfoList.Count; i++)
            {
                cmdText += "'" + rowInfo.FieldInfoList[i].FieldValue + "'";

                if (i < rowInfo.FieldInfoList.Count - 1)
                    cmdText += ", ";
            }
            cmdText += ");";

            MySqlCommand command = new(cmdText, connection);
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    outMessage = "Data inserted successfully";
                    return true;
                }

                else
                {
                    outMessage = "Could not insert data";
                    return false;
                }
            }
            catch(Exception e)
            {
                outMessage = "Could not insert data. Reason: \n" + e.Message;
                return false;
            }    
        }

        public static RowInfo GetFieldInfo(string selectedTable, out string outMessage)
        {
            RowInfo fieldInfoCollection = new();
            MySqlCommand command = new("SHOW columns FROM " + selectedTable, connection);
            try
            {
                MySqlDataReader result = command.ExecuteReader();
                FieldInfo newElement;

                while (result.Read())
                {
                    newElement = new();
                    newElement.FieldName = (string)result.GetValue(0);
                    newElement.FieldType = (string)result.GetValue(1);
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

                    fieldInfoCollection.FieldInfoList.Add(newElement);
                }
                result.Close();
                outMessage = "OK";
                return fieldInfoCollection;
            }
            catch(Exception e)
            {
                outMessage = "Could not load data. Reason:\n" + e.Message;
                return fieldInfoCollection;
            }
        }

        public static bool GetFieldValues(string selectedTable, string selectedKeyName, string selectedKeyValue, RowInfo fieldInfoCollection, out string outMessage)
        {
            MySqlCommand command = new("SELECT * FROM " + selectedTable + " WHERE " + selectedKeyName + " = " + selectedKeyValue + ";", connection);
            try
            {
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    for (int fieldNo = 0; fieldNo < result.FieldCount; fieldNo++)
                    {
                        if (!result.IsDBNull(fieldNo))
                            fieldInfoCollection.FieldInfoList[fieldNo].FieldValue = (result.GetString(fieldNo));
                    }
                }
                result.Close();
                outMessage = "OK";
                return true;
            }
            catch(Exception e)
            {
                outMessage = "Could not load data. Reason:\n" + e.Message;
                return false;
            }
        }
    }
}

// connection string do bazy danych
// Server=localhost;Database=mydatabase;Uid=admin; Password=password;