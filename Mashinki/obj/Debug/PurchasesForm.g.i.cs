﻿#pragma checksum "..\..\PurchasesForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "292333FA78A01D9A02829774A44CD672ED6E0DE1C899CAA2BA0283ABD7EC25CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Mashinki;
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


namespace Mashinki {
    
    
    /// <summary>
    /// PurchasesForm
    /// </summary>
    public partial class PurchasesForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Id;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_ClientID;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_ClientId;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_AutoID;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_AutoID;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Date;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Date;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\PurchasesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Save;
        
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
            System.Uri resourceLocater = new System.Uri("/RadaDBM;component/purchasesform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PurchasesForm.xaml"
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
            this.Label_Id = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Label_ClientID = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ComboBox_ClientId = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Label_AutoID = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ComboBox_AutoID = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Label_Date = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.TextBox_Date = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Button_Save = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\PurchasesForm.xaml"
            this.Button_Save.Click += new System.Windows.RoutedEventHandler(this.Button_Save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
