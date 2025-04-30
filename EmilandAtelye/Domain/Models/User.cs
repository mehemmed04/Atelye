// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.User
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class User
{
  public string? UserCode { get; set; }

  public string? UserName { get; set; }

  public int IdleTime { get; set; }

  public int PassNeed { get; set; }
}
