// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.IroningDaily
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Windows.Media;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class IroningDaily
{
  public int Id { get; set; }

  public DateTime? IroningDate { get; set; }

  public byte? Wd { get; set; }

  public byte? WdSt { get; set; }

  public int? KOST_12 { get; set; }

  public int? KOST_13 { get; set; }

  public int? KOST_14 { get; set; }

  public int? KOST_17 { get; set; }

  public int? KOST_16 { get; set; }

  public int? KOST_18 { get; set; }

  public int? KOST_ALL { get; set; }

  public int? SAL_12 { get; set; }

  public int? SAL_13 { get; set; }

  public int? SAL_14 { get; set; }

  public int? SAL_17 { get; set; }

  public int? SAL_16 { get; set; }

  public int? SAL_18 { get; set; }

  public int? SAL_ALL { get; set; }

  public int? JIL_12 { get; set; }

  public int? JIL_13 { get; set; }

  public int? JIL_14 { get; set; }

  public int? JIL_17 { get; set; }

  public int? JIL_16 { get; set; }

  public int? JIL_18 { get; set; }

  public int? JIL_ALL { get; set; }

  public int? KOY_12 { get; set; }

  public int? KOY_13 { get; set; }

  public int? KOY_14 { get; set; }

  public int? KOY_17 { get; set; }

  public int? KOY_16 { get; set; }

  public int? KOY_18 { get; set; }

  public int? KOY_ALL { get; set; }

  public Brush BackgroundColor1
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#f9fbd2") : (Brush) Brushes.Red;
    }
  }

  public Brush BackgroundColor2
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#d5ffd5") : (Brush) Brushes.Red;
    }
  }

  public Brush BackgroundColor3
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#d1d1fc") : (Brush) Brushes.Red;
    }
  }

  public Brush BackgroundColor4
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#ababab") : (Brush) Brushes.Red;
    }
  }

  public Brush BackgroundColor5
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#a694c5") : (Brush) Brushes.Red;
    }
  }

  public Brush BackgroundColor6
  {
    get
    {
      DateTime? ironingDate = this.IroningDate;
      ref DateTime? local = ref ironingDate;
      return (local.HasValue ? (local.GetValueOrDefault().DayOfWeek == DayOfWeek.Sunday ? 1 : 0) : 0) == 0 ? (Brush) new BrushConverter().ConvertFromString("#1d8a8a") : (Brush) Brushes.Red;
    }
  }
}
