// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Ironing1
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Windows.Media;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Ironing1
{
  public int Number { get; set; }

  public string? RowNo { get; set; }

  public int DepartId { get; set; }

  public int CustomerId { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public long GroupGen2Id { get; set; }

  public byte CustTable { get; set; }

  public byte St_Order { get; set; }

  public string GroupGen2ShortName { get; set; }

  public byte Ironing_12 { get; set; }

  public byte St_Ironing { get; set; }

  public byte? Ironing_1 { get; set; }

  public byte? Ironing_2 { get; set; }

  public int FinanceId { get; set; }

  public int St { get; set; }

  public int Pr { get; set; }

  public byte Ironing1AndIroning2Sum { get; set; }

  public DateTime? RowDate { get; set; }

  public DateTime? RowDateLast { get; set; }

  public DateTime? RDate1 { get; set; }

  public DateTime? RDate2 { get; set; }

  public DateTime? RDate3 { get; set; }

  public DateTime? Ironing_3RowDate { get; set; }

  public DateTime? Ironing_1RowDate { get; set; }

  public DateTime? Ironing_2RowDate { get; set; }

  public DateTime? FittingDate { get; set; }

  public DateTime? Cutting_RowDate { get; set; }

  public DateTime? Prepare_RowDate { get; set; }

  public DateTime? OperDate { get; set; }

  public Brush RowBackgroundColor { get; set; }

  public Brush BackgroundColor1
  {
    get => !this.Prepare_RowDate.HasValue ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;
  }

  public Brush BackgroundColor2
  {
    get => !this.Cutting_RowDate.HasValue ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;
  }

  public Brush BackgroundColor3
  {
    get => !this.Ironing_1.HasValue ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;
  }

  public Brush BackgroundColor5
  {
    get => !this.Ironing_3RowDate.HasValue ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;
  }

  public Brush BackgroundColor4
  {
    get => !this.Ironing_2.HasValue ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;
  }
}
