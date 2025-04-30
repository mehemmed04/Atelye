// Decompiled with JetBrains decompiler
// Type: EmilandAtelye.Domain.ViewModels.StockViewModel
// Assembly: EmilandAtelye, Version=1.0.1.19, Culture=neutral, PublicKeyToken=null
// MVID: EC4E6CC0-886D-4498-B6A7-B3AEAEA842AB
// Assembly location: C:\Users\DELL\Desktop\EmilandAtelyeNew-1.0.1.19\EmilandAtelye.dll

using EmilandAtelye.Commands;
using EmilandAtelye.DataAccess.Abstracts;
using EmilandAtelye.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace EmilandAtelye.Domain.ViewModels;

public class StockViewModel : BaseViewModel
{
  private ObservableCollection<string> _groupgen2s;
  private string? _selectedGroupGen2;
  private ObservableCollection<string> _companies;
  private string? _selectedCompany;
  private string barCode;
  private ObservableCollection<GoodsStore> _stock;
  private int _goodsCount;
  private double _goodsQuantity;
  private double _total1;
  private double _total2;
  private double _total3;
  private double _total4;
  private double _total5;
  private double? miqdarBoyukdur;
  private double? boyukdur1;
  private double? miqdarKichikdir;
  private double? kichikdir1;
  private double? boyukdur2;
  private double? kichikdir2;
  private double? boyukdur3;
  private double? kichikdir3;
  private double? boyukdur4;
  private double? kichikdir4;
  private double? boyukdur5;
  private double? kichikdir5;

  private IUnitOfWork _unitOfWork { get; set; }

  public IEnumerable<GoodsStore> StockWithoutColor { get; set; }

  public ObservableCollection<string> GroupGen2s
  {
    get => this._groupgen2s;
    set
    {
      this._groupgen2s = value;
      this.OnPropertyChanged(nameof (GroupGen2s));
    }
  }

  public string? SelectedGroupGen2
  {
    get => this._selectedGroupGen2;
    set
    {
      this._selectedGroupGen2 = value;
      this.OnPropertyChanged(nameof (SelectedGroupGen2));
      this.SearchStock();
    }
  }

  public ObservableCollection<string> Companies
  {
    get => this._companies;
    set
    {
      this._companies = value;
      this.OnPropertyChanged(nameof (Companies));
    }
  }

  public string? SelectedCompany
  {
    get => this._selectedCompany;
    set
    {
      this._selectedCompany = value;
      this.OnPropertyChanged(nameof (SelectedCompany));
      this.SearchStock();
    }
  }

  public string BarCode
  {
    get => this.barCode;
    set
    {
      this.barCode = value;
      this.OnPropertyChanged(nameof (BarCode));
      this.SearchStock();
    }
  }

  public ObservableCollection<GoodsStore> Stock
  {
    get => this._stock;
    set
    {
      this._stock = value;
      this.OnPropertyChanged(nameof (Stock));
    }
  }

  public int GoodsCount
  {
    get => this._goodsCount;
    set
    {
      this._goodsCount = value;
      this.OnPropertyChanged(nameof (GoodsCount));
    }
  }

  public double GoodsQuantity
  {
    get => this._goodsQuantity;
    set
    {
      this._goodsQuantity = value;
      this.OnPropertyChanged(nameof (GoodsQuantity));
    }
  }

  public double Total1
  {
    get => this._total1;
    set
    {
      this._total1 = value;
      this.OnPropertyChanged(nameof (Total1));
    }
  }

  public double Total2
  {
    get => this._total2;
    set
    {
      this._total2 = value;
      this.OnPropertyChanged(nameof (Total2));
    }
  }

  public double Total3
  {
    get => this._total3;
    set
    {
      this._total3 = value;
      this.OnPropertyChanged(nameof (Total3));
    }
  }

  public double Total4
  {
    get => this._total4;
    set
    {
      this._total4 = value;
      this.OnPropertyChanged(nameof (Total4));
    }
  }

  public double Total5
  {
    get => this._total5;
    set
    {
      this._total5 = value;
      this.OnPropertyChanged(nameof (Total5));
    }
  }

  public double? MiqdarBoyukdur
  {
    get => this.miqdarBoyukdur;
    set
    {
      this.miqdarBoyukdur = value;
      this.OnPropertyChanged(nameof (MiqdarBoyukdur));
      this.SearchStock();
    }
  }

  public double? Boyukdur1
  {
    get => this.boyukdur1;
    set
    {
      this.boyukdur1 = value;
      this.OnPropertyChanged(nameof (Boyukdur1));
      this.SearchStock();
    }
  }

  public double? MiqdarKichikdir
  {
    get => this.miqdarKichikdir;
    set
    {
      this.miqdarKichikdir = value;
      this.OnPropertyChanged(nameof (MiqdarKichikdir));
      this.SearchStock();
    }
  }

  public double? Kichikdir1
  {
    get => this.kichikdir1;
    set
    {
      this.kichikdir1 = value;
      this.OnPropertyChanged(nameof (Kichikdir1));
      this.SearchStock();
    }
  }

  public double? Boyukdur2
  {
    get => this.boyukdur2;
    set
    {
      this.boyukdur2 = value;
      this.OnPropertyChanged(nameof (Boyukdur2));
      this.SearchStock();
    }
  }

  public double? Kichikdir2
  {
    get => this.kichikdir2;
    set
    {
      this.kichikdir2 = value;
      this.OnPropertyChanged(nameof (Kichikdir2));
      this.SearchStock();
    }
  }

  public double? Boyukdur3
  {
    get => this.boyukdur3;
    set
    {
      this.boyukdur3 = value;
      this.OnPropertyChanged(nameof (Boyukdur3));
      this.SearchStock();
    }
  }

  public double? Kichikdir3
  {
    get => this.kichikdir3;
    set
    {
      this.kichikdir3 = value;
      this.OnPropertyChanged(nameof (Kichikdir3));
      this.SearchStock();
    }
  }

  public double? Boyukdur4
  {
    get => this.boyukdur4;
    set
    {
      this.boyukdur4 = value;
      this.OnPropertyChanged(nameof (Boyukdur4));
      this.SearchStock();
    }
  }

  public double? Kichikdir4
  {
    get => this.kichikdir4;
    set
    {
      this.kichikdir4 = value;
      this.OnPropertyChanged(nameof (Kichikdir4));
      this.SearchStock();
    }
  }

  public double? Boyukdur5
  {
    get => this.boyukdur5;
    set
    {
      this.boyukdur5 = value;
      this.OnPropertyChanged(nameof (Boyukdur5));
      this.SearchStock();
    }
  }

  public double? Kichikdir5
  {
    get => this.kichikdir5;
    set
    {
      this.kichikdir5 = value;
      this.OnPropertyChanged(nameof (Kichikdir5));
      this.SearchStock();
    }
  }

  public IEnumerable<GoodsStore> BaseStock { get; set; }

  public RelayCommand ResetCommand { get; set; }

  public RelayCommand GreenCommand { get; set; }

  public RelayCommand RedCommand { get; set; }

  public RelayCommand BlueCommand { get; set; }

  public RelayCommand BlackCommand { get; set; }

  public StockViewModel(IUnitOfWork unitOfWork)
  {
    this._unitOfWork = unitOfWork;
    this.LoadBaseStock();
    this.SearchStock();
    this.ResetCommand = new RelayCommand((Action<object>) (async param => await this.Reset(param)));
    this.GreenCommand = new RelayCommand((Action<object>) (async param => await this.SearchWithColor("Green")));
    this.RedCommand = new RelayCommand((Action<object>) (async param => await this.SearchWithColor("Red")));
    this.BlueCommand = new RelayCommand((Action<object>) (async param => await this.SearchWithColor("Blue")));
    this.BlackCommand = new RelayCommand((Action<object>) (async param => await this.SearchWithColor("Black")));
  }

  private async Task SearchWithColor(string color)
  {
    this.Stock = new ObservableCollection<GoodsStore>(this.StockWithoutColor.Where<GoodsStore>((Func<GoodsStore, bool>) (s => s.Color == color)));
    this.GoodsCount = this.Stock.Count<GoodsStore>();
    this.GoodsQuantity = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.RestManualCount.GetValueOrDefault()));
    this.Total1 = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store1.GetValueOrDefault()));
    this.Total2 = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store2.GetValueOrDefault()));
    this.Total3 = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store3.GetValueOrDefault()));
    this.Total4 = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store4.GetValueOrDefault()));
    this.Total5 = this.Stock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store5.GetValueOrDefault()));
  }

  private async Task LoadBaseStock()
  {
    this.BaseStock = await this._unitOfWork.StockRepository.GetStocks(this.SelectedCompany ?? "");
    foreach (GoodsStore goodsStore in this.BaseStock)
    {
      double? nullable = goodsStore.RestManualCount;
      double valueOrDefault1 = nullable.GetValueOrDefault();
      nullable = goodsStore.LimitRed;
      double valueOrDefault2 = nullable.GetValueOrDefault();
      if (valueOrDefault1 > valueOrDefault2)
        goodsStore.Color = "Blue";
      nullable = goodsStore.RestManualCount;
      double valueOrDefault3 = nullable.GetValueOrDefault();
      nullable = goodsStore.LimitRed;
      double valueOrDefault4 = nullable.GetValueOrDefault();
      if (valueOrDefault3 <= valueOrDefault4)
        goodsStore.Color = "Red";
      nullable = goodsStore.RestManualCount;
      double valueOrDefault5 = nullable.GetValueOrDefault();
      nullable = goodsStore.LimitBlue;
      double valueOrDefault6 = nullable.GetValueOrDefault();
      if (valueOrDefault5 > valueOrDefault6)
        goodsStore.Color = "Black";
    }
    this.BaseStock = (IEnumerable<GoodsStore>) this.BaseStock.OrderBy<GoodsStore, double?>((Func<GoodsStore, double?>) (s => s.RestManualCount));
    this.Stock = new ObservableCollection<GoodsStore>(this.BaseStock);
    this.GroupGen2s = new ObservableCollection<string>(this.Stock.DistinctBy<GoodsStore, string>((Func<GoodsStore, string>) (s => s.GroupGen2Name)).Select<GoodsStore, string>((Func<GoodsStore, string>) (s => s.GroupGen2Name)));
    this.Companies = new ObservableCollection<string>(this.Stock.DistinctBy<GoodsStore, string>((Func<GoodsStore, string>) (s => s.Initial)).Select<GoodsStore, string>((Func<GoodsStore, string>) (s => s.Initial)));
    this.GoodsCount = this.BaseStock.Count<GoodsStore>();
    this.GoodsQuantity = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.RestManualCount.GetValueOrDefault()));
    this.Total1 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store1.GetValueOrDefault()));
    this.Total2 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store2.GetValueOrDefault()));
    this.Total3 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store3.GetValueOrDefault()));
    this.Total4 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store4.GetValueOrDefault()));
    this.Total5 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store5.GetValueOrDefault()));
    this.StockWithoutColor = (IEnumerable<GoodsStore>) this.Stock;
  }

  public async Task SearchStock()
  {
    IEnumerable<GoodsStore> goodsStores = this.BaseStock;
    if (goodsStores == null)
      return;
    if (!this.SelectedGroupGen2.IsNullOrEmpty<char>())
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s => s.GroupGen2Name == this.SelectedGroupGen2));
    if (!this.SelectedCompany.IsNullOrEmpty<char>())
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s => s.Initial == this.SelectedCompany));
    string barcode = this.BarCode?.ToLower() ?? "";
    if (!this.BarCode.IsNullOrEmpty<char>())
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s => s.BarCode.ToLower().Contains(barcode)));
    if (this.MiqdarBoyukdur.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault1 = s.RestManualCount.GetValueOrDefault();
        double? miqdarBoyukdur = this.MiqdarBoyukdur;
        double valueOrDefault2 = miqdarBoyukdur.GetValueOrDefault();
        return valueOrDefault1 <= valueOrDefault2 & miqdarBoyukdur.HasValue;
      }));
    if (this.MiqdarKichikdir.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault3 = s.RestManualCount.GetValueOrDefault();
        double? miqdarKichikdir = this.MiqdarKichikdir;
        double valueOrDefault4 = miqdarKichikdir.GetValueOrDefault();
        return valueOrDefault3 >= valueOrDefault4 & miqdarKichikdir.HasValue;
      }));
    if (this.Boyukdur1.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault5 = s.Store1.GetValueOrDefault();
        double? boyukdur1 = this.Boyukdur1;
        double valueOrDefault6 = boyukdur1.GetValueOrDefault();
        return valueOrDefault5 <= valueOrDefault6 & boyukdur1.HasValue;
      }));
    if (this.Kichikdir1.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault7 = s.Store1.GetValueOrDefault();
        double? kichikdir1 = this.Kichikdir1;
        double valueOrDefault8 = kichikdir1.GetValueOrDefault();
        return valueOrDefault7 >= valueOrDefault8 & kichikdir1.HasValue;
      }));
    if (this.Boyukdur2.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault9 = s.Store2.GetValueOrDefault();
        double? boyukdur2 = this.Boyukdur2;
        double valueOrDefault10 = boyukdur2.GetValueOrDefault();
        return valueOrDefault9 <= valueOrDefault10 & boyukdur2.HasValue;
      }));
    if (this.Kichikdir2.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault11 = s.Store2.GetValueOrDefault();
        double? kichikdir2 = this.Kichikdir2;
        double valueOrDefault12 = kichikdir2.GetValueOrDefault();
        return valueOrDefault11 >= valueOrDefault12 & kichikdir2.HasValue;
      }));
    if (this.Boyukdur3.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault13 = s.Store3.GetValueOrDefault();
        double? boyukdur3 = this.Boyukdur3;
        double valueOrDefault14 = boyukdur3.GetValueOrDefault();
        return valueOrDefault13 <= valueOrDefault14 & boyukdur3.HasValue;
      }));
    if (this.Kichikdir3.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault15 = s.Store3.GetValueOrDefault();
        double? kichikdir3 = this.Kichikdir3;
        double valueOrDefault16 = kichikdir3.GetValueOrDefault();
        return valueOrDefault15 >= valueOrDefault16 & kichikdir3.HasValue;
      }));
    if (this.Boyukdur4.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault17 = s.Store4.GetValueOrDefault();
        double? boyukdur4 = this.Boyukdur4;
        double valueOrDefault18 = boyukdur4.GetValueOrDefault();
        return valueOrDefault17 <= valueOrDefault18 & boyukdur4.HasValue;
      }));
    if (this.Kichikdir4.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault19 = s.Store4.GetValueOrDefault();
        double? kichikdir4 = this.Kichikdir4;
        double valueOrDefault20 = kichikdir4.GetValueOrDefault();
        return valueOrDefault19 >= valueOrDefault20 & kichikdir4.HasValue;
      }));
    if (this.Boyukdur5.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault21 = s.Store5.GetValueOrDefault();
        double? boyukdur5 = this.Boyukdur5;
        double valueOrDefault22 = boyukdur5.GetValueOrDefault();
        return valueOrDefault21 <= valueOrDefault22 & boyukdur5.HasValue;
      }));
    if (this.Kichikdir5.HasValue)
      goodsStores = goodsStores.Where<GoodsStore>((Func<GoodsStore, bool>) (s =>
      {
        double valueOrDefault23 = s.Store5.GetValueOrDefault();
        double? kichikdir5 = this.Kichikdir5;
        double valueOrDefault24 = kichikdir5.GetValueOrDefault();
        return valueOrDefault23 >= valueOrDefault24 & kichikdir5.HasValue;
      }));
    this.GoodsCount = goodsStores.Count<GoodsStore>();
    this.GoodsQuantity = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.RestManualCount.GetValueOrDefault()));
    this.Total1 = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store1.GetValueOrDefault()));
    this.Total2 = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store2.GetValueOrDefault()));
    this.Total3 = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store3.GetValueOrDefault()));
    this.Total4 = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store4.GetValueOrDefault()));
    this.Total5 = goodsStores.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store5.GetValueOrDefault()));
    this.Stock = new ObservableCollection<GoodsStore>(goodsStores);
    this.StockWithoutColor = (IEnumerable<GoodsStore>) this.Stock;
  }

  public async Task Reset(object param)
  {
    this.SelectedCompany = (string) null;
    this.SelectedGroupGen2 = (string) null;
    this.BarCode = string.Empty;
    this.Total1 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store1.GetValueOrDefault()));
    this.Total2 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store2.GetValueOrDefault()));
    this.Total3 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store3.GetValueOrDefault()));
    this.Total4 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store4.GetValueOrDefault()));
    this.Total5 = this.BaseStock.Sum<GoodsStore>((Func<GoodsStore, double>) (s => s.Store5.GetValueOrDefault()));
    this.Stock = new ObservableCollection<GoodsStore>(this.BaseStock);
    this.StockWithoutColor = (IEnumerable<GoodsStore>) this.Stock;
  }
}
