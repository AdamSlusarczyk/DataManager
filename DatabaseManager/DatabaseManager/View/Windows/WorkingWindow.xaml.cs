using System.Windows;

namespace DatabaseManager.View
{
    /// <summary>
    /// Interaction logic for WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        private readonly Window back;
        public WorkingWindow(Window back)
        {
            this.back = back;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var x = MessageBox.Show("Are you sure that you want to exit?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(x == MessageBoxResult.Yes)
            {
                Connection.Connection.Disconnect();
                back.Show();
            }
            else
                e.Cancel = true;         
        }
    }
}
