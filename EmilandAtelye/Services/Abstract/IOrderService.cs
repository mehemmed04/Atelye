// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Abstract.IOrderService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Services.Concrete;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Abstract;

public interface IOrderService
{
  Task<OrderDto> GetCustomerOrders(int departmentId);
}
