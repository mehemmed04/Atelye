// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.MainViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.Constants;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.Views;
using EmilandAtelye.Domain.Views.Cashboxs;
using EmilandAtelye.Domain.Views.Expenses;
using EmilandAtelye.Domain.Views.Ironings;
using EmilandAtelye.Domain.Views.OrderViews;
using EmilandAtelye.Services.Abstract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class MainViewModel : BaseViewModel
{
  private static DispatcherTimer? _idleTimer;
  private string? username;
  private Department? _selectedDepartment;
  private UserControl _currentView;

  private string BaseTitle { get; set; } = "Emiland Atelye - ";

  private IUnitOfWork UnitOfWork { get; set; }

  private IOrderService OrderService { get; set; }

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  private MainWindow MainWindow { get; set; }

  public string? Username
  {
    get => this.username;
    set
    {
      this.username = value;
      this.NotifyPropertyChanged(nameof (Username));
    }
  }

  public Department? SelectedDepartment
  {
    get => this._selectedDepartment;
    set
    {
      this._selectedDepartment = value;
      if (this._selectedDepartment != null && value != null)
        this._selectedDepartment.DepartmentName = "Filial: " + value.DepartmentName;
      this.OnPropertyChanged(nameof (SelectedDepartment));
    }
  }

  public UserControl CurrentView
  {
    get => this._currentView;
    set
    {
      this._currentView = value;
      this.OnPropertyChanged(nameof (CurrentView));
    }
  }

  public RelayCommand MsBookCommand { get; set; }

  public RelayCommand StockCommand { get; set; }

  public RelayCommand MeasurementCommand { get; set; }

  public RelayCommand ChangesCommand { get; set; }

  public RelayCommand Ironing1Command { get; set; }

  public RelayCommand Ironing2Command { get; set; }

  public RelayCommand IroningDailyCommand { get; set; }

  public RelayCommand DebtsCommand { get; set; }

  public RelayCommand HandoverCommand { get; set; }

  public RelayCommand CashboxCommand { get; set; }

  public RelayCommand ExpensesCommand { get; set; }

  public RelayCommand OrderTCommand { get; set; }

  public RelayCommand OrderFCommand { get; set; }

  public RelayCommand OrderNCommand { get; set; }

  public RelayCommand OrderHCCommand { get; set; }

  public RelayCommand OrderMICommand { get; set; }

  public RelayCommand OrderMKCommand { get; set; }

  public RelayCommand CashboxMICommand { get; set; }

  public RelayCommand ExpenseMICommand { get; set; }

  public MainViewModel(
    MainWindow mainWindow,
    Department? selectedDepartment,
    User user,
    IUnitOfWork unitOfWork,
    ICurrencyTypeService currencyTypeService,
    IOrderService orderService)
  {
    MainViewModel._idleTimer = new DispatcherTimer();
    int idleTime = user.IdleTime;
    MainViewModel._idleTimer.Interval = TimeSpan.FromSeconds((double) idleTime);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    MainViewModel._idleTimer.Tick += MainViewModel.\u003C\u003EO.\u003C0\u003E__IdleTimer_Tick ?? (MainViewModel.\u003C\u003EO.\u003C0\u003E__IdleTimer_Tick = new EventHandler(MainViewModel.IdleTimer_Tick));
    MainViewModel._idleTimer.IsEnabled = idleTime != 0;
    this.SelectedDepartment = selectedDepartment;
    this.MainWindow = mainWindow;
    this.username = user.UserName;
    this.UnitOfWork = unitOfWork;
    this.CurrencyTypeService = currencyTypeService;
    this.MsBookCommand = new RelayCommand(new Action<object>(this.OpenMsBook));
    this.StockCommand = new RelayCommand(new Action<object>(this.OpenStock));
    this.MeasurementCommand = new RelayCommand(new Action<object>(this.OpenMeasurement));
    this.ChangesCommand = new RelayCommand(new Action<object>(this.OpenChanges));
    this.Ironing1Command = new RelayCommand(new Action<object>(this.OpenIroning1));
    this.Ironing2Command = new RelayCommand(new Action<object>(this.OpenIroning2));
    this.IroningDailyCommand = new RelayCommand(new Action<object>(this.OpenIroningDaily));
    this.DebtsCommand = new RelayCommand(new Action<object>(this.OpenDebts));
    this.HandoverCommand = new RelayCommand(new Action<object>(this.OpenHandover));
    this.CashboxCommand = new RelayCommand(new Action<object>(this.OpenCashbox));
    this.ExpensesCommand = new RelayCommand(new Action<object>(this.OpenExpenses));
    this.OrderTCommand = new RelayCommand(new Action<object>(this.OpenOrderT));
    this.OrderNCommand = new RelayCommand(new Action<object>(this.OpenOrderN));
    this.OrderFCommand = new RelayCommand(new Action<object>(this.OpenOrderF));
    this.OrderHCCommand = new RelayCommand(new Action<object>(this.OpenOrderHc));
    this.OrderMICommand = new RelayCommand(new Action<object>(this.OpenOrderMi));
    this.OrderMKCommand = new RelayCommand(new Action<object>(this.OpenOrderMk));
    this.CashboxMICommand = new RelayCommand(new Action<object>(this.OpenCashboxMi));
    this.ExpenseMICommand = new RelayCommand(new Action<object>(this.OpenExpenseMi));
    this.OrderService = orderService;
  }

  private static void IdleTimer_Tick(object? sender, EventArgs e)
  {
    foreach (Window window in Application.Current.Windows)
      window.Close();
  }

  private static void ResetIdleTimer()
  {
    MainViewModel._idleTimer?.Stop();
    MainViewModel._idleTimer?.Start();
  }

  public static void OnUserActivity(object sender, EventArgs e)
  {
    DispatcherTimer idleTimer = MainViewModel._idleTimer;
    if (idleTimer == null || !idleTimer.IsEnabled)
      return;
    MainViewModel.ResetIdleTimer();
  }

  private void OpenMsBook(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.MalinPasportu, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "MS Kitabı";
    this.CurrentView = (UserControl) new MSBookView();
    this.CurrentView.DataContext = (object) new MSBookViewModel(this.UnitOfWork, this.CurrencyTypeService);
  }

  private void OpenCashboxMi(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.KassaMI, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Kassa MI";
    this.CurrentView = (UserControl) new CashboxMIView();
    this.CurrentView.DataContext = (object) new CashboxMIViewModel(this.UnitOfWork);
  }

  private void OpenExpenseMi(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.XercMI, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Xərc MI";
    this.CurrentView = (UserControl) new ExpensesMIView();
    this.CurrentView.DataContext = (object) new ExpensesMIViewModel(this.UnitOfWork);
  }

  private void OpenStock(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.AnbarQaligi, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Anbar qalığı";
    this.CurrentView = (UserControl) new StockView();
    this.CurrentView.DataContext = (object) new StockViewModel(this.UnitOfWork);
  }

  private void OpenOrderT(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerT, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər T";
    this.CurrentView = (UserControl) new OrderT();
    this.CurrentView.DataContext = (object) new OrderTViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenOrderN(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerN, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər N";
    this.CurrentView = (UserControl) new OrderN();
    this.CurrentView.DataContext = (object) new OrderNViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenOrderF(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerF, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər F";
    this.CurrentView = (UserControl) new OrderF();
    this.CurrentView.DataContext = (object) new OrderFViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenOrderHc(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerHC, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər HC";
    this.CurrentView = (UserControl) new OrderHC();
    this.CurrentView.DataContext = (object) new OrderHCViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenOrderMi(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerMI, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər MI";
    this.CurrentView = (UserControl) new OrderMI();
    this.CurrentView.DataContext = (object) new OrderMIViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenOrderMk(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.SifarislerMK, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Sifarişlər MK";
    this.CurrentView = (UserControl) new OrderMK();
    this.CurrentView.DataContext = (object) new OrderMKViewModel(this.UnitOfWork, this.CurrencyTypeService, this.OrderService);
  }

  private void OpenMeasurement(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Olculer, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Ölçülər";
    this.CurrentView = (UserControl) new MeasurementView();
    this.CurrentView.DataContext = (object) new MeasurementViewModel(this.UnitOfWork);
  }

  private void OpenChanges(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Deyishiklikler, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Dəyişikliklər";
    this.CurrentView = (UserControl) new ChangesView();
    this.CurrentView.DataContext = (object) new ChangesViewModel(this.UnitOfWork);
  }

  private void OpenIroning1(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Utuleme1, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    Ironing1View ironing1View = new Ironing1View();
    ironing1View.DataContext = (object) new Ironing1ViewModel(this.UnitOfWork);
    ironing1View.Show();
  }

  private void OpenIroning2(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Utuleme2, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    Ironing2View ironing2View = new Ironing2View();
    ironing2View.DataContext = (object) new Ironing2ViewModel(this.UnitOfWork);
    ironing2View.Show();
  }

  private void OpenIroningDaily(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.UtulemeGunluk, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Ütüləmə günlük";
    this.CurrentView = (UserControl) new IroningDailyView();
    this.CurrentView.DataContext = (object) new IroningDailyViewModel(this.UnitOfWork);
  }

  private void OpenDebts(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Borclar, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Borclar";
    this.CurrentView = (UserControl) new DebtsView();
    this.CurrentView.DataContext = (object) new DebtsViewModel(this.UnitOfWork);
  }

  private void OpenHandover(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Tehvil, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Təhvil";
    this.CurrentView = (UserControl) new HandoverView();
    this.CurrentView.DataContext = (object) new HandoverViewModel(this.UnitOfWork);
  }

  private void OpenCashbox(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Kassa, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Kassa";
    this.CurrentView = (UserControl) new CashboxView();
    this.CurrentView.DataContext = (object) new CashboxViewModel(this.UnitOfWork);
  }

  private void OpenExpenses(object parameter)
  {
    if (!Permissions.HasReadPermission(ViewTag.Xerc, CurrentValues.CurrentUser?.UserName ?? ""))
      return;
    this.MainWindow.Title = this.BaseTitle + "Xərc";
    this.CurrentView = (UserControl) new ExpenseView();
    this.CurrentView.DataContext = (object) new ExpensesViewModel(this.UnitOfWork);
  }
}
