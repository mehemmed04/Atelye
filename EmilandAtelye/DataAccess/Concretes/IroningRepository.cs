// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.IroningRepository
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

public class IroningRepository(string connectionString) : BaseSqlRepository(connectionString), IIroningRepository
{
  public async Task<IEnumerable<IroningDaily>> GetIroningDaily(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<IroningDaily> ironingDaily = await conn.QueryAsync<IroningDaily>("exec SP_IRONING_Daily @Date,default,0", (object) new
    {
      Date = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<IroningDaily> ironingDaily1 = ironingDaily;
    conn = (SqlConnection) null;
    ironingDaily = (IEnumerable<IroningDaily>) null;
    return ironingDaily1;
  }

  public async Task<IEnumerable<Ironing1>> GetIroning1Detail(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Ironing1> ironingDetails = await conn.QueryAsync<Ironing1>("exec SP_IRONING @rowDate,1,default,default,default", (object) new
    {
      rowDate = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<Ironing1> ironing1Detail = ironingDetails;
    conn = (SqlConnection) null;
    ironingDetails = (IEnumerable<Ironing1>) null;
    return ironing1Detail;
  }

  public async Task<IEnumerable<Ironing1>> GetIroning1NextDetail(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Ironing1> ironingNextDetails = await conn.QueryAsync<Ironing1>("exec SP_IRONING;1 @rowDate,1,default,default,default", (object) new
    {
      rowDate = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<Ironing1> ironing1NextDetail = ironingNextDetails;
    conn = (SqlConnection) null;
    ironingNextDetails = (IEnumerable<Ironing1>) null;
    return ironing1NextDetail;
  }

  public async Task<CustomerIroningDetail> GetCustomerIroningDetail(int customerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    CustomerIroningDetail details = await conn.QueryFirstOrDefaultAsync<CustomerIroningDetail>("SELECT S.CUSTOMERID, S.DEPARTID, D.DEPARTSHORTNAME,\r\n            S.P1, S.P2, S.P3, S.P4, S.P5, S.P6, S.P7, S.P8, S.P9, S.P10,\r\n            S.P11, S.P12, S.P13, S.P14, S.P15, S.P16, S.P17, S.P18,\r\n            S.P19, S.P20, S.P21, S.P22, S.P23, S.P24, S.P25, S.P26,\r\n            S.ODATE, S.P27, S.P28, S.P29, S.P30, S.P31, S.P32,\r\n            S.STATUS, S.STURGENT\r\n            FROM dbo.AZSSUITE AS S INNER JOIN dbo.LPRODEPART AS D\r\n            ON S.DEPARTID = D.DEPARTID\r\n            WHERE  (S.STATUS = 0)\r\n             AND (S.CUSTOMERID = @id)", (object) new
    {
      id = customerId
    });
    await conn.CloseAsync();
    CustomerIroningDetail customerIroningDetail = details;
    conn = (SqlConnection) null;
    details = (CustomerIroningDetail) null;
    return customerIroningDetail;
  }

  public async Task<IEnumerable<Ironing2>> GetIroning2Detail(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Ironing2> details = await conn.QueryAsync<Ironing2>("\r\n    SELECT \r\n        F.DEPARTID, F.CUSTOMERID, F.CUSNAME, F.CUSSURNAME, F.GROUPGEN2ID,   \r\n        GG2.GROUPGEN2SHORTNAME, GG2.IRONING_12, GG2.ST_IRONING, \r\n        F.IRONING_1, F.IRONING_2, F.FINANCEID,  \r\n        1 AS ST, \r\n        F.IRONING_1 + F.IRONING_2 AS TOTAL_IRONING,  \r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.ROWDATE)) AS ROWDATE,   F.PREPARE_ROWDATE, F.Cutting_RowDate, F.Ironing_3RowDate, F.Ironing_2,\r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.OPERDATE)) AS OPERDATE \r\n    FROM dbo.AZSFINANCE AS F \r\n    INNER JOIN dbo.LPROGROUPGEN2 AS GG2  \r\n        ON F.GROUPGEN2ID = GG2.GROUPGEN2ID   \r\n    WHERE \r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.ROWDATE)) = @Tarih and ( F.GROUPGEN2ID = 11002 or F.GROUPGEN2ID = 13001 or F.GROUPGEN2ID = 13010 or F.GROUPGEN2ID = 13012 or F.GROUPGEN2ID = 13019  )\r\n    ORDER BY F.IRONING_1 + F.IRONING_2 ASC, ST, GG2.ST_IRONING, F.CUSNAME, F.CUSSURNAME;", (object) new
    {
      Tarih = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<Ironing2> ironing2Detail = details;
    conn = (SqlConnection) null;
    details = (IEnumerable<Ironing2>) null;
    return ironing2Detail;
  }

  public async Task<IEnumerable<Ironing2>> GetIroning2NextDetail(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Ironing2> nextDetails = await conn.QueryAsync<Ironing2>("\r\n    SELECT \r\n        F.DEPARTID, F.CUSTOMERID, F.CUSNAME, F.CUSSURNAME, F.GROUPGEN2ID,   \r\n        GG2.GROUPGEN2SHORTNAME, GG2.IRONING_12, GG2.ST_IRONING, \r\n        F.IRONING_1, F.IRONING_2, F.FINANCEID,  \r\n        1 AS ST, \r\n        F.IRONING_1 + F.IRONING_2 AS TOTAL_IRONING,  \r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.ROWDATE)) AS ROWDATE,   F.PREPARE_ROWDATE, F.Cutting_RowDate, F.Ironing_3RowDate, F.Ironing_2,\r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.OPERDATE)) AS OPERDATE \r\n    FROM dbo.AZSFINANCE AS F \r\n    INNER JOIN dbo.LPROGROUPGEN2 AS GG2  \r\n        ON F.GROUPGEN2ID = GG2.GROUPGEN2ID   \r\n    WHERE \r\n        DATEADD(dd, 0, DATEDIFF(dd, 0, F.ROWDATE)) = @Tarih and ( F.GROUPGEN2ID = 11002 or F.GROUPGEN2ID = 13001 or F.GROUPGEN2ID = 13010 or F.GROUPGEN2ID = 13012 or F.GROUPGEN2ID = 13019  )\r\n    ORDER BY F.IRONING_1 + F.IRONING_2 ASC, ST, GG2.ST_IRONING, F.CUSNAME, F.CUSSURNAME;", (object) new
    {
      Tarih = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<Ironing2> ironing2NextDetail = nextDetails;
    conn = (SqlConnection) null;
    nextDetails = (IEnumerable<Ironing2>) null;
    return ironing2NextDetail;
  }

  public async Task Planlama(int financeId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE dbo.AZSFINANCE\r\n        SET PREPARE_ROWDATE = \r\n            CASE \r\n                WHEN PREPARE_ROWDATE IS NULL THEN GETDATE()  \r\n                ELSE NULL  \r\n            END\r\n        WHERE FINANCEID = @FinanceId; ", (object) new
    {
      FinanceId = financeId
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }

  public async Task Kesim(int financeId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE dbo.AZSFINANCE\r\nSET CUTTING_ROWDATE = \r\n    CASE \r\n        WHEN CUTTING_ROWDATE IS NULL THEN GETDATE() \r\n        ELSE NULL  \r\n    END\r\nWHERE FINANCEID = @FinanceId", (object) new
    {
      FinanceId = financeId
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }

  public async Task Hazir1ci(int financeId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE dbo.AZSFINANCE\r\nSET \r\n    IRONING_1 = CASE \r\n                  WHEN IRONING_1ROWDATE IS NULL THEN 1 \r\n                  ELSE NULL\r\n                END,\r\n    IRONING_1ROWDATE = CASE \r\n                         WHEN IRONING_1ROWDATE IS NULL THEN GETDATE()\r\n                         ELSE NULL\r\n                       END\r\nWHERE FINANCEID = @FinanceId;", (object) new
    {
      FinanceId = financeId
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }

  public async Task SonYoxlama(int financeId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE dbo.AZSFINANCE\r\nSET \r\n    IRONING_3ROWDATE = CASE \r\n                           WHEN IRONING_3ROWDATE IS NULL THEN GETDATE() \r\n                           ELSE NULL \r\n                       END\r\nWHERE FINANCEID = @FinanceId;", (object) new
    {
      FinanceId = financeId
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }

  public async Task Hazir2ci(int financeId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE dbo.AZSFINANCE\r\nSET \r\n    IRONING_2 = CASE \r\n                  WHEN IRONING_2ROWDATE IS NULL THEN 1 \r\n                  ELSE NULL\r\n                END,\r\n    IRONING_2ROWDATE = CASE \r\n                         WHEN IRONING_2ROWDATE IS NULL THEN GETDATE()\r\n                         ELSE NULL\r\n                       END\r\nWHERE FINANCEID = @FinanceId; ", (object) new
    {
      FinanceId = financeId
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }
}
