// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CustomerRepository
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

public class CustomerRepository(string connectionString) : BaseSqlRepository(connectionString), ICustomerRepository
{
  public async Task<IEnumerable<Customer>> GetAllCustomers()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Customer> customers = await conn.QueryAsync<Customer>("exec SP_IU_AZSCUSTOMER;1");
    await conn.CloseAsync();
    IEnumerable<Customer> allCustomers = customers;
    conn = (SqlConnection) null;
    customers = (IEnumerable<Customer>) null;
    return allCustomers;
  }

  public async Task<IEnumerable<Customer>> GetAllCustomersForDeparts(int DepartId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Customer> customers = await conn.QueryAsync<Customer>("\tSELECT  DEPARTID, CAST(CUSTOMERID AS nvarchar) AS CUSTOMERID, CUSNAME, CUSSURNAME, CUSFATHERNAME, CUSTELNO, CUSGSM\r\n\tFROM         dbo.AZSCUSTOMER\r\n\twhere DEPARTID = @departId or DEPARTID = 11\r\n\t\tORDER BY CAST(CUSTOMERID AS nvarchar), CUSNAME, CUSSURNAME", (object) new
    {
      departId = DepartId
    });
    await conn.CloseAsync();
    IEnumerable<Customer> customersForDeparts = customers;
    conn = (SqlConnection) null;
    customers = (IEnumerable<Customer>) null;
    return customersForDeparts;
  }

  public async Task<Customer> GetCustomerById(string id, int DepartId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    Customer customers = await conn.QueryFirstOrDefaultAsync<Customer>("SELECT * FROM AZSCUSTOMER WHERE CustomerId = @customerid and (DEPARTID = @departId or DEPARTID = 11)", (object) new
    {
      customerid = id,
      departId = DepartId
    });
    await conn.CloseAsync();
    Customer customerById = customers;
    conn = (SqlConnection) null;
    customers = (Customer) null;
    return customerById;
  }

  public async Task<int> GetMaxCustomerId()
  {
    await using (SqlConnection conn = await this.OpenSqlConnectionAsync())
      return await conn.QueryFirstOrDefaultAsync<int>("select MAX(CUSTOMERID) FROM AZSCUSTOMER");
  }

  public async Task<bool> InsertCustomer(CustomerInsert customer)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int result = await conn.ExecuteAsync("INSERT INTO AZSCUSTOMER (\r\n    customerid,regDate, reguid, editDate, editUid, departId, cusName, cusSurname, cusFatherName, \r\n    cusTelNo, cusGsm, cusrelation, remainTotalAll, callId, callIdTime, callId2, callIdTime2, \r\n    callId3, callIdTime3, smsId, smsIdTime, smsId2, smsIdTime2, smsId3, smsIdTime3, \r\n    callNote, lastTime, gCallId, gCallIdTime, gCallId2, gCallIdTime2, gCallId3, gCallIdTime3, \r\n    gSmsId, gSmsIdTime, gSmsId2, gSmsIdTime2, gSmsId3, gSmsIdTime3, gCallNote, gLastTime, \r\n    fittingId, given_note\r\n) VALUES (\r\n    @cusId,@regDate, @reguid, @editDate, @editUid, @departId, @cusName, @cusSurname, @cusFatherName, \r\n    @cusTelNo, @cusGsm, @cusRelation, @remainTotalAll, @callId, @callIdTime, @callId2, @callIdTime2, \r\n    @callId3, @callIdTime3, @smsId, @smsIdTime, @smsId2, @smsIdTime2, @smsId3, @smsIdTime3, \r\n    @callNote, @lastTime, @gCallId, @gCallIdTime, @gCallId2, @gCallIdTime2, @gCallId3, @gCallIdTime3, \r\n    @gSmsId, @gSmsIdTime, @gSmsId2, @gSmsIdTime2, @gSmsId3, @gSmsIdTime3, @gCallNote, @gLastTime, \r\n    @fittingId, @given_note\r\n);\r\n", (object) new
    {
      cusId = customer.CustomerId,
      regDate = customer.RegDate,
      reguid = customer.RegGuid,
      editDate = customer.EditDate,
      editUid = customer.EditUid,
      departId = customer.DepartId,
      cusName = customer.CusName,
      cusSurname = customer.CusSurname,
      cusFatherName = customer.CusFatherName,
      cusTelNo = customer.CusTelNo,
      cusGsm = customer.CusGsm,
      cusRelation = customer.CusRelation,
      remainTotalAll = customer.RemainTotalAll,
      callId = customer.CallId,
      callIdTime = customer.CallIdTime,
      callId2 = customer.CallId2,
      callIdTime2 = customer.CallIdTime2,
      callId3 = customer.CallId3,
      callIdTime3 = customer.CallIdTime3,
      smsId = customer.SmsId,
      smsIdTime = customer.SmsIdTime,
      smsId2 = customer.SmsId2,
      smsIdTime2 = customer.SmsIdTime2,
      smsId3 = customer.SmsId3,
      smsIdTime3 = customer.SmsIdTime3,
      callNote = customer.CallNote,
      lastTime = customer.LastTime,
      gCallId = customer.GCallId,
      gCallIdTime = customer.GCallIdTime,
      gCallId2 = customer.GCallId2,
      gCallIdTime2 = customer.GCallIdTime2,
      gCallId3 = customer.GCallId3,
      gCallIdTime3 = customer.GCallIdTime3,
      gSmsId = customer.GSmsId,
      gSmsIdTime = customer.GSmsIdTime,
      gSmsId2 = customer.GSmsId2,
      gSmsIdTime2 = customer.GSmsIdTime2,
      gSmsId3 = customer.GSmsId3,
      gSmsIdTime3 = customer.GSmsIdTime3,
      gCallNote = customer.GCallNote,
      gLastTime = customer.GLastTime,
      fittingId = customer.FittingId,
      given_note = customer.Given_Note
    });
    await conn.CloseAsync();
    bool flag = result != 0;
    conn = (SqlConnection) null;
    return flag;
  }
}
