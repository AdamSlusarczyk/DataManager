using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Model.Database
{
    class ColumnInfo : INotifyPropertyChanged
    {
        string columnName;
        string columnType;
        bool nullable;
        KeyTypeEnum keyType;
        string defaultValue;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public string ColumnName
        {
            set
            {
                columnName = value;
                OnPropertyChanged("ColumnName");
            }
            get
            {
                return columnName;
            }
        }
        public string ColumnType
        {
            set
            {
                columnType = value;
                OnPropertyChanged("ColumnType");
            }
            get
            {
                return columnType;
            }
        }
        public bool Nullable
        {
            set
            {
                nullable = value;
                OnPropertyChanged("Nullable");
            }
            get
            {
                return nullable;
            }
        }
        public KeyTypeEnum KeyType
        {
            set
            {
                keyType = value;
                OnPropertyChanged("KeyType");
            }
            get
            {
                return keyType;
            }
        }
        public string DefaultValue
        {
            set
            {
                defaultValue = value;
                OnPropertyChanged("DefaultValue");
            }
            get
            {
                return defaultValue;
            }
        }

    }

    public enum KeyTypeEnum
    {
        PRIMARY, FOREIGN, NONE
    };
}
