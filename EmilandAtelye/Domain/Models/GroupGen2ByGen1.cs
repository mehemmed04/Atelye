// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.GroupGen2ByGen1
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class GroupGen2ByGen1
{
  public long GroupGen1Id { get; set; }

  public long GroupGen2Id { get; set; }

  public string GroupGen2Name { get; set; }

  public string GroupGen2ShortName { get; set; }

  public int Status { get; set; }

  public byte GroupGen2SampleId { get; set; }

  public string DistribName { get; set; }
}
