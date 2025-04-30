// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Abstracts.IDailyExpenseRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Abstracts;

public interface IDailyExpenseRepository
{
  Task<IEnumerable<DailyExpense>> GetDailyExpenseInCashBoxAsync(DateTime date);

  Task<IEnumerable<DailyExpense>> GetDailyExpenseInCashBoxMIAsync(DateTime date);

  Task<int> InsertDailyExpenseAsync(DailyExpense dailyExpense);

  Task<List<string>> GetExpenseNamesAsync();

  Task<List<string>> GetFilteredExpensesNames(string expenseName);

  Task<string?> GetExpenseIdByNameAsync(string expenseName);

  Task<int> AddExpenseAsync(LproExpense expense);

  Task<string> GetMaxExpenseIdAsync();
}
