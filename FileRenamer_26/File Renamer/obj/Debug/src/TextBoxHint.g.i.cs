﻿#pragma checksum "..\..\..\src\TextBoxHint.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2A97F1D40E4036711FEC8CC88EF78662"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using File_Renamer;
using Microsoft.Windows.Themes;
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


namespace File_Renamer {
    
    
    /// <summary>
    /// TextBoxHint
    /// </summary>
    public partial class TextBoxHint : System.Windows.Controls.TextBox, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 7 "..\..\..\src\TextBoxHint.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal File_Renamer.TextBoxHint textBox;
        
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
            System.Uri resourceLocater = new System.Uri("/File_Renamer;component/src/textboxhint.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\src\TextBoxHint.xaml"
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
            this.textBox = ((File_Renamer.TextBoxHint)(target));
            
            #line 10 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.Loaded += new System.Windows.RoutedEventHandler(this.TextBox_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TextBox_MouseEnter);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TextBox_MouseLeave);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\src\TextBoxHint.xaml"
            this.textBox.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 50 "..\..\..\src\TextBoxHint.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ExpanderCanvas_MouseUp);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 53 "..\..\..\src\TextBoxHint.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClearCanvas_MouseDown);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 56 "..\..\..\src\TextBoxHint.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.WarningCanvas_MouseUp);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

