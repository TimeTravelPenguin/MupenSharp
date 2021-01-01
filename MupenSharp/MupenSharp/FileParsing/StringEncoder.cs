#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: StringEncoder.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

using System;
using MupenSharp.Enums;

namespace MupenSharp.FileParsing
{
  public static class StringEncoder
  {
    public static string Encode(this byte[] bytes, Encoding encoding)
    {
      return encoding switch
      {
        Encoding.ASCII => bytes.EncodeAscii(),
        Encoding.UTF8 => bytes.EncodeUtf8(),
        _ => throw new ArgumentOutOfRangeException(nameof(encoding), encoding, null)
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
}