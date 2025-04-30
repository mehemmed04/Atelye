// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Services.Concrete.ExcelService
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Services.Abstract;
using Microsoft.CSharp.RuntimeBinder;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Services.Concrete;

public class ExcelService : IExcelService
{
  public async Task<bool> DownloadFile(object dataList, string tableName)
  {
    // ISSUE: reference to a compiler-generated field
    if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.Equal, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
      }));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    object obj1 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__0, dataList, (object) null);
    // ISSUE: reference to a compiler-generated field
    if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__5 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.IsTrue, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      }));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if (!ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__5.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__5, obj1))
    {
      // ISSUE: reference to a compiler-generated field
      if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.IsTrue, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, bool> target1 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__4.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, bool>> p4 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__4;
      // ISSUE: reference to a compiler-generated field
      if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, System.Linq.Expressions.ExpressionType.Or, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, object, object> target2 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__3.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, object, object>> p3 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__3;
      object obj2 = obj1;
      // ISSUE: reference to a compiler-generated field
      if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.Equal, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, int, object> target3 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__2.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, int, object>> p2 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__2;
      // ISSUE: reference to a compiler-generated field
      if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Count", typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__1, dataList);
      object obj4 = target3((CallSite) p2, obj3, 0);
      object obj5 = target2((CallSite) p3, obj2, obj4);
      if (!target1((CallSite) p4, obj5))
      {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        if (!Directory.Exists(folderPath))
          Directory.CreateDirectory(folderPath);
        string fileName = Path.Combine(folderPath, tableName + ".xlsx");
        using (ExcelPackage package = new ExcelPackage())
        {
          ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("Data");
          // ISSUE: reference to a compiler-generated field
          if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__6 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, IEnumerable<object>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (IEnumerable<object>), typeof (ExcelService)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj6 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__6.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__6, dataList).FirstOrDefault<object>();
          // ISSUE: reference to a compiler-generated field
          if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetProperties", (IEnumerable<Type>) null, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target4 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p8 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetType", (IEnumerable<Type>) null, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__7.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__7, obj6);
          object obj8 = target4((CallSite) p8, obj7);
          int num1 = 0;
          while (true)
          {
            // ISSUE: reference to a compiler-generated field
            if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__11 == null)
            {
              // ISSUE: reference to a compiler-generated field
              ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.IsTrue, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target5 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__11.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p11 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__11;
            // ISSUE: reference to a compiler-generated field
            if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__10 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.LessThan, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, int, object, object> target6 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, int, object, object>> p10 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__10;
            int num2 = num1;
            // ISSUE: reference to a compiler-generated field
            if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj9 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__9.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__9, obj8);
            object obj10 = target6((CallSite) p10, num2, obj9);
            if (target5((CallSite) p11, obj10))
            {
              ExcelRange cell = excelWorksheet.Cells[1, num1 + 1];
              // ISSUE: reference to a compiler-generated field
              if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__13 == null)
              {
                // ISSUE: reference to a compiler-generated field
                ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Name", typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, object> target7 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__13.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, object>> p13 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__13;
              // ISSUE: reference to a compiler-generated field
              if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__12 == null)
              {
                // ISSUE: reference to a compiler-generated field
                ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj11 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__12.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__12, obj8, num1);
              object obj12 = target7((CallSite) p13, obj11);
              cell.Value = obj12;
              ++num1;
            }
            else
              break;
          }
          int num3 = 0;
          // ISSUE: reference to a compiler-generated field
          if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (IEnumerable), typeof (ExcelService)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          foreach (object obj13 in ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__19.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__19, dataList))
          {
            int num4 = 0;
            while (true)
            {
              // ISSUE: reference to a compiler-generated field
              if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__16 == null)
              {
                // ISSUE: reference to a compiler-generated field
                ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.IsTrue, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, bool> target8 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__16.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, bool>> p16 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__16;
              // ISSUE: reference to a compiler-generated field
              if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__15 == null)
              {
                // ISSUE: reference to a compiler-generated field
                ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__15 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, System.Linq.Expressions.ExpressionType.LessThan, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, int, object, object> target9 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__15.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, int, object, object>> p15 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__15;
              int num5 = num4;
              // ISSUE: reference to a compiler-generated field
              if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__14 == null)
              {
                // ISSUE: reference to a compiler-generated field
                ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Length", typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj14 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__14.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__14, obj8);
              object obj15 = target9((CallSite) p15, num5, obj14);
              if (target8((CallSite) p16, obj15))
              {
                ExcelRange cell = excelWorksheet.Cells[num3 + 2, num4 + 1];
                // ISSUE: reference to a compiler-generated field
                if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__18 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetValue", (IEnumerable<Type>) null, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, object, object> target10 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__18.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, object, object>> p18 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__18;
                // ISSUE: reference to a compiler-generated field
                if (ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__17 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (ExcelService), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj16 = ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__17.Target((CallSite) ExcelService.\u003C\u003Eo__0.\u003C\u003Ep__17, obj8, num4);
                object obj17 = obj13;
                object obj18 = target10((CallSite) p18, obj16, obj17);
                cell.Value = obj18;
                ++num4;
              }
              else
                break;
            }
            ++num3;
          }
          await package.SaveAsAsync(new FileInfo(fileName));
          return true;
        }
      }
    }
    return false;
  }
}
