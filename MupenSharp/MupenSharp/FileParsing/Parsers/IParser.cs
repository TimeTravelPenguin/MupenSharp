#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: IParser.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System.IO;
using MupenSharp.Models;

#endregion

namespace MupenSharp.FileParsing.Parsers
{
  /// <summary>
  ///   Parser Interface for all m64 file versions
  /// </summary>
  public interface IParser
  {
    /// <summary>
    ///   Create an object containing data of a specific m64 file
    /// </summary>
    /// <param name="m64File">The file to parse</param>
    /// <returns></returns>
    M64 Parse(FileInfo m64File);

    /// <summary>
    ///   Validates a file is a valid m64 file.
    /// </summary>
    /// <param name="m64File">The m64 file to validate.</param>
    /// <returns>True if the file is valid.</returns>
    bool ValidateFile(FileInfo m64File);
  }
}