﻿#pragma checksum "..\..\LoggedIn.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7308F64503C734D2047237206350201C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CardReaderClient;
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


namespace CardReaderClient {
    
    
    /// <summary>
    /// LoggedIn
    /// </summary>
    public partial class LoggedIn : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label welcome;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddStudent;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProwadzacy;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPrzedmiot;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartLesson;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddObowiazek;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LoggedIn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MySubjects;
        
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
            System.Uri resourceLocater = new System.Uri("/CardReaderClient;component/loggedin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoggedIn.xaml"
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
            this.welcome = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.AddStudent = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\LoggedIn.xaml"
            this.AddStudent.Click += new System.Windows.RoutedEventHandler(this.AddStudent_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddProwadzacy = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\LoggedIn.xaml"
            this.AddProwadzacy.Click += new System.Windows.RoutedEventHandler(this.AddProwadzacy_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddPrzedmiot = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\LoggedIn.xaml"
            this.AddPrzedmiot.Click += new System.Windows.RoutedEventHandler(this.AddPrzedmiot_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartLesson = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\LoggedIn.xaml"
            this.StartLesson.Click += new System.Windows.RoutedEventHandler(this.StartLesson_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddObowiazek = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\LoggedIn.xaml"
            this.AddObowiazek.Click += new System.Windows.RoutedEventHandler(this.AddObowiazek_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MySubjects = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\LoggedIn.xaml"
            this.MySubjects.Click += new System.Windows.RoutedEventHandler(this.MySubjects_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

