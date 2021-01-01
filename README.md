# MupenSharp
![Nuget](https://img.shields.io/nuget/v/MupenSharp) ![nuget build](https://github.com/TimeTravelPenguin/MupenSharp/workflows/publish%20to%20nuget/badge.svg)

MupenSharp is a .Net Standard library to interface with .m64 files for reading and writing.

This library is designed to assist in reading and writing .m64 files for the Mupen64 application. By using MupenSharp, you do not need to manually process the file's header or encoding types, as it is all maintained within this library.

For more specific information on the filetype's header layout, please refer to the [TASVideos page](http://tasvideos.org/EmulatorResources/Mupen/M64.html) which documents the format.

## Overview

- ### What is Mupen64?

  Mupen64 is an emulation tool designed and used for [Tool-Assisted Speedrunning](https://en.wikipedia.org/wiki/Tool-assisted_speedrun) Nintendo 64 titles. It is largely used by the Super Mario 64 TASing community, with various application version for video playback recording and LUA plugin support.


- ### What is a .m64 file?

  The [.m64 file](http://tasvideos.org/EmulatorResources/Mupen/M64.html) is the movie playback file which holds the inputs of a TAS. This file is made and read by Mupen64 and holds information for the game title, ROM CRC, region code, and other information to ensure a valid emulation can be played back.


- ### Why make MupenSharp?

  There are several applications that exist that allow a user to edit or combine files, such as the .m64 editor built into the TAS tool [STROOP](https://github.com/SM64-TAS-ABC/STROOP), which is used by the SM64 TASing community. The goal of this library is to provide a simple interface for all future applications to manage these files.
