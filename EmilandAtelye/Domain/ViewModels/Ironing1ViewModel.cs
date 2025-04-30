// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.Ironing1ViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class Ironing1ViewModel : BaseViewModel
{
  private DateTime _selectedDate;
  private ObservableCollection<Ironing1> _ironings;
  private ObservableCollection<Ironing1> _ironingsDateTimeAddDaysOne;
  private ObservableCollection<Ironing1> _ironingsDateTimeAddDaysTwo;
  private CustomerIroningDetail _selectedCustomerIroningDetail;
  private Ironing1? _selectedIroningItem1;
  private Ironing1? _selectedIroningItem2;
  private Ironing1? _selectedIroningItem3;
  private string codeText;
  private string nameText;
  private string surNameText;
  private readonly List<string> DepartsUsers = new List<string>()
  {
    "MagazaMS",
    "Magaza1",
    "Magaza2",
    "n",
    "f",
    "hc"
  };

  private IUnitOfWork _unitOfWork { get; set; }

  public RelayCommand NextDayCommand { get; set; }

  public RelayCommand PreviousDayCommand { get; set; }

  public RelayCommand ResetCommand { get; set; }

  public RelayCommand PlanlamaCommand { get; set; }

  public RelayCommand KesimCommand { get; set; }

  public RelayCommand SonyoxlamaCommand { get; set; }

  public RelayCommand Hazir1Command { get; set; }

  public RelayCommand Hazir2Command { get; set; }

  public DateTime SelectedDate
  {
    get => this._selectedDate;
    set
    {
      this._selectedDate = value;
      this.OnPropertyChanged(nameof (SelectedDate));
      this.LoadIronings((object) 1).GetAwaiter();
    }
  }

  public ObservableCollection<Ironing1> IroningsDateTimeNow
  {
    get => this._ironings;
    set
    {
      int num = 0;
      foreach (Ironing1 ironing1 in (Collection<Ironing1>) value)
        ironing1.Number = ++num;
      this._ironings = value;
      this.OnPropertyChanged(nameof (IroningsDateTimeNow));
    }
  }

  public ObservableCollection<Ironing1> IroningsDateTimeAddDaysOne
  {
    get => this._ironingsDateTimeAddDaysOne;
    set
    {
      int num = 0;
      foreach (Ironing1 ironing1 in (Collection<Ironing1>) value)
        ironing1.Number = ++num;
      this._ironingsDateTimeAddDaysOne = value;
      this.OnPropertyChanged(nameof (IroningsDateTimeAddDaysOne));
    }
  }

  public ObservableCollection<Ironing1> IroningsDateTimeAddDaysTwo
  {
    get => this._ironingsDateTimeAddDaysTwo;
    set
    {
      int num = 0;
      foreach (Ironing1 ironing1 in (Collection<Ironing1>) value)
        ironing1.Number = ++num;
      this._ironingsDateTimeAddDaysTwo = value;
      this.OnPropertyChanged(nameof (IroningsDateTimeAddDaysTwo));
    }
  }

  public CustomerIroningDetail SelectedCustomerIroningDetail
  {
    get => this._selectedCustomerIroningDetail;
    set
    {
      this._selectedCustomerIroningDetail = value;
      this.OnPropertyChanged(nameof (SelectedCustomerIroningDetail));
    }
  }

  public Ironing1? SelectedIroningItem1
  {
    get => this._selectedIroningItem1;
    set
    {
      if (this._selectedIroningItem1 == value)
        return;
      this._selectedIroningItem1 = value;
      this.OnPropertyChanged(nameof (SelectedIroningItem1));
      if (value != null)
      {
        this.SelectedIroningItem2 = (Ironing1) null;
        this.SelectedIroningItem3 = (Ironing1) null;
      }
      this.LoadSelectedIroningItemAsync();
    }
  }

  public Ironing1? SelectedIroningItem2
  {
    get => this._selectedIroningItem2;
    set
    {
      if (this._selectedIroningItem2 == value)
        return;
      this._selectedIroningItem2 = value;
      this.OnPropertyChanged(nameof (SelectedIroningItem2));
      if (value != null)
      {
        this.SelectedIroningItem1 = (Ironing1) null;
        this.SelectedIroningItem3 = (Ironing1) null;
      }
      this.LoadSelectedIroningItemAsync();
    }
  }

  public Ironing1? SelectedIroningItem3
  {
    get => this._selectedIroningItem3;
    set
    {
      if (this._selectedIroningItem3 == value)
        return;
      this._selectedIroningItem3 = value;
      this.OnPropertyChanged(nameof (SelectedIroningItem3));
      if (value != null)
      {
        this.SelectedIroningItem1 = (Ironing1) null;
        this.SelectedIroningItem2 = (Ironing1) null;
      }
      this.LoadSelectedIroningItemAsync();
    }
  }

  public string CodeText
  {
    get => this.codeText;
    set
    {
      this.codeText = value;
      this.OnPropertyChanged(nameof (CodeText));
      this.SearchText();
    }
  }

  public string NameText
  {
    get => this.nameText;
    set
    {
      this.nameText = value;
      this.OnPropertyChanged(nameof (NameText));
      this.SearchText();
    }
  }

  public string SurNameText
  {
    get => this.surNameText;
    set
    {
      this.surNameText = value;
      this.OnPropertyChanged(nameof (SurNameText));
      this.SearchText();
    }
  }

  public IEnumerable<Ironing1> SearchedIronings1 { get; set; }

  public IEnumerable<Ironing1> SearchedIronings2 { get; set; }

  public IEnumerable<Ironing1> SearchedIronings3 { get; set; }

  public async Task LoadSelectedIroningItemAsync()
  {
    CustomerIroningDetail customerIroningDetail = (CustomerIroningDetail) null;
    if (this.SelectedIroningItem1 != null)
      customerIroningDetail = await this._unitOfWork.IroningRepository.GetCustomerIroningDetail(this.SelectedIroningItem1.CustomerId);
    else if (this.SelectedIroningItem2 != null)
      customerIroningDetail = await this._unitOfWork.IroningRepository.GetCustomerIroningDetail(this.SelectedIroningItem2.CustomerId);
    else if (this.SelectedIroningItem3 != null)
      customerIroningDetail = await this._unitOfWork.IroningRepository.GetCustomerIroningDetail(this.SelectedIroningItem3.CustomerId);
    if (customerIroningDetail == null)
      return;
    this.SelectedCustomerIroningDetail = customerIroningDetail ?? new CustomerIroningDetail();
  }

  public Ironing1ViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.SelectedDate = DateTime.Now;
    this.NextDayCommand = new RelayCommand((Action<object>) (async param => this.SwitchNextDay(param)));
    this.PreviousDayCommand = new RelayCommand((Action<object>) (async param => this.SwitchPreviousDay(param)));
    this.ResetCommand = new RelayCommand((Action<object>) (async param => await this.Reset(param)));
    this.PlanlamaCommand = new RelayCommand((Action<object>) (async param => this.UpdateIroning(1)), (Predicate<object>) (param => CurrentValues.CurrentUser?.UserName != "kesim1" && !this.DepartsUsers.Contains(CurrentValues.CurrentUser?.UserName)));
    this.KesimCommand = new RelayCommand((Action<object>) (async param => this.UpdateIroning(2)), (Predicate<object>) (param => !this.DepartsUsers.Contains(CurrentValues.CurrentUser?.UserName)));
    this.Hazir1Command = new RelayCommand((Action<object>) (async param => this.UpdateIroning(3)), (Predicate<object>) (param => CurrentValues.CurrentUser?.UserName != "kesim1" && !this.DepartsUsers.Contains(CurrentValues.CurrentUser?.UserName)));
    this.SonyoxlamaCommand = new RelayCommand((Action<object>) (async param => this.UpdateIroning(4)), (Predicate<object>) (param => CurrentValues.CurrentUser?.UserName != "kesim1" && !this.DepartsUsers.Contains(CurrentValues.CurrentUser?.UserName)));
    this.Hazir2Command = new RelayCommand((Action<object>) (async param => this.UpdateIroning(5)), (Predicate<object>) (param => CurrentValues.CurrentUser?.UserName != "kesim1" && !this.DepartsUsers.Contains(CurrentValues.CurrentUser?.UserName)));
    this.SelectedIroningItem1 = (Ironing1) null;
    this.SelectedIroningItem2 = (Ironing1) null;
    this.SelectedIroningItem3 = (Ironing1) null;
    this.LoadDateTimeNowIroning();
  }

  private async Task UpdateIroning(int converter)
  {
    switch (converter)
    {
      case 1:
        if (this.SelectedIroningItem1 != null)
        {
          this._unitOfWork.IroningRepository.Planlama(this.SelectedIroningItem1.FinanceId);
          break;
        }
        if (this.SelectedIroningItem2 != null)
        {
          this._unitOfWork.IroningRepository.Planlama(this.SelectedIroningItem2.FinanceId);
          break;
        }
        if (this.SelectedIroningItem3 != null)
        {
          this._unitOfWork.IroningRepository.Planlama(this.SelectedIroningItem3.FinanceId);
          break;
        }
        int num1 = (int) MessageBox.Show("Ütüləmə elementi seçin");
        break;
      case 2:
        if (this.SelectedIroningItem1 != null)
        {
          this._unitOfWork.IroningRepository.Kesim(this.SelectedIroningItem1.FinanceId);
          break;
        }
        if (this.SelectedIroningItem2 != null)
        {
          this._unitOfWork.IroningRepository.Kesim(this.SelectedIroningItem2.FinanceId);
          break;
        }
        if (this.SelectedIroningItem3 != null)
        {
          this._unitOfWork.IroningRepository.Kesim(this.SelectedIroningItem3.FinanceId);
          break;
        }
        int num2 = (int) MessageBox.Show("Ütüləmə elementi seçin");
        break;
      case 3:
        if (this.SelectedIroningItem1 != null)
        {
          this._unitOfWork.IroningRepository.Hazir1ci(this.SelectedIroningItem1.FinanceId);
          break;
        }
        if (this.SelectedIroningItem2 != null)
        {
          this._unitOfWork.IroningRepository.Hazir1ci(this.SelectedIroningItem2.FinanceId);
          break;
        }
        if (this.SelectedIroningItem3 != null)
        {
          this._unitOfWork.IroningRepository.Hazir1ci(this.SelectedIroningItem3.FinanceId);
          break;
        }
        int num3 = (int) MessageBox.Show("Ütüləmə elementi seçin");
        break;
      case 4:
        if (this.SelectedIroningItem1 != null)
        {
          this._unitOfWork.IroningRepository.SonYoxlama(this.SelectedIroningItem1.FinanceId);
          break;
        }
        if (this.SelectedIroningItem2 != null)
        {
          this._unitOfWork.IroningRepository.SonYoxlama(this.SelectedIroningItem2.FinanceId);
          break;
        }
        if (this.SelectedIroningItem3 != null)
        {
          this._unitOfWork.IroningRepository.SonYoxlama(this.SelectedIroningItem3.FinanceId);
          break;
        }
        int num4 = (int) MessageBox.Show("Ütüləmə elementi seçin");
        break;
      case 5:
        if (this.SelectedIroningItem1 != null)
        {
          this._unitOfWork.IroningRepository.Hazir2ci(this.SelectedIroningItem1.FinanceId);
          break;
        }
        if (this.SelectedIroningItem2 != null)
        {
          this._unitOfWork.IroningRepository.Hazir2ci(this.SelectedIroningItem2.FinanceId);
          break;
        }
        if (this.SelectedIroningItem3 != null)
        {
          this._unitOfWork.IroningRepository.Hazir2ci(this.SelectedIroningItem3.FinanceId);
          break;
        }
        int num5 = (int) MessageBox.Show("Ütüləmə elementi seçin");
        break;
    }
    this.LoadDateTimeNowIroning();
  }

  private async Task LoadDateTimeNowIroning()
  {
    IEnumerable<Ironing1> BaseIroningForDateTimeNow = await this._unitOfWork.IroningRepository.GetIroning1Detail(this.SelectedDate);
    Ironing1 ironing1;
    foreach (Ironing1 ironing1_1 in BaseIroningForDateTimeNow)
    {
      ironing1 = ironing1_1;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_1.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    IEnumerable<Ironing1> BaseIroningForDateTimeNowAddDayOne = await this._unitOfWork.IroningRepository.GetIroning1NextDetail(this.SelectedDate.AddDays(1.0));
    foreach (Ironing1 ironing1_2 in BaseIroningForDateTimeNowAddDayOne)
    {
      ironing1 = ironing1_2;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_2.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    IEnumerable<Ironing1> BaseIroningForDateTimeNowAddDayTwo = await this._unitOfWork.IroningRepository.GetIroning1NextDetail(this.SelectedDate.AddDays(2.0));
    foreach (Ironing1 ironing1_3 in BaseIroningForDateTimeNowAddDayTwo)
    {
      ironing1 = ironing1_3;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_3.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    this.IroningsDateTimeNow = new ObservableCollection<Ironing1>(BaseIroningForDateTimeNow);
    this.IroningsDateTimeAddDaysOne = new ObservableCollection<Ironing1>(BaseIroningForDateTimeNowAddDayOne);
    this.IroningsDateTimeAddDaysTwo = new ObservableCollection<Ironing1>(BaseIroningForDateTimeNowAddDayTwo);
    BaseIroningForDateTimeNow = (IEnumerable<Ironing1>) null;
    BaseIroningForDateTimeNowAddDayOne = (IEnumerable<Ironing1>) null;
    BaseIroningForDateTimeNowAddDayTwo = (IEnumerable<Ironing1>) null;
  }

  public async Task LoadIronings(object param)
  {
    this.SearchedIronings1 = await this._unitOfWork.IroningRepository.GetIroning1Detail(this.SelectedDate);
    Ironing1 ironing1;
    foreach (Ironing1 ironing1_1 in this.SearchedIronings1)
    {
      ironing1 = ironing1_1;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_1.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    this.SearchedIronings2 = await this._unitOfWork.IroningRepository.GetIroning1NextDetail(this.SelectedDate.AddDays(1.0));
    foreach (Ironing1 ironing1_2 in this.SearchedIronings2)
    {
      ironing1 = ironing1_2;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_2.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    this.SearchedIronings3 = await this._unitOfWork.IroningRepository.GetIroning1NextDetail(this.SelectedDate.AddDays(2.0));
    foreach (Ironing1 ironing1_3 in this.SearchedIronings3)
    {
      ironing1 = ironing1_3;
      ironing1.RowBackgroundColor = (await this._unitOfWork.FinanceRepository.GetFinanceUrgentStatus(ironing1_3.FinanceId)).GetValueOrDefault() == 1 ? (Brush) Brushes.Red : (Brush) Brushes.Transparent;
      ironing1 = (Ironing1) null;
    }
    this.IroningsDateTimeNow = new ObservableCollection<Ironing1>(this.SearchedIronings1);
    this.IroningsDateTimeAddDaysOne = new ObservableCollection<Ironing1>(this.SearchedIronings2);
    this.IroningsDateTimeAddDaysTwo = new ObservableCollection<Ironing1>(this.SearchedIronings3);
    this.SelectedCustomerIroningDetail = new CustomerIroningDetail();
  }

  public async Task Reset(object param)
  {
    this.CodeText = string.Empty;
    this.SurNameText = string.Empty;
    this.NameText = string.Empty;
    this.IroningsDateTimeNow = new ObservableCollection<Ironing1>(this.SearchedIronings1);
    this.IroningsDateTimeAddDaysOne = new ObservableCollection<Ironing1>(this.SearchedIronings2);
    this.IroningsDateTimeAddDaysTwo = new ObservableCollection<Ironing1>(this.SearchedIronings3);
    this.SelectedCustomerIroningDetail = new CustomerIroningDetail();
  }

  public async Task SwitchNextDay(object param)
  {
    this.SelectedDate = this.SelectedDate.AddDays(1.0);
    this.SearchText();
  }

  public async Task SwitchPreviousDay(object param)
  {
    this.SelectedDate = this.SelectedDate.AddDays(-1.0);
    this.SearchText();
  }

  public async Task SearchText()
  {
    string codeText = this.CodeText?.ToLower() ?? string.Empty;
    string nameText = this.NameText?.ToLower() ?? string.Empty;
    string surnameText = this.SurNameText?.ToLower() ?? string.Empty;
    IEnumerable<Ironing1> ironing1s1 = this.SearchedIronings1;
    IEnumerable<Ironing1> ironing1s2 = this.SearchedIronings2;
    IEnumerable<Ironing1> ironing1s3 = this.SearchedIronings3;
    if (!codeText.IsNullOrEmpty<char>())
    {
      ironing1s1 = ironing1s1.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CustomerId.ToString().Contains(codeText)));
      ironing1s2 = ironing1s2.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CustomerId.ToString().Contains(codeText)));
      ironing1s3 = ironing1s3.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CustomerId.ToString().Contains(codeText)));
    }
    if (!nameText.IsNullOrEmpty<char>())
    {
      ironing1s1 = ironing1s1.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusName.ToLower().Contains(nameText)));
      ironing1s2 = ironing1s2.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusName.ToLower().Contains(nameText)));
      ironing1s3 = ironing1s3.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusName.ToLower().Contains(nameText)));
    }
    if (!this.surNameText.IsNullOrEmpty<char>())
    {
      ironing1s1 = ironing1s1.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusSurname.ToLower().Contains(surnameText)));
      ironing1s2 = ironing1s2.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusSurname.ToLower().Contains(surnameText)));
      ironing1s3 = ironing1s3.Where<Ironing1>((Func<Ironing1, bool>) (i => i.CusSurname.ToLower().Contains(surnameText)));
    }
    this.IroningsDateTimeNow = new ObservableCollection<Ironing1>(ironing1s1);
    this.IroningsDateTimeAddDaysOne = new ObservableCollection<Ironing1>(ironing1s2);
    this.IroningsDateTimeAddDaysTwo = new ObservableCollection<Ironing1>(ironing1s3);
  }
}
