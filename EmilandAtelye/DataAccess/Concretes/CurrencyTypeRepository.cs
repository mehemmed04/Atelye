// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CurrencyTypeRepository
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

public class CurrencyTypeRepository(string connectionString) : 
  BaseSqlRepository(connectionString),
  ICurrencyTypeRepository
{
  public async Task<IEnumerable<CurrencyType>> GetAllCurrencyTypes()
  {
    await using (SqlConnection conn = await this.OpenSqlConnectionAsync())
      return await conn.QueryAsync<CurrencyType>("select * from LPROCURTYPE");
  }

  public async Task<CurrencyType> GetCurrencyTypeById(int id)
  {
    await using (SqlConnection conn = await this.OpenSqlConnectionAsync())
      return await conn.QueryFirstOrDefaultAsync<CurrencyType>("select * from LPROCURTYPE WHERE CURTYPEID = @typeId", (object) new
      {
        typeId = id
      }) ?? new CurrencyType();
  }
}
