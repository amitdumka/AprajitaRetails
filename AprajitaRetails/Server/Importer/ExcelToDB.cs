using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Telerik.Maui;
using Path = System.IO.Path;

namespace AprajitaRetails.Server.Importer
{
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

        public ReturnData UpdatePurchaseInvoiceToDB(string basePath)
        {
            _importedDataPath = basePath;
            basePath = Path.Combine(basePath, "ImportedObjects");

            ReturnData returnData = new ReturnData();
            //First Update ProductItem to DB
            var flag = UpdateProductItem(Path.Combine(basePath, "ProductItems.json"));
            if (!flag.Error)
            {
                returnData.Message += $"#ProdutItem=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                // Insert PurchaseInvoice then PurchaseItems
                flag = UpdatePurchaseInv(Path.Combine(basePath, "ProductPurchases.json"));
                if (!flag.Error)
                {
                    returnData.Message += $"#ProductPurchases=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                    flag = UpdatePurchaseItem(Path.Combine(basePath, "PurchaseItems.json"));
                    if (!flag.Error)
                    {
                        returnData.Message += $"#PurchaseItems=[{flag.Success},Skipped={flag.Skipped}, Added={flag.Added}, Saved={flag.SavedToDB} ]";
                        flag = UpdateStockItem(Path.Combine(basePath, "Stocks.json"));
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
            vendors.Add(v3);
            vendors.Add(v4);
            vendors.Add(v5);
            vendors.Add(v6);
            vendors.Add(v7);
            vendors.Add(v8); vendors.Add(v9); vendors.Add(v10);

            foreach (var item in vendors)
            {
                if (db.Vendors.Any(c => c.VendorName == item.VendorName) == false)
                {
                    db.Vendors.Add(item);
                }
            }


            //  db.Vendors.AddRange(vendors);
            db.SaveChanges();

            return (db.Vendors.Count() == 10);
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
                    if (_db.ProductItems.Any(c => c.Barcode == item.Barcode))
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
    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}