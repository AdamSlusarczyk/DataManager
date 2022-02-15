using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DatabaseManager.Model.Database
{
    public class RowInfo : INotifyPropertyChanged
    {
        ObservableCollection<FieldInfo> fieldInfoList;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RowInfo()
        {
            fieldInfoList = new();
        }

        public ObservableCollection<FieldInfo> FieldInfoList
        {
            get
            {
                return fieldInfoList;
            }
            set
            {
                if (fieldInfoList != value)
                {
                    fieldInfoList = value;
                    OnPropertyChanged("ColumnInfoList");
                }
            }
        }


        public List<FieldInfo> GetPrimaryKeysColumns()
        {
            return (fieldInfoList.Where(n => n.KeyType == KeyTypeEnum.PRIMARY)).ToList<FieldInfo>();
        }
    }
}
