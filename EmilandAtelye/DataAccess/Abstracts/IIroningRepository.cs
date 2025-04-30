// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Abstracts.IIroningRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Abstracts;

public interface IIroningRepository
{
  Task<IEnumerable<IroningDaily>> GetIroningDaily(DateTime date);

  Task<IEnumerable<Ironing1>> GetIroning1Detail(DateTime date);

  Task<IEnumerable<Ironing1>> GetIroning1NextDetail(DateTime date);

  Task<CustomerIroningDetail> GetCustomerIroningDetail(int customerId);

  Task<IEnumerable<Ironing2>> GetIroning2Detail(DateTime date);

  Task<IEnumerable<Ironing2>> GetIroning2NextDetail(DateTime date);

  Task Planlama(int financeId);

  Task Kesim(int financeId);

  Task Hazir1ci(int financeId);

  Task SonYoxlama(int financeId);

  Task Hazir2ci(int financeId);
}
