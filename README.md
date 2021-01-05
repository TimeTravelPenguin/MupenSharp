# MupenSharp
![Nuget](https://img.shields.io/nuget/v/MupenSharp) ![publish](https://github.com/TimeTravelPenguin/MupenSharp/workflows/publish/badge.svg)

MupenSharp is a .Net Standard library to interface with .m64 files for reading and writing.

This library is designed to assist in reading and writing .m64 files for the Mupen64 application. By using MupenSharp, you do not need to manually process the file's header or encoding types, as it is all maintained within this library.

For more specific information on the filetype's header layout, please refer to the [TASVideos page](http://tasvideos.org/EmulatorResources/Mupen/M64.html) which documents the format.

## Documentation coming soon

## Overview

- ### What is Mupen64?

  Mupen64 is an emulation tool designed and used for [Tool-Assisted Speedrunning](https://en.wikipedia.org/wiki/Tool-assisted_speedrun) Nintendo 64 titles. It is largely used by the Super Mario 64 TASing community, with various application version for video playback recording and LUA plugin support.


- ### What is a .m64 file?

  The [.m64 file](http://tasvideos.org/EmulatorResources/Mupen/M64.html) is the movie playback file which holds the inputs of a TAS. This file is made and read by Mupen64 and holds information for the game title, ROM CRC, region code, and other information to ensure a valid emulation can be played back.


- ### Why make MupenSharp?

  There are several applications that exist that allow a user to edit or combine files, such as the .m64 editor built into the TAS tool [STROOP](https://github.com/SM64-TAS-ABC/STROOP), which is used by the SM64 TASing community. The goal of this library is to provide a simple interface for all future applications to manage these files.

## How to use?

In order to read a .m64 file, you can do the following:

```cs
const string file = "C://path/to/file.m64";
M64 m64 = M64Parser.Parse(file);

Console.WriteLine($"Author(s): {m64.Author}");
Console.WriteLine($"ROM name: {m64.NameOfRom}");

var frameCount = 1;
foreach (var inputFrame in m64.Inputs)
{
    Console.WriteLine($"Frame {frameCount++}:\t{inputFrame}");
}
```

An example console output would be:

```console
Author(s): Phillip Smith
ROM name: SUPER MARIO 64

Frame 1:        (0, 0)
Frame 2:        (0, 0)
Frame 3:        (0, 0) Start
Frame 4:        (0, 0) Start
Frame 5:        (0, 0) Start
...
Frame 259:      (-10, 127)
Frame 260:      (-10, 127) B
Frame 261:      (-21, 127) R
Frame 262:      (-30, 127) R
Frame 263:      (-35, 127) R
Frame 264:      (13, 127) R, B
Frame 265:      (13, 127) R, B
Frame 266:      (13, 127) R, B
```

