// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.ExpensesViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

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

public class ExpensesViewModel : BaseViewModel
{
  private DateTime _startDate;
  private DateTime _endDate;
  private ObservableCollection<Department> departments;
  private Department? _selectedDepartment;
  private ObservableCollection<Expense> _expenses;
  private double _totalOperSumDollar;
  private double _totalOperSumAzn;
  private double _totalOperSumAznBref;
  private double _totalOperSumUsdBref;
  private string _expenseName;

  private IUnitOfWork _unitOfWork { get; set; }

  public DateTime StartDate
  {
    get => this._startDate;
    set
    {
      this._startDate = value;
      this.OnPropertyChanged(nameof (StartDate));
      this.Search();
    }
  }

  public DateTime EndDate
  {
    get => this._endDate;
    set
    {
      this._endDate = value;
      this.OnPropertyChanged(nameof (EndDate));
      this.Search();
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

  public ObservableCollection<Expense> Expenses
  {
    get => this._expenses;
    set
    {
      this._expenses = value;
      this.TotalOperSumDollar = value.Sum<Expense>((Func<Expense, double>) (e => e.OperSumDollar));
      this.TotalOperSumAzn = value.Sum<Expense>((Func<Expense, double>) (e => e.OperSumAzn));
      this.TotalOperSumAznBref = value.Sum<Expense>((Func<Expense, double>) (e => e.OperSumAznBref));
      this.TotalOperSumUsdBref = value.Sum<Expense>((Func<Expense, double>) (e => e.OperSumUsdBref));
      this.OnPropertyChanged(nameof (Expenses));
    }
  }

  public double TotalOperSumDollar
  {
    get => this._totalOperSumDollar;
    set
    {
      this._totalOperSumDollar = value;
      this.OnPropertyChanged(nameof (TotalOperSumDollar));
    }
  }

  public double TotalOperSumAzn
  {
    get => this._totalOperSumAzn;
    set
    {
      this._totalOperSumAzn = value;
      this.OnPropertyChanged(nameof (TotalOperSumAzn));
    }
  }

  public double TotalOperSumAznBref
  {
    get => this._totalOperSumAznBref;
    set
    {
      this._totalOperSumAznBref = value;
      this.OnPropertyChanged(nameof (TotalOperSumAznBref));
    }
  }

  public double TotalOperSumUsdBref
  {
    get => this._totalOperSumUsdBref;
    set
    {
      this._totalOperSumUsdBref = value;
      this.OnPropertyChanged(nameof (TotalOperSumUsdBref));
    }
  }

  public string ExpenseName
  {
    get => this._expenseName;
    set
    {
      this._expenseName = value;
      this.OnPropertyChanged(nameof (ExpenseName));
      this.Search();
    }
  }

  public ExpensesViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    DateTime dateTime = DateTime.Now;
    dateTime = dateTime.AddMonths(-9);
    this.StartDate = dateTime.AddDays(-9.0);
    this.EndDate = DateTime.Now.AddMonths(-9);
    this.ExpenseName = string.Empty;
    this.LoadDepartments();
    this.LoadStocks();
  }

  private async Task LoadDepartments()
  {
    this.Departments = new ObservableCollection<Department>(await this._unitOfWork.DepartmentRepository.GetAllDepartmentsAsync());
  }

  private async Task LoadStocks()
  {
    this.Expenses = new ObservableCollection<Expense>(await this._unitOfWork.ExpenseRepository.GetAllExpenses(this.StartDate, this.EndDate));
  }

  public async Task Search()
  {
    IEnumerable<Expense> expenses = await this._unitOfWork.ExpenseRepository.GetAllExpenses(this.StartDate, this.EndDate);
    if (this.SelectedDepartment != null)
      expenses = expenses.Where<Expense>((Func<Expense, bool>) (e => e.DepartShortName == this.SelectedDepartment.DepartmentShortName));
    string expensename = this.ExpenseName.ToLower();
    if (!this.ExpenseName.IsNullOrEmpty<char>())
      expenses = expenses.Where<Expense>((Func<Expense, bool>) (e => !e.ExpenseName.IsNullOrEmpty<char>() && e.ExpenseName.ToLower().Contains(expensename)));
    this.Expenses = new ObservableCollection<Expense>(expenses);
  }
}
