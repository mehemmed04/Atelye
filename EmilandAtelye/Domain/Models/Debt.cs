// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Debt
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Debt
{
  public int CustomerId { get; set; }

  public int DepartId { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public string CusFatherName { get; set; }

  public string CusTelNo { get; set; }

  public string CusGSM { get; set; }

  public float RemainTotalAll { get; set; }

  public byte CallId { get; set; }

  public DateTime? CallIdTime { get; set; }

  public byte CallId2 { get; set; }

  public DateTime? CallIdTime2 { get; set; }

  public byte CallId3 { get; set; }

  public DateTime? CallIdTime3 { get; set; }

  public byte SmsId { get; set; }

  public DateTime? SmsIdTime { get; set; }

  public byte SmsId2 { get; set; }

  public DateTime? SmsIdTime2 { get; set; }

  public byte SmsId3 { get; set; }

  public DateTime? SmsIdTime3 { get; set; }

  public string CallNote { get; set; }

  public DateTime? LastTime { get; set; }
}
