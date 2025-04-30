// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Views.Cashboxs.CashboxView
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
namespace EmilandAtelye.Domain.Views.Cashboxs;

public partial class CashboxView : UserControl, IComponentConnector
{
  internal 
  #nullable disable
  Button MyButton;
  internal Button MyButton2;
  private bool _contentLoaded;

  public CashboxView() => this.InitializeComponent();

  private void TextBox_TextChanged(
  #nullable enable
  object sender, TextChangedEventArgs e)
  {
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/EmilandAtelye;V1.0.1.19;component/domain/views/cashboxs/cashboxview.xaml", UriKind.Relative));
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
        this.MyButton2 = (Button) target;
      else
        this._contentLoaded = true;
    }
    else
      this.MyButton = (Button) target;
  }
}
