#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: Controller.cs
// 
// Current Data:
// 2021-01-06 12:09 AM
// 
// Creation Date:
// 2021-01-05 11:30 PM

#endregion

using System;

namespace MupenSharp.Enums
{
  [Flags]
  internal enum ControllerProperty
  {
    ControllerOnePresent = 0x0001,
    ControllerTwoPresent = 0x0002,
    ControllerThreePresent = 0x0004,
    ControllerFourPresent = 0x0008,
    ControllerOneMemoryPackPresent = 0x0010,
    ControllerTwoMemoryPackPresent = 0x0020,
    ControllerThreeMemoryPackPresent = 0x0040,
    ControllerFourMemoryPackPresent = 0x0080,
    ControllerOneRumblePackPresent = 0x0100,
    ControllerTwoRumblePackPresent = 0x0200,
    ControllerThreeRumblePackPresent = 0x0400,
    ControllerFourRumblePackPresent = 0x0800
  }
}