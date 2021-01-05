#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64ParserFactory.cs
// 
// Current Data:
// 2021-01-05 11:02 PM
// 
// Creation Date:
// 2021-01-04 4:23 PM

#endregion

using MupenSharp.Base;
using MupenSharp.Exceptions;
using MupenSharp.FileParsing.Parsers;

namespace MupenSharp.FileParsing
{
  internal class M64ParserFactory : FactoryBase<int, IParser>
  {
    public M64ParserFactory()
    {
      Registry.Add(3, () => new MupenV3Parser());
    }

    public IParser CreateFromVersion(int version)
    {
      if (!Registry.ContainsKey(version))
      {
        throw new InvalidFileVersionException($"'{nameof(version)}' is not a supported version");
      }

      return Registry[version].Invoke();
    }
  }
}