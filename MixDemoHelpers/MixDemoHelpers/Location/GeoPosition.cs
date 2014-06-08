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
  public class GeoPosition<T>
  {
    //
    // Summary:
    //     Initializes a new instance of the System.Device.Location.GeoPosition<T> class
    //     with the provided time stamp and location.
    //
    // Parameters:
    //   timestamp:
    //     A DateTimeOffset object specifying the point in time associated with the
    //     System.Device.Location.GeoPosition<T> object.
    //
    //   location:
    //     The location associated with the System.Device.Location.GeoPosition<T> object.
    public GeoPosition(DateTimeOffset timestamp, T location)
    {
      Location = location;
      Timestamp = timestamp;
    }

    // Summary:
    //     Gets or sets the location of the System.Device.Location.GeoPosition<T> object.
    public T Location { get; set; }
    //
    // Summary:
    //     Gets or sets the time stamp of the System.Device.Location.GeoPosition<T>
    //     object.
    //
    // Returns:
    //     Type: System.DateTimeOffset. The point in time associated with the System.Device.Location.GeoPosition<T>
    //     object.
    public DateTimeOffset Timestamp { get; set; }

  }
}
