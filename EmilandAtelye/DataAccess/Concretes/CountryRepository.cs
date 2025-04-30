// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CountryRepository
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

public class CountryRepository(string connectionString) : BaseSqlRepository(connectionString), ICountryRepository
{
  public async Task<IEnumerable<Country>> GetAllCountries()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Country> countries = await conn.QueryAsync<Country>("select * from LPROCOUNTRY");
    await conn.CloseAsync();
    IEnumerable<Country> allCountries = countries;
    conn = (SqlConnection) null;
    countries = (IEnumerable<Country>) null;
    return allCountries;
  }
}
