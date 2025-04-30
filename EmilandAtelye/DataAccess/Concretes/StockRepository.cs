// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.StockRepository
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

public class StockRepository(string connectionString) : BaseSqlRepository(connectionString), IStockRepository
{
  public async Task<IEnumerable<GoodsStore>> GetStocks(string companyId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<GoodsStore> stock = await conn.QueryAsync<GoodsStore>("exec [OR].SP_Sel_GoodsStore;1 @id,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,0,0", (object) new
    {
      id = companyId
    });
    await conn.CloseAsync();
    IEnumerable<GoodsStore> stocks = stock;
    conn = (SqlConnection) null;
    stock = (IEnumerable<GoodsStore>) null;
    return stocks;
  }
}
