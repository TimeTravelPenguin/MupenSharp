using System;
using System.IO;
using System.Linq;
using AllOverIt.Assertion;
using JetBrains.Annotations;
using MupenSharp.Attributes;
using MupenSharp.Enums;
using MupenSharp.Exceptions;
using MupenSharp.Extensions;
using MupenSharp.Helpers;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing;

/// <summary>
///     A parser for .m64 version 3 files
/// </summary>
public class MupenV3Parser
{
    /// <summary>
    ///     Validates that all reserved offsets have a value of zero.
    /// </summary>
    /// <param name="m64File">The file to process</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    public static bool ValidateReservedOffsets(FileInfo m64File)
    {
        if (!m64File.WhenNotNull(nameof(m64File)).Exists)
            throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(m64File));

        using var reader = new BinaryReader(m64File.Open(FileMode.Open, FileAccess.Read));

        return reader.ReadBytes(0x16, 2).All(x => x == 0)
               && reader.ReadBytes(0x1E, 2).All(x => x == 0)
               && reader.ReadBytes(0x24, 160).All(x => x == 0)
               && reader.ReadBytes(0xEA, 56).All(x => x == 0);
    }

    /// <summary>
    ///     Parses the file <paramref name="path" />.
    /// </summary>
    /// <param name="path">The path of the .m64 file</param>
    /// <returns>Returns object with data of parsed file</returns>
    public static M64 Parse(string path)
    {
        var m64 = new FileInfo(path);

        using (var reader = new BinaryReader(m64.Open(FileMode.Open, FileAccess.Read)))
        {
            // Validate file is a mupen file
            var signature = reader.ReadBytes(4);
            var validSig = signature.SequenceEqual(Constants.ValidM64Signature);

            if (!validSig) throw new InvalidOperationException(ExceptionsResource.NotM64);
        }

        return ParseFile(m64);
    }

    private static M64 ParseFile([NotNull] FileInfo m64File)
    {
        if (!ValidateReservedOffsets(m64File))
            throw new InvalidOperationException(ExceptionsResource.ReservedOffsetValueInvalid);

        using var reader = new BinaryReader(m64File.Open(FileMode.Open, FileAccess.Read));

        var stringAttributes =
            typeof(M64).GetPropertyAttributeDictionaryOfType<StringEncodingAttribute>();

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

            RomName =
                reader.ReadString(0xC4, stringAttributes[nameof(M64.RomName)].ByteSize,
                    stringAttributes[nameof(M64.RomName)].Encoding),

            VideoPluginName =
                reader.ReadString(0x122, stringAttributes[nameof(M64.VideoPluginName)].ByteSize,
                    stringAttributes[nameof(M64.VideoPluginName)].Encoding),

            AudioPluginName =
                reader.ReadString(0x162, stringAttributes[nameof(M64.AudioPluginName)].ByteSize,
                    stringAttributes[nameof(M64.AudioPluginName)].Encoding),

            InputPluginName =
                reader.ReadString(0x1A2, stringAttributes[nameof(M64.InputPluginName)].ByteSize,
                    stringAttributes[nameof(M64.InputPluginName)].Encoding),

            RspPluginName =
                reader.ReadString(0x1E2, stringAttributes[nameof(M64.RspPluginName)].ByteSize,
                    stringAttributes[nameof(M64.RspPluginName)].Encoding),

            Author =
                reader.ReadString(0x222, stringAttributes[nameof(M64.Author)].ByteSize,
                    stringAttributes[nameof(M64.Author)].Encoding),

            MovieDescription =
                reader.ReadString(0x300, stringAttributes[nameof(M64.MovieDescription)].ByteSize,
                    stringAttributes[nameof(M64.MovieDescription)].Encoding)
        };

        var numControllers =
            (m64.ControllerFlags & (uint)ControllerProperty.ControllerOnePresent)
            + ((m64.ControllerFlags & (uint)ControllerProperty.ControllerTwoPresent) >> 1)
            + ((m64.ControllerFlags & (uint)ControllerProperty.ControllerThreePresent) >> 2)
            + ((m64.ControllerFlags & (uint)ControllerProperty.ControllerFourPresent) >> 3);

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
            throw new InvalidFrameCountException(
                $"File size is too small. The header expects a minimum of {m64.InputCount * numControllers} bytes of input frame data, but got {reader.BaseStream.Length - 0x400}");

        reader.BaseStream.Seek(0x400, SeekOrigin.Begin);
        while (reader.BaseStream.Position != reader.BaseStream.Length)
            m64.ControllerInputs.Add((InputModel)reader.ReadBytes(4));

        return m64;
    }
}