// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.ColorRepository
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

public class ColorRepository(string connectionString) : BaseSqlRepository(connectionString), IColorRepository
{
  public async Task<IEnumerable<Color>> GetAllColors()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Color> colors = await conn.QueryAsync<Color>("select * from LAZSCOLOR");
    await conn.CloseAsync();
    IEnumerable<Color> allColors = colors;
    conn = (SqlConnection) null;
    colors = (IEnumerable<Color>) null;
    return allColors;
  }

  public async Task<IEnumerable<ColorByGroupGen2>> GetColorsByGroupGen2IdsAsync(
    List<int> groupGen2Ids)
  {
    IEnumerable<ColorByGroupGen2> groupGen2IdsAsync;
    using (SqlConnection conn = await this.OpenSqlConnectionAsync())
    {
      string sql = "\r\n                            SELECT COLORID, COLORNAME, GROUPGEN2ID, COLORROW\r\n                            FROM LAZSCOLOR\r\n                            WHERE GROUPGEN2ID IN @Ids\r\n                            ORDER BY COLORROW";
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@Ids", (object) groupGen2Ids);
      groupGen2IdsAsync = await conn.QueryAsync<ColorByGroupGen2>(sql, (object) dynamicParameters);
    }
    return groupGen2IdsAsync;
  }
}
