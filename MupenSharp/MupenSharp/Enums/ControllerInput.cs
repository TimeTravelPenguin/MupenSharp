#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: ControllerInput.cs
// 
// Current Data:
// 2021-01-04 11:28 AM
// 
// Creation Date:
// 2021-01-02 11:17 PM

#endregion

using System;

namespace MupenSharp.Enums
{
  /// <summary>
  ///   Controller button bit flags
  /// </summary>
  [Flags]
  public enum ControllerInput
  {
    /// <summary>
    ///   The C-Right button
    /// </summary>
    CRight = 0x0001,

    /// <summary>
    ///   The C-Left button
    /// </summary>
    CLeft = 0x0002,

    /// <summary>
    ///   The C-Down button
    /// </summary>
    CDown = 0x0004,

    /// <summary>
    ///   The C-Up button
    /// </summary>
    CUp = 0x0008,

    /// <summary>
    ///   The right shoulder button
    /// </summary>
    R = 0x0010,

    /// <summary>
    ///   The left shoulder button
    /// </summary>
    L = 0x0020,

    /// <summary>
    ///   Reserved input 01
    /// </summary>
    Reserved1 = 0x0040,

    /// <summary>
    ///   Reserved input 02
    /// </summary>
    Reserved2 = 0x0080,

    /// <summary>
    ///   Right D-Pad button
    /// </summary>
    DigitalPadRight = 0x0100,

    /// <summary>
    ///   Left D-Pad button
    /// </summary>
    DigitalPadLeft = 0x0200,

    /// <summary>
    ///   Down D-Pad button
    /// </summary>
    DigitalPadDown = 0x0400,

    /// <summary>
    ///   Up D-Pad button
    /// </summary>
    DigitalPadUp = 0x0800,

    /// <summary>
    ///   The Start button
    /// </summary>
    Start = 0x1000,

    /// <summary>
    ///   The Z button
    /// </summary>
    Z = 0x2000,

    /// <summary>
    ///   The B button
    /// </summary>
    B = 0x4000,

    /// <summary>
    ///   The A button
    /// </summary>
    A = 0x8000
  }
}