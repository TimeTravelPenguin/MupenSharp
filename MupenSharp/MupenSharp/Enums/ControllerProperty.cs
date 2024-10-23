using System;

namespace MupenSharp.Enums;

/// <summary>
///     Properties to determine controller, controller memory pack, and controller rumble pack presence.
/// </summary>
[Flags]
public enum ControllerProperty
{
    /// <summary>
    ///     Presence flag for controller 1
    /// </summary>
    ControllerOnePresent = 0x0001,

    /// <summary>
    ///     Presence flag for controller 2
    /// </summary>
    ControllerTwoPresent = 0x0002,

    /// <summary>
    ///     Presence flag for controller 3
    /// </summary>
    ControllerThreePresent = 0x0004,

    /// <summary>
    ///     Presence flag for controller 4
    /// </summary>
    ControllerFourPresent = 0x0008,

    /// <summary>
    ///     Presence flag for controller 1 memory pack
    /// </summary>
    ControllerOneMemoryPackPresent = 0x0010,

    /// <summary>
    ///     Presence flag for controller 2 memory pack
    /// </summary>
    ControllerTwoMemoryPackPresent = 0x0020,

    /// <summary>
    ///     Presence flag for controller 3 memory pack
    /// </summary>
    ControllerThreeMemoryPackPresent = 0x0040,

    /// <summary>
    ///     Presence flag for controller 4 memory pack
    /// </summary>
    ControllerFourMemoryPackPresent = 0x0080,

    /// <summary>
    ///     Presence flag for controller 1 rumble pack
    /// </summary>
    ControllerOneRumblePackPresent = 0x0100,

    /// <summary>
    ///     Presence flag for controller 2 rumble pack
    /// </summary>
    ControllerTwoRumblePackPresent = 0x0200,

    /// <summary>
    ///     Presence flag for controller 3 rumble pack
    /// </summary>
    ControllerThreeRumblePackPresent = 0x0400,

    /// <summary>
    ///     Presence flag for controller 4 rumble pack
    /// </summary>
    ControllerFourRumblePackPresent = 0x0800
}