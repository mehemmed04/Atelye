// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.MeasureUnit
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class MeasureUnit
{
  public int MeasureId { get; set; }

  public DateTime RegDate { get; set; }

  public string? Reguid { get; set; }

  public DateTime EditDate { get; set; }

  public string? Edituid { get; set; }

  public string? Measure { get; set; }
}
