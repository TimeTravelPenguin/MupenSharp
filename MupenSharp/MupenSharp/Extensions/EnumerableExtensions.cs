#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: EnumerableExtensions.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace MupenSharp.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="IEnumerable{T}" />.
  /// </summary>
  internal static class EnumerableExtensions
  {
    /// <summary>
    ///   Join a collection of elements and return them as a comma-separated string.
    /// </summary>
    /// <typeparam name="T">The object type contained by the IEnumerable.</typeparam>
    /// <param name="collection">The collection of elements to join.</param>
    /// <param name="separator">The separator character. Default is ", ".</param>
    /// <returns>A string composed of the collection elements with separators where appropriate.</returns>
    public static string Join<T>(this IEnumerable<T> collection, string separator = ", ")
    {
      return string.Join(separator, collection);
    }

    /// <summary>
    ///   Check all elements of the collection are equal to a given value.
    /// </summary>
    /// <typeparam name="T">The element type of the IEnumerable that inherits <see cref="IEquatable{T}" />.</typeparam>
    /// <param name="collection">The collection of elements which will be equated.</param>
    /// <param name="value">The value to equate each element of the collection to.</param>
    /// <returns>True if all elements equate <see langword="true" /> to <paramref name="value" />.</returns>
    public static bool IsAll<T>(this IEnumerable<T> collection, T value) where T : IEquatable<T>
    {
      return collection.All(t => t.Equals(value));
    }
  }
}