#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: M64.cs
// 
// Current Data:
// 2021-07-09 12:57 PM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System.Collections.ObjectModel;
using System.ComponentModel;
using MupenSharp.Attributes;
using MupenSharp.Base;
using MupenSharp.Enums;

#endregion

namespace MupenSharp.Models
{
  /// <summary>
  ///   Stores data of a .m64 file.
  ///   Refer to the <see href="http://tasvideos.org/EmulatorResources/Mupen/M64.html">header documentation</see> for more
  ///   information.
  /// </summary>
  public class M64 : PropertyChangedBase, IM64
  {
    private string _audioPluginName;
    private string _author;
    private uint _controllerCount;
    private uint _controllerFlags;
    private ObservableCollection<InputModel> _controllerInputs = new();
    private uint _crc32;
    private uint _inputCount;
    private string _inputPluginName;
    private string _movieDescription;
    private ushort _movieStartType;
    private int _movieUid;
    private ushort _regionCode;
    private uint _rerecordCount;
    private string _romName;
    private string _rspPluginName;
    private uint _version;
    private uint _vICount;
    private string _videoPluginName;
    private uint _viPerSecond;

    /// <summary>
    ///   The UID of the movie.
    /// </summary>
    public int MovieUid
    {
      get => _movieUid;
      set => SetValue(ref _movieUid, value);
    }

    /// <summary>
    ///   The internal name of ROM used when recording, directly from ROM.
    /// </summary>
    [StringEncoding(Encoding.ASCII, 32)]
    public string RomName
    {
      get => _romName;
      set => SetValue(ref _romName, value);
    }

    /// <summary>
    ///   The name of video plugin used when recording, directly from plugin
    /// </summary>
    [StringEncoding(Encoding.ASCII, 64)]
    public string VideoPluginName
    {
      get => _videoPluginName;
      set => SetValue(ref _videoPluginName, value);
    }

    /// <summary>
    ///   The name of audio plugin used when recording, directly from plugin
    /// </summary>
    [StringEncoding(Encoding.ASCII, 64)]
    public string AudioPluginName
    {
      get => _audioPluginName;
      set => SetValue(ref _audioPluginName, value);
    }

    /// <summary>
    ///   The name of input plugin used when recording, directly from plugin
    /// </summary>
    [StringEncoding(Encoding.ASCII, 64)]
    public string InputPluginName
    {
      get => _inputPluginName;
      set => SetValue(ref _inputPluginName, value);
    }

    /// <summary>
    ///   The name of rsp plugin used when recording, directly from plugin
    /// </summary>
    [StringEncoding(Encoding.ASCII, 64)]
    public string RspPluginName
    {
      get => _rspPluginName;
      set => SetValue(ref _rspPluginName, value);
    }

    /// <summary>
    ///   The collection of controller inputs every input frame and controller,
    ///   containing analogue x, y positions and buttons pressed.
    /// </summary>
    public ObservableCollection<InputModel> ControllerInputs
    {
      // TODO: Implement multiple controller support
      get => _controllerInputs;
      set => SetValue(ref _controllerInputs, value);
    }

    /// <summary>
    ///   Version number. Should be 3.
    /// </summary>
    public uint Version
    {
      get => _version;
      set => SetValue(ref _version, value);
    }

    /// <summary>
    ///   The number of frames (vertical interrupts).
    /// </summary>
    public uint ViCount
    {
      get => _vICount;
      set => SetValue(ref _vICount, value);
    }

    /// <summary>
    ///   The number of file rerecords.
    /// </summary>
    public uint RerecordCount
    {
      get => _rerecordCount;
      set => SetValue(ref _rerecordCount, value);
    }

    /// <summary>
    ///   Frames (vertical interrupts) per second.
    /// </summary>
    public uint ViPerSecond
    {
      get => _viPerSecond;
      set => SetValue(ref _viPerSecond, value);
    }

    /// <summary>
    ///   The number of controllers enabled for the file.
    /// </summary>
    public uint ControllerCount
    {
      get => _controllerCount;
      set => SetValue(ref _controllerCount, value);
    }

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
    public ushort MovieStartType
    {
      get => _movieStartType;
      set => SetValue(ref _movieStartType, value);
    }

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
    public uint ControllerFlags
    {
      get => _controllerFlags;
      set => SetValue(ref _controllerFlags, value);
    }

    /// <summary>
    ///   CRC32 of ROM used when recording, directly from ROM.
    /// </summary>
    public uint Crc32
    {
      get => _crc32;
      set => SetValue(ref _crc32, value);
    }

    /// <summary>
    ///   The country code of ROM used when recording, directly from ROM.
    /// </summary>
    public ushort RegionCode
    {
      get => _regionCode;
      set => SetValue(ref _regionCode, value);
    }

    /// <summary>
    ///   The movie description info.
    /// </summary>
    [StringEncoding(Encoding.UTF8, 256)]
    public string MovieDescription
    {
      get => _movieDescription;
      set => SetValue(ref _movieDescription, value);
    }

    /// <summary>
    ///   The number of input samples from the controllers (for one controller).
    /// </summary>
    public uint InputCount
    {
      get => _inputCount;
      set => SetValue(ref _inputCount, value);
    }

    /// <summary>
    ///   The Author info of the movie.
    /// </summary>
    [StringEncoding(Encoding.UTF8, 222)]
    public string Author
    {
      get => _author;
      set => SetValue(ref _author, value);
    }

    /// <summary>
    ///   Object wrapper to encapsulate the data of a .m64 file
    /// </summary>
    public M64()
    {
      // Notify change when ControllerInputs notifies change
      ((INotifyPropertyChanged) ControllerInputs).PropertyChanged +=
        delegate { OnPropertyChanged(GetType().FullName); };
    }
  }
}