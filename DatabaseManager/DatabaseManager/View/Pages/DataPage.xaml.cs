using DatabaseManager.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseManager.View.Pages
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPageVM VM { get; set; }
        public DataPage()
        {
            VM = new();
            VM.RefreshTableNames();
            InitializeComponent();
        }

        private void BtnAddRecord_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // new page, pass VM as argument
            // with VM.AddRecord add new record
            VM.AddRecord();
        }

        private void BtnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable.SelectedItem != null)
            {
                VM.DeleteRecord(dataTable.SelectedItem, out string message);
            }
                
            else
                MessageBox.Show("Select record to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnModifyRecord_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (dataTable.SelectedItem != null)
            {
                VM.ModifyRecord(dataTable.SelectedItem, out string message);
            }
                
            else
                MessageBox.Show("Select record to modify.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnImportRecords_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void BtnExportRecords_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnFilterRectods_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            string selectedTable = cbTables.Text;
            VM.RefreshTableNames();
            cbTables.Text = selectedTable;
            if(!string.IsNullOrEmpty((string) cbTables.SelectedItem) && VM.TableNames.Contains(selectedTable))
            {
                VM.RefreshData((string)cbTables.SelectedItem);
                dataTable.ItemsSource = VM.DataTable.DefaultView;
            }            
        }

        private void CbTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.RefreshData((string)cbTables.SelectedItem);
            dataTable.ItemsSource = VM.DataTable.DefaultView;
        }
    }
}
