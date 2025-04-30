// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.VersionService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Logger;
using EmilandAtelye.Services.Abstract;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

internal class VersionService(IFileService fileService, FileLogger logger) : IVersionService
{
  private readonly string versionPath = "https://t7yke4ph39u8rqgx6dan.emiland.com/version.txt";
  private readonly string NewVersionPack = "https://t7yke4ph39u8rqgx6dan.emiland.com/EmilandAtelyeNew.zip";

  private async Task<string> GetLastVersionFromServer()
  {
    return await fileService.ReadFileFromUrlAsync(this.versionPath);
  }

  private async Task<string> GetLatestVersionFromLocal()
  {
    return await fileService.ReadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Configuration/version.txt");
  }

  public async Task<bool> HasUpdate()
  {
    string currentVersion = await this.GetLatestVersionFromLocal();
    bool flag = string.Compare(await this.GetLastVersionFromServer(), currentVersion, StringComparison.Ordinal) == 1;
    currentVersion = (string) null;
    return flag;
  }

  public async Task<bool> UpdateToNewVersion()
  {
    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string zipFilePath = Path.Combine(desktopPath, "EmilandAtelyeNew.zip");
    string extractFolderPath = Path.Combine(desktopPath, "EmilandAtelyeNew");
    logger.Information("Downloading ZIP file to Desktop...");
    try
    {
      using (HttpClient client = new HttpClient())
      {
        using (HttpResponseMessage response = await client.GetAsync(this.NewVersionPack, HttpCompletionOption.ResponseHeadersRead))
        {
          response.EnsureSuccessStatusCode();
          using (Stream stream = await response.Content.ReadAsStreamAsync())
          {
            using (FileStream fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192 /*0x2000*/, true))
              await stream.CopyToAsync((Stream) fileStream);
          }
        }
      }
      logger.Information("File downloaded successfully and saved to: " + zipFilePath);
      logger.Information($"Extracting ZIP file to folder: {extractFolderPath}...");
      if (!Directory.Exists(extractFolderPath))
        Directory.CreateDirectory(extractFolderPath);
      ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath);
      logger.Information("Extraction completed successfully!");
      logger.Information("Deleting the ZIP file...");
      File.Delete(zipFilePath);
      logger.Information("ZIP file deleted: " + zipFilePath);
      Process.Start(Path.Combine(desktopPath, "Configuration", "VersionUpdaterEXE", "UpdaterWPF.exe"));
      logger.Information("Shutting down the program...");
      Environment.Exit(0);
      return true;
    }
    catch (Exception ex)
    {
      logger.Error("An error occurred: " + ex.Message);
      Environment.Exit(1);
      return false;
    }
  }
}
