// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.Models.Employee
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;

#nullable enable
namespace EmilandAtelye.Domain.Models;

public class Employee
{
  public int EmployeeId { get; set; }

  public DateTime RegDate { get; set; }

  public string Reguid { get; set; }

  public DateTime? EditDate { get; set; }

  public string? Edituid { get; set; }

  public int? DepartId { get; set; }

  public string EmpName { get; set; }

  public string EmpDuty { get; set; }

  public string? EmpTelNo { get; set; }

  public string? EmpGsm { get; set; }

  public string? EmpNote { get; set; }

  public int EmployeeGroupId { get; set; }

  public Decimal EmpTakenDebt { get; set; }

  public float EmpFixSalary { get; set; }

  public float EmpFixAdvance { get; set; }

  public float EmpTakenAdvanceBef { get; set; }

  public float EmpTakenAdvance { get; set; }

  public float EmpSalaryRem { get; set; }

  public float EmpTakenBonusBef { get; set; }

  public float EmpTakenBonus { get; set; }

  public float EmpTakenSalary { get; set; }

  public byte St { get; set; }

  public byte EmpStatus { get; set; }

  public string Eg { get; set; }
}
