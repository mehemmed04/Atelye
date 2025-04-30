// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.HandoverViewModel
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

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class HandoverViewModel : BaseViewModel
{
  private ObservableCollection<HandoverDouble> _userOrders;
  private Handover _selectedHandover;
  private ObservableCollection<Department> departments;
  private ObservableCollection<Handover> _handover;
  private Department? _selectedDepartment;
  private string customerCode;
  private string customerName;
  private string customerSurname;
  private string customerFatherName;
  private string customerMobile;
  private string customerTel;
  private Decimal _remainTotalAll;

  private IUnitOfWork _unitOfWork { get; set; }

  public RelayCommand ResetCommand { get; set; }

  public RelayCommand BCommand { get; set; }

  public ObservableCollection<HandoverDouble> UserOrders
  {
    get => this._userOrders;
    set
    {
      this._userOrders = value;
      this.OnPropertyChanged(nameof (UserOrders));
    }
  }

  public Handover SelectedHandover
  {
    get => this._selectedHandover;
    set
    {
      this._selectedHandover = value;
      this.OnPropertyChanged(nameof (SelectedHandover));
    }
  }

  public ObservableCollection<Department> Departments
  {
    get => this.departments;
    set
    {
      this.departments = value;
      this.OnPropertyChanged(nameof (Departments));
    }
  }

  public ObservableCollection<Handover> Handovers
  {
    get => this._handover;
    set
    {
      this._handover = value;
      this.OnPropertyChanged(nameof (Handovers));
    }
  }

  public Department? SelectedDepartment
  {
    get => this._selectedDepartment;
    set
    {
      this._selectedDepartment = value;
      this.OnPropertyChanged(nameof (SelectedDepartment));
      this.Search();
    }
  }

  public string CustomerCode
  {
    get => this.customerCode;
    set
    {
      this.customerCode = value;
      this.NotifyPropertyChanged(nameof (CustomerCode));
      this.Search();
    }
  }

  public string CustomerName
  {
    get => this.customerName;
    set
    {
      this.customerName = value;
      this.NotifyPropertyChanged(nameof (CustomerName));
      this.Search();
    }
  }

  public string CustomerSurname
  {
    get => this.customerSurname;
    set
    {
      this.customerSurname = value;
      this.NotifyPropertyChanged(nameof (CustomerSurname));
      this.Search();
    }
  }

  public string CustomerFatherName
  {
    get => this.customerFatherName;
    set
    {
      this.customerFatherName = value;
      this.NotifyPropertyChanged(nameof (CustomerFatherName));
      this.Search();
    }
  }

  public string CustomerMobile
  {
    get => this.customerMobile;
    set
    {
      this.customerMobile = value;
      this.NotifyPropertyChanged(nameof (CustomerMobile));
      this.Search();
    }
  }

  public string CustomerTel
  {
    get => this.customerTel;
    set
    {
      this.customerTel = value;
      this.NotifyPropertyChanged(nameof (CustomerTel));
      this.Search();
    }
  }

  public Decimal RemainTotalAll
  {
    get => this._remainTotalAll;
    set
    {
      if (!(this._remainTotalAll != value))
        return;
      this._remainTotalAll = value;
      this.NotifyPropertyChanged(nameof (RemainTotalAll));
      this.Search();
    }
  }

  public HandoverViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.LoadDepartments();
    this.Search();
    this.ResetCommand = new RelayCommand((Action<object>) (async param => await this.ResetInputs(param)));
    this.BCommand = new RelayCommand((Action<object>) (async param => await this.LoadDepts()));
  }

  public async Task LoadDoubleClick()
  {
    this.UserOrders = new ObservableCollection<HandoverDouble>(await this._unitOfWork.HandoverRepository.GetCustomerOrders(this.SelectedHandover.CustomerId));
    this.LoadCustomerInfo();
  }

  public async Task LoadCustomerInfo()
  {
    this.CustomerCode = this.SelectedHandover.CustomerId.ToString();
    this.CustomerName = this.SelectedHandover.CusName;
    this.CustomerSurname = this.SelectedHandover.CusSurname;
    this.CustomerFatherName = this.SelectedHandover.CusFatherName;
    this.CustomerMobile = this.SelectedHandover.CusGsm;
    this.CustomerTel = this.SelectedHandover.CustelNo;
  }

  private async Task LoadDepartments()
  {
    this.Departments = new ObservableCollection<Department>(await this._unitOfWork.DepartmentRepository.GetAllDepartmentsAsync());
    this.SelectedDepartment = this.Departments.FirstOrDefault<Department>((Func<Department, bool>) (d => d.DepartmentId == 12));
    this.Search();
  }

  public async Task LoadDepts()
  {
    this.Handovers = new ObservableCollection<Handover>(await this._unitOfWork.HandoverRepository.GetDeptsAsync(this.SelectedDepartment.DepartmentId));
  }

  public async void UpdateGivenTime(HandoverDouble handoverDouble, bool isChecked, string timeType)
  {
    HandoverViewModel handoverViewModel = this;
    if (!isChecked)
    {
      switch (timeType)
      {
        case "GivenDate":
          handoverDouble.GivenDate = new DateTime?(DateTime.Now);
          handoverDouble.GivenId = new byte?((byte) 1);
          break;
        case "FittingDate":
          handoverDouble.FittingDate = new DateTime?(DateTime.Now);
          handoverDouble.FittingId = new byte?((byte) 1);
          break;
      }
    }
    else if (isChecked)
    {
      switch (timeType)
      {
        case "GivenDate":
          handoverDouble.GivenDate = new DateTime?();
          handoverDouble.GivenId = new byte?((byte) 0);
          break;
        case "FittingDate":
          handoverDouble.FittingDate = new DateTime?();
          handoverDouble.FittingId = new byte?((byte) 0);
          break;
      }
    }
    handoverViewModel.OnPropertyChanged("UserOrders");
    await handoverViewModel._unitOfWork.HandoverRepository.UpdateGivenAsync(handoverDouble);
  }

  public async void UpdateCallIdTime(Handover handover, bool isChecked, string timeType)
  {
    HandoverViewModel handoverViewModel = this;
    if (!isChecked)
    {
      switch (timeType)
      {
        case "GCallIdTime":
          handover.GCallIdTime = new DateTime?(DateTime.Now);
          handover.GCallId = (byte) 1;
          break;
        case "GCallIdTime2":
          handover.GCallIdTime2 = new DateTime?(DateTime.Now);
          handover.GCallId2 = (byte) 1;
          break;
        case "GCallIdTime3":
          handover.GCallIdTime3 = new DateTime?(DateTime.Now);
          handover.GCallId3 = (byte) 1;
          break;
        case "GSmsIdTime":
          handover.GSmsIdTime = new DateTime?(DateTime.Now);
          handover.GSmsId = (byte) 1;
          break;
        case "GSmsIdTime2":
          handover.GSmsIdTime2 = new DateTime?(DateTime.Now);
          handover.GSmsId2 = (byte) 1;
          break;
        case "GSmsIdTime3":
          handover.GSmsIdTime3 = new DateTime?(DateTime.Now);
          handover.GSmsId3 = (byte) 1;
          break;
      }
    }
    else
    {
      switch (timeType)
      {
        case "GCallIdTime":
          handover.GCallIdTime = new DateTime?();
          handover.GCallId = (byte) 0;
          break;
        case "GCallIdTime2":
          handover.GCallIdTime2 = new DateTime?();
          handover.GCallId2 = (byte) 0;
          break;
        case "GCallIdTime3":
          handover.GCallIdTime3 = new DateTime?();
          handover.GCallId3 = (byte) 0;
          break;
        case "GSmsIdTime":
          handover.GSmsIdTime = new DateTime?();
          handover.GSmsId = (byte) 0;
          break;
        case "GSmsIdTime2":
          handover.GSmsIdTime2 = new DateTime?();
          handover.GSmsId2 = (byte) 0;
          break;
        case "GSmsIdTime3":
          handover.GSmsIdTime3 = new DateTime?();
          handover.GSmsId3 = (byte) 0;
          break;
      }
    }
    handoverViewModel.OnPropertyChanged("Handovers");
    await handoverViewModel._unitOfWork.HandoverRepository.UpdateHandoverAsync(handover);
  }

  public async Task Search()
  {
    IEnumerable<Handover> handovers = (IEnumerable<Handover>) new List<Handover>();
    string cusname = this.CustomerName?.ToLower() ?? string.Empty;
    string cussurname = this.CustomerSurname?.ToLower() ?? string.Empty;
    string cusfathername = this.CustomerFatherName?.ToLower() ?? string.Empty;
    string cusgsm = this.CustomerMobile?.ToLower() ?? string.Empty;
    string custelno = this.CustomerTel?.ToLower() ?? string.Empty;
    if (this.SelectedDepartment != null)
      handovers = await this._unitOfWork.HandoverRepository.GetHandoversAsync(this.SelectedDepartment.DepartmentId);
    if (!this.CustomerCode.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => d.CustomerId.ToString().Contains(this.CustomerCode)));
    if (!this.CustomerName.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => !d.CusName.IsNullOrEmpty<char>() && d.CusName.ToLower().Contains(cusname)));
    if (!this.CustomerSurname.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => !d.CusSurname.IsNullOrEmpty<char>() && d.CusSurname.ToLower().Contains(cussurname)));
    if (!this.CustomerFatherName.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => !d.CusFatherName.IsNullOrEmpty<char>() && d.CusFatherName.ToLower().Contains(cusfathername)));
    if (!this.CustomerMobile.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => !d.CusGsm.IsNullOrEmpty<char>() && d.CusGsm.ToLower().Contains(cusgsm)));
    if (!this.CustomerTel.IsNullOrEmpty<char>())
      handovers = handovers.Where<Handover>((Func<Handover, bool>) (d => !d.CustelNo.IsNullOrEmpty<char>() && d.CustelNo.ToLower().Contains(custelno)));
    this.Handovers = new ObservableCollection<Handover>(handovers);
  }

  public async Task ResetInputs(object param)
  {
    this.CustomerCode = string.Empty;
    this.CustomerName = string.Empty;
    this.CustomerSurname = string.Empty;
    this.CustomerFatherName = string.Empty;
    this.CustomerMobile = string.Empty;
    this.CustomerTel = string.Empty;
    this.Search();
  }
}
