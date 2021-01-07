#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: NoControllerException.cs
// 
// Current Data:
// 2021-01-07 11:53 AM
// 
// Creation Date:
// 2021-01-06 9:56 AM

#endregion

using System;

namespace MupenSharp.Exceptions
{
  /// <summary>
  ///   Exception to alert there is no controller present for the .m64 file
  /// </summary>
  public class NoControllerException : Exception
  {
    /// <summary>
    ///   Exception to alert there is no controller present for the .m64 file
    /// </summary>
    public NoControllerException()
    {
    }

    /// <summary>
    ///   Exception to alert there is no controller present for the .m64 file
    /// </summary>
    /// <param name="message">The exception message</param>
    public NoControllerException(string message) : base(message)
    {
    }
  }
}