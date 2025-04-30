// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.IroningDailyViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class IroningDailyViewModel : BaseViewModel
{
  private DateTime selectedDate;
  private ObservableCollection<EmilandAtelye.Domain.Models.IroningDaily> _ironingDaily;

  private IUnitOfWork _unitOfWork { get; set; }

  public DateTime SelectedDate
  {
    get => this.selectedDate;
    set
    {
      this.selectedDate = value;
      this.OnPropertyChanged(nameof (SelectedDate));
      this.Search((object) 1);
    }
  }

  public ObservableCollection<EmilandAtelye.Domain.Models.IroningDaily> IroningDaily
  {
    get => this._ironingDaily;
    set
    {
      this._ironingDaily = value;
      this.OnPropertyChanged(nameof (IroningDaily));
    }
  }

  public RelayCommand NextDayCommand { get; set; }

  public RelayCommand PreviousDayCommand { get; set; }

  public IroningDailyViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.SelectedDate = DateTime.Now;
    this.NextDayCommand = new RelayCommand((Action<object>) (async param => await this.SwitchNextDay(param)));
    this.PreviousDayCommand = new RelayCommand((Action<object>) (async param => await this.SwitchPreviousDay(param)));
  }

  public async Task Search(object param)
  {
    try
    {
      this.IroningDaily = new ObservableCollection<EmilandAtelye.Domain.Models.IroningDaily>(await this._unitOfWork.IroningRepository.GetIroningDaily(this.SelectedDate));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
  }

  public async Task SwitchNextDay(object param)
  {
    this.SelectedDate = this.SelectedDate.AddDays(1.0);
  }

  public async Task SwitchPreviousDay(object param)
  {
    this.SelectedDate = this.SelectedDate.AddDays(-1.0);
  }
}
