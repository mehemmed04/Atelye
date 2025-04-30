// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.PriceRepository
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

public class PriceRepository(string connectionString) : BaseSqlRepository(connectionString), IPriceRepository
{
  public async Task<IEnumerable<Price>> GetPrices()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Price> prices = await conn.QueryAsync<Price>("exec [OR].SP_IU_AZSPRICE 1");
    await conn.CloseAsync();
    IEnumerable<Price> prices1 = prices;
    conn = (SqlConnection) null;
    prices = (IEnumerable<Price>) null;
    return prices1;
  }

  public async Task<IEnumerable<Price2>> GetAllPrices()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Price2> prices = await conn.QueryAsync<Price2>("exec [OR].SP_IU_AZSPRICE");
    await conn.CloseAsync();
    IEnumerable<Price2> allPrices = prices;
    conn = (SqlConnection) null;
    prices = (IEnumerable<Price2>) null;
    return allPrices;
  }
}
