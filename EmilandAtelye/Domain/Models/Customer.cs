// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Customer
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Customer
{
  public int DepartId { get; set; }

  public int CustomerId { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public string CusFatherName { get; set; }

  public string CusTelNo { get; set; }

  public string CusGsm { get; set; }
}
