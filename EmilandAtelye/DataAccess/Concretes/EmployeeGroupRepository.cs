// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.EmployeeGroupRepository
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

public class EmployeeGroupRepository(string connectionString) : 
  BaseSqlRepository(connectionString),
  IEmployeeGroupRepository
{
  public async Task<IEnumerable<EmployeeGroup>> GetAllEmployeeGroups()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<EmployeeGroup> employeeGroups = await conn.QueryAsync<EmployeeGroup>("exec SP_IU_AZSEMPLOYEEGROUP");
    await conn.CloseAsync();
    IEnumerable<EmployeeGroup> allEmployeeGroups = employeeGroups;
    conn = (SqlConnection) null;
    employeeGroups = (IEnumerable<EmployeeGroup>) null;
    return allEmployeeGroups;
  }
}
