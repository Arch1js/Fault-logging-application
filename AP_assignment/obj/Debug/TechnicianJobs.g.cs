﻿#pragma checksum "..\..\TechnicianJobs.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "72CD7CCF03FA12BD271561EBE03A2787"
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
    /// TechnicianJobs
    /// </summary>
    public partial class TechnicianJobs : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fault_Logger.TechnicianJobs App;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUser;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgJobs;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStatus;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMyStatus;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TechnicianJobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBreak;
        
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
            System.Uri resourceLocater = new System.Uri("/Fault Logger;component/technicianjobs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TechnicianJobs.xaml"
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
            this.App = ((Fault_Logger.TechnicianJobs)(target));
            return;
            case 2:
            this.cmbUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 13 "..\..\TechnicianJobs.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.cmbLogout);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgJobs = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\TechnicianJobs.xaml"
            this.dgJobs.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgJobs_AutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 18 "..\..\TechnicianJobs.xaml"
            this.dgJobs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgJobs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblMyStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnBreak = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\TechnicianJobs.xaml"
            this.btnBreak.Click += new System.Windows.RoutedEventHandler(this.btnBreak_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

