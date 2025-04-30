// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.DailyTransactionsSummary
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable disable
namespace EmilandAtelye.Domain.Models;

public class DailyTransactionsSummary
{
  public int DepartId { get; set; }

  public DateTime OperDate { get; set; }

  public float? PriceTotal { get; set; }

  public float? LastPriceTotal { get; set; }

  public float? PayTotAzn { get; set; }

  public float? PayTotUsd { get; set; }

  public float? PayTotEur { get; set; }

  public float? PayTotRur { get; set; }

  public int? Kostyum { get; set; }

  public int? Kostyum_Smoking { get; set; }

  public int? Pencek { get; set; }

  public int? Shalvar { get; set; }

  public int? Koynek { get; set; }

  public int? Koynek_Smoking { get; set; }

  public int? Frak { get; set; }

  public int? Plash { get; set; }

  public int? Palto { get; set; }

  public int? Jilet { get; set; }

  public int? Hazir_Jilet { get; set; }

  public int? Qurshaq { get; set; }

  public int? Bab { get; set; }

  public int? Ayaqqabi { get; set; }

  public int? Qalstuk { get; set; }

  public int? Zapinka { get; set; }

  public int? Skirt { get; set; }

  public int? Lady_Dress { get; set; }

  public int? Lady_Kostyum { get; set; }

  public int? Lady_Pencek { get; set; }

  public int? Lady_Shalvar { get; set; }
}
