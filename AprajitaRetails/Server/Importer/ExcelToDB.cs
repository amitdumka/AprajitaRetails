using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Constants;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.ViewModels.Imports;
using Microsoft.EntityFrameworkCore;
using Syncfusion.ExcelExport;
using Syncfusion.XlsIO;
using Syncfusion.XlsIO.Implementation.Collections.Grouping;
using System.Data;
using System.IO;
using TypeSupport.Extensions;
using Path = System.IO.Path;

namespace AprajitaRetails.Server.Importer
{
    public class AModel
    {
        //SN	StyleCode	HSNCode	Qty	Rate	Unit	Per	Amount	CGST	SGST	CGSTAmount	SGSTAmount	TotalAmount

        public int SN { get; set; }
        public string StyleCode { get; set; }
        public string HSNCode { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Per { get; set; }
        public decimal Amount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class InearWearToDB : ExcelToDB
    {
        public InearWearToDB(ARDBContext db) : base(db)
        {

        }

        public bool RemapIWear(string basePath)
        {
            string bSheet = "InnearWear Sheet", rSheet = "InnerWear";
            string bRange = "A1:AA131", rRange = "A1:M123";
            string jsonFileNameS = "", jsonFileNameR = "";
            string basedirectory = "", fileName = Path.Combine(basePath, "Excel", "TheArvindStorePurchaseData.xlsx");

            basedirectory = Path.Combine(basePath, "TAS", "ARD", "json", "InnearWears");
            var x = Directory.CreateDirectory(basedirectory);
            Console.WriteLine(x.FullName);

            jsonFileNameS = Path.Combine(basedirectory, "wsheet", bSheet + ".json");
            jsonFileNameR = Path.Combine(basedirectory, "wsheet", rSheet + ".json");
            x = Directory.CreateDirectory(Path.GetDirectoryName(jsonFileNameS));
            Console.WriteLine(x.FullName);
            x = Directory.CreateDirectory(Path.Combine(basedirectory, AKSConstant.ImportedObjects));


            //Convert WorkSheet to JSon
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    IWorkbook workbook = application.Workbooks.Open(fileStream);

                    IWorksheet worksheetR = workbook.Worksheets[rSheet];
                    IWorksheet worksheetS = workbook.Worksheets[bSheet];

                    //Custom range
                    IRange rangeS = worksheetS.Range[bRange];
                    IRange rangeR = worksheetR.Range[rRange];



                    //Save the Range to a JSON file stream as schema by default
                    using (FileStream stream = new FileStream(jsonFileNameR, FileMode.Create, FileAccess.ReadWrite))
                    {
                        workbook.SaveAsJson(stream, rangeR);



                    }
                    //Save the Range to a JSON file stream without schema
                    using (FileStream stream2 = new FileStream(jsonFileNameS, FileMode.Create, FileAccess.ReadWrite))
                    {
                        workbook.SaveAsJson(stream2, rangeS, false);
                    }
                    //Read Json File For Processing Further
                    var rowDataR = ImportDataHelper.JsonToObject<AModel>(jsonFileNameR);
                    var rowDataS = ImportDataHelper.JsonToObject<PurchaseInvoiceItem>(jsonFileNameS);
                    List<PurchaseInvoiceItem> FinalData = new List<PurchaseInvoiceItem>();
                    foreach (var item in rowDataR)
                    {
                        var sData = rowDataS.FirstOrDefault(c => c.StyleCode == item.StyleCode);
                        if (sData != null)
                        {
                            item.SN = -2;
                            sData.HSNCODE = item.HSNCode;
                            if (sData.UnitMRP < item.Rate) sData.UnitMRP = item.Rate;
                            sData.IGST_CGSTAmount = item.CGSTAmount;
                            sData.SGSTAmount = item.SGSTAmount;
                            sData.IGST_CGSTRate = item.CGST;
                            sData.SGSTRate = item.SGST;
                            sData.Amount = item.TotalAmount;
                            sData.CostValue = item.Amount;
                            sData.MRPValue = item.Rate * item.Qty;
                            sData.Quantity = item.Qty;
                            sData.DiscoutP = item.Per;
                            sData.UnitCost = Math.Round(item.Amount / item.Qty, 2);
                            FinalData.Add(sData);
                        }
                        else
                        {
                            item.SN = -1;
                        }
                    }

                    //convert list to datadtabel 


                    //Export data from DataTable to Excel worksheet.
                    var wsr = workbook.Worksheets.Create("");
                    var wss = workbook.Worksheets.Create("");
                    var wsf = workbook.Worksheets.Create("");
                    
                    wsr.ImportDataTable(DocIO.ToDataTable<AModel>(rowDataR), true, 1, 1);
                    wsr.UsedRange.AutofitColumns();

                    wss.ImportDataTable(DocIO.ToDataTable<PurchaseInvoiceItem>(rowDataS), true, 1, 1);
                    wss.UsedRange.AutofitColumns();

                    wsf.ImportDataTable(DocIO.ToDataTable<PurchaseInvoiceItem>(FinalData), true, 1, 1);
                    wsf.UsedRange.AutofitColumns();

                    workbook.SaveAs(fileStream);
                    return true;

                }
            }



        }


    }
    public class ExcelToDBTrail
    {
        private ARDBContext _db;
        private string _importedDataPath;

        public ExcelToDBTrail(ARDBContext db, string sc, string sg)
        {
            _db = db;
            //_storeCode = sc; _storeGroup = sg;
            // UpdateCat();
            // sizeList = Enum.GetNames(typeof(Size2)).ToList();
        }
        public ReturnData UpdatePurchasesDataToDB(string basePath, string section)
        {
            _importedDataPath = basePath;
            if (basePath.Contains(AKSConstant.ImportedObjects) == false)
                basePath = Path.Combine(basePath, AKSConstant.ImportedObjects);
            ReturnData returnData = new ReturnData();
            switch (section)
            {
                case "ProductItems":
                    var flag = UpdateProductItem(Path.Combine(basePath, AKSConstant.ProductItems));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#ProdutItem=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#ProductItem={flag.ErrorMessage}";
                    }

                    break;
                case "Stocks":
                    flag = UpdateStockItem(Path.Combine(basePath, AKSConstant.Stocks));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#Stocks=[{flag.Success},Skipped=0, Added={(flag.Added + flag.Skipped)}, Saved={flag.SavedToDB} ]";
                        returnData.Success = flag.Success;
                        returnData.Message += "##Do manual check and verify that added properly, Run Stock Verification";
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#Stocks={flag.ErrorMessage}";
                    }
                    break;
                case "PurchaseInvoice":
                    flag = UpdatePurchaseInv(Path.Combine(basePath, AKSConstant.ProductPurchase));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#ProductPurchases=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                        flag = UpdatePurchaseItem(Path.Combine(basePath, AKSConstant.PurchaseItems));
                        if (!flag.Error)
                        {
                            returnData.Message += $"#PurchaseItems=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";

                        }
                        else
                        {
                            returnData.Error = true;
                            returnData.ErrorMessage += $"#PurchaseItems={flag.ErrorMessage}";
                        }
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#ProductPurchases={flag.ErrorMessage}";
                    }



                    break;
                default:
                    returnData.Error = true;
                    returnData.ErrorMessage = "Wrong choice.";
                    break;
            }

            return returnData;

        }
        private ReturnData UpdateProductItem(string filename)
        {
            try
            {
                int skiped = 0, added = 0, saved = 0;
                var productItems = ImportDataHelper.JsonToObject<ProductItem>(filename);
                if (productItems == null) return new ReturnData { Error = true, ErrorMessage = "Product Items is null" }; ;
                productItems = productItems.DistinctBy(c => c.Barcode).ToList();
                var missingitem = _db.ProductItems.Where(c => c.StyleCode.Contains("Missing")).ToList();
                var barcodelist = _db.ProductItems.Where(c => c.StyleCode.Contains("Missing") == false).Select(c => c.Barcode).ToList();
                foreach (var pi in missingitem)
                {
                    var item = productItems.Where(c => c.Barcode == pi.Barcode).FirstOrDefault();
                    if (item != null)
                    {

                        pi.Unit = item.Unit;
                        pi.BrandCode = item.BrandCode;
                        pi.Description = item.Description;
                        pi.StyleCode = item.StyleCode;
                        if (string.IsNullOrEmpty(pi.HSNCode))
                            pi.HSNCode = item.HSNCode;
                        pi.TaxType = item.TaxType;
                        pi.SubCategory = item.SubCategory;
                        pi.Size = item.Size;
                        pi.ProductTypeId = item.ProductTypeId;
                        pi.ProductCategory = item.ProductCategory;
                        pi.Name = item.Name;
                        if (pi.MRP < item.MRP)
                            pi.MRP = item.MRP;
                        _db.ProductItems.Update(pi);
                        productItems.Remove(item);
                        added++;
                    }
                }

                saved = _db.SaveChanges();




                foreach (var item in productItems)
                {
                    //if (_db.ProductItems.Any(c => c.Barcode == item.Barcode && c.StyleCode.Contains("Missing") == true))
                    //{
                    //    var pi = _db.ProductItems.Find(item.Barcode);
                    //    pi.Unit = item.Unit;
                    //    pi.BrandCode = item.BrandCode;
                    //    pi.Description = item.Description;
                    //    pi.StyleCode = item.StyleCode;
                    //    if (string.IsNullOrEmpty(pi.HSNCode))
                    //        pi.HSNCode = item.HSNCode;
                    //    pi.TaxType = item.TaxType;
                    //    pi.SubCategory = item.SubCategory;
                    //    pi.Size = item.Size;
                    //    pi.ProductTypeId = item.ProductTypeId;
                    //    pi.ProductCategory = item.ProductCategory;
                    //    pi.Name = item.Name;
                    //    if (pi.MRP < item.MRP)
                    //        pi.MRP = item.MRP;
                    //    _db.ProductItems.Update(pi);
                    //    added++;

                    //}

                    //else 
                    if (barcodelist.Any(c => c == item.Barcode))
                    {
                        skiped++;
                    }
                    else
                    {
                        added++;
                        _db.ProductItems.Add(item);
                    }
                }
                saved += _db.SaveChanges();

                return new ReturnData { Success = true, Added = added, Skipped = skiped, SavedToDB = saved };
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message }; ;
            }
        }

        private ReturnData UpdatePurchaseInv(string filename)
        {
            try
            {
                int skiped = 0, added = 0;

                var purchaseInvoices = ImportDataHelper.JsonToObject<ProductPurchase>(filename);
                if (purchaseInvoices != null) return new ReturnData { Error = true, ErrorMessage = "Purchase Invoice is null" };
                foreach (var item in purchaseInvoices)
                {
                    if (_db.ProductPurchases.Any(c => c.InwardNumber == item.InwardNumber))
                    {
                        skiped++;
                    }
                    else
                    {
                        added++;
                        _db.ProductPurchases.Add(item);
                    }
                }

                return new ReturnData { Success = true, Added = added, Skipped = skiped, SavedToDB = 0 };
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message }; ;
            }
        }

        private ReturnData UpdatePurchaseItem(string filename)
        {
            ReturnData returnData = new ReturnData();
            try
            {
                var purchaseItems = ImportDataHelper.JsonToObject<PurchaseItem>(filename);
                if (purchaseItems == null)
                {
                    returnData.Error = true; returnData.ErrorMessage = "Json return null data for Purchase Item";
                    return returnData;
                }
                foreach (var item in purchaseItems)
                {
                    if (_db.PurchaseItems.Any(c => c.InwardNumber == item.InwardNumber && c.Barcode == item.Barcode && c.Qty == item.Qty))
                    {
                        returnData.Skipped++;
                    }
                    else
                    {
                        returnData.Added++;
                        _db.PurchaseItems.Add(item);
                    }
                }
                returnData.SavedToDB = 0;
                returnData.Success = true;

                return returnData;
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message };
            }
        }

        private ReturnData UpdateStockItem(string filename)
        {
            ReturnData returnData = new ReturnData();
            try
            {
                var stocks = ImportDataHelper.JsonToObject<Stock>(filename);
                if (stocks == null)
                {
                    returnData.Error = true; returnData.ErrorMessage = "Json return null data for stocks";
                    return returnData;
                }

                // clubing all stock
                var x = stocks.GroupBy(c => new { c.StoreId, c.Barcode })
                    .Select(c => new Stock
                    {
                        StoreId = c.Key.StoreId,
                        Barcode = c.Key.Barcode,
                        CostPrice = c.Select(x => x.CostPrice).Average(),
                        EntryStatus = EntryStatus.Added,
                        HoldQty = 0,
                        IsReadOnly = true,
                        MarkedDeleted = false,
                        MRP = c.Select(x => x.MRP).Max(),
                        MultiPrice = false,
                        PurchaseQty = c.Select(x => x.PurchaseQty).Sum(),
                        Id = Guid.NewGuid(),
                        SoldQty = 0,
                        UserId = "AutoAdmin",
                        Unit = c.Select(x => x.Unit).First(),
                    })
                    .ToList();

                foreach (var item in stocks)
                {
                    if (_db.Stocks.Any(c => c.StoreId == item.StoreId && c.Barcode == item.Barcode))
                    {
                        returnData.Skipped++;
                        var stock = _db.Stocks.Where(c => c.StoreId == item.StoreId && c.Barcode == item.Barcode).First();
                        stock.PurchaseQty += item.PurchaseQty;
                        if (stock.MRP < item.MRP) stock.MRP = item.MRP;
                        if (stock.CostPrice != item.CostPrice)
                        {
                            stock.CostPrice = ((stock.CostPrice * stock.PurchaseQty) + (item.CostPrice * item.PurchaseQty) / (stock.PurchaseQty + item.PurchaseQty));
                        }
                        stock.EntryStatus = EntryStatus.Updated;
                        _db.Stocks.Update(stock);
                    }
                    else
                    {
                        returnData.Added++;
                        _db.Stocks.Add(item);
                    }
                }
                returnData.SavedToDB = 0;

                returnData.Success = true;

                return returnData;
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message };
            }
        }


        public ReturnData StockReVerifyFromPurchaseItem(string storecode)
        {
            //First Stage Qty Rectification.
            ReturnData returnData = new ReturnData();
            var pi = _db.PurchaseItems.Include(c => c.PurchaseProduct).Where(c => c.PurchaseProduct.StoreId == storecode).GroupBy(c => new { c.PurchaseProduct.StoreId, c.Barcode })
                    .Select(c => new
                    {
                        Barcode = c.Key.Barcode,
                        CostPrice = c.Select(x => x.CostPrice).Average(),
                        CostValue = c.Select(x => x.CostValue).Sum(),
                        TaxValue = c.Select(x => x.TaxAmount).Sum(),
                        PurchaseQty = c.Select(x => x.Qty).Sum(),
                        Id = Guid.NewGuid(),
                    })
                    .ToList();

            var stocks = _db.Stocks.Where(c => c.StoreId == storecode).ToList();
            returnData.Message = $"PurchaseItem Count:{pi.Count} and Stocks count: {stocks.Count}";

            foreach (var stock in stocks)
            {
                if (pi.Any(c => c.Barcode == stock.Barcode && c.PurchaseQty != stock.PurchaseQty))
                {
                    var i = pi.Where(c => c.Barcode == stock.Barcode).First();
                    stock.PurchaseQty = i.PurchaseQty;

                    //Calculation of CostPrice. 
                    var val = (i.CostValue + i.TaxValue) / i.PurchaseQty;
                    if (val != i.CostPrice)
                    {
                        if (val > i.CostValue)
                        {
                            stock.CostPrice = val;
                        }
                        else
                            stock.CostPrice = i.CostPrice;
                    }
                    else
                    {
                        stock.CostPrice = val;

                    }
                    stock.EntryStatus = EntryStatus.Updated;
                    _db.Stocks.Update(stock);
                    returnData.Added++;
                }
                else
                {
                    returnData.Skipped++;
                }
            }
            returnData.SavedToDB = 0;
            returnData.Success = true;
            return returnData;
        }


    }
    public class ExcelToDB : ExcelToJson
    {
        private ARDBContext _db;
        private string _importedDataPath;

        public ExcelToDB(ARDBContext db, string sc, string sg)
        {
            _db = db;
            _storeCode = sc; _storeGroup = sg;
            UpdateCat();
            sizeList = Enum.GetNames(typeof(Size)).ToList();
        }
        public ExcelToDB(ARDBContext db)
        {
            _db = db;
            _storeCode = "ÁRD"; _storeGroup = "TAS";
           // UpdateCat();
           // sizeList = Enum.GetNames(typeof(Size)).ToList();
        }


        public bool StockTransferFromOneToAnother(string source, string dest)
        {
            var sourceStock = _db.Stocks.Where(c => c.StoreId == source).ToList();
            var destStock = _db.Stocks.Where(c => c.StoreId == dest).ToList();

            foreach (var sStock in sourceStock)
            {
                if (destStock.Any(c => c.Barcode == sStock.Barcode))
                {
                    var dStock = destStock.Where(c => c.Barcode == sStock.Barcode).First();
                    dStock.HoldQty = sStock.PurchaseQty;
                    _db.Stocks.Update(dStock);
                }
                else
                {
                    Stock nS = new Stock
                    {
                        HoldQty = sStock.PurchaseQty,
                        SoldQty = 0,
                        MRP = sStock.MRP,
                        MarkedDeleted = false,
                        IsReadOnly = false,
                        MultiPrice = sStock.MultiPrice,
                        EntryStatus = EntryStatus.Added,
                        Barcode = sStock.Barcode,
                        CostPrice = sStock.CostPrice,
                        PurchaseQty = 0,
                        StoreId = dest,
                        Id = Guid.NewGuid(),
                        UserId = "AutoAdmin",
                        Unit = sStock.Unit
                    };
                    _db.Stocks.Add(nS);
                }
            }
            return _db.SaveChanges() > 0;

        }

        public ReturnData VerifyPurchaseInvoiceDataFromDB(string basePath, string section)
        {
            //TODO: Need to implement Stock and purchase Data from db and json file.
            ReturnData returnData = new ReturnData();
            return returnData;
        }


        public ReturnData UpdatePurchasesDataToDB(string basePath, string section)
        {
            _importedDataPath = basePath;
            if (basePath.Contains(AKSConstant.ImportedObjects) == false)
                basePath = Path.Combine(basePath, AKSConstant.ImportedObjects);
            //basePath = Path.Combine(basePath, AKSConstant.ImportedObjects);
            ReturnData returnData = new ReturnData();
            switch (section)
            {
                case "ProductItems":
                    var flag = UpdateProductItem(Path.Combine(basePath, AKSConstant.ProductItems));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#ProdutItem=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#ProductItem={flag.ErrorMessage}";
                    }

                    break;
                case "Stocks":
                    flag = UpdateStockItem(Path.Combine(basePath, AKSConstant.Stocks));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#Stocks=[{flag.Success},Skipped=0, Added={(flag.Added + flag.Skipped)}, Saved={flag.SavedToDB} ]";
                        returnData.Success = flag.Success;
                        returnData.Message += "##Do manual check and verify that added properly, Run Stock Verification";
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#Stocks={flag.ErrorMessage}";
                    }
                    break;
                case "PurchaseInvoice":
                    //var x=SeedBasicVendor(_db);
                    //if (!x)
                    //{

                    //}
                    flag = UpdatePurchaseInv(Path.Combine(basePath, AKSConstant.ProductPurchase));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#ProductPurchases=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                        flag = UpdatePurchaseItem(Path.Combine(basePath, AKSConstant.PurchaseItems));
                        if (!flag.Error)
                        {
                            returnData.Message += $"#PurchaseItems=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";

                        }
                        else
                        {
                            returnData.Error = true;
                            returnData.ErrorMessage += $"#PurchaseItems={flag.ErrorMessage}";
                        }
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#ProductPurchases={flag.ErrorMessage}";
                    }



                    break;
                default:
                    returnData.Error = true;
                    returnData.ErrorMessage = "Wrong choice.";
                    break;
            }

            return returnData;

        }


        public ReturnData UpdatePurchaseInvoiceToDB(string basePath, string section)
        {
            _importedDataPath = basePath;
            basePath = Path.Combine(basePath, AKSConstant.ImportedObjects);

            ReturnData returnData = new ReturnData();
            //First Update ProductItem to DB
            var flag = UpdateProductItem(Path.Combine(basePath, AKSConstant.ProductItems));
            if (!flag.Error)
            {
                returnData.Message += $"#ProdutItem=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                // Insert PurchaseInvoice then PurchaseItems
                flag = UpdatePurchaseInv(Path.Combine(basePath, AKSConstant.ProductPurchase));
                if (!flag.Error)
                {
                    returnData.Message += $"#ProductPurchases=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                    flag = UpdatePurchaseItem(Path.Combine(basePath, AKSConstant.PurchaseItems));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#PurchaseItems=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                        flag = UpdateStockItem(Path.Combine(basePath, AKSConstant.Stocks));
                        if (!flag.Error)
                        {
                            returnData.Message += $"#Stocks=[{flag.Success},Skipped=0, Added={(flag.Added + flag.Skipped)}, Saved={flag.SavedToDB} ]";
                            returnData.Success = flag.Success;
                            returnData.Message += "##Do manual check and verify that added properly";
                        }
                        else
                        {
                            returnData.Error = true;
                            returnData.ErrorMessage += $"#Stocks={flag.ErrorMessage}";
                        }
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#PurchaseItems={flag.ErrorMessage}";
                    }
                }
                else
                {
                    returnData.Error = true;
                    returnData.ErrorMessage += $"#ProductPurchases={flag.ErrorMessage}";
                }
            }
            else
            {
                returnData.Error = true;
                returnData.ErrorMessage += $"#ProductItem={flag.ErrorMessage}";
            }

            return returnData;
        }
        public ReturnData UpdatePurchaseInvoiceToDB(string basePath)
        {
            _importedDataPath = basePath;
            basePath = Path.Combine(basePath, AKSConstant.ImportedObjects);

            ReturnData returnData = new ReturnData();
            //First Update ProductItem to DB
            var flag = UpdateProductItem(Path.Combine(basePath, AKSConstant.ProductItems));
            if (!flag.Error)
            {
                returnData.Message += $"#ProdutItem=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                // Insert PurchaseInvoice then PurchaseItems
                flag = UpdatePurchaseInv(Path.Combine(basePath, AKSConstant.ProductPurchase));
                if (!flag.Error)
                {
                    returnData.Message += $"#ProductPurchases=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                    flag = UpdatePurchaseItem(Path.Combine(basePath, AKSConstant.PurchaseItems));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#PurchaseItems=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                        flag = UpdateStockItem(Path.Combine(basePath, AKSConstant.Stocks));
                        if (!flag.Error)
                        {
                            returnData.Message += $"#Stocks=[{flag.Success},Skipped=0, Added={(flag.Added + flag.Skipped)}, Saved={flag.SavedToDB} ]";
                            returnData.Success = flag.Success;
                            returnData.Message += "##Do manual check and verify that added properly";
                        }
                        else
                        {
                            returnData.Error = true;
                            returnData.ErrorMessage += $"#Stocks={flag.ErrorMessage}";
                        }
                    }
                    else
                    {
                        returnData.Error = true;
                        returnData.ErrorMessage += $"#PurchaseItems={flag.ErrorMessage}";
                    }
                }
                else
                {
                    returnData.Error = true;
                    returnData.ErrorMessage += $"#ProductPurchases={flag.ErrorMessage}";
                }
            }
            else
            {
                returnData.Error = true;
                returnData.ErrorMessage += $"#ProductItem={flag.ErrorMessage}";
            }

            return returnData;
        }

        private static bool SeedBasicVendor(ARDBContext db)
        {
            //TODO: Need to change storeid to StoreGroup
            List<Vendor> vendors = new List<Vendor>();

            Vendor v1 = new()
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0001",
                VendorType = VendorType.EBO,
                VendorName = "Arvind Limited"
            };
            Vendor v2 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0002",
                VendorType = VendorType.EBO,
                VendorName = "Arvind Brands Limited"
            };
            Vendor v3 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0003",
                VendorType = VendorType.EBO,
                VendorName = "Arvind Lifestyle Brands Limited"
            };
            Vendor v4 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0004",
                VendorType = VendorType.NonSalable,
                VendorName = "Safari Industries India Ltd"
            };
            Vendor v5 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0005",
                VendorType = VendorType.NonSalable,
                VendorName = "Khush"
            };
            Vendor v6 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0006",
                VendorType = VendorType.Distributor,
                VendorName = "Satish Mandal, Dhandbad"
            };
            Vendor v7 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0007",
                VendorType = VendorType.InHouse,
                VendorName = "Aprajita Retails, Jamshedpur"
            };
            Vendor v8 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0008",
                VendorType = VendorType.InHouse,
                VendorName = "Aprajita Retails, Dumka",
            };
            Vendor v9 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0009",
                VendorType = VendorType.BrandAuth,
                VendorName = "The Arvind Store - Jamshedpur COCO"
            };
            Vendor v10 = new Vendor
            {
                Active = true,
                EntryStatus = EntryStatus.Added,
                IsReadOnly = true,
                MarkedDeleted = false,
                OnDate = new DateTime(2015, 11, 1),
                StoreId = "ARD",
                UserId = "AUTO",
                VendorId = "ARD/VIN/0010",
                VendorType = VendorType.TempVendor,
                VendorName = "UnVerifired Vendor"
            };

            vendors.Add(v1);
            vendors.Add(v2);
            //vendors.Add(v3);
            vendors.Add(v4);
            vendors.Add(v5);
            //vendors.Add(v6);
            //vendors.Add(v7);
            //vendors.Add(v8); 
            // vendors.Add(v9); 
            // vendors.Add(v10);
            db.Vendors.AddRange(vendors);

            //foreach (var item in vendors)
            //{
            //    if (db.Vendors.Any(c => c.VendorName == item.VendorName) == false)
            //    {
            //        db.Vendors.Add(item);
            //    }
            //}


            //  db.Vendors.AddRange(vendors);
            db.SaveChanges();

            return (db.Vendors.Count() >= 10);
        }

        private async void UpdateCat()
        {
            //TODO: implementing StoreGroup conpect here
            var subcats = await _db.ProductSubCategories.ToListAsync();
            var ptypes = await _db.ProductTypes.ToListAsync();
            this.UpdateSubCategory(subcats);
            this.UpdateProductType(ptypes);
        }


        private ReturnData UpdateProductItem(string filename)
        {
            try
            {
                int skiped = 0, added = 0;
                var productItems = ImportDataHelper.JsonToObject<ProductItem>(filename);
                if (productItems == null) return new ReturnData { Error = true, ErrorMessage = "Product Items is null" }; ;
                productItems = productItems.DistinctBy(c => c.Barcode).ToList();

                foreach (var item in productItems)
                {
                    if (_db.ProductItems.Any(c => c.Barcode == item.Barcode && c.StyleCode.Contains("Missing") == true))
                    {
                        var pi = _db.ProductItems.Find(item.Barcode);
                        pi.Unit = item.Unit;
                        pi.BrandCode = item.BrandCode;
                        pi.Description = item.Description;
                        pi.StyleCode = item.StyleCode;
                        if (string.IsNullOrEmpty(item.HSNCode))
                            pi.HSNCode = item.HSNCode;
                        pi.TaxType = item.TaxType;
                        pi.SubCategory = item.SubCategory;
                        pi.Size = item.Size;
                        pi.ProductTypeId = item.ProductTypeId;
                        pi.ProductCategory = item.ProductCategory;
                        pi.Name = item.Name;
                        if (pi.MRP < item.MRP)
                            pi.MRP = item.MRP;
                        _db.ProductItems.Update(pi);
                        added++;

                    }

                    else if (_db.ProductItems.Any(c => c.Barcode == item.Barcode))
                    {
                        skiped++;
                    }
                    else
                    {
                        added++;
                        _db.ProductItems.Add(item);
                    }
                }
                var result = _db.SaveChanges();
                if (result != added)
                    return new ReturnData { Success = false, Added = added, Skipped = skiped, SavedToDB = result };
                else
                    return new ReturnData { Success = true, Added = added, Skipped = skiped, SavedToDB = result };
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message }; ;
            }
        }

        private ReturnData UpdatePurchaseInv(string filename)
        {
            try
            {
                int skiped = 0, added = 0;

                var purchaseInvoices = ImportDataHelper.JsonToObject<ProductPurchase>(filename);
                if (purchaseInvoices == null) return new ReturnData { Error = true, ErrorMessage = "Purchase Invoice is null" };
                foreach (var item in purchaseInvoices)
                {
                    if (_db.ProductPurchases.Any(c => c.InwardNumber == item.InwardNumber))
                    {
                        skiped++;
                    }
                    else
                    {
                        added++;
                        _db.ProductPurchases.Add(item);
                    }
                }
                var result = _db.SaveChanges();
                if (result != added)
                    return new ReturnData { Success = false, Added = added, Skipped = skiped, SavedToDB = result };
                else
                    return new ReturnData { Success = true, Added = added, Skipped = skiped, SavedToDB = result };
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message }; ;
            }
        }

        private ReturnData UpdatePurchaseItem(string filename)
        {
            ReturnData returnData = new ReturnData();
            try
            {
                var purchaseItems = ImportDataHelper.JsonToObject<PurchaseItem>(filename);
                if (purchaseItems == null)
                {
                    returnData.Error = true; returnData.ErrorMessage = "Json return null data for Purchase Item";
                    return returnData;
                }
                foreach (var item in purchaseItems)
                {
                    if (_db.PurchaseItems.Any(c => c.InwardNumber == item.InwardNumber && c.Barcode == item.Barcode && c.Qty == item.Qty))
                    {
                        returnData.Skipped++;
                    }
                    else
                    {
                        returnData.Added++;
                        _db.PurchaseItems.Add(item);
                    }
                }
                returnData.SavedToDB = _db.SaveChanges();

                if (returnData.SavedToDB == returnData.Added)
                {
                    returnData.Success = true;
                }
                else
                {
                    returnData.ErrorMessage = "Not saved all";
                }
                return returnData;
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message };
            }
        }

        private ReturnData UpdateStockItem(string filename)
        {
            ReturnData returnData = new ReturnData();
            try
            {
                var stocks = ImportDataHelper.JsonToObject<Stock>(filename);
                if (stocks == null)
                {
                    returnData.Error = true; returnData.ErrorMessage = "Json return null data for stocks";
                    return returnData;
                }

                // clubing all stock
                var x = stocks.GroupBy(c => new { c.StoreId, c.Barcode })
                    .Select(c => new Stock
                    {
                        StoreId = c.Key.StoreId,
                        Barcode = c.Key.Barcode,
                        CostPrice = c.Select(x => x.CostPrice).Average(),
                        EntryStatus = EntryStatus.Added,
                        HoldQty = 0,
                        IsReadOnly = true,
                        MarkedDeleted = false,
                        MRP = c.Select(x => x.MRP).Max(),
                        MultiPrice = false,
                        PurchaseQty = c.Select(x => x.PurchaseQty).Sum(),
                        Id = Guid.NewGuid(),
                        SoldQty = 0,
                        UserId = "AutoAdmin",
                        Unit = c.Select(x => x.Unit).First(),
                    })
                    .ToList();

                foreach (var item in stocks)
                {
                    if (_db.Stocks.Any(c => c.StoreId == item.StoreId && c.Barcode == item.Barcode))
                    {
                        returnData.Skipped++;
                        var stock = _db.Stocks.Where(c => c.StoreId == item.StoreId && c.Barcode == item.Barcode).First();
                        stock.PurchaseQty += item.PurchaseQty;
                        if (stock.MRP < item.MRP) stock.MRP = item.MRP;
                        if (stock.CostPrice != item.CostPrice)
                        {
                            stock.CostPrice = ((stock.CostPrice * stock.PurchaseQty) + (item.CostPrice * item.PurchaseQty) / (stock.PurchaseQty + item.PurchaseQty));
                        }
                        stock.EntryStatus = EntryStatus.Updated;
                        _db.Stocks.Update(stock);
                    }
                    else
                    {
                        returnData.Added++;
                        _db.Stocks.Add(item);
                    }
                }
                returnData.SavedToDB = _db.SaveChanges();
                if (returnData.SavedToDB == (returnData.Skipped + returnData.Added))
                {
                    returnData.Success = true;
                }
                else
                {
                    returnData.Success = false;
                    returnData.ErrorMessage = "Saved to db doesnt match with total record";
                }
                return returnData;
            }
            catch (Exception e)
            {
                return new ReturnData { Error = true, ErrorMessage = e.Message };
            }
        }


        public ReturnData StockReVerifyFromPurchaseItem(string storecode)
        {
            //First Stage Qty Rectification.
            ReturnData returnData = new ReturnData();
            var pi = _db.PurchaseItems.Include(c => c.PurchaseProduct).Where(c => c.PurchaseProduct.StoreId == storecode).GroupBy(c => new { c.PurchaseProduct.StoreId, c.Barcode })
                    .Select(c => new
                    {
                        Barcode = c.Key.Barcode,
                        CostPrice = c.Select(x => x.CostPrice).Average(),
                        CostValue = c.Select(x => x.CostValue).Sum(),
                        TaxValue = c.Select(x => x.TaxAmount).Sum(),
                        PurchaseQty = c.Select(x => x.Qty).Sum(),
                        Id = Guid.NewGuid(),
                    })
                    .ToList();

            var stocks = _db.Stocks.Where(c => c.StoreId == storecode).ToList();
            returnData.Message = $"PurchaseItem Count:{pi.Count} and Stocks count: {stocks.Count}";

            foreach (var stock in stocks)
            {
                if (pi.Any(c => c.Barcode == stock.Barcode && c.PurchaseQty != stock.PurchaseQty))
                {
                    var i = pi.Where(c => c.Barcode == stock.Barcode).First();
                    stock.PurchaseQty = i.PurchaseQty;

                    //Calculation of CostPrice. 
                    var val = (i.CostValue + i.TaxValue) / i.PurchaseQty;
                    if (val != i.CostPrice)
                    {
                        if (val > i.CostValue)
                        {
                            stock.CostPrice = val;
                        }
                        else
                            stock.CostPrice = i.CostPrice;
                    }
                    else
                    {
                        stock.CostPrice = val;

                    }
                    stock.EntryStatus = EntryStatus.Updated;
                    _db.Stocks.Update(stock);
                    returnData.Added++;
                }
                else
                {
                    returnData.Skipped++;
                }
            }
            returnData.SavedToDB = _db.SaveChanges();
            returnData.Success = true;
            return returnData;
        }

        /// <summary>
        /// Remap to new size enum 
        /// </summary>
        /// <returns></returns>

        public bool RemapSizeToSize2()
        {
            //var data = _db.ProductItems.ToList();
            //int x = 0;
            //foreach (var item in data)
            //{
            //     x=(int) MapToSize2(item.Size);
            //    if (x < 0)
            //    {
            //        x=(int)Size2.NOTVALID;
            //        item.Size = (Size)x;
            //    }
            //    item.Size = (Size)x;
            //    _db.ProductItems.Update(item);
            //}
            return _db.SaveChanges() > 0;
        }


    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}


/*
 //Create an instance of ExcelEngine
using (ExcelEngine excelEngine = new ExcelEngine())
{
  //Instantiate the Excel application object
  IApplication application = excelEngine.Excel;

  //Set the default application version
  application.DefaultVersion = ExcelVersion.Xlsx;

  //Load the existing Excel workbook into IWorkbook
  Stream inputStream = await client.GetStreamAsync("sample-data/Sample.xlsx");
  IWorkbook workbook = application.Workbooks.Open(inputStream);

  //Get the first worksheet in the workbook into IWorksheet
  IWorksheet worksheet = workbook.Worksheets[0];

  //Assign some text in a cell
  worksheet.Range["A3"].Text = "Hello World";

  //Access a cell value from Excel
  var value = worksheet.Range["A1"].Value;

  //Save the document as a stream and retrun the stream.
  using (MemoryStream stream = new MemoryStream())
  {
    //Save the created Excel document to MemoryStream
    workbook.SaveAs(stream);

    //Download the excel file
    await JS.SaveAs("Output.xlsx", stream.ToArray());
  }
}
 
 
 */