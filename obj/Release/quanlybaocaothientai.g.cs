﻿#pragma checksum "..\..\quanlybaocaothientai.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2FC1BF77F42F52E0987B936FA5E8C39E827728EDF9A0EAC83E62766C4D13B6AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BTL_HeThongQuanLyDuLieuThienTai;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace BTL_HeThongQuanLyDuLieuThienTai {
    
    
    /// <summary>
    /// quanlybaocaothientai
    /// </summary>
    public partial class quanlybaocaothientai : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\quanlybaocaothientai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgv_quanlybaocao;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\quanlybaocaothientai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\quanlybaocaothientai.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_find;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BTL_HeThongQuanLyDuLieuThienTai;component/quanlybaocaothientai.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\quanlybaocaothientai.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\quanlybaocaothientai.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.quanlybaocao_loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgv_quanlybaocao = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\quanlybaocaothientai.xaml"
            this.dgv_quanlybaocao.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\quanlybaocaothientai.xaml"
            this.btn_delete.Click += new System.Windows.RoutedEventHandler(this.btn_delete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_find = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

