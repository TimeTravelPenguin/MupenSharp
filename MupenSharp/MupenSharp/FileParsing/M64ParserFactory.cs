#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: M64ParserFactory.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using MupenSharp.Base;
using MupenSharp.Exceptions;
using MupenSharp.FileParsing.Parsers;

#endregion

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