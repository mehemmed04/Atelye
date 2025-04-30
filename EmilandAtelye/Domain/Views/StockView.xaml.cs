// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.StockView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views;

public partial class StockView : UserControl, IComponentConnector
{
  internal 
  #nullable disable
  DataGrid StockDataGrid;
  internal Grid FooterGrid;
  private bool _contentLoaded;

  public StockView() => this.InitializeComponent();

  private void DataGrid_LoadingRow(
  #nullable enable
  object sender, DataGridRowEventArgs e)
  {
    e.Row.Header = (object) (e.Row.GetIndex() + 1).ToString();
  }

  private void StockDataGrid_Loaded(object sender, RoutedEventArgs e)
  {
    for (int index = 0; index < this.StockDataGrid.Columns.Count && index < this.FooterGrid.ColumnDefinitions.Count; ++index)
    {
      DataGridColumn column = this.StockDataGrid.Columns[index];
      ColumnDefinition footerColumn = this.FooterGrid.ColumnDefinitions[index];
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(DataGridColumn.ActualWidthProperty, typeof (DataGridColumn)))?.AddValueChanged((object) column, (EventHandler) ((s, args) => footerColumn.Width = new GridLength(column.ActualWidth)));
      footerColumn.Width = new GridLength(column.ActualWidth);
    }
  }

  private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
  {
    e.Handled = !StockView.IsTextAllowed(e.Text, ((TextBox) sender).Text);
  }

  private static bool IsTextAllowed(string input, string currentText)
  {
    if (string.IsNullOrEmpty(input))
      return true;
    if (!Regex.IsMatch(input, "^-?[0-9]*\\.?[0-9]*$") || input == "." && currentText.Contains("."))
      return false;
    return !(input == "-") || !currentText.Contains("-");
  }

  private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
  {
    if (e.DataObject.GetDataPresent(typeof (string)))
    {
      if (StockView.IsTextAllowed((string) e.DataObject.GetData(typeof (string)), ((TextBox) sender).Text))
        return;
      e.CancelCommand();
    }
    else
      e.CancelCommand();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/stockview.xaml", UriKind.Relative));
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
        ((UIElement) target).PreviewTextInput += new TextCompositionEventHandler(this.TextBox_PreviewTextInput);
        ((UIElement) target).AddHandler(DataObject.PastingEvent, (Delegate) new DataObjectPastingEventHandler(this.TextBox_Pasting));
        break;
      case 2:
        this.StockDataGrid = (DataGrid) target;
        this.StockDataGrid.Loaded += new RoutedEventHandler(this.StockDataGrid_Loaded);
        this.StockDataGrid.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid_LoadingRow);
        break;
      case 3:
        this.FooterGrid = (Grid) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
