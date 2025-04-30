// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.OrderService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Services.Abstract;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class OrderService(IUnitOfWork UnitOfWork) : IOrderService
{
  public async Task<OrderDto> GetCustomerOrders(int departmentId)
  {
    OrderDto orderDto = new OrderDto();
    if (CurrentValues.CurrentUser?.UserName == "admin")
    {
      orderDto.BaseLeftOrders = await UnitOfWork.FinanceRepository.GetCustomersSummaryAsync(departmentId);
      CustomersSummaryTotal summaryTotalAsync = await UnitOfWork.FinanceRepository.GetCustomersSummaryTotalAsync(departmentId);
      orderDto.LeftUsdAll = summaryTotalAsync.SumPayUSD;
      orderDto.LeftAznAll = summaryTotalAsync.SumPayAZN;
      orderDto.LeftEuroAll = summaryTotalAsync.SumPayEUR;
      orderDto.LeftRubAll = summaryTotalAsync.SumPayRUB;
      orderDto.LeftDebtAll = summaryTotalAsync.SumRemainTotalAll;
    }
    else
    {
      orderDto.BaseLeftOrders = await UnitOfWork.FinanceRepository.GetCustomersSummaryDailyAsync(departmentId);
      CustomersSummaryTotal summaryDailyTotalAsync = await UnitOfWork.FinanceRepository.GetCustomersSummaryDailyTotalAsync(departmentId);
      orderDto.LeftUsdAll = summaryDailyTotalAsync.SumPayUSD;
      orderDto.LeftAznAll = summaryDailyTotalAsync.SumPayAZN;
      orderDto.LeftEuroAll = summaryDailyTotalAsync.SumPayEUR;
      orderDto.LeftRubAll = summaryDailyTotalAsync.SumPayRUB;
      orderDto.LeftDebtAll = summaryDailyTotalAsync.SumRemainTotalAll;
    }
    OrderDto customerOrders = orderDto;
    orderDto = (OrderDto) null;
    return customerOrders;
  }
}
