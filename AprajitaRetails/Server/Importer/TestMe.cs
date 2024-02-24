
using System.Data.Common;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Stores;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            StoreGroupId = "TAS",
            StoreId = "MBO",
            StoreManager = "Alok Kumar",
            StoreManagerContactNo = "",
            StoreName = "Aprajita Retails",
            StorePhoneNumber = "06434224461",
            VatNo = "",
            ZipCode = "814101"

        };
        db.StoreGroups.Add(group);
        db.Stores.Add(store);
        int x = db.SaveChanges();
        return (x > 1);

    }

    public string MoveEmployee()
    {
        Salesman salesman = new Salesman
        {
            EmployeeId = "SM",
            EntryStatus = EntryStatus.Added,
            IsActive = true,
            IsReadOnly = true,
            MarkedDeleted = false,
            Name = "Manager",
            SalesmanId = "MBO-2023-SM-1",
            StoreId = "MBO",
            UserId = "AutoADMIN"
        };
        db.Salesmen.Add(salesman);
        var emps = db.Employees.Where(c => c.IsWorking).ToList();
        foreach (var item in emps)
        {
            item.StoreId = "MBO";

        }
        db.Employees.UpdateRange(emps);
        int y = db.SaveChanges();
        return $"Moved   Emp and salesman {y}";
    }

    public string MoveStock(List<OldStock> oldStocks)
    {
        //List<ProductItem> productItems = new List<ProductItem>();
        // List<Stock> stocks = new List<Stock>();




        foreach (var oStock in oldStocks)
        {
            //var pi = db.ProductItems.Where(c => c.Barcode == oStock.Barcode).FirstOrDefault();
            var stk = db.Stocks.Where(c => c.Barcode == oStock.Barcode).FirstOrDefault();
            if (stk != null)
            {
                Stock nStock = stk;
                nStock.StoreId = StoreId;
                nStock.HoldQty = stk.PurchaseQty - stk.HoldQty - stk.SoldQty;
                nStock.PurchaseQty = oStock.Qty;
                nStock.Id = Guid.NewGuid();
                db.Stocks.Add(nStock);
            }



        }
        int x = db.SaveChanges();
        return $"Moved {x} items out of {oldStocks.Count}  ";

    }

    public string MoveVouchers()
    {
        var vouchers = db.Vouchers.Where(c => c.OnDate > new DateTime(2023, 3, 31)).ToList();
        foreach (var v in vouchers)
        {
            v.StoreId = StoreId;
        }

        var cashvouchers = db.CashVouchers.Where(c => c.OnDate > new DateTime(2023, 3, 31)).ToList();
        foreach (var v in cashvouchers)
        {
            v.StoreId = StoreId;
        }
        var salarypayments = db.SalaryPayments.Where(c => c.OnDate > new DateTime(2023, 3, 31)).ToList();
        foreach (var v in salarypayments)
        {
            v.StoreId = StoreId;
        }
        int x = db.SaveChanges();
        return $"Moved {x} vouchers, cash vouchers, salary payments";
    }

    public string MoveAttendance()
    {
        var attendances = db.Attendances.Where(c => c.OnDate > new DateTime(2023, 3, 31) && c.StoreId == "ARD").ToList();
        foreach (var v in attendances)
        {
            v.StoreId = StoreId;
        }
        int x = db.SaveChanges();
        return $"Moved {x} attendances";
    }
    public async Task<string> MoveAsync(string ops, string basepath)
    {
         if(ops=="stock"){
            var data=await ReadStockExcelAsync(basepath);
            return MoveMain(ops,data);
         }

        return MoveMain(ops, null);
    }

    public string MoveInvoice()
    {

        var productsales = db.ProductSales.Where(c => c.OnDate > new DateTime(2023, 3, 31)).ToList();
        foreach (var v in productsales)
        {
            v.StoreId = StoreId;
        }
        int x = db.SaveChanges();
        return $"Moved {x} invoices";

    }

    public async Task<List<OldStock>?> ReadStockExcelAsync(string basepath)
    {
        string pathname=Path.Combine(basepath,"data","excel"); 
         try
            {
                var data = ImportDataHelper.ReadExcel<OldStock>(pathname, "currentstock.xlsx", "Sheet1", "A1:Z1");
                if(data==null) return null;
                var json = await ImportDataHelper.ObjectToJsonFileAsync(data, "CurrentStock.json");

                return data;
                    
                 
            }
            catch (Exception ex)
            {
                //TODO: insert Loging and notificaton and exception handling
                //return (string)($"#ERROR#MSG#{ex.Message}");
                // throw;
                return null;
            }

    }

    public string MoveMain(string ops, List<OldStock>? stocks = null)
    {
        switch (ops)
        {
            case "stock":
                return MoveStock(stocks);
                break;
            case "vouchers":
                return MoveVouchers(); break;
            case "employee":
                return MoveEmployee();
            case "attendance":
                return MoveAttendance();
                break;
            case "invoice":
                return MoveInvoice();
            default:
                return "error";
                break;
        }

    }
}

public class OldStock
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public decimal MRP { get; set; }
    public decimal Qty { get; set; }
    public decimal Cost { get; set; }
    public decimal OldMRP { get; set; }
    public decimal OpeningStock{get;set;}
    public string Category{get;set;}
    public decimal StockOutOld { get{return (OpeningStock-Qty);}}
    public decimal NewMargin{get {return(MRP-Cost);}}
    public decimal Percentage{get {return((NewMargin*100)/Cost);}}

}

