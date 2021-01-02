#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InputExtension.cs
// 
// Current Data:
// 2021-01-02 10:46 PM
// 
// Creation Date:
// 2021-01-02 8:56 PM

#endregion

using System.Collections.Generic;
using System.Linq;
using MupenSharp.Enums;
using MupenSharp.Models;

namespace MupenSharp.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="InputModel" />.
  /// </summary>
  public static class InputExtension
  {
    /// <summary>
    ///   Gets the collection of controller buttons pressed for a particular <see cref="InputModel" />.
    /// </summary>
    /// <param name="inputModel">The current input</param>
    /// <returns>A collection of buttons pressed.</returns>
    public static IEnumerable<ControllerInput> GetInputs(this InputModel inputModel)
    {
      return EnumExtensions.EnumToArray<ControllerInput>()
        .Where(input => ((ControllerInput) inputModel.Buttons).HasFlag(input));
    }
  }
}