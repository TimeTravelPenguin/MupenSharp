#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64Parser.cs
// 
// Current Data:
// 2021-01-05 11:13 PM
// 
// Creation Date:
// 2021-01-04 4:23 PM

#endregion

using System;
using System.IO;
using System.Linq;
using MupenSharp.Extensions;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing
{
  /// <summary>
  ///   Parser object that can read and write a .m64 file
  /// </summary>
  public static class M64Parser
  {
    private static readonly M64ParserFactory ParserFactory = new M64ParserFactory();

    /// <summary>
    ///   Parses the file <paramref name="path" />.
    /// </summary>
    /// <param name="path">The path of the .m64 file</param>
    /// <returns>Returns object with data of parsed file</returns>
    public static M64 Parse(string path)
    {
      var m64 = new FileInfo(path);

      int version;
      using (var reader = new BinaryReader(m64.Open(FileMode.Open, FileAccess.Read)))
      {
        // Validate file is a mupen file
        var signature = reader.ReadBytes(4);
        var validSig = signature.SequenceEqual(Constants.ValidM64Signature);

        if (!validSig)
        {
          throw new InvalidOperationException(ExceptionsResource.NotM64);
        }

        // TODO: Check offset 0x004 is the header for all m64 versions
        version = (int) reader.ReadUInt32(0x4);
      }

      var parser = ParserFactory.CreateFromVersion(version);
      return parser.Parse(m64);
    }
  }
}