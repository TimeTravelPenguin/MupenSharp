#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: MupenNullParser.cs
// 
// Current Data:
// 2021-01-04 1:53 PM
// 
// Creation Date:
// 2021-01-03 8:51 PM

#endregion

using System.IO;
using MupenSharp.Exceptions;
using MupenSharp.Models;

namespace MupenSharp.FileParsing.Parsers
{
  internal class MupenNullParser : IParser
  {
    /// <exception cref="InvalidFileVersionException"></exception>
    public M64 Parse(FileInfo m64File)
    {
      throw new InvalidFileVersionException("The current m64 version is not supported");
    }
  }
}