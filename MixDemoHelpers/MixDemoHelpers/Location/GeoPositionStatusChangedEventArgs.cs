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
  public class GeoPositionStatusChangedEventArgs : EventArgs
  {
    internal GeoPositionStatusChangedEventArgs(GeoPositionStatus status)
    {
      Status = status;
    }

    // Summary:
    //     The GeoPositionStatus value reflecting the updated status of the location
    //     service.
    //
    // Returns:
    //     Type: System.Device.Location.GeoPositionStatus.
    public GeoPositionStatus Status { get; private set; }

  }
}
