// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.LoginViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.Constants;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.Views;
using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class LoginViewModel : BaseViewModel
{
  private string username;
  private Department _selectedDepartment;
  private string errorMessage;
  private ObservableCollection<Department> departments;

  private IUnitOfWork _unitOfWork { get; set; }

  private IOrderService OrderService { get; set; }

  private IFileService _fileService { get; set; }

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  public RelayCommand LoginCommand { get; set; }

  public string Username
  {
    get => this.username;
    set
    {
      this.username = value;
      this.NotifyPropertyChanged(nameof (Username));
    }
  }

  public Department SelectedDepartment
  {
    get => this._selectedDepartment;
    set
    {
      this._selectedDepartment = value;
      this.OnPropertyChanged(nameof (SelectedDepartment));
    }
  }

  public string ErrorMessage
  {
    get => this.errorMessage;
    set
    {
      this.errorMessage = value;
      this.NotifyPropertyChanged(nameof (ErrorMessage));
    }
  }

  public ObservableCollection<Department> Departments
  {
    get => this.departments;
    set
    {
      this.departments = value;
      this.NotifyPropertyChanged(nameof (Departments));
    }
  }

  public LoginViewModel(
    IUnitOfWork unitOfWork,
    IFileService fileService,
    ICurrencyTypeService currencyTypeService,
    IOrderService orderService)
  {
    this._unitOfWork = unitOfWork;
    this._fileService = fileService;
    this.CurrencyTypeService = currencyTypeService;
    this.LoginCommand = new RelayCommand(new Action<object>(this.Login));
    this.GetDeviceUser();
    this.LoadDepartmentsAsync();
    this.OrderService = orderService;
  }

  private async Task LoadDepartmentsAsync()
  {
    LoginViewModel loginViewModel = this;
    IEnumerable<Department> departmentsAsync = await loginViewModel._unitOfWork.DepartmentRepository.GetAllDepartmentsAsync();
    loginViewModel.Departments = new ObservableCollection<Department>(departmentsAsync);
    loginViewModel.SelectedDepartment = loginViewModel.Departments.FirstOrDefault<Department>() ?? new Department();
    loginViewModel.OnPropertyChanged("Departments");
  }

  public async Task GetDeviceUser()
  {
    PassKeyDto passKeyDto = await this._fileService.ReadPasskey();
    if (passKeyDto == null)
      return;
    this.Username = passKeyDto.Username;
  }

  public async void Login(object param)
  {
    User userByNameAsync = await this._unitOfWork.UserRepository.GetUserByNameAsync(this.username);
    string enumerable = (param is PasswordBox passwordBox ? passwordBox.Password : (string) null) ?? string.Empty;
    this.ErrorMessage = string.Empty;
    string str1;
    string passkey = PassKeyConstants.UserCredentials.TryGetValue(this.Username, out str1) ? str1 : string.Empty;
    string str2 = enumerable.Substring(0, enumerable.Length - 3);
    if (this.SelectedDepartment != null && this.SelectedDepartment.DepartmentName.IsNullOrEmpty<char>())
    {
      int num = (int) MessageBox.Show("Filial seçilməlidir");
    }
    else if (this.Username.IsNullOrEmpty<char>())
      this.ErrorMessage = "İstifadəçi adı daxil edilməyib";
    else if (enumerable.IsNullOrEmpty<char>())
      this.ErrorMessage = "Şifrə daxil edilməyib";
    else if (userByNameAsync == null)
      this.ErrorMessage = "İstifadəçi adı və ya şifrə yanlışdır";
    else if (userByNameAsync.UserCode == enumerable.Substring(enumerable.Length - 3) && passkey == str2)
    {
      this.ErrorMessage = string.Empty;
      Window loginView = Application.Current.Windows.OfType<Window>().FirstOrDefault<Window>((Func<Window, bool>) (w => w is LoginView));
      CurrentValues.CurrentUser = userByNameAsync;
      MainWindow mainWindow = new MainWindow();
      mainWindow.DataContext = (object) new MainViewModel(mainWindow, this.SelectedDepartment, userByNameAsync, this._unitOfWork, this.CurrencyTypeService, this.OrderService);
      await this._fileService.SavePasskey(this.Username, passkey);
      mainWindow.Show();
      loginView?.Close();
      loginView = (Window) null;
      mainWindow = (MainWindow) null;
    }
    else
      this.ErrorMessage = "İstifadəçi adı və ya şifrə yanlışdır";
  }
}
