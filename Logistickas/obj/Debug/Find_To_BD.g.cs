﻿#pragma checksum "..\..\Find_To_BD.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED639F4EED5643E461C41970F95075998988EAA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Logistickas;
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


namespace Logistickas {
    
    
    /// <summary>
    /// Find_To_BD
    /// </summary>
    public partial class Find_To_BD : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Find_To_BD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Find_ID;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Find_To_BD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Find_Name;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Find_To_BD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Find;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Find_To_BD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Find;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Find_To_BD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Find_OK;
        
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
            System.Uri resourceLocater = new System.Uri("/Logistickas;component/find_to_bd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Find_To_BD.xaml"
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
            this.Button_Find_ID = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Find_To_BD.xaml"
            this.Button_Find_ID.Click += new System.Windows.RoutedEventHandler(this.Button_Find_ID_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_Find_Name = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Find_To_BD.xaml"
            this.Button_Find_Name.Click += new System.Windows.RoutedEventHandler(this.Button_Find_Name_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBlock_Find = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBox_Find = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\Find_To_BD.xaml"
            this.TextBox_Find.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Find_TextChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\Find_To_BD.xaml"
            this.TextBox_Find.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_Find_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_Find_OK = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Find_To_BD.xaml"
            this.Button_Find_OK.Click += new System.Windows.RoutedEventHandler(this.Button_Find_OK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

