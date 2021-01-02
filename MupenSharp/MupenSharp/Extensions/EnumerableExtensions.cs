#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2021-01-02 10:45 PM
// 
// Creation Date:
// 2021-01-02 8:56 PM

#endregion

using System.Collections.Generic;

namespace MupenSharp.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="IEnumerable{T}" />.
  /// </summary>
  public static class EnumerableExtensions
  {
    /// <summary>
    ///   String joiner helper method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection of elements</param>
    /// <param name="separator">The separator</param>
    /// <returns>A string composed of the collection elements with separators where appropriate.</returns>
    public static string Join<T>(this IEnumerable<T> collection, string separator)
    {
      return string.Join(separator, collection);
    }
  }
}