#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: StringEncoder.cs
// 
// Current Data:
// 2020-05-13 11:31 AM
// 
// Creation Date:
// 2020-05-13 11:22 AM

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