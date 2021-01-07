#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: RegionCode.cs
// 
// Current Data:
// 2021-01-07 12:15 PM
// 
// Creation Date:
// 2021-01-06 9:56 AM

#endregion

namespace MupenSharp.Enums
{
  /// <summary>
  ///   Known region codes for SM64 --- OBSOLETE
  /// </summary>
  public enum RegionCode : uint
  {
    /// <summary>
    ///   SM64 USA region code
    /// </summary>
    U = 0xFF2B5A63,

    /// <summary>
    ///   SM64 Japan region code
    /// </summary>
    J = 0xE3DAA4E,

    /// <summary>
    ///   Region code for SM64 Ghost ROM hack v1
    /// </summary>
    GhostV1 = 0x95ED43A4,

    /// <summary>
    ///   Region code for SM64 Ghost ROM hack v2
    /// </summary>
    GhostV2 = 0xAF5E2D01
  }
}