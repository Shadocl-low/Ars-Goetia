﻿#pragma checksum "..\..\..\..\Forms\OptionMenu - Copy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1749A13B792490C818504EA49641899A1AAF9FDB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MainMenu;
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


namespace MainMenu {
    
    
    /// <summary>
    /// OptionMenu
    /// </summary>
    public partial class OptionMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GameOptionsUnderline;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GameOptions;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border WindowOptionsUnderline;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WindowOptions;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame OptionControl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitBtnOption;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MainMenu;V1.0.0.0;component/forms/optionmenu%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GameOptionsUnderline = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.GameOptions = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
            this.GameOptions.Click += new System.Windows.RoutedEventHandler(this.ShowGameOptions);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WindowOptionsUnderline = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.WindowOptions = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
            this.WindowOptions.Click += new System.Windows.RoutedEventHandler(this.ShowWindowOptions);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OptionControl = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.QuitBtnOption = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Forms\OptionMenu - Copy.xaml"
            this.QuitBtnOption.Click += new System.Windows.RoutedEventHandler(this.QuitBtnOption_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

