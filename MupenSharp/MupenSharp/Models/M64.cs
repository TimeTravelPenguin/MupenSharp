using System;
using System.Collections.Generic;
using MupenSharp.Attributes;
using MupenSharp.Enums;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MupenSharp.Models;

/// <summary>
///   Stores data of a .m64 file.
///   Refer to the <see href="http://tasvideos.org/EmulatorResources/Mupen/M64.html">header documentation</see> for more
///   information.
/// </summary>
public class M64 : ReactiveObject, IM64
{
  /// <summary>
  ///   The UID of the movie.
  /// </summary>
  [Reactive]
  public int MovieUid { get; set; }

  /// <summary>
  ///   The internal name of ROM used when recording, directly from ROM.
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.ASCII, 32)]
  public string RomName { get; set; }

  /// <summary>
  ///   The name of video plugin used when recording, directly from plugin
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.ASCII, 64)]
  public string VideoPluginName { get; set; }

  /// <summary>
  ///   The name of audio plugin used when recording, directly from plugin
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.ASCII, 64)]
  public string AudioPluginName { get; set; }

  /// <summary>
  ///   The name of input plugin used when recording, directly from plugin
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.ASCII, 64)]
  public string InputPluginName { get; set; }

  /// <summary>
  ///   The name of rsp plugin used when recording, directly from plugin
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.ASCII, 64)]
  public string RspPluginName { get; set; }

  /// <summary>
  ///   The collection of controller inputs every input frame and controller,
  ///   containing analogue x, y positions and buttons pressed.
  /// </summary>
  // TODO: Implement multiple controller support
  [Reactive]
  public IList<InputModel> ControllerInputs { get; set; }

  /// <summary>
  ///   Version number. Should be 3.
  /// </summary>
  [Reactive]
  public uint Version { get; set; }

  /// <summary>
  ///   The number of frames (vertical interrupts).
  /// </summary>
  [Reactive]
  public uint ViCount { get; set; }

  /// <summary>
  ///   The number of file rerecords.
  /// </summary>
  [Reactive]
  public uint RerecordCount { get; set; }

  /// <summary>
  ///   Frames (vertical interrupts) per second.
  /// </summary>
  [Reactive]
  public uint ViPerSecond { get; set; }

  /// <summary>
  ///   The number of controllers enabled for the file.
  /// </summary>
  [Reactive]
  public uint ControllerCount { get; set; }

  /// <summary>
  ///   The movie start type.
  ///   <list type="table">
  ///     <listheader>
  ///       <term>
  ///         Value
  ///       </term>
  ///       <term>
  ///         Description
  ///       </term>
  ///     </listheader>
  ///     <item>
  ///       <term>1</term>
  ///       <term>
  ///         movie begins from snapshot (the snapshot will be loaded from an external file with the movie filename.
  ///         and a .st extension)
  ///       </term>
  ///     </item>
  ///     <item>
  ///       <term> 2</term>
  ///       <term>
  ///         movie begins from power-on
  ///       </term>
  ///     </item>
  ///     <item>
  ///       <term>other values</term>
  ///       <term>
  ///         invalid movie
  ///       </term>
  ///     </item>
  ///   </list>
  /// </summary>
  [Reactive]
  public ushort MovieStartType { get; set; }

  /// <summary>
  ///   Flags set for each controller.
  ///   <list type="bullet">
  ///     <item>
  ///       <term>bit 0</term>
  ///       <description>
  ///         Controller 1 present
  ///       </description>
  ///     </item>
  ///     <item>
  ///       <term>bit 4</term>
  ///       <description>
  ///         Controller 1 has mempak
  ///       </description>
  ///     </item>
  ///     <item>
  ///       <term>bit 8</term>
  ///       <description>
  ///         Controller 1 has rumblepak
  ///       </description>
  ///     </item>
  ///   </list>
  ///   +1..3 for controllers 2..4.
  /// </summary>
  [Reactive]
  public uint ControllerFlags { get; set; }

  /// <summary>
  ///   CRC32 of ROM used when recording, directly from ROM.
  /// </summary>
  [Reactive]
  public uint Crc32 { get; set; }

  /// <summary>
  ///   The country code of ROM used when recording, directly from ROM.
  /// </summary>
  [Reactive]
  public ushort RegionCode { get; set; }

  /// <summary>
  ///   The movie description info.
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.UTF8, 256)]
  public string MovieDescription { get; set; }

  /// <summary>
  ///   The number of input samples from the controllers (for one controller).
  /// </summary>
  [Reactive]
  public uint InputCount { get; set; }

  /// <summary>
  ///   The Author info of the movie.
  /// </summary>
  [Reactive]
  [StringEncoding(Encoding.UTF8, 222)]
  public string Author { get; set; }

  /// <summary>
  ///   Returns if the current controller is present in the given file.
  /// </summary>
  /// <param name="controller">The controller to check for.</param>
  /// <returns>A boolean reflecting whether the controller is present.</returns>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public bool IsControllerPresent(Controller controller)
  {
    var controllerProperty = controller switch
    {
      Controller.ControllerOne => ControllerProperty.ControllerOnePresent,
      Controller.ControllerTwo => ControllerProperty.ControllerTwoPresent,
      Controller.ControllerThree => ControllerProperty.ControllerThreePresent,
      Controller.ControllerFour => ControllerProperty.ControllerFourPresent,
      _ => throw new ArgumentOutOfRangeException(nameof(controller), controller, null)
    };

    return ((ControllerProperty)ControllerFlags).HasFlag(controllerProperty);
  }

  /// <summary>
  ///   Get the input of a particular controller.
  /// </summary>
  /// <param name="controller">The controller to get the input of.</param>
  /// <param name="input">The input frame of interest.</param>
  /// <returns>Returns the input of the controller for that input frame.</returns>
  public InputModel GetControllerInput(Controller controller, int input)
  {
    if (!IsControllerPresent(controller))
    {
      throw new Exception($"Controller '{controller}' is not present.");
    }

    var offset = (int)controller;
    if (ControllerInputs.Count * ControllerCount > input + offset)
    {
      throw new IndexOutOfRangeException($"The input '{input}' falls out of range.");
    }

    return ControllerInputs[input + offset];
  }

  /// <summary>
  ///   Get all inputs for a given controller.
  /// </summary>
  /// <param name="controller">The controller to get the inputs.</param>
  /// <returns>Returns the inputs of the given controller.</returns>
  public IEnumerable<InputModel> GetControllerInputs(Controller controller)
  {
    if (!IsControllerPresent(controller))
    {
      throw new Exception($"Controller '{controller}' is not present.");
    }

    var inputs = new List<InputModel>(ControllerInputs.Count);
    if (ControllerInputs.Count == 0)
    {
      return inputs;
    }

    var offset = (int)controller;
    for (var i = 0; i < ControllerInputs.Count; i += (int)ControllerCount)
    {
      inputs.Add(ControllerInputs[i + offset]);
    }

    return inputs;
  }
}