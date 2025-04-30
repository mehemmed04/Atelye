// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.DebtsViewModel
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

public class DebtsViewModel : BaseViewModel
{
  private ObservableCollection<Department> departments;
  private ObservableCollection<Debt> _debts;
  private Department? _selectedDepartment;
  private string customerCode;
  private string customerName;
  private string customerSurname;
  private string customerFatherName;
  private string customerMobile;
  private string customerTel;

  private IUnitOfWork _unitOfWork { get; set; }

  public RelayCommand ResetCommand { get; set; }

  public ObservableCollection<Department> Departments
  {
    get => this.departments;
    set
    {
      this.departments = value;
      this.OnPropertyChanged(nameof (Departments));
    }
  }

  public ObservableCollection<Debt> Debts
  {
    get => this._debts;
    set
    {
      this._debts = value;
      this.OnPropertyChanged(nameof (Debts));
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

  public DebtsViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.LoadDepartments();
    this.Search();
    this.ResetCommand = new RelayCommand((Action<object>) (async param => await this.ResetInputs(param)));
  }

  private async Task LoadDepartments()
  {
    this.Departments = new ObservableCollection<Department>(await this._unitOfWork.DepartmentRepository.GetAllDepartmentsAsync());
    this.SelectedDepartment = this.Departments.FirstOrDefault<Department>((Func<Department, bool>) (d => d.DepartmentId == 12));
    this.Search();
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

  public async Task Search()
  {
    IEnumerable<Debt> debts = (IEnumerable<Debt>) new List<Debt>();
    string cusname = this.CustomerName?.ToLower() ?? string.Empty;
    string cussurname = this.CustomerSurname?.ToLower() ?? string.Empty;
    string cusfathername = this.CustomerFatherName?.ToLower() ?? string.Empty;
    string cusgsm = this.CustomerMobile?.ToLower() ?? string.Empty;
    string custelno = this.CustomerTel?.ToLower() ?? string.Empty;
    if (this.SelectedDepartment != null)
      debts = await this._unitOfWork.DebtRepository.GetDebtsByDepartmentIdAsync(this.SelectedDepartment.DepartmentId);
    if (!this.CustomerCode.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => d.CustomerId.ToString().Contains(this.CustomerCode)));
    if (!this.CustomerName.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => !d.CusName.IsNullOrEmpty<char>() && d.CusName.ToLower().Contains(cusname)));
    if (!this.CustomerSurname.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => !d.CusSurname.IsNullOrEmpty<char>() && d.CusSurname.ToLower().Contains(cussurname)));
    if (!this.CustomerFatherName.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => !d.CusFatherName.IsNullOrEmpty<char>() && d.CusFatherName.ToLower().Contains(cusfathername)));
    if (!this.CustomerMobile.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => !d.CusGSM.IsNullOrEmpty<char>() && d.CusGSM.ToLower().Contains(cusgsm)));
    if (!this.CustomerTel.IsNullOrEmpty<char>())
      debts = debts.Where<Debt>((Func<Debt, bool>) (d => !d.CusTelNo.IsNullOrEmpty<char>() && d.CusTelNo.ToLower().Contains(custelno)));
    this.Debts = new ObservableCollection<Debt>(debts);
  }
}
