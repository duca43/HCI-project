﻿#pragma checksum "..\..\..\AddDialogs\AddMonument.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97ED521218BDCE4934FC12DD639E930B6C0AE724"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace MyProject.AddDialogs {
    
    
    /// <summary>
    /// AddMonument
    /// </summary>
    public partial class AddMonument : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding addCommand;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding helpCommand;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock headline;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chcbxEcoEndangered;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chcbxHabitat;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chcbxPopulatedRegion;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmButton;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbID;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDesc;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbType;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbClimate;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIcon;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTouristStatus;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIncome;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\AddDialogs\AddMonument.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
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
            System.Uri resourceLocater = new System.Uri("/MyProject;component/adddialogs/addmonument.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddDialogs\AddMonument.xaml"
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
            
            #line 14 "..\..\..\AddDialogs\AddMonument.xaml"
            this.addCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddMonument_CanExecute);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\AddDialogs\AddMonument.xaml"
            this.addCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddMonument_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\AddDialogs\AddMonument.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Cancel_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\AddDialogs\AddMonument.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Cancel_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.helpCommand = ((System.Windows.Input.CommandBinding)(target));
            return;
            case 4:
            this.headline = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.chcbxEcoEndangered = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.chcbxHabitat = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.chcbxPopulatedRegion = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.confirmButton = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.tbID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbDesc = ((System.Windows.Controls.TextBox)(target));
            
            #line 144 "..\..\..\AddDialogs\AddMonument.xaml"
            this.tbDesc.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Desc_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.cbType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 13:
            this.cbClimate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.tbIcon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            
            #line 171 "..\..\..\AddDialogs\AddMonument.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Browse_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.cbTouristStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.tbIncome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 19:
            
            #line 182 "..\..\..\AddDialogs\AddMonument.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PickTags_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

