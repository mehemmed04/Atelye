// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.ExpenseRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class ExpenseRepository(string connectionString) : BaseSqlRepository(connectionString), IExpenseRepository
{
  public async Task<IEnumerable<Expense>> GetAllExpenses(DateTime BeginDate, DateTime EndDate)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Expense> expenses = await conn.QueryAsync<Expense>("EXEC [SP_SEL_EXPENSE] @BeginD, @EndD, @PARAM", (object) new
    {
      BeginD = BeginDate.ToString("MM/dd/yyyy"),
      EndD = EndDate.ToString("MM/dd/yyyy"),
      PARAM = 1
    });
    await conn.CloseAsync();
    IEnumerable<Expense> allExpenses = expenses;
    conn = (SqlConnection) null;
    expenses = (IEnumerable<Expense>) null;
    return allExpenses;
  }

  public async Task<IEnumerable<Expense>> GetAllExpensesMI(DateTime BeginDate, DateTime EndDate)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Expense> expenses = await conn.QueryAsync<Expense>("EXEC [SP_SEL_EXPENSE] @BeginD, @EndD, @PARAM", (object) new
    {
      BeginD = BeginDate.ToString("MM/dd/yyyy"),
      EndD = EndDate.ToString("MM/dd/yyyy"),
      PARAM = 3
    });
    await conn.CloseAsync();
    IEnumerable<Expense> allExpensesMi = expenses;
    conn = (SqlConnection) null;
    expenses = (IEnumerable<Expense>) null;
    return allExpensesMi;
  }

  public async Task<int> GetLastExpenseID()
  {
    await using (SqlConnection connection = await this.OpenSqlConnectionAsync())
      return await connection.QueryFirstOrDefaultAsync<int>("SELECT ISNULL(MAX(ExpenseID), 0) FROM LPROEXPENSE");
  }

  public async Task<ExpenseInsert> CreateExpenses(ExpenseInsert expenseInsert)
  {
    ExpenseRepository expenseRepository = this;
    await using (SqlConnection connection = await expenseRepository.OpenSqlConnectionAsync())
    {
      expenseInsert.ExpenseID = (await expenseRepository.GetLastExpenseID() + 1).ToString("D4");
      return await connection.ExecuteAsync("INSERT INTO LPROEXPENSE (EXPENSEID , DEPARTID, REGDATE, REGUID, EDITDATE, EDITUID, EXPENSENAME, STATUS, aa, BEX) VALUES (@EXPENSEID, @DEPARTID, @REGDATE, @REGUID, @EDITDATE, @EDITUID, @EXPENSENAME, @STATUS, @aa, @BEX);", (object) new
      {
        ExpenseID = expenseInsert.ExpenseID,
        DEPARTID = expenseInsert.DEPARTID,
        REGDATE = expenseInsert.REGDATE,
        REGUID = expenseInsert.REGUID,
        EDITDATE = ((object) expenseInsert.EDITDATE ?? (object) DBNull.Value),
        EDITUID = expenseInsert.EDITUID,
        EXPENSENAME = expenseInsert.EXPENSENAME,
        STATUS = expenseInsert.STATUS,
        aa = expenseInsert.aa,
        BEX = expenseInsert.BEX
      }) != 0 ? expenseInsert : new ExpenseInsert();
    }
  }
}
