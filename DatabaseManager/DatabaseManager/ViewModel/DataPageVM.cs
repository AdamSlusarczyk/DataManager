using DatabaseManager.Model.Database;
using DatabaseManager.View.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DatabaseManager.ViewModel
{
    public class DataPageVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> tableNames;
        public ObservableCollection<string> TableNames { get { return tableNames; } set { if (tableNames != value) tableNames = value; OnPropertyChanged("TableNames"); } }
        private DataTable dataTable;
        public DataTable DataTable { get { return dataTable; } set { if (dataTable != value) dataTable = value; OnPropertyChanged("DataTable"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DataPageVM()
        {
            TableNames = new ObservableCollection<string>();
            DataTable = new DataTable();
        }

        internal void DeleteRecord(string selectedTableName, object selectedRecord)
        {
            string message;
            var columnInfo = Connection.Connection.GetFieldInfo(selectedTableName, out message);
            
            if(columnInfo.FieldInfoList.Count == 0)
                MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {
                if (columnInfo.GetPrimaryKeysColumns().Count == 0)
                { //TODO
                    message = "Could not delete record. Reason:\nSelected table does not have primary key.\nComing soon.";
                }

                else if (columnInfo.GetPrimaryKeysColumns().Count == 1)
                {
                    if (Connection.Connection.TryDelete(selectedTableName, columnInfo.GetPrimaryKeysColumns()[0].FieldName, ((DataRowView)selectedRecord).Row[0].ToString(), out message))
                        MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Information);

                    else
                        MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                { //TODO
                    message = "Could not delete record. Reason:\nSelected table have multiple primary keys.\nComing soon.";
                }
            }
        }

        internal bool CanModify(string selectedTableName, out string message)
        {
            {
                var columnInfo = Connection.Connection.GetFieldInfo(selectedTableName, out message);
                if(columnInfo.FieldInfoList.Count == 0)
                    return false;
                
                if (columnInfo.GetPrimaryKeysColumns().Count == 0)
                {//TODO
                    message = "Cannot modify record. Reason:\nSelected table does not have primary key.\nComing soon.";
                    return false;
                }
                else if (columnInfo.GetPrimaryKeysColumns().Count == 1)
                {
                    message = "";
                    return true;
                }
                else
                {//TODO
                    message = "Cannot modify record. Reason:\nSelected table have multiple primary keys.\nComing soon.";
                    return false;
                }
            }
        }

        internal void RefreshTableNames()
        {
            //refresh TableNames
            TableNames.Clear();
            var tableNames = Connection.Connection.GetTableNames(out string message);
            if (tableNames.Count == 0)
                MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                foreach (string name in tableNames)
                    TableNames.Add(name);
            }
        }

        internal void RefreshData(string selectedTable)
        {
            DataTable.Clear();
            DataTable = Connection.Connection.GetData(selectedTable, out string message);
            if (DataTable.Rows.Count == 0)
                MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
