/* 
    Copyright (c) 2010 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
    
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
//

//using System.Device.Location;
using MixDemoHelpers.Location;


namespace LocationServiceSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// This sample receives data from the Location Service and displays the geographic coordinates of the device.
        /// </summary>

        GeoCoordinateWatcher watcher;
        string accuracyText = "";
        double goal = 0;
        double actual = 0;
        double lastlong = 0;
        double lastlat = 0;
        double currentlong = 0;
        double currentlat = 0;

        #region Initialization

        /// <summary>
        /// Constructor for the PhoneApplicationPage object
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            PortlandLocationData.Setup();
        }

        #endregion

        #region User Interface

        /// <summary>
        /// Click event handler for the low accuracy button
        /// </summary>
        /// <param name="sender">The control that raised the event</param>
        /// <param name="e">An EventArgs object containing event data.</param>
        private void LowButtonClick(object sender, EventArgs e)
        {
            // Start data acquisition from the Location Service, low accuracy
            accuracyText = "power optimized";
            StartLocationService(GeoPositionAccuracy.Default);
        }

        /// <summary>
        /// Click event handler for the high accuracy button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HighButtonClick(object sender, EventArgs e)
        {
            // Start data acquisition from the Location Service, high accuracy
            accuracyText = "high accuracy";
            StartLocationService(GeoPositionAccuracy.High);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            if (watcher != null)
            {
                watcher.Stop();
            }
            StatusTextBlock.Text = "location service is off";
            LatitudeTextBlock.Text = " ";
            LongitudeTextBlock.Text = " ";
        }

        #endregion

        #region Application logic

        /// <summary>
        /// Helper method to start up the location data acquisition
        /// </summary>
        /// <param name="accuracy">The accuracy level </param>
        private void StartLocationService(GeoPositionAccuracy accuracy)
        {
            // Reinitialize the GeoCoordinateWatcher
            StatusTextBlock.Text = "starting, " + accuracyText;
            watcher = new GeoCoordinateWatcher(accuracy);
           // watcher.MovementThreshold = 20;

            // Add event handlers for StatusChanged and PositionChanged events
            watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

            // Start data acquisition
            watcher.Start();
        }

        /// <summary>
        /// Handler for the StatusChanged event. This invokes MyStatusChanged on the UI thread and
        /// passes the GeoPositionStatusChangedEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => MyStatusChanged(e));
        }
        /// <summary>
        /// Custom method called from the StatusChanged event handler
        /// </summary>
        /// <param name="e"></param>
        void MyStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The location service is disabled or unsupported.
                    // Alert the user
                    StatusTextBlock.Text = "location is unsupported on this device";
                    break;
                case GeoPositionStatus.Initializing:
                    // The location service is initializing.
                    // Disable the Start Location button
                    StatusTextBlock.Text = "initializing location service," + accuracyText;
                    break;
                case GeoPositionStatus.NoData:
                    // The location service is working, but it cannot get location data
                    // Alert the user and enable the Stop Location button
                    StatusTextBlock.Text = "data unavailable," + accuracyText;
                    break;
                case GeoPositionStatus.Ready:
                    // The location service is working and is receiving location data
                    // Show the current position and enable the Stop Location button
                    StatusTextBlock.Text = "receiving data, " + accuracyText;
                    break;

            }
        }

        /// <summary>
        /// Handler for the PositionChanged event. This invokes MyStatusChanged on the UI thread and
        /// passes the GeoPositionStatusChangedEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => MyPositionChanged(e));
        }

        /// <summary>
        /// Custom method called from the PositionChanged event handler
        /// </summary>
        /// <param name="e"></param>
        void MyPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            lastlat = currentlat;
            lastlong = currentlong;
            // Update the TextBlocks to show the current location
            LatitudeTextBlock.Text = e.Position.Location.Latitude.ToString("0.000");
            LongitudeTextBlock.Text = e.Position.Location.Longitude.ToString("0.000");
            currentlong = e.Position.Location.Longitude;
            currentlat = e.Position.Location.Latitude;
            double difflong = 69.1 * (currentlong - lastlong) *Math.Cos(lastlong/57.3);
            double difflat = 69.1 * (currentlat - lastlat);
            actual += Math.Sqrt(difflong * difflong + difflat * difflat);
            if (goal - actual < 0) 
            { 
                DistanceDifference.Text = ((goal - actual) * 1).ToString(); 
            }
            else 
            { 
                DistanceDifference.Text = (goal - actual).ToString();
                
            }
            
            DistanceActual.Text = actual.ToString();
        }

        #endregion


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Start data acquisition from the Location Service, high accuracy
            accuracyText = "high accuracy";
            StartLocationService(GeoPositionAccuracy.High);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            actual = 0;
            goal = 0;
            EnteredGoal.Text = "";
            DistanceDifference.Text = "";
            DistanceActual.Text = "";
            lastlong = 0;
            lastlat = 0;
            currentlong = 0;
            currentlat = 0;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (watcher != null)
            {
                watcher.Stop();
            }
            StatusTextBlock.Text = "location service is off";
            LatitudeTextBlock.Text = " ";
            LongitudeTextBlock.Text = " ";
        }

        private void EnteredGoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if ((EnteredGoal.Text.ToString() == "") || (EnteredGoal.Text.ToString() == "Enter distance goal in miles")) { return; }
                goal = Convert.ToDouble(EnteredGoal.Text.ToString());
                //Goal.Text = goal.ToString();
            }
            catch (Exception ex) 
            { 

            }
        }
    }
}
