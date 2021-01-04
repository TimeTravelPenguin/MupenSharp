#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InvalidFileVersionException.cs
// 
// Current Data:
// 2021-01-04 1:52 PM
// 
// Creation Date:
// 2021-01-04 1:51 PM

#endregion

using System;

namespace MupenSharp.Exceptions
{
  public class InvalidFileVersionException : Exception
  {
    public InvalidFileVersionException()
    {
    }

    public InvalidFileVersionException(string message) : base(message)
    {
    }
  }
}