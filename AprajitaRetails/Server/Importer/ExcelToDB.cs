using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Constants;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.ViewModels.Imports;
using Microsoft.EntityFrameworkCore;

using Path = System.IO.Path;

namespace AprajitaRetails.Server.Importer
{

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

                return new ReturnData { Success = true, Added = added, Skipped = skiped, SavedToDB = 0 };
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
            sizeList = Enum.GetNames(typeof(Size2)).ToList();
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