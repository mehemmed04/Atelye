// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.GoodsStore
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class GoodsStore
{
  public int Ordered { get; set; }

  public string GoodsId { get; set; }

  public string Initial { get; set; }

  public string GroupGen1Name { get; set; }

  public string GroupGen2Name { get; set; }

  public double? WHPrice { get; set; }

  public double? RestManualCount { get; set; }

  public double? Store1 { get; set; }

  public double? Store2 { get; set; }

  public double? Store3 { get; set; }

  public double? Store4 { get; set; }

  public double? Store5 { get; set; }

  public double? LimitBlue { get; set; }

  public double? LimitRed { get; set; }

  public string GoodsCode { get; set; }

  public string RowNo { get; set; }

  public string BarCode { get; set; }

  public string? IntGoodsCode { get; set; }

  public string? Note1 { get; set; }

  public int SendArchive { get; set; }

  public double? Kostyum { get; set; }

  public double? Pencek { get; set; }

  public double? Shalvar { get; set; }

  public double? Kostyum_Smoking { get; set; }

  public double? Palto { get; set; }

  public double? Jilet { get; set; }

  public double? Skirt { get; set; }

  public double? Koynek { get; set; }

  public double? Koynek_Smoking { get; set; }

  public string Color { get; set; } = "Green";
}
