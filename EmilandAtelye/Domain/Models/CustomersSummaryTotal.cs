// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.CustomersSummaryTotal
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable disable
namespace EmilandAtelye.Domain.Models;

public class CustomersSummaryTotal
{
  public float SumPayUSD { get; set; }

  public float SumPayAZN { get; set; }

  public float SumPayEUR { get; set; }

  public float SumPayRUB { get; set; }

  public Decimal SumRemainTotalAll { get; set; }
}
