#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: RegionCode.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

namespace MupenSharp.Enums
{
  // These are based off the ROM CRC
  // These are obsolete and are specific only to SM64
  public enum RegionCode : uint
  {
    U = 0xFF2B5A63,
    J = 0xE3DAA4E,
    Ghost_v1 = 0x95ED43A4,
    Ghost_v2 = 0xAF5E2D01
  }
}