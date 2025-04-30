// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Company
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Company
{
  public int? CountryId { get; set; }

  public string CompShortName { get; set; }

  public string CompFullname { get; set; }

  public string Initial { get; set; }

  public int? EANId { get; set; }

  public int Status { get; set; }

  public int Ingredients { get; set; }

  public int? EditUid { get; set; }

  public DateTime? EditDate { get; set; }

  public string RegUid { get; set; }

  public DateTime RegDate { get; set; }

  public string CompanyId { get; set; }
}
