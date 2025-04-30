// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.CardsRepository
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

public class CardsRepository(string connectionString) : BaseSqlRepository(connectionString), ICardsRepository
{
  public async Task<IEnumerable<Card>> GetAllCards()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<Card> cards = await conn.QueryAsync<Card>("exec SP_Sch_Cards default,2,default,default");
    await conn.CloseAsync();
    IEnumerable<Card> allCards = cards;
    conn = (SqlConnection) null;
    cards = (IEnumerable<Card>) null;
    return allCards;
  }

  public async Task<IEnumerable<ACard>> GetACards()
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    IEnumerable<ACard> cards = await conn.QueryAsync<ACard>("SELECT OPERDATE, CUSNAME, BARCODE, LASTPRICETOTAL\r\n            FROM azsfinance\r\n            WHERE customerid = 1 AND STATUS = 0 AND (ST IS NULL OR ST <> 1)\r\n            ORDER BY OPERDATE DESC;");
    await conn.CloseAsync();
    IEnumerable<ACard> acards = cards;
    conn = (SqlConnection) null;
    cards = (IEnumerable<ACard>) null;
    return acards;
  }

  public async Task<double> GetPriceByBarcode(string barcode)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    double cards = await conn.QueryFirstOrDefaultAsync<double>("SELECT LASTPRICETOTAL FROM azsfinance\r\nWHERE customerid = 1 AND STATUS = 0 AND (ST IS NULL OR ST <> 1) AND BARCODE = @barCode", (object) new
    {
      barCode = barcode
    });
    await conn.CloseAsync();
    double priceByBarcode = cards;
    conn = (SqlConnection) null;
    return priceByBarcode;
  }

  public async Task UpdateCard(string barcode, double? payment)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    int num = await conn.ExecuteAsync("UPDATE AZSFINANCE SET LASTPRICETOTAL = LASTPRICETOTAL - @payMent\r\n                WHERE BARCODE = @barCode", (object) new
    {
      barCode = barcode,
      payMent = payment
    });
    await conn.CloseAsync();
    conn = (SqlConnection) null;
  }
}
