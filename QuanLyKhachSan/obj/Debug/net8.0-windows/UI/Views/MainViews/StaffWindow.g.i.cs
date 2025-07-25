﻿#pragma checksum "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DBB57CDC361306364BA5DC8121D0F9A3BCCF30A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using QuanLyKhachSan.UI.Views.MainViews;
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


namespace QuanLyKhachSan.UI.Views.MainViews {
    
    
    /// <summary>
    /// StaffWindow
    /// </summary>
    public partial class StaffWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdSideBar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spMenu;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridHome;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdHeader;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup ChangePasswordPopup;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdBody;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spBody;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyKhachSan;component/ui/views/mainviews/staffwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdSideBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.spMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.gridHome = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.grdHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            
            #line 171 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 172 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangePassword_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ChangePasswordPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 8:
            this.NewPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            
            #line 221 "..\..\..\..\..\..\UI\Views\MainViews\StaffWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdatePassword_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grdBody = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.spBody = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

