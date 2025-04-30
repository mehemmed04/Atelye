// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.SizeRepository
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

public class SizeRepository(string connectionString) : BaseSqlRepository(connectionString), ISizeRepository
{
  public async Task<IEnumerable<SizeModel>> GetAllSizes()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<SizeModel> sizes = await conn.QueryAsync<SizeModel>("select * from LAZSSIZE");
    await conn.CloseAsync();
    IEnumerable<SizeModel> allSizes = sizes;
    conn = (SqlConnection) null;
    sizes = (IEnumerable<SizeModel>) null;
    return allSizes;
  }

  public async Task<IEnumerable<SizeByGroupGen2>> GetSizeByGroupGen2Id(int groupGen2Id)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<SizeByGroupGen2> sizes = await conn.QueryAsync<SizeByGroupGen2>("SELECT SIZEID, SIZE, GROUPGEN2ID, SIZEROW\r\n                FROM LAZSSIZE  WHERE (GROUPGEN2ID = @id)  ORDER BY SIZEROW", (object) new
    {
      id = groupGen2Id
    });
    await conn.CloseAsync();
    IEnumerable<SizeByGroupGen2> sizeByGroupGen2Id = sizes;
    conn = (SqlConnection) null;
    sizes = (IEnumerable<SizeByGroupGen2>) null;
    return sizeByGroupGen2Id;
  }

  public async Task<IEnumerable<SizeByGroupGen2>> GetSizesByGroupGen2IdsAsync(List<int> groupGen2Ids)
  {
    IEnumerable<SizeByGroupGen2> groupGen2IdsAsync;
    using (SqlConnection conn = await this.OpenSqlConnectionAsync())
    {
      string sql = "\r\n                            SELECT SizeId, SIZE, GroupGen2Id, SizeRow\r\n                            FROM LAZSSIZE\r\n                            WHERE GroupGen2Id IN @Ids\r\n                            ORDER BY SizeRow";
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@Ids", (object) groupGen2Ids);
      groupGen2IdsAsync = await conn.QueryAsync<SizeByGroupGen2>(sql, (object) dynamicParameters);
    }
    return groupGen2IdsAsync;
  }
}
