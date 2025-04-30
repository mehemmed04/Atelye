// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Abstract.IEncryptionService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

#nullable enable
namespace EmilandAtelye.Services.Abstract;

public interface IEncryptionService
{
  string Encrypt(string plainText, string key, string iv);

  string Decrypt(string encryptedText, string key, string iv);
}
