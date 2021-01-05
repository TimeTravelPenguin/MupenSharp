#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: NoControllerException.cs
// 
// Current Data:
// 2021-01-06 12:55 AM
// 
// Creation Date:
// 2021-01-06 12:48 AM

#endregion

using System;

namespace MupenSharp.Exceptions
{
  public class NoControllerException : Exception
  {
    public NoControllerException()
    {
    }

    public NoControllerException(string message) : base(message)
    {
    }
  }
}