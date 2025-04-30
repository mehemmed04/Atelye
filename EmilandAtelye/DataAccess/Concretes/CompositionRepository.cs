// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CompositionRepository
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

public class CompositionRepository(string connectionString) : 
  BaseSqlRepository(connectionString),
  ICompositionRepository
{
  public async Task<IEnumerable<Composition>> GetAllCompositions()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Composition> compositions = await conn.QueryAsync<Composition>("exec SP_IU_LAGCOMPOSITION");
    await conn.CloseAsync();
    IEnumerable<Composition> allCompositions = compositions;
    conn = (SqlConnection) null;
    compositions = (IEnumerable<Composition>) null;
    return allCompositions;
  }
}
