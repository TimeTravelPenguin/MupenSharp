#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: ITas.cs
// 
// Current Data:
// 2021-01-01 10:44 PM
// 
// Creation Date:
// 2021-01-01 8:04 PM

#endregion

namespace MupenSharp.Models
{
  /// <summary>
  /// Tool-Assisted Speedrun Interface
  /// </summary>
  public interface ITas
  {
    string Author { get; set; }
    uint InputFrames { get; set; }
  }
}