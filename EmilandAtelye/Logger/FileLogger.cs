// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Logger.FileLogger
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.IO;

#nullable enable
namespace EmilandAtelye.Logger;

public class FileLogger
{
  private readonly string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Configuration/Logs.txt");

  public void CheckLoggerExist()
  {
    try
    {
      if (!File.Exists(this.logFilePath))
        File.Create(this.logFilePath).Close();
      string[] strArray = File.ReadAllLines(this.logFilePath);
      bool flag = false;
      foreach (string str in strArray)
      {
        if (str.Equals(this.logFilePath, StringComparison.OrdinalIgnoreCase))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        File.AppendAllText(this.logFilePath, this.logFilePath + Environment.NewLine);
        Console.WriteLine("Added logger.txt path to the configuration file.");
      }
      else
        Console.WriteLine("logger.txt path already exists in the configuration file.");
    }
    catch (Exception ex)
    {
      Console.WriteLine("An error occurred while checking the logger existence: " + ex.Message);
    }
  }

  public void Information(string message)
  {
    this.CheckLoggerExist();
    this.LogToFile("INFO", message);
  }

  public void Warning(string message)
  {
    this.CheckLoggerExist();
    this.LogToFile("WARNING", message);
  }

  public void Error(string message)
  {
    this.CheckLoggerExist();
    this.LogToFile("ERROR", message);
  }

  private void LogToFile(string logLevel, string message)
  {
    try
    {
      File.AppendAllText(this.logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}" + Environment.NewLine);
      Console.WriteLine($"Logged {logLevel} message: {message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine("An error occurred while logging the message: " + ex.Message);
    }
  }
}
