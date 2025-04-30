// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.DepartmentRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class DepartmentRepository(string connectionString) : BaseSqlRepository(connectionString), IDepartmentRepository
{
  public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Department> departments = await conn.QueryAsync<Department>("select DEPARTID as DepartmentId, \r\n                REGDATE as RegistrationDate, REGUID as Reguid, EDITDATE as EditDate, EDITUID as EditUid,\r\n                DEPARTNAME as DepartmentName, DEPARTSHORTNAME as DepartmentShortName, CURRENTDEPART as CurrentDepartment,\r\n                STATUS as Status, DTAXID as DtaxId,DTAXDUTYID as DtaxDutyId,DLEGALFORMID as LegalFormId,DCHIEFFULLNAME as ChiefFullName,\r\n                DCHIEFSHORTNAME as ChiefShortName, DCHIEFACCOUNTANT as ChiefAccountant, DCHIEFACCOUNTANTSHORT as ChiefAccountantShort,\r\n                DACCOUNTANT as Accountant, DBANKID as BankId, BANKNAME as BankName, BANKTAXID as BankTaxId, BANKSHOT as BankShot,\r\n                BANKSWIFT as BankSwift, SINVDETROWCOUNT as CountRow, ADDRESS as Address, ST as St,\r\n                EXTRAFEE as ExtraFee from dbo.LPRODEPART");
    await conn.CloseAsync();
    IEnumerable<Department> departmentsAsync = departments;
    conn = (SqlConnection) null;
    departments = (IEnumerable<Department>) null;
    return departmentsAsync;
  }

  public async Task<Department> GetDepartmentByIdAsync(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    Department department = await conn.QueryFirstOrDefaultAsync<Department>("select DEPARTID as DepartmentId, \r\n                REGDATE as RegistrationDate, REGUID as Reguid, EDITDATE as EditDate, EDITUID as EditUid,\r\n                DEPARTNAME as DepartmentName, DEPARTSHORTNAME as DepartmentShortName, CURRENTDEPART as CurrentDepartment,\r\n                STATUS as Status, DTAXID as DtaxId,DTAXDUTYID as DtaxDutyId,DLEGALFORMID as LegalFormId,DCHIEFFULLNAME as ChiefFullName,\r\n                DCHIEFSHORTNAME as ChiefShortName, DCHIEFACCOUNTANT as ChiefAccountant, DCHIEFACCOUNTANTSHORT as ChiefAccountantShort,\r\n                DACCOUNTANT as Accountant, DBANKID as BankId, BANKNAME as BankName, BANKTAXID as BankTaxId, BANKSHOT as BankShot,\r\n                BANKSWIFT as BankSwift, SINVDETROWCOUNT as CountRow, ADDRESS as Address, ST as St,\r\n                EXTRAFEE as ExtraFee from dbo.LPRODEPART where DEPARTID = @ID", (object) new
    {
      ID = departmentId
    });
    await conn.CloseAsync();
    Department departmentByIdAsync = department;
    conn = (SqlConnection) null;
    department = (Department) null;
    return departmentByIdAsync;
  }

  public async Task<Department> AddDepartmentAsync(Department newDepartment)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("insert into LPRODEPART (DEPARTID, REGDATE, REGUID, EDITDATE, EDITUID,\r\n                        DEPARTNAME, DEPARTSHORTNAME, CURRENTDEPART, STATUS,\r\n                        DTAXID, DTAXDUTYID, DLEGALFORMID, DCHIEFFULLNAME,\r\n                        DCHIEFSHORTNAME, DCHIEFACCOUNTANT, DCHIEFACCOUNTANTSHORT,\r\n                        DACCOUNTANT, DBANKID, BANKNAME, BANKTAXID, BANKSHOT, BANKSWIFT,\r\n                        SINVDETROWCOUNT, ADDRESS, ST, EXTRAFEE)\r\n                values (@DepartmentId, @RegistrationDate, @Reguid, @EditDate, @EditUid, @DepartmentName,\r\n                        @DepartmentShortName, @CurrentDepartment, @Status, @DtaxId, @DtaxDutyId, @LegalFormId, @ChiefFullName, @ChiefShortName,\r\n                        @ChiefAccountant, @ChiefAccountantShort, @Accountant, @BankId, @BankName, @BankTaxId, @BankShot, @BankSwift,\r\n                        @CountRow, @Address, @St, @ExtraFee)", (object) new
    {
      DepartmentId = newDepartment.DepartmentId,
      RegistrationDate = newDepartment.RegistrationDate,
      Reguid = newDepartment.Reguid,
      EditDate = newDepartment.EditDate,
      EditUid = newDepartment.EditUid,
      DepartmentName = newDepartment.DepartmentName,
      DepartmentShortName = newDepartment.DepartmentShortName,
      CurrentDepartment = newDepartment.CurrentDepartment,
      Status = newDepartment.Status,
      DtaxId = newDepartment.DtaxId,
      DtaxDutyId = newDepartment.DtaxDutyId,
      LegalFormId = newDepartment.LegalFormId,
      ChiefFullName = newDepartment.ChiefFullName,
      ChiefShortName = newDepartment.ChiefShortName,
      ChiefAccountant = newDepartment.ChiefAccountant,
      ChiefAccountantShort = newDepartment.ChiefAccountantShort,
      Accountant = newDepartment.Accountant,
      BankId = newDepartment.BankId,
      BankName = newDepartment.BankName,
      BankTaxId = newDepartment.BankTaxId,
      BankShot = newDepartment.BankShot,
      BankSwift = newDepartment.BankSwift,
      CountRow = newDepartment.CountRow,
      Address = newDepartment.Address,
      St = newDepartment.St,
      ExtraFee = newDepartment.ExtraFee
    });
    await conn.CloseAsync();
    Department department = newDepartment;
    conn = (SqlConnection) null;
    return department;
  }
}
