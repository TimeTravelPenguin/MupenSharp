#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: EnumExtensions.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace MupenSharp.Extensions
{
  /// <summary>
  ///   Extension methods for type <see cref="Enum" />.
  /// </summary>
  public static class EnumExtensions
  {
    /// <summary>
    ///   Returns an array of type <typeparamref name="T" /> containing <see cref="Enum" /> values.
    /// </summary>
    /// <typeparam name="T">
    ///   The element type of the array
    /// </typeparam>
    /// <returns>
    ///   Returns an array of type <typeparamref name="T" />
    /// </returns>
    public static IEnumerable<T> EnumToArray<T>() where T : Enum
    {
      return Enum.GetValues(typeof(T)).Cast<T>();
    }
  }
}