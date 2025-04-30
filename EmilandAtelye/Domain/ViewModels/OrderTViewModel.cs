// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.OrderTViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.Views.OrderViews;
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

public class OrderTViewModel : BaseViewModel
{
  private Tailor selectedTypeForMeasurment;
  private DateTime deliverDate;
  private ObservableCollection<Tailor> tailors;
  private ObservableCollection<CurrencyType> currencies;
  private DateTime handoverDate;
  private Tailor? selectedTailor;
  private CurrencyType selectedCurrency;
  private ObservableCollection<GroupGen2ForOrder> types;
  private GroupGen2ForOrder selectedType;
  private string customerId;
  private string customerName;
  private string customerSurname;
  private string note;
  private string customerGsm;
  private string customerTel;
  private string barCode;
  private string cardBarCode;
  private double? price;
  private double? lastPrice;
  private double? beh;
  private string kurs;
  private bool isChecked;
  private string searchCard;
  private ObservableCollection<CustomersSummary> leftOrders;
  private ObservableCollection<FinanceDto> financeLeftOrders;
  private ObservableCollection<CustomerTotalFinanceDto> financeRightOrders;
  private ObservableCollection<DailyTransactionsSummary> rightOrders;
  private ObservableCollection<EmilandAtelye.Domain.Models.DebtForOrder> debtForOrder;
  private ObservableCollection<Card> cardOrders;
  private ObservableCollection<ACard> acardOrders;
  private float leftUsdAll;
  private float leftAznAll;
  private float leftEuroAll;
  private float leftRubAll;
  private Decimal leftDebtAll;
  private float rightEuroAll;
  private float rightRubAll;
  private float kostAll;
  private float rightUsdAll;
  private float rightAznAll;
  private float kosAll;
  private float penAll;
  private float salvAll;
  private float koyAll;
  private float koysAll;
  private float qDonAll;
  private float qKostAll;
  private float qPenAll;
  private float qSalvAll;
  private float frakAll;
  private float plasAll;
  private float paltoAll;
  private float jiletAll;
  private float jiHAll;
  private float qursAll;
  private float babAll;
  private float ayaqAll;
  private float qalsAll;
  private float zapAll;
  private float yubkaAll;
  private CustomersSummary selectedItemDataGrid;
  private FinanceDto selectedFinanceDto;
  private int cusCustomerId;

  public bool IsSearchPage { get; set; } = true;

  public bool AButtonVisible { get; set; }

  public int SelectedCustomerId { get; set; }

  public int DepartmentId { get; set; } = 12;

  private IUnitOfWork UnitOfWork { get; set; }

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  private IOrderService OrderService { get; set; }

  public IEnumerable<Customer> Customers { get; set; }

  public Tailor SelectedTypeForMeasurment
  {
    get => this.selectedTypeForMeasurment;
    set
    {
      this.selectedTypeForMeasurment = value;
      this.OnPropertyChanged(nameof (SelectedTypeForMeasurment));
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

  private ICurrencyTypeService currencyTypeService { get; set; }

  public IEnumerable<EmilandAtelye.Domain.Models.DebtForOrder> BaseDebtForOrders { get; set; }

  public IEnumerable<Card> BaseCardOrders { get; set; }

  public IEnumerable<ACard> BaseACardOrders { get; set; }

  public IEnumerable<DailyTransactionsSummary> BaseRightOrders { get; set; }

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

  public DateTime HandoverDate
  {
    get => this.handoverDate;
    set
    {
      this.handoverDate = value;
      this.OnPropertyChanged(nameof (HandoverDate));
    }
  }

  public Tailor? SelectedTailor
  {
    get => this.selectedTailor;
    set
    {
      this.selectedTailor = value;
      this.OnPropertyChanged(nameof (SelectedTailor));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public CurrencyType SelectedCurrency
  {
    get => this.selectedCurrency;
    set
    {
      this.selectedCurrency = value;
      this.OnPropertyChanged(nameof (SelectedCurrency));
      if (!this.IsSearchPage)
        return;
      this.Search();
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

  public GroupGen2ForOrder SelectedType
  {
    get => this.selectedType;
    set
    {
      this.selectedType = value;
      this.OnPropertyChanged(nameof (SelectedType));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string CustomerId
  {
    get => this.customerId;
    set
    {
      this.customerId = value;
      this.OnPropertyChanged(nameof (CustomerId));
      if (this.IsSearchPage)
        this.Search();
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
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string CustomerSurname
  {
    get => this.customerSurname;
    set
    {
      this.customerSurname = value;
      this.OnPropertyChanged(nameof (CustomerSurname));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string Note
  {
    get => this.note;
    set
    {
      this.note = value;
      this.OnPropertyChanged(nameof (Note));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string CustomerGsm
  {
    get => this.customerGsm;
    set
    {
      this.customerGsm = value;
      this.OnPropertyChanged(nameof (CustomerGsm));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string CustomerTel
  {
    get => this.customerTel;
    set
    {
      this.customerTel = value;
      this.OnPropertyChanged(nameof (CustomerTel));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string BarCode
  {
    get => this.barCode;
    set
    {
      this.barCode = value;
      this.OnPropertyChanged(nameof (BarCode));
      if (this.IsSearchPage)
        this.Search();
      this.GetPricesByBarCode();
    }
  }

  public string CardBarCode
  {
    get => this.cardBarCode;
    set
    {
      this.cardBarCode = value;
      this.OnPropertyChanged(nameof (CardBarCode));
    }
  }

  private async Task GetPricesByBarCode()
  {
    OrderTViewModel orderTviewModel1 = this;
    Goods goodsByBarCode = await orderTviewModel1.UnitOfWork.GoodsRepository.GetGoodsByBarCode(orderTviewModel1.BarCode);
    if (goodsByBarCode == null)
      return;
    OrderTViewModel orderTviewModel2 = orderTviewModel1;
    Decimal? suiteSp1 = goodsByBarCode.SuiteSp;
    double? nullable1 = suiteSp1.HasValue ? new double?((double) suiteSp1.GetValueOrDefault()) : new double?();
    orderTviewModel2.Price = nullable1;
    OrderTViewModel orderTviewModel3 = orderTviewModel1;
    Decimal? suiteSp2 = goodsByBarCode.SuiteSp;
    double? nullable2 = suiteSp2.HasValue ? new double?((double) (float) suiteSp2.GetValueOrDefault()) : new double?();
    orderTviewModel3.LastPrice = nullable2;
  }

  public double? Price
  {
    get => this.price;
    set
    {
      this.price = value;
      this.OnPropertyChanged(nameof (Price));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public double? LastPrice
  {
    get => this.lastPrice;
    set
    {
      this.lastPrice = value;
      this.OnPropertyChanged(nameof (LastPrice));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public double? Beh
  {
    get => this.beh;
    set
    {
      this.beh = value;
      this.OnPropertyChanged(nameof (Beh));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string Kurs
  {
    get => this.kurs;
    set
    {
      this.kurs = value;
      this.OnPropertyChanged(nameof (Kurs));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public bool IsChecked
  {
    get => this.isChecked;
    set
    {
      this.isChecked = value;
      this.OnPropertyChanged(nameof (IsChecked));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public string SearchCard
  {
    get => this.searchCard;
    set
    {
      this.searchCard = value;
      this.OnPropertyChanged(nameof (SearchCard));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public ObservableCollection<CustomersSummary> LeftOrders
  {
    get => this.leftOrders;
    set
    {
      this.leftOrders = value;
      this.OnPropertyChanged(nameof (LeftOrders));
    }
  }

  public ObservableCollection<FinanceDto> FinanceLeftOrders
  {
    get => this.financeLeftOrders;
    set
    {
      this.financeLeftOrders = value;
      this.OnPropertyChanged(nameof (FinanceLeftOrders));
    }
  }

  public ObservableCollection<CustomerTotalFinanceDto> FinanceRightOrders
  {
    get => this.financeRightOrders;
    set
    {
      this.financeRightOrders = value;
      this.OnPropertyChanged(nameof (FinanceRightOrders));
    }
  }

  public ObservableCollection<DailyTransactionsSummary> RightOrders
  {
    get => this.rightOrders;
    set
    {
      this.rightOrders = value;
      this.OnPropertyChanged(nameof (RightOrders));
    }
  }

  public ObservableCollection<EmilandAtelye.Domain.Models.DebtForOrder> DebtForOrder
  {
    get => this.debtForOrder;
    set
    {
      this.debtForOrder = value;
      this.OnPropertyChanged(nameof (DebtForOrder));
    }
  }

  public ObservableCollection<Card> CardOrders
  {
    get => this.cardOrders;
    set
    {
      this.cardOrders = value;
      this.OnPropertyChanged(nameof (CardOrders));
    }
  }

  public ObservableCollection<ACard> ACardOrders
  {
    get => this.acardOrders;
    set
    {
      this.acardOrders = value;
      this.OnPropertyChanged(nameof (ACardOrders));
    }
  }

  public float LeftUsdAll
  {
    get => this.leftUsdAll;
    set
    {
      this.leftUsdAll = value;
      this.OnPropertyChanged(nameof (LeftUsdAll));
    }
  }

  public float LeftAznAll
  {
    get => this.leftAznAll;
    set
    {
      this.leftAznAll = value;
      this.OnPropertyChanged(nameof (LeftAznAll));
    }
  }

  public float LeftEuroAll
  {
    get => this.leftEuroAll;
    set
    {
      this.leftEuroAll = value;
      this.OnPropertyChanged(nameof (LeftEuroAll));
    }
  }

  public float LeftRubAll
  {
    get => this.leftRubAll;
    set
    {
      this.leftRubAll = value;
      this.OnPropertyChanged(nameof (LeftRubAll));
    }
  }

  public Decimal LeftDebtAll
  {
    get => this.leftDebtAll;
    set
    {
      this.leftDebtAll = value;
      this.OnPropertyChanged(nameof (LeftDebtAll));
    }
  }

  public float RightEuroAll
  {
    get => this.rightEuroAll;
    set
    {
      this.rightEuroAll = value;
      this.OnPropertyChanged(nameof (RightEuroAll));
    }
  }

  public float RightRubAll
  {
    get => this.rightRubAll;
    set
    {
      this.rightRubAll = value;
      this.OnPropertyChanged(nameof (RightRubAll));
    }
  }

  public float KostAll
  {
    get => this.kostAll;
    set
    {
      this.kostAll = value;
      this.OnPropertyChanged(nameof (KostAll));
    }
  }

  public float RightUsdAll
  {
    get => this.rightUsdAll;
    set
    {
      this.rightUsdAll = value;
      this.OnPropertyChanged(nameof (RightUsdAll));
    }
  }

  public float RightAznAll
  {
    get => this.rightAznAll;
    set
    {
      this.rightAznAll = value;
      this.OnPropertyChanged(nameof (RightAznAll));
    }
  }

  public float KosAll
  {
    get => this.kosAll;
    set
    {
      this.kosAll = value;
      this.OnPropertyChanged(nameof (KosAll));
    }
  }

  public float PenAll
  {
    get => this.penAll;
    set
    {
      this.penAll = value;
      this.OnPropertyChanged(nameof (PenAll));
    }
  }

  public float SalvAll
  {
    get => this.salvAll;
    set
    {
      this.salvAll = value;
      this.OnPropertyChanged(nameof (SalvAll));
    }
  }

  public float KoyAll
  {
    get => this.koyAll;
    set
    {
      this.koyAll = value;
      this.OnPropertyChanged(nameof (KoyAll));
    }
  }

  public float KoysAll
  {
    get => this.koysAll;
    set
    {
      this.koysAll = value;
      this.OnPropertyChanged(nameof (KoysAll));
    }
  }

  public float QDonAll
  {
    get => this.qDonAll;
    set
    {
      this.qDonAll = value;
      this.OnPropertyChanged(nameof (QDonAll));
    }
  }

  public float QKostAll
  {
    get => this.qKostAll;
    set
    {
      this.qKostAll = value;
      this.OnPropertyChanged(nameof (QKostAll));
    }
  }

  public float QPenAll
  {
    get => this.qPenAll;
    set
    {
      this.qPenAll = value;
      this.OnPropertyChanged(nameof (QPenAll));
    }
  }

  public float QSalvAll
  {
    get => this.qSalvAll;
    set
    {
      this.qSalvAll = value;
      this.OnPropertyChanged(nameof (QSalvAll));
    }
  }

  public float FrakAll
  {
    get => this.frakAll;
    set
    {
      this.frakAll = value;
      this.OnPropertyChanged(nameof (FrakAll));
    }
  }

  public float PlasAll
  {
    get => this.plasAll;
    set
    {
      this.plasAll = value;
      this.OnPropertyChanged(nameof (PlasAll));
    }
  }

  public float PaltoAll
  {
    get => this.paltoAll;
    set
    {
      this.paltoAll = value;
      this.OnPropertyChanged(nameof (PaltoAll));
    }
  }

  public float JiletAll
  {
    get => this.jiletAll;
    set
    {
      this.jiletAll = value;
      this.OnPropertyChanged(nameof (JiletAll));
    }
  }

  public float JiHAll
  {
    get => this.jiHAll;
    set
    {
      this.jiHAll = value;
      this.OnPropertyChanged(nameof (JiHAll));
    }
  }

  public float QursAll
  {
    get => this.qursAll;
    set
    {
      this.qursAll = value;
      this.OnPropertyChanged(nameof (QursAll));
    }
  }

  public float BabAll
  {
    get => this.babAll;
    set
    {
      this.babAll = value;
      this.OnPropertyChanged(nameof (BabAll));
    }
  }

  public float AyaqAll
  {
    get => this.ayaqAll;
    set
    {
      this.ayaqAll = value;
      this.OnPropertyChanged(nameof (AyaqAll));
    }
  }

  public float QalsAll
  {
    get => this.qalsAll;
    set
    {
      this.qalsAll = value;
      this.OnPropertyChanged(nameof (QalsAll));
    }
  }

  public float ZapAll
  {
    get => this.zapAll;
    set
    {
      this.zapAll = value;
      this.OnPropertyChanged(nameof (ZapAll));
    }
  }

  public float YubkaAll
  {
    get => this.yubkaAll;
    set
    {
      this.yubkaAll = value;
      this.OnPropertyChanged(nameof (YubkaAll));
    }
  }

  public CustomersSummary SelectedDataGridItem
  {
    get => this.selectedItemDataGrid;
    set
    {
      this.selectedItemDataGrid = value;
      this.OnPropertyChanged(nameof (SelectedDataGridItem));
    }
  }

  public FinanceDto SelectedFinanceDto
  {
    get => this.selectedFinanceDto;
    set
    {
      this.selectedFinanceDto = value;
      this.OnPropertyChanged(nameof (SelectedFinanceDto));
      this.SetInputs();
    }
  }

  private void SetInputs()
  {
    if (this.selectedFinanceDto == null)
      return;
    int? customerId = this.selectedFinanceDto.CustomerId;
    ref int? local = ref customerId;
    this.CustomerId = (local.HasValue ? local.GetValueOrDefault().ToString() : (string) null) ?? "";
    this.CustomerName = this.selectedFinanceDto.CusName ?? "";
    this.Note = this.selectedFinanceDto.CusFatherName ?? "";
    this.CustomerSurname = this.selectedFinanceDto.CusSurname ?? "";
    this.CustomerTel = this.selectedFinanceDto.CusTelNo;
    this.CustomerGsm = this.selectedFinanceDto.CusGsm;
    this.BarCode = this.selectedFinanceDto.Barcode;
    this.SelectedType = this.selectedFinanceDto.GroupGen;
    this.SelectedTailor = this.selectedFinanceDto.SelectedTailor;
    float? priceTotal = this.selectedFinanceDto.PriceTotal;
    this.Price = priceTotal.HasValue ? new double?((double) priceTotal.GetValueOrDefault()) : new double?();
    float? lastPriceTotal = this.selectedFinanceDto.LastPriceTotal;
    this.LastPrice = lastPriceTotal.HasValue ? new double?((double) lastPriceTotal.GetValueOrDefault()) : new double?();
    float? payedTotal = this.selectedFinanceDto.PayedTotal;
    this.Beh = payedTotal.HasValue ? new double?((double) payedTotal.GetValueOrDefault()) : new double?();
    byte? sturgent = this.selectedFinanceDto.Sturgent;
    this.IsChecked = (sturgent.HasValue ? new int?((int) sturgent.GetValueOrDefault()) : new int?()).GetValueOrDefault() == 1;
  }

  public int CusCustomerId
  {
    get => this.cusCustomerId;
    set
    {
      this.cusCustomerId = value;
      this.OnPropertyChanged(nameof (CusCustomerId));
      if (!this.IsSearchPage)
        return;
      this.Search();
    }
  }

  public RelayCommand ACommand { get; set; }

  public RelayCommand BCommand { get; set; }

  public RelayCommand SaveCommand { get; set; }

  public RelayCommand LeftAndRightDataLoadedForDoubleClick { get; set; }

  public RelayCommand UpdateOrderCommand { get; set; }

  public RelayCommand CardButtonClick { get; set; }

  public RelayCommand GetCustomerOrdersCommand { get; set; }

  public RelayCommand ResetCommand { get; set; }

  public RelayCommand CardButtonClick2 { get; set; }

  public OrderTViewModel(
    IUnitOfWork unitOfWork,
    ICurrencyTypeService currencyTypeService,
    IOrderService orderService)
  {
    this.DeliveryDate = DateTime.Now;
    this.SelectedFinanceDto = this.selectedFinanceDto;
    this.UnitOfWork = unitOfWork;
    this.CurrencyTypeService = currencyTypeService;
    Task.Run<Task>((Func<Task<Task>>) (() => Task.FromResult<Task>(this.LoadLeftData())));
    Task.Run<Task>((Func<Task<Task>>) (() => Task.FromResult<Task>(this.LoadComboBoxes())));
    Task.Run<Task>((Func<Task<Task>>) (() => Task.FromResult<Task>(this.LoadRightData())));
    Task.Run<Task>((Func<Task<Task>>) (() => Task.FromResult<Task>(this.LoadCustomers())));
    this.ResetCommand = new RelayCommand((Action<object>) (async param => await this.Reset(param)));
    this.BCommand = new RelayCommand((Action<object>) (async param => await this.BButtonClicked(param)));
    this.ACommand = new RelayCommand((Action<object>) (async param => await this.AButtonClicked(param)), (Predicate<object>) (param => this.AButtonVisible));
    this.CardButtonClick = new RelayCommand((Action<object>) (async param => await this.CardButtonClicked(param)));
    this.CardButtonClick2 = new RelayCommand((Action<object>) (async param => await this.CardButtonClicked2(param)));
    this.SaveCommand = new RelayCommand((Action<object>) (async param => await this.AddOrderCommandAsync(param)));
    this.LeftAndRightDataLoadedForDoubleClick = new RelayCommand((Action<object>) (async param => await this.LoadDataForDoubleClickAsync(param)));
    this.UpdateOrderCommand = new RelayCommand((Action<object>) (async param => await this.UpdateCommandRedirect(param)));
    this.GetCustomerOrdersCommand = new RelayCommand((Action<object>) (async param => await this.GetCustomerOrders(param)));
    this.OrderService = orderService;
  }

  private Task Reset(object param)
  {
    this.CustomerId = string.Empty;
    this.CustomerName = string.Empty;
    this.Note = string.Empty;
    this.CustomerSurname = string.Empty;
    this.CustomerTel = string.Empty;
    this.CustomerGsm = string.Empty;
    this.BarCode = string.Empty;
    this.SelectedType = (GroupGen2ForOrder) null;
    this.SelectedTailor = (Tailor) null;
    this.Price = new double?();
    this.LastPrice = new double?();
    this.Beh = new double?();
    this.IsChecked = false;
    return Task.CompletedTask;
  }

  public async Task LoadUpdateView(FinanceDto SelectedFinanceDto)
  {
    this.CustomerId = SelectedFinanceDto.CustomerId.ToString();
    this.CustomerName = SelectedFinanceDto.CusName;
    this.CustomerSurname = SelectedFinanceDto.CusSurname;
    this.CustomerGsm = SelectedFinanceDto.CusGsm;
    this.CustomerTel = SelectedFinanceDto.CusTelNo;
  }

  private async Task LoadDataForDoubleClickAsync(object param)
  {
    this.AButtonVisible = true;
    this.IsSearchPage = false;
    this.FinanceLeftOrders = new ObservableCollection<FinanceDto>();
    this.FinanceRightOrders = new ObservableCollection<CustomerTotalFinanceDto>();
    if (!(param is CustomersSummary customerSummary))
    {
      customerSummary = (CustomersSummary) null;
    }
    else
    {
      if (this.SelectedFinanceDto == null)
        this.SelectedFinanceDto = new FinanceDto();
      this.SelectedFinanceDto.CustomerId = new int?(customerSummary.CustomerId);
      this.SelectedFinanceDto.CusName = customerSummary.CusName;
      this.SelectedFinanceDto.CusSurname = customerSummary.CusSurname;
      this.SelectedFinanceDto.CusGsm = customerSummary.CusGsm;
      this.SelectedFinanceDto.CusTelNo = customerSummary.CusTelNo;
      this.CusCustomerId = customerSummary.CustomerId;
      this.LoadUpdateView(this.SelectedFinanceDto);
      await this.LoadRightFinanceDataToday(customerSummary.CustomerId);
      await this.LoadLeftFinanceDataToday(customerSummary.CustomerId);
      customerSummary = (CustomersSummary) null;
    }
  }

  private Task UpdateCommandRedirect(object param)
  {
    UpdateOrderView updateOrderView = new UpdateOrderView(this.UnitOfWork, this.SelectedFinanceDto, (IEnumerable<GroupGen2ForOrder>) this.Types.ToList<GroupGen2ForOrder>(), this.CurrencyTypeService);
    this.ClearLeftFinanceData();
    this.ClearRightFinanceData();
    updateOrderView.Closed += (EventHandler) (async (s, e) =>
    {
      await this.LoadLeftFinanceDataToday(this.CusCustomerId);
      await this.LoadRightFinanceDataToday(this.CusCustomerId);
    });
    updateOrderView.Show();
    return Task.CompletedTask;
  }

  private void ClearLeftFinanceData() => this.FinanceLeftOrders.Clear();

  private void ClearRightFinanceData() => this.FinanceRightOrders.Clear();

  private async Task GetCustomerOrders(object param)
  {
    this.LeftOrders = new ObservableCollection<CustomersSummary>(await this.UnitOfWork.FinanceRepository.GetFilteredCustomersSummaryAsync(this.DepartmentId, this.CustomerId, this.CustomerName, this.CustomerSurname));
  }

  private async Task LoadRightFinanceDataToday(int customerId)
  {
    this.ClearRightFinanceData();
    IEnumerable<CustomerTotalFinance> financeOrderRight = await this.UnitOfWork.FinanceRepository.GetFinanceForDepositTodayAsync(this.DepartmentId, customerId);
    IEnumerable<CurrencyType> allCurrencyTypes = await this.CurrencyTypeService.GetAllCurrencyTypes();
    foreach (CustomerTotalFinance customerTotalFinance in financeOrderRight)
    {
      CustomerTotalFinance item = customerTotalFinance;
      string str = allCurrencyTypes.FirstOrDefault<CurrencyType>((Func<CurrencyType, bool>) (x => x.CurTypeId == item.CurTypeId))?.CurType ?? "Unknown";
      this.FinanceRightOrders.Add(new CustomerTotalFinanceDto()
      {
        St = item.St,
        Status = item.Status,
        CusSurname = item.CusSurname,
        FinDeliverySt = new bool?(item.FinDeliverySt),
        CurTypeId = str,
        CusFatherName = item.CusFatherName,
        CusGsm = item.CusGsm,
        CusName = item.CusName,
        CusTelNo = item.CusTelNo,
        CustomerId = new int?(item.CustomerId),
        DepartId = new int?(item.DepartId),
        FinanceId = new int?(item.FinanceId),
        FinanceNote = item.FinanceNote,
        OperDate = new DateTime?(item.OperDate),
        PayedTotal = new Decimal?(item.PayedTotal),
        PayedTotalAzn = new Decimal?(item.PayedTotalAzn),
        RemainTotalAll = new Decimal?(item.RemainTotalAll)
      });
    }
    financeOrderRight = (IEnumerable<CustomerTotalFinance>) null;
  }

  private async Task LoadLeftFinanceDataToday(int customerId)
  {
    try
    {
      this.ClearLeftFinanceData();
      IEnumerable<Finance> financeOrder = await this.UnitOfWork.FinanceRepository.GetFinanceForOrderTodayAsync(this.DepartmentId, this.CusCustomerId);
      IEnumerable<CurrencyType> currencyTypes = await this.CurrencyTypeService.GetAllCurrencyTypes();
      IEnumerable<Tailor> tailors = await this.UnitOfWork.TailorRepository.GetTailors(this.DepartmentId);
      foreach (Finance finance in financeOrder)
      {
        Finance item = finance;
        string currencyType = currencyTypes.FirstOrDefault<CurrencyType>((Func<CurrencyType, bool>) (x => x.CurTypeId == item.CurTypeId))?.CurType ?? "Unknown";
        string tailorName = tailors.FirstOrDefault<Tailor>((Func<Tailor, bool>) (x => x.TailorId == item.TailorId))?.TailorShortName;
        string genNameByIdAsync = await this.GetGroupGenNameByIdAsync(new int?((int) item.GroupGen2Id));
        GroupGen2ForOrder groupGen2ForOrder = (await this.UnitOfWork.GroupGen2Repository.GetGroupGen2ForOrdersAsync()).FirstOrDefault<GroupGen2ForOrder>((Func<GroupGen2ForOrder, bool>) (x => (long) x.GroupGen2Id == item.GroupGen2Id));
        this.FinanceLeftOrders.Add(new FinanceDto()
        {
          SelectedTailor = new Tailor()
          {
            TailorShortName = tailorName
          },
          St = new int?(item.St),
          Status = new byte?(item.Status),
          Sturgent = new byte?(item.Sturgent),
          St_Order = new byte?(item.St_Order),
          CusSurname = item.CusSurname,
          DepartId = new int?(item.DepartId),
          OSegment = item.OSegment,
          OperDate = new DateTime?(item.OperDate),
          RowDate = new DateTime?(item.RowDate),
          Barcode = item.Barcode,
          CurTypeName = currencyType,
          CusFatherName = item.CusFatherName,
          CusGsm = item.CusGsm,
          CusName = item.CusName,
          CusTelNo = item.CusTelNo,
          CustomerId = new int?(item.CustomerId),
          Fabric_Amount = new float?(item.Fabric_Amount),
          FinanceId = new int?(item.FinanceId),
          FinanceNote = item.FinanceNote,
          GG2 = item.GG2,
          GroupGen = groupGen2ForOrder,
          LastPriceTotal = item.LastPriceTotal,
          OButton = item.OButton,
          OButtonNo = item.OButtonNo,
          OTextileNo = item.OTextileNo,
          PayedTotal = item.PayedTotal,
          PayedTotalAzn = item.PayedTotalAzn,
          PriceTotal = item.PriceTotal,
          PriceTotalAzn = item.PriceTotalAzn,
          PriceTotal_Rub = item.PriceTotal_Rub,
          Rate_Rub = item.Rate_Rub,
          RemainTotalAll = item.RemainTotalAll,
          RowNo = item.RowNo
        });
        currencyType = (string) null;
        tailorName = (string) null;
      }
      financeOrder = (IEnumerable<Finance>) null;
      currencyTypes = (IEnumerable<CurrencyType>) null;
      tailors = (IEnumerable<Tailor>) null;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
      Console.WriteLine("Stack Trace: " + ex.StackTrace);
      throw new Exception("An error occurred while loading the finance data.", ex);
    }
  }

  private async Task LoadRightFinanceData(int customerId)
  {
    this.ClearRightFinanceData();
    IEnumerable<CustomerTotalFinance> financeOrderRight = await this.UnitOfWork.FinanceRepository.GetFinanceForDepositAsync(this.DepartmentId, customerId);
    IEnumerable<CurrencyType> allCurrencyTypes = await this.CurrencyTypeService.GetAllCurrencyTypes();
    foreach (CustomerTotalFinance customerTotalFinance in financeOrderRight)
    {
      CustomerTotalFinance item = customerTotalFinance;
      string str = allCurrencyTypes.FirstOrDefault<CurrencyType>((Func<CurrencyType, bool>) (x => x.CurTypeId == item.CurTypeId))?.CurType ?? "Unknown";
      this.FinanceRightOrders.Add(new CustomerTotalFinanceDto()
      {
        St = item.St,
        Status = item.Status,
        CusSurname = item.CusSurname,
        FinDeliverySt = new bool?(item.FinDeliverySt),
        CurTypeId = str,
        CusFatherName = item.CusFatherName,
        CusGsm = item.CusGsm,
        CusName = item.CusName,
        CusTelNo = item.CusTelNo,
        CustomerId = new int?(item.CustomerId),
        DepartId = new int?(item.DepartId),
        FinanceId = new int?(item.FinanceId),
        FinanceNote = item.FinanceNote,
        OperDate = new DateTime?(item.OperDate),
        PayedTotal = new Decimal?(item.PayedTotal),
        PayedTotalAzn = new Decimal?(item.PayedTotalAzn),
        RemainTotalAll = new Decimal?(item.RemainTotalAll)
      });
    }
    financeOrderRight = (IEnumerable<CustomerTotalFinance>) null;
  }

  private async Task LoadLeftFinanceData(int customerId)
  {
    try
    {
      IEnumerable<Finance> financeOrder = await this.UnitOfWork.FinanceRepository.GetFinanceForOrderAsync(this.DepartmentId, customerId);
      IEnumerable<CurrencyType> currencyTypes = await this.CurrencyTypeService.GetAllCurrencyTypes();
      IEnumerable<Tailor> tailors = await this.UnitOfWork.TailorRepository.GetTailors(this.DepartmentId);
      foreach (Finance finance in financeOrder)
      {
        Finance item = finance;
        string currencyType = currencyTypes.FirstOrDefault<CurrencyType>((Func<CurrencyType, bool>) (x => x.CurTypeId == item.CurTypeId))?.CurType ?? "Unknown";
        string tailorName = tailors.FirstOrDefault<Tailor>((Func<Tailor, bool>) (x => x.TailorId == item.TailorId))?.TailorShortName;
        string genNameByIdAsync = await this.GetGroupGenNameByIdAsync(new int?((int) item.GroupGen2Id));
        GroupGen2ForOrder groupGen2ForOrder = (await this.UnitOfWork.GroupGen2Repository.GetGroupGen2ForOrdersAsync()).FirstOrDefault<GroupGen2ForOrder>((Func<GroupGen2ForOrder, bool>) (x => (long) x.GroupGen2Id == item.GroupGen2Id));
        this.FinanceLeftOrders.Add(new FinanceDto()
        {
          SelectedTailor = new Tailor()
          {
            TailorShortName = tailorName
          },
          St = new int?(item.St),
          Status = new byte?(item.Status),
          Sturgent = new byte?(item.Sturgent),
          St_Order = new byte?(item.St_Order),
          CusSurname = item.CusSurname,
          DepartId = new int?(item.DepartId),
          OSegment = item.OSegment,
          OperDate = new DateTime?(item.OperDate),
          RowDate = new DateTime?(item.RowDate),
          Barcode = item.Barcode,
          CurTypeName = currencyType,
          CusFatherName = item.CusFatherName,
          CusGsm = item.CusGsm,
          CusName = item.CusName,
          CusTelNo = item.CusTelNo,
          CustomerId = new int?(item.CustomerId),
          Fabric_Amount = new float?(item.Fabric_Amount),
          FinanceId = new int?(item.FinanceId),
          FinanceNote = item.FinanceNote,
          GG2 = item.GG2,
          GroupGen = groupGen2ForOrder,
          LastPriceTotal = item.LastPriceTotal,
          OButton = item.OButton,
          OButtonNo = item.OButtonNo,
          OTextileNo = item.OTextileNo,
          PayedTotal = item.PayedTotal,
          PayedTotalAzn = item.PayedTotalAzn,
          PriceTotal = item.PriceTotal,
          PriceTotalAzn = item.PriceTotalAzn,
          PriceTotal_Rub = item.PriceTotal_Rub,
          Rate_Rub = item.Rate_Rub,
          RemainTotalAll = item.RemainTotalAll,
          RowNo = item.RowNo
        });
        currencyType = (string) null;
        tailorName = (string) null;
      }
      financeOrder = (IEnumerable<Finance>) null;
      currencyTypes = (IEnumerable<CurrencyType>) null;
      tailors = (IEnumerable<Tailor>) null;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
      Console.WriteLine("Stack Trace: " + ex.StackTrace);
      throw new Exception("An error occurred while loading the finance data.", ex);
    }
  }

  private async Task<string> GetGroupGenNameByIdAsync(int? groupGen2Id)
  {
    string genNameByIdAsync;
    if (groupGen2Id.HasValue)
      genNameByIdAsync = await this.UnitOfWork.GroupGen2Repository.GetGroupGen2NameByIdAsync(groupGen2Id.Value);
    else
      genNameByIdAsync = "Unknown";
    return genNameByIdAsync;
  }

  private async Task AddOrderCommandAsync(object param) => await this.AddOrder(param);

  private async Task CardButtonClicked(object param)
  {
    try
    {
      IEnumerable<Card> allCards = await this.UnitOfWork.CardsRepository.GetAllCards();
      this.CardOrders = new ObservableCollection<Card>(allCards);
      this.BaseCardOrders = allCards;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      throw;
    }
  }

  private async Task CardButtonClicked2(object param)
  {
    try
    {
      Customer customerById = await this.UnitOfWork.CustomerRepository.GetCustomerById("1", this.DepartmentId);
      if (customerById != null)
      {
        this.CustomerId = customerById.CustomerId.ToString();
        this.CustomerName = customerById.CusName;
        this.CustomerSurname = customerById.CusSurname;
        this.CustomerTel = customerById.CusTelNo;
        this.CustomerGsm = customerById.CusGsm;
        this.Note = customerById.CusFatherName;
      }
      IEnumerable<ACard> acards = await this.UnitOfWork.CardsRepository.GetACards();
      this.ACardOrders = new ObservableCollection<ACard>(acards);
      this.BaseACardOrders = acards;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      throw;
    }
  }

  private async Task AButtonClicked(object param)
  {
    try
    {
      this.ClearLeftFinanceData();
      this.ClearRightFinanceData();
      await Task.WhenAll(this.LoadLeftFinanceData(this.CusCustomerId), this.LoadRightFinanceData(this.CusCustomerId));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      throw;
    }
  }

  private async Task BButtonClicked(object param)
  {
    this.IsSearchPage = false;
    try
    {
      IEnumerable<EmilandAtelye.Domain.Models.DebtForOrder> debtsForOrderAsync = await this.UnitOfWork.DebtRepository.GetDebtsForOrderAsync(this.DepartmentId);
      this.DebtForOrder = new ObservableCollection<EmilandAtelye.Domain.Models.DebtForOrder>(debtsForOrderAsync);
      this.BaseDebtForOrders = debtsForOrderAsync;
      this.LeftUsdAll = debtsForOrderAsync.Sum<EmilandAtelye.Domain.Models.DebtForOrder>((Func<EmilandAtelye.Domain.Models.DebtForOrder, float>) (o => o.PayTotUsd.GetValueOrDefault()));
      this.LeftAznAll = debtsForOrderAsync.Sum<EmilandAtelye.Domain.Models.DebtForOrder>((Func<EmilandAtelye.Domain.Models.DebtForOrder, float>) (o => o.PayTotAzn.GetValueOrDefault()));
      this.LeftEuroAll = debtsForOrderAsync.Sum<EmilandAtelye.Domain.Models.DebtForOrder>((Func<EmilandAtelye.Domain.Models.DebtForOrder, float>) (o => o.PayTotEur.GetValueOrDefault()));
      this.LeftRubAll = debtsForOrderAsync.Sum<EmilandAtelye.Domain.Models.DebtForOrder>((Func<EmilandAtelye.Domain.Models.DebtForOrder, float>) (o => o.PayTotRur.GetValueOrDefault()));
      this.LeftDebtAll = debtsForOrderAsync.Sum<EmilandAtelye.Domain.Models.DebtForOrder>((Func<EmilandAtelye.Domain.Models.DebtForOrder, Decimal>) (o => o.RemainTotalAll.GetValueOrDefault()));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
      throw;
    }
  }

  private async Task LoadLeftData()
  {
    OrderTViewModel orderTviewModel = this;
    try
    {
      // ISSUE: reference to a compiler-generated method
      Task.Run(new Func<Task>(orderTviewModel.\u003CLoadLeftData\u003Eb__360_0));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
  }

  private async Task LoadRightData()
  {
    IEnumerable<DailyTransactionsSummary> transactionsSummaryAsync = await this.UnitOfWork.FinanceRepository.GetDailyTransactionsSummaryAsync(this.DepartmentId);
    this.RightOrders = new ObservableCollection<DailyTransactionsSummary>(transactionsSummaryAsync);
    this.BaseRightOrders = transactionsSummaryAsync;
    this.RightUsdAll = transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, float>) (o => o.PayTotUsd.GetValueOrDefault()));
    this.RightAznAll = transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, float>) (o => o.PayTotAzn.GetValueOrDefault()));
    this.RightEuroAll = transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, float>) (o => o.PayTotEur.GetValueOrDefault()));
    this.RightRubAll = transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, float>) (o => o.PayTotRur.GetValueOrDefault()));
    this.KostAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Kostyum.GetValueOrDefault()));
    this.KosAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Kostyum_Smoking.GetValueOrDefault()));
    this.PenAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Pencek.GetValueOrDefault()));
    this.SalvAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Shalvar.GetValueOrDefault()));
    this.KoyAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Koynek.GetValueOrDefault()));
    this.KoysAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Koynek_Smoking.GetValueOrDefault()));
    this.QDonAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Lady_Dress.GetValueOrDefault()));
    this.QPenAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Lady_Pencek.GetValueOrDefault()));
    this.QSalvAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Lady_Shalvar.GetValueOrDefault()));
    this.FrakAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Frak.GetValueOrDefault()));
    this.PlasAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Plash.GetValueOrDefault()));
    this.PaltoAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Palto.GetValueOrDefault()));
    this.JiletAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Jilet.GetValueOrDefault()));
    this.JiHAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Hazir_Jilet.GetValueOrDefault()));
    this.QursAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Qurshaq.GetValueOrDefault()));
    this.BabAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Bab.GetValueOrDefault()));
    this.AyaqAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Ayaqqabi.GetValueOrDefault()));
    this.QalsAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Qalstuk.GetValueOrDefault()));
    this.ZapAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Zapinka.GetValueOrDefault()));
    this.YubkaAll = (float) transactionsSummaryAsync.Sum<DailyTransactionsSummary>((Func<DailyTransactionsSummary, int>) (o => o.Skirt.GetValueOrDefault()));
  }

  private async Task LoadComboBoxes()
  {
    this.Types = new ObservableCollection<GroupGen2ForOrder>(await this.UnitOfWork.GroupGen2Repository.GetGroupGen2ForOrdersAsync());
    this.Tailors = new ObservableCollection<Tailor>(await this.UnitOfWork.TailorRepository.GetTailors(this.DepartmentId));
    if (this.currencyTypeService == null)
      this.currencyTypeService = (ICurrencyTypeService) new EmilandAtelye.Services.Concrete.CurrencyTypeService(this.UnitOfWork);
    IEnumerable<CurrencyType> allCurrencyTypes = await this.currencyTypeService.GetAllCurrencyTypes();
    this.Currencies = new ObservableCollection<CurrencyType>(allCurrencyTypes);
    this.SelectedCurrency = (allCurrencyTypes != null ? allCurrencyTypes.FirstOrDefault<CurrencyType>() : (CurrencyType) null) ?? new CurrencyType();
  }

  private Task Search()
  {
    Task.Run((Func<Task>) (() => Task.CompletedTask));
    return Task.CompletedTask;
  }

  private async Task GetCustomer()
  {
    Customer customerById = await this.UnitOfWork.CustomerRepository.GetCustomerById(this.CustomerId, this.DepartmentId);
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
    this.Customers = await this.UnitOfWork.CustomerRepository.GetAllCustomersForDeparts(this.DepartmentId);
  }

  public async Task<bool> AddCustomer()
  {
    return await this.UnitOfWork.CustomerRepository.InsertCustomer(new CustomerInsert()
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
    OrderTViewModel orderTviewModel1 = this;
    DateTime? editdatecard = new DateTime?();
    GroupGen2ForOrder selectedType1 = orderTviewModel1.SelectedType;
    int groupgen2 = selectedType1 != null ? selectedType1.GroupGen2Id : 17001;
    double? payment = orderTviewModel1.Beh;
    if (orderTviewModel1.CardBarCode != null)
    {
      payment = new double?(await orderTviewModel1.UnitOfWork.CardsRepository.GetPriceByBarcode(orderTviewModel1.CardBarCode));
      groupgen2 = 12000;
      editdatecard = new DateTime?(DateTime.Now);
    }
    AddUpdateFinanceRequest order;
    if (orderTviewModel1.SelectedCurrency == null)
    {
      int num = (int) MessageBox.Show("Valyuta tipini seçin");
      order = (AddUpdateFinanceRequest) null;
    }
    else
    {
      byte urgent = 0;
      if (orderTviewModel1.IsChecked)
        urgent = (byte) 1;
      int num1;
      if (orderTviewModel1.CustomerId.IsNullOrEmpty<char>())
      {
        int maxCustomerId = await orderTviewModel1.UnitOfWork.CustomerRepository.GetMaxCustomerId();
        OrderTViewModel orderTviewModel2 = orderTviewModel1;
        int num2;
        num1 = num2 = maxCustomerId + 1;
        string str = num1.ToString();
        orderTviewModel2.CustomerId = str;
        if (!await orderTviewModel1.AddCustomer())
        {
          int num3 = (int) MessageBox.Show("Müştəri əlavə oluna bilmədi");
        }
      }
      AddUpdateFinanceRequest updateFinanceRequest = new AddUpdateFinanceRequest();
      updateFinanceRequest.CustomerId = new int?(int.Parse(orderTviewModel1.CustomerId));
      updateFinanceRequest.CusName = orderTviewModel1.CustomerName;
      updateFinanceRequest.CusGsm = orderTviewModel1.CustomerGsm;
      updateFinanceRequest.CusSurname = orderTviewModel1.CustomerSurname;
      updateFinanceRequest.CusFatherName = orderTviewModel1.Note;
      updateFinanceRequest.Barcode = orderTviewModel1.BarCode;
      updateFinanceRequest.CusTelNo = orderTviewModel1.CustomerTel;
      updateFinanceRequest.GroupGen2Id = new long?((long) groupgen2);
      Tailor typeForMeasurment = orderTviewModel1.SelectedTypeForMeasurment;
      updateFinanceRequest.TailorId = new int?(typeForMeasurment != null ? typeForMeasurment.TailorId : 0);
      updateFinanceRequest.StUrgent = new byte?(urgent);
      updateFinanceRequest.OperDate = new DateTime?(DateTime.Now);
      double? price = orderTviewModel1.Price;
      updateFinanceRequest.PriceTotal = price.HasValue ? new Decimal?((Decimal) price.GetValueOrDefault()) : new Decimal?();
      updateFinanceRequest.DepartId = new int?(orderTviewModel1.DepartmentId);
      double? nullable1 = orderTviewModel1.LastPrice;
      updateFinanceRequest.LastPriceTotal = nullable1.HasValue ? new float?((float) nullable1.GetValueOrDefault()) : new float?();
      nullable1 = payment;
      updateFinanceRequest.PayedTotal = nullable1.HasValue ? new float?((float) nullable1.GetValueOrDefault()) : new float?();
      nullable1 = payment;
      updateFinanceRequest.PayedTotalAzn = nullable1.HasValue ? new float?((float) nullable1.GetValueOrDefault()) : new float?();
      updateFinanceRequest.CurTypeId = new int?(orderTviewModel1.SelectedCurrency.CurTypeId);
      updateFinanceRequest.RowDate = new DateTime?(orderTviewModel1.DeliveryDate.Date);
      nullable1 = orderTviewModel1.LastPrice;
      double? nullable2 = payment;
      updateFinanceRequest.RemainTotalAll = nullable1.HasValue & nullable2.HasValue ? new float?((float) (nullable1.GetValueOrDefault() - nullable2.GetValueOrDefault())) : new float?();
      updateFinanceRequest.Status = new byte?((byte) (orderTviewModel1.SelectedTypeForMeasurment == null));
      updateFinanceRequest.FinanceNote = orderTviewModel1.CardBarCode ?? (string) null;
      updateFinanceRequest.EditDate = editdatecard;
      order = updateFinanceRequest;
      bool result = false;
      int? tailorId = order.TailorId;
      num1 = 0;
      if (tailorId.GetValueOrDefault() == num1 & tailorId.HasValue)
      {
        long? groupGen2Id = order.GroupGen2Id;
        long num4 = 17001;
        if (!(groupGen2Id.GetValueOrDefault() == num4 & groupGen2Id.HasValue) && orderTviewModel1.CardBarCode == null)
        {
          int num5 = (int) MessageBox.Show("Dərzini seçin");
          goto label_17;
        }
      }
      if (order.CusName == null)
      {
        order = (AddUpdateFinanceRequest) null;
        return;
      }
      result = await orderTviewModel1.UnitOfWork.FinanceRepository.AddFinanceAsync(order);
      await orderTviewModel1.UnitOfWork.CardsRepository.UpdateCard(orderTviewModel1.CardBarCode, payment);
label_17:
      if (!result)
      {
        order = (AddUpdateFinanceRequest) null;
      }
      else
      {
        int num6 = (int) MessageBox.Show("Sifariş əlavə olundu");
        if (orderTviewModel1.AButtonVisible)
          await orderTviewModel1.CardButtonClicked2((object) null);
        if (orderTviewModel1.DepartmentId == 18)
        {
          OrderTViewModel orderTviewModel3 = orderTviewModel1;
          AddUpdateFinanceRequest request = order;
          nullable2 = orderTviewModel1.Beh;
          float? payedTotal = nullable2.HasValue ? new float?((float) nullable2.GetValueOrDefault()) : new float?();
          int departmentId = orderTviewModel1.DepartmentId;
          GroupGen2ForOrder selectedType2 = orderTviewModel1.SelectedType;
          int groupgen2Id = selectedType2 != null ? selectedType2.GroupGen2Id : 12006;
          await orderTviewModel3.ProcessCashBoxMI(request, payedTotal, departmentId, groupgen2Id);
        }
        if (orderTviewModel1.DepartmentId == 12 || orderTviewModel1.DepartmentId == 13 || orderTviewModel1.DepartmentId == 14 || orderTviewModel1.DepartmentId == 17)
        {
          OrderTViewModel orderTviewModel4 = orderTviewModel1;
          AddUpdateFinanceRequest request = order;
          nullable2 = orderTviewModel1.Beh;
          float? payedTotal = nullable2.HasValue ? new float?((float) nullable2.GetValueOrDefault()) : new float?();
          int departmentId = orderTviewModel1.DepartmentId;
          GroupGen2ForOrder selectedType3 = orderTviewModel1.SelectedType;
          int groupgen2Id = selectedType3 != null ? selectedType3.GroupGen2Id : 12006;
          await orderTviewModel4.ProcessCashBox(request, payedTotal, departmentId, groupgen2Id);
        }
        if (!orderTviewModel1.IsSearchPage)
        {
          orderTviewModel1.LoadRightFinanceDataToday(int.Parse(orderTviewModel1.CustomerId));
          orderTviewModel1.LoadLeftFinanceDataToday(int.Parse(orderTviewModel1.CustomerId));
        }
        else
        {
          orderTviewModel1.LoadLeftData();
          orderTviewModel1.LoadRightData();
        }
        orderTviewModel1.ClearInputs();
        order = (AddUpdateFinanceRequest) null;
      }
    }
  }

  public async Task ClearInputs()
  {
    this.CustomerId = string.Empty;
    this.CustomerName = string.Empty;
    this.CustomerSurname = string.Empty;
    this.Note = string.Empty;
    this.CustomerTel = string.Empty;
    this.CustomerGsm = string.Empty;
    this.SelectedType = (GroupGen2ForOrder) null;
    this.SelectedTypeForMeasurment = (Tailor) null;
    this.Price = new double?();
    this.LastPrice = new double?();
    this.BarCode = string.Empty;
    this.Beh = new double?();
    this.IsChecked = false;
    this.CardBarCode = string.Empty;
  }

  public async Task ProcessCashBoxMI(
    AddUpdateFinanceRequest request,
    float? payedTotal,
    int departmentId,
    int groupgen2Id)
  {
    ICashboxRepository cashboxRepository1 = this.UnitOfWork.CashboxRepository;
    DateTime? nullable = request.OperDate;
    DateTime date1 = nullable ?? DateTime.MinValue;
    DailyCashBoxMI cashBoxesMiAsync = await cashboxRepository1.GetDailyCashBoxesMIAsync(date1);
    if (cashBoxesMiAsync == null)
    {
      ICashboxRepository cashboxRepository2 = this.UnitOfWork.CashboxRepository;
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
      ICashboxRepository cashboxRepository3 = this.UnitOfWork.CashboxRepository;
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
    int num1 = await this.UnitOfWork.CashboxRepository.UpdateDailyCashMIAsync(cashBoxesMiAsync);
  }

  public async Task ProcessCashBox(
    AddUpdateFinanceRequest request,
    float? payedTotal,
    int departmentId,
    int groupgen2Id)
  {
    ICashboxRepository cashboxRepository1 = this.UnitOfWork.CashboxRepository;
    DateTime? nullable = request.OperDate;
    DateTime date1 = nullable ?? DateTime.MinValue;
    DailyCashBox dailyCashBoxesAsync = await cashboxRepository1.GetDailyCashBoxesAsync(date1);
    if (dailyCashBoxesAsync == null)
    {
      ICashboxRepository cashboxRepository2 = this.UnitOfWork.CashboxRepository;
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
      ICashboxRepository cashboxRepository3 = this.UnitOfWork.CashboxRepository;
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
    int num1 = await this.UnitOfWork.CashboxRepository.UpdateDailyCashAsync(dailyCashBoxesAsync);
  }
}
