using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DatabaseManager.Model.Database
{
    class ColumnInfoCollection : INotifyPropertyChanged
    {
        ObservableCollection<ColumnInfo> columnInfoList;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ColumnInfoCollection()
        {
            columnInfoList = new();
        }

        public ObservableCollection<ColumnInfo> ColumnInfoList
        {
            get
            {
                return columnInfoList;
            }
            set
            {
                if (columnInfoList != value)
                {
                    columnInfoList = value;
                    OnPropertyChanged("ColumnInfoList");
                }
            }
        }


        public List<ColumnInfo> GetPrimaryKeysColumns()
        {
            return (columnInfoList.Where(n => n.KeyType == KeyTypeEnum.PRIMARY)).ToList<ColumnInfo>();
        }
    }
}
