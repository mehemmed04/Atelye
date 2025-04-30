// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DTOs.Requests.AddUpdateFinanceRequest
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.DTOs.Requests;

public class AddUpdateFinanceRequest
{
  public DateTime? RegDate { get; set; }

  public string? RegUid { get; set; }

  public DateTime? EditDate { get; set; }

  public string? EditUid { get; set; }

  public int? DepartId { get; set; }

  public int? CustomerId { get; set; }

  public string? CusName { get; set; }

  public string? CusSurname { get; set; }

  public string? CusFatherName { get; set; }

  public string? CusTelNo { get; set; }

  public string? CusGsm { get; set; }

  public long? GroupGen2Id { get; set; }

  public DateTime? OperDate { get; set; }

  public string? Barcode { get; set; }

  public Decimal? Rate_Rub { get; set; }

  public Decimal? PriceTotal { get; set; }

  public float? PriceTotal_Rub { get; set; }

  public float? LastPriceTotal { get; set; }

  public float? PayedTotal { get; set; }

  public float? RemainTotal { get; set; }

  public string? FinanceNote { get; set; }

  public int? CurTypeId { get; set; }

  public float? PriceTotalAzn { get; set; }

  public float? PayedTotalAzn { get; set; }

  public float? RemainTotalAll { get; set; }

  public DateTime? RowDate { get; set; }

  public DateTime? RowDateLast { get; set; }

  public byte? Status { get; set; }

  public byte? St { get; set; }

  public string? OType { get; set; }

  public string? OCode { get; set; }

  public string? OTextileNo { get; set; }

  public string? OButtonNo { get; set; }

  public string? OButton { get; set; }

  public string? OSegment { get; set; }

  public byte? FinDeliverySt { get; set; }

  public byte? PrintStatus { get; set; }

  public float? RemainTotalAll_90 { get; set; }

  public float? RemainTotal_90 { get; set; }

  public float? Fabric_Amount { get; set; }

  public byte? Ironing_1 { get; set; }

  public byte? Ironing_2 { get; set; }

  public DateTime? Ironing_1RowDate { get; set; }

  public DateTime? Ironing_2RowDate { get; set; }

  public byte? StUrgent { get; set; }

  public DateTime? PrintDate { get; set; }

  public DateTime? Cutting_RowDate { get; set; }

  public DateTime? Ironing_3RowDate { get; set; }

  public DateTime? OrderDate { get; set; }

  public DateTime? Prepare_RowDate { get; set; }

  public byte? St_Order { get; set; }

  public string? RowNo { get; set; }

  public byte? GivenId { get; set; }

  public DateTime? GivenDate { get; set; }

  public byte? FittingId { get; set; }

  public DateTime? FittingDate { get; set; }

  public DateTime? Ironing_Pres1 { get; set; }

  public DateTime? Ironing_Pres2 { get; set; }

  public float? PayAznAmount { get; set; }

  public int? TailorId { get; set; }

  public string? GivenNote { get; set; }
}
