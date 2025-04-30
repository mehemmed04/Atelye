// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Delivery
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Delivery
{
  public int CustomerId { get; set; }

  public int DepartmentId { get; set; }

  public string CustomerName { get; set; }

  public string CustomerSurname { get; set; }

  public string CustomerFatherName { get; set; }

  public string CustomerTelNumber { get; set; }

  public string CustomerGsm { get; set; }

  public string CustomerRelation { get; set; }

  public float RemainTotalAll { get; set; }

  public byte GCallId { get; set; }

  public DateTime GCallIdTime { get; set; }

  public byte GCallId2 { get; set; }

  public DateTime GCallIdTime2 { get; set; }

  public byte GCallId3 { get; set; }

  public DateTime GCallIdTime3 { get; set; }

  public byte GSmsId { get; set; }

  public DateTime GSmsIdTime { get; set; }

  public byte GSmsId2 { get; set; }

  public DateTime GSmsIdTime2 { get; set; }

  public byte GSmsId3 { get; set; }

  public DateTime GSmsIdTime3 { get; set; }

  public string GCallNote { get; set; }

  public string GivenNote { get; set; }

  public DateTime GLastTime { get; set; }

  public byte FittingId { get; set; }

  public int St_Old { get; set; }

  public int T { get; set; }

  public int St { get; set; }

  public DateTime MaxGivenDate { get; set; }

  public int GSay { get; set; }

  public DateTime IronDate { get; set; }
}
