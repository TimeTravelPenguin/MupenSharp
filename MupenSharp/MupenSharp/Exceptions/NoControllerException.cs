#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: NoControllerException.cs
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
  ///   Exception to alert there is no controller present for the .m64 file
  /// </summary>
  internal class NoControllerException : Exception
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