// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CompanyRepository
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

internal class CompanyRepository(string connectionString) : BaseSqlRepository(connectionString), ICompanyRepository
{
  public async Task<IEnumerable<Company>> GetAllCompanies()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Company> companies = await conn.QueryAsync<Company>("select * from LAZSCOMPANY");
    await conn.CloseAsync();
    IEnumerable<Company> allCompanies = companies;
    conn = (SqlConnection) null;
    companies = (IEnumerable<Company>) null;
    return allCompanies;
  }
}
