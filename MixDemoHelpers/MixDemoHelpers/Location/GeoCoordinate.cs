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

namespace MixDemoHelpers.Location
{
  public class GeoCoordinate
  {
    public GeoCoordinate()
    {
      IsUnknown = true;
    }

    public GeoCoordinate(double latitude, double longitude)
      : this(latitude, longitude, "Unknown")
    {
    }

    internal GeoCoordinate(double latitude, double longitude, string friendlyName)
    {
      IsUnknown = false;
      Latitude = latitude;
      Longitude = longitude;
      HorizontalAccuracy = 50;
      FriendlyName = friendlyName;
    }

    // MIX10: Added internal property to get an address out of a coordinate.
    internal string FriendlyName { get; set; }

    //
    // Summary:
    //     A double representing the latitude of the System.Device.Location.GeoCoordinate.
    //
    // Returns:
    //     Type: System.Double. The latitude of the System.Device.Location.GeoCoordinate.
    public double Latitude { get; set; }
    //
    // Summary:
    //     A double representing the longitude of the System.Device.Location.GeoCoordinate.
    //
    // Returns:
    //     Type: System.Double. The longitude of the System.Device.Location.GeoCoordinate.
    public double Longitude { get; set; }
    //
    // Summary:
    //     A double representing the horizontal accuracy of the System.Device.Location.GeoCoordinate.
    //
    // Returns:
    //     Type: System.Double. The horizontal accuracy of the System.Device.Location.GeoCoordinate.

    public double HorizontalAccuracy { get; set; }
    //
    // Summary:
    //     Gets a value indicating whether the System.Device.Location.GeoCoordinate
    //     contains any geographic coordinate data.
    //
    // Returns:
    //     Returns System.Boolean. true if both the latitude and longitude of the current
    //     instance are not a number.
    public bool IsUnknown { get; private set; }

  }
}
