// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.GoodsRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class GoodsRepository(string connectionString) : BaseSqlRepository(connectionString), IGoodsRepository
{
  public async Task<IEnumerable<Goods>> GetAllGoods()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Goods> goods = await conn.QueryAsync<Goods>("SELECT * FROM LPROGOODS");
    await conn.CloseAsync();
    IEnumerable<Goods> allGoods = goods;
    conn = (SqlConnection) null;
    goods = (IEnumerable<Goods>) null;
    return allGoods;
  }

  public async Task<IEnumerable<Goods>> GetGoodsByGroupGen2(int groupGen2İd)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Goods> goods = await conn.QueryAsync<Goods>("SELECT * FROM LPROGOODS WHERE GROUPGEN2ID = @id", (object) new
    {
      id = groupGen2İd
    });
    await conn.CloseAsync();
    IEnumerable<Goods> goodsByGroupGen2 = goods;
    conn = (SqlConnection) null;
    goods = (IEnumerable<Goods>) null;
    return goodsByGroupGen2;
  }

  public async Task<Goods> GetGoodsByBarCode(string barCode)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    Goods getGood = await conn.QueryFirstOrDefaultAsync<Goods>("SELECT * FROM LPROGOODS WHERE BARCODE = @barCode", (object) new
    {
      barCode = barCode
    });
    await conn.CloseAsync();
    Goods goodsByBarCode = getGood != null ? getGood : new Goods();
    conn = (SqlConnection) null;
    getGood = (Goods) null;
    return goodsByBarCode;
  }

  public async Task<int> AddGoodsAsync(Goods goods)
  {
    GoodsRepository goodsRepository = this;
    int num;
    try
    {
      SqlConnection conn = await goodsRepository.OpenSqlConnectionAsync();
      int Result = await conn.ExecuteAsync("\r\n            INSERT INTO LPROGOODS (\r\n                GOODSID, REGDATE, REGUID, EDITDATE, EDITUID, COMPANYID, GOODSSHORTNAME, \r\n                GROUPGEN1ID, GROUPGEN2ID, MEASUREID, BARCODE, LIMITRED, LIMITBLUE, \r\n                WHPRICE, CURTYPEID, RESTMANUALCOUNT, GOODSCODE, RESTCOUNT, ROWNO, \r\n                COLUMNNO, INTGOODSCODE, NOTE1, GOODSFULLNAME, INTERNATNAME, \r\n                RESTSTOCKCOUNT, PARTNUMYES, MINMINSELLINGPRICE, STATUS, STORE1, \r\n                STORE2, STORE3, STORE4, STORE5, STORE6, STORE7, SPODK_N, SPUQU_N, \r\n                BARCODETERMINAL, SUITESP, JACKETSP, PANTSSP, SMOKINGSP, WAISTCOATSP, \r\n                SUITESMOKINGSP, SKIRTSP, COLORID, SIZEID, COMPOSITIONID1, COMPOSITIONID1P, \r\n                COMPOSITIONID2, COMPOSITIONID2P, COMPOSITIONID3, COMPOSITIONID3P, \r\n                SENDARCHIVE, ORDERED, SUITESP_RUS, JACKETSP_RUS, PANTSSP_RUS, SMOKINGSP_RUS)\r\n            VALUES (\r\n                @GoodsId, @RegDate, @RegUid, @EditDate, @EditUid, @CompanyId, @GoodsShortName, \r\n                @GroupGen1Id, @GroupGen2Id, @MeasureId, @Barcode, @LimitRed, @LimitBlue, \r\n                @WhPrice, @CurTypeId, @RestManualCount, @GoodsCode, @RestCount, @RowNo, \r\n                @ColumnNo, @IntGoodsCode, @Note1, @GoodsFullName, @InternatName, \r\n                @RestStockCount, @PartNumYes, @MinMinSellingPrice, @Status, @Store1, \r\n                @Store2, @Store3, @Store4, @Store5, @Store6, @Store7, @SpodkN, @SpuquN, \r\n                @BarcodeTerminal, @SuiteSp, @JacketSp, @PantsSp, @SmokingSp, @WaistcoatSp, \r\n                @SuiteSmokingSp, @SkirtSp, @ColorId, @SizeId, @CompositionId1, @CompositionId1P, \r\n                @CompositionId2, @CompositionId2P, @CompositionId3, @CompositionId3P, \r\n                @SendArchive, @Ordered, @SuiteSpRus, @JacketSpRus, @PantsSpRus, @SmokingSpRus)", (object) new
      {
        GoodsId = goods.GoodsId,
        RegDate = goods.RegDate,
        RegUid = goods.RegUid,
        EditDate = goods.EditDate,
        EditUid = goods.EditUid,
        CompanyId = goods.CompanyId,
        GoodsShortName = goods.GoodsShortName,
        GroupGen1Id = goods.GroupGen1Id,
        GroupGen2Id = goods.GroupGen2Id,
        MeasureId = goods.MeasureId,
        Barcode = goods.Barcode,
        LimitRed = goods.LimitRed,
        LimitBlue = goods.LimitBlue,
        WhPrice = goods.WhPrice,
        CurTypeId = goods.CurTypeId,
        RestManualCount = goods.RestManualCount,
        GoodsCode = goods.GoodsCode,
        RestCount = goods.RestCount,
        RowNo = goods.RowNo,
        ColumnNo = goods.ColumnNo,
        IntGoodsCode = goods.IntGoodsCode,
        Note1 = goods.Note1,
        GoodsFullName = goods.GoodsFullName,
        InternatName = goods.InternatName,
        RestStockCount = goods.RestStockCount,
        PartNumYes = goods.PartNumYes,
        MinMinSellingPrice = goods.MinMinSellingPrice,
        Status = goods.Status,
        Store1 = goods.Store1,
        Store2 = goods.Store2,
        Store3 = goods.Store3,
        Store4 = goods.Store4,
        Store5 = goods.Store5,
        Store6 = goods.Store6,
        Store7 = goods.Store7,
        SpodkN = goods.SpodkN,
        SpuquN = goods.SpuquN,
        BarcodeTerminal = goods.BarcodeTerminal,
        SuiteSp = goods.SuiteSp,
        JacketSp = goods.JacketSp,
        PantsSp = goods.PantsSp,
        SmokingSp = goods.SmokingSp,
        WaistcoatSp = goods.WaistcoatSp,
        SuiteSmokingSp = goods.SuiteSmokingSp,
        SkirtSp = goods.SkirtSp,
        ColorId = goods.ColorId,
        SizeId = goods.SizeId,
        CompositionId1 = goods.CompositionId1,
        CompositionId1P = goods.CompositionId1P,
        CompositionId2 = goods.CompositionId2,
        CompositionId2P = goods.CompositionId2P,
        CompositionId3 = goods.CompositionId3,
        CompositionId3P = goods.CompositionId3P,
        SendArchive = goods.SendArchive,
        Ordered = goods.Ordered,
        SuiteSpRus = goods.SuiteSpRus,
        JacketSpRus = goods.JacketSpRus,
        PantsSpRus = goods.PantsSpRus,
        SmokingSpRus = goods.SmokingSpRus
      });
      await conn.CloseAsync();
      num = Result;
    }
    catch (Exception ex)
    {
      throw;
    }
    return num;
  }

  public async Task<string> GetMaxGoodId()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string maxGoodId = await conn.QueryFirstOrDefaultAsync<string>("SELECT MAX(GOODSID) FROM LPROGOODS");
    await conn.CloseAsync();
    string maxGoodId1 = maxGoodId;
    conn = (SqlConnection) null;
    maxGoodId = (string) null;
    return maxGoodId1;
  }
}
