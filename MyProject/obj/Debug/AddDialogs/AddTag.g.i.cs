﻿#pragma checksum "..\..\..\AddDialogs\AddTag.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54D1D8FF56C95B5C7B626A9EA2BFB4417B9D66DD"
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
    /// AddTag
    /// </summary>
    public partial class AddTag : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\AddDialogs\AddTag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding addCommand;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AddDialogs\AddTag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding helpCommand;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\AddDialogs\AddTag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbID;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\AddDialogs\AddTag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDesc;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\AddDialogs\AddTag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker tagColor;
        
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
            System.Uri resourceLocater = new System.Uri("/MyProject;component/adddialogs/addtag.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddDialogs\AddTag.xaml"
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
            
            #line 14 "..\..\..\AddDialogs\AddTag.xaml"
            this.addCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddTag_CanExecute);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\AddDialogs\AddTag.xaml"
            this.addCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddTag_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\AddDialogs\AddTag.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Cancel_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\AddDialogs\AddTag.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Cancel_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.helpCommand = ((System.Windows.Input.CommandBinding)(target));
            return;
            case 4:
            this.tbID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbDesc = ((System.Windows.Controls.TextBox)(target));
            
            #line 100 "..\..\..\AddDialogs\AddTag.xaml"
            this.tbDesc.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Desc_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tagColor = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

