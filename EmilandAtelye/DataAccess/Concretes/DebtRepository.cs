// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.DebtRepository
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

public class DebtRepository(string connectionString) : BaseSqlRepository(connectionString), IDebtRepository
{
  public async Task<IEnumerable<Debt>> GetDebtsByDepartmentIdAsync(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Debt> debts = await conn.QueryAsync<Debt>("exec SP_IU_AZSCUSTOMER default,2,default,default,default,default,default,@id,default", (object) new
    {
      id = departmentId
    });
    await conn.CloseAsync();
    IEnumerable<Debt> departmentIdAsync = debts;
    conn = (SqlConnection) null;
    debts = (IEnumerable<Debt>) null;
    return departmentIdAsync;
  }

  public async Task<IEnumerable<DebtForOrder>> GetDebtsForOrderAsync(int departmentId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<DebtForOrder> debts = await conn.QueryAsync<DebtForOrder>("exec SP_IU_AZSFINANCE;1 default,default,default,2,@id,default,default", (object) new
    {
      id = departmentId
    });
    await conn.CloseAsync();
    IEnumerable<DebtForOrder> debtsForOrderAsync = debts;
    conn = (SqlConnection) null;
    debts = (IEnumerable<DebtForOrder>) null;
    return debtsForOrderAsync;
  }

  public async Task<bool> UpdateDebtAsync(Debt updatedDebt)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int result = await conn.ExecuteAsync("update AZSCUSTOMER\r\n            set DEPARTID = @departId, CUSNAME = @name,\r\n                CUSSURNAME = @surname, CUSFATHERNAME = @fathername, CUSTELNO = @telNo,\r\n                CUSGSM = @gsm, REMAINTOTALALL = @remainTotalAll, CALLID = @callId,\r\n                CALLIDTIME = @callIdTime, SMSID = @smsId, SMSIDTIME = @smsIdTime,\r\n                CALLNOTE = @note, CALLID2 = @callId2, CALLIDTIME2 = @callIdTime2,\r\n                SMSID2 = @smsId2, SMSIDTIME2 = @smsIdTime2, CALLID3 = @callId3,\r\n\r\n                CALLIDTIME3 = @callIdTime3, SMSID3 = @smsId3, SMSIDTIME3 = @smsIdTime3,\r\n                LASTTIME = @lastTime\r\n            where CUSTOMERID = @customerId", (object) new
    {
      customerId = updatedDebt.CustomerId,
      departId = updatedDebt.DepartId,
      name = updatedDebt.CusName,
      surname = updatedDebt.CusSurname,
      fathername = updatedDebt.CusFatherName,
      telNo = updatedDebt.CusTelNo,
      gsm = updatedDebt.CusGSM,
      remainTotalAll = updatedDebt.RemainTotalAll,
      callId = updatedDebt.CallId,
      callIdTime = updatedDebt.CallIdTime,
      smsId = updatedDebt.SmsId,
      smsIdTime = updatedDebt.SmsIdTime,
      note = updatedDebt.CallNote,
      callId2 = updatedDebt.CallId2,
      callIdTime2 = updatedDebt.CallIdTime2,
      smsId2 = updatedDebt.SmsId2,
      smsIdTime2 = updatedDebt.SmsIdTime2,
      callId3 = updatedDebt.CallId3,
      callIdTime3 = updatedDebt.CallIdTime3,
      smsId3 = updatedDebt.SmsId3,
      smsIdTime3 = updatedDebt.SmsIdTime3,
      lastTime = updatedDebt.LastTime
    });
    await conn.CloseAsync();
    bool flag = result != 0;
    conn = (SqlConnection) null;
    return flag;
  }
}
