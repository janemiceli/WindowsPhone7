﻿#pragma checksum "C:\Users\micelim\Windows Phone\Code\LocationServiceSample\LocationServiceSample\LocationServiceSample\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B43E66C4EF96F214C0D99C27FDABB1A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace LocationServiceSample {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentGrid;
        
        internal System.Windows.Controls.TextBlock StatusLabel;
        
        internal System.Windows.Controls.TextBlock StatusTextBlock;
        
        internal System.Windows.Controls.TextBlock LatLabel;
        
        internal System.Windows.Controls.TextBlock LatitudeTextBlock;
        
        internal System.Windows.Controls.TextBlock LongLabel;
        
        internal System.Windows.Controls.TextBlock LongitudeTextBlock;
        
        internal System.Windows.Controls.Button Start;
        
        internal System.Windows.Controls.Button Stop;
        
        internal System.Windows.Controls.TextBlock Goal;
        
        internal System.Windows.Controls.TextBox EnteredGoal;
        
        internal System.Windows.Controls.TextBlock Distance;
        
        internal System.Windows.Controls.TextBlock DistanceActual;
        
        internal System.Windows.Controls.Button Clear;
        
        internal System.Windows.Controls.TextBlock DistanceDifferenceLabel;
        
        internal System.Windows.Controls.TextBlock DistanceDifference;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LocationServiceSample;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentGrid = ((System.Windows.Controls.Grid)(this.FindName("ContentGrid")));
            this.StatusLabel = ((System.Windows.Controls.TextBlock)(this.FindName("StatusLabel")));
            this.StatusTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("StatusTextBlock")));
            this.LatLabel = ((System.Windows.Controls.TextBlock)(this.FindName("LatLabel")));
            this.LatitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LatitudeTextBlock")));
            this.LongLabel = ((System.Windows.Controls.TextBlock)(this.FindName("LongLabel")));
            this.LongitudeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LongitudeTextBlock")));
            this.Start = ((System.Windows.Controls.Button)(this.FindName("Start")));
            this.Stop = ((System.Windows.Controls.Button)(this.FindName("Stop")));
            this.Goal = ((System.Windows.Controls.TextBlock)(this.FindName("Goal")));
            this.EnteredGoal = ((System.Windows.Controls.TextBox)(this.FindName("EnteredGoal")));
            this.Distance = ((System.Windows.Controls.TextBlock)(this.FindName("Distance")));
            this.DistanceActual = ((System.Windows.Controls.TextBlock)(this.FindName("DistanceActual")));
            this.Clear = ((System.Windows.Controls.Button)(this.FindName("Clear")));
            this.DistanceDifferenceLabel = ((System.Windows.Controls.TextBlock)(this.FindName("DistanceDifferenceLabel")));
            this.DistanceDifference = ((System.Windows.Controls.TextBlock)(this.FindName("DistanceDifference")));
        }
    }
}

