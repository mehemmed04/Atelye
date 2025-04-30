// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.UpdateOrderViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.DTOs;
using EmilandAtelye.DTOs.Requests;
using EmilandAtelye.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class UpdateOrderViewModel : BaseViewModel
{
  private string customerId;
  private string customerName;
  private string barCode;
  private GroupGen2ForOrder selectedType;
  private string customerSurname;
  private double? price;
  private string note;
  private double? lastPrice;
  private string customerGsm;
  private double? beh;
  private string customerTel;
  private byte? _isChecked;
  private DateTime? deliverDate;
  private Tailor selectedTypeForMeasurment;
  private FinanceDto selectedFinanceLeftOrder;
  private CustomersSummary _selectedCustomerInfo;
  private ObservableCollection<FinanceDto> financeLeftOrders;
  private ObservableCollection<GroupGen2ForOrder> types;
  private ObservableCollection<Tailor> tailors;

  private int DepartmentId { get; set; } = 12;

  private int? SelectedCustomerId { get; set; }

  private IUnitOfWork UnitOfWork { get; set; }

  public RelayCommand UpdateOrderCommand { get; set; }

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  public string CustomerId
  {
    get => this.customerId;
    set
    {
      this.customerId = value;
      this.OnPropertyChanged(nameof (CustomerId));
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
    }
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

  public double? Price
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

  public double? LastPrice
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

  public double? Beh
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

  public byte? IsChecked
  {
    get => this._isChecked;
    set
    {
      byte? isChecked = this._isChecked;
      int? nullable1 = isChecked.HasValue ? new int?((int) isChecked.GetValueOrDefault()) : new int?();
      byte? nullable2 = value;
      int? nullable3 = nullable2.HasValue ? new int?((int) nullable2.GetValueOrDefault()) : new int?();
      if (nullable1.GetValueOrDefault() == nullable3.GetValueOrDefault() & nullable1.HasValue == nullable3.HasValue)
        return;
      this._isChecked = value;
      this.OnPropertyChanged(nameof (IsChecked));
    }
  }

  public DateTime? DeliveryDate
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

  public FinanceDto SelectedFinanceLeftOrder
  {
    get => this.selectedFinanceLeftOrder;
    set
    {
      this.selectedFinanceLeftOrder = value;
      this.OnPropertyChanged(nameof (SelectedFinanceLeftOrder));
    }
  }

  public CustomersSummary SelectedCustomerInfo
  {
    get => this._selectedCustomerInfo;
    set => this._selectedCustomerInfo = value;
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

  public UpdateOrderViewModel(
    IUnitOfWork unitOfWork,
    FinanceDto financeDto,
    IEnumerable<GroupGen2ForOrder> types,
    ICurrencyTypeService currencyTypeService)
  {
    this.UnitOfWork = unitOfWork;
    this.LoadComboBoxes();
    this.Types = new ObservableCollection<GroupGen2ForOrder>(types);
    this.SelectedCustomerId = financeDto.CustomerId;
    this.SelectedFinanceLeftOrder = financeDto;
    this.CurrencyTypeService = currencyTypeService;
    this.UpdateOrderCommand = new RelayCommand((Action<object>) (async param => await this.UpdateOrder(param)));
    this.LoadUpdateView();
  }

  public async Task UpdateOrder(object param)
  {
    UpdateOrderViewModel updateOrderViewModel = this;
    // ISSUE: reference to a compiler-generated method
    CurrencyType currencyType = (await updateOrderViewModel.CurrencyTypeService.GetAllCurrencyTypes()).FirstOrDefault<CurrencyType>(new Func<CurrencyType, bool>(updateOrderViewModel.\u003CUpdateOrder\u003Eb__97_0));
    AddUpdateFinanceRequest updateFinanceRequest = new AddUpdateFinanceRequest();
    updateFinanceRequest.CustomerId = new int?(int.Parse(updateOrderViewModel.CustomerId));
    updateFinanceRequest.CusName = updateOrderViewModel.SelectedFinanceLeftOrder.CusName;
    updateFinanceRequest.CusGsm = updateOrderViewModel.SelectedFinanceLeftOrder.CusGsm;
    updateFinanceRequest.CusSurname = updateOrderViewModel.SelectedFinanceLeftOrder.CusSurname;
    updateFinanceRequest.RegDate = new DateTime?(DateTime.Now);
    updateFinanceRequest.Barcode = updateOrderViewModel.SelectedFinanceLeftOrder.Barcode;
    updateFinanceRequest.CusTelNo = updateOrderViewModel.SelectedFinanceLeftOrder.CusTelNo;
    int? groupGen2Id = updateOrderViewModel.SelectedFinanceLeftOrder.GroupGen?.GroupGen2Id;
    updateFinanceRequest.GroupGen2Id = groupGen2Id.HasValue ? new long?((long) groupGen2Id.GetValueOrDefault()) : new long?();
    updateFinanceRequest.TailorId = updateOrderViewModel.SelectedFinanceLeftOrder.SelectedTailor?.TailorId;
    updateFinanceRequest.StUrgent = updateOrderViewModel.SelectedFinanceLeftOrder.Sturgent;
    updateFinanceRequest.OperDate = updateOrderViewModel.SelectedFinanceLeftOrder.OperDate;
    float? priceTotal = updateOrderViewModel.SelectedFinanceLeftOrder.PriceTotal;
    updateFinanceRequest.PriceTotal = priceTotal.HasValue ? new Decimal?((Decimal) priceTotal.GetValueOrDefault()) : new Decimal?();
    double? lastPrice = updateOrderViewModel.LastPrice;
    updateFinanceRequest.LastPriceTotal = lastPrice.HasValue ? new float?((float) lastPrice.GetValueOrDefault()) : new float?();
    updateFinanceRequest.PayedTotal = updateOrderViewModel.SelectedFinanceLeftOrder.PayedTotal;
    updateFinanceRequest.CurTypeId = currencyType?.CurTypeId;
    updateFinanceRequest.RowDate = updateOrderViewModel.SelectedFinanceLeftOrder.RowDate;
    AddUpdateFinanceRequest request = updateFinanceRequest;
    if (!await updateOrderViewModel.UnitOfWork.FinanceRepository.UpdateFinanceAsync(updateOrderViewModel.SelectedFinanceLeftOrder.FinanceId.GetValueOrDefault(), request) || MessageBox.Show("SAVED") != MessageBoxResult.OK)
      return;
    Application.Current.Windows.OfType<Window>().SingleOrDefault<Window>((Func<Window, bool>) (w => w.IsActive))?.Close();
  }

  public async Task LoadComboBoxes()
  {
    this.Tailors = new ObservableCollection<Tailor>(await this.UnitOfWork.TailorRepository.GetTailors(this.DepartmentId));
  }

  public async Task LoadUpdateView()
  {
    UpdateOrderViewModel updateOrderViewModel1 = this;
    if (updateOrderViewModel1.SelectedFinanceLeftOrder == null)
      return;
    updateOrderViewModel1.CustomerId = updateOrderViewModel1.SelectedCustomerId.ToString();
    updateOrderViewModel1.CustomerName = updateOrderViewModel1.SelectedFinanceLeftOrder.CusName;
    updateOrderViewModel1.CustomerSurname = updateOrderViewModel1.SelectedFinanceLeftOrder.CusSurname;
    updateOrderViewModel1.CustomerTel = updateOrderViewModel1.SelectedFinanceLeftOrder.CusTelNo;
    updateOrderViewModel1.BarCode = updateOrderViewModel1.SelectedFinanceLeftOrder.Barcode;
    updateOrderViewModel1.Note = updateOrderViewModel1.SelectedFinanceLeftOrder.CusFatherName;
    UpdateOrderViewModel updateOrderViewModel2 = updateOrderViewModel1;
    float? nullable1 = updateOrderViewModel1.SelectedFinanceLeftOrder.PriceTotal;
    double? nullable2 = nullable1.HasValue ? new double?((double) nullable1.GetValueOrDefault()) : new double?();
    updateOrderViewModel2.Price = nullable2;
    UpdateOrderViewModel updateOrderViewModel3 = updateOrderViewModel1;
    nullable1 = updateOrderViewModel1.SelectedFinanceLeftOrder.LastPriceTotal;
    double? nullable3 = nullable1.HasValue ? new double?((double) nullable1.GetValueOrDefault()) : new double?();
    updateOrderViewModel3.LastPrice = nullable3;
    updateOrderViewModel1.CustomerGsm = updateOrderViewModel1.SelectedFinanceLeftOrder.CusGsm;
    UpdateOrderViewModel updateOrderViewModel4 = updateOrderViewModel1;
    nullable1 = updateOrderViewModel1.SelectedFinanceLeftOrder.PayedTotal;
    double? nullable4 = nullable1.HasValue ? new double?((double) nullable1.GetValueOrDefault()) : new double?();
    updateOrderViewModel4.Beh = nullable4;
    updateOrderViewModel1.IsChecked = updateOrderViewModel1.SelectedFinanceLeftOrder.St_Order;
    updateOrderViewModel1.DeliveryDate = updateOrderViewModel1.SelectedFinanceLeftOrder.RowDate;
    GroupGen2ForOrder groupgen2 = updateOrderViewModel1.SelectedFinanceLeftOrder.GroupGen;
    updateOrderViewModel1.SelectedType = updateOrderViewModel1.Types.FirstOrDefault<GroupGen2ForOrder>((Func<GroupGen2ForOrder, bool>) (t => t.GroupGen2Id == groupgen2.GroupGen2Id));
    updateOrderViewModel1.SelectedTypeForMeasurment = updateOrderViewModel1.SelectedFinanceLeftOrder.SelectedTailor;
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
}
