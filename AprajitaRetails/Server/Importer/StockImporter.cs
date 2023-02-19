using AprajitaRetails.Server.Data;
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
                using StreamReader reader = new StreamReader(PurchasePath);
                var JSONFILE = reader.ReadToEnd();
                reader.Close();
                var purchaseList = JsonSerializer.Deserialize<List<PInvoice>>(JSONFILE);

                foreach (var item in purchaseList)
                {
                    if (NewStockList.Any(c => c.Barcode == item.Barcode && c.StoreId == StoreCode))
                    {
                        var stocks = NewStockList.Where(c => c.Barcode == item.Barcode && c.StoreId == StoreCode).ToList();
                        if (stocks.Count > 1)
                        {
                            var zstock = stocks.Where(c => c.CostPrice == item.Cost && c.MRP == item.MRP).FirstOrDefault();
                            if (zstock != null) zstock.PurchaseQty += item.Quantity;
                            else
                            {
                                var stock = new Stock { Barcode = item.Barcode, CostPrice = item.Cost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = false, MarkedDeleted = false, MRP = item.MRP, MultiPrice = true, PurchaseQty = item.Quantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                                NewStockList.Add(stock);
                            }
                        }
                        else
                        {
                            var fstock = stocks[0];
                            if (fstock.MRP == item.MRP && fstock.CostPrice == item.Cost)
                            {

                                fstock.PurchaseQty += item.Quantity;
                            }
                            else
                            {
                                fstock.MultiPrice = true;
                                var cstock = new Stock { Barcode = item.Barcode, CostPrice = item.Cost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = false, MarkedDeleted = false, MRP = item.MRP, MultiPrice = true, PurchaseQty = item.Quantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };

                                NewStockList.Add(cstock);

                            }

                        }
                    }
                    else
                    {

                        var stock = new Stock { Barcode = item.Barcode, CostPrice = item.Cost, EntryStatus = EntryStatus.Added, HoldQty = 0, IsReadOnly = false, MarkedDeleted = false, MRP = item.MRP, MultiPrice = false, PurchaseQty = item.Quantity, UserId = "Auto", StoreId = StoreCode, SoldQty = 0, Unit = Unit.Nos };
                        NewStockList.Add(stock);
                    }
                }


                JSONFILE = JsonSerializer.Serialize<List<Stock>>(NewStockList);

                using StreamReader reader2 = new StreamReader(SalePath);
                 JSONFILE = reader2.ReadToEnd();
                reader2.Close();
                using StreamWriter writer = new StreamWriter(Path.Combine(this.hostingEnv.WebRootPath, "Data/PurchaseStockJson.json"));
               await writer.WriteAsync(JSONFILE);
                writer.Close();
                var saleList = JsonSerializer.Deserialize<List<SInvoice>>(JSONFILE);
                List<SInvoice> BarCodeNotFound = new List<SInvoice>();

                foreach (var item in saleList)
                {
                    var stock = NewStockList.Where(c => c.Barcode == item.BARCODE && c.StoreId == StoreCode && c.MRP == item.MRP).FirstOrDefault();

                    if (stock != null) { stock.SoldQty += item.Quantity;
                        if (stock.CurrentQty > 0) stock.EntryStatus = EntryStatus.Rejected;
                    }
                    else
                    {
                        BarCodeNotFound.Add(item);
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
                return true; 

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
        //public string InvoiceNo { get; set; }//C33IN601784,
        //public string InvoiceDate { get; set; }//01-01-2017,
        //public string InvoiceType { get; set; }//SALES,
        //public string BrandName { get; set; }//FlyingMachine,
        //public string ProductName { get; set; }//Apparel/MensCasual/Jeans,
        //public string ItemDesc { get; set; }//MIDRISEMICHAEL,
        //public string HSNCode { get; set; }//,
        public string BARCODE { get; set; }//8907378341709,
        //public string StyleCode { get; set; }//FMJN781734,
        public string Quantity { get; set; }//1,
        public string MRP { get; set; }//2199,
        //public decimal BasicAmt { get; set; }//1759.2,
        //public decimal TaxAmt { get; set; }//,
        //public decimal SGSTAmt { get; set; }//96.76,
        //public decimal CGSTAmt { get; set; }//,

    }
    public class PInvoice
    {
       // public string GRNNo { get; set; }

       // public string InvoiceNo { get; set; }
       // public string InvoiceDate { get; set; }
        //public string SupplierName { get; set; }
        public string Barcode { get; set; }
        //public string ProductName { get; set; }
        //public string StyleCode { get; set; }
        //public string ItemDesc { get; set; }
        public string Quantity { get; set; }
        public string MRP { get; set; }
        //public decimal MRPValue { get; set; }
        public string Cost { get; set; }
        //public decimal CostValue { get; set; }
        //public decimal TaxAmt { get; set; }
    }

}
