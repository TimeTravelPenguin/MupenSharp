#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2020-05-12 6:29 PM
// 
// Creation Date:
// 2020-05-12 6:27 PM

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