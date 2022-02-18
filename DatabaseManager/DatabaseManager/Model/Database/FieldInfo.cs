using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DatabaseManager.Model.Database
{
    public class FieldInfo : INotifyPropertyChanged
    {
        string fieldName;
        string fieldType;
        string fieldValue;
        bool nullable;
        KeyTypeEnum keyType;
        string defaultValue;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public string FieldName
        {
            set
            {
                fieldName = value;
                OnPropertyChanged("ColumnName");
            }
            get
            {
                return fieldName;
            }
        }
        public string FieldType
        {
            set
            {
                fieldType = value;
                OnPropertyChanged("ColumnType");
            }
            get
            {
                return fieldType;
            }
        }
        public string FieldValue
        {
            set
            {
                fieldValue = value;
                OnPropertyChanged("ColumnValue");
            }
            get
            {
                return fieldValue;
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

        public string GetDefaultValHint
        {
            set
            {

            }
            get
            {
                if (String.IsNullOrEmpty(defaultValue))
                    return "Field does not have default value.";
                else
                    return "Fields default value is set to: " + DefaultValue;
            }
        }
    }

    public enum KeyTypeEnum
    {
        PRIMARY, FOREIGN, NONE
    };
}
