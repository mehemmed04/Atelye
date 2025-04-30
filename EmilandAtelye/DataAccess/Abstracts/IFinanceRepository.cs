// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Abstracts.IFinanceRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using EmilandAtelye.DTOs.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Abstracts;

public interface IFinanceRepository
{
  Task<int?> GetFinanceUrgentStatus(int financeId);

  Task<IEnumerable<CustomersSummary>> GetCustomersSummaryDailyAsync(int departId);

  Task<CustomersSummaryTotal> GetCustomersSummaryDailyTotalAsync(int departId);

  Task<IEnumerable<Finance>> GetFinanceForOrderAsync(int departId, int customerId);

  Task<IEnumerable<Finance>> GetFinanceForOrderTodayAsync(int departId, int customerId);

  Task<IEnumerable<CustomerTotalFinance>> GetFinanceForDepositTodayAsync(
    int departId,
    int customerId);

  Task<IEnumerable<CustomerTotalFinance>> GetFinanceForDepositAsync(int departId, int customerId);

  Task<IEnumerable<CustomersSummary>> GetCustomersSummaryAsync(int departId);

  Task<IEnumerable<CustomersSummary>> GetFilteredCustomersSummaryAsync(
    int departmentId,
    string customerId,
    string name = "",
    string surname = "");

  Task<IEnumerable<CustomersSummary>> GetCustomersSummaryWithPaginationAsync(
    int departId,
    int page,
    int size);

  Task<int> GetCustomersSummaryCountAsync(int departId);

  Task<CustomersSummaryTotal> GetCustomersSummaryTotalAsync(int departId);

  Task<IEnumerable<DailyTransactionsSummary>> GetDailyTransactionsSummaryAsync(int departId);

  Task<bool> AddFinanceAsync(AddUpdateFinanceRequest request);

  Task<bool> UpdateFinanceAsync(int financeId, AddUpdateFinanceRequest request);
}
