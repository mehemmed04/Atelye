// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Concretes.ModelPhotoRepository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using Dapper;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Concretes;

public class ModelPhotoRepository(string connectionString) : BaseSqlRepository(connectionString), IModelPhotoRepository
{
  public async Task<ModelPhoto> GetModelPhotoById(string modelId)
  {
    SqlConnection conn = await this.OpenSqlConnectionAsync();
    ModelPhoto photo = await conn.QueryFirstOrDefaultAsync<ModelPhoto>("SELECT MODELID, PHOTOL, PHOTOB\r\n                FROM dbo.LAZSMODELPHOTO  WHERE MODELID = @id", (object) new
    {
      id = modelId
    });
    await conn.CloseAsync();
    ModelPhoto modelPhotoById = photo;
    conn = (SqlConnection) null;
    photo = (ModelPhoto) null;
    return modelPhotoById;
  }
}
