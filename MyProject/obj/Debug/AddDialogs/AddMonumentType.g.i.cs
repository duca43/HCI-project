﻿#pragma checksum "..\..\..\AddDialogs\AddMonumentType.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76E17F99412F5BE37BD39275F38344E078D2FEFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyProject.AddDialogs;
using MyProject.Commands;
using MyProject.Help;
using MyProject.Validation;
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


namespace MyProject.AddDialogs {
    
    
    /// <summary>
    /// AddMonumentType
    /// </summary>
    public partial class AddMonumentType : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding addCommand;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding helpCommand;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbID;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDesc;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIcon;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\AddDialogs\AddMonumentType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/MyProject;component/adddialogs/addmonumenttype.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddDialogs\AddMonumentType.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.addCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 13 "..\..\..\AddDialogs\AddMonumentType.xaml"
            this.addCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddMonumentType_CanExecute);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\AddDialogs\AddMonumentType.xaml"
            this.addCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddMonumentType_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\..\AddDialogs\AddMonumentType.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Cancel_CanExecute);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\AddDialogs\AddMonumentType.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Cancel_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.helpCommand = ((System.Windows.Input.CommandBinding)(target));
            return;
            case 4:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.tbID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbDesc = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\..\AddDialogs\AddMonumentType.xaml"
            this.tbDesc.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Desc_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbIcon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.browseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\..\AddDialogs\AddMonumentType.xaml"
            this.browseBtn.Click += new System.Windows.RoutedEventHandler(this.Browse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

