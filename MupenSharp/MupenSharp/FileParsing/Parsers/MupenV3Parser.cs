#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: MupenV3Parser.cs
// 
// Current Data:
// 2021-01-04 12:54 PM
// 
// Creation Date:
// 2021-01-03 8:51 PM

#endregion

using System;
using System.IO;
using MupenSharp.Enums;
using MupenSharp.Extensions;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing.Parsers
{
  internal class MupenV3Parser : IParser
  {
    public M64 Parse(FileInfo m64File)
    {
      /* TODO: Implement header validation to check for:
        1. A valid .m64 file for Mupen.
        2. Validate file version, header properties and length
      */

      if (m64File is null)
      {
        throw new NullReferenceException(ExceptionsResource.FilePathNotSet);
      }

      if (!m64File.Exists)
      {
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(m64File));
      }

      using var reader = new BinaryReader(m64File?.Open(FileMode.Open, FileAccess.Read));

      var m64 = new M64
      {
        Version = reader.ReadUInt32(0x4),
        VerticalInterrupts = reader.ReadUInt32(0xC),
        RerecordCount = reader.ReadUInt32(0x10),
        ViPerSecond = reader.ReadByte(0x15),
        NumberOfControllers = reader.ReadByte(0x16),
        InputFrames = reader.ReadUInt32(0x18),
        MovieStartType = reader.ReadUInt16(0x1C),
        ControllerFlags = reader.ReadUInt32(0x20),
        NameOfRom = reader.ReadString(0xC4, 32, Encoding.ASCII),
        Crc32 = reader.ReadUInt32(0xE4),
        CountryCode = reader.ReadUInt16(0xE8),
        Author = reader.ReadString(0x222, 222, Encoding.UTF8),
        MovieDescription = reader.ReadString(0x300, 256, Encoding.UTF8)
      };

      // TODO: Implement multiple controller support
      var frame = 0;
      reader.BaseStream.Seek(0x400, SeekOrigin.Begin);
      while (reader.BaseStream.Position != reader.BaseStream.Length && frame < m64.InputFrames)
      {
        m64.Inputs.Add((InputModel) reader.ReadBytes(4));
        frame++;
      }

      return m64;
    }
  }
}