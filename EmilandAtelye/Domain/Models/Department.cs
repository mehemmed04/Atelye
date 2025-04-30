// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Department
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Department
{
  public int DepartmentId { get; set; }

  public DateTime RegistrationDate { get; set; }

  public string Reguid { get; set; }

  public DateTime? EditDate { get; set; }

  public string EditUid { get; set; }

  public string DepartmentName { get; set; }

  public string DepartmentShortName { get; set; }

  public int CurrentDepartment { get; set; }

  public int Status { get; set; }

  public string DtaxId { get; set; }

  public int DtaxDutyId { get; set; }

  public int LegalFormId { get; set; }

  public string ChiefFullName { get; set; }

  public string ChiefShortName { get; set; }

  public string ChiefAccountant { get; set; }

  public string ChiefAccountantShort { get; set; }

  public string Accountant { get; set; }

  public string BankId { get; set; }

  public string BankName { get; set; }

  public string BankTaxId { get; set; }

  public string BankShot { get; set; }

  public string BankSwift { get; set; }

  public int CountRow { get; set; }

  public string Address { get; set; }

  public int St { get; set; }

  public int ExtraFee { get; set; }
}
