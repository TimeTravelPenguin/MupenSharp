#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: InputModel.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using MupenSharp.Base;
using MupenSharp.Extensions;
using MupenSharp.Resources;

namespace MupenSharp.Models
{
  public class InputModel : PropertyChangedBase
  {
    public sbyte X { get; set; }
    public sbyte Y { get; set; }
    public ushort Buttons { get; set; }

    /// <summary>
    ///   InputModel representing data contained within an .m64 file.
    /// </summary>
    /// <param name="input">
    ///   A 4-byte value containing X and Y analogue positions, and the XOR of buttons pressed.
    ///   The first two bytes are the XOR of the buttons, followed by the X and Y inputs
    ///   represented by 1-byte each.
    ///   <para />
    ///   <example>
    ///     Given the input 0xC0182541, this can be seen as:
    ///     <list type="bullet">
    ///       <item>
    ///         <term>Button Flags</term>
    ///         <description>2-bytes = C0 18</description>
    ///       </item>
    ///       <item>
    ///         <term>X Analogue</term>
    ///         <description>1-byte = 25</description>
    ///       </item>
    ///       <item>
    ///         <term>Y Analogue</term>
    ///         <description>1-byte = 41</description>
    ///       </item>
    ///     </list>
    ///   </example>
    ///   <remarks>
    ///     When reading from an .m64 file from offset 0x400, 4-bytes at a time, the following code works if the
    ///     hex input is NOT REVERSED.
    ///   </remarks>
    /// </param>
    public InputModel([NotNull] byte[] input)
    {
      // input = byte[4] { AA, BB, CC, DD }

      if (input is null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length != 4)
      {
        throw new InvalidOperationException($"{nameof(input)} should be 4 bytes, not {input.Length}");
      }

      // X = CC
      X = unchecked((sbyte) input[2]);

      // Y = DD
      Y = unchecked((sbyte) input[3]);

      // Buttons = AA BB
      Buttons = BitConverter.ToUInt16(input
        .Take(2)
        .Reverse() // Reverse because BitConverter reverses order due to being low-endien
        .ToArray(), 0);
    }

    /// <summary>
    ///   Implicitly converts a <see cref="byte" /> array into an InputModel
    /// </summary>
    /// <param name="input"></param>
    public static explicit operator InputModel(byte[] input)
    {
      if (input is null)
      {
        throw new ArgumentNullException(nameof(input),
          string.Format(CultureInfo.InvariantCulture, ExceptionsResource.ArgumentIsNull, nameof(input)));
      }

      if (input.Length != 4)
      {
        throw new ArgumentException(ExceptionsResource.InputArrayInvalidLength, nameof(input));
      }

      return new InputModel(input);
    }

    public override string ToString()
    {
      return $"({Convert.ToInt32(X)},{Convert.ToInt32(Y)}) {this.GetInputs().Join(", ")}";
    }

    /// <summary>
    ///   Explicitly converts a
    /// </summary>
    /// <param name="input"></param>
    public static explicit operator byte[]([NotNull] InputModel input)
    {
      if (input is null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      var x = unchecked((byte) input.X);
      var y = unchecked((byte) input.Y);
      var buttons = BitConverter.GetBytes(input.Buttons);

      // Buttons are reversed because BitConverter reverses order due to being low-endien
      return new[] {buttons[1], buttons[0], x, y};
    }
  }
}