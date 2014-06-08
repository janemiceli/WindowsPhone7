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
  public class ResolveAddressCompletedEventArgs : EventArgs
  {

    // Summary:
    //     Initializes a new instance of the System.Device.Location.ResolveAddressCompletedEventArgs
    //     class.
    //
    // Parameters:
    //   error:
    //     This parameter is not used.
    //
    //   address:
    //     A System.Device.Location.CivicAddress object containing the resolved address.
    //
    //   cancelled:
    //     This parameter is not used.
    //
    //   userState:
    //     This parameter is not used.
    public ResolveAddressCompletedEventArgs(CivicAddress address)
    {
      Address = address;
    }

    // Summary:
    //     The resolved civic address.
    //
    // Returns:
    //     Type: System.Device.Location.CivicAddress . The resolved civic address.
    public CivicAddress Address { get; internal set; }
  }
}
