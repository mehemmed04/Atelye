// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.DataAccess.Abstracts.IGroupGen2Repository
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.DataAccess.Abstracts;

public interface IGroupGen2Repository
{
  Task<IEnumerable<GroupGen2>> GetAllGroupGen2Async();

  Task<IEnumerable<GroupGen2ForOrder>> GetGroupGen2ForOrdersAsync();

  Task<IEnumerable<GroupGen2ByGen1>> GetGroupGen2ByGroupGen1Id(int groupGen1Id);

  Task<string> GetGroupGen2NameByIdAsync(int groupGen2Id);
}
