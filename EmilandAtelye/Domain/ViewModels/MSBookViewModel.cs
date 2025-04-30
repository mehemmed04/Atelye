// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.MSBookViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class MSBookViewModel : BaseViewModel
{
  private readonly IUnitOfWork _unitWork;
  private string kost;
  private string koy;
  private string zap;
  private string qals;
  private string yayl;
  private string jilet;
  private string corab;
  private string ayag;
  private string kemer;
  private string qurs;
  private string bab;
  private EmilandAtelye.Domain.Models.Goods? currentGoods;
  private string? barCode;
  private ObservableCollection<string> yesNo;
  private ObservableCollection<CurrencyType> currencyTypes;
  private MeasureUnit selectedMeasureUnit;
  private Company? selectedCompany;
  private CurrencyType selectedCurrency;
  private ObservableCollection<SizeModel> sizes;
  private ObservableCollection<Color> colors;
  private ObservableCollection<MeasureUnit> _measureUnits;
  private ObservableCollection<Country> _countries;
  private ObservableCollection<Department> _departments;
  private ObservableCollection<Customer> _customers;
  private ObservableCollection<SizeByGroupGen2DTO> _sizeByGroupGen2;
  private ObservableCollection<ColorByGroupGen2DTO> _colorByGroupGen2;
  private ObservableCollection<Composition> _compositions;
  private ObservableCollection<EmployeeGroup> _employeeGroups;
  private EmployeeGroup selectedEmployeeGroup;
  private ObservableCollection<Employee> _employees;
  private ObservableCollection<Employee> debtors;
  private ObservableCollection<Employee> employeePerGroup;
  private ObservableCollection<GroupGen1> _groupGen1s;
  private GroupGen1 _selectedGroupGen1;
  private ObservableCollection<GroupGen2ByGen1> _groupGen2s;
  private ObservableCollection<Company> _companies;
  private ObservableCollection<Price2DTO> _prices2 = new ObservableCollection<Price2DTO>();
  private ObservableCollection<Price> _prices;
  private Price _selectedPrice;

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  private async Task FetchData(string value)
  {
    MSBookViewModel msBookViewModel = this;
    msBookViewModel.BarCode = value;
    EmilandAtelye.Domain.Models.Goods goodsByBarCode = await msBookViewModel._unitWork.GoodsRepository.GetGoodsByBarCode(value);
    msBookViewModel.CurrentGoods = goodsByBarCode;
    if (msBookViewModel.CurrentGoods == null)
      return;
    // ISSUE: reference to a compiler-generated method
    msBookViewModel.SelectedMeasureUnit = msBookViewModel.MeasureUnits.FirstOrDefault<MeasureUnit>(new Func<MeasureUnit, bool>(msBookViewModel.\u003CFetchData\u003Eb__4_0));
    // ISSUE: reference to a compiler-generated method
    msBookViewModel.SelectedCurrency = msBookViewModel.CurrencyTypes.FirstOrDefault<CurrencyType>(new Func<CurrencyType, bool>(msBookViewModel.\u003CFetchData\u003Eb__4_1));
  }

  public RelayCommand OpenMalinPasportu { get; set; }

  public RelayCommand OpenYeniQiymetler { get; set; }

  public RelayCommand OpenQruplar { get; set; }

  public RelayCommand OpenFirmalar { get; set; }

  public RelayCommand OpenModeller { get; set; }

  public RelayCommand OpenQiymetler { get; set; }

  public RelayCommand OpenMSK1 { get; set; }

  public RelayCommand OpenMusteriler { get; set; }

  public RelayCommand OpenOlculer { get; set; }

  public RelayCommand OpenRengler { get; set; }

  public RelayCommand OpenParcalar { get; set; }

  public RelayCommand OpenEmekHaqqlari { get; set; }

  public RelayCommand SaveCommand { get; set; }

  public string Kost
  {
    get => this.kost;
    set
    {
      this.kost = value;
      this.OnPropertyChanged(nameof (Kost));
      this.FetchData(value);
    }
  }

  public string Koy
  {
    get => this.koy;
    set
    {
      this.koy = value;
      this.OnPropertyChanged(nameof (Koy));
      this.FetchData(value);
    }
  }

  public string Zap
  {
    get => this.zap;
    set
    {
      this.zap = value;
      this.OnPropertyChanged(nameof (Zap));
      this.FetchData(value);
    }
  }

  public string Qals
  {
    get => this.qals;
    set
    {
      this.qals = value;
      this.OnPropertyChanged(nameof (Qals));
      this.FetchData(value);
    }
  }

  public string Yayl
  {
    get => this.yayl;
    set
    {
      this.yayl = value;
      this.OnPropertyChanged(nameof (Yayl));
      this.FetchData(value);
    }
  }

  public string Jilet
  {
    get => this.jilet;
    set
    {
      this.jilet = value;
      this.OnPropertyChanged(nameof (Jilet));
      this.FetchData(value);
    }
  }

  public string Corab
  {
    get => this.corab;
    set
    {
      this.corab = value;
      this.OnPropertyChanged(nameof (Corab));
      this.FetchData(value);
    }
  }

  public string Ayag
  {
    get => this.ayag;
    set
    {
      this.ayag = value;
      this.OnPropertyChanged(nameof (Ayag));
      this.FetchData(value);
    }
  }

  public string Kemer
  {
    get => this.kemer;
    set
    {
      this.kemer = value;
      this.OnPropertyChanged(nameof (Kemer));
      this.FetchData(value);
    }
  }

  public string Qurs
  {
    get => this.qurs;
    set
    {
      this.qurs = value;
      this.OnPropertyChanged(nameof (Qurs));
      this.FetchData(value);
    }
  }

  public string Bab
  {
    get => this.bab;
    set
    {
      this.bab = value;
      this.OnPropertyChanged(nameof (Bab));
      this.FetchData(value);
    }
  }

  public EmilandAtelye.Domain.Models.Goods? CurrentGoods
  {
    get => this.currentGoods;
    set
    {
      this.currentGoods = value;
      this.OnPropertyChanged(nameof (CurrentGoods));
    }
  }

  public string? BarCode
  {
    get => this.barCode;
    set
    {
      this.barCode = value;
      this.OnPropertyChanged(nameof (BarCode));
    }
  }

  public ObservableCollection<string> YesNo
  {
    get
    {
      ObservableCollection<string> yesNo = new ObservableCollection<string>();
      yesNo.Add("Bəli");
      yesNo.Add("Xeyr");
      return yesNo;
    }
    set
    {
      this.yesNo = value;
      this.OnPropertyChanged(nameof (YesNo));
    }
  }

  public ObservableCollection<CurrencyType> CurrencyTypes
  {
    get => this.currencyTypes;
    set
    {
      this.currencyTypes = value;
      this.OnPropertyChanged(nameof (CurrencyTypes));
    }
  }

  public MeasureUnit SelectedMeasureUnit
  {
    get => this.selectedMeasureUnit;
    set
    {
      this.selectedMeasureUnit = value;
      this.OnPropertyChanged(nameof (SelectedMeasureUnit));
    }
  }

  public Company? SelectedCompany
  {
    get => this.selectedCompany;
    set
    {
      this.selectedCompany = value;
      this.OnPropertyChanged(nameof (SelectedCompany));
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

  public IEnumerable<EmilandAtelye.Domain.Models.Goods> Goods { get; set; }

  public ObservableCollection<SizeModel> Sizes
  {
    get => this.sizes;
    set
    {
      this.sizes = value;
      this.OnPropertyChanged(nameof (Sizes));
    }
  }

  public ObservableCollection<Color> Colors
  {
    get => this.colors;
    set
    {
      this.colors = value;
      this.OnPropertyChanged(nameof (Colors));
    }
  }

  public ObservableCollection<MeasureUnit> MeasureUnits
  {
    get => this._measureUnits;
    set
    {
      this._measureUnits = value;
      this.OnPropertyChanged(nameof (MeasureUnits));
    }
  }

  public ObservableCollection<Country> Countries
  {
    get => this._countries;
    set
    {
      this._countries = value;
      this.OnPropertyChanged(nameof (Countries));
    }
  }

  public ObservableCollection<Department> Departments
  {
    get => this._departments;
    set
    {
      this._departments = value;
      this.OnPropertyChanged(nameof (Departments));
    }
  }

  public ObservableCollection<Customer> Customers
  {
    get => this._customers;
    set
    {
      this._customers = value;
      this.OnPropertyChanged(nameof (Customers));
    }
  }

  public ObservableCollection<SizeByGroupGen2DTO> SizeByGroupGen2
  {
    get => this._sizeByGroupGen2;
    set
    {
      this._sizeByGroupGen2 = value;
      this.OnPropertyChanged(nameof (SizeByGroupGen2));
    }
  }

  public ObservableCollection<ColorByGroupGen2DTO> ColorByGroupGen2
  {
    get => this._colorByGroupGen2;
    set
    {
      this._colorByGroupGen2 = value;
      this.OnPropertyChanged(nameof (ColorByGroupGen2));
    }
  }

  public ObservableCollection<Composition> Compositions
  {
    get => this._compositions;
    set
    {
      this._compositions = value;
      this.OnPropertyChanged(nameof (Compositions));
    }
  }

  public ObservableCollection<EmployeeGroup> EmployeeGroups
  {
    get => this._employeeGroups;
    set
    {
      this._employeeGroups = value;
      this.OnPropertyChanged(nameof (EmployeeGroups));
    }
  }

  public EmployeeGroup SelectedEmployeeGroup
  {
    get => this.selectedEmployeeGroup;
    set
    {
      this.selectedEmployeeGroup = value;
      this.OnPropertyChanged(nameof (SelectedEmployeeGroup));
      this.SetEmployeesPerGroup();
    }
  }

  public ObservableCollection<Employee> AllEmployees
  {
    get => this._employees;
    set
    {
      this._employees = value;
      this.OnPropertyChanged(nameof (AllEmployees));
    }
  }

  public ObservableCollection<Employee> Debtors
  {
    get => this.debtors;
    set
    {
      this.debtors = value;
      this.OnPropertyChanged(nameof (Debtors));
    }
  }

  public ObservableCollection<Employee> EmployeePerGroup
  {
    get => this.employeePerGroup;
    set
    {
      this.employeePerGroup = value;
      this.OnPropertyChanged(nameof (EmployeePerGroup));
    }
  }

  public ObservableCollection<GroupGen1> GroupGen1s
  {
    get => this._groupGen1s;
    set
    {
      this._groupGen1s = value;
      this.OnPropertyChanged(nameof (GroupGen1s));
    }
  }

  public GroupGen1 SelectedGroupGen1
  {
    get => this._selectedGroupGen1;
    set
    {
      this._selectedGroupGen1 = value;
      this.OnPropertyChanged(nameof (SelectedGroupGen1));
      this.LoadGroupGen2sAsync();
    }
  }

  public ObservableCollection<GroupGen2ByGen1> GroupGen2s
  {
    get => this._groupGen2s;
    set
    {
      this._groupGen2s = value;
      this.OnPropertyChanged(nameof (GroupGen2s));
    }
  }

  public ObservableCollection<Company> Companies
  {
    get => this._companies;
    set
    {
      this._companies = value;
      this.OnPropertyChanged(nameof (Companies));
    }
  }

  public ObservableCollection<Price2DTO> Prices2
  {
    get => this._prices2;
    set
    {
      this._prices2 = value;
      this.OnPropertyChanged(nameof (Prices2));
    }
  }

  public ObservableCollection<Price> Prices
  {
    get => this._prices;
    set
    {
      this._prices = value;
      this.OnPropertyChanged(nameof (Prices));
    }
  }

  public Price SelectedPrice
  {
    get => this._selectedPrice;
    set
    {
      this._selectedPrice = value;
      this.OnPropertyChanged(nameof (SelectedPrice));
    }
  }

  public MSBookViewModel(IUnitOfWork unitWork, ICurrencyTypeService currencyTypeService)
  {
    this._unitWork = unitWork;
    this.CurrencyTypeService = currencyTypeService;
    this.LoadDataAsync();
    this.OpenYeniQiymetler = new RelayCommand((Action<object>) (param => this.LoadPricesAsync()));
    this.SaveCommand = new RelayCommand((Action<object>) (async param => await this.AddGoodsAsync(param)));
  }

  private async void LoadDataAsync()
  {
    await this.LoadGroupGen1sAsync();
    this.LoadGroupGen2sAsync();
    this.Goods = await this._unitWork.GoodsRepository.GetAllGoods();
    this.Sizes = new ObservableCollection<SizeModel>(await this._unitWork.SizeRepository.GetAllSizes());
    this.Colors = new ObservableCollection<Color>(await this._unitWork.ColorRepository.GetAllColors());
    this.LoadCurrencyTypes();
    this.LoadPrices2Async();
    this.LoadPricesAsync();
    this.LoadMSK1Async();
    this.LoadCompaniesAsync();
    this.LoadCustomersAsync();
    this.LoadSizeByGroupGen2Async();
    this.LoadColorByGroupGen2Async();
    this.LoadCompositionsAsync();
    await this.LoadEmployeeGroupsAsync();
    this.LoadEmployeesAsync();
  }

  private async Task AddGoodsAsync(object param) => await this.SaveGood(param);

  private async Task SaveGood(object param)
  {
    try
    {
      (string, string) groupGenId = await this.GetGroupGenId();
      string maxGoodId = await this._unitWork.GoodsRepository.GetMaxGoodId();
      EmilandAtelye.Domain.Models.Goods goods = new EmilandAtelye.Domain.Models.Goods()
      {
        GoodsId = (int.Parse(maxGoodId) + 1).ToString(),
        RegDate = DateTime.Now,
        RegUid = CurrentValues.CurrentUser?.UserName,
        EditDate = new DateTime?(),
        EditUid = (string) null,
        CompanyId = this.SelectedCompany?.CompanyId,
        GoodsShortName = this.CurrentGoods?.GoodsShortName,
        GroupGen1Id = new long?(long.Parse(groupGenId.Item2)),
        GroupGen2Id = new long?(long.Parse(groupGenId.Item1)),
        MeasureId = this.SelectedMeasureUnit?.MeasureId,
        Barcode = this.BarCode ?? (string) null,
        LimitRed = (Decimal?) this.CurrentGoods?.LimitRed,
        LimitBlue = (Decimal?) this.CurrentGoods?.LimitBlue,
        WhPrice = (Decimal?) this.CurrentGoods?.WhPrice,
        CurTypeId = this.SelectedCurrency?.CurTypeId,
        RestManualCount = (Decimal?) this.CurrentGoods?.RestManualCount,
        GoodsCode = this.CurrentGoods?.GoodsCode,
        RestCount = (Decimal?) this.CurrentGoods?.RestCount,
        RowNo = this.CurrentGoods?.RowNo,
        ColumnNo = this.CurrentGoods?.ColumnNo,
        IntGoodsCode = this.CurrentGoods?.IntGoodsCode,
        Note1 = this.CurrentGoods?.Note1,
        GoodsFullName = this.CurrentGoods?.GoodsFullName,
        InternatName = this.CurrentGoods?.InternatName,
        RestStockCount = (Decimal?) this.CurrentGoods?.RestStockCount,
        PartNumYes = (bool?) this.CurrentGoods?.PartNumYes,
        MinMinSellingPrice = (Decimal?) this.CurrentGoods?.MinMinSellingPrice,
        Status = 0,
        Store1 = (float?) this.CurrentGoods?.Store1,
        Store2 = (float?) this.CurrentGoods?.Store2,
        Store3 = (float?) this.CurrentGoods?.Store3,
        Store4 = (float?) this.CurrentGoods?.Store4,
        Store5 = (float?) this.CurrentGoods?.Store5,
        Store6 = (float?) this.CurrentGoods?.Store6,
        Store7 = (float?) this.CurrentGoods?.Store7,
        SpodkN = this.CurrentGoods?.SpodkN,
        SpuquN = this.CurrentGoods?.SpuquN,
        BarcodeTerminal = this.CurrentGoods?.BarcodeTerminal,
        SuiteSp = (Decimal?) this.CurrentGoods?.SuiteSp,
        JacketSp = (Decimal?) this.CurrentGoods?.JacketSp,
        PantsSp = (Decimal?) this.CurrentGoods?.PantsSp,
        SmokingSp = (Decimal?) this.CurrentGoods?.SmokingSp,
        WaistcoatSp = (Decimal?) this.CurrentGoods?.WaistcoatSp,
        SuiteSmokingSp = (Decimal?) this.CurrentGoods?.SuiteSmokingSp,
        SkirtSp = (Decimal?) this.CurrentGoods?.SkirtSp,
        ColorId = (int?) this.CurrentGoods?.ColorId,
        SizeId = (int?) this.CurrentGoods?.SizeId,
        CompositionId1 = (int?) this.CurrentGoods?.CompositionId1,
        CompositionId1P = (float?) this.CurrentGoods?.CompositionId1P,
        CompositionId2 = (int?) this.CurrentGoods?.CompositionId2,
        CompositionId2P = (float?) this.CurrentGoods?.CompositionId2P,
        CompositionId3 = (int?) this.CurrentGoods?.CompositionId3,
        CompositionId3P = (float?) this.CurrentGoods?.CompositionId3P,
        SendArchive = (bool?) this.CurrentGoods?.SendArchive,
        Ordered = (bool?) this.CurrentGoods?.Ordered,
        SuiteSpRus = (Decimal?) this.CurrentGoods?.SuiteSpRus,
        JacketSpRus = (Decimal?) this.CurrentGoods?.JacketSpRus,
        PantsSpRus = (Decimal?) this.CurrentGoods?.PantsSpRus,
        SmokingSpRus = (Decimal?) this.CurrentGoods?.SmokingSpRus
      };
      if (this.CurrentGoods == null || this.CurrentGoods.GoodsCode == null || this.BarCode == null || this.SelectedCompany == null)
      {
        int num1 = (int) MessageBox.Show("Barkodu, Firma adını və Daxili kodu hər birini daxil edin.");
      }
      else
      {
        if (await this._unitWork.GoodsRepository.AddGoodsAsync(goods) == 1)
        {
          int num2 = (int) MessageBox.Show("Məhsul əlavə olundu");
          this.ResetForm();
        }
        else
        {
          int num3 = (int) MessageBox.Show("Məhsul əlavə olunarkən səhv baş verdi");
        }
        groupGenId = ();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error: " + ex?.ToString());
    }
  }

  public async Task<(string, string)> GetGroupGenId()
  {
    string str1 = "0000";
    string str2 = "00";
    if (this.kost != null)
    {
      str1 = "12006";
      str2 = "12";
    }
    else if (this.koy != null)
    {
      str1 = "13001";
      str2 = "13";
    }
    else if (this.zap != null)
    {
      str1 = "13004";
      str2 = "13";
    }
    else if (this.qals != null)
    {
      str1 = "13003";
      str2 = "13";
    }
    else if (this.yayl != null)
    {
      str1 = "13009";
      str2 = "13";
    }
    else if (this.jilet != null)
    {
      str1 = "12011";
      str2 = "12";
    }
    else if (this.corab != null)
    {
      str1 = "13008";
      str2 = "13";
    }
    else if (this.ayag != null)
    {
      str1 = "13002";
      str2 = "13";
    }
    else if (this.kemer != null)
    {
      str1 = "13007";
      str2 = "13";
    }
    else if (this.qurs != null)
    {
      str1 = "13005";
      str2 = "13";
    }
    else if (this.bab != null)
    {
      str1 = "13006";
      str2 = "13";
    }
    return (str1, str2);
  }

  private void ResetForm()
  {
    this.CurrentGoods = new EmilandAtelye.Domain.Models.Goods();
    this.SelectedCompany = (Company) null;
    this.SelectedMeasureUnit = (MeasureUnit) null;
    this.SelectedCurrency = (CurrencyType) null;
    this.BarCode = string.Empty;
    this.Kost = string.Empty;
    this.Koy = string.Empty;
    this.Zap = string.Empty;
    this.Qals = string.Empty;
    this.Yayl = string.Empty;
    this.Jilet = string.Empty;
    this.Corab = string.Empty;
    this.Ayag = string.Empty;
    this.Kemer = string.Empty;
    this.Qurs = string.Empty;
    this.Bab = string.Empty;
  }

  private async Task LoadMSK1Async()
  {
    this.MeasureUnits = new ObservableCollection<MeasureUnit>(await this._unitWork.MeasureUnitRepository.GetAllMeasureUnits());
    this.SelectedMeasureUnit = this.MeasureUnits.FirstOrDefault<MeasureUnit>();
    this.Countries = new ObservableCollection<Country>(await this._unitWork.CountryRepository.GetAllCountries());
    this.Departments = new ObservableCollection<Department>(await this._unitWork.DepartmentRepository.GetAllDepartmentsAsync());
  }

  private async Task LoadCustomersAsync()
  {
    this.Customers = new ObservableCollection<Customer>(await this._unitWork.CustomerRepository.GetAllCustomers());
  }

  private async Task LoadSizeByGroupGen2Async()
  {
    IEnumerable<GroupGen2> groupGen2List = await this._unitWork.GroupGen2Repository.GetAllGroupGen2Async();
    IEnumerable<EmilandAtelye.Domain.Models.SizeByGroupGen2> groupGen2IdsAsync = await this._unitWork.SizeRepository.GetSizesByGroupGen2IdsAsync(groupGen2List.Select<GroupGen2, int>((Func<GroupGen2, int>) (g => g.GroupGen2Id)).ToList<int>());
    List<SizeByGroupGen2DTO> list = new List<SizeByGroupGen2DTO>();
    foreach (GroupGen2 groupGen2 in groupGen2List)
    {
      GroupGen2 item = groupGen2;
      foreach (EmilandAtelye.Domain.Models.SizeByGroupGen2 sizeByGroupGen2 in groupGen2IdsAsync.Where<EmilandAtelye.Domain.Models.SizeByGroupGen2>((Func<EmilandAtelye.Domain.Models.SizeByGroupGen2, bool>) (s => s.GroupGen2Id == (long) item.GroupGen2Id)))
      {
        SizeByGroupGen2DTO sizeByGroupGen2Dto = new SizeByGroupGen2DTO()
        {
          SizeId = sizeByGroupGen2.SizeId,
          Size = sizeByGroupGen2.SIZE,
          SizeRow = sizeByGroupGen2.SizeRow,
          GroupGen2Name = item.GroupGen2Name
        };
        list.Add(sizeByGroupGen2Dto);
      }
    }
    this.SizeByGroupGen2 = new ObservableCollection<SizeByGroupGen2DTO>(list);
    groupGen2List = (IEnumerable<GroupGen2>) null;
  }

  private async Task LoadColorByGroupGen2Async()
  {
    IEnumerable<GroupGen2> groupGen2List = await this._unitWork.GroupGen2Repository.GetAllGroupGen2Async();
    IEnumerable<EmilandAtelye.Domain.Models.ColorByGroupGen2> groupGen2IdsAsync = await this._unitWork.ColorRepository.GetColorsByGroupGen2IdsAsync(groupGen2List.Select<GroupGen2, int>((Func<GroupGen2, int>) (g => g.GroupGen2Id)).ToList<int>());
    List<ColorByGroupGen2DTO> list = new List<ColorByGroupGen2DTO>();
    foreach (GroupGen2 groupGen2 in groupGen2List)
    {
      GroupGen2 item = groupGen2;
      foreach (EmilandAtelye.Domain.Models.ColorByGroupGen2 colorByGroupGen2 in groupGen2IdsAsync.Where<EmilandAtelye.Domain.Models.ColorByGroupGen2>((Func<EmilandAtelye.Domain.Models.ColorByGroupGen2, bool>) (c => c.GroupGen2Id == (long) item.GroupGen2Id)))
      {
        ColorByGroupGen2DTO colorByGroupGen2Dto = new ColorByGroupGen2DTO()
        {
          ColorId = colorByGroupGen2.ColorId,
          ColorName = colorByGroupGen2.ColorName,
          ColorRow = colorByGroupGen2.ColorRow,
          GroupGen2Name = item.GroupGen2Name
        };
        list.Add(colorByGroupGen2Dto);
      }
    }
    this.ColorByGroupGen2 = new ObservableCollection<ColorByGroupGen2DTO>(list);
    groupGen2List = (IEnumerable<GroupGen2>) null;
  }

  private async Task LoadCompositionsAsync()
  {
    this.Compositions = new ObservableCollection<Composition>(await this._unitWork.CompositionRepository.GetAllCompositions());
  }

  private async Task LoadEmployeeGroupsAsync()
  {
    this.EmployeeGroups = new ObservableCollection<EmployeeGroup>(await this._unitWork.EmployeeGroupRepository.GetAllEmployeeGroups());
    this.SelectedEmployeeGroup = this.EmployeeGroups.FirstOrDefault<EmployeeGroup>();
  }

  private async Task LoadEmployeesAsync()
  {
    this.AllEmployees = new ObservableCollection<Employee>(await this._unitWork.EmployeeRepository.GetAllEmployees());
    this.Debtors = new ObservableCollection<Employee>(await this._unitWork.EmployeeRepository.GetDebtors());
    this.EmployeePerGroup = new ObservableCollection<Employee>((IEnumerable<Employee>) await this._unitWork.EmployeeRepository.GetEmployeesByGroupId(this.SelectedEmployeeGroup.EmployeeGroupId));
  }

  private async Task LoadGroupGen1sAsync()
  {
    this.GroupGen1s = new ObservableCollection<GroupGen1>(await this._unitWork.GroupGen1Repository.GetAllGroupGen1s());
    this.SelectedGroupGen1 = this.GroupGen1s.FirstOrDefault<GroupGen1>();
  }

  private async Task LoadGroupGen2sAsync()
  {
    this.GroupGen2s = new ObservableCollection<GroupGen2ByGen1>(await this._unitWork.GroupGen2Repository.GetGroupGen2ByGroupGen1Id((int) this.SelectedGroupGen1.GroupGen1Id));
  }

  private async Task LoadCompaniesAsync()
  {
    this.Companies = new ObservableCollection<Company>(await this._unitWork.CompanyRepository.GetAllCompanies());
  }

  private async Task LoadPrices2Async()
  {
    foreach (Price2 item in (Collection<Price2>) new ObservableCollection<Price2>(await this._unitWork.PriceRepository.GetAllPrices()))
    {
      ObservableCollection<Price2DTO> observableCollection = this.Prices2;
      Price2DTO price2Dto1 = new Price2DTO();
      Price2DTO price2Dto2 = price2Dto1;
      price2Dto2.GroupGen2Name = await this._unitWork.GroupGen2Repository.GetGroupGen2NameByIdAsync((int) item.GroupGen2Id);
      price2Dto1.Barcode = string.Empty;
      price2Dto1.SellingPrice = item.SellingPrice;
      price2Dto1.SellingPrice_Rus = item.SellingPrice_Rus;
      observableCollection.Add(price2Dto1);
      observableCollection = (ObservableCollection<Price2DTO>) null;
      price2Dto2 = (Price2DTO) null;
      price2Dto1 = (Price2DTO) null;
    }
  }

  private async Task LoadPricesAsync()
  {
    this.Prices = new ObservableCollection<Price>(await this._unitWork.PriceRepository.GetPrices());
    this.SelectedPrice = this.Prices.FirstOrDefault<Price>();
  }

  private async Task LoadCurrencyTypes()
  {
    IEnumerable<CurrencyType> allCurrencyTypes = await this.CurrencyTypeService.GetAllCurrencyTypes();
    this.SelectedCurrency = allCurrencyTypes.FirstOrDefault<CurrencyType>();
    this.CurrencyTypes = new ObservableCollection<CurrencyType>(allCurrencyTypes);
  }

  private async Task SetEmployeesPerGroup()
  {
    this.EmployeePerGroup = new ObservableCollection<Employee>((IEnumerable<Employee>) await this._unitWork.EmployeeRepository.GetEmployeesByGroupId(this.SelectedEmployeeGroup.EmployeeGroupId));
  }
}
