#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: BinaryReaderExtensions.cs
// 
// Current Data:
// 2021-01-04 12:52 PM
// 
// Creation Date:
// 2021-01-03 8:51 PM

#endregion

using System;
using System.Globalization;
using System.IO;
using JetBrains.Annotations;
using MupenSharp.Enums;
using MupenSharp.FileParsing;
using MupenSharp.Resources;

namespace MupenSharp.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="M64Parser" />.
  /// </summary>
  public static class BinaryReaderExtensions
  {
    public static byte ReadByte([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      reader.BaseStream.Seek(offset, SeekOrigin.Begin);
      return reader.ReadByte();
    }

    public static byte[] ReadBytes([NotNull] this BinaryReader reader, long offset, int length)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      reader.BaseStream.Seek(offset, SeekOrigin.Begin);
      return reader.ReadBytes(length);
    }

    public static uint ReadUInt32([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      return BitConverter.ToUInt32(reader.ReadBytes(offset, 4), 0);
    }

    public static ushort ReadUInt16([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      return BitConverter.ToUInt16(reader.ReadBytes(offset, 2), 0);
    }

    public static string ReadString([NotNull] this BinaryReader reader, long offset, int length, Encoding encoding)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      return reader.ReadBytes(offset, length).Encode(encoding);
    }
  }
}