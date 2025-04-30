// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.FinanceRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.DTOs.Requests;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class FinanceRepository(string connectionString) : BaseSqlRepository(connectionString), IFinanceRepository
{
  public async Task<IEnumerable<Finance>> GetFinanceForOrderAsync(int departId, int customerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Finance> financeList = await conn.QueryAsync<Finance>("SELECT     FINANCEID, DEPARTID, CUSTOMERID, GROUPGEN2ID, OPERDATE, RATE_RUB, PRICETOTAL, PRICETOTAL_RUB, LASTPRICETOTAL, PRICETOTALAZN, PAYEDTOTAL, PAYEDTOTALAZN, CURTYPEID,  \r\n                       ROWDATE, BARCODE, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, FABRIC_AMOUNT, ROWNO, ST_ORDER,  \r\n                       CUSTELNO, REMAINTOTALALL, STATUS, ST, OTEXTILENO, OBUTTONNO, OBUTTON, OSEGMENT, STURGENT, FINANCENOTE, TAILORID,  \r\n                       CASE WHEN GROUPGEN2ID in (12001, 12002, 12003, 12006, 12007, 12012, 12013, 12014) THEN 'Suite' ELSE  \r\n                           CASE WHEN GROUPGEN2ID in (13001, 13010, 13012, 13019) THEN 'Shirt' ELSE  \r\n                               CASE WHEN GROUPGEN2ID in (12010, 12019) THEN 'Jilet' ELSE  \r\n                                   CASE WHEN GROUPGEN2ID in (12020) THEN 'Skirt' ELSE  \r\n                                       CASE WHEN GROUPGEN2ID in (12008, 12009, 12017, 12018) THEN 'Overcoat' END END END END END AS GG2  \r\n            FROM         AZSFINANCE  \r\n            WHERE     (CUSTOMERID = @cusId) AND ((STATUS = 1) or (STATUS = 0)) AND (ST IS NULL) AND  (DEPARTID = @id) ORDER BY OPERDATE DESC, FINANCEID DESC  ", (object) new
    {
      id = departId,
      cusId = customerId
    });
    await conn.CloseAsync();
    IEnumerable<Finance> financeForOrderAsync = financeList;
    conn = (SqlConnection) null;
    financeList = (IEnumerable<Finance>) null;
    return financeForOrderAsync;
  }

  public async Task<IEnumerable<Finance>> GetFinanceForOrderTodayAsync(int departId, int customerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Finance> financeList = await conn.QueryAsync<Finance>("SELECT     FINANCEID, DEPARTID, CUSTOMERID, GROUPGEN2ID, OPERDATE, RATE_RUB, PRICETOTAL, PRICETOTAL_RUB, LASTPRICETOTAL, PRICETOTALAZN, PAYEDTOTAL, PAYEDTOTALAZN, CURTYPEID,  \r\n                       ROWDATE, BARCODE, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, FABRIC_AMOUNT, ROWNO, ST_ORDER,  \r\n                       CUSTELNO, REMAINTOTALALL, STATUS, ST, OTEXTILENO, OBUTTONNO, OBUTTON, OSEGMENT, STURGENT, FINANCENOTE, TAILORID,  \r\n                       CASE WHEN GROUPGEN2ID in (12001, 12002, 12003, 12006, 12007, 12012, 12013, 12014) THEN 'Suite' ELSE  \r\n                           CASE WHEN GROUPGEN2ID in (13001, 13010, 13012, 13019) THEN 'Shirt' ELSE  \r\n                               CASE WHEN GROUPGEN2ID in (12010, 12019) THEN 'Jilet' ELSE  \r\n                                   CASE WHEN GROUPGEN2ID in (12020) THEN 'Skirt' ELSE  \r\n                                       CASE WHEN GROUPGEN2ID in (12008, 12009, 12017, 12018) THEN 'Overcoat' END END END END END AS GG2  \r\n            FROM         AZSFINANCE  \r\n            WHERE     (CUSTOMERID = @cusId) AND ((STATUS = 1) or (STATUS = 0)) AND (ST IS NULL) AND  (DEPARTID = @id) and (CAST(OPERDATE AS DATE) = CAST(GETDATE() AS DATE)) ORDER BY OPERDATE DESC, FINANCEID DESC", (object) new
    {
      id = departId,
      cusId = customerId
    });
    await conn.CloseAsync();
    IEnumerable<Finance> forOrderTodayAsync = financeList;
    conn = (SqlConnection) null;
    financeList = (IEnumerable<Finance>) null;
    return forOrderTodayAsync;
  }

  public async Task<IEnumerable<CustomerTotalFinance>> GetFinanceForDepositTodayAsync(
    int departId,
    int customerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<CustomerTotalFinance> financeList = await conn.QueryAsync<CustomerTotalFinance>("SELECT     FINANCEID, DEPARTID, CUSTOMERID, OPERDATE, PAYEDTOTAL, PAYEDTOTALAZN, CURTYPEID, REMAINTOTALALL, STATUS, CUSNAME,  \r\n                       CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, ST, FINDELIVERYST, FINANCENOTE  \r\n            FROM         AZSFINANCE  \r\n            WHERE    (CUSTOMERID = @cusId) AND (DEPARTID=@id ) AND ((STATUS = 0) OR (STATUS = 1)) AND (ST IS NULL) and (CAST(OPERDATE AS DATE) = CAST(GETDATE() AS DATE))\r\n            ORDER BY OPERDATE DESC, FINANCEID DESC", (object) new
    {
      id = departId,
      cusId = customerId
    });
    await conn.CloseAsync();
    IEnumerable<CustomerTotalFinance> depositTodayAsync = financeList;
    conn = (SqlConnection) null;
    financeList = (IEnumerable<CustomerTotalFinance>) null;
    return depositTodayAsync;
  }

  public async Task<IEnumerable<CustomerTotalFinance>> GetFinanceForDepositAsync(
    int departId,
    int customerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<CustomerTotalFinance> financeList = await conn.QueryAsync<CustomerTotalFinance>("SELECT     FINANCEID, DEPARTID, CUSTOMERID, OPERDATE, PAYEDTOTAL, PAYEDTOTALAZN, CURTYPEID, REMAINTOTALALL, STATUS, CUSNAME,  \r\n                       CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, ST, FINDELIVERYST, FINANCENOTE  \r\n            FROM         AZSFINANCE  \r\n            WHERE    (CUSTOMERID = @cusId) AND (DEPARTID=@id ) AND ((STATUS = 0) OR (STATUS = 1)) AND (ST IS NULL)\r\n            ORDER BY OPERDATE DESC, FINANCEID DESC", (object) new
    {
      id = departId,
      cusId = customerId
    });
    await conn.CloseAsync();
    IEnumerable<CustomerTotalFinance> financeForDepositAsync = financeList;
    conn = (SqlConnection) null;
    financeList = (IEnumerable<CustomerTotalFinance>) null;
    return financeForDepositAsync;
  }

  public async Task<IEnumerable<CustomersSummary>> GetCustomersSummaryAsync(int departId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<CustomersSummary> summary = await conn.QueryAsync<CustomersSummary>("exec SP_IU_AZSFINANCE;1 default,\r\n            default,default,3,@id,default,default", (object) new
    {
      id = departId
    });
    await conn.CloseAsync();
    IEnumerable<CustomersSummary> customersSummaryAsync = summary;
    conn = (SqlConnection) null;
    summary = (IEnumerable<CustomersSummary>) null;
    return customersSummaryAsync;
  }

  public async Task<IEnumerable<DailyTransactionsSummary>> GetDailyTransactionsSummaryAsync(
    int departId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<DailyTransactionsSummary> summary = await conn.QueryAsync<DailyTransactionsSummary>("exec SP_IU_AZSFINANCE;1 default,default,\r\n            default,5,@id,default,default", (object) new
    {
      id = departId
    });
    await conn.CloseAsync();
    IEnumerable<DailyTransactionsSummary> transactionsSummaryAsync = summary;
    conn = (SqlConnection) null;
    summary = (IEnumerable<DailyTransactionsSummary>) null;
    return transactionsSummaryAsync;
  }

  public async Task<int?> GetFinanceUrgentStatus(int financeId)
  {
    await using (SqlConnection connection = await this.OpenSqlConnectionAsync())
      return await connection.QueryFirstOrDefaultAsync<int?>("select STURGENT from AZSFINANCE WHERE FINANCEID = @financeId", (object) new
      {
        financeId = financeId
      });
  }

  public async Task<bool> AddFinanceAsync(AddUpdateFinanceRequest request)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int result = await conn.ExecuteAsync("INSERT INTO [dbo].[AZSFINANCE] (\r\n                [REGDATE], [REGUID], [EDITDATE], [EDITUID], [DEPARTID], [CUSTOMERID], [CUSNAME], \r\n                [CUSSURNAME], [CUSFATHERNAME], [CUSTELNO], [CUSGSM], [GROUPGEN2ID], [OPERDATE], \r\n                [BARCODE], [RATE_RUB], [PRICETOTAL], [PRICETOTAL_RUB], [LASTPRICETOTAL], [PAYEDTOTAL], \r\n                [REMAINTOTAL], [FINANCENOTE], [CURTYPEID], [PRICETOTALAZN], [PAYEDTOTALAZN], \r\n                [REMAINTOTALALL], [ROWDATE], [ROWDATELAST], [STATUS], [ST], [OTYPE], [OCODE], \r\n                [OTEXTILENO], [OBUTTONNO], [OBUTTON], [OSEGMENT], [FINDELIVERYST], [PRINTSTATUS], \r\n                [REMAINTOTALALL_90], [REMAINTOTAL_90], [FABRIC_AMOUNT], [IRONING_1], [IRONING_2], \r\n                [IRONING_1ROWDATE], [IRONING_2ROWDATE], [STURGENT], [PRINTDATE], [CUTTING_ROWDATE], \r\n                [IRONING_3ROWDATE], [ORDERDATE], [PREPARE_ROWDATE], [ST_ORDER], [ROWNO], [GIVENID], \r\n                [GIVENDATE], [FITTINGID], [FITTINGDATE], [IRONING_PRES1], [IRONING_PRES2], [PAYAZNAMOUNT], \r\n                [TAILORID], [GIVEN_NOTE]\r\n            ) \r\n            VALUES (\r\n                @RegDate, @RegUid, @EditDate, @EditUid, @DepartId, @CustomerId, @CusName, @CusSurname, \r\n                @CusFatherName, @CusTelNo, @CusGsm, @GroupGen2Id, @OperDate, @Barcode, @Rate_Rub, @PriceTotal, \r\n                @PriceTotal_Rub, @LastPriceTotal, @PayedTotal, @RemainTotal, @FinanceNote, @CurTypeId, \r\n                @PriceTotalAzn, @PayedTotalAzn, @RemainTotalAll, @RowDate, @RowDateLast, @Status, @St, \r\n                @OType, @OCode, @OTextileNo, @OButtonNo, @OButton, @OSegment, @FinDeliverySt, @PrintStatus, \r\n                @RemainTotalAll_90, @RemainTotal_90, @Fabric_Amount, @Ironing_1, @Ironing_2, @Ironing_1RowDate, \r\n                @Ironing_2RowDate, @StUrgent, @PrintDate, @Cutting_RowDate, @Ironing_3RowDate, @OrderDate, \r\n                @Prepare_RowDate, @St_Order, @RowNo, @GivenId, @GivenDate, @FittingId, @FittingDate, \r\n                @Ironing_Pres1, @Ironing_Pres2, @PayAznAmount, @TailorId, @GivenNote)", (object) new
    {
      RegDate = DateTime.Now,
      RegUid = CurrentValues.CurrentUser.UserName,
      EditDate = request.EditDate,
      EditUid = request.EditUid,
      DepartId = request.DepartId,
      CustomerId = request.CustomerId,
      CusName = request.CusName,
      CusSurname = request.CusSurname,
      CusFatherName = request.CusFatherName,
      CusTelNo = request.CusTelNo,
      CusGsm = request.CusGsm,
      GroupGen2Id = request.GroupGen2Id,
      OperDate = request.OperDate,
      Barcode = request.Barcode,
      Rate_Rub = request.Rate_Rub,
      PriceTotal = request.PriceTotal,
      PriceTotal_Rub = request.PriceTotal_Rub,
      LastPriceTotal = request.LastPriceTotal,
      PayedTotal = request.PayedTotal,
      RemainTotal = request.RemainTotal,
      FinanceNote = request.FinanceNote,
      CurTypeId = request.CurTypeId,
      PriceTotalAzn = request.PriceTotalAzn,
      PayedTotalAzn = request.PayedTotalAzn,
      RemainTotalAll = request.RemainTotalAll,
      RowDate = request.RowDate,
      RowDateLast = request.RowDateLast,
      Status = request.Status,
      St = request.St,
      OType = request.OType,
      OCode = request.OCode,
      OTextileNo = request.OTextileNo,
      OButtonNo = request.OButtonNo,
      OButton = request.OButton,
      OSegment = request.OSegment,
      FinDeliverySt = request.FinDeliverySt,
      PrintStatus = request.PrintStatus,
      RemainTotalAll_90 = request.RemainTotalAll_90,
      RemainTotal_90 = request.RemainTotal_90,
      Fabric_Amount = request.Fabric_Amount,
      Ironing_1 = request.Ironing_1,
      Ironing_2 = request.Ironing_2,
      Ironing_1RowDate = request.Ironing_1RowDate,
      Ironing_2RowDate = request.Ironing_2RowDate,
      StUrgent = request.StUrgent,
      PrintDate = request.PrintDate,
      Cutting_RowDate = request.Cutting_RowDate,
      Ironing_3RowDate = request.Ironing_3RowDate,
      OrderDate = request.OrderDate,
      Prepare_RowDate = request.Prepare_RowDate,
      St_Order = request.St_Order,
      RowNo = request.RowNo,
      GivenId = request.GivenId,
      GivenDate = request.GivenDate,
      FittingId = request.FittingId,
      FittingDate = request.FittingDate,
      Ironing_Pres1 = request.Ironing_Pres1,
      Ironing_Pres2 = request.Ironing_Pres2,
      PayAznAmount = request.PayAznAmount,
      TailorId = request.TailorId,
      GivenNote = request.GivenNote
    });
    await conn.CloseAsync();
    bool flag = result != 0;
    conn = (SqlConnection) null;
    return flag;
  }

  public async Task<bool> UpdateFinanceAsync(int financeId, AddUpdateFinanceRequest request)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int result = await conn.ExecuteAsync("UPDATE [dbo].[AZSFINANCE] \r\n            SET \r\n            [REGDATE] = @RegDate,\r\n    [CUSNAME] = @CusName,\r\n    [CUSSURNAME] = @CusSurname,\r\n    [CUSTELNO] = @CusTelNo,\r\n    [CUSGSM] = @CusGsm,\r\n    [GROUPGEN2ID] = @GroupGen2Id,\r\n    [TAILORID] = @TailorId,\r\n    [STURGENT] = @StUrgent,\r\n    [OPERDATE] = @OperDate,\r\n    [BARCODE] = @Barcode,\r\n    [PRICETOTAL] = @PriceTotal,\r\n    [LASTPRICETOTAL] = @LastPriceTotal,\r\n    [PAYEDTOTAL] = @PayedTotal,\r\n    [CURTYPEID] = @CurTypeId,\r\n    [ROWDATE] = @RowDate\r\n        WHERE [FINANCEID] = @FinanceId", (object) new
    {
      FinanceId = financeId,
      CustomerId = request.CustomerId,
      RegDate = request.RegDate,
      CusName = request.CusName,
      CusSurname = request.CusSurname,
      CusTelNo = request.CusTelNo,
      CusGsm = request.CusGsm,
      GroupGen2Id = request.GroupGen2Id,
      TailorId = request.TailorId,
      StUrgent = request.StUrgent,
      OperDate = request.OperDate,
      Barcode = request.Barcode,
      PriceTotal = request.PriceTotal,
      LastPriceTotal = request.LastPriceTotal,
      PayedTotal = request.PayedTotal,
      CurTypeId = request.CurTypeId,
      RowDate = request.RowDate
    });
    await conn.CloseAsync();
    bool flag = result != 0;
    conn = (SqlConnection) null;
    return flag;
  }

  public async Task<IEnumerable<CustomersSummary>> GetCustomersSummaryWithPaginationAsync(
    int departId,
    int page,
    int size)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string str = " WHERE (1 = 1)  ";
    IEnumerable<CustomersSummary> summary = await conn.QueryAsync<CustomersSummary>($"SELECT \r\n    CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, \r\n    CASE WHEN SUM(PRICETOTAL) <> 0 THEN SUM(PRICETOTAL) ELSE NULL END AS PRICETOTAL, \r\n    CASE WHEN SUM(PRICETOTAL_RUB) <> 0 THEN SUM(PRICETOTAL_RUB) ELSE NULL END AS PRICETOTAL_RUB,\r\n    CASE WHEN SUM(LASTPRICETOTAL) <> 0 THEN SUM(LASTPRICETOTAL) ELSE NULL END AS LASTPRICETOTAL, \r\n    SUM(PayTotAZN) AS PayTotAZN, SUM(PayTotUSD) AS PayTotUSD, SUM(PayTotEUR) AS PayTotEUR, SUM(PayTotRUR) AS PayTotRUR, \r\n    CASE WHEN REMAINTOTALALL <> 0 THEN REMAINTOTALALL ELSE NULL END AS REMAINTOTALALL, \r\n    MAX(FINANCEID) AS MaxFinID\r\nFROM (\r\n    SELECT \r\n        DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n        (DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, \r\n        PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n        CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n        CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n        CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n        CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n        FINANCEID\r\n    FROM dbo.AZSFINANCE{(departId != 12 ? str + "AND DEPARTID = @DEPARTID " : str + "AND (DEPARTID in (11, 12)) ")}) AS F\r\nGROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\nORDER BY OPERDATE DESC, MaxFinID DESC\r\nOFFSET @OFFSET ROWS FETCH NEXT @SIZE ROWS ONLY;\r\n", (object) new
    {
      OFFSET = ((page - 1) * size),
      SIZE = size,
      DEPARTID = departId,
      date = DateTime.Now
    });
    await conn.CloseAsync();
    IEnumerable<CustomersSummary> withPaginationAsync = summary;
    conn = (SqlConnection) null;
    summary = (IEnumerable<CustomersSummary>) null;
    return withPaginationAsync;
  }

  public async Task<IEnumerable<CustomersSummary>> GetCustomersSummaryDailyAsync(int departId)
  {
    FinanceRepository financeRepository = this;
    try
    {
      SqlConnection conn = await financeRepository.OpenSqlConnectionAsync();
      string str1 = " WHERE (1 = 1) AND OPERDATE > @startDate AND OPERDATE< @endDate  ";
      string str2 = departId != 12 ? str1 + "AND DEPARTID = @DEPARTID " : str1 + "AND (DEPARTID in (11, 12)) ";
      SqlConnection cnn = conn;
      string sql = $"SELECT \r\n    CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, \r\n    CASE WHEN SUM(PRICETOTAL) <> 0 THEN SUM(PRICETOTAL) ELSE NULL END AS PRICETOTAL, \r\n    CASE WHEN SUM(PRICETOTAL_RUB) <> 0 THEN SUM(PRICETOTAL_RUB) ELSE NULL END AS PRICETOTAL_RUB,\r\n    CASE WHEN SUM(LASTPRICETOTAL) <> 0 THEN SUM(LASTPRICETOTAL) ELSE NULL END AS LASTPRICETOTAL, \r\n    SUM(PayTotAZN) AS PayTotAZN, SUM(PayTotUSD) AS PayTotUSD, SUM(PayTotEUR) AS PayTotEUR, SUM(PayTotRUR) AS PayTotRUR, \r\n    CASE WHEN REMAINTOTALALL <> 0 THEN REMAINTOTALALL ELSE NULL END AS REMAINTOTALALL, \r\n    MAX(FINANCEID) AS MaxFinID\r\nFROM (\r\n    SELECT \r\n        DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n        (DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, \r\n        PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n        CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n        CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n        CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n        CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n        FINANCEID\r\n    FROM dbo.AZSFINANCE{str2}) AS F\r\nGROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\nORDER BY OPERDATE DESC, MaxFinID DESC\r\n";
      int num = departId;
      DateTime dateTime = DateTime.Now;
      string str3 = dateTime.ToString("yyyy-MM-dd");
      dateTime = DateTime.Now;
      dateTime = dateTime.AddDays(1.0);
      string str4 = dateTime.ToString("yyyy-MM-dd");
      var data = new
      {
        DEPARTID = num,
        startDate = str3,
        endDate = str4
      };
      int? commandTimeout = new int?();
      CommandType? commandType = new CommandType?();
      IEnumerable<CustomersSummary> summary = await cnn.QueryAsync<CustomersSummary>(sql, (object) data, commandTimeout: commandTimeout, commandType: commandType);
      await conn.CloseAsync();
      return summary;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
    return (IEnumerable<CustomersSummary>) new List<CustomersSummary>();
  }

  public async Task<int> GetCustomersSummaryCountAsync(int departId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string str = " WHERE (1 = 1) ";
    int summary = await conn.QueryFirstOrDefaultAsync<int>($"\r\nSELECT COUNT(*) AS TotalRows\r\nFROM (\r\n    SELECT \r\n        CUSTOMERID\r\n    FROM (\r\n        SELECT \r\n            DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n            (DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, \r\n            PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n            CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n            CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n            CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n            CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n            FINANCEID\r\n        FROM dbo.AZSFINANCE{(departId != 12 ? str + "AND DEPARTID = @DEPARTID " : str + "AND (DEPARTID in (11, 12)) ")}\r\n        \r\n    ) AS F\r\n    GROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\n) AS TotalCountQuery;", (object) new
    {
      DEPARTID = departId
    });
    await conn.CloseAsync();
    int summaryCountAsync = summary;
    conn = (SqlConnection) null;
    return summaryCountAsync;
  }

  public async Task<CustomersSummaryTotal> GetCustomersSummaryTotalAsync(int departId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string str = " WHERE (1 = 1) ";
    CustomersSummaryTotal summary = await conn.QueryFirstOrDefaultAsync<CustomersSummaryTotal>($"\r\nSELECT  SUM(T.PayTotUSD) AS SumPayUSD,SUM(T.PayTotAZN) AS SumPayAZN, SUM(T.PayTotEUR)AS SumPayEUR,SUM(T.PayTotRUR) AS SumPayRUB,SUM(T.REMAINTOTALALL) AS SumRemainTotalAll FROM(\r\n\r\nSELECT     TOP (100) PERCENT /*row_number() over (ORDER BY (MAX(FINANCEID)+OPERDATE) DESC) AS FID, */\r\n\t\tCUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, \r\n\t\t\t\t\t\tCASE WHEN SUM(PRICETOTAL) <> 0 then SUM(PRICETOTAL) else NULL end AS PRICETOTAL, \r\n\t\t\t\t\t\tCASE WHEN SUM(PRICETOTAL_RUB) <> 0 then SUM(PRICETOTAL_RUB) else NULL end AS PRICETOTAL_RUB,\r\n\t\t\t\t\t\tCASE WHEN SUM(LASTPRICETOTAL) <> 0 then SUM(LASTPRICETOTAL) else NULL end AS LASTPRICETOTAL, \r\n\t\t\t\t\t\tSUM(PayTotAZN) AS PayTotAZN, SUM(PayTotUSD) AS PayTotUSD, SUM(PayTotEUR) AS PayTotEUR, SUM(PayTotRUR) AS PayTotRUR, \r\n\t\t\t\t\t\tCASE WHEN REMAINTOTALALL <> 0 THEN REMAINTOTALALL ELSE NULL end AS REMAINTOTALALL, MAX(FINANCEID) AS MaxFinID\r\n\t\t\t\t\t\t   FROM          (SELECT     TOP (100) PERCENT DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  FINANCEID\r\n\t\t\t\t\t\t\t\t\t\t\t\t   FROM          dbo.AZSFINANCE{(departId != 12 ? str + "AND DEPARTID = @DEPARTID " : str + "AND (DEPARTID in (11, 12))  ")}\r\n        \r\n    \t\t\t\t\t\t) AS F\r\n\t   GROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\n       ORDER BY OPERDATE DESC, MaxFinID DESC\r\n\r\n) AS T\r\n\r\n", (object) new
    {
      DEPARTID = departId
    });
    await conn.CloseAsync();
    CustomersSummaryTotal summaryTotalAsync = summary;
    conn = (SqlConnection) null;
    summary = (CustomersSummaryTotal) null;
    return summaryTotalAsync;
  }

  public async Task<CustomersSummaryTotal> GetCustomersSummaryDailyTotalAsync(int departId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string str1 = " WHERE (1 = 1) AND OPERDATE > @startDate AND OPERDATE< @endDate ";
    string str2 = departId != 12 ? str1 + "AND DEPARTID = @DEPARTID " : str1 + "AND (DEPARTID in (11, 12))  ";
    SqlConnection cnn = conn;
    string sql = $"\r\nSELECT  SUM(T.PayTotUSD) AS SumPayUSD,SUM(T.PayTotAZN) AS SumPayAZN, SUM(T.PayTotEUR)AS SumPayEUR,SUM(T.PayTotRUR) AS SumPayRUB,SUM(T.REMAINTOTALALL) AS SumRemainTotalAll FROM(\r\n\r\nSELECT     TOP (100) PERCENT /*row_number() over (ORDER BY (MAX(FINANCEID)+OPERDATE) DESC) AS FID, */\r\n\t\tCUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, \r\n\t\t\t\t\t\tCASE WHEN SUM(PRICETOTAL) <> 0 then SUM(PRICETOTAL) else NULL end AS PRICETOTAL, \r\n\t\t\t\t\t\tCASE WHEN SUM(PRICETOTAL_RUB) <> 0 then SUM(PRICETOTAL_RUB) else NULL end AS PRICETOTAL_RUB,\r\n\t\t\t\t\t\tCASE WHEN SUM(LASTPRICETOTAL) <> 0 then SUM(LASTPRICETOTAL) else NULL end AS LASTPRICETOTAL, \r\n\t\t\t\t\t\tSUM(PayTotAZN) AS PayTotAZN, SUM(PayTotUSD) AS PayTotUSD, SUM(PayTotEUR) AS PayTotEUR, SUM(PayTotRUR) AS PayTotRUR, \r\n\t\t\t\t\t\tCASE WHEN REMAINTOTALALL <> 0 THEN REMAINTOTALALL ELSE NULL end AS REMAINTOTALALL, MAX(FINANCEID) AS MaxFinID\r\n\t\t\t\t\t\t   FROM          (SELECT     TOP (100) PERCENT DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t(DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  FINANCEID\r\n\t\t\t\t\t\t\t\t\t\t\t\t   FROM          dbo.AZSFINANCE{str2}\r\n        \r\n    \t\t\t\t\t\t) AS F\r\n\t   GROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\n       ORDER BY OPERDATE DESC, MaxFinID DESC\r\n\r\n) AS T\r\n\r\n";
    int num = departId;
    string str3 = DateTime.Now.ToString("yyyy-MM-dd");
    DateTime dateTime = DateTime.Now;
    dateTime = dateTime.AddDays(1.0);
    string str4 = dateTime.ToString("yyyy-MM-dd");
    var data = new
    {
      DEPARTID = num,
      startDate = str3,
      endDate = str4
    };
    int? commandTimeout = new int?();
    CommandType? commandType = new CommandType?();
    CustomersSummaryTotal summary = await cnn.QueryFirstOrDefaultAsync<CustomersSummaryTotal>(sql, (object) data, commandTimeout: commandTimeout, commandType: commandType);
    await conn.CloseAsync();
    CustomersSummaryTotal summaryDailyTotalAsync = summary;
    conn = (SqlConnection) null;
    summary = (CustomersSummaryTotal) null;
    return summaryDailyTotalAsync;
  }

  public async Task<IEnumerable<CustomersSummary>> GetFilteredCustomersSummaryAsync(
    int departmentId,
    string customerId = "",
    string name = "",
    string surname = "")
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string str = " WHERE (1 = 1) ";
    if (!customerId.IsNullOrEmpty<char>())
      str += " AND CUSTOMERID = @customerId ";
    if (!name.IsNullOrEmpty<char>())
      str = $"{str} AND CUSNAME LIKE '%{name}%' ";
    if (!surname.IsNullOrEmpty<char>())
      str = $"{str} AND CUSSURNAME LIKE '%{surname}%' ";
    IEnumerable<CustomersSummary> summary = await conn.QueryAsync<CustomersSummary>($"SELECT \r\n    CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, \r\n    CASE WHEN SUM(PRICETOTAL) <> 0 THEN SUM(PRICETOTAL) ELSE NULL END AS PRICETOTAL, \r\n    CASE WHEN SUM(PRICETOTAL_RUB) <> 0 THEN SUM(PRICETOTAL_RUB) ELSE NULL END AS PRICETOTAL_RUB,\r\n    CASE WHEN SUM(LASTPRICETOTAL) <> 0 THEN SUM(LASTPRICETOTAL) ELSE NULL END AS LASTPRICETOTAL, \r\n    SUM(PayTotAZN) AS PayTotAZN, SUM(PayTotUSD) AS PayTotUSD, SUM(PayTotEUR) AS PayTotEUR, SUM(PayTotRUR) AS PayTotRUR, \r\n    CASE WHEN REMAINTOTALALL <> 0 THEN REMAINTOTALALL ELSE NULL END AS REMAINTOTALALL, \r\n    MAX(FINANCEID) AS MaxFinID\r\nFROM (\r\n    SELECT \r\n        DEPARTID, CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO,  \r\n        (DATEADD(dd, 0, DATEDIFF(dd, 0, OPERDATE))) AS OPERDATE, RATE_RUB, PRICETOTAL_RUB, \r\n        PRICETOTAL, LASTPRICETOTAL, REMAINTOTALALL, CURTYPEID, \r\n        CASE WHEN CURTYPEID = 1 THEN PAYEDTOTAL ELSE NULL END AS PayTotAZN, \r\n        CASE WHEN CURTYPEID = 2 THEN PAYEDTOTAL ELSE NULL END AS PayTotUSD, \r\n        CASE WHEN CURTYPEID = 3 THEN PAYEDTOTAL ELSE NULL END AS PayTotEUR, \r\n        CASE WHEN CURTYPEID = 4 THEN PAYEDTOTAL ELSE NULL END AS PayTotRUR, \r\n        FINANCEID\r\n    FROM dbo.AZSFINANCE{(departmentId != 12 ? str + "AND DEPARTID = @DEPARTID " : str + "AND (DEPARTID in (11, 12)) ")}) AS F\r\nGROUP BY CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSGSM, CUSTELNO, OPERDATE, REMAINTOTALALL\r\nORDER BY OPERDATE DESC, MaxFinID DESC\r\n", (object) new
    {
      DEPARTID = departmentId,
      customerId = customerId
    });
    await conn.CloseAsync();
    IEnumerable<CustomersSummary> customersSummaryAsync = summary;
    conn = (SqlConnection) null;
    summary = (IEnumerable<CustomersSummary>) null;
    return customersSummaryAsync;
  }
}
