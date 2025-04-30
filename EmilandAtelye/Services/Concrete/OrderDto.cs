// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.OrderDto
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using System;
using System.Collections.Generic;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class OrderDto
{
  public IEnumerable<CustomersSummary> BaseLeftOrders { get; set; }

  public OrderDto()
  {
    this.BaseLeftOrders = (IEnumerable<CustomersSummary>) new List<CustomersSummary>();
  }

  public float LeftUsdAll { get; set; }

  public float LeftAznAll { get; set; }

  public float LeftEuroAll { get; set; }

  public float LeftRubAll { get; set; }

  public Decimal LeftDebtAll { get; set; }
}
