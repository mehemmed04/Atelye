// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Expense
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Expense
{
  public string DepartShortName { get; set; }

  public string ExpenseName { get; set; }

  public double OperSumDollar { get; set; }

  public double OperSumAzn { get; set; }

  public double OperSumAznBref { get; set; }

  public double OperSumUsdBref { get; set; }

  public DateTime? OperDate { get; set; }
}
