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
  /// Some sample data for Vegas.
  /// </summary>
  public class LasVegasLocationData
  {
    public static void Setup()
    {
      GeoCoordinateWatcher.TimeToGetFix = 2000;
      GeoCoordinateWatcher.TimeToWarmUp = 2000;
      GeoCoordinateWatcher.TimeToStartMoving = 5000;
      GeoCoordinateWatcher.TimeToChangePosition = 5000;
      CivicAddressResolver.TimeToResolveAddress = 500;
      GeoCoordinateWatcher.InitialPosition = new GeoCoordinate(36.091624402234245, -115.17439086242677, "Mandalay Bay");
      GeoCoordinateWatcher.InMotionPositions = new List<GeoCoordinate>()
      {
        new GeoCoordinate(36.09526559817705, -115.17537791534425, "Luxor"), 
        new GeoCoordinate(36.09903665898325, -115.17522771163942, "Excalibur"),
        new GeoCoordinate(36.10232210236377, -115.1744123200989, "New York, New York"),
        new GeoCoordinate(36.104731918078784, -115.17424065872194, "Monte Carlo"),
        new GeoCoordinate(36.1100540548897, -115.17203051849367, "Planet Hollywood"),
        new GeoCoordinate(36.112949007195, -115.17580706878664,"Bellagio"),
        new GeoCoordinate(36.11787191457684, -115.17492730422975, "Caesar's Palace"),
        // Decide to stay at Caesar's for a while.....
      };
    }
  }
}
