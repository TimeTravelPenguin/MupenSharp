#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: MupenNullParser.cs
// 
// Current Data:
// 2021-01-03 7:56 PM
// 
// Creation Date:
// 2021-01-03 7:55 PM

#endregion

using System;
using System.IO;
using MupenSharp.Models;

namespace MupenSharp.FileParsing.Parsers
{
  internal class MupenNullParser : IParser
  {
    public M64 Parse(FileInfo m64File)
    {
      throw new InvalidOperationException("Null Parser Exception");
    }
  }
}