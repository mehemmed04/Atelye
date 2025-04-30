// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Finance
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Finance
{
  public int FinanceId { get; set; }

  public int DepartId { get; set; }

  public int CustomerId { get; set; }

  public long GroupGen2Id { get; set; }

  public DateTime OperDate { get; set; }

  public Decimal? Rate_Rub { get; set; }

  public float? PriceTotal { get; set; }

  public float? PriceTotal_Rub { get; set; }

  public float? LastPriceTotal { get; set; }

  public float? PriceTotalAzn { get; set; }

  public float? PayedTotal { get; set; }

  public float? PayedTotalAzn { get; set; }

  public int CurTypeId { get; set; }

  public DateTime RowDate { get; set; }

  public string? Barcode { get; set; }

  public string? CusName { get; set; }

  public string? CusSurname { get; set; }

  public string? CusFatherName { get; set; }

  public string? CusGsm { get; set; }

  public float Fabric_Amount { get; set; }

  public string? RowNo { get; set; }

  public byte St_Order { get; set; }

  public string? CusTelNo { get; set; }

  public Decimal? RemainTotalAll { get; set; }

  public byte Status { get; set; }

  public int St { get; set; }

  public string? OTextileNo { get; set; }

  public string? OButtonNo { get; set; }

  public string? OButton { get; set; }

  public string? OSegment { get; set; }

  public byte Sturgent { get; set; }

  public string? FinanceNote { get; set; }

  public int TailorId { get; set; }

  public string? GG2 { get; set; }
}
