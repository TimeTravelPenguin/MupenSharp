#region Title Header

// Name: Phillip Smith
// 
// Solution: MupenTasStudio
// Project: MupenSharp
// File Name: FactoryBase.cs
// 
// Current Data:
// 2021-07-11 11:21 AM
// 
// Creation Date:
// 2021-07-06 3:25 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using MupenSharp.Resources;

#endregion

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