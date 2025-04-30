// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.ChangesViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DataAccess.Abstracts;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class ChangesViewModel : BaseViewModel
{
  private IUnitOfWork _unitOfWork { get; set; }

  public ChangesViewModel(IUnitOfWork unitOfWork) => this._unitOfWork = unitOfWork;
}
