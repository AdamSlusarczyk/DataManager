using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

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
        internal void AddRecord()
        {
            throw new NotImplementedException();
        }

        internal void DeleteRecord(object selectedItem, out string message)
        {
            throw new NotImplementedException();
        }

        internal void ModifyRecord(object selectedItem, out string message)
        {
            throw new NotImplementedException();
        }

        internal void RefreshTableNames()
        {
            //refresh TableNames
            TableNames.Clear(); 
            foreach(string name in Connection.Connection.GetTableNames())
                TableNames.Add(name);
        }

        internal void RefreshData(string selectedTable)
        {
            DataTable.Clear();
            DataTable = Connection.Connection.GetData(selectedTable);
        }
    }
}
