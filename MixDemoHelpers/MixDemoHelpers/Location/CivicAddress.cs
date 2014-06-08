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
  public class CivicAddress
  {
    internal CivicAddress(GeoCoordinate coordinate)
    {
      IsUnknown = false;
      this.coordinate = coordinate;
    }

    private GeoCoordinate coordinate;
    //
    // Returns:
    //     Type: System.String. The first line of the civic address, generally used
    //     for street name and number.
    public string AddressLine1 { get { return coordinate.FriendlyName; } }

    public bool IsUnknown { get; internal set; }
  }
}
