using AprajitaRetails.Server.Data;
using System.Reflection.Metadata;

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

        public void StockUpdate(string purchaseFileName, string saleFileName)
        {
            var PurchasePath = Path.Combine(this.hostingEnv.WebRootPath, "Data/PurchaseInvoice.json");
            var SalePath = Path.Combine(this.hostingEnv.WebRootPath, "Data/SaleInvoices.json");

            var productList = aRDB.ProductItems.ToList();
            try
            {
                using StreamReader reader = new StreamReader(PurchasePath);
                var purchaseJson = reader.ReadToEnd();
                reader.Close();

                using StreamReader reader2 = new StreamReader(SalePath);
                var saleJson = reader2.ReadToEnd();
                reader2.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }


    }


    public class SInvoice
    {
        public string InvoiceNo{get;set;}//C33IN601784,
        public DateTime InvoiceDate { get;set;}//01-01-2017,
        public string InvoiceType { get;set;}//SALES,
        public string BrandName { get;set;}//FlyingMachine,
        public string ProductName { get;set;}//Apparel/MensCasual/Jeans,
        public string ItemDesc { get;set;}//MIDRISEMICHAEL,
        public string HSNCode { get;set;}//,
        public string BARCODE { get;set;}//8907378341709,
        public string StyleCode { get;set;}//FMJN781734,
        public decimal Quantity { get;set;}//1,
        public decimal MRP { get;set;}//2199,
        public decimal BasicAmt { get;set;}//1759.2,
        public decimal TaxAmt { get;set;}//,
        public decimal SGSTAmt { get;set;}//96.76,
        public decimal CGSTAmt { get;set;}//,
   
    }
    public class PInvoice
    {
        public string GRNNo { get; set; }

        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string StyleCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal MRPValue { get; set; }
        public decimal Cost { get; set; }
        public decimal CostValue { get; set; }
        public decimal TaxAmt { get; set; }
    }

}
