// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.OrderViews.UpdateOrderView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.ViewModels;
using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.OrderViews;

public partial class UpdateOrderView : Window, IComponentConnector
{
  private bool _contentLoaded;

  private IUnitOfWork _unitOfWork { get; set; }

  private ICurrencyTypeService CurrencyTypeService { get; set; }

  public CustomersSummary customers { get; set; }

  public UpdateOrderView(
    IUnitOfWork unitOfWork,
    FinanceDto financeDto,
    IEnumerable<GroupGen2ForOrder> types,
    ICurrencyTypeService currencyTypeService)
  {
    this._unitOfWork = unitOfWork;
    this.CurrencyTypeService = currencyTypeService;
    this.InitializeComponent();
    this.DataContext = (object) new UpdateOrderViewModel(this._unitOfWork, financeDto, types, this.CurrencyTypeService);
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
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/orderviews/updateorderview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, 
  #nullable disable
  object target)
  {
    if (connectionId != 1)
    {
      if (connectionId == 2)
        ((TextBoxBase) target).TextChanged += new TextChangedEventHandler(this.TextBox_TextChanged);
      else
        this._contentLoaded = true;
    }
    else
    {
      ((UIElement) target).MouseMove += new MouseEventHandler(this.Window_MouseMove);
      ((UIElement) target).KeyDown += new KeyEventHandler(this.Window_KeyDown);
    }
  }
}
