#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: InvalidFileVersionException.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System;

#endregion

namespace MupenSharp.Exceptions
{
  /// <summary>
  ///   Exception to alert that the .m64 file version is not supported by this library.
  /// </summary>
  internal class InvalidFileVersionException : Exception
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