// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.GroupGen2Repository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class GroupGen2Repository(string connectionString) : BaseSqlRepository(connectionString), IGroupGen2Repository
{
  public async Task<IEnumerable<GroupGen2>> GetAllGroupGen2Async()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<GroupGen2> groupGens = await conn.QueryAsync<GroupGen2>("select * from LPROGROUPGEN2");
    await conn.CloseAsync();
    IEnumerable<GroupGen2> allGroupGen2Async = groupGens;
    conn = (SqlConnection) null;
    groupGens = (IEnumerable<GroupGen2>) null;
    return allGroupGen2Async;
  }

  public async Task<IEnumerable<GroupGen2ForOrder>> GetGroupGen2ForOrdersAsync()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<GroupGen2ForOrder> groupGens = await conn.QueryAsync<GroupGen2ForOrder>("SELECT     GG2.GROUPGEN2ID, GG2.GROUPGEN2NAME, GG2.GROUPGEN2SHORTNAME, GG1.GROUPGEN1NAME, GG1.GROUPGEN1ID,\r\n                      GG2.GROUPGEN2SAMPLEID, GG2.BARCODEYES1NO0\r\n                        FROM         LPROGROUPGEN2 AS GG2 INNER JOIN\r\n                                              LPROGROUPGEN1 AS GG1 ON GG2.GROUPGEN1ID = GG1.GROUPGEN1ID\r\n                        WHERE     (GG1.GROUPGEN1ID IN (12,13,18))\r\n                        ORDER BY GG2.ST");
    await conn.CloseAsync();
    IEnumerable<GroupGen2ForOrder> gen2ForOrdersAsync = groupGens;
    conn = (SqlConnection) null;
    groupGens = (IEnumerable<GroupGen2ForOrder>) null;
    return gen2ForOrdersAsync;
  }

  public async Task<IEnumerable<GroupGen2ByGen1>> GetGroupGen2ByGroupGen1Id(int groupGen1Id)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<GroupGen2ByGen1> groupGen2s = await conn.QueryAsync<GroupGen2ByGen1>("exec SP_LPROGROUPGEN2_SEL;1 @id", (object) new
    {
      id = groupGen1Id
    });
    await conn.CloseAsync();
    IEnumerable<GroupGen2ByGen1> gen2ByGroupGen1Id = groupGen2s;
    conn = (SqlConnection) null;
    groupGen2s = (IEnumerable<GroupGen2ByGen1>) null;
    return gen2ByGroupGen1Id;
  }

  public async Task<string> GetGroupGen2NameByIdAsync(int groupGen2Id)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string groupGen2Name = await conn.QueryFirstOrDefaultAsync<string>("SELECT GROUPGEN2NAME \r\n                      FROM LPROGROUPGEN2 \r\n                        WHERE GROUPGEN2ID = @id", (object) new
    {
      id = groupGen2Id
    });
    await conn.CloseAsync();
    string gen2NameByIdAsync = groupGen2Name;
    conn = (SqlConnection) null;
    groupGen2Name = (string) null;
    return gen2NameByIdAsync;
  }
}
