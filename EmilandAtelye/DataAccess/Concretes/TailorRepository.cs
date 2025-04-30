// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.TailorRepository
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

public class TailorRepository(string connectionString) : BaseSqlRepository(connectionString), ITailorRepository
{
  public async Task<IEnumerable<Tailor>> GetTailors(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Tailor> tailors = await conn.QueryAsync<Tailor>("SELECT TAILORID, TAILORSHORTNAME, TAILORFULLNAME FROM AZSTAILOR\r\n            WHERE DEPARTID = @id\r\n            ORDER BY DEPARTID, REGDATE", (object) new
    {
      id = departmentId
    });
    await conn.CloseAsync();
    IEnumerable<Tailor> tailors1 = tailors;
    conn = (SqlConnection) null;
    tailors = (IEnumerable<Tailor>) null;
    return tailors1;
  }
}
