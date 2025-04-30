// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Constants.Permissions
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System.Collections.Generic;

#nullable enable
namespace EmilandAtelye.Constants;

public class Permissions
{
  public static Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>()
  {
    {
      ViewTag.AnbarQaligi,
      new List<string>()
      {
        "tunzale",
        "admin",
        "anbar",
        "MagazaMS"
      }
    },
    {
      ViewTag.SifarislerT,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "Magaza1",
        "Magaza2"
      }
    },
    {
      ViewTag.SifarislerN,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "n"
      }
    },
    {
      ViewTag.SifarislerF,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "f"
      }
    },
    {
      ViewTag.SifarislerMK,
      new List<string>() { "tunzale", "admin", "ruslan", "Asif" }
    },
    {
      ViewTag.SifarislerHC,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "hc"
      }
    },
    {
      ViewTag.Deyishiklikler,
      new List<string>() { "tunzale", "admin", "ruslan", "Asif" }
    },
    {
      ViewTag.Utuleme1,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "anbar",
        "kesim1",
        "pres1",
        "utu1",
        "utu2",
        "utu3",
        "Magaza1",
        "Magaza2",
        "MagazaMS",
        "n",
        "f",
        "hc"
      }
    },
    {
      ViewTag.Utuleme2,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "Asif",
        "anbar",
        "utu4",
        "Magaza1",
        "Magaza2",
        "MagazaMS",
        "n",
        "f",
        "hc"
      }
    },
    {
      ViewTag.UtulemeGunluk,
      new List<string>()
      {
        "tunzale",
        "admin",
        "ruslan",
        "anbar",
        "Magaza1",
        "Magaza2",
        "MagazaMS",
        "n",
        "f",
        "hc"
      }
    },
    {
      ViewTag.Borclar,
      new List<string>() { "tunzale", "admin", "ruslan", "Asif" }
    },
    {
      ViewTag.Tehvil,
      new List<string>() { "tunzale", "admin", "ruslan", "Asif" }
    },
    {
      ViewTag.Kassa,
      new List<string>() { "admin", "ruslan", "Asif", "tunzale" }
    },
    {
      ViewTag.Xerc,
      new List<string>() { "admin", "ruslan" }
    },
    {
      ViewTag.KassaMI,
      new List<string>() { "tunzale", "admin", "ruslan", "Asif" }
    },
    {
      ViewTag.XercMI,
      new List<string>() { "tunzale", "admin", "ruslan" }
    },
    {
      ViewTag.MalinPasportu,
      new List<string>()
      {
        "tunzale",
        "admin",
        "anbar",
        "MagazaMS"
      }
    },
    {
      ViewTag.Olculer,
      new List<string>() { "anbar", "tunzale" }
    }
  };

  public static bool HasReadPermission(string view, string username)
  {
    List<string> stringList;
    return Permissions.Data.TryGetValue(view, out stringList) && stringList.Contains(username);
  }
}
