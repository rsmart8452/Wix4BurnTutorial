namespace Bootstrapper.Models.Util
{
  /// <summary>
  ///   The states of the update view model.
  /// </summary>
  internal enum UpdateDiscoveryState
  {
    Unknown,
    Initializing,
    Checking,
    Current,
    Available,
    Failed
  }
}