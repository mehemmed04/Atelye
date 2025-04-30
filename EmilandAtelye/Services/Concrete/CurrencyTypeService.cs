// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.CurrencyTypeService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class CurrencyTypeService(IUnitOfWork unitOfWork) : ICurrencyTypeService
{
  private readonly string currencyCacheKey;
  private IUnitOfWork unitOfWork = unitOfWork;

  public async Task<IEnumerable<CurrencyType>> GetAllCurrencyTypes()
  {
    IEnumerable<CurrencyType> fromCache = CacheService.GetFromCache<IEnumerable<CurrencyType>>(this.currencyCacheKey);
    if (fromCache != null && fromCache.Any<CurrencyType>())
      return fromCache;
    IEnumerable<CurrencyType> allCurrencyTypes = await this.unitOfWork.CurrencyTypeRepository.GetAllCurrencyTypes();
    CacheService.AddToCache(this.currencyCacheKey, (object) allCurrencyTypes, TimeSpan.FromDays(30.0));
    return allCurrencyTypes;
  }

  public Task<CurrencyType> GetCurrencyTypeById(int id) => throw new NotImplementedException();
}
