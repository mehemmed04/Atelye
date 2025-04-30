// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.Ironings.IroningDailyView
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

#nullable enable
namespace EmilandAtelye.Domain.Views.Ironings;

public partial class IroningDailyView : UserControl, IComponentConnector
{
  private bool _contentLoaded;

  public IroningDailyView() => this.InitializeComponent();

  private void Button_Click(object sender, RoutedEventArgs e)
  {
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/ironings/ironingdailyview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, 
  #nullable disable
  object target)
  {
    if (connectionId == 1)
      ((ButtonBase) target).Click += new RoutedEventHandler(this.Button_Click);
    else
      this._contentLoaded = true;
  }
}
