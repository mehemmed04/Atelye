// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.CacheService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Runtime.Caching;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class CacheService
{
  private static readonly MemoryCache Cache = MemoryCache.Default;

  public static void AddToCache(string key, object? data, TimeSpan duration)
  {
    if (data == null)
      return;
    CacheItemPolicy policy = new CacheItemPolicy()
    {
      AbsoluteExpiration = DateTimeOffset.Now.Add(duration)
    };
    CacheService.Cache.Set(key, data, policy, (string) null);
  }

  public static T? GetFromCache<T>(string key)
  {
    return CacheService.Cache.Contains(key, (string) null) ? (T) CacheService.Cache.Get(key, (string) null) : default (T);
  }

  public static void RemoveFromCache(string key)
  {
    if (!CacheService.Cache.Contains(key, (string) null))
      return;
    CacheService.Cache.Remove(key, (string) null);
  }
}
