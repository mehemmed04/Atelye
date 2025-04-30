// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.DailyCashBoxMI
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Reflection;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class DailyCashBoxMI
{
  public int DailyCashId { get; set; }

  public DateTime RegDate { get; set; }

  public string RegUid { get; set; }

  public DateTime? EditDate { get; set; }

  public float EditUid { get; set; }

  public int? DepartId { get; set; }

  public DateTime OperDate { get; set; }

  public float? EditBefRemUsd { get; set; }

  public float? EditBefRemAzn { get; set; }

  public float? EditBefRemUsdBref { get; set; }

  public float? EditBefRemAznBref { get; set; }

  public float? Edit1Usd { get; set; }

  public float? Edit1Azn { get; set; }

  public float? Edit1BUsd { get; set; }

  public float? Edit1BAzn { get; set; }

  public float? Edit1UsdM { get; set; }

  public float? Edit1AznM { get; set; }

  public float? Edit1BAznM { get; set; }

  public float? EditB1Usd { get; set; }

  public float? EditB1Azn { get; set; }

  public float? EditB1BUsd { get; set; }

  public float? EditB1BAzn { get; set; }

  public float? EditB1UsdM { get; set; }

  public float? EditB1AznM { get; set; }

  public float? EditB1BAznM { get; set; }

  public float? Edit4Usd { get; set; }

  public float? Edit4Azn { get; set; }

  public float? Edit4BUsd { get; set; }

  public float? Edit4BAzn { get; set; }

  public float? Edit4UsdM { get; set; }

  public float? Edit4AznM { get; set; }

  public float? Edit4BAznM { get; set; }

  public float? Edit5Usd { get; set; }

  public float? Edit5Azn { get; set; }

  public float? Edit5BUsd { get; set; }

  public float? Edit5BAzn { get; set; }

  public float? Edit5UsdM { get; set; }

  public float? Edit5AznM { get; set; }

  public float? Edit5BAznM { get; set; }

  public float? EditAllUsd { get; set; }

  public float? EditAllAzn { get; set; }

  public float? EditAllBUsd { get; set; }

  public float? EditAllBAzn { get; set; }

  public float? EditAllUsdM { get; set; }

  public float? EditAllAznM { get; set; }

  public float? EditAllBUsdM { get; set; }

  public float? EditAllBAznM { get; set; }

  public float? EditExpenseUsd { get; set; }

  public float? EditExpenseAzn { get; set; }

  public float? EditExpenseUsdBref { get; set; }

  public float? EditExpenseAznBref { get; set; }

  public float? EditCurRemUsd { get; set; }

  public float? EditCurRemAzn { get; set; }

  public float? EditCurRemUsdBref { get; set; }

  public float? EditCurRemAznBref { get; set; }

  public int? EditSuit { get; set; }

  public int? EditJacket { get; set; }

  public int? EditPants { get; set; }

  public int? EditShirt { get; set; }

  public int? EditWaistcoat { get; set; }

  public int? EditOvercoat { get; set; }

  public int? EditRaincoat { get; set; }

  public byte? Status { get; set; }

  public string Fin2Cash2 { get; set; }

  public byte CheckYes1No0 { get; set; }

  public DailyCashBoxMI()
  {
    foreach (PropertyInfo property in this.GetType().GetProperties())
    {
      if (property.PropertyType == typeof (float))
        property.SetValue((object) this, (object) 0.0f);
    }
  }
}
