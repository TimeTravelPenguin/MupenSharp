using System;

namespace MupenSharp.Exceptions;

internal class InvalidFileVersionException : Exception
{
  public InvalidFileVersionException()
  {
  }

  public InvalidFileVersionException(string message) : base(message)
  {
  }
}