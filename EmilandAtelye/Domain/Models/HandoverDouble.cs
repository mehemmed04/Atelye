// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.HandoverDouble
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class HandoverDouble
{
  public int FinanceId { get; set; }

  public DateTime RegDate { get; set; }

  public long GroupGen2Id { get; set; }

  public string? BarCode { get; set; }

  public float? PriceTotal { get; set; }

  public float? LastPriceTotal { get; set; }

  public float? RemainTotal { get; set; }

  public byte? STUrgent { get; set; }

  public string? GivenNote { get; set; }

  public byte? GivenId { get; set; }

  public DateTime? GivenDate { get; set; }

  public byte? FittingId { get; set; }

  public DateTime? FittingDate { get; set; }
}
