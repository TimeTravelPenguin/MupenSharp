using System;

namespace MupenSharp.Exceptions;

internal class NoControllerException : Exception
{
  public NoControllerException()
  {
  }

  public NoControllerException(string message) : base(message)
  {
  }
}