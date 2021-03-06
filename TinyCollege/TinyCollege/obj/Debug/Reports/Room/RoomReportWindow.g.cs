﻿#pragma checksum "..\..\..\..\Reports\Room\RoomReportWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1C62356B0E4D329483F208F02E7CECC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using TinyCollege.Reports.Room;


namespace TinyCollege.Reports.Room {
    
    
    /// <summary>
    /// RoomReportWindow
    /// </summary>
    public partial class RoomReportWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChkBuilding;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbBuilding;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbDay;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChkTime;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker TpStart;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker TpEnd;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ReportContainer;
        
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
            System.Uri resourceLocater = new System.Uri("/TinyCollege;component/reports/room/roomreportwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Reports\Room\RoomReportWindow.xaml"
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
            this.ChkBuilding = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.CmbBuilding = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CmbDay = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ChkTime = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.TpStart = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 6:
            this.TpEnd = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 7:
            this.ReportContainer = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

