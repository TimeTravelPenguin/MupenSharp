#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenSharp
// Project: MupenSharp
// File Name: FactoryBase.cs
// 
// Current Data:
// 2021-01-03 7:59 PM
// 
// Creation Date:
// 2021-01-03 7:34 PM

#endregion

using System;
using System.Collections.Generic;
using MupenSharp.Resources;

namespace MupenSharp.Base
{
  internal abstract class FactoryBase<TKey, TValue>
  {
    protected readonly IDictionary<TKey, Func<TValue>> Registry = new Dictionary<TKey, Func<TValue>>();

    public void Register(TKey key, Func<TValue> value)
    {
      if (Registry.ContainsKey(key))
      {
        throw new InvalidOperationException(ExceptionsResource.RegistryKeyAlreadyExist);
      }

      Registry.Add(key, value);
    }

    public TValue Create(TKey key)
    {
      if (!Registry.ContainsKey(key))
      {
        throw new InvalidOperationException(ExceptionsResource.RegistryDoenNotContainKey);
      }

      return Registry[key].Invoke();
    }
  }
}