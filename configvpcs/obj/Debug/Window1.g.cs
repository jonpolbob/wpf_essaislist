﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "01D3C1AFF9DC1BE752B910E6800C90F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using configvpcs;


namespace configvpcs {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\Window1.xaml"
        internal System.Windows.Controls.RowDefinition TopLine;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        internal System.Windows.Controls.WrapPanel Sections;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Window1.xaml"
        internal System.Windows.Controls.ColumnDefinition LeftPart;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Window1.xaml"
        internal System.Windows.Controls.ColumnDefinition slide;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Window1.xaml"
        internal System.Windows.Controls.ColumnDefinition Right;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Window1.xaml"
        internal System.Windows.Controls.GridSplitter gridSplitter1;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Window1.xaml"
        internal System.Windows.Controls.ListBox ListDir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/configvpcs;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TopLine = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 2:
            this.Sections = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.LeftPart = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.slide = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.Right = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 6:
            this.gridSplitter1 = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 7:
            this.ListDir = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 51 "..\..\Window1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.btnShowSelectedItem_Click);
            
            #line default
            #line hidden
            
            #line 51 "..\..\Window1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.btnShowSelectedItem_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 54 "..\..\Window1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnShowSelectedItem_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

