// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.CustomerInsert
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class CustomerInsert
{
  public int CustomerId { get; set; }

  public DateTime? RegDate { get; set; }

  public string? RegGuid { get; set; }

  public DateTime? EditDate { get; set; }

  public string? EditUid { get; set; }

  public int? DepartId { get; set; }

  public string? CusName { get; set; }

  public string? CusSurname { get; set; }

  public string? CusFatherName { get; set; }

  public string? CusTelNo { get; set; }

  public string? CusGsm { get; set; }

  public string? CusRelation { get; set; }

  public Decimal? RemainTotalAll { get; set; }

  public byte? CallId { get; set; }

  public DateTime? CallIdTime { get; set; }

  public byte? CallId2 { get; set; }

  public DateTime? CallIdTime2 { get; set; }

  public byte? CallId3 { get; set; }

  public DateTime? CallIdTime3 { get; set; }

  public byte? SmsId { get; set; }

  public DateTime? SmsIdTime { get; set; }

  public byte? SmsId2 { get; set; }

  public DateTime? SmsIdTime2 { get; set; }

  public byte? SmsId3 { get; set; }

  public DateTime? SmsIdTime3 { get; set; }

  public string? CallNote { get; set; }

  public DateTime? LastTime { get; set; }

  public byte? GCallId { get; set; }

  public DateTime? GCallIdTime { get; set; }

  public byte? GCallId2 { get; set; }

  public DateTime? GCallIdTime2 { get; set; }

  public byte? GCallId3 { get; set; }

  public DateTime? GCallIdTime3 { get; set; }

  public byte? GSmsId { get; set; }

  public DateTime? GSmsIdTime { get; set; }

  public byte? GSmsId2 { get; set; }

  public DateTime? GSmsIdTime2 { get; set; }

  public byte? GSmsId3 { get; set; }

  public DateTime? GSmsIdTime3 { get; set; }

  public string? GCallNote { get; set; }

  public DateTime? GLastTime { get; set; }

  public byte? FittingId { get; set; }

  public string? Given_Note { get; set; }
}
