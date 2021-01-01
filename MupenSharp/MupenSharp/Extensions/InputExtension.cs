#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenMovieEditor
// Project: MupenSharp
// File Name: InputExtension.cs
// 
// Current Data:
// 2020-05-12 5:11 PM
// 
// Creation Date:
// 2020-05-12 5:07 PM

#endregion

using System.Collections.Generic;
using System.Linq;
using MupenSharp.Enums;
using MupenSharp.Models;

namespace MupenSharp.Extensions
{
  public static class InputExtension
  {
    public static IEnumerable<ControllerInput> GetInputs(this InputModel inputModel)
    {
      return EnumExtensions.EnumToArray<ControllerInput>()
        .Where(input => ((ControllerInput) inputModel.Buttons).HasFlag(input));
    }
  }
}