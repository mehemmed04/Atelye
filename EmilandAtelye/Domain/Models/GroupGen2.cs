// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.GroupGen2
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class GroupGen2
{
  public int GroupGen2Id { get; set; }

  public DateTime RegDate { get; set; }

  public string RegUid { get; set; }

  public DateTime EditDate { get; set; }

  public string EditUid { get; set; }

  public int GroupGen1Id { get; set; }

  public string GroupGen2Name { get; set; }

  public string GroupGen2ShortName { get; set; }

  public byte GroupGen2SampleId { get; set; }

  public int Status { get; set; }

  public string DistribName { get; set; }

  public byte? St { get; set; } = new byte?((byte) 45);

  public byte St_Ironing { get; set; }

  public byte Ironing_12 { get; set; }

  public byte ForSearch { get; set; }

  public byte CustTable { get; set; }

  public byte ForShirt { get; set; }

  public byte ForPriceSeperate { get; set; }

  public byte BarcodeYes1No0 { get; set; }

  public float ExtraPayment { get; set; }

  public float ExtraPercent { get; set; }

  public float CuttingAmount { get; set; }
}
