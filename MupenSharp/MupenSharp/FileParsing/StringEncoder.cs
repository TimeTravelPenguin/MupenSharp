#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: StringEncoder.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System;
using MupenSharp.Enums;
using MupenSharp.Resources;

#endregion

namespace MupenSharp.FileParsing;

/// <summary>
///     Static class string encoder helper
/// </summary>
internal static class StringEncoder
{
    /// <summary>
    ///     Encode a byte array with a particular <see cref="Encoding" />.
    /// </summary>
    /// <param name="bytes">Byte array to be encoded</param>
    /// <param name="encoding">The encoding type.</param>
    /// <returns>Encoded string</returns>
    public static string Encode(this byte[] bytes, Encoding encoding)
    {
        return encoding switch
        {
            Encoding.ASCII => bytes.EncodeAscii(),
            Encoding.UTF8 => bytes.EncodeUtf8(),
            _ => throw new ArgumentOutOfRangeException(nameof(encoding), encoding,
                ExceptionsResource.InvalidEncodingType)
        };
    }

    private static string EncodeAscii(this byte[] bytes)
    {
        return System.Text.Encoding.ASCII.GetString(bytes);
    }

    private static string EncodeUtf8(this byte[] bytes)
    {
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}