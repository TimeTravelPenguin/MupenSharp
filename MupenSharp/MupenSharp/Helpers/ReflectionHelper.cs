#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: ReflectionHelper.cs
// 
// Current Data:
// 2021-07-09 12:45 PM
// 
// Creation Date:
// 2021-07-09 12:22 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace MupenSharp.Helpers
{
  internal static class ReflectionHelper
  {
    public static Dictionary<string, TAttribute> GetPropertyAttributeDictionaryOfType<TAttribute>(this Type type)
      where TAttribute : Attribute
    {
      var attr = (from prop in type.GetProperties()
          from attribs in prop.GetCustomAttributes(typeof(TAttribute)).Cast<TAttribute>()
          select new KeyValuePair<string, TAttribute>(prop.Name, attribs))
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

      return attr;
    }
  }
}