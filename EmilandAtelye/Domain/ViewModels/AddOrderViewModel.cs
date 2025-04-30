// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.AddOrderViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.DTOs;
using EmilandAtelye.DTOs.Requests;
using EmilandAtelye.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class AddOrderViewModel : BaseViewModel
{
  private string customerId;
  private FinanceDto selectedFinanceDto;
  private string customerName;
  private string barCode;
  private GroupGen2ForOrder selectedType;
  private string customerSurname;
  private Decimal? price;
  private string note;
  private float? lastPrice;
  private string customerGsm;
  private float? beh;
  private string customerTel;
  private bool _isChecked;
  private DateTime deliverDate;
  private Tailor selectedTypeForMeasurment;
  private CurrencyType selectedCurrency;
  private ObservableCollection<GroupGen2ForOrder> types;
  private ObservableCollection<Tailor> tailors;
  private ObservableCollection<CurrencyType> currencies;

  public Window CurrentWindow { get; set; }

  public bool IsSearchPage { get; set; }

  public IEnumerable<Customer> Customers { get; set; }

  public int DepartmentId { get; set; }

  private IUnitOfWork _unitOfWork { get; set; }

  private ICurrencyTypeService currencyTypeService { get; set; }

  public RelayCommand SaveButtonCommand { get; set; }

  public FinanceDto SelectedFinanceDto
  {
    get => this.selectedFinanceDto;
    set
    {
      this.selectedFinanceDto = value;
      this.OnPropertyChanged(nameof (SelectedFinanceDto));
    }
  }

  public string CustomerId
  {
    get => this.customerId;
    set
    {
      this.customerId = value;
      this.OnPropertyChanged(nameof (CustomerId));
      this.GetCustomer();
    }
  }

  public string CustomerName
  {
    get => this.customerName;
    set
    {
      this.customerName = value;
      this.OnPropertyChanged(nameof (CustomerName));
    }
  }

  public string BarCode
  {
    get => this.barCode;
    set
    {
      this.barCode = value;
      this.OnPropertyChanged(nameof (BarCode));
      this.GetPricesByBarCode();
    }
  }

  private async Task GetPricesByBarCode()
  {
    AddOrderViewModel addOrderViewModel1 = this;
    Goods goodsByBarCode = await addOrderViewModel1._unitOfWork.GoodsRepository.GetGoodsByBarCode(addOrderViewModel1.BarCode);
    if (goodsByBarCode == null)
      return;
    addOrderViewModel1.Price = goodsByBarCode.SuiteSp;
    AddOrderViewModel addOrderViewModel2 = addOrderViewModel1;
    Decimal? suiteSp = goodsByBarCode.SuiteSp;
    float? nullable = suiteSp.HasValue ? new float?((float) suiteSp.GetValueOrDefault()) : new float?();
    addOrderViewModel2.LastPrice = nullable;
  }

  public GroupGen2ForOrder SelectedType
  {
    get => this.selectedType;
    set
    {
      this.selectedType = value;
      this.OnPropertyChanged(nameof (SelectedType));
    }
  }

  public string CustomerSurname
  {
    get => this.customerSurname;
    set
    {
      this.customerSurname = value;
      this.OnPropertyChanged(nameof (CustomerSurname));
    }
  }

  public Decimal? Price
  {
    get => this.price;
    set
    {
      this.price = value;
      this.OnPropertyChanged(nameof (Price));
    }
  }

  public string Note
  {
    get => this.note;
    set
    {
      this.note = value;
      this.OnPropertyChanged(nameof (Note));
    }
  }

  public float? LastPrice
  {
    get => this.lastPrice;
    set
    {
      this.lastPrice = value;
      this.OnPropertyChanged(nameof (LastPrice));
    }
  }

  public string CustomerGsm
  {
    get => this.customerGsm;
    set
    {
      this.customerGsm = value;
      this.OnPropertyChanged(nameof (CustomerGsm));
    }
  }

  public float? Beh
  {
    get => this.beh;
    set
    {
      this.beh = value;
      this.OnPropertyChanged(nameof (Beh));
    }
  }

  public string CustomerTel
  {
    get => this.customerTel;
    set
    {
      this.customerTel = value;
      this.OnPropertyChanged(nameof (CustomerTel));
    }
  }

  public bool IsChecked
  {
    get => this._isChecked;
    set
    {
      if (this._isChecked == value)
        return;
      this._isChecked = value;
      this.OnPropertyChanged(nameof (IsChecked));
    }
  }

  public DateTime DeliveryDate
  {
    get => this.deliverDate;
    set
    {
      this.deliverDate = value;
      this.OnPropertyChanged(nameof (DeliveryDate));
    }
  }

  public Tailor SelectedTypeForMeasurment
  {
    get => this.selectedTypeForMeasurment;
    set
    {
      this.selectedTypeForMeasurment = value;
      this.OnPropertyChanged(nameof (SelectedTypeForMeasurment));
    }
  }

  public CurrencyType SelectedCurrency
  {
    get => this.selectedCurrency;
    set
    {
      this.selectedCurrency = value;
      this.OnPropertyChanged(nameof (SelectedCurrency));
    }
  }

  public ObservableCollection<GroupGen2ForOrder> Types
  {
    get => this.types;
    set
    {
      this.types = value;
      this.OnPropertyChanged(nameof (Types));
    }
  }

  public ObservableCollection<Tailor> Tailors
  {
    get => this.tailors;
    set
    {
      this.tailors = value;
      this.OnPropertyChanged(nameof (Tailors));
    }
  }

  public ObservableCollection<CurrencyType> Currencies
  {
    get => this.currencies;
    set
    {
      this.currencies = value;
      this.OnPropertyChanged(nameof (Currencies));
    }
  }

  public AddOrderViewModel(
    IUnitOfWork unitOfWork,
    Window currentWindow,
    int departmentId,
    ICurrencyTypeService currencyTypeService,
    FinanceDto selectedFinanceDto,
    bool IsSearchPage)
  {
    this.SelectedFinanceDto = selectedFinanceDto;
    this.LoadUpdateView();
    this._unitOfWork = unitOfWork;
    this.LoadCustomers();
    this.SaveButtonCommand = new RelayCommand((Action<object>) (async param => await this.AddOrder(param)));
    this.LoadComboBoxes();
    this.DeliveryDate = DateTime.Now;
    this.DepartmentId = departmentId;
    this.CurrentWindow = currentWindow;
    this.currencyTypeService = currencyTypeService;
  }

  private async Task GetCustomer()
  {
    Customer customerById = await this._unitOfWork.CustomerRepository.GetCustomerById(this.CustomerId, this.DepartmentId);
    if (customerById == null)
      return;
    this.CustomerName = customerById.CusName;
    this.CustomerSurname = customerById.CusSurname;
    this.CustomerTel = customerById.CusTelNo;
    this.CustomerGsm = customerById.CusGsm;
    this.Note = customerById.CusFatherName;
  }

  public async Task LoadCustomers()
  {
    this.Customers = await this._unitOfWork.CustomerRepository.GetAllCustomersForDeparts(this.DepartmentId);
  }

  public async Task LoadComboBoxes()
  {
    this.Types = new ObservableCollection<GroupGen2ForOrder>(await this._unitOfWork.GroupGen2Repository.GetGroupGen2ForOrdersAsync());
    this.Tailors = new ObservableCollection<Tailor>(await this._unitOfWork.TailorRepository.GetTailors(this.DepartmentId));
    IEnumerable<CurrencyType> allCurrencyTypes = await this.currencyTypeService.GetAllCurrencyTypes();
    this.Currencies = new ObservableCollection<CurrencyType>(allCurrencyTypes);
    this.SelectedCurrency = (allCurrencyTypes != null ? allCurrencyTypes.FirstOrDefault<CurrencyType>() : (CurrencyType) null) ?? new CurrencyType();
  }

  public async Task<bool> AddCustomer()
  {
    return await this._unitOfWork.CustomerRepository.InsertCustomer(new CustomerInsert()
    {
      CustomerId = int.Parse(this.CustomerId),
      RegDate = new DateTime?(DateTime.Now),
      RegGuid = CurrentValues.CurrentUser.UserName,
      EditDate = new DateTime?(),
      EditUid = (string) null,
      DepartId = new int?(this.DepartmentId),
      CusName = this.CustomerName,
      CusSurname = this.CustomerSurname,
      CusFatherName = this.Note,
      CusTelNo = this.CustomerTel,
      CusGsm = this.CustomerGsm,
      CusRelation = (string) null,
      RemainTotalAll = new Decimal?(0M),
      CallId = new byte?((byte) 0),
      CallId2 = new byte?((byte) 0),
      CallId3 = new byte?((byte) 0),
      CallIdTime = new DateTime?(),
      CallIdTime2 = new DateTime?(),
      CallIdTime3 = new DateTime?(),
      SmsId = new byte?((byte) 0),
      SmsId2 = new byte?(),
      SmsId3 = new byte?((byte) 0),
      SmsIdTime = new DateTime?(),
      SmsIdTime2 = new DateTime?(),
      SmsIdTime3 = new DateTime?(),
      CallNote = (string) null,
      LastTime = new DateTime?(),
      GCallId = new byte?((byte) 0),
      GCallId2 = new byte?((byte) 0),
      GCallId3 = new byte?((byte) 0),
      GCallIdTime = new DateTime?(),
      GCallIdTime2 = new DateTime?(),
      GCallIdTime3 = new DateTime?(),
      GCallNote = (string) null,
      FittingId = new byte?(),
      Given_Note = (string) null,
      GLastTime = new DateTime?(),
      GSmsId = new byte?((byte) 0),
      GSmsId2 = new byte?((byte) 0),
      GSmsId3 = new byte?((byte) 0),
      GSmsIdTime = new DateTime?(),
      GSmsIdTime2 = new DateTime?(),
      GSmsIdTime3 = new DateTime?()
    });
  }

  public async Task AddOrder(object parametr)
  {
    AddOrderViewModel addOrderViewModel1 = this;
    AddUpdateFinanceRequest order;
    if (addOrderViewModel1.SelectedCurrency == null)
    {
      int num = (int) MessageBox.Show("Valyuta tipini seçin");
      order = (AddUpdateFinanceRequest) null;
    }
    else
    {
      byte urgent = 0;
      if (addOrderViewModel1.IsChecked)
        urgent = (byte) 1;
      int num1;
      if (addOrderViewModel1.CustomerId.IsNullOrEmpty<char>())
      {
        int maxCustomerId = await addOrderViewModel1._unitOfWork.CustomerRepository.GetMaxCustomerId();
        AddOrderViewModel addOrderViewModel2 = addOrderViewModel1;
        int num2;
        num1 = num2 = maxCustomerId + 1;
        string str = num1.ToString();
        addOrderViewModel2.CustomerId = str;
        if (!await addOrderViewModel1.AddCustomer())
        {
          int num3 = (int) MessageBox.Show("Müştəri əlavə oluna bilmədi");
        }
      }
      float? beh1 = addOrderViewModel1.Beh;
      AddUpdateFinanceRequest updateFinanceRequest = new AddUpdateFinanceRequest();
      updateFinanceRequest.CustomerId = new int?(int.Parse(addOrderViewModel1.CustomerId));
      updateFinanceRequest.CusName = addOrderViewModel1.CustomerName;
      updateFinanceRequest.CusGsm = addOrderViewModel1.CustomerGsm;
      updateFinanceRequest.CusSurname = addOrderViewModel1.CustomerSurname;
      updateFinanceRequest.CusFatherName = addOrderViewModel1.Note;
      updateFinanceRequest.Barcode = addOrderViewModel1.BarCode;
      updateFinanceRequest.CusTelNo = addOrderViewModel1.CustomerTel;
      GroupGen2ForOrder selectedType1 = addOrderViewModel1.SelectedType;
      updateFinanceRequest.GroupGen2Id = new long?(selectedType1 != null ? (long) selectedType1.GroupGen2Id : 17001L);
      Tailor typeForMeasurment = addOrderViewModel1.SelectedTypeForMeasurment;
      updateFinanceRequest.TailorId = new int?(typeForMeasurment != null ? typeForMeasurment.TailorId : 0);
      updateFinanceRequest.StUrgent = new byte?(urgent);
      updateFinanceRequest.OperDate = new DateTime?(DateTime.Now);
      updateFinanceRequest.PriceTotal = addOrderViewModel1.Price;
      updateFinanceRequest.DepartId = new int?(addOrderViewModel1.DepartmentId);
      updateFinanceRequest.LastPriceTotal = addOrderViewModel1.LastPrice;
      updateFinanceRequest.PayedTotal = addOrderViewModel1.Beh;
      updateFinanceRequest.CurTypeId = new int?(addOrderViewModel1.SelectedCurrency.CurTypeId);
      updateFinanceRequest.RowDate = new DateTime?(addOrderViewModel1.DeliveryDate);
      float? lastPrice = addOrderViewModel1.LastPrice;
      float? beh2 = addOrderViewModel1.Beh;
      updateFinanceRequest.RemainTotalAll = lastPrice.HasValue & beh2.HasValue ? new float?(lastPrice.GetValueOrDefault() - beh2.GetValueOrDefault()) : new float?();
      updateFinanceRequest.Status = new byte?((byte) (addOrderViewModel1.SelectedTypeForMeasurment == null));
      order = updateFinanceRequest;
      bool flag = false;
      int? tailorId = order.TailorId;
      num1 = 0;
      if (tailorId.GetValueOrDefault() == num1 & tailorId.HasValue)
      {
        long? groupGen2Id = order.GroupGen2Id;
        long num4 = 17001;
        if (!(groupGen2Id.GetValueOrDefault() == num4 & groupGen2Id.HasValue))
        {
          int num5 = (int) MessageBox.Show("Dərzini seçin");
          goto label_14;
        }
      }
      flag = await addOrderViewModel1._unitOfWork.FinanceRepository.AddFinanceAsync(order);
label_14:
      if (!flag)
      {
        order = (AddUpdateFinanceRequest) null;
      }
      else
      {
        MessageBoxResult response = MessageBox.Show("Sifariş əlavə olundu");
        if (addOrderViewModel1.DepartmentId == 18)
        {
          AddOrderViewModel addOrderViewModel3 = addOrderViewModel1;
          AddUpdateFinanceRequest request = order;
          float? beh3 = addOrderViewModel1.Beh;
          int departmentId = addOrderViewModel1.DepartmentId;
          GroupGen2ForOrder selectedType2 = addOrderViewModel1.SelectedType;
          int groupgen2Id = selectedType2 != null ? selectedType2.GroupGen2Id : 12006;
          await addOrderViewModel3.ProcessCashBoxMI(request, beh3, departmentId, groupgen2Id);
        }
        if (addOrderViewModel1.DepartmentId == 12 || addOrderViewModel1.DepartmentId == 13 || addOrderViewModel1.DepartmentId == 14 || addOrderViewModel1.DepartmentId == 17)
        {
          AddOrderViewModel addOrderViewModel4 = addOrderViewModel1;
          AddUpdateFinanceRequest request = order;
          float? beh4 = addOrderViewModel1.Beh;
          int departmentId = addOrderViewModel1.DepartmentId;
          GroupGen2ForOrder selectedType3 = addOrderViewModel1.SelectedType;
          int groupgen2Id = selectedType3 != null ? selectedType3.GroupGen2Id : 12006;
          await addOrderViewModel4.ProcessCashBox(request, beh4, departmentId, groupgen2Id);
        }
        if (response != MessageBoxResult.OK)
        {
          order = (AddUpdateFinanceRequest) null;
        }
        else
        {
          addOrderViewModel1.CurrentWindow.Close();
          order = (AddUpdateFinanceRequest) null;
        }
      }
    }
  }

  public async Task LoadUpdateView()
  {
    if (this.selectedFinanceDto == null)
      return;
    this.CustomerId = this.SelectedFinanceDto.CustomerId.ToString();
    this.CustomerName = this.SelectedFinanceDto.CusName;
    this.CustomerSurname = this.SelectedFinanceDto.CusSurname;
    this.CustomerGsm = this.SelectedFinanceDto.CusGsm;
    this.CustomerTel = this.SelectedFinanceDto.CusTelNo;
  }

  public async Task ProcessCashBoxMI(
    AddUpdateFinanceRequest request,
    float? payedTotal,
    int departmentId,
    int groupgen2Id)
  {
    ICashboxRepository cashboxRepository1 = this._unitOfWork.CashboxRepository;
    DateTime? nullable = request.OperDate;
    DateTime date1 = nullable ?? DateTime.MinValue;
    DailyCashBoxMI cashBoxesMiAsync = await cashboxRepository1.GetDailyCashBoxesMIAsync(date1);
    if (cashBoxesMiAsync == null)
    {
      ICashboxRepository cashboxRepository2 = this._unitOfWork.CashboxRepository;
      DailyCashBoxMI dailyCashMI = new DailyCashBoxMI();
      dailyCashMI.CheckYes1No0 = (byte) 0;
      dailyCashMI.RegUid = CurrentValues.CurrentUser.UserName;
      dailyCashMI.RegDate = DateTime.Now;
      dailyCashMI.DepartId = new int?();
      nullable = new DateTime?();
      dailyCashMI.EditDate = nullable;
      dailyCashMI.OperDate = DateTime.Now;
      dailyCashMI.Status = new byte?();
      int num = await cashboxRepository2.InsertDailyCashMIAsync(dailyCashMI);
      ICashboxRepository cashboxRepository3 = this._unitOfWork.CashboxRepository;
      nullable = request.OperDate;
      DateTime date2 = nullable ?? DateTime.MinValue;
      cashBoxesMiAsync = await cashboxRepository3.GetDailyCashBoxesMIAsync(date2);
    }
    if (cashBoxesMiAsync == null)
      return;
    if (departmentId == 18 && groupgen2Id != 11002 && groupgen2Id != 13001 && groupgen2Id != 13010 && groupgen2Id != 13012 && groupgen2Id != 13019)
      cashBoxesMiAsync.Edit1Azn = new float?(cashBoxesMiAsync.Edit1Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 18 && (groupgen2Id == 11002 || groupgen2Id == 13001 || groupgen2Id == 13010 || groupgen2Id == 13012 || groupgen2Id == 13019))
      cashBoxesMiAsync.Edit1BAzn = new float?(cashBoxesMiAsync.Edit1BAzn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (groupgen2Id == 13021 || groupgen2Id == 13013 || groupgen2Id == 13003)
      cashBoxesMiAsync.EditB1Azn = new float?(cashBoxesMiAsync.EditB1Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    int num1 = await this._unitOfWork.CashboxRepository.UpdateDailyCashMIAsync(cashBoxesMiAsync);
  }

  public async Task ProcessCashBox(
    AddUpdateFinanceRequest request,
    float? payedTotal,
    int departmentId,
    int groupgen2Id)
  {
    ICashboxRepository cashboxRepository1 = this._unitOfWork.CashboxRepository;
    DateTime? nullable = request.OperDate;
    DateTime date1 = nullable ?? DateTime.MinValue;
    DailyCashBox dailyCashBoxesAsync = await cashboxRepository1.GetDailyCashBoxesAsync(date1);
    if (dailyCashBoxesAsync == null)
    {
      ICashboxRepository cashboxRepository2 = this._unitOfWork.CashboxRepository;
      DailyCashBox dailyCash = new DailyCashBox();
      dailyCash.CheckYes1No0 = (byte) 0;
      dailyCash.RegUid = CurrentValues.CurrentUser.UserName;
      dailyCash.RegDate = DateTime.Now;
      dailyCash.DepartId = new int?();
      nullable = new DateTime?();
      dailyCash.EditDate = nullable;
      dailyCash.OperDate = DateTime.Now;
      dailyCash.Status = new byte?();
      int num = await cashboxRepository2.InsertDailyCashAsync(dailyCash);
      ICashboxRepository cashboxRepository3 = this._unitOfWork.CashboxRepository;
      nullable = request.OperDate;
      DateTime date2 = nullable ?? DateTime.MinValue;
      dailyCashBoxesAsync = await cashboxRepository3.GetDailyCashBoxesAsync(date2);
    }
    if (dailyCashBoxesAsync == null)
      return;
    if (departmentId == 12 && groupgen2Id != 11002 && groupgen2Id != 13001 && groupgen2Id != 13010 && groupgen2Id != 13012 && groupgen2Id != 13019 && groupgen2Id != 13005 && groupgen2Id != 13006 && groupgen2Id != 13014 && groupgen2Id != 13015 && groupgen2Id != 13021 && groupgen2Id != 13013 && groupgen2Id != 13003)
      dailyCashBoxesAsync.Edit1Azn = new float?(dailyCashBoxesAsync.Edit1Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 13 && groupgen2Id != 11002 && groupgen2Id != 13001 && groupgen2Id != 13010 && groupgen2Id != 13012 && groupgen2Id != 13019 && groupgen2Id != 13005 && groupgen2Id != 13006 && groupgen2Id != 13014 && groupgen2Id != 13015 && groupgen2Id != 13021 && groupgen2Id != 13013 && groupgen2Id != 13003)
      dailyCashBoxesAsync.Edit2Azn = new float?(dailyCashBoxesAsync.Edit2Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 14 && groupgen2Id != 11002 && groupgen2Id != 13001 && groupgen2Id != 13010 && groupgen2Id != 13012 && groupgen2Id != 13019 && groupgen2Id != 13005 && groupgen2Id != 13006 && groupgen2Id != 13014 && groupgen2Id != 13015 && groupgen2Id != 13021 && groupgen2Id != 13013 && groupgen2Id != 13003)
      dailyCashBoxesAsync.Edit3Azn = new float?(dailyCashBoxesAsync.Edit3Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 17 && groupgen2Id != 11002 && groupgen2Id != 13001 && groupgen2Id != 13010 && groupgen2Id != 13012 && groupgen2Id != 13019 && groupgen2Id != 13005 && groupgen2Id != 13006 && groupgen2Id != 13014 && groupgen2Id != 13015 && groupgen2Id != 13021 && groupgen2Id != 13013 && groupgen2Id != 13003)
      dailyCashBoxesAsync.Edit9Azn = new float?(dailyCashBoxesAsync.Edit9Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 12 && (groupgen2Id == 11002 || groupgen2Id == 13001 || groupgen2Id == 13010 || groupgen2Id == 13012 || groupgen2Id == 13019))
      dailyCashBoxesAsync.Edit1BAzn = new float?(dailyCashBoxesAsync.Edit1BAzn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 13 && (groupgen2Id == 11002 || groupgen2Id == 13001 || groupgen2Id == 13010 || groupgen2Id == 13012 || groupgen2Id == 13019))
      dailyCashBoxesAsync.Edit2BAzn = new float?(dailyCashBoxesAsync.Edit2BAzn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 14 && (groupgen2Id == 11002 || groupgen2Id == 13001 || groupgen2Id == 13010 || groupgen2Id == 13012 || groupgen2Id == 13019))
      dailyCashBoxesAsync.Edit3BAzn = new float?(dailyCashBoxesAsync.Edit3BAzn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (departmentId == 17 && (groupgen2Id == 11002 || groupgen2Id == 13001 || groupgen2Id == 13010 || groupgen2Id == 13012 || groupgen2Id == 13019))
      dailyCashBoxesAsync.Edit9BAzn = new float?(dailyCashBoxesAsync.Edit9BAzn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
    if (groupgen2Id == 13005 || groupgen2Id == 13006 || groupgen2Id == 13014 || groupgen2Id == 13015)
    {
      switch (this.DepartmentId)
      {
        case 12:
          dailyCashBoxesAsync.Edit5Azn = new float?(dailyCashBoxesAsync.Edit5Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 13:
          dailyCashBoxesAsync.Edit7Azn = new float?(dailyCashBoxesAsync.Edit7Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 14:
          dailyCashBoxesAsync.Edit8Azn = new float?(dailyCashBoxesAsync.Edit5Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 17:
          dailyCashBoxesAsync.Edit10Azn = new float?(dailyCashBoxesAsync.Edit10Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
      }
    }
    if (groupgen2Id == 13021 || groupgen2Id == 13013 || groupgen2Id == 13003)
    {
      switch (this.DepartmentId)
      {
        case 12:
          dailyCashBoxesAsync.EditB1Azn = new float?(dailyCashBoxesAsync.EditB1Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 13:
          dailyCashBoxesAsync.EditB2Azn = new float?(dailyCashBoxesAsync.EditB2Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 14:
          dailyCashBoxesAsync.EditB3Azn = new float?(dailyCashBoxesAsync.EditB3Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
        case 17:
          dailyCashBoxesAsync.EditB9Azn = new float?(dailyCashBoxesAsync.EditB9Azn.GetValueOrDefault() + payedTotal.GetValueOrDefault());
          break;
      }
    }
    if (groupgen2Id == 11001 || groupgen2Id == 12006)
      dailyCashBoxesAsync.EditSuit = new int?(dailyCashBoxesAsync.EditSuit.GetValueOrDefault() + 1);
    if (groupgen2Id == 12002 || groupgen2Id == 12025)
      dailyCashBoxesAsync.EditJacket = new int?(dailyCashBoxesAsync.EditJacket.GetValueOrDefault() + 1);
    if (groupgen2Id == 12003)
      dailyCashBoxesAsync.EditPants = new int?(dailyCashBoxesAsync.EditPants.GetValueOrDefault() + 1);
    if (groupgen2Id == 13001)
      dailyCashBoxesAsync.EditShirt = new int?(dailyCashBoxesAsync.EditShirt.GetValueOrDefault() + 1);
    int num1 = await this._unitOfWork.CashboxRepository.UpdateDailyCashAsync(dailyCashBoxesAsync);
  }
}
