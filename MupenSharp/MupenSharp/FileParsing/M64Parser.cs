#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64Parser.cs
// 
// Current Data:
// 2021-01-03 8:48 PM
// 
// Creation Date:
// 2021-01-02 11:17 PM

#endregion

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using MupenSharp.FileParsing.Parsers;
using MupenSharp.Models;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing
{
  /// <summary>
  ///   Parser object that can read and write a .m64 file
  /// </summary>
  public class M64Parser
  {
    private readonly M64ParserFactory _parserFactory = new M64ParserFactory();
    private FileInfo _mupenFile;
    private IParser _parser = new MupenNullParser();

    /// <summary>
    ///   Sets the file path of the .m64 file to read
    /// </summary>
    /// <param name="path"></param>
    public void SetFile(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentException(ExceptionsResource.CannotBeNullOrWhitespace, nameof(path));
      }

      if (File.Exists(path))
      {
        _mupenFile = new FileInfo(path);
      }
      else
      {
        _mupenFile = null;
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(path));
      }

      _parser = _parserFactory.CreateFromVersion(_mupenFile);
    }

    /// <summary>
    ///   Checks the first four bytes of a file to validate it is a mupen file. Should be
    ///   <see cref="Constants.ValidM64Signature" /> ("M64\x1A").
    /// </summary>
    /// <returns>Returns true if the file is a valid m64.</returns>
    public bool ValidateM64File()
    {
      if (_mupenFile is null)
      {
        throw new NullReferenceException(string.Format(CultureInfo.InvariantCulture, ExceptionsResource.NullReference,
          nameof(_mupenFile)));
      }

      using var reader = new BinaryReader(_mupenFile?.Open(FileMode.Open, FileAccess.Read));
      var signature = reader.ReadBytes(4);

      return signature.SequenceEqual(Constants.ValidM64Signature);
    }

    /// <summary>
    ///   Parses the file <paramref name="path" />.
    /// </summary>
    /// <param name="path">The path of the .m64 file</param>
    /// <returns>Returns object with data of parsed file</returns>
    public M64 Parse(string path)
    {
      SetFile(path);
      return Parse();
    }

    /// <summary>
    ///   Parses the set file
    /// </summary>
    /// <returns>Returns object with data of parsed file</returns>
    public M64 Parse()
    {
      return _parser.Parse(_mupenFile);
    }
  }
}