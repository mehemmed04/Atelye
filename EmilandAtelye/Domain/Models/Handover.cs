// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Handover
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Windows.Media;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Handover
{
  public int CustomerId { get; set; }

  public int DepartId { get; set; }

  public string CusName { get; set; }

  public string CusSurname { get; set; }

  public string CusFatherName { get; set; }

  public string CustelNo { get; set; }

  public string CusGsm { get; set; }

  public string CusRelation { get; set; }

  public Decimal RemainTotalAll { get; set; }

  public byte CallId { get; set; }

  public DateTime? CallIdTime { get; set; }

  public byte CallId2 { get; set; }

  public DateTime? CallIdTime2 { get; set; }

  public byte CallId3 { get; set; }

  public DateTime? CallIdTime3 { get; set; }

  public byte SmsId { get; set; }

  public DateTime? SmsIdTime { get; set; }

  public byte SmsId2 { get; set; }

  public DateTime? SmsIdTime2 { get; set; }

  public byte SmsId3 { get; set; }

  public DateTime? SmsIdTime3 { get; set; }

  public byte GCallId { get; set; }

  public DateTime? GCallIdTime { get; set; }

  public byte GCallId2 { get; set; }

  public DateTime? GCallIdTime2 { get; set; }

  public byte GCallId3 { get; set; }

  public DateTime? GCallIdTime3 { get; set; }

  public byte GSmsId { get; set; }

  public DateTime? GSmsIdTime { get; set; }

  public byte GSmsId2 { get; set; }

  public DateTime? GSmsIdTime2 { get; set; }

  public byte GSmsId3 { get; set; }

  public DateTime? GSmsIdTime3 { get; set; }

  public string GCallNote { get; set; }

  public string Given_Note { get; set; }

  public DateTime GLastTime { get; set; }

  public byte FittingId { get; set; }

  public int St_Old { get; set; }

  public int T { get; set; }

  public int ST { get; set; }

  public byte GivenId { get; set; }

  public DateTime? MaxGivenDate { get; set; }

  public int GSay { get; set; }

  public DateTime IronDate { get; set; }

  public Brush RowBackground
  {
    get
    {
      SolidColorBrush rowBackground;
      switch (this.ST)
      {
        case 1:
          rowBackground = Brushes.LightYellow;
          break;
        case 2:
          rowBackground = Brushes.Red;
          break;
        case 3:
          rowBackground = Brushes.White;
          break;
        case 4:
          rowBackground = Brushes.LightGray;
          break;
        default:
          rowBackground = Brushes.LightPink;
          break;
      }
      return (Brush) rowBackground;
    }
  }

  public Brush TBackground => this.T != 1 ? (Brush) Brushes.Transparent : (Brush) Brushes.Green;

  public Brush PBackground
  {
    get => this.FittingId != (byte) 1 ? (Brush) Brushes.Transparent : (Brush) Brushes.Red;
  }
}
