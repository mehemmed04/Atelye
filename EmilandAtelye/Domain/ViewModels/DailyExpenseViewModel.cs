// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.DailyExpenseViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class DailyExpenseViewModel : BaseViewModel
{
  private ObservableCollection<Department> departments;
  private Department? _selectedDepartment;
  private string _expenseId;
  private string _expenseName;
  private int _departId;
  private Decimal _operSumAzn;
  private DateTime? _operDate;
  private List<string> _expenseNameList;
  private ObservableCollection<string> _suggestionList;
  private bool isSuggestionListVisible;
  private List<string> _filteredExpenseNames;

  public Window CurrentWindow { get; set; }

  private IUnitOfWork _unitOfWork { get; set; }

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
    }
  }

  public string ExpenseId
  {
    get => this._expenseId;
    set
    {
      this._expenseId = value;
      this.OnPropertyChanged(nameof (ExpenseId));
    }
  }

  public string ExpenseName
  {
    get => this._expenseName;
    set
    {
      this._expenseName = value;
      this.OnPropertyChanged(nameof (ExpenseName));
    }
  }

  public int DepartId
  {
    get => this._departId;
    set
    {
      this._departId = value;
      this.OnPropertyChanged(nameof (DepartId));
    }
  }

  public Decimal OperSumAzn
  {
    get => this._operSumAzn;
    set
    {
      this._operSumAzn = value;
      this.OnPropertyChanged(nameof (OperSumAzn));
    }
  }

  public DateTime? OperDate
  {
    get => this._operDate;
    set
    {
      this._operDate = value;
      this.OnPropertyChanged(nameof (OperDate));
    }
  }

  public List<string> ExpenseNameList { get; set; } = new List<string>();

  public ObservableCollection<string> SuggestionList
  {
    get => this._suggestionList;
    set
    {
      this._suggestionList = value;
      this.OnPropertyChanged(nameof (SuggestionList));
    }
  }

  public bool IsSuggestionListVisible
  {
    get => this.isSuggestionListVisible;
    set
    {
      if (this.isSuggestionListVisible == value)
        return;
      this.isSuggestionListVisible = value;
      this.OnPropertyChanged(nameof (IsSuggestionListVisible));
    }
  }

  public List<string> FilteredExpenseNames
  {
    get => this._filteredExpenseNames;
    set
    {
      this._filteredExpenseNames = value;
      this.OnPropertyChanged(nameof (FilteredExpenseNames));
    }
  }

  public RelayCommand SaveButtonCommand { get; set; }

  public DailyExpenseViewModel(IUnitOfWork unitOfWork, Window currentWindow, DateTime date)
  {
    this._unitOfWork = unitOfWork;
    this.LoadDepartments();
    this.OperDate = new DateTime?(date);
    this.SaveButtonCommand = new RelayCommand((Action<object>) (async param => await this.SaveExpenseAsync()));
    this.CurrentWindow = currentWindow;
    this.LoadExpenseNames();
    this.SuggestionList = new ObservableCollection<string>();
    this.IsSuggestionListVisible = false;
  }

  private async Task LoadDepartments()
  {
    this.Departments = new ObservableCollection<Department>(await this._unitOfWork.DepartmentRepository.GetAllDepartmentsAsync());
  }

  private async Task SaveExpenseAsync()
  {
    try
    {
      Department selectedDepartment = this.SelectedDepartment;
      int num1;
      if (selectedDepartment == null)
      {
        num1 = 1;
      }
      else
      {
        int departmentId = selectedDepartment.DepartmentId;
        num1 = 0;
      }
      if (num1 != 0)
      {
        int num2 = (int) MessageBox.Show("Filial seçin");
      }
      else
      {
        DailyExpense dailyExpense1 = new DailyExpense();
        dailyExpense1.DepartId = this.SelectedDepartment.DepartmentId;
        DailyExpense dailyExpense2 = dailyExpense1;
        dailyExpense2.ExpenseId = await this.GetExpenseId();
        dailyExpense1.ExpenseName = this.ExpenseName;
        dailyExpense1.OperDate = this.OperDate.Value.Date;
        dailyExpense1.OperSumAzn = new int?(Convert.ToInt32(this.OperSumAzn));
        dailyExpense1.StCash = (byte) 1;
        DailyExpense dailyExpense = dailyExpense1;
        dailyExpense2 = (DailyExpense) null;
        dailyExpense1 = (DailyExpense) null;
        if (await this._unitOfWork.DailyExpenseRepository.InsertDailyExpenseAsync(dailyExpense) == 1)
        {
          if (MessageBox.Show("Xərc əlavə edildi") != MessageBoxResult.OK)
            return;
          this.CurrentWindow.Close();
        }
        else
        {
          int num3 = (int) MessageBox.Show("Xərc əlavə edilərkən xəta baş verdi");
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Xəta baş verdi: " + ex.Message);
    }
  }

  public async Task<string> GetExpenseId()
  {
    string expenseIdByNameAsync = await this._unitOfWork.DailyExpenseRepository.GetExpenseIdByNameAsync(this.ExpenseName);
    if (expenseIdByNameAsync != null)
      return expenseIdByNameAsync;
    string str = await this.AddExpenseType();
    return await this._unitOfWork.DailyExpenseRepository.GetExpenseIdByNameAsync(this.ExpenseName);
  }

  public async Task<string> AddExpenseType()
  {
    string maxExpenseIdAsync = await this._unitOfWork.DailyExpenseRepository.GetMaxExpenseIdAsync();
    int num = await this._unitOfWork.DailyExpenseRepository.AddExpenseAsync(new LproExpense()
    {
      EXPENSEID = (int.Parse(maxExpenseIdAsync) + 1).ToString().PadLeft(maxExpenseIdAsync.Length, '0'),
      DEPARTID = this.SelectedDepartment.DepartmentId,
      REGDATE = new DateTime?(DateTime.Now),
      REGUID = CurrentValues.CurrentUser?.UserName,
      EDITDATE = new DateTime?(),
      EDITUID = (string) null,
      EXPENSENAME = this.ExpenseName,
      STATUS = 0,
      aa = (string) null,
      BEX = (string) null
    });
    return await this._unitOfWork.DailyExpenseRepository.GetExpenseIdByNameAsync(this.ExpenseName);
  }

  private async Task<List<string>> LoadExpenseNames()
  {
    return await this._unitOfWork.DailyExpenseRepository.GetExpenseNamesAsync();
  }

  public async void UpdateSuggestions(string input)
  {
    if (string.IsNullOrWhiteSpace(input))
    {
      this.SuggestionList.Clear();
      this.IsSuggestionListVisible = false;
    }
    else
    {
      List<string> suggestionsFromDatabase = await this.GetSuggestionsFromDatabase(input);
      this.SuggestionList.Clear();
      foreach (string str in suggestionsFromDatabase)
        this.SuggestionList.Add(str);
      this.IsSuggestionListVisible = this.SuggestionList.Count > 0;
    }
  }

  private async Task<List<string>> GetSuggestionsFromDatabase(string input)
  {
    return (await this.LoadExpenseNames()).Where<string>((Func<string, bool>) (expense => expense.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))).ToList<string>();
  }
}
