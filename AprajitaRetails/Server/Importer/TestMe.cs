
using System.Data.Common;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Stores;

namespace AprajitaRetails.Importer;

public class StoreMover
{

    private ARDBContext db;
    public string StoreId = "MBO";
    public string StoreGroupId = "ARN";
    public StoreMover(ARDBContext aRDB)
    {
        db = aRDB;
    }
    public bool CreateStore(Guid guid)
    {
        StoreGroup group = new StoreGroup
        {
            AppClientId = guid,
            GroupName = "Aprajita Retail MBO",
            Remarks = "Convert to MBO",
            StoreGroupId = "ARN",

        };
        Store store = new Store
        {
            AppClientId = guid,
            BeginDate = new DateTime(2023, 4, 1),
            City = "Dumka",
            Country = "India",
            EndDate = null,
            AppClient = null,
            GSTIN = "20AJHPA7396P1ZV",
            IsActive = true,
            MarkedDeleted = false,
            PanNo = "AJPHA7396P",
            State = "Jharkhand",
            StoreCode = "MBO001",
            StoreEmailId = "aprajitaretails@gmail.com",
            StoreGroup = group,
            StoreGroupId = "ARN",
            StoreId = "MBO",
            StoreManager = "Alok Kumar",
            StoreManagerContactNo = "",
            StoreName = "Aprajita Retails",
            StorePhoneNumber = "06434224461",
            VatNo = "",
            ZipCode = "814101"

        };

        db.Stores.Add(store);
        int x = db.SaveChanges();
        return (x > 1);

    }

    
    public void MoveStock(List<OldStock> oldStocks)
    {
        List<ProductItem> productItems= new List<ProductItem>();
        List<Stock> stocks= new List<Stock>();

        foreach (var oStock in oldStocks)
        {
            var pi= db.ProductItems.Where(c=>c.Barcode==oStock.Barcode).FirstOrDefault(); 
            var stk= db.Stocks.Where(c=>c.Barcode==oStock.Barcode).FirstOrDefault(); 
            
            ProductItem productItem= pi;
            productItem.StoreGroupId=StoreGroupId;
            


        }


    }

}

public class OldStock{
    public string Barcode{get;set;}
    public string Name{get;set;}
    public decimal MRP{get;set;}
    public decimal Qty{get;set;}
}

