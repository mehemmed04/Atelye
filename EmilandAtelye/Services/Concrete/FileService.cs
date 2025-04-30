// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.FileService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.DTOs;
using EmilandAtelye.Services.Abstract;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class FileService(IEncryptionService encryptionService) : IFileService
{
  public async Task SavePasskey(string username, string passkey)
  {
    string key = "1234567890123456";
    string iv = "1234567890123456";
    string str1 = encryptionService.Encrypt(passkey, key, iv);
    string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Configuration");
    if (!Directory.Exists(str2))
      Directory.CreateDirectory(str2);
    File.WriteAllText(Path.Combine(str2, "configuration.txt"), $"{username} {str1}");
  }

  public Task<PassKeyDto?> ReadPasskey()
  {
    string key = "1234567890123456";
    string iv = "1234567890123456";
    string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Configuration"), "configuration.txt");
    if (!File.Exists(path))
      return Task.FromResult<PassKeyDto>((PassKeyDto) null);
    string[] strArray = File.ReadAllText(path).Split(' ');
    if (strArray.Length != 2)
      return Task.FromResult<PassKeyDto>((PassKeyDto) null);
    string str1 = strArray[0];
    string str2 = encryptionService.Decrypt(strArray[1], key, iv);
    return Task.FromResult<PassKeyDto>(new PassKeyDto()
    {
      Username = str1,
      PassKey = str2
    });
  }

  public async Task<string> ReadFileFromUrlAsync(string url)
  {
    string str;
    using (HttpClient client = new HttpClient())
    {
      HttpResponseMessage async = await client.GetAsync(url);
      async.EnsureSuccessStatusCode();
      str = await async.Content.ReadAsStringAsync();
    }
    return str;
  }

  public async Task<string> ReadFromFile(string url) => await File.ReadAllTextAsync(url);
}
