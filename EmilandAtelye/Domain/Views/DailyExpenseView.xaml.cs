// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.DailyExpenseView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;
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
namespace EmilandAtelye.Domain.Views;

public partial class DailyExpenseView : Window, IComponentConnector
{
  internal 
  #nullable disable
  ListBox SuggestionListBox;
  private bool _contentLoaded;

  private 
  #nullable enable
  IUnitOfWork _unitOfWork { get; set; }

  public DailyExpenseView(IUnitOfWork unitOfWork, DateTime date)
  {
    this._unitOfWork = unitOfWork;
    this.InitializeComponent();
    this.DataContext = (object) new DailyExpenseViewModel(this._unitOfWork, (Window) this, date);
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

  private void TextBox_KeyUp(object sender, KeyEventArgs e)
  {
    DailyExpenseViewModel dataContext = (DailyExpenseViewModel) this.DataContext;
    dataContext.UpdateSuggestions(dataContext.ExpenseName);
  }

  private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    DailyExpenseViewModel dataContext = (DailyExpenseViewModel) this.DataContext;
    if (!(this.SuggestionListBox.SelectedItem is string selectedItem))
      return;
    dataContext.ExpenseName = selectedItem;
    dataContext.IsSuggestionListVisible = false;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/dailyexpenseview.xaml", UriKind.Relative));
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
        ((UIElement) target).KeyUp += new KeyEventHandler(this.TextBox_KeyUp);
        break;
      case 3:
        this.SuggestionListBox = (ListBox) target;
        this.SuggestionListBox.SelectionChanged += new SelectionChangedEventHandler(this.ListBox_SelectionChanged);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
