// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.DailyExpenseRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class DailyExpenseRepository(string connectionString) : 
  BaseSqlRepository(connectionString),
  IDailyExpenseRepository
{
  public async Task<IEnumerable<DailyExpense>> GetDailyExpenseInCashBoxAsync(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<DailyExpense> expenses = await conn.QueryAsync<DailyExpense>("SELECT DAILYEXPENSEID, DEPARTID, EXPENSEID, EXPENSENAME, OPERDATE, OPERSUMDOLLAR, OPERSUMAZN, OPERSUMAZNBREF, STCASH,\r\n\t\t\t\t\t\t  OPERSUMUSDBREF, STOPERSUM\r\n\tFROM         AZSDAILYEXPENSE\r\n\tWHERE    (STCASH = 1) AND OPERDATE >= @date AND OPERDATE < DATEADD(day, 1, @date)\r\n\tORDER BY STOPERSUM desc, DEPARTID, DAILYEXPENSEID", (object) new
    {
      date = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<DailyExpense> expenseInCashBoxAsync = expenses;
    conn = (SqlConnection) null;
    expenses = (IEnumerable<DailyExpense>) null;
    return expenseInCashBoxAsync;
  }

  public async Task<int> InsertDailyExpenseAsync(DailyExpense dailyExpense)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num;
    try
    {
      int result = await conn.ExecuteAsync("INSERT INTO AZSDAILYEXPENSE (DEPARTID, EXPENSEID, EXPENSENAME, OPERDATE, OPERSUMAZN,STCASH)\r\n        VALUES (@DepartId, @ExpenseId, @ExpenseName, @OperDate, @OperSumAzn ,@StCash);", (object) new
      {
        DepartId = dailyExpense.DepartId,
        ExpenseId = dailyExpense.ExpenseId,
        ExpenseName = dailyExpense.ExpenseName,
        OperDate = dailyExpense.OperDate,
        OperSumAzn = dailyExpense.OperSumAzn,
        StCash = dailyExpense.StCash
      });
      await conn.CloseAsync();
      num = result;
    }
    catch (Exception ex)
    {
      throw;
    }
    conn = (SqlConnection) null;
    return num;
  }

  public async Task<string> GetExpenseIdByNameAsync(string expenseName)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string expenseid = await conn.QueryFirstOrDefaultAsync<string>("SELECT EXPENSEID FROM LPROEXPENSE WHERE  EXPENSENAME=@expensename", (object) new
    {
      expensename = expenseName
    });
    await conn.CloseAsync();
    string expenseIdByNameAsync = expenseid;
    conn = (SqlConnection) null;
    expenseid = (string) null;
    return expenseIdByNameAsync;
  }

  public async Task<IEnumerable<DailyExpense>> GetDailyExpenseInCashBoxMIAsync(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<DailyExpense> expenses = await conn.QueryAsync<DailyExpense>("SELECT DAILYEXPENSEID, DEPARTID, EXPENSEID, EXPENSENAME, OPERDATE, OPERSUMDOLLAR, OPERSUMAZN, OPERSUMAZNBREF, STCASH,\r\n\t\t\t\t\t\t  OPERSUMUSDBREF, STOPERSUM\r\n\t            FROM         AZSDAILYEXPENSE\r\n\t            WHERE    (STCASH = 2) and (OPERDATE = @date)\r\n\t            ORDER BY STOPERSUM desc, DEPARTID, DAILYEXPENSEID", (object) new
    {
      date = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    IEnumerable<DailyExpense> inCashBoxMiAsync = expenses;
    conn = (SqlConnection) null;
    expenses = (IEnumerable<DailyExpense>) null;
    return inCashBoxMiAsync;
  }

  public async Task<List<string>> GetExpenseNamesAsync()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<string> expenseNames = await conn.QueryAsync<string>("SELECT EXPENSENAME FROM LPROEXPENSE");
    await conn.CloseAsync();
    List<string> list = expenseNames.ToList<string>();
    conn = (SqlConnection) null;
    expenseNames = (IEnumerable<string>) null;
    return list;
  }

  public async Task<int> AddExpenseAsync(LproExpense expense)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int result = await conn.ExecuteAsync("INSERT INTO LPROEXPENSE \r\n    (EXPENSEID, DEPARTID, REGDATE, REGUID, EDITDATE, EDITUID, EXPENSENAME, STATUS, aa, BEX) \r\n    VALUES (@ExpenseId, @DepartId, @RegDate, @RegUid, @EditDate, @EditUid, @ExpenseName, @Status, @Aa, @Bex);", (object) new
    {
      ExpenseId = expense.EXPENSEID,
      DepartId = expense.DEPARTID,
      RegDate = expense.REGDATE,
      RegUid = expense.REGUID,
      EditDate = expense.EDITDATE,
      EditUid = expense.EDITUID,
      ExpenseName = expense.EXPENSENAME,
      Status = expense.STATUS,
      Aa = expense.aa,
      Bex = expense.BEX
    });
    await conn.CloseAsync();
    int num = result;
    conn = (SqlConnection) null;
    return num;
  }

  public async Task<string> GetMaxExpenseIdAsync()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    string maxExpenseId = await conn.QueryFirstAsync<string>("SELECT MAX(EXPENSEID) FROM LPROEXPENSE");
    await conn.CloseAsync();
    string maxExpenseIdAsync = maxExpenseId;
    conn = (SqlConnection) null;
    maxExpenseId = (string) null;
    return maxExpenseIdAsync;
  }

  public async Task<List<string>> GetFilteredExpensesNames(string expenseName)
  {
    List<string> list;
    using (SqlConnection conn = await this.OpenSqlConnectionAsync())
      list = (await conn.QueryAsync<string>("SELECT EXPENSENAME FROM LPROEXPENSE WHERE EXPENSENAME LIKE @ExpenseName", (object) new
      {
        ExpenseName = (expenseName + "%")
      })).ToList<string>();
    return list;
  }
}
