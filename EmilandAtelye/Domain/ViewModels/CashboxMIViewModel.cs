// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.CashboxMIViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class CashboxMIViewModel : BaseViewModel
{
  private DateTime? selectedDate;
  private DateTime? previousDay;
  private DailyCashBoxMI _dailyCashBoxMI = new DailyCashBoxMI();
  private DailyCashBoxMI _previousDayDailyCashBoxMI = new DailyCashBoxMI();
  private ObservableCollection<DailyExpense> _dailyExpenses;
  private ObservableCollection<DailyExpense> _previousDayDailyExpenses;

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

  public DailyCashBoxMI DailyCashBoxMI
  {
    get => this._dailyCashBoxMI;
    set
    {
      this._dailyCashBoxMI = value;
      this.OnPropertyChanged(nameof (DailyCashBoxMI));
    }
  }

  public DailyCashBoxMI PreviousDayDailyCashBoxMI
  {
    get => this._previousDayDailyCashBoxMI;
    set
    {
      this._previousDayDailyCashBoxMI = value;
      this.OnPropertyChanged(nameof (PreviousDayDailyCashBoxMI));
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

  public CashboxMIViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.SelectedDate = new DateTime?(DateTime.Today);
    this.LoadData();
  }

  private async void LoadData()
  {
    await this.LoadDailyCashBoxMIAsync();
    await this.LoadDailyExpensesMIAsync();
    await this.LoadPreviousDayDailyCashBoxMIAsync();
    await this.LoadPreviousDayDailyExpensesMIAsync();
  }

  private async Task LoadDailyCashBoxMIAsync()
  {
    this.DailyCashBoxMI = await this._unitOfWork.CashboxRepository.GetDailyCashBoxesMIAsync(this.SelectedDate.Value) ?? new DailyCashBoxMI();
  }

  private async Task LoadDailyExpensesMIAsync()
  {
    this.DailyExpenses = new ObservableCollection<DailyExpense>(await this._unitOfWork.DailyExpenseRepository.GetDailyExpenseInCashBoxMIAsync(this.SelectedDate.Value));
  }

  private async Task LoadPreviousDayDailyCashBoxMIAsync()
  {
    this.PreviousDayDailyCashBoxMI = await this._unitOfWork.CashboxRepository.GetDailyCashBoxesMIAsync(this.PreviousDay.Value) ?? new DailyCashBoxMI();
  }

  private async Task LoadPreviousDayDailyExpensesMIAsync()
  {
    this.PreviousDayDailyExpenses = new ObservableCollection<DailyExpense>(await this._unitOfWork.DailyExpenseRepository.GetDailyExpenseInCashBoxMIAsync(this.PreviousDay.Value));
  }

  private void UpdatePreviousDay()
  {
    if (this.SelectedDate.HasValue)
      this.PreviousDay = new DateTime?(this.SelectedDate.Value.AddDays(-1.0));
    else
      this.PreviousDay = new DateTime?(new DateTime().AddDays(-1.0));
  }
}
