# Quick startup

MupenSharp is designed to be intuitive to give you full access and control over your .m64 files. In order to read an .m64 file, you can simply use the following code:

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

