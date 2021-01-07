#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InvalidFileVersionException.cs
// 
// Current Data:
// 2021-01-07 11:52 AM
// 
// Creation Date:
// 2021-01-06 9:56 AM

#endregion

using System;

namespace MupenSharp.Exceptions
{
  /// <summary>
  ///   Exception to alert that the .m64 file version is not supported by this library.
  /// </summary>
  public class InvalidFileVersionException : Exception
  {
    /// <summary>
    ///   Exception to alert that the .m64 file version is not supported by this library.
    /// </summary>
    public InvalidFileVersionException()
    {
    }

    /// <summary>
    ///   Exception to alert that the .m64 file version is not supported by this library.
    /// </summary>
    /// <param name="message">The exception message</param>
    public InvalidFileVersionException(string message) : base(message)
    {
    }
  }
}