// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.Expenses.ExpenseView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.Expenses;

public partial class ExpenseView : UserControl, IComponentConnector
{
  internal 
  #nullable disable
  DataGrid MainDataGrid;
  internal Grid FooterGrid;
  private bool _contentLoaded;

  public ExpenseView() => this.InitializeComponent();

  private void DataGrid_LoadingRow(
  #nullable enable
  object sender, DataGridRowEventArgs e)
  {
    e.Row.Header = (object) (e.Row.GetIndex() + 1).ToString();
  }

  private void StockDataGrid_Loaded(object sender, RoutedEventArgs e)
  {
    for (int index = 0; index < this.MainDataGrid.Columns.Count && index < this.FooterGrid.ColumnDefinitions.Count; ++index)
    {
      DataGridColumn column = this.MainDataGrid.Columns[index];
      ColumnDefinition footerColumn = this.FooterGrid.ColumnDefinitions[index];
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(DataGridColumn.ActualWidthProperty, typeof (DataGridColumn)))?.AddValueChanged((object) column, (EventHandler) ((s, args) => footerColumn.Width = new GridLength(column.ActualWidth)));
      footerColumn.Width = new GridLength(column.ActualWidth);
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/expenses/expenseview.xaml", UriKind.Relative));
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
        this.FooterGrid = (Grid) target;
      else
        this._contentLoaded = true;
    }
    else
    {
      this.MainDataGrid = (DataGrid) target;
      this.MainDataGrid.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid_LoadingRow);
      this.MainDataGrid.Loaded += new RoutedEventHandler(this.StockDataGrid_Loaded);
    }
  }
}
