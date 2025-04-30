// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.CurrencyType
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class CurrencyType(
  int curTypeId,
  DateTime regDate,
  string reguid,
  DateTime? editDate,
  string edituid,
  string curType,
  byte defaultCur,
  byte curStatus)
{
  public CurrencyType()
    : this(-1, DateTime.MinValue, string.Empty, new DateTime?(), string.Empty, string.Empty, (byte) 0, (byte) 0)
  {
  }

  public int CurTypeId { get; set; } = curTypeId;

  public DateTime RegDate { get; set; } = regDate;

  public string Reguid { get; set; } = reguid;

  public DateTime? EditDate { get; set; } = editDate;

  public string Edituid { get; set; } = edituid;

  public string CurType { get; set; } = curType;

  public byte DefaultCur { get; set; } = defaultCur;

  public byte CurStatus { get; set; } = curStatus;
}
