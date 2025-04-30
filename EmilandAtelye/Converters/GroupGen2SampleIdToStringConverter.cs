// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Converters.GroupGen2SampleIdToStringConverter
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace EmilandAtelye.Converters;

public class GroupGen2SampleIdToStringConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (!(value is byte num))
      return (object) "";
    switch (num)
    {
      case 0:
        return (object) "BOŞ";
      case 1:
        return (object) "KOST";
      case 2:
        return (object) "PEN";
      case 3:
        return (object) "ŞAL";
      default:
        return (object) "BOŞ";
    }
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
