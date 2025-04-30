// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.LproExpense
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class LproExpense
{
  public string EXPENSEID { get; set; }

  public int DEPARTID { get; set; }

  public DateTime? REGDATE { get; set; } = new DateTime?(DateTime.Now);

  public string REGUID { get; set; }

  public DateTime? EDITDATE { get; set; }

  public string EDITUID { get; set; }

  public string EXPENSENAME { get; set; }

  public int STATUS { get; set; }

  public string aa { get; set; }

  public string BEX { get; set; }
}
