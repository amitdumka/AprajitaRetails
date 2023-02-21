﻿using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using System.Reflection.Metadata;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{
    public class StockImporter
    {
        private ARDBContext aRDB;
        private string StoreCode;
        private IWebHostEnvironment hostingEnv;
        public StockImporter(IWebHostEnvironment env, ARDBContext db, string storeCode = "ARD")
        {
            this.hostingEnv = env;
            aRDB = db;
            StoreCode = storeCode;
        }

        public async Task<bool> StockUpdate()//string purchaseFileName, string saleFileName)
        {
            var PurchasePath = Path.Combine(this.hostingEnv.WebRootPath, "Data/PurchaseInvoice.json");
            var SalePath = Path.Combine(this.hostingEnv.WebRootPath, "Data/SaleInvoices.json");


            var productList = aRDB.ProductItems.ToList();
            List<Stock> NewStockList = new List<Stock>();
            try
            {
                // Fetch Product from DB
                NewStockList = aRDB.ProductItems.Select(c => new Stock
                {
                    Barcode = c.Barcode,
                    CostPrice = 0,
                    EntryStatus = EntryStatus.Added,
                    HoldQty = 0,
                    IsReadOnly = false,
                    MarkedDeleted = false,
                    MRP = 0,
                    MultiPrice = false,
                    PurchaseQty = 0,
                    SoldQty = 0,
                    StoreId = StoreCode,
                    Unit = c.Unit,
                    UserId = "Auto",
                    Id = Guid.NewGuid()
                }).OrderBy(c => c.Barcode).ToList();

                using StreamReader reader = new StreamReader(PurchasePath);
                var JSONFILE = reader.ReadToEnd();
                reader.Close();
                var purchaseList = JsonSerializer.Deserialize<List<PInvoice>>(JSONFILE);

                foreach (var item in purchaseList)
                {
                    var ItemCost = Math.Round(decimal.Parse(item.Cost), 2);
                    var ItemMRP = decimal.Parse(item.MRP);
                    var ItemQuantity = decimal.Parse(item.Quantity);

                    if (NewStockList.Any(c => c.Barcode == item.Barcode && c.StoreId == StoreCode))
                    {
                        var stocks = NewStockList.Where(c => c.Barcode == item.Barcode && c.StoreId == StoreCode).ToList();

                        if (stocks.Count > 1)
                        {
                            var zstock = stocks.Where(c => c.MRP == ItemMRP).FirstOrDefault();

                            if (zstock != null)
                            {

                                if (zstock.CostPrice != ItemCost)
                                {
                                    if (((zstock.CostPrice - ItemCost) < 1)|| ItemQuantity==1 || ItemQuantity == 2 || ItemQuantity == 4 || ItemQuantity == 3)
                                    {
                                        var avrCp = (zstock.PurchaseQty * zstock.CostPrice) + (ItemQuantity * ItemCost);
                                        avrCp = avrCp / (ItemQuantity + zstock.PurchaseQty);
                                        zstock.CostPrice = Math.Round(avrCp,2);
                                        zstock.PurchaseQty += ItemQuantity;
                                    }
                                    
                                    else
                                    {
                                        var stock = new Stock { Barcode = item.Barcode, CostPrice = ItemCost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = true, MarkedDeleted = false, MRP = ItemMRP, MultiPrice = true, PurchaseQty = ItemQuantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                                        NewStockList.Add(stock);
                                    }
                                }
                                else
                                {

                                    zstock.PurchaseQty += ItemQuantity;
                                }
                            }
                            else
                            {
                                var stock = new Stock { Barcode = item.Barcode, CostPrice = ItemCost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = true, MarkedDeleted = false, MRP = ItemMRP, MultiPrice = true, PurchaseQty = ItemQuantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                                NewStockList.Add(stock);
                            }
                        }
                        else
                        {
                            var fstock = stocks[0];

                            if (fstock.MRP == 0 && fstock.CostPrice == 0 && fstock.PurchaseQty == 0)
                            {
                                fstock.PurchaseQty += ItemQuantity;
                                fstock.MRP = ItemMRP;
                                fstock.CostPrice = ItemCost;
                            }
                            else if(fstock.CostPrice != ItemCost && fstock.MRP==ItemMRP)
                            {
                                if (((fstock.CostPrice - ItemCost) < 1) || ItemQuantity == 1 || ItemQuantity == 2 || ItemQuantity == 4 || ItemQuantity == 3)
                                {
                                    var avrCp = (fstock.PurchaseQty * fstock.CostPrice) + (ItemQuantity * ItemCost);
                                    avrCp = avrCp / (ItemQuantity + fstock.PurchaseQty);
                                    fstock.CostPrice = Math.Round(avrCp, 2);
                                    fstock.PurchaseQty += ItemQuantity;
                                    fstock.MultiPrice = true;
                                }

                                else
                                {
                                    var stock = new Stock { Barcode = item.Barcode, CostPrice = ItemCost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = true, MarkedDeleted = false, MRP = ItemMRP, MultiPrice = true, PurchaseQty = ItemQuantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                                    NewStockList.Add(stock);
                                }
                            }
                            else if (fstock.MRP == ItemMRP && fstock.CostPrice == ItemCost)
                            {

                                fstock.PurchaseQty += ItemQuantity;
                            }
                            else
                            {
                                fstock.MultiPrice = true;
                                var cstock = new Stock { Barcode = item.Barcode, CostPrice = ItemCost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = true, MarkedDeleted = false, MRP = ItemMRP, MultiPrice = true, PurchaseQty = ItemQuantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };

                                NewStockList.Add(cstock);

                            }

                        }
                    }
                    else
                    {

                        var stock = new Stock { Barcode = item.Barcode, CostPrice = ItemCost, EntryStatus = EntryStatus.DeleteApproved, HoldQty = 0, IsReadOnly = false, MarkedDeleted = false, MRP = ItemMRP, MultiPrice = false, PurchaseQty = ItemQuantity, UserId = "AutoNEW", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                        NewStockList.Add(stock);
                    }
                }


                JSONFILE = JsonSerializer.Serialize<List<Stock>>(NewStockList);


                using StreamWriter writer = new StreamWriter(Path.Combine(this.hostingEnv.WebRootPath, "Data/PurchaseStockJson.json"));
                await writer.WriteAsync(JSONFILE);
                writer.Close();

                using StreamReader reader2 = new StreamReader(SalePath);
                JSONFILE = reader2.ReadToEnd();
                reader2.Close();
                var saleList = JsonSerializer.Deserialize<List<SInvoice>>(JSONFILE);
                List<SInvoice> BarCodeNotFound = new List<SInvoice>();

                foreach (var item in saleList)
                {
                    // var ItemCost = decimal.Parse(item.);
                    var ItemMRP = decimal.Parse(item.MRP);
                    var ItemQuantity = decimal.Parse(item.Quantity);

                    var stock = NewStockList.Where(c => c.Barcode == item.BARCODE && c.StoreId == StoreCode).FirstOrDefault();

                    if (stock != null)
                    {
                        stock.SoldQty += ItemQuantity;
                        if (stock.CurrentQty < 0) stock.EntryStatus = EntryStatus.Rejected;
                    }
                    else
                    {
                        if (item.BARCODE.StartsWith("SA"))
                        {

                        }
                        else
                        {
                            BarCodeNotFound.Add(item);
                        }

                    }

                }

                JSONFILE = JsonSerializer.Serialize<List<Stock>>(NewStockList);
                using StreamWriter writer2 = new StreamWriter(Path.Combine(this.hostingEnv.WebRootPath, "Data/SaleStockJson.json"));
                await writer2.WriteAsync(JSONFILE);
                writer2.Close();
                if (BarCodeNotFound.Count > 0)
                {
                    JSONFILE = JsonSerializer.Serialize<List<SInvoice>>(BarCodeNotFound);
                    using StreamWriter writer3 = new StreamWriter(Path.Combine(this.hostingEnv.WebRootPath, "Data/BarcodeNotFound.json"));
                    await writer3.WriteAsync(JSONFILE);
                    writer3.Close();
                }
                //var data = NewStockList.GroupBy(c => c.Barcode).Where(c => c.Count() > 1)
                //    .Select(c => new {Barcode= c.Key, MRP = c.Select(x => x.MRP), Cost = c.Select(x => x.CostPrice), Qty=c.Select(x=>x.PurchaseQty) }).ToList();
                var data = NewStockList.Where(c => c.EntryStatus == EntryStatus.DeleteApproved).ToList(); 
                JSONFILE = JsonSerializer.Serialize(data);
                using StreamWriter writer21 = new StreamWriter(Path.Combine(this.hostingEnv.WebRootPath, "Data/SummyStockJson.json"));
                await writer21.WriteAsync(JSONFILE);

                aRDB.Stocks.RemoveRange(aRDB.Stocks.ToList());
                aRDB.SaveChanges();

                aRDB.Stocks.AddRange(NewStockList) ;
                return aRDB.SaveChanges() > 0;
               // return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }


    }

    public class StockH
    {
        public string BARCODE { get; set; }
        public decimal Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal Cost { get; set; }
        public bool Sold { get; set; }
    }

    public class SInvoice
    {
        public string BARCODE { get; set; }//8907378341709,        
        public string Quantity { get; set; }//1,
        public string MRP { get; set; }//2199,
        public string InvoiceNo { get; set; }

    }
    public class PInvoice
    {
        public string Barcode { get; set; }
        public string Quantity { get; set; }
        public string MRP { get; set; }
        public string Cost { get; set; }
    }
    // public string GRNNo { get; set; }
    // public string InvoiceNo { get; set; }
    // public string InvoiceDate { get; set; }
    //public string SupplierName { get; set; }
    //public string ProductName { get; set; }
    //public string StyleCode { get; set; }
    //public string ItemDesc { get; set; }
    //public decimal MRPValue { get; set; }
    //public decimal CostValue { get; set; }
    //public decimal TaxAmt { get; set; }
    //public string StyleCode { get; set; }//FMJN781734,
    //public decimal BasicAmt { get; set; }//1759.2,
    //public decimal TaxAmt { get; set; }//,
    //public decimal SGSTAmt { get; set; }//96.76,
    //public decimal CGSTAmt { get; set; }//,
    //public string InvoiceNo { get; set; }//C33IN601784,
    //public string InvoiceDate { get; set; }//01-01-2017,
    //public string InvoiceType { get; set; }//SALES,
    //public string BrandName { get; set; }//FlyingMachine,
    //public string ProductName { get; set; }//Apparel/MensCasual/Jeans,
    //public string ItemDesc { get; set; }//MIDRISEMICHAEL,
    //public string HSNCode { get; set; }//,


}
