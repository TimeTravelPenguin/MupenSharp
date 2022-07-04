using System;

namespace MupenSharp.Exceptions;

internal class InvalidFrameCountException : Exception
{
  public InvalidFrameCountException()
  {
  }

  public InvalidFrameCountException(string message) : base(message)
  {
  }
}