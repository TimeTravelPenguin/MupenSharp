#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: MupenV3Parser.cs
// 
// Current Data:
// 2021-07-09 12:54 PM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using MupenSharp.Attributes;
using MupenSharp.Enums;
using MupenSharp.Exceptions;
using MupenSharp.Extensions;
using MupenSharp.Helpers;
using MupenSharp.Models;
using MupenSharp.Resources;

#endregion

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

      var stringAttribs = typeof(M64).GetPropertyAttributeDictionaryOfType<StringEncodingAttribute>();

      var m64 = new M64
      {
        Version = reader.ReadUInt32(0x4),
        MovieUid = reader.ReadInt32(0x8),
        ViCount = reader.ReadUInt32(0xC),
        RerecordCount = reader.ReadUInt32(0x10),
        ViPerSecond = reader.ReadByte(0x14),
        ControllerCount = reader.ReadByte(0x15),
        InputCount = reader.ReadUInt32(0x18),
        MovieStartType = reader.ReadUInt16(0x1C),
        ControllerFlags = reader.ReadUInt32(0x20),
        Crc32 = reader.ReadUInt32(0xE4),
        RegionCode = reader.ReadUInt16(0xE8),

        RomName = reader.ReadString(0xC4, stringAttribs[nameof(M64.RomName)].ByteSize,
          stringAttribs[nameof(M64.RomName)].Encoding),

        VideoPluginName = reader.ReadString(0xC4, stringAttribs[nameof(M64.VideoPluginName)].ByteSize,
          stringAttribs[nameof(M64.VideoPluginName)].Encoding),

        AudioPluginName = reader.ReadString(0xC4, stringAttribs[nameof(M64.AudioPluginName)].ByteSize,
          stringAttribs[nameof(M64.AudioPluginName)].Encoding),

        InputPluginName = reader.ReadString(0xC4, stringAttribs[nameof(M64.InputPluginName)].ByteSize,
          stringAttribs[nameof(M64.InputPluginName)].Encoding),

        RspPluginName = reader.ReadString(0xC4, stringAttribs[nameof(M64.RspPluginName)].ByteSize,
          stringAttribs[nameof(M64.RspPluginName)].Encoding),

        Author = reader.ReadString(0x222, stringAttribs[nameof(M64.Author)].ByteSize,
          stringAttribs[nameof(M64.Author)].Encoding),

        MovieDescription = reader.ReadString(0x300, stringAttribs[nameof(M64.MovieDescription)].ByteSize,
          stringAttribs[nameof(M64.MovieDescription)].Encoding)
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
        Because of this, it is possible for the header to have an InputCount
        that is smaller than the list of inputs. This is because Mupen64 plays the file
        up until the header length. Any other data after is ignored.
       */

      // Check the file size (minus the header) is not shorter to the header expected value
      var inputsBitLength = reader.BaseStream.Length - 0x400;
      var headerExpectedLength = m64.InputCount * numControllers;

      if (inputsBitLength < headerExpectedLength)
      {
        throw new InvalidFrameCountException(
          $"File size is too small. The header expects a minimum of {m64.InputCount * numControllers} bytes of input frame data, but got {reader.BaseStream.Length - 0x400}");
      }

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