// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.UserRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class UserRepository(string connectionString) : BaseSqlRepository(connectionString), IUserRepository
{
  public async Task<User?> GetUserByNameAsync(string name)
  {
    SqlConnection connection = await this.OpenSqlConnectionAsync();
    User user = await connection.QueryFirstOrDefaultAsync<User>("SELECT USERNAME As UserName, USERCODE As UserCode, IDLE_TIME As IdleTime, INT_PSW_NEED As PassNeed  FROM AG_USERS WHERE USERNAME = @Name", (object) new
    {
      Name = name
    });
    await connection.CloseAsync();
    User userByNameAsync = user;
    connection = (SqlConnection) null;
    user = (User) null;
    return userByNameAsync;
  }
}
