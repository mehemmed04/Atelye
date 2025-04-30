// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.EmployeeRepository
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

public class EmployeeRepository(string connectionString) : BaseSqlRepository(connectionString), IEmployeeRepository
{
  public async Task<IEnumerable<Employee>> GetAllEmployees()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Employee> employees = await conn.QueryAsync<Employee>("exec SP_IU_AZSEMPLOYEE default,2");
    await conn.CloseAsync();
    IEnumerable<Employee> allEmployees = employees;
    conn = (SqlConnection) null;
    employees = (IEnumerable<Employee>) null;
    return allEmployees;
  }

  public async Task<IEnumerable<EmployeeByGroup>> GetEmployeesByGroupId(int employeeGroupId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<EmployeeByGroup> employees = await conn.QueryAsync<EmployeeByGroup>("exec SP_IU_AZSEMPLOYEE @id,0", (object) new
    {
      id = employeeGroupId
    });
    await conn.CloseAsync();
    IEnumerable<EmployeeByGroup> employeesByGroupId = employees;
    conn = (SqlConnection) null;
    employees = (IEnumerable<EmployeeByGroup>) null;
    return employeesByGroupId;
  }

  public async Task<IEnumerable<Employee>> GetDebtors()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Employee> employees = await conn.QueryAsync<Employee>("exec SP_IU_AZSEMPLOYEE default,3");
    await conn.CloseAsync();
    IEnumerable<Employee> debtors = employees;
    conn = (SqlConnection) null;
    employees = (IEnumerable<Employee>) null;
    return debtors;
  }
}
