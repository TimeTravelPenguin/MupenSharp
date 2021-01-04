#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: M64.cs
// 
// Current Data:
// 2021-01-02 11:13 PM
// 
// Creation Date:
// 2021-01-02 8:56 PM

#endregion

using System.Collections.ObjectModel;
using System.ComponentModel;
using MupenSharp.Attributes;
using MupenSharp.Base;
using MupenSharp.Enums;

namespace MupenSharp.Models
{
  /// <summary>
  ///   Stores data of a .m64 file.
  ///   Refer to the <see href="http://tasvideos.org/EmulatorResources/Mupen/M64.html">header documentation</see> for more
  ///   information.
  /// </summary>
  public class M64 : PropertyChangedBase, ITas, IM64
  {
    private string _author;
    private uint _controllerFlags;
    private ushort _countryCode;
    private uint _crc32;
    private uint _inputFrames;
    private string _movieDescription;
    private ushort _movieStartType;
    private string _nameOfRom;
    private byte _numberOfControllers;
    private uint _rerecordCount;
    private uint _version;
    private uint _verticalInterrupts;
    private byte _viPerSecond;

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
    public uint VerticalInterrupts
    {
      get => _verticalInterrupts;
      set => SetValue(ref _verticalInterrupts, value);
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
    public byte ViPerSecond
    {
      get => _viPerSecond;
      set => SetValue(ref _viPerSecond, value);
    }

    /// <summary>
    ///   The number of controllers enabled for the file.
    /// </summary>
    public byte NumberOfControllers
    {
      get => _numberOfControllers;
      set => SetValue(ref _numberOfControllers, value);
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
    ///   The internal name of ROM used when recording, directly from ROM.
    /// </summary>
    [StringEncoding(Encoding.ASCII, 32)]
    public string NameOfRom
    {
      get => _nameOfRom;
      set => SetValue(ref _nameOfRom, value);
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
    public ushort CountryCode
    {
      get => _countryCode;
      set => SetValue(ref _countryCode, value);
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
    ///   The input for every input frame, containing analogue x, y positions and buttons pressed.
    /// </summary>
    public ObservableCollection<InputModel> ControllerInputs { get; } = new ObservableCollection<InputModel>();

    /// <summary>
    ///   The number of input samples from the controllers.
    /// </summary>
    public uint InputFrames
    {
      get => _inputFrames;
      set => SetValue(ref _inputFrames, value);
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
      ((INotifyPropertyChanged) ControllerInputs).PropertyChanged += delegate { OnPropertyChanged(GetType().FullName); };
    }
  }
}