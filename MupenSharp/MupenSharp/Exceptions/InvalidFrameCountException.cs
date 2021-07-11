#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: InvalidFrameCountException.cs
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
  ///   Exception for when a file's frame count and header frame count property do not match
  /// </summary>
  internal class InvalidFrameCountException : Exception
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