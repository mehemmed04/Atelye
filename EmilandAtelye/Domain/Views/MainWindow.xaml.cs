// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.MainWindow
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Constants;
using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.ViewModels;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye;

public partial class MainWindow : Window, IComponentConnector
{
  internal 
  #nullable disable
  Grid StatusBarGrid;
  internal Button MsBook;
  internal Button Stock;
  internal Button Measurement;
  internal Button OrderT;
  internal Button OrderF;
  internal Button OrderN;
  internal Button OrderHC;
  internal Button OrderMI;
  internal Button OrderMK;
  internal Button Changes;
  internal Button Ironing1;
  internal Button Ironing2;
  internal Button IroningDaily;
  internal Button Debts;
  internal Button Handover;
  internal Button Cashbox;
  internal Button Expenses;
  internal Button CashboxMI;
  internal Button ExpensesMI;
  private bool _contentLoaded;

  public 
  #nullable enable
  List<Button> Buttons
  {
    get
    {
      return new List<Button>()
      {
        this.MsBook,
        this.Stock,
        this.Measurement,
        this.OrderT,
        this.OrderF,
        this.OrderN,
        this.OrderHC,
        this.OrderMI,
        this.OrderMK,
        this.Changes,
        this.Ironing1,
        this.Ironing2,
        this.IroningDaily,
        this.Debts,
        this.Handover,
        this.Cashbox,
        this.Expenses,
        this.CashboxMI,
        this.ExpensesMI
      };
    }
  }

  public MainWindow()
  {
    this.InitializeComponent();
    foreach (Button button in this.Buttons)
    {
      string view = this.Converter(button);
      button.Visibility = Visibility.Collapsed;
      string username = CurrentValues.CurrentUser?.UserName ?? "";
      if (Permissions.HasReadPermission(view, username))
        button.Visibility = Visibility.Visible;
    }
    this.Loaded += new RoutedEventHandler(this.MainWindow_Loaded);
  }

  private string Converter(Button button)
  {
    if (button == this.MsBook)
      return ViewTag.MalinPasportu;
    if (button == this.Stock)
      return ViewTag.AnbarQaligi;
    if (button == this.Measurement)
      return ViewTag.Olculer;
    if (button == this.OrderT)
      return ViewTag.SifarislerT;
    if (button == this.OrderN)
      return ViewTag.SifarislerN;
    if (button == this.OrderF)
      return ViewTag.SifarislerF;
    if (button == this.OrderHC)
      return ViewTag.SifarislerHC;
    if (button == this.OrderMI)
      return ViewTag.SifarislerMI;
    if (button == this.OrderMK)
      return ViewTag.SifarislerMK;
    if (button == this.Changes)
      return ViewTag.Deyishiklikler;
    if (button == this.Ironing1)
      return ViewTag.Utuleme1;
    if (button == this.Ironing2)
      return ViewTag.Utuleme2;
    if (button == this.IroningDaily)
      return ViewTag.UtulemeGunluk;
    if (button == this.Debts)
      return ViewTag.Borclar;
    if (button == this.Handover)
      return ViewTag.Tehvil;
    if (button == this.Cashbox)
      return ViewTag.Kassa;
    if (button == this.Expenses)
      return ViewTag.Xerc;
    if (button == this.CashboxMI)
      return ViewTag.KassaMI;
    return button == this.ExpensesMI ? ViewTag.XercMI : "";
  }

  private void Window_MouseMove(object sender, MouseEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void Window_KeyDown(object sender, KeyEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void MainWindow_Loaded(object sender, RoutedEventArgs e) => this.SetGridWidth();

  private void SetGridWidth() => this.StatusBarGrid.Width = this.ActualWidth;

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    base.OnRenderSizeChanged(sizeInfo);
    this.SetGridWidth();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/mainwindow.xaml", UriKind.Relative));
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
        ((UIElement) target).PreviewKeyDown += new KeyEventHandler(this.Window_PreviewKeyDown);
        ((UIElement) target).KeyDown += new KeyEventHandler(this.Window_KeyDown);
        break;
      case 2:
        this.StatusBarGrid = (Grid) target;
        break;
      case 3:
        this.MsBook = (Button) target;
        break;
      case 4:
        this.Stock = (Button) target;
        break;
      case 5:
        this.Measurement = (Button) target;
        break;
      case 6:
        this.OrderT = (Button) target;
        break;
      case 7:
        this.OrderF = (Button) target;
        break;
      case 8:
        this.OrderN = (Button) target;
        break;
      case 9:
        this.OrderHC = (Button) target;
        break;
      case 10:
        this.OrderMI = (Button) target;
        break;
      case 11:
        this.OrderMK = (Button) target;
        break;
      case 12:
        this.Changes = (Button) target;
        break;
      case 13:
        this.Ironing1 = (Button) target;
        break;
      case 14:
        this.Ironing2 = (Button) target;
        break;
      case 15:
        this.IroningDaily = (Button) target;
        break;
      case 16 /*0x10*/:
        this.Debts = (Button) target;
        break;
      case 17:
        this.Handover = (Button) target;
        break;
      case 18:
        this.Cashbox = (Button) target;
        break;
      case 19:
        this.Expenses = (Button) target;
        break;
      case 20:
        this.CashboxMI = (Button) target;
        break;
      case 21:
        this.ExpensesMI = (Button) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
