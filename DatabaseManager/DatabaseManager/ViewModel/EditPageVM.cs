using DatabaseManager.Model.Database;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DatabaseManager.ViewModel
{
    class EditPageVM : INotifyPropertyChanged
    {
        RowInfo rowInfo;
        readonly string tableName;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RowInfo ColumnCollection
        {
            get
            {
                return rowInfo;
            }
            set
            {
                if (rowInfo != value)
                {
                    rowInfo = value;
                    OnPropertyChanged("ColumnCollection");
                }    
            }
        }

        public void FillWithDefaultValues()
        {
            foreach(FieldInfo columnInfo in ColumnCollection.FieldInfoList)
            {
                if (!string.IsNullOrEmpty(columnInfo.DefaultValue))
                    columnInfo.FieldValue = columnInfo.DefaultValue;
            }
        }

        public bool CheckAndFillWithDefaults(out string outMessage)
        {
            foreach(FieldInfo field in rowInfo.FieldInfoList)
            {
                if (String.IsNullOrEmpty(field.FieldValue))
                    if (!String.IsNullOrEmpty(field.DefaultValue))
                        field.FieldValue = field.DefaultValue;
                    else
                    {
                        outMessage = "Mandatory field " + field.FieldName + " is empty and does not have default value";
                        return false;
                    }                 
            }
            outMessage = "";
            return true;
        }

        public EditPageVM(string tableName, RowInfo columnCollection)
        {
            this.tableName = tableName;
            rowInfo = columnCollection;
        }

        internal bool ModifyRow()
        {
            if (!CheckAndFillWithDefaults(out string message))
            {
                MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }                
            else
            {
                bool modifyResult = Connection.Connection.Modify(tableName, rowInfo.GetPrimaryKeysColumns()[0].FieldName, rowInfo, out message);

                if (modifyResult)
                {
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }             
                else
                {
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }                  
            }    
        }

        internal bool InsertRow()
        {
            if (!CheckAndFillWithDefaults(out string message))
            {
                MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                bool insertResult = Connection.Connection.Insert(tableName, rowInfo, out message);
                
                if (insertResult)
                {
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
    }
}
