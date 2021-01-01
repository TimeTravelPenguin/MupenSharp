#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: M64ParserExtensions.cs
// 
// Current Data:
// 2020-06-09 10:33 PM
// 
// Creation Date:
// 2020-05-13 10:27 AM

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using JetBrains.Annotations;
using MupenSharp.Enums;
using MupenSharp.FileParsing;
using MupenSharp.Resources;

namespace MupenSharp.Extensions
{
  public static class M64ParserExtensions
  {
    public static uint ReadBytesAndConvertUInt32([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      reader.BaseStream.Seek(offset, SeekOrigin.Begin);
      return BitConverter.ToUInt32(reader.ReadBytes(4), 0);
    }

    public static ushort ReadBytesAndConvertUInt16([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      reader.BaseStream.Seek(offset, SeekOrigin.Begin);
      return BitConverter.ToUInt16(reader.ReadBytes(2), 0);
    }

    public static string ReadBytesAndConvertString([NotNull] this BinaryReader reader, long offset, Encoding encoding)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      reader.BaseStream.Seek(offset, SeekOrigin.Begin);
      var bytes = new List<byte>();
      byte current;
      while ((current = reader.ReadByte()) != 0x0)
      {
        bytes.Add(current);
      }

      return bytes.ToArray().Encode(encoding);
    }

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
  }
}