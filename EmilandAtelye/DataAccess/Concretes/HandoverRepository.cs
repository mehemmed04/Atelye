// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.HandoverRepository
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

public class HandoverRepository(string connectionString) : BaseSqlRepository(connectionString), IHandoverRepository
{
  public async Task<IEnumerable<Handover>> GetHandoversAsync(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Handover> handovers = await conn.QueryAsync<Handover>("SELECT    C.CUSTOMERID, C.DEPARTID, C.CUSNAME, C.CUSSURNAME, C.CUSFATHERNAME, C.CUSTELNO, C.CUSGSM, C.CUSRELATION,\r\n\r\n\t\t\t\t\t  CASE WHEN C.REMAINTOTALALL = 0 THEN NULL ELSE C.REMAINTOTALALL END AS REMAINTOTALALL, C.GCALLID, C.GCALLIDTIME, C.GCALLID2, C.GCALLIDTIME2,\r\n                      C.GCALLID3, C.GCALLIDTIME3, C.GSMSID, C.GSMSIDTIME, C.GSMSID2, C.GSMSIDTIME2, C.GSMSID3, C.GSMSIDTIME3, C.GCALLNOTE, C.GIVEN_NOTE, C.GLASTTIME, C.FITTINGID,\r\n\r\n\r\n\t\t\t CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) = DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate))\r\n\t\t\t\t\tAND (C.GLASTTIME IS NULL OR DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate)) > DATEADD(dd, 0, DATEDIFF(dd, 0, C.GLASTTIME))) THEN 1\r\n\t\t\t\tELSE CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) <> DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate)) AND\r\n\t\t\t\t((C.GCALLIDTIME IS NULL  OR P.IronDate >=C.GCALLIDTIME) AND (C.GCALLIDTIME2 IS NULL  OR P.IronDate >=C.GCALLIDTIME2)\r\n\t\t\t\t\tAND (C.GCALLIDTIME3 IS NULL  OR P.IronDate >=C.GCALLIDTIME3)\r\n\t\t\t\t\tAND (C.GSMSIDTIME IS NULL  OR P.IronDate >=C.GSMSIDTIME) AND (C.GSMSIDTIME2 IS NULL  OR P.IronDate >=C.GSMSIDTIME2)\r\n\t\t\t\t\tAND (C.GSMSIDTIME3 IS NULL  OR P.IronDate >=C.GSMSIDTIME3) AND (C.GLASTTIME IS NULL  OR P.IronDate >=C.GLASTTIME)) THEN 2\r\n\t\t\t\tELSE CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, C.GLASTTIME)) < DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))-3 OR (C.GLASTTIME IS NULL) THEN 3\r\n\t\t\t\tELSE  CASE WHEN (P.MaxGivenDate >='05/15/2017' AND C.REMAINTOTALALL >0 AND P.GSAY = 0) THEN 1 ELSE 4  END END END END AS ST_Old,\r\n CASE WHEN (P.MaxGivenDate >='05/15/2017' AND C.REMAINTOTALALL >0 AND P.GSAY = 0) THEN 1 ELSE NULL END AS T,\r\n\r\n\r\n\t\tCASE\r\n    WHEN CAST(GETDATE() AS DATE) = CAST(P.IronDate AS DATE)\r\n         AND C.GCALLIDTIME IS NULL\r\n         AND C.GCALLIDTIME2 IS NULL\r\n         AND C.GCALLIDTIME3 IS NULL\r\n         AND C.GSMSIDTIME IS NULL\r\n         AND C.GSMSIDTIME2 IS NULL\r\n         AND C.GSMSIDTIME3 IS NULL THEN 1\r\n    ELSE CASE\r\n        WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) <> DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate))\r\n             AND (C.GCALLIDTIME IS NULL AND C.GCALLIDTIME2 IS NULL\r\n                  AND C.GCALLIDTIME3 IS NULL\r\n                  AND C.GSMSIDTIME IS NULL AND C.GSMSIDTIME2 IS NULL\r\n                  AND C.GSMSIDTIME3 IS NULL AND C.GLASTTIME IS NULL) THEN 2\r\n        ELSE CASE\r\n            WHEN (C.GCALLIDTIME IS NOT NULL OR C.GCALLIDTIME2 IS NOT NULL OR\r\n                  C.GCALLIDTIME3 IS NOT NULL OR C.GSMSIDTIME IS NOT NULL OR\r\n                  C.GSMSIDTIME2 IS NOT NULL OR C.GSMSIDTIME3 IS NOT NULL)\r\n            AND DATEDIFF(dd,\r\n                (SELECT MAX(TimeValue)\r\n                 FROM (VALUES (C.GCALLIDTIME), (C.GCALLIDTIME2),\r\n                              (C.GCALLIDTIME3), (C.GSMSIDTIME),\r\n                              (C.GSMSIDTIME2), (C.GSMSIDTIME3)) AS TimeTable(TimeValue)\r\n                 WHERE TimeValue IS NOT NULL),\r\n                GETDATE()) < 3 THEN 3\r\n            ELSE 4\r\n        END\r\n    END\r\nEND AS ST\r\n\r\n\r\n\r\nFROM         (SELECT CUSTOMERID, MAX(IronDate) AS IronDate, MAX(MaxGivenDate) AS MaxGivenDate, MAX(GSay) AS GSay FROM\r\n\t\t\t\t\t(SELECT     CUSTOMERID, MAX(IRONING_3ROWDATE) AS IronDate, MAX(GIVENDATE) AS MaxGivenDate, sum(case when GIVENDATE is null then 1 else 0 end) GSay\r\n\t\t\t\t\t\t\t\t\t\t\t   FROM          AZSFINANCE\r\n\t\t\t\t\t\t\t\t\t\t\t   WHERE  /*(customerid=21139) and  */ (OPERDATE>='09/01/2014') and (IRONING_3ROWDATE>='09/01/2014') AND (NOT(GROUPGEN2ID in (13001, 13010, 13012,13019, 12000))) AND (IRONING_1=1 OR IRONING_2=1) AND ((GIVENDATE IS NULL OR GIVENDATE > DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))) OR (GIVENDATE >='05/15/2017' AND REMAINTOTALALL >0))\r\n\t\t\t\t\t\t\t\t\t   GROUP BY CUSTOMERID\r\n\t\t\t\t\tUNION ALL\r\n\t\t\t\t\tSELECT     CUSTOMERID, MAX(IRONING_2ROWDATE) AS IronDate, MAX(GIVENDATE) AS MaxGivenDate, sum(case when GIVENDATE is null then 1 else 0 end) GSay\r\n\t\t\t\t\t\t\t\t\t\t\t   FROM          AZSFINANCE\r\n\t\t\t\t\t\t\t\t\t\t\t   WHERE  /*(customerid=21139) and  */   (OPERDATE>='09/01/2014') and (IRONING_2ROWDATE>='09/01/2014') AND (GROUPGEN2ID in (13001, 13010, 13012,13019)) AND ((GIVENDATE IS NULL OR GIVENDATE > DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))) OR (GIVENDATE >='05/15/2017' AND REMAINTOTALALL >0))\r\n\t\t\t\t\t\t\t\t\t\t\t   GROUP BY CUSTOMERID) AS P\r\n\t\t\t\t\tGROUP BY CUSTOMERID) AS P INNER JOIN\r\n\t\t\t\t\t\t  AZSCUSTOMER AS C ON P.CUSTOMERID = C.CUSTOMERID LEFT OUTER JOIN\r\n\t\t\t\t\t\t\t  (SELECT     CUSTOMERID\r\n\t\t\t\t\t\t\t\tFROM          AZSFINANCE AS AZSFINANCE_1\r\n\t\t\t\t\t\t\t\tWHERE   /* (customerid=21139) and */ (OPERDATE>='09/01/2014') and  ((IRONING_2ROWDATE IS NULL) ) AND (GROUPGEN2ID in (13001, 13010, 13012,13019)) GROUP BY CUSTOMERID) AS NP2 ON\r\n\t\t\t\t\t\t  P.CUSTOMERID = NP2.CUSTOMERID LEFT OUTER JOIN\r\n\t\t\t\t\t\t\t  (SELECT     CUSTOMERID\r\n\t\t\t\t\t\t\t\tFROM          AZSFINANCE AS F INNER JOIN\r\n\t\t\t\t\t\t\t\t  LPROGROUPGEN2 AS GG2 ON F.GROUPGEN2ID = GG2.GROUPGEN2ID\r\n\t\t\t\t\t\t\t\tWHERE  /* (customerid=21139) and */ (F.OPERDATE>='09/01/2014') and ((F.IRONING_3ROWDATE IS NULL)) AND (GG2.GROUPGEN1ID = 12) AND (NOT(F.GROUPGEN2ID in (12000))) GROUP BY F.CUSTOMERID) AS NP ON\r\n\t\t\t\t\t\t  P.CUSTOMERID = NP.CUSTOMERID\r\n\tWHERE     (C.DEPARTID LIKE @departId) /*AND (NP.CUSTOMERID IS NULL) AND (NP2.CUSTOMERID IS NULL) --and C.CUSTOMERID = 22779 --1915 --22779*/\r\n--and C.CUSTOMERID in (21106, 7908, 10051) 21139\r\n\tORDER BY  ST, P.IronDate DESC, C.GLASTTIME DESC, C.CUSTOMERID \r\n        ", (object) new
    {
      departId = departmentId
    });
    await conn.CloseAsync();
    IEnumerable<Handover> handoversAsync = handovers;
    conn = (SqlConnection) null;
    handovers = (IEnumerable<Handover>) null;
    return handoversAsync;
  }

  public async Task UpdateGivenAsync(HandoverDouble handoverdouble)
  {
    HandoverRepository handoverRepository = this;
    try
    {
      SqlConnection conn = await handoverRepository.OpenSqlConnectionAsync();
      int num = await conn.ExecuteAsync("UPDATE [dbo].[AZSFINANCE] \r\n        SET \r\n[GIVENDATE]=@GivenDate,\r\n[GIVENID]=@GivenId,\r\n[FITTINGDATE]=@FittingDate,\r\n[FITTINGID]=@FittingId\r\n        WHERE [FINANCEID] = @FinanceId", (object) new
      {
        GivenDate = handoverdouble.GivenDate,
        GivenId = handoverdouble.GivenId,
        FittingDate = handoverdouble.FittingDate,
        FittingId = handoverdouble.FittingId,
        FinanceId = handoverdouble.FinanceId
      });
      await conn.CloseAsync();
      conn = (SqlConnection) null;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public async Task UpdateHandoverAsync(Handover handover)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE [dbo].[AZSCUSTOMER] \r\n        SET \r\n[GCALLID]=@GCallId,\r\n[GCALLID2]=@GCallId2,\r\n[GCALLID3]=@GCallId3,\r\n[GCALLIDTIME] = @GCallIdTime,\r\n[GCALLIDTIME2]=@GCallIdTime2,\r\n[GCALLIDTIME3]=@GCallIdTime3,\r\n[GSMSID]=@GSmsId,\r\n[GSMSID2]=@GSmsId2,\r\n[GSMSID3]=@GSmsId3,\r\n[GSMSIDTIME]=@GSmsIdTime,\r\n[GSMSIDTIME2]=@GSmsIdTime2,\r\n[GSMSIDTIME3]=@GSmsIdTime3\r\n        WHERE [CUSTOMERID] = @CustomerId", (object) new
    {
      CustomerId = handover.CustomerId,
      GCallId = handover.GCallId,
      GCallId2 = handover.GCallId2,
      GCallId3 = handover.GCallId3,
      GCallIdTime = handover.GCallIdTime,
      GCallIdTime2 = handover.GCallIdTime2,
      GCallIdTime3 = handover.GCallIdTime3,
      GSmsId = handover.GSmsId,
      GSmsId2 = handover.GSmsId2,
      GSmsId3 = handover.GSmsId3,
      GSmsIdTime = handover.GSmsIdTime,
      GSmsIdTime2 = handover.GSmsIdTime2,
      GSmsIdTime3 = handover.GSmsIdTime3
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }

  public async Task<IEnumerable<HandoverDouble>> GetCustomerOrders(int CustomerId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<HandoverDouble> CustomerOrders = await conn.QueryAsync<HandoverDouble>("SELECT FINANCEID,REGDATE,GROUPGEN2ID,BARCODE,PRICETOTAL,LASTPRICETOTAL,REMAINTOTAL,STURGENT,GIVEN_NOTE,GIVENID,GIVENDATE,FITTINGID,FITTINGDATE from AZSFINANCE WHERE CUSTOMERID=@customerId", (object) new
    {
      customerId = CustomerId
    });
    await conn.CloseAsync();
    IEnumerable<HandoverDouble> customerOrders = CustomerOrders;
    conn = (SqlConnection) null;
    CustomerOrders = (IEnumerable<HandoverDouble>) null;
    return customerOrders;
  }

  public async Task<IEnumerable<Handover>> GetDeptsAsync(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Handover> handovers = await conn.QueryAsync<Handover>("SELECT    C.CUSTOMERID, C.DEPARTID, C.CUSNAME, C.CUSSURNAME, C.CUSFATHERNAME, C.CUSTELNO, C.CUSGSM, C.CUSRELATION,\r\n\r\n\t\t\t\t\t  CASE WHEN C.REMAINTOTALALL = 0 THEN NULL ELSE C.REMAINTOTALALL END AS REMAINTOTALALL, C.GCALLID, C.GCALLIDTIME, C.GCALLID2, C.GCALLIDTIME2,\r\n                      C.GCALLID3, C.GCALLIDTIME3, C.GSMSID, C.GSMSIDTIME, C.GSMSID2, C.GSMSIDTIME2, C.GSMSID3, C.GSMSIDTIME3, C.GCALLNOTE, C.GIVEN_NOTE, C.GLASTTIME, C.FITTINGID,\r\n\r\n\r\n\t\t\t CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) = DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate))\r\n\t\t\t\t\tAND (C.GLASTTIME IS NULL OR DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate)) > DATEADD(dd, 0, DATEDIFF(dd, 0, C.GLASTTIME))) THEN 1\r\n\t\t\t\tELSE CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) <> DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate)) AND\r\n\t\t\t\t((C.GCALLIDTIME IS NULL  OR P.IronDate >=C.GCALLIDTIME) AND (C.GCALLIDTIME2 IS NULL  OR P.IronDate >=C.GCALLIDTIME2)\r\n\t\t\t\t\tAND (C.GCALLIDTIME3 IS NULL  OR P.IronDate >=C.GCALLIDTIME3)\r\n\t\t\t\t\tAND (C.GSMSIDTIME IS NULL  OR P.IronDate >=C.GSMSIDTIME) AND (C.GSMSIDTIME2 IS NULL  OR P.IronDate >=C.GSMSIDTIME2)\r\n\t\t\t\t\tAND (C.GSMSIDTIME3 IS NULL  OR P.IronDate >=C.GSMSIDTIME3) AND (C.GLASTTIME IS NULL  OR P.IronDate >=C.GLASTTIME)) THEN 2\r\n\t\t\t\tELSE CASE WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, C.GLASTTIME)) < DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))-3 OR (C.GLASTTIME IS NULL) THEN 3\r\n\t\t\t\tELSE  CASE WHEN (P.MaxGivenDate >='05/15/2017' AND C.REMAINTOTALALL >0 AND P.GSAY = 0) THEN 1 ELSE 4  END END END END AS ST_Old,\r\n CASE WHEN (P.MaxGivenDate >='05/15/2017' AND C.REMAINTOTALALL >0 AND P.GSAY = 0) THEN 1 ELSE NULL END AS T,\r\n\r\n\r\n\t\tCASE\r\n    WHEN CAST(GETDATE() AS DATE) = CAST(P.IronDate AS DATE)\r\n         AND C.GCALLIDTIME IS NULL\r\n         AND C.GCALLIDTIME2 IS NULL\r\n         AND C.GCALLIDTIME3 IS NULL\r\n         AND C.GSMSIDTIME IS NULL\r\n         AND C.GSMSIDTIME2 IS NULL\r\n         AND C.GSMSIDTIME3 IS NULL THEN 1\r\n    ELSE CASE\r\n        WHEN DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) <> DATEADD(dd, 0, DATEDIFF(dd, 0, P.IronDate))\r\n             AND (C.GCALLIDTIME IS NULL AND C.GCALLIDTIME2 IS NULL\r\n                  AND C.GCALLIDTIME3 IS NULL\r\n                  AND C.GSMSIDTIME IS NULL AND C.GSMSIDTIME2 IS NULL\r\n                  AND C.GSMSIDTIME3 IS NULL AND C.GLASTTIME IS NULL) THEN 2\r\n        ELSE CASE\r\n            WHEN (C.GCALLIDTIME IS NOT NULL OR C.GCALLIDTIME2 IS NOT NULL OR\r\n                  C.GCALLIDTIME3 IS NOT NULL OR C.GSMSIDTIME IS NOT NULL OR\r\n                  C.GSMSIDTIME2 IS NOT NULL OR C.GSMSIDTIME3 IS NOT NULL)\r\n            AND DATEDIFF(dd,\r\n                (SELECT MAX(TimeValue)\r\n                 FROM (VALUES (C.GCALLIDTIME), (C.GCALLIDTIME2),\r\n                              (C.GCALLIDTIME3), (C.GSMSIDTIME),\r\n                              (C.GSMSIDTIME2), (C.GSMSIDTIME3)) AS TimeTable(TimeValue)\r\n                 WHERE TimeValue IS NOT NULL),\r\n                GETDATE()) < 3 THEN 3\r\n            ELSE 4\r\n        END\r\n    END\r\nEND AS ST\r\n\r\n\r\n\r\nFROM         (SELECT CUSTOMERID, MAX(IronDate) AS IronDate, MAX(MaxGivenDate) AS MaxGivenDate, MAX(GSay) AS GSay FROM\r\n\t\t\t\t\t(SELECT     CUSTOMERID, MAX(IRONING_3ROWDATE) AS IronDate, MAX(GIVENDATE) AS MaxGivenDate, sum(case when GIVENDATE is null then 1 else 0 end) GSay\r\n\t\t\t\t\t\t\t\t\t\t\t   FROM          AZSFINANCE\r\n\t\t\t\t\t\t\t\t\t\t\t   WHERE  /*(customerid=21139) and  */ (OPERDATE>='09/01/2014') and (IRONING_3ROWDATE>='09/01/2014') AND (NOT(GROUPGEN2ID in (13001, 13010, 13012,13019, 12000))) AND (IRONING_1=1 OR IRONING_2=1) AND ((GIVENDATE IS NULL OR GIVENDATE > DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))) OR (GIVENDATE >='05/15/2017' AND REMAINTOTALALL >0))\r\n\t\t\t\t\t\t\t\t\t   GROUP BY CUSTOMERID\r\n\t\t\t\t\tUNION ALL\r\n\t\t\t\t\tSELECT     CUSTOMERID, MAX(IRONING_2ROWDATE) AS IronDate, MAX(GIVENDATE) AS MaxGivenDate, sum(case when GIVENDATE is null then 1 else 0 end) GSay\r\n\t\t\t\t\t\t\t\t\t\t\t   FROM          AZSFINANCE\r\n\t\t\t\t\t\t\t\t\t\t\t   WHERE  /*(customerid=21139) and  */   (OPERDATE>='09/01/2014') and (IRONING_2ROWDATE>='09/01/2014') AND (GROUPGEN2ID in (13001, 13010, 13012,13019)) AND ((GIVENDATE IS NULL OR GIVENDATE > DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))) OR (GIVENDATE >='05/15/2017' AND REMAINTOTALALL >0))\r\n\t\t\t\t\t\t\t\t\t\t\t   GROUP BY CUSTOMERID) AS P\r\n\t\t\t\t\tGROUP BY CUSTOMERID) AS P INNER JOIN\r\n\t\t\t\t\t\t  AZSCUSTOMER AS C ON P.CUSTOMERID = C.CUSTOMERID LEFT OUTER JOIN\r\n\t\t\t\t\t\t\t  (SELECT     CUSTOMERID\r\n\t\t\t\t\t\t\t\tFROM          AZSFINANCE AS AZSFINANCE_1\r\n\t\t\t\t\t\t\t\tWHERE   /* (customerid=21139) and */ (OPERDATE>='09/01/2014') and  ((IRONING_2ROWDATE IS NULL) ) AND (GROUPGEN2ID in (13001, 13010, 13012,13019)) GROUP BY CUSTOMERID) AS NP2 ON\r\n\t\t\t\t\t\t  P.CUSTOMERID = NP2.CUSTOMERID LEFT OUTER JOIN\r\n\t\t\t\t\t\t\t  (SELECT     CUSTOMERID\r\n\t\t\t\t\t\t\t\tFROM          AZSFINANCE AS F INNER JOIN\r\n\t\t\t\t\t\t\t\t  LPROGROUPGEN2 AS GG2 ON F.GROUPGEN2ID = GG2.GROUPGEN2ID\r\n\t\t\t\t\t\t\t\tWHERE  /* (customerid=21139) and */ (F.OPERDATE>='09/01/2014') and ((F.IRONING_3ROWDATE IS NULL)) AND (GG2.GROUPGEN1ID = 12) AND (NOT(F.GROUPGEN2ID in (12000))) GROUP BY F.CUSTOMERID) AS NP ON\r\n\t\t\t\t\t\t  P.CUSTOMERID = NP.CUSTOMERID\r\n\tWHERE     (C.DEPARTID LIKE @departId) /*AND (NP.CUSTOMERID IS NULL) AND (NP2.CUSTOMERID IS NULL) --and C.CUSTOMERID = 22779 --1915 --22779*/\r\n--and C.CUSTOMERID in (21106, 7908, 10051) 21139\r\n\tand C.REMAINTOTALALL >0\r\n\tORDER BY  ST, P.IronDate DESC, C.GLASTTIME DESC, C.CUSTOMERID", (object) new
    {
      departId = departmentId
    });
    await conn.CloseAsync();
    IEnumerable<Handover> deptsAsync = handovers;
    conn = (SqlConnection) null;
    handovers = (IEnumerable<Handover>) null;
    return deptsAsync;
  }
}
