﻿#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: Controller.cs
// 
// Current Data:
// 2021-07-14 12:06 PM
// 
// Creation Date:
// 2021-07-14 11:19 AM

#endregion

namespace MupenSharp.Enums
{
  /// <summary>
  ///   Enum to indicate a specific controller selection.
  /// </summary>
  public enum Controller
  {
    /// <summary>
    ///   Controller in port one. Has offset 0.
    /// </summary>
    ControllerOne = 0,

    /// <summary>
    ///   Controller in port two. Has offset 1.
    /// </summary>
    ControllerTwo = 1,

    /// <summary>
    ///   Controller in port three. Has offset 2.
    /// </summary>
    ControllerThree = 2,

    /// <summary>
    ///   Controller in port four. Has offset 3.
    /// </summary>
    ControllerFour = 3
  }
}