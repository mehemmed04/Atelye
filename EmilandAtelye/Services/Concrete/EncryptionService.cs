// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.EncryptionService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Services.Abstract;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class EncryptionService : IEncryptionService
{
  public string Encrypt(string plainText, string key, string iv)
  {
    using (Aes aes = Aes.Create())
    {
      aes.Key = Encoding.UTF8.GetBytes(key);
      aes.IV = Encoding.UTF8.GetBytes(iv);
      ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
        {
          using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
            streamWriter.Write(plainText);
        }
        return Convert.ToBase64String(memoryStream.ToArray());
      }
    }
  }

  public string Decrypt(string encryptedText, string key, string iv)
  {
    using (Aes aes = Aes.Create())
    {
      aes.Key = Encoding.UTF8.GetBytes(key);
      aes.IV = Encoding.UTF8.GetBytes(iv);
      ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
      using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
        {
          using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
            return streamReader.ReadToEnd();
        }
      }
    }
  }
}
