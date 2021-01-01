#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

using System.Collections.Generic;

namespace MupenSharp.Extensions
{
  public static class EnumerableExtensions
  {
    public static string Join<T>(this IEnumerable<T> collection, string separator)
    {
      return string.Join(separator, collection);
    }
  }
}