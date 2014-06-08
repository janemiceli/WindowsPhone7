using System;

namespace MixDemoHelpers.Location
{
  // Summary:
  //     Defines the status values for the location service. Used by the System.Device.Location.GeoCoordinateWatcher.Status
  //     property.
  public enum GeoPositionStatus
  {
    // Summary:
    //     The location service is disabled or unsupported.
    Disabled = 0,
    //
    // Summary:
    //     The location service is enabled and ready.
    Ready = 1,
    //
    // Summary:
    //     The location service is attempting to acquire data.
    Initializing = 2,
    //
    // Summary:
    //     The location sensors are accessible but the service is unable to resolve
    //     location data.
    NoData = 3,
  }
}
