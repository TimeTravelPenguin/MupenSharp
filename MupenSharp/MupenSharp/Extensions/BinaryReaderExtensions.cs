#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: BinaryReaderExtensions.cs
// 
// Current Data:
// 2021-01-07 12:03 PM
// 
// Creation Date:
// 2021-01-06 9:56 AM

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
  ///   Extension methods for <see cref="BinaryReader" />.
  /// </summary>
  public static class BinaryReaderExtensions
  {
    /// <summary>
    ///   Read a single byte from a given offset of a binary stream.
    /// </summary>
    /// <param name="reader">The binary reader.</param>
    /// <param name="offset">The offset byte to read onward from.</param>
    /// <returns>The byte read.</returns>
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

    /// <summary>
    ///   Reads a number of bytes from a given offset of a binary stream.
    /// </summary>
    /// <param name="reader">The binary reader.</param>
    /// <param name="offset">The offset byte to read onward from.</param>
    /// <param name="length">The number of bytes to read from the offset.</param>
    /// <returns>The array of bytes read.</returns>
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

    /// <summary>
    ///   Reads 4 bytes from a given offset of a binary stream and returns it as an <see cref="uint" />.
    /// </summary>
    /// <param name="reader">The binary reader.</param>
    /// <param name="offset">The offset byte to read onward from.</param>
    /// <returns>Returns the read <see cref="uint" /> value.</returns>
    public static uint ReadUInt32([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      return BitConverter.ToUInt32(reader.ReadBytes(offset, 4), 0);
    }


    /// <summary>
    ///   Reads 2 bytes from a given offset of a binary stream and returns it as an <see cref="ushort" />.
    /// </summary>
    /// <param name="reader">The binary reader.</param>
    /// <param name="offset">The offset byte to read onward from.</param>
    /// <returns>Returns the read <see cref="ushort" /> value.</returns>
    public static ushort ReadUInt16([NotNull] this BinaryReader reader, long offset)
    {
      if (reader is null)
      {
        throw new ArgumentNullException(nameof(reader),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, reader));
      }

      return BitConverter.ToUInt16(reader.ReadBytes(offset, 2), 0);
    }


    /// <summary>
    ///   Reads a number of bytes from a given offset of a binary stream and returns it as a string with a specific encoding.
    /// </summary>
    /// <param name="reader">The binary reader.</param>
    /// <param name="offset">The offset byte to read onward from.</param>
    /// <param name="length">The number of bytes to read.</param>
    /// <param name="encoding">The encoding type of the string.</param>
    /// <returns>A string, decoded from the read bytes.</returns>
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