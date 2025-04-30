// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.GroupGen1Repository
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

public class GroupGen1Repository(string connectionString) : BaseSqlRepository(connectionString), IGroupGen1Repository
{
  public async Task<IEnumerable<GroupGen1>> GetAllGroupGen1s()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<GroupGen1> groupGens = await conn.QueryAsync<GroupGen1>("select * from LPROGROUPGEN1");
    await conn.CloseAsync();
    IEnumerable<GroupGen1> allGroupGen1s = groupGens;
    conn = (SqlConnection) null;
    groupGens = (IEnumerable<GroupGen1>) null;
    return allGroupGen1s;
  }
}
