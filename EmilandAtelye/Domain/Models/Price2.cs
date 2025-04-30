// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Price2
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Price2
{
  public string PrizeId { get; set; }

  public long GroupGen2Id { get; set; }

  public int CurTypeId { get; set; }

  public Decimal Rate { get; set; }

  public long GoodsId { get; set; }

  public Decimal SellingPrice { get; set; }

  public Decimal SellingPrice_Rus { get; set; }

  public DateTime RegDate { get; set; }
}
