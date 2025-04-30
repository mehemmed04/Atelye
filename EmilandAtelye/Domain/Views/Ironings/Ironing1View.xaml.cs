// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.Ironings.Ironing1View
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.ViewModels;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.Ironings;

public partial class Ironing1View : Window, IComponentConnector
{
  private object _lastSelectedItem;
  private object _lastSelectedItem2;
  private object _lastSelectedItem3;
  internal 
  #nullable disable
  DataGrid MyDataGrid;
  internal DataGrid MyDataGrid2;
  internal DataGrid MyDataGrid3;
  private bool _contentLoaded;

  public Ironing1View() => this.InitializeComponent();

  private void Window_MouseMove(
  #nullable enable
  object sender, MouseEventArgs e) => MainViewModel.OnUserActivity(sender, (EventArgs) e);

  private void Window_KeyDown(object sender, KeyEventArgs e)
  {
    MainViewModel.OnUserActivity(sender, (EventArgs) e);
  }

  private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (this.MyDataGrid.SelectedItem == null)
      this.MyDataGrid.SelectedItem = this._lastSelectedItem;
    else
      this._lastSelectedItem = this.MyDataGrid.SelectedItem;
  }

  private void MyDataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (this.MyDataGrid2.SelectedItem == null)
      this.MyDataGrid2.SelectedItem = this._lastSelectedItem2;
    else
      this._lastSelectedItem2 = this.MyDataGrid2.SelectedItem;
  }

  private void MyDataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (this.MyDataGrid3.SelectedItem == null)
      this.MyDataGrid3.SelectedItem = this._lastSelectedItem3;
    else
      this._lastSelectedItem3 = this.MyDataGrid3.SelectedItem;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/ironings/ironing1view.xaml", UriKind.Relative));
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
        this.MyDataGrid = (DataGrid) target;
        this.MyDataGrid.SelectionChanged += new SelectionChangedEventHandler(this.MyDataGrid_SelectionChanged);
        break;
      case 3:
        this.MyDataGrid2 = (DataGrid) target;
        this.MyDataGrid2.SelectionChanged += new SelectionChangedEventHandler(this.MyDataGrid2_SelectionChanged);
        break;
      case 4:
        this.MyDataGrid3 = (DataGrid) target;
        this.MyDataGrid3.SelectionChanged += new SelectionChangedEventHandler(this.MyDataGrid3_SelectionChanged);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
