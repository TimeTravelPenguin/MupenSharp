#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64Parser.cs
// 
// Current Data:
// 2021-01-02 11:02 PM
// 
// Creation Date:
// 2021-01-02 8:56 PM

#endregion

using System;
using System.IO;
using MupenSharp.Enums;
using MupenSharp.Extensions;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing
{
  /// <summary>
  ///   Parser object that can read and write a .m64 file
  /// </summary>
  public class M64Parser
  {
    private FileInfo _mupenFile;

    /// <summary>
    ///   Sets the file path of the .m64 file to read
    /// </summary>
    /// <param name="path"></param>
    public void SetFile(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentException(ExceptionsResource.CannotBeNullOrWhitespace, nameof(path));
      }

      if (File.Exists(path))
      {
        _mupenFile = new FileInfo(path);
      }
      else
      {
        _mupenFile = null;
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(path));
      }
    }

    /// <summary>
    ///   Parses the file <paramref name="path" />.
    /// </summary>
    /// <param name="path">The path of the .m64 file</param>
    /// <returns>Returns object with data of parsed file</returns>
    public M64 Parse(string path)
    {
      SetFile(path);
      return Parse();
    }

    /// <summary>
    ///   Parses the set file
    /// </summary>
    /// <returns>Returns object with data of parsed file</returns>
    public M64 Parse()
    {
      /* TODO: Implement header validation to check for:
        1. A valid .m64 file for Mupen.
        2. Validate file version, header properties and length
      */

      if (_mupenFile is null)
      {
        throw new NullReferenceException(ExceptionsResource.FilePathNotSet);
      }

      if (!_mupenFile.Exists)
      {
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(_mupenFile));
      }

      using var reader = new BinaryReader(_mupenFile?.Open(FileMode.Open, FileAccess.Read));

      var m64 = new M64
      {
        Version = reader.ReadBytesAndConvertUInt32(0x4),
        VerticalInterrupts = reader.ReadBytesAndConvertUInt32(0xC),
        RerecordCount = reader.ReadBytesAndConvertUInt32(0x10),
        ViPerSecond = reader.ReadByte(0x15),
        NumberOfControllers = reader.ReadByte(0x16),
        InputFrames = reader.ReadBytesAndConvertUInt32(0x18),
        MovieStartType = reader.ReadBytesAndConvertUInt16(0x1C),
        ControllerFlags = reader.ReadBytesAndConvertUInt32(0x20),
        NameOfRom = reader.ReadBytesAndConvertString(0xC4, Encoding.ASCII),
        Crc32 = reader.ReadBytesAndConvertUInt32(0xE4),
        CountryCode = reader.ReadBytesAndConvertUInt16(0xE8),
        Author = reader.ReadBytesAndConvertString(0x222, Encoding.UTF8),
        MovieDescription = reader.ReadBytesAndConvertString(0x300, Encoding.UTF8)
      };

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