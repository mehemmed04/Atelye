// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.EmployeeGroup
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class EmployeeGroup
{
  public int EmployeeGroupId { get; set; }

  public string Eg { get; set; }

  public string? EgNote { get; set; }

  public int St { get; set; }
}
