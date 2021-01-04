#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64ParserFactory.cs
// 
// Current Data:
// 2021-01-03 9:55 PM
// 
// Creation Date:
// 2021-01-03 8:51 PM

#endregion

using System;
using System.IO;
using MupenSharp.Base;
using MupenSharp.Extensions;
using MupenSharp.FileParsing.Parsers;
using MupenSharp.Resources;

namespace MupenSharp.FileParsing
{
  internal class M64ParserFactory : FactoryBase<int, IParser>
  {
    public M64ParserFactory()
    {
      Registry.Add(0, () => new MupenNullParser());
      Registry.Add(3, () => new MupenV3Parser());
    }

    public IParser CreateFromVersion(FileInfo mupenFile)
    {
      if (mupenFile is null)
      {
        throw new NullReferenceException(ExceptionsResource.FilePathNotSet);
      }

      if (!mupenFile.Exists)
      {
        throw new FileNotFoundException(ExceptionsResource.InvalidFilePath, nameof(mupenFile));
      }

      if (!M64Parser.ValidateM64File(mupenFile))
      {
        throw new InvalidOperationException(ExceptionsResource.NotM64);
      }

      using var reader = new BinaryReader(mupenFile?.Open(FileMode.Open, FileAccess.Read));

      // TODO: Check offset 0x004 is the header for all m64 versions
      var version = (int) reader.ReadUInt32(0x4);

      return Registry.TryGetValue(version, out var parser)
        ? parser.Invoke()
        : new MupenNullParser();
    }
  }
}