using DatabaseManager.ViewModel;
using System.Windows;


namespace DatabaseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVM MainWindowVM { get; set;}
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM = new MainWindowVM();
            this.DataContext = this;
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            Connection.Connection.ConnectionString = txtAddress.Text;
            if(Connection.Connection.TryConnect())
            {
                MessageBox.Show("OK", "KK", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
                MessageBox.Show(Connection.Connection.Message, "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            
        }
    }
}