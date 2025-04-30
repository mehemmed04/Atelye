// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.CustomerTotalFinance
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class CustomerTotalFinance
{
  public int CurTypeId { get; set; }

  public string CusFatherName { get; set; }

  public string CusGsm { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public string CusTelNo { get; set; }

  public int CustomerId { get; set; }

  public int DepartId { get; set; }

  public int FinanceId { get; set; }

  public string FinanceNote { get; set; }

  public bool FinDeliverySt { get; set; }

  public DateTime OperDate { get; set; }

  public Decimal PayedTotal { get; set; }

  public Decimal PayedTotalAzn { get; set; }

  public Decimal RemainTotalAll { get; set; }

  public string St { get; set; }

  public string Status { get; set; }
}
