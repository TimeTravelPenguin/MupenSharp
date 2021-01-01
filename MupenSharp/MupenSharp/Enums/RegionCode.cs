#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: RegionCode.cs
// 
// Current Data:
// 2020-07-14 10:59 AM
// 
// Creation Date:
// 2020-06-10 11:37 AM

#endregion

namespace MupenSharp.Enums
{
  // These are based off the ROM CRC
  public enum RegionCode : uint
  {
    U = 0xFF2B5A63,
    J = 0xE3DAA4E,
    Ghost_v1 = 0x95ED43A4,
    Ghost_v2 = 0xAF5E2D01
  }
}