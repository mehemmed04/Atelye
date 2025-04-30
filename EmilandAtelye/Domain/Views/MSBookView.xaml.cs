// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.MSBookView
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
namespace EmilandAtelye.Domain.Views;

public partial class MSBookView : UserControl, IComponentConnector
{
  internal 
  #nullable disable
  StackPanel Kost1;
  internal StackPanel Koy1;
  internal StackPanel Zap1;
  internal StackPanel Qals1;
  internal StackPanel Yayl1;
  internal StackPanel Jilet1;
  internal StackPanel Corab1;
  internal StackPanel Ayaq1;
  internal StackPanel Kemer1;
  internal StackPanel Qurs1;
  internal StackPanel Bab1;
  internal StackPanel Kost2;
  internal StackPanel Koy2;
  internal StackPanel Kost3;
  internal StackPanel Kost4;
  internal StackPanel Kost5;
  internal StackPanel Kost6;
  internal StackPanel Kost8;
  internal StackPanel Kost7;
  internal TabItem YeniQiymetler;
  internal TabItem Qruplar;
  internal TabItem Firmalar;
  internal TabItem Modeller;
  internal TabItem Qiymetler;
  internal TabItem MSK1;
  internal DataGrid Dasdads;
  internal TabItem Musteriler;
  internal TabItem Olculer;
  internal TabItem Rengler;
  internal TabItem Parcalar;
  internal TabItem Emekhaqqlari;
  private bool _contentLoaded;

  public MSBookView() => this.InitializeComponent();

  private void ResetAllShowenBoxes()
  {
    this.Kost1.Visibility = Visibility.Collapsed;
    if (this.Koy2.Visibility == Visibility.Visible)
      this.Kost2.Visibility = Visibility.Hidden;
    else
      this.Kost2.Visibility = Visibility.Collapsed;
    this.Kost3.Visibility = Visibility.Hidden;
    this.Kost4.Visibility = Visibility.Hidden;
    this.Kost5.Visibility = Visibility.Hidden;
    this.Kost6.Visibility = Visibility.Hidden;
    this.Kost7.Visibility = Visibility.Hidden;
    this.Koy1.Visibility = Visibility.Collapsed;
    if (this.Kost2.Visibility == Visibility.Visible)
      this.Koy2.Visibility = Visibility.Hidden;
    else
      this.Koy2.Visibility = Visibility.Collapsed;
    this.Zap1.Visibility = Visibility.Collapsed;
    this.Qals1.Visibility = Visibility.Collapsed;
    this.Yayl1.Visibility = Visibility.Collapsed;
    this.Jilet1.Visibility = Visibility.Collapsed;
    this.Corab1.Visibility = Visibility.Collapsed;
    this.Ayaq1.Visibility = Visibility.Collapsed;
    this.Kemer1.Visibility = Visibility.Collapsed;
    this.Qurs1.Visibility = Visibility.Collapsed;
    this.Bab1.Visibility = Visibility.Collapsed;
  }

  private void Kost_OnGotFocus(
  #nullable enable
  object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost1.Visibility = Visibility.Visible;
    this.Kost2.Visibility = Visibility.Visible;
    this.Kost3.Visibility = Visibility.Visible;
    this.Kost4.Visibility = Visibility.Visible;
    this.Kost5.Visibility = Visibility.Visible;
    this.Kost6.Visibility = Visibility.Visible;
    this.Kost7.Visibility = Visibility.Visible;
  }

  private void Koy_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Koy1.Visibility = Visibility.Visible;
    this.Koy2.Visibility = Visibility.Visible;
  }

  private void Zap_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Zap1.Visibility = Visibility.Visible;
  }

  private void Qals_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Qals1.Visibility = Visibility.Visible;
  }

  private void Yayl_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Yayl1.Visibility = Visibility.Visible;
  }

  private void Jilet_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Jilet1.Visibility = Visibility.Visible;
  }

  private void Corab_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Corab1.Visibility = Visibility.Visible;
  }

  private void Ayag_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Ayaq1.Visibility = Visibility.Visible;
  }

  private void Kemer_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Kemer1.Visibility = Visibility.Visible;
  }

  private void Qurs_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Qurs1.Visibility = Visibility.Visible;
  }

  private void Bab_OnGotFocus(object sender, RoutedEventArgs e)
  {
    this.ResetAllShowenBoxes();
    this.Kost2.Visibility = Visibility.Collapsed;
    this.Koy2.Visibility = Visibility.Hidden;
    this.Bab1.Visibility = Visibility.Visible;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/msbookview.xaml", UriKind.Relative));
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
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Kost_OnGotFocus);
        break;
      case 2:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Koy_OnGotFocus);
        break;
      case 3:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Zap_OnGotFocus);
        break;
      case 4:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Qals_OnGotFocus);
        break;
      case 5:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Yayl_OnGotFocus);
        break;
      case 6:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Jilet_OnGotFocus);
        break;
      case 7:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Corab_OnGotFocus);
        break;
      case 8:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Ayag_OnGotFocus);
        break;
      case 9:
        this.Kost1 = (StackPanel) target;
        break;
      case 10:
        this.Koy1 = (StackPanel) target;
        break;
      case 11:
        this.Zap1 = (StackPanel) target;
        break;
      case 12:
        this.Qals1 = (StackPanel) target;
        break;
      case 13:
        this.Yayl1 = (StackPanel) target;
        break;
      case 14:
        this.Jilet1 = (StackPanel) target;
        break;
      case 15:
        this.Corab1 = (StackPanel) target;
        break;
      case 16 /*0x10*/:
        this.Ayaq1 = (StackPanel) target;
        break;
      case 17:
        this.Kemer1 = (StackPanel) target;
        break;
      case 18:
        this.Qurs1 = (StackPanel) target;
        break;
      case 19:
        this.Bab1 = (StackPanel) target;
        break;
      case 20:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Kemer_OnGotFocus);
        break;
      case 21:
        this.Kost2 = (StackPanel) target;
        break;
      case 22:
        this.Koy2 = (StackPanel) target;
        break;
      case 23:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Qurs_OnGotFocus);
        break;
      case 24:
        this.Kost3 = (StackPanel) target;
        break;
      case 25:
        ((UIElement) target).GotFocus += new RoutedEventHandler(this.Bab_OnGotFocus);
        break;
      case 26:
        this.Kost4 = (StackPanel) target;
        break;
      case 27:
        this.Kost5 = (StackPanel) target;
        break;
      case 28:
        this.Kost6 = (StackPanel) target;
        break;
      case 29:
        this.Kost8 = (StackPanel) target;
        break;
      case 30:
        this.Kost7 = (StackPanel) target;
        break;
      case 31 /*0x1F*/:
        this.YeniQiymetler = (TabItem) target;
        break;
      case 32 /*0x20*/:
        this.Qruplar = (TabItem) target;
        break;
      case 33:
        this.Firmalar = (TabItem) target;
        break;
      case 34:
        this.Modeller = (TabItem) target;
        break;
      case 35:
        this.Qiymetler = (TabItem) target;
        break;
      case 36:
        this.MSK1 = (TabItem) target;
        break;
      case 37:
        this.Dasdads = (DataGrid) target;
        break;
      case 38:
        this.Musteriler = (TabItem) target;
        break;
      case 39:
        this.Olculer = (TabItem) target;
        break;
      case 40:
        this.Rengler = (TabItem) target;
        break;
      case 41:
        this.Parcalar = (TabItem) target;
        break;
      case 42:
        this.Emekhaqqlari = (TabItem) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
