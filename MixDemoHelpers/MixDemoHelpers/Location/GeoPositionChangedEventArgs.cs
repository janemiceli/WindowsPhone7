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
  public class GeoPositionChangedEventArgs<T> : EventArgs
  {
    // Summary:
    //     Initializes a new instance of the System.Device.Location.GeoPositionChangedEventArgs<T>
    //     class.
    //
    // Parameters:
    //   position:
    //     A System.Device.Location.GeoPosition<T> object containing the location and
    //     time stamp data for the event.
    public GeoPositionChangedEventArgs(GeoPosition<T> position)
    {
      Position = position;
    }

    // Summary:
    //     A System.Device.Location.GeoPosition<T> object containing the location and
    //     time stamp data for the System.Device.Location.GeoCoordinateWatcher.PositionChanged
    //     event.
    //
    // Returns:
    //     Type: System.Device.Location.GeoPosition<T>.
    public GeoPosition<T> Position { get; private set; }
  }
}
