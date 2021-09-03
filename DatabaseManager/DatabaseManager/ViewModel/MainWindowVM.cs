using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DatabaseManager.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        string address;
        public string Address 
        {
            get { return address; }
            set
            {
                if(address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
