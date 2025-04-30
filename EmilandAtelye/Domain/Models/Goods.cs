// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Goods
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Goods
{
  public string GoodsId { get; set; }

  public DateTime RegDate { get; set; }

  public string RegUid { get; set; }

  public DateTime? EditDate { get; set; }

  public string? EditUid { get; set; }

  public string? CompanyId { get; set; }

  public string? GoodsShortName { get; set; }

  public long? GroupGen1Id { get; set; }

  public long? GroupGen2Id { get; set; }

  public int? MeasureId { get; set; }

  public string? Barcode { get; set; }

  public Decimal? LimitRed { get; set; }

  public Decimal? LimitBlue { get; set; }

  public Decimal? WhPrice { get; set; }

  public int? CurTypeId { get; set; }

  public Decimal? RestManualCount { get; set; }

  public string? GoodsCode { get; set; }

  public Decimal? RestCount { get; set; }

  public string? RowNo { get; set; }

  public string? ColumnNo { get; set; }

  public string? IntGoodsCode { get; set; }

  public string? Note1 { get; set; }

  public string? GoodsFullName { get; set; }

  public string? InternatName { get; set; }

  public Decimal? RestStockCount { get; set; }

  public bool? PartNumYes { get; set; }

  public Decimal? MinMinSellingPrice { get; set; }

  public int Status { get; set; }

  public float? Store1 { get; set; }

  public float? Store2 { get; set; }

  public float? Store3 { get; set; }

  public float? Store4 { get; set; }

  public float? Store5 { get; set; }

  public float? Store6 { get; set; }

  public float? Store7 { get; set; }

  public string? SpodkN { get; set; }

  public string? SpuquN { get; set; }

  public string? BarcodeTerminal { get; set; }

  public Decimal? SuiteSp { get; set; }

  public Decimal? JacketSp { get; set; }

  public Decimal? PantsSp { get; set; }

  public Decimal? SmokingSp { get; set; }

  public Decimal? WaistcoatSp { get; set; }

  public Decimal? SuiteSmokingSp { get; set; }

  public Decimal? SkirtSp { get; set; }

  public int? ColorId { get; set; }

  public int? SizeId { get; set; }

  public int? CompositionId1 { get; set; }

  public float? CompositionId1P { get; set; }

  public int? CompositionId2 { get; set; }

  public float? CompositionId2P { get; set; }

  public int? CompositionId3 { get; set; }

  public float? CompositionId3P { get; set; }

  public bool? SendArchive { get; set; }

  public bool? Ordered { get; set; }

  public Decimal? SuiteSpRus { get; set; }

  public Decimal? JacketSpRus { get; set; }

  public Decimal? PantsSpRus { get; set; }

  public Decimal? SmokingSpRus { get; set; }

  public Decimal? WaistcoatSpRus { get; set; }

  public Decimal? SuiteSmokingSpRus { get; set; }

  public Decimal? SkirtSpRus { get; set; }
}
