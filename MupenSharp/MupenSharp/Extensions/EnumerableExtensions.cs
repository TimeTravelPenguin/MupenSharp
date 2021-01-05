#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2021-01-05 10:37 PM
// 
// Creation Date:
// 2021-01-02 11:17 PM

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

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

    public static bool IsAll<T>(this IEnumerable<T> collection, T value) where T : IEquatable<T>
    {
      return collection.All(t => t.Equals(value));
    }
  }
}