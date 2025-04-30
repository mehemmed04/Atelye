// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.GroupGen1
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class GroupGen1
{
  public long GroupGen1Id { get; set; }

  public DateTime RegDate { get; set; }

  public string Reguid { get; set; }

  public DateTime EditDate { get; set; }

  public string Edituid { get; set; }

  public string GroupGen1Name { get; set; }

  public string GroupGen1ShortName { get; set; }

  public byte NoParts { get; set; }

  public int Status { get; set; }
}
