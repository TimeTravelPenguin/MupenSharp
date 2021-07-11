#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: EnumExtensions.cs
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
  ///   Extension methods for type <see cref="Enum" />.
  /// </summary>
  internal static class EnumExtensions
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