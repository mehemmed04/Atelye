// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.CashboxViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class CashboxViewModel : BaseViewModel
{
  private DateTime? selectedDate;
  private DateTime? previousDay;
  private DailyCashBox _dailyCashBox = new DailyCashBox();
  private DailyCashBox _previousDayDailyCashBox = new DailyCashBox();
  private ObservableCollection<DailyExpense> _dailyExpenses;
  private ObservableCollection<DailyExpense> _previousDayDailyExpenses;

  public ICommand OpenInsertExpenseView { get; }

  public ICommand OpenInsertExpenseViewYesterday { get; }

  private IUnitOfWork _unitOfWork { get; set; }

  public DateTime? SelectedDate
  {
    get => this.selectedDate;
    set
    {
      this.selectedDate = value;
      this.OnPropertyChanged(nameof (SelectedDate));
      this.UpdatePreviousDay();
      this.LoadData();
    }
  }

  public DateTime? PreviousDay
  {
    get => this.previousDay;
    set
    {
      this.previousDay = value;
      this.OnPropertyChanged(nameof (PreviousDay));
    }
  }

  public DailyCashBox DailyCashBox
  {
    get => this._dailyCashBox;
    set
    {
      this._dailyCashBox = value;
      this.OnPropertyChanged(nameof (DailyCashBox));
    }
  }

  public DailyCashBox PreviousDayDailyCashBox
  {
    get => this._previousDayDailyCashBox;
    set
    {
      this._previousDayDailyCashBox = value;
      this.OnPropertyChanged(nameof (PreviousDayDailyCashBox));
    }
  }

  public ObservableCollection<DailyExpense> DailyExpenses
  {
    get => this._dailyExpenses;
    set
    {
      this._dailyExpenses = value;
      this.OnPropertyChanged(nameof (DailyExpenses));
    }
  }

  public ObservableCollection<DailyExpense> PreviousDayDailyExpenses
  {
    get => this._previousDayDailyExpenses;
    set
    {
      this._previousDayDailyExpenses = value;
      this.OnPropertyChanged(nameof (PreviousDayDailyExpenses));
    }
  }

  public CashboxViewModel(IUnitOfWork unitOfWork)
  {
    this.OpenInsertExpenseView = (ICommand) new RelayCommand((Action<object>) (async param => await this.AddExpense()));
    this.OpenInsertExpenseViewYesterday = (ICommand) new RelayCommand((Action<object>) (async param => await this.AddExpenseYesterday()));
    this._unitOfWork = unitOfWork;
    this.SelectedDate = new DateTime?(DateTime.Today);
    this.LoadData();
  }

  private async Task AddExpense()
  {
    CashboxViewModel cashboxViewModel = this;
    DailyExpenseView dailyExpenseView = new DailyExpenseView(cashboxViewModel._unitOfWork, cashboxViewModel.SelectedDate.Value);
    // ISSUE: reference to a compiler-generated method
    dailyExpenseView.Closed += new EventHandler(cashboxViewModel.\u003CAddExpense\u003Eb__35_0);
    dailyExpenseView.Show();
  }

  private async Task AddExpenseYesterday()
  {
    CashboxViewModel cashboxViewModel = this;
    DailyExpenseView dailyExpenseView = new DailyExpenseView(cashboxViewModel._unitOfWork, cashboxViewModel.PreviousDay.Value);
    // ISSUE: reference to a compiler-generated method
    dailyExpenseView.Closed += new EventHandler(cashboxViewModel.\u003CAddExpenseYesterday\u003Eb__36_0);
    dailyExpenseView.Show();
  }

  private async void LoadData()
  {
    await this.LoadDailyCashBoxAsync();
    await this.LoadDailyExpensesAsync();
    await this.LoadPreviousDayDailyCashBoxAsync();
    await this.LoadPreviousDayDailyExpensesAsync();
  }

  private async Task LoadDailyCashBoxAsync()
  {
    this.DailyCashBox = await this._unitOfWork.CashboxRepository.GetDailyCashBoxesAsync(this.SelectedDate.Value) ?? new DailyCashBox();
  }

  private async Task LoadDailyExpensesAsync()
  {
    this.DailyExpenses = new ObservableCollection<DailyExpense>(await this._unitOfWork.DailyExpenseRepository.GetDailyExpenseInCashBoxAsync(this.SelectedDate.Value));
  }

  private async Task LoadPreviousDayDailyCashBoxAsync()
  {
    this.PreviousDayDailyCashBox = await this._unitOfWork.CashboxRepository.GetDailyCashBoxesAsync(this.PreviousDay.Value) ?? new DailyCashBox();
  }

  private async Task LoadPreviousDayDailyExpensesAsync()
  {
    this.PreviousDayDailyExpenses = new ObservableCollection<DailyExpense>(await this._unitOfWork.DailyExpenseRepository.GetDailyExpenseInCashBoxAsync(this.PreviousDay.Value));
  }

  private void UpdatePreviousDay()
  {
    if (this.SelectedDate.HasValue)
      this.PreviousDay = new DateTime?(this.SelectedDate.Value.AddDays(-1.0));
    else
      this.PreviousDay = new DateTime?(new DateTime().AddDays(-1.0));
  }
}
