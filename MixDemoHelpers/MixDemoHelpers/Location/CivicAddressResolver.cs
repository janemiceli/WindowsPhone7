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
using System.Threading;

namespace MixDemoHelpers.Location
{
  public class CivicAddressResolver
  {

    internal static int TimeToResolveAddress = 500;

    // Summary:
    //     Occurs when an asynchronous request for civic address resolution is completed.
    public event EventHandler<ResolveAddressCompletedEventArgs> ResolveAddressCompleted;

    //
    // Summary:
    //     Attempts to asynchronously obtain a civic address from the provided geographic
    //     coordinate.
    //
    // Parameters:
    //   coordinate:
    //     The geographic coordinate from which a civic address is resolved.
    public void ResolveAddressAsync(GeoCoordinate coordinate)
    {
      Thread thread = new Thread(FakeResolve);
      thread.Start(coordinate);
    }

    void FakeResolve(object coordinate)
    {
      Thread.Sleep(TimeToResolveAddress);
      if (ResolveAddressCompleted != null)
        ResolveAddressCompleted(this, new ResolveAddressCompletedEventArgs(new CivicAddress(coordinate as GeoCoordinate)));
    }
  }
}
