#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: MupenV3Parser.cs
// 
// Current Data:
// 2021-01-06 1:14 AM
// 
// Creation Date:
// 2021-01-04 11:50 PM

#endregion

using System;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using MupenSharp.Enums;
using MupenSharp.Exceptions;
using MupenSharp.Extensions;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing.Parsers
{
  internal class MupenV3Parser : IParser
  {
    /// <summary>
    /// </summary>
    /// <param name="m64File"></param>
    /// <returns></returns>
    /// <exception cref="InvalidFrameCountException">
    ///   Raises exception if the header's frame count does not match the file body length
    /// </exception>
    public M64 Parse([NotNull] FileInfo m64File)
    {
      if (m64File is null)
      {
        throw new NullReferenceException(ExceptionsResource.FilePathNotSet);
      }

      if (!m64File.Exists)
      {
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(m64File));
      }

      using var reader = new BinaryReader(m64File.Open(FileMode.Open, FileAccess.Read));

      // TODO: Implement plugin details & UID

      var m64 = new M64
      {
        Version = reader.ReadUInt32(0x4),
        VerticalInterrupts = reader.ReadUInt32(0xC),
        RerecordCount = reader.ReadUInt32(0x10),
        ViPerSecond = reader.ReadByte(0x14),
        NumberOfControllers = reader.ReadByte(0x15),
        InputFrames = reader.ReadUInt32(0x18),
        MovieStartType = reader.ReadUInt16(0x1C),
        ControllerFlags = reader.ReadUInt32(0x20),
        NameOfRom = reader.ReadString(0xC4, 32, Encoding.ASCII),
        Crc32 = reader.ReadUInt32(0xE4),
        CountryCode = reader.ReadUInt16(0xE8),
        Author = reader.ReadString(0x222, 222, Encoding.UTF8),
        MovieDescription = reader.ReadString(0x300, 256, Encoding.UTF8)
      };

      var numControllers = (m64.ControllerFlags & (uint) ControllerProperty.ControllerOnePresent)
                           + ((m64.ControllerFlags & (uint) ControllerProperty.ControllerTwoPresent) >> 1)
                           + ((m64.ControllerFlags & (uint) ControllerProperty.ControllerThreePresent) >> 2)
                           + ((m64.ControllerFlags & (uint) ControllerProperty.ControllerFourPresent) >> 3);

#if DEBUG
      Debug.Assert(0 < numControllers && numControllers <= 4);
#endif

      if (numControllers == 0)
      {
        // TODO: Is this bad? Will someone need to edit a no-controller TAS???
        throw new NoControllerException("m64 file has no enabled controllers");
      }

      /*
        Mupen does not delete old inputs when writing to an m64 file.
        E.g. if someone loads a save-state and works over the top of the work.
        Because of this, it is possible for the header to have an InputFrames
        that is smaller than the list of inputs. This is because Mupen64 plays the file
        up until the header length. Any other data after is ignored.
       */

      // Check the file size (minus the header) is not shorter to the header expected value
      var inputsBitLength = reader.BaseStream.Length - 0x400;
      var headerExpectedLength = m64.InputFrames * numControllers;

      if (inputsBitLength < headerExpectedLength)
      {
        throw new InvalidFrameCountException(
          $"File size is too small. The header expects a minimum of {m64.InputFrames * numControllers} bytes of input frame data, but got {reader.BaseStream.Length - 0x400}");
      }

      // TODO: Implement multiple controller support
      reader.BaseStream.Seek(0x400, SeekOrigin.Begin);
      while (reader.BaseStream.Position != reader.BaseStream.Length)
      {
        m64.ControllerInputs.Add((InputModel) reader.ReadBytes(4));
      }

      return m64;
    }

    public bool ValidateFile([NotNull] FileInfo m64File)
    {
      if (m64File is null)
      {
        throw new NullReferenceException(ExceptionsResource.FilePathNotSet);
      }

      if (!m64File.Exists)
      {
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(m64File));
      }

      using var reader = new BinaryReader(m64File.Open(FileMode.Open, FileAccess.Read));

      return reader.ReadBytes(0x16, 2).IsAll<byte>(0)
             && reader.ReadBytes(0x1E, 2).IsAll<byte>(0)
             && reader.ReadBytes(0x24, 160).IsAll<byte>(0)
             && reader.ReadBytes(0xEA, 56).IsAll<byte>(0);
    }

    public void SplitControllerInputs(M64 m64)
    {
      /*
       * Concept:
       * Read byte array of controllers
       */
    }
  }
}