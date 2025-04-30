// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.OrderViews.OrderMK
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.OrderViews;

public partial class OrderMK : UserControl, IComponentConnector
{
  internal 
  #nullable disable
  Button aButtonForDefault;
  internal Button bButtonForDefault;
  internal Button KButtonForB;
  internal Grid gridForDataGridDefault;
  internal ColumnDefinition FirstColumn;
  internal DataGrid DataGrid1;
  internal Grid FooterGrid1;
  internal GridSplitter FirstGridSplitter;
  internal DataGrid DataGrid2;
  internal Grid FooterGrid2;
  internal Grid gridForDataGridB;
  internal DataGrid DataGridForB;
  internal Grid FooterGridForB;
  internal Grid gridForDataGridCard;
  internal DataGrid DataGridForCard;
  internal Grid gridForDataGridDoubleClick;
  internal ColumnDefinition FirstColumnDoubleClick;
  internal DataGrid DataGridLeftDoubleClick;
  internal GridSplitter FirstGridSplitterForDoubleClick;
  internal DataGrid DataGrid2ForDoubleClick;
  private bool _contentLoaded;

  public OrderMK() => this.InitializeComponent();

  private void StockDataGrid1_Loaded(
  #nullable enable
  object sender, RoutedEventArgs e)
  {
    for (int index = 0; index < this.DataGrid1.Columns.Count && index < this.FooterGrid1.ColumnDefinitions.Count; ++index)
    {
      DataGridColumn column = this.DataGrid1.Columns[index];
      ColumnDefinition footerColumn = this.FooterGrid1.ColumnDefinitions[index];
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(DataGridColumn.ActualWidthProperty, typeof (DataGridColumn)))?.AddValueChanged((object) column, (EventHandler) ((s, args) => footerColumn.Width = new GridLength(column.ActualWidth)));
      footerColumn.Width = new GridLength(column.ActualWidth);
    }
  }

  private void StockDataGrid2_Loaded(object sender, RoutedEventArgs e)
  {
    for (int index = 0; index < this.DataGrid2.Columns.Count && index < this.FooterGrid2.ColumnDefinitions.Count; ++index)
    {
      DataGridColumn column = this.DataGrid2.Columns[index];
      ColumnDefinition footerColumn = this.FooterGrid2.ColumnDefinitions[index];
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(DataGridColumn.ActualWidthProperty, typeof (DataGridColumn)))?.AddValueChanged((object) column, (EventHandler) ((s, args) => footerColumn.Width = new GridLength(column.ActualWidth)));
      footerColumn.Width = new GridLength(column.ActualWidth);
    }
  }

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    this.gridForDataGridDefault.Visibility = Visibility.Collapsed;
    this.gridForDataGridCard.Visibility = Visibility.Collapsed;
    this.gridForDataGridB.Visibility = Visibility.Visible;
    this.KButtonForB.Visibility = Visibility.Visible;
    this.bButtonForDefault.Visibility = Visibility.Collapsed;
  }

  private void Button_Click_1(object sender, RoutedEventArgs e)
  {
    this.gridForDataGridDefault.Visibility = Visibility.Visible;
    this.gridForDataGridB.Visibility = Visibility.Collapsed;
    this.gridForDataGridCard.Visibility = Visibility.Collapsed;
    this.KButtonForB.Visibility = Visibility.Collapsed;
    this.bButtonForDefault.Visibility = Visibility.Visible;
    this.gridForDataGridDoubleClick.Visibility = Visibility.Collapsed;
  }

  private void Button_Click_2(object sender, RoutedEventArgs e)
  {
    this.gridForDataGridDefault.Visibility = Visibility.Collapsed;
    this.gridForDataGridB.Visibility = Visibility.Collapsed;
    this.gridForDataGridCard.Visibility = Visibility.Visible;
  }

  private void KButtonForB_Click(object sender, RoutedEventArgs e)
  {
    this.gridForDataGridDefault.Visibility = Visibility.Collapsed;
    this.gridForDataGridB.Visibility = Visibility.Collapsed;
    this.KButtonForB.Visibility = Visibility.Collapsed;
    this.bButtonForDefault.Visibility = Visibility.Visible;
    this.gridForDataGridCard.Visibility = Visibility.Visible;
  }

  private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
  {
    this.gridForDataGridDefault.Visibility = Visibility.Collapsed;
    this.gridForDataGridDoubleClick.Visibility = Visibility.Visible;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/orderviews/ordermk.xaml", UriKind.Relative));
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
        this.aButtonForDefault = (Button) target;
        break;
      case 2:
        this.bButtonForDefault = (Button) target;
        this.bButtonForDefault.Click += new RoutedEventHandler(this.Button_Click);
        break;
      case 3:
        this.KButtonForB = (Button) target;
        this.KButtonForB.Click += new RoutedEventHandler(this.KButtonForB_Click);
        break;
      case 4:
        this.gridForDataGridDefault = (Grid) target;
        break;
      case 5:
        this.FirstColumn = (ColumnDefinition) target;
        break;
      case 6:
        this.DataGrid1 = (DataGrid) target;
        this.DataGrid1.Loaded += new RoutedEventHandler(this.StockDataGrid1_Loaded);
        this.DataGrid1.MouseDoubleClick += new MouseButtonEventHandler(this.DataGrid1_MouseDoubleClick);
        break;
      case 7:
        this.FooterGrid1 = (Grid) target;
        break;
      case 8:
        this.FirstGridSplitter = (GridSplitter) target;
        break;
      case 9:
        this.DataGrid2 = (DataGrid) target;
        this.DataGrid2.Loaded += new RoutedEventHandler(this.StockDataGrid2_Loaded);
        break;
      case 10:
        this.FooterGrid2 = (Grid) target;
        break;
      case 11:
        this.gridForDataGridB = (Grid) target;
        break;
      case 12:
        this.DataGridForB = (DataGrid) target;
        this.DataGridForB.Loaded += new RoutedEventHandler(this.StockDataGrid1_Loaded);
        break;
      case 13:
        this.FooterGridForB = (Grid) target;
        break;
      case 14:
        this.gridForDataGridCard = (Grid) target;
        break;
      case 15:
        this.DataGridForCard = (DataGrid) target;
        this.DataGridForCard.Loaded += new RoutedEventHandler(this.StockDataGrid1_Loaded);
        break;
      case 16 /*0x10*/:
        this.gridForDataGridDoubleClick = (Grid) target;
        break;
      case 17:
        this.FirstColumnDoubleClick = (ColumnDefinition) target;
        break;
      case 18:
        this.DataGridLeftDoubleClick = (DataGrid) target;
        this.DataGridLeftDoubleClick.Loaded += new RoutedEventHandler(this.StockDataGrid1_Loaded);
        break;
      case 19:
        this.FirstGridSplitterForDoubleClick = (GridSplitter) target;
        break;
      case 20:
        this.DataGrid2ForDoubleClick = (DataGrid) target;
        this.DataGrid2ForDoubleClick.Loaded += new RoutedEventHandler(this.StockDataGrid2_Loaded);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
