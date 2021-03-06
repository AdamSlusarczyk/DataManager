#pragma checksum "..\..\..\..\..\View\Pages\DataPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "850CADF557C6AED09D766F6DAEBEE5FDA6A93477"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DatabaseManager.View.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DatabaseManager.View.Pages {
    
    
    /// <summary>
    /// DataPage
    /// </summary>
    public partial class DataPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DatabaseManager.View.Pages.DataPage @this;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTables;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataTable;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRecord;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteRecord;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifyRecord;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImportRecords;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportRecords;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFilterRectods;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\View\Pages\DataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DatabaseManager;component/view/pages/datapage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Pages\DataPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.@this = ((DatabaseManager.View.Pages.DataPage)(target));
            return;
            case 2:
            this.cbTables = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.cbTables.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbTables_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnRefresh.Click += new System.Windows.RoutedEventHandler(this.BtnRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnAddRecord = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnAddRecord.Click += new System.Windows.RoutedEventHandler(this.BtnAddRecord_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDeleteRecord = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnDeleteRecord.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteRecord_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnModifyRecord = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnModifyRecord.Click += new System.Windows.RoutedEventHandler(this.BtnModifyRecord_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnImportRecords = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnImportRecords.Click += new System.Windows.RoutedEventHandler(this.BtnImportRecords_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnExportRecords = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnExportRecords.Click += new System.Windows.RoutedEventHandler(this.BtnExportRecords_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnFilterRectods = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnFilterRectods.Click += new System.Windows.RoutedEventHandler(this.BtnFilterRectods_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\..\View\Pages\DataPage.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.BtnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

