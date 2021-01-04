#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InvalidFrameCountException.cs
// 
// Current Data:
// 2021-01-04 1:41 PM
// 
// Creation Date:
// 2021-01-04 1:39 PM

#endregion

using System;

namespace MupenSharp.Exceptions
{
  /// <summary>
  ///   Exception for when a file's frame count and header frame count property do not match
  /// </summary>
  public class InvalidFrameCountException : Exception
  {
    /// <summary>
    ///   Raises an exception to indicate there is an invalid frame count
    /// </summary>
    public InvalidFrameCountException()
    {
    }

    /// <summary>
    ///   Raises an exception to indicate there is an invalid frame count
    /// </summary>
    /// <param name="message"></param>
    public InvalidFrameCountException(string message) : base(message)
    {
    }
  }
}