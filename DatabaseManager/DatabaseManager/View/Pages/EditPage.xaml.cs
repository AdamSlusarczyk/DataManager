using DatabaseManager.Model.Database;
using DatabaseManager.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DatabaseManager.View.Pages
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        readonly EditPageVM VM;
        public EditPage()
        {
            VM = new EditPageVM("null", new RowInfo());
            InitializeComponent();
        }

        public EditPage(string tableName, RowInfo columns)
        {
            InitializeComponent();
            VM = new EditPageVM(tableName, columns);
            PopulateWithColumns(columns);
            CheckButton(columns);
        }

        private void CheckButton(RowInfo columns)
        {
            var notEmptyColumns = columns.FieldInfoList.Where(n => !String.IsNullOrEmpty(n.FieldValue)).ToList();
            if (notEmptyColumns.Count > 0)
            {
                btnOK.Content = "Modify";
                btnOK.Click += BtnModify_Click;
            }          
            else
            {
                btnOK.Content = "Insert";
                btnOK.Click += BtnInsert_Click;
            }        
        }

        private void PopulateWithColumns(RowInfo columns)
        {
            for (int rowNo = 0; rowNo < columns.FieldInfoList.Count; rowNo++)
                AddRow(columns.FieldInfoList[rowNo], rowNo);
        }

        private void AddRow(FieldInfo columnInfo, int rowNo)
        {
            TextBlock newTextBlock_Name = new() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Text = columnInfo.FieldName};
            Grid.SetColumn(newTextBlock_Name, 0);
            Grid.SetRow(newTextBlock_Name, rowNo);

            TextBlock newTextBlock_Type = new() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Text = columnInfo.FieldType + " ["+ columnInfo.KeyType.ToString() +"]" };
            Grid.SetColumn(newTextBlock_Type, 1);
            Grid.SetRow(newTextBlock_Type, rowNo);

            TextBox newTextBox_Value = new() { Width = 100, Height = 25, HorizontalAlignment = HorizontalAlignment.Center };
            if(!string.IsNullOrEmpty(columnInfo.DefaultValue))
                newTextBox_Value.Text = columnInfo.FieldValue;
            Grid.SetColumn(newTextBox_Value, 2);
            Grid.SetRow(newTextBox_Value, rowNo);
            newTextBox_Value.SetBinding(TextBox.TextProperty, new Binding("FieldValue") { Source = columnInfo });

            CheckBox newCheckBox_Nullable = new() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, IsEnabled = false };
            Grid.SetColumn(newCheckBox_Nullable, 3);
            Grid.SetRow(newCheckBox_Nullable, rowNo);
            newCheckBox_Nullable.SetBinding(CheckBox.IsCheckedProperty, new Binding("Nullable") { Source = columnInfo });

            innerGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
            innerGrid.Children.Add(newTextBlock_Name);
            innerGrid.Children.Add(newTextBlock_Type);
            innerGrid.Children.Add(newTextBox_Value);
            innerGrid.Children.Add(newCheckBox_Nullable);
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            if (VM.ModifyRow())
                Window.GetWindow(this).Close();
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (VM.InsertRow())
                Window.GetWindow(this).Close();
        }

        private void BtnFillDefault_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("All values will be filled with default values. Continue?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                VM.FillWithDefaultValues();

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("All changes will be lost. Continue?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Window.GetWindow(this).Close();
        }
    }
}
