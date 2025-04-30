// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.HandoverView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using EmilandAtelye.Domain.ViewModels;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

#nullable enable
namespace EmilandAtelye.Domain.Views;

public partial class HandoverView : UserControl, IComponentConnector, IStyleConnector
{
  internal 
  #nullable disable
  DataGrid DataGrid1;
  internal DataGrid DataGridDouble;
  private bool _contentLoaded;

  public HandoverView() => this.InitializeComponent();

  private void DataGrid_LoadingRow(
  #nullable enable
  object sender, DataGridRowEventArgs e)
  {
    e.Row.Header = (object) (e.Row.GetIndex() + 1).ToString();
  }

  private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
  }

  private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
  {
  }

  private void CheckBox_Checked_Unchecked2(object sender, RoutedEventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (checkBox == null)
      return;
    ((DispatcherObject) this).Dispatcher.BeginInvoke((Delegate) (() =>
    {
      if (!(checkBox?.DataContext is HandoverDouble dataContext2))
        return;
      HandoverViewModel dataContext3 = this.DataContext as HandoverViewModel;
      string timeType = checkBox?.Tag.ToString();
      bool valueOrDefault = ((bool?) checkBox?.IsChecked).GetValueOrDefault();
      if (dataContext3 == null || timeType == null)
        return;
      dataContext3.UpdateGivenTime(dataContext2, valueOrDefault, timeType);
    }), (DispatcherPriority) 4, Array.Empty<object>());
  }

  private void CheckBox_Checked_Unchecked(object sender, RoutedEventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (checkBox == null)
      return;
    ((DispatcherObject) this).Dispatcher.BeginInvoke((Delegate) (() =>
    {
      if (!(checkBox?.DataContext is Handover dataContext2))
        return;
      HandoverViewModel dataContext3 = this.DataContext as HandoverViewModel;
      string timeType = checkBox?.Tag.ToString();
      bool valueOrDefault = ((bool?) checkBox?.IsChecked).GetValueOrDefault();
      if (dataContext3 == null || timeType == null)
        return;
      dataContext3.UpdateCallIdTime(dataContext2, valueOrDefault, timeType);
    }), (DispatcherPriority) 4, Array.Empty<object>());
  }

  private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
  {
  }

  private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
  {
    if (this.DataContext is HandoverViewModel dataContext)
      dataContext.LoadDoubleClick();
    this.DataGrid1.Visibility = Visibility.Collapsed;
    this.DataGridDouble.Visibility = Visibility.Visible;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/handoverview.xaml", UriKind.Relative));
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
      if (connectionId == 8)
      {
        this.DataGridDouble = (DataGrid) target;
        this.DataGridDouble.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid_LoadingRow);
        this.DataGridDouble.SelectionChanged += new SelectionChangedEventHandler(this.DataGrid_SelectionChanged_2);
      }
      else
        this._contentLoaded = true;
    }
    else
    {
      this.DataGrid1 = (DataGrid) target;
      this.DataGrid1.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGrid_LoadingRow);
      this.DataGrid1.SelectionChanged += new SelectionChangedEventHandler(this.DataGrid_SelectionChanged_2);
      this.DataGrid1.MouseDoubleClick += new MouseButtonEventHandler(this.DataGrid_MouseDoubleClick);
    }
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IStyleConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 2:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 3:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 4:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 5:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 6:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 7:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked)
        });
        break;
      case 9:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked2)
        });
        break;
      case 10:
        ((Style) target).Setters.Add((SetterBase) new EventSetter()
        {
          Event = UIElement.PreviewMouseDownEvent,
          Handler = (Delegate) new MouseButtonEventHandler(this.CheckBox_Checked_Unchecked2)
        });
        break;
    }
  }
}
