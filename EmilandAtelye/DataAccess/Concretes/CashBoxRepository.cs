// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CashBoxRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class CashBoxRepository(string connectionString) : BaseSqlRepository(connectionString), ICashboxRepository
{
  public async Task<DailyCashBox?> GetDailyCashBoxesAsync(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    DailyCashBox cashBoxes = await conn.QueryFirstOrDefaultAsync<DailyCashBox>("SELECT *\r\nFROM AZSDAILYCASH\r\nWHERE CONVERT(VARCHAR, OPERDATE, 23)  = @date", (object) new
    {
      date = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    DailyCashBox dailyCashBoxesAsync = cashBoxes;
    conn = (SqlConnection) null;
    cashBoxes = (DailyCashBox) null;
    return dailyCashBoxesAsync;
  }

  public async Task<DailyCashBoxMI?> GetDailyCashBoxesMIAsync(DateTime date)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    DailyCashBoxMI cashBoxes = await conn.QueryFirstOrDefaultAsync<DailyCashBoxMI>("SELECT *\r\nFROM AZSDAILYCASH2\r\nWHERE CONVERT(VARCHAR, OPERDATE, 23)  = @date", (object) new
    {
      date = date.ToString("yyyy-MM-dd")
    });
    await conn.CloseAsync();
    DailyCashBoxMI cashBoxesMiAsync = cashBoxes;
    conn = (SqlConnection) null;
    cashBoxes = (DailyCashBoxMI) null;
    return cashBoxesMiAsync;
  }

  public async Task<int> InsertDailyCashAsync(DailyCashBox dailyCash)
  {
    int num;
    using (SqlConnection connection = await this.OpenSqlConnectionAsync())
      num = await connection.QuerySingleAsync<int>("\r\n            INSERT INTO AZSDAILYCASH\r\n            (REGDATE, REGUID, EDITDATE, EDITUID, CHECKYES1NO0, DEPARTID, OPERDATE, \r\n             EDITBEFREMUSD, EDITBEFREMAZN, EDITBEFREMAZNBREF, EDIT1USD, EDIT1AZN, EDIT1BUSDM,\r\n             EDITB1USD, EDITB1AZN, EDITB1BUSDM, EDIT2USD, EDIT2AZN, EDIT2BUSDM, \r\n             EDIT3USD, EDIT3AZN, EDIT3BUSDM, EDIT4USD, EDIT4AZN, EDIT4BUSDM, EDIT5USD, \r\n             EDIT5AZN, EDIT5BUSDM, EDIT7USD, EDIT7AZN, EDIT7BUSDM, EDIT8USD, EDIT8AZN, \r\n             EDIT8BUSDM, EDIT9USD, EDIT9AZN, EDIT9BUSDM, EDIT10USD, EDIT10AZN, EDIT10BUSDM, \r\n             EDITALLUSD, EDITALLAZN, EDITALLBUSD, EDITEXPENSEUSD, EDITEXPENSEAZN, EDITCURREMUSD, \r\n             EDITCURREMAZN, STATUS, EDITSUIT, EDITJACKET, EDITPANTS, EDITSHIRT, EDITWAISTCOAT, \r\n             EDITOVERCOAT, EDITRAINCOAT, FIN2CASH)\r\n            VALUES\r\n            (@RegDate, @RegUid, @EditDate, @EditUid, @CheckYes1No0, @DepartId, @OperDate, \r\n             @EditBefRemUsd, @EditBefRemAzn, @EditBefRemAznBref, @Edit1Usd, @Edit1Azn, @Edit1BUsd, \r\n             @EditB1Usd, @EditB1Azn, @EditB1BUsd, @Edit2Usd, @Edit2Azn, @Edit2BUsd, \r\n             @Edit3Usd, @Edit3Azn, @Edit3BUsd, @Edit4Usd, @Edit4Azn, @Edit4BUsd, @Edit5Usd, \r\n             @Edit5Azn, @Edit5BUsd, @Edit7Usd, @Edit7Azn, @Edit7BUsd, @Edit8Usd, @Edit8Azn, \r\n             @Edit8BUsd, @Edit9Usd, @Edit9Azn, @Edit9BUsd, @Edit10Usd, @Edit10Azn, @Edit10BUsd, \r\n             @EditAllUsd, @EditAllAzn, @EditAllBUsd, @EditExpenseUsd, @EditExpenseAzn, @EditCurRemUsd, \r\n             @EditCurRemAzn, @Status, @EditSuit, @EditJacket, @EditPants, @EditShirt, @EditWaistcoat, \r\n             @EditOvercoat, @EditRaincoat, @Fin2Cash);\r\n            SELECT CAST(SCOPE_IDENTITY() as int);", (object) dailyCash);
    return num;
  }

  public async Task<int> InsertDailyCashMIAsync(DailyCashBoxMI dailyCashMI)
  {
    int num;
    using (SqlConnection connection = await this.OpenSqlConnectionAsync())
      num = await connection.QuerySingleAsync<int>(" INSERT INTO AZSDAILYCASH2\r\n            (REGDATE, REGUID, EDITDATE, EDITUID, CHECKYES1NO0, DEPARTID, OPERDATE, \r\n             EDITBEFREMUSD, EDITBEFREMAZN, EDITBEFREMAZNBREF, EDIT1USD, EDIT1AZN, EDIT1BUSDM,\r\n             EDITB1USD, EDITB1AZN, EDITB1BUSDM, EDIT4USD, EDIT4AZN, EDIT4BUSDM, EDIT5USD, \r\n             EDIT5AZN, EDIT5BUSDM,EDITALLUSD, EDITALLAZN, EDITALLBUSD, EDITEXPENSEUSD, EDITEXPENSEAZN, EDITCURREMUSD, \r\n             EDITCURREMAZN, STATUS, EDITSUIT, EDITJACKET, EDITPANTS, EDITSHIRT, EDITWAISTCOAT, \r\n             EDITOVERCOAT, EDITRAINCOAT)\r\n            VALUES\r\n            (@RegDate, @RegUid, @EditDate, @EditUid, @CheckYes1No0, @DepartId, @OperDate, \r\n             @EditBefRemUsd, @EditBefRemAzn, @EditBefRemAznBref, @Edit1Usd, @Edit1Azn, @Edit1BUsd, \r\n             @EditB1Usd, @EditB1Azn, @EditB1BUsd,  @Edit4Usd, @Edit4Azn, @Edit4BUsd, @Edit5Usd, \r\n             @Edit5Azn, @Edit5BUsd, @EditAllUsd, @EditAllAzn, @EditAllBUsd, @EditExpenseUsd, @EditExpenseAzn, @EditCurRemUsd, \r\n             @EditCurRemAzn, @Status, @EditSuit, @EditJacket, @EditPants, @EditShirt, @EditWaistcoat, \r\n             @EditOvercoat, @EditRaincoat);\r\n            SELECT CAST(SCOPE_IDENTITY() as int);", (object) dailyCashMI);
    return num;
  }

  public async Task<int> UpdateDailyCashAsync(DailyCashBox dailyCash)
  {
    CashBoxRepository cashBoxRepository = this;
    try
    {
      using (SqlConnection connection = await cashBoxRepository.OpenSqlConnectionAsync())
        return await connection.ExecuteAsync("\r\n            UPDATE AZSDAILYCASH\r\n            SET \r\n                REGDATE = @RegDate,\r\n                REGUID = @RegUid,\r\n                EDITDATE = @EditDate,\r\n                EDITUID = @EditUid,\r\n                CHECKYES1NO0 = @CheckYes1No0,\r\n                DEPARTID = @DepartId,\r\n                OPERDATE = @OperDate,\r\n                EDITBEFREMUSD = @EditBefRemUsd,\r\n                EDITBEFREMAZN = @EditBefRemAzn,\r\n                EDITBEFREMAZNBREF = @EditBefRemAznBref,\r\n                EDIT1USD = @Edit1Usd,\r\n                EDIT1AZN = @Edit1Azn,\r\n                EDIT1BUSDM = @Edit1BUsd,\r\n                EDITB1USD = @EditB1Usd,\r\n                EDITB2AZN=@EditB2Azn,  \r\n                EDITB3AZN=@EditB3Azn,\r\n                EDITB9AZN=@EditB9Azn,\r\n                EDIT1BAZN=@Edit1BAzn,\r\n                EDIT2BAZN=@Edit2BAzn,\r\n                EDIT3BAZN=@Edit3BAzn,\r\n                EDIT9BAZN=@Edit9BAzn,\r\n                EDITB1AZN = @EditB1Azn,\r\n                EDITB1BUSDM = @EditB1BUsd,\r\n                EDIT2USD = @Edit2Usd,\r\n                EDIT2AZN = @Edit2Azn,\r\n                EDIT2BUSDM = @Edit2BUsd,\r\n                EDIT3USD = @Edit3Usd,\r\n                EDIT3AZN = @Edit3Azn,\r\n                EDIT3BUSDM = @Edit3BUsd,\r\n                EDIT4USD = @Edit4Usd,\r\n                EDIT4AZN = @Edit4Azn,\r\n                EDIT4BUSDM = @Edit4BUsd,\r\n                EDIT5USD = @Edit5Usd,\r\n                EDIT5AZN = @Edit5Azn,\r\n                EDIT5BUSDM = @Edit5BUsd,\r\n                EDIT7USD = @Edit7Usd,\r\n                EDIT7AZN = @Edit7Azn,\r\n                EDIT7BUSDM = @Edit7BUsd,\r\n                EDIT8USD = @Edit8Usd,\r\n                EDIT8AZN = @Edit8Azn,\r\n                EDIT8BUSDM = @Edit8BUsd,\r\n                EDIT9USD = @Edit9Usd,\r\n                EDIT9AZN = @Edit9Azn,\r\n                EDIT9BUSDM = @Edit9BUsd,\r\n                EDIT10USD = @Edit10Usd,\r\n                EDIT10AZN = @Edit10Azn,\r\n                EDIT10BUSDM = @Edit10BUsd,\r\n                EDITALLUSD = @EditAllUsd,\r\n                EDITALLAZN = @EditAllAzn,\r\n                EDITALLBUSD = @EditAllBUsd,\r\n                EDITEXPENSEUSD = @EditExpenseUsd,\r\n                EDITEXPENSEAZN = @EditExpenseAzn,\r\n                EDITCURREMUSD = @EditCurRemUsd,\r\n                EDITCURREMAZN = @EditCurRemAzn,\r\n                STATUS = @Status,\r\n                EDITSUIT = @EditSuit,\r\n                EDITJACKET = @EditJacket,\r\n                EDITPANTS = @EditPants,\r\n                EDITSHIRT = @EditShirt,\r\n                EDITWAISTCOAT = @EditWaistcoat,\r\n                EDITOVERCOAT = @EditOvercoat,\r\n                EDITRAINCOAT = @EditRaincoat,\r\n                FIN2CASH = @Fin2Cash\r\n            WHERE DAILYCASHID = @DailyCashId", (object) dailyCash);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
    return 0;
  }

  public async Task<int> UpdateDailyCashMIAsync(DailyCashBoxMI dailyCashMI)
  {
    CashBoxRepository cashBoxRepository = this;
    try
    {
      using (SqlConnection connection = await cashBoxRepository.OpenSqlConnectionAsync())
        return await connection.ExecuteAsync("\r\n                        UPDATE AZSDAILYCASH2\r\n            SET \r\n                REGDATE = @RegDate,\r\n                REGUID = @RegUid,\r\n                EDITDATE = @EditDate,\r\n                EDITUID = @EditUid,\r\n                CHECKYES1NO0 = @CheckYes1No0,\r\n                DEPARTID = @DepartId,\r\n                OPERDATE = @OperDate,\r\n                EDITBEFREMUSD = @EditBefRemUsd,\r\n                EDITBEFREMAZN = @EditBefRemAzn,\r\n                EDITBEFREMAZNBREF = @EditBefRemAznBref,\r\n                EDIT1USD = @Edit1Usd,\r\n                EDIT1AZN = @Edit1Azn,\r\n                EDIT1BUSDM = @Edit1BUsd,\r\n                EDITB1USD = @EditB1Usd,\r\n                EDIT1BAZN=@Edit1BAzn,\r\n                EDITB1AZN = @EditB1Azn,\r\n                EDITB1BUSDM = @EditB1BUsd,\r\n                EDIT4USD = @Edit4Usd,\r\n                EDIT4AZN = @Edit4Azn,\r\n                EDIT4BUSDM = @Edit4BUsd,\r\n                EDIT5USD = @Edit5Usd,\r\n                EDIT5AZN = @Edit5Azn,\r\n                EDIT5BUSDM = @Edit5BUsd,\r\n                EDITALLUSD = @EditAllUsd,\r\n                EDITALLAZN = @EditAllAzn,\r\n                EDITALLBUSD = @EditAllBUsd,\r\n                EDITEXPENSEUSD = @EditExpenseUsd,\r\n                EDITEXPENSEAZN = @EditExpenseAzn,\r\n                EDITCURREMUSD = @EditCurRemUsd,\r\n                EDITCURREMAZN = @EditCurRemAzn,\r\n                STATUS = @Status,\r\n                EDITSUIT = @EditSuit,\r\n                EDITJACKET = @EditJacket,\r\n                EDITPANTS = @EditPants,\r\n                EDITSHIRT = @EditShirt,\r\n                EDITWAISTCOAT = @EditWaistcoat,\r\n                EDITOVERCOAT = @EditOvercoat,\r\n                EDITRAINCOAT = @EditRaincoat\r\n            WHERE DAILYCASHID = @DailyCashId", (object) dailyCashMI);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
    return 0;
  }
}
