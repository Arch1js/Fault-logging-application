﻿#pragma checksum "..\..\Technician_Dispatch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BB962182B9FC7D38D7C2245E0E616E5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Fault_Logger {
    
    
    /// <summary>
    /// Technician_Dispatch
    /// </summary>
    public partial class Technician_Dispatch : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fault_Logger.Technician_Dispatch App;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUser;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFault;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMaintenance;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReport;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Technician_Dispatch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManage;
        
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
            System.Uri resourceLocater = new System.Uri("/Fault Logger;component/technician_dispatch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Technician_Dispatch.xaml"
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
            this.App = ((Fault_Logger.Technician_Dispatch)(target));
            return;
            case 2:
            this.cmbUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 13 "..\..\Technician_Dispatch.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.cmbLogout);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnFault = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Technician_Dispatch.xaml"
            this.btnFault.Click += new System.Windows.RoutedEventHandler(this.btnFault_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMaintenance = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Technician_Dispatch.xaml"
            this.btnMaintenance.Click += new System.Windows.RoutedEventHandler(this.btnMaintenance_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnReport = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Technician_Dispatch.xaml"
            this.btnReport.Click += new System.Windows.RoutedEventHandler(this.btnReport_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnManage = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Technician_Dispatch.xaml"
            this.btnManage.Click += new System.Windows.RoutedEventHandler(this.btnManage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

