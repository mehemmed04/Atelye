// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.OrderViews.AddOrderView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.ViewModels;
using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.OrderViews;

public partial class AddOrderView : Window, IComponentConnector
{
  internal 
  #nullable disable
  TextBox CustomerId;
  private bool _contentLoaded;

  private 
  #nullable enable
  IUnitOfWork _unitOfWork { get; set; }

  private ICurrencyTypeService currencyTypeService { get; set; }

  public AddOrderView(
    IUnitOfWork unitOfWork,
    int departmentId,
    ICurrencyTypeService currencyTypeService,
    FinanceDto SelectedFinanceDto,
    bool IsSearchPage)
  {
    this._unitOfWork = unitOfWork;
    this.InitializeComponent();
    this.currencyTypeService = currencyTypeService;
    this.DataContext = (object) new AddOrderViewModel(this._unitOfWork, (Window) this, departmentId, currencyTypeService, SelectedFinanceDto, IsSearchPage);
  }

  private void Window_MouseMove(object sender, MouseEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void Window_KeyDown(object sender, KeyEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
  {
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/orderviews/addorderview.xaml", UriKind.Relative));
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
        ((UIElement) target).MouseMove += new MouseEventHandler(this.Window_MouseMove);
        ((UIElement) target).KeyDown += new KeyEventHandler(this.Window_KeyDown);
        break;
      case 2:
        this.CustomerId = (TextBox) target;
        break;
      case 3:
        ((TextBoxBase) target).TextChanged += new TextChangedEventHandler(this.TextBox_TextChanged);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
