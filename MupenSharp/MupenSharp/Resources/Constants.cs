#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: Constants.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

namespace MupenSharp.Resources
{
  /// <summary>
  ///   Constant variables class
  /// </summary>
  internal static class Constants
  {
    /// <summary>
    ///   The first four byte of a valid .m64 file
    /// </summary>
    public static readonly byte[] ValidM64Signature = {0x4D, 0x36, 0x34, 0x1A};
  }
}