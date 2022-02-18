using DatabaseManager.Model.Database;
using DatabaseManager.View.Windows;
using DatabaseManager.ViewModel;
using System;
using System.Data;
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

        private void BtnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (cbTables.SelectedItem != null)
            {
                var columnsInfo = Connection.Connection.GetFieldInfo(cbTables.SelectedValue.ToString(), out string message);
                if(columnsInfo.FieldInfoList.Count == 0)
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    new SecondaryWindow { Content = new EditPage(cbTables.SelectedValue.ToString(), columnsInfo)}.ShowDialog();
            }
                
            else
                MessageBox.Show("Select table you want to add data to.", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable.SelectedItem != null)
            {
                var result = MessageBox.Show("Do you really want to delete this record?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    VM.DeleteRecord(cbTables.SelectedValue.ToString(), dataTable.SelectedItem);
            }
            else
                MessageBox.Show("Select record to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnModifyRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable.SelectedItem != null)
            {
                if (VM.CanModify(cbTables.SelectedItem.ToString(), out string message))
                {
                    var columnInfoCollection = Connection.Connection.GetFieldInfo(cbTables.SelectedValue.ToString(), out message);
                    if(columnInfoCollection.FieldInfoList.Count == 0)
                        MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        var selectedTable = cbTables.SelectedValue.ToString();
                        var selectedKeyName = columnInfoCollection.GetPrimaryKeysColumns()[0].FieldName;
                        var temp = columnInfoCollection.GetPrimaryKeysColumns()[0].FieldName;
                        var selectedKeyValue = (((DataRowView)dataTable.SelectedItem).Row.Field<int>(temp)).ToString();


                        var result = Connection.Connection.GetFieldValues(selectedTable, selectedKeyName, selectedKeyValue, columnInfoCollection, out message);
                        if (result)
                            new SecondaryWindow { Content = new EditPage(cbTables.SelectedValue.ToString(), columnInfoCollection) }.ShowDialog();
                        else
                            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Select record to modify.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnImportRecords_Click(object sender, RoutedEventArgs e)
        {//TODO

        }

        private void BtnExportRecords_Click(object sender, RoutedEventArgs e)
        {//TODO

        }

        private void BtnFilterRectods_Click(object sender, RoutedEventArgs e)
        {//TODO

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            string selectedTable = cbTables.Text;
            VM.RefreshTableNames();
            cbTables.Text = selectedTable;
            if (!string.IsNullOrEmpty((string)cbTables.SelectedItem) && VM.TableNames.Contains(selectedTable))
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