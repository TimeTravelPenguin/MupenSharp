#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: IM64.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace MupenSharp.Models
{
  /// <summary>
  ///   M64 file interface
  /// </summary>
  public interface IM64
  {
    /// <summary>
    ///   Version number. Should be 3.
    /// </summary>
    uint Version { get; set; }

    /// <summary>
    ///   The number of frames (vertical interrupts).
    /// </summary>
    uint ViCount { get; set; }

    /// <summary>
    ///   The number of file rerecords.
    /// </summary>
    uint RerecordCount { get; set; }

    /// <summary>
    ///   Frames (vertical interrupts) per second.
    /// </summary>
    uint ViPerSecond { get; set; }

    /// <summary>
    ///   The number of controllers enabled for the file.
    /// </summary>
    uint ControllerCount { get; set; }

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
    ushort MovieStartType { get; set; }

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
    uint ControllerFlags { get; set; }

    /// <summary>
    ///   The internal name of ROM used when recording, directly from ROM.
    /// </summary>
    string RomName { get; set; }

    /// <summary>
    ///   The name of video plugin used when recording, directly from plugin
    /// </summary>
    string VideoPluginName { get; set; }

    /// <summary>
    ///   The name of audio plugin used when recording, directly from plugin
    /// </summary>
    string AudioPluginName { get; set; }

    /// <summary>
    ///   The name of input plugin used when recording, directly from plugin
    /// </summary>
    string InputPluginName { get; set; }

    /// <summary>
    ///   The name of rsp plugin used when recording, directly from plugin
    /// </summary>
    string RspPluginName { get; set; }

    /// <summary>
    ///   CRC32 of ROM used when recording, directly from ROM.
    /// </summary>
    uint Crc32 { get; set; }

    /// <summary>
    ///   The country code of ROM used when recording, directly from ROM.
    /// </summary>
    ushort RegionCode { get; set; }

    /// <summary>
    ///   The movie description info.
    /// </summary>
    string MovieDescription { get; set; }

    /// <summary>
    ///   The collection of controller inputs every input frame and controller,
    ///   containing analogue x, y positions and buttons pressed.
    /// </summary>
    IList<InputModel> ControllerInputs { get; }

    /// <summary>
    ///   The number of input samples from the controllers.
    /// </summary>
    uint InputCount { get; set; }

    /// <summary>
    ///   The Author info of the movie.
    /// </summary>
    string Author { get; set; }
  }
}