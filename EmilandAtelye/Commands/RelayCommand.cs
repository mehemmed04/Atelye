// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Commands.RelayCommand
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Windows.Input;

#nullable enable
namespace EmilandAtelye.Commands;

public class RelayCommand : ICommand
{
  private Action<object> _execute;
  private Predicate<object> _canExecute;

  public event EventHandler CanExecuteChanged
  {
    add => CommandManager.RequerySuggested += value;
    remove => CommandManager.RequerySuggested -= value;
  }

  public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
  {
    this._execute = execute != null ? execute : throw new ArgumentNullException();
    this._canExecute = canExecute;
  }

  public bool CanExecute(object parameter)
  {
    return this._canExecute == null || this._canExecute(parameter);
  }

  public void Execute(object parameter) => this._execute(parameter);
}
