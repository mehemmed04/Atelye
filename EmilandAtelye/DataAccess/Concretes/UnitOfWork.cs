// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.UnitOfWork
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class UnitOfWork : IUnitOfWork
{
  private readonly string _connectionString;

  public UnitOfWork()
  {
    this._connectionString = "Server=46.101.247.22,7000;Initial Catalog=AZSAtelyeY;Integrated Security=false;User=sa;Password=password123;MultipleActiveResultSets=true;TrustServerCertificate=True;";
  }

  public IUserRepository UserRepository
  {
    get => (IUserRepository) new EmilandAtelye.DataAccess.Concretes.UserRepository(this._connectionString);
  }

  public IDepartmentRepository DepartmentRepository
  {
    get => (IDepartmentRepository) new EmilandAtelye.DataAccess.Concretes.DepartmentRepository(this._connectionString);
  }

  public IExpenseRepository ExpenseRepository
  {
    get => (IExpenseRepository) new EmilandAtelye.DataAccess.Concretes.ExpenseRepository(this._connectionString);
  }

  public IDebtRepository DebtRepository
  {
    get => (IDebtRepository) new EmilandAtelye.DataAccess.Concretes.DebtRepository(this._connectionString);
  }

  public IDeliveryRepository DeliveryRepository
  {
    get => (IDeliveryRepository) new EmilandAtelye.DataAccess.Concretes.DeliveryRepository(this._connectionString);
  }

  public IGroupGen2Repository GroupGen2Repository
  {
    get => (IGroupGen2Repository) new EmilandAtelye.DataAccess.Concretes.GroupGen2Repository(this._connectionString);
  }

  public ICompanyRepository CompanyRepository
  {
    get => (ICompanyRepository) new EmilandAtelye.DataAccess.Concretes.CompanyRepository(this._connectionString);
  }

  public IStockRepository StockRepository
  {
    get => (IStockRepository) new EmilandAtelye.DataAccess.Concretes.StockRepository(this._connectionString);
  }

  public IFinanceRepository FinanceRepository
  {
    get => (IFinanceRepository) new EmilandAtelye.DataAccess.Concretes.FinanceRepository(this._connectionString);
  }

  public IIroningRepository IroningRepository
  {
    get => (IIroningRepository) new EmilandAtelye.DataAccess.Concretes.IroningRepository(this._connectionString);
  }

  public ITailorRepository TailorRepository
  {
    get => (ITailorRepository) new EmilandAtelye.DataAccess.Concretes.TailorRepository(this._connectionString);
  }

  public IHandoverRepository HandoverRepository
  {
    get => (IHandoverRepository) new EmilandAtelye.DataAccess.Concretes.HandoverRepository(this._connectionString);
  }

  public ICurrencyTypeRepository CurrencyTypeRepository
  {
    get => (ICurrencyTypeRepository) new EmilandAtelye.DataAccess.Concretes.CurrencyTypeRepository(this._connectionString);
  }

  public IColorRepository ColorRepository
  {
    get => (IColorRepository) new EmilandAtelye.DataAccess.Concretes.ColorRepository(this._connectionString);
  }

  public ISizeRepository SizeRepository
  {
    get => (ISizeRepository) new EmilandAtelye.DataAccess.Concretes.SizeRepository(this._connectionString);
  }

  public IGroupGen1Repository GroupGen1Repository
  {
    get => (IGroupGen1Repository) new EmilandAtelye.DataAccess.Concretes.GroupGen1Repository(this._connectionString);
  }

  public IPriceRepository PriceRepository
  {
    get => (IPriceRepository) new EmilandAtelye.DataAccess.Concretes.PriceRepository(this._connectionString);
  }

  public IModelPhotoRepository ModelPhotoRepository
  {
    get => (IModelPhotoRepository) new EmilandAtelye.DataAccess.Concretes.ModelPhotoRepository(this._connectionString);
  }

  public ICashboxRepository CashboxRepository
  {
    get => (ICashboxRepository) new CashBoxRepository(this._connectionString);
  }

  public IDailyExpenseRepository DailyExpenseRepository
  {
    get => (IDailyExpenseRepository) new EmilandAtelye.DataAccess.Concretes.DailyExpenseRepository(this._connectionString);
  }

  public ICustomerRepository CustomerRepository
  {
    get => (ICustomerRepository) new EmilandAtelye.DataAccess.Concretes.CustomerRepository(this._connectionString);
  }

  public IMeasureUnitRepository MeasureUnitRepository
  {
    get => (IMeasureUnitRepository) new EmilandAtelye.DataAccess.Concretes.MeasureUnitRepository(this._connectionString);
  }

  public ICountryRepository CountryRepository
  {
    get => (ICountryRepository) new EmilandAtelye.DataAccess.Concretes.CountryRepository(this._connectionString);
  }

  public ICompositionRepository CompositionRepository
  {
    get => (ICompositionRepository) new EmilandAtelye.DataAccess.Concretes.CompositionRepository(this._connectionString);
  }

  public IEmployeeGroupRepository EmployeeGroupRepository
  {
    get => (IEmployeeGroupRepository) new EmilandAtelye.DataAccess.Concretes.EmployeeGroupRepository(this._connectionString);
  }

  public IEmployeeRepository EmployeeRepository
  {
    get => (IEmployeeRepository) new EmilandAtelye.DataAccess.Concretes.EmployeeRepository(this._connectionString);
  }

  public IGoodsRepository GoodsRepository
  {
    get => (IGoodsRepository) new EmilandAtelye.DataAccess.Concretes.GoodsRepository(this._connectionString);
  }

  public ICardsRepository CardsRepository
  {
    get => (ICardsRepository) new EmilandAtelye.DataAccess.Concretes.CardsRepository(this._connectionString);
  }
}
