// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Converters.IngredientsToStringConverter
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace EmilandAtelye.Converters;

public class IngredientsToStringConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (!(value is int num))
      return (object) "";
    if (num == 1)
      return (object) "Bəli";
    return num == 2 ? (object) "Xeyr" : (object) "Xeyr";
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is string str)
    {
      switch (str)
      {
        case "Bəli":
          return (object) 1;
        case "Xeyr":
          return (object) 2;
      }
    }
    return (object) null;
  }
}
