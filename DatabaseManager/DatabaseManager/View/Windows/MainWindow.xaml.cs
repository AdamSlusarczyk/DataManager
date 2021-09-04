using DatabaseManager.View;
using DatabaseManager.View.Pages;
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
            if(Connection.Connection.TryConnect(txtAddress.Text))
            {
                this.Hide();
                (new WorkingWindow(this) {Content = new DataPage()}).Show();
            }
            else
                MessageBox.Show(Connection.Connection.Message, "Error", MessageBoxButton.OK,MessageBoxImage.Error);            
        }
    }
}