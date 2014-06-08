using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace MixDemoHelpers.Location
{
    /// <summary>
    /// Some sample data for Portland.
    /// http://blogs.msdn.com/b/ptorr/archive/2010/03/25/mock-location-apis-from-my-mix10-talk.aspx
    /// </summary>
    public class PortlandLocationData
    {
        public static void Setup()
        {
            GeoCoordinateWatcher.TimeToGetFix = 2000;
            GeoCoordinateWatcher.TimeToWarmUp = 2000;
            GeoCoordinateWatcher.TimeToStartMoving = 5000;
            GeoCoordinateWatcher.TimeToChangePosition = 5000;
            CivicAddressResolver.TimeToResolveAddress = 500;
            GeoCoordinateWatcher.InitialPosition = new GeoCoordinate(45.588801, -122.592809, "Portland Airport");
            GeoCoordinateWatcher.InMotionPositions = new List<GeoCoordinate>()
            {
                new GeoCoordinate(45.531481, -122.667723, "Rose Garden"),
                new GeoCoordinate(45.518884, -122.679305, "Pioneer Square"),
                new GeoCoordinate(45.500858, -122.805583, "Five Guys"),
                new GeoCoordinate(45.457467, -122.779115, "Redtail Golf Course"),
                new GeoCoordinate(45.450735, -122.779558, "Lego Store"),
                new GeoCoordinate(45.444611, -122.773526, "Microsoft Offices"),
                // Decide to stay at office for a while.....
            };
        }
    }
}
