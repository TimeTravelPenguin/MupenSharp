#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InputExtension.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

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