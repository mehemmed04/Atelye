// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.BaseSqlRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class BaseSqlRepository
{
  private readonly string _connectionString;

  public BaseSqlRepository(string connectionString) => this._connectionString = connectionString;

  public async Task<SqlConnection> OpenSqlConnectionAsync()
  {
    SqlConnection sqlConnection;
    try
    {
      SqlConnection connection = new SqlConnection(this._connectionString);
      await connection.OpenAsync();
      sqlConnection = connection;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      throw new ApplicationException(ex.Message ?? "", ex);
    }
    return sqlConnection;
  }
}
