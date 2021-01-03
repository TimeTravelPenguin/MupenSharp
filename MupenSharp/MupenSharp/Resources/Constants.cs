#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: Constants.cs
// 
// Current Data:
// 2021-01-03 8:40 PM
// 
// Creation Date:
// 2021-01-03 8:37 PM

#endregion

namespace MupenSharp.Resources
{
  /// <summary>
  ///   Constant variables class
  /// </summary>
  public static class Constants
  {
    /// <summary>
    ///   The first four byte of a valid .m64 file
    /// </summary>
    public static readonly byte[] ValidM64Signature = {0x4D, 0x36, 0x34, 0x1A};
  }
}