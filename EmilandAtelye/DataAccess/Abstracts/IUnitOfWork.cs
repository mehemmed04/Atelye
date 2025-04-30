// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Abstracts.IUnitOfWork
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.DataAccess.Abstracts;

public interface IUnitOfWork
{
  IUserRepository UserRepository { get; }

  IDepartmentRepository DepartmentRepository { get; }

  IExpenseRepository ExpenseRepository { get; }

  IDebtRepository DebtRepository { get; }

  IDeliveryRepository DeliveryRepository { get; }

  IGroupGen1Repository GroupGen1Repository { get; }

  IGroupGen2Repository GroupGen2Repository { get; }

  ICompanyRepository CompanyRepository { get; }

  IStockRepository StockRepository { get; }

  IIroningRepository IroningRepository { get; }

  IFinanceRepository FinanceRepository { get; }

  ITailorRepository TailorRepository { get; }

  IHandoverRepository HandoverRepository { get; }

  ICurrencyTypeRepository CurrencyTypeRepository { get; }

  ISizeRepository SizeRepository { get; }

  IPriceRepository PriceRepository { get; }

  IModelPhotoRepository ModelPhotoRepository { get; }

  ICashboxRepository CashboxRepository { get; }

  IDailyExpenseRepository DailyExpenseRepository { get; }

  ICustomerRepository CustomerRepository { get; }

  IMeasureUnitRepository MeasureUnitRepository { get; }

  ICountryRepository CountryRepository { get; }

  ICompositionRepository CompositionRepository { get; }

  IEmployeeGroupRepository EmployeeGroupRepository { get; }

  IEmployeeRepository EmployeeRepository { get; }

  IColorRepository ColorRepository { get; }

  IGoodsRepository GoodsRepository { get; }

  ICardsRepository CardsRepository { get; }
}
