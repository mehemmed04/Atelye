// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.CustomersSummary
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class CustomersSummary
{
  public int CustomerId { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public string CusFatherName { get; set; }

  public string CusGsm { get; set; }

  public string CusTelNo { get; set; }

  public DateTime OperDate { get; set; }

  public float? PriceTotal { get; set; }

  public float? PriceTotal_Rub { get; set; }

  public float? LastPriceTotal { get; set; }

  public float? PayTotAzn { get; set; }

  public float? PayTotUsd { get; set; }

  public float? PayTotEur { get; set; }

  public float? PayTotRur { get; set; }

  public Decimal? RemainTotalAll { get; set; }

  public int MaxFinId { get; set; }
}
