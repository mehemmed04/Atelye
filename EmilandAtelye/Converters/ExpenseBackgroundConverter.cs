// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Converters.ExpenseBackgroundConverter
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Domain.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

#nullable enable
namespace EmilandAtelye.Converters;

public class ExpenseBackgroundConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    if (value is DailyExpense dailyExpense)
    {
      int? nullable = dailyExpense.OperSumDollar;
      int num1 = 0;
      if (!(nullable.GetValueOrDefault() < num1 & nullable.HasValue))
      {
        nullable = dailyExpense.OperSumAzn;
        int num2 = 0;
        if (!(nullable.GetValueOrDefault() < num2 & nullable.HasValue))
          goto label_4;
      }
      return (object) Brushes.Red;
    }
label_4:
    return (object) Brushes.Wheat;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
