// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Country
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Country
{
  public int CountryId { get; set; }

  public DateTime RegDate { get; set; }

  public string Reguid { get; set; }

  public DateTime EditDate { get; set; }

  public string Edituid { get; set; }

  public string CountryShortName { get; set; }

  public string CountryName { get; set; }

  public string Initial { get; set; }

  public string EanId { get; set; }

  public int Status { get; set; }
}
