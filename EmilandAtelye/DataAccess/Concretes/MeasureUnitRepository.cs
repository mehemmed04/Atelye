// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.MeasureUnitRepository
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

public class MeasureUnitRepository(string connectionString) : 
  BaseSqlRepository(connectionString),
  IMeasureUnitRepository
{
  public async Task<IEnumerable<MeasureUnit>> GetAllMeasureUnits()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<MeasureUnit> measureUnits = await conn.QueryAsync<MeasureUnit>("select * from LPROMEASURE");
    await conn.CloseAsync();
    IEnumerable<MeasureUnit> allMeasureUnits = measureUnits;
    conn = (SqlConnection) null;
    measureUnits = (IEnumerable<MeasureUnit>) null;
    return allMeasureUnits;
  }
}
