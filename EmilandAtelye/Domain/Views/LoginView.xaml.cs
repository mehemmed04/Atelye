// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.LoginView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.ViewModels;
using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views;

public partial class LoginView : Window, IComponentConnector
{
  private IFileService _fileService;
  internal 
  #nullable disable
  TextBox UsernameTextBox;
  internal PasswordBox PasswordBox;
  internal TextBlock ErrorMessage;
  private bool _contentLoaded;

  public LoginView(
  #nullable enable
  LoginViewModel viewModel, IFileService fileService)
  {
    this.InitializeComponent();
    this.DataContext = (object) viewModel;
    this._fileService = fileService;
    this.GetDeviceUser();
  }

  private void SetSelection(int start, int length)
  {
    ((object) this.PasswordBox).GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object) this.PasswordBox, new object[2]
    {
      (object) start,
      (object) length
    });
  }

  public async Task GetDeviceUser()
  {
    PassKeyDto passKeyDto = await this._fileService.ReadPasskey();
    if (passKeyDto == null)
      return;
    this.PasswordBox.Password = passKeyDto.PassKey;
    this.SetSelection(this.PasswordBox.Password.Length, 0);
    this.PasswordBox.Focus();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/loginview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, 
  #nullable disable
  object target)
  {
    switch (connectionId)
    {
      case 1:
        this.UsernameTextBox = (TextBox) target;
        break;
      case 2:
        this.PasswordBox = (PasswordBox) target;
        break;
      case 3:
        this.ErrorMessage = (TextBlock) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
