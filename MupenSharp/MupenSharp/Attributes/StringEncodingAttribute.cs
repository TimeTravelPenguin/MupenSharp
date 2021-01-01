#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: StringEncodingAttribute.cs
// 
// Current Data:
// 2020-05-13 7:36 PM
// 
// Creation Date:
// 2020-05-13 5:41 PM

#endregion

using System;
using JetBrains.Annotations;
using MupenSharp.Enums;
using MupenSharp.FileParsing;

namespace MupenSharp.Attributes
{
  /// <summary>
  ///   Attribute used to specify a string encoding and byte size.
  /// </summary>
  [UsedImplicitly]
  [AttributeUsage(AttributeTargets.Property)]
  public class StringEncodingAttribute : Attribute
  {
    /// <summary>
    ///   Sets the string encoding type for reading and writing
    /// </summary>
    public virtual Encoding Encoding { get; }

    /// <summary>
    ///   The size of the string in bytes
    /// </summary>
    public virtual int ByteSize { get; }

    /// <summary>
    ///   Attribute used to specify a string encoding and byte size.
    /// </summary>
    /// <param name="encoding">The type of encoding of the string.</param>
    /// <param name="byteSize">The number of bytes of the string.</param>
    public StringEncodingAttribute(Encoding encoding, int byteSize)
    {
      Encoding = encoding;
      ByteSize = byteSize;
    }
  }
}