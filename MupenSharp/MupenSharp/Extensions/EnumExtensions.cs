using System;
using System.Collections.Generic;
using System.Linq;

namespace MupenSharp.Extensions;

internal static class EnumExtensions
{
    public static IEnumerable<T> EnumToArray<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}