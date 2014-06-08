using System;
using System.Threading;
using System.Collections.Generic;

namespace MixDemoHelpers.Location
{
  public class GeoCoordinateWatcher
  {
    Thread workerThread = null;

    static GeoCoordinateWatcher()
    {
      TimeToWarmUp = 500;
      TimeToGetFix = 500;
      TimeToStartMoving = 500;
      TimeToChangePosition = 500;
      InitialPosition = new GeoCoordinate();
    }

    public GeoCoordinateWatcher(GeoPositionAccuracy desiredAccuracy)
    {
      DesiredAccuracy = desiredAccuracy;
      Status = GeoPositionStatus.Initializing;
      Position = new GeoPosition<GeoCoordinate>(DateTimeOffset.Now, InitialPosition);
    }

    // Summary:
    //     The desired accuracy for data returned from the location service.
    //
    // Returns:
    //     Type: System.Device.Location.GeoPositionAccuracy. The desired accuracy for
    //     location data.
    public GeoPositionAccuracy DesiredAccuracy { get; internal set; }

    //
    // Summary:
    //     The most recent position obtained from the location service.
    //
    // Returns:
    //     Type: System.Device.Location.GeoPosition<T>. The most recent position obtained
    //     from the location service.
    public GeoPosition<GeoCoordinate> Position { get; internal set; }
    //
    // Summary:
    //     The status of the location service.
    //
    // Returns:
    //     Type: System.Device.Location.GeoPositionStatus The status of the location
    //     service..
    public GeoPositionStatus Status { get; internal set; }

    // Summary:
    //     Occurs when the location service detects a change in position.
    public event EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>> PositionChanged;

    //
    // Summary:
    //     Occurs when the status of the location service changes.
    public event EventHandler<GeoPositionStatusChangedEventArgs> StatusChanged;

    //
    // Summary:
    //     Starts the acquisition of data from the location service.
    public void Start()
    {
      if (isRunning == true)
        throw new InvalidOperationException("Location is already running!");

      isRunning = true;
      workerThread = new Thread(FakeLocationLoop);
      workerThread.Start();
    }

    bool isRunning = false;
    static bool isFirstRun = true;

    internal static int TimeToWarmUp { get; set; }
    internal static int TimeToGetFix { get; set; }
    internal static int TimeToStartMoving { get; set; }
    internal static int TimeToChangePosition { get; set; }
    internal static GeoCoordinate InitialPosition { get; set; }
    internal static List<GeoCoordinate> InMotionPositions { get; set; }

    void FakeLocationLoop()
    {
      GeoCoordinate currentLocation = InitialPosition;

      if (isFirstRun)
      {
        ChangeStatusWithEvent(GeoPositionStatus.Initializing);
        Thread.Sleep(TimeToWarmUp);
        isFirstRun = false;
      }

      ChangeStatusWithEvent(GeoPositionStatus.NoData);
      Thread.Sleep(TimeToGetFix);
      ChangeStatusWithEvent(GeoPositionStatus.Ready, currentLocation);
      Thread.Sleep(TimeToStartMoving);
      int index = 0;
      while (isRunning)
      {
        if (InMotionPositions != null && InMotionPositions.Count > index)
        {
          currentLocation = InMotionPositions[index++];
        }
        ChangePositionWithEvent(currentLocation);
        Thread.Sleep(TimeToChangePosition);
      }

      ChangeStatusWithEvent(GeoPositionStatus.Initializing);
    }

    private void ChangePositionWithEvent(GeoCoordinate currentLocation)
    {
      Position = new GeoPosition<GeoCoordinate>(DateTimeOffset.Now, currentLocation);
      if (PositionChanged != null)
      {
        PositionChanged(this, new GeoPositionChangedEventArgs<GeoCoordinate>(Position));
      }
    }

    private void ChangeStatusWithEvent(GeoPositionStatus status, GeoCoordinate currentLocation)
    {
      Position = new GeoPosition<GeoCoordinate>(DateTimeOffset.Now, currentLocation);
      ChangeStatusWithEvent(status);

      if (PositionChanged != null)
      {
        PositionChanged(this, new GeoPositionChangedEventArgs<GeoCoordinate>(Position));
      }
    }

    private void ChangeStatusWithEvent(GeoPositionStatus status)
    {
      Status = status;
      if (StatusChanged != null)
      {
        StatusChanged(this, new GeoPositionStatusChangedEventArgs(status));
      }
    }

    //
    // Summary:
    //     Stops the acquisition of data from the location service.
    public void Stop()
    {
      if (isRunning == false)
        throw new InvalidOperationException("Location is not running!");

      isRunning = false;
      workerThread = null;
    }
  }
}
