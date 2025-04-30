// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.DailyExpense
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class DailyExpense
{
  public int DailyExpenseId { get; set; }

  public int DepartId { get; set; }

  public string ExpenseId { get; set; }

  public string ExpenseName { get; set; }

  public DateTime OperDate { get; set; }

  public int? OperSumAzn { get; set; }

  public int? OperSumAznBref { get; set; }

  public int? OperSumDollar { get; set; }

  public int? OperSumUsdBref { get; set; }

  public byte StCash { get; set; }

  public byte StoperSum { get; set; }
}
