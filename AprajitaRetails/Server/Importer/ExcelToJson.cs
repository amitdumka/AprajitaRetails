using AprajitaRetails.Shared.Constants;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.ViewModels.Imports;
using Path = System.IO.Path;

namespace AprajitaRetails.Server.Importer
{
    public class ExcelToJson
    {
        //TODO: Move Static or supporting functions to one class so only main function should be here.
        protected string _storeCode, _storeGroup;

        protected List<ProductSubCategory> _subCategories;
        protected List<ProductType> _typeCategories;
        protected List<string> sizeList;

        /// <summary>
        /// Convert Excel sheet to json data for futher process
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="worksheet"></param>
        /// <param name="range"></param>
        /// <param name="jsonfilename"></param>
        /// <param name="savejson"></param>
        /// <returns></returns>
        public async Task<string> ConvertExcelToJson<T>(string path, string filename, string worksheet, string range, string jsonfilename, bool savejson)
        {
            try
            {
                var data = ImportDataHelper.ReadExcel<T>(path, filename, worksheet, range);
                if (savejson)
                {
                    var json = await ImportDataHelper.ObjectToJsonFileAsync(data, jsonfilename);
                    return json;
                }
                else
                {
                    var json = ImportDataHelper.ObjectToJson<T>(data);
                    return json;
                }
            }
            catch (Exception ex)
            {
                //TODO: insert Loging and notificaton and exception handling
                return (string)($"#ERROR#MSG#{ex.Message}");
                // throw;
            }
        }

        public async Task<string> ImportPurchaseInvoiceAsync(string path, string excelfilename, string worksheet, string range, string storecode, string storegroup, bool savejson)
        {
            string jsonFileName = "";
            string basedirectory = "";
            try
            {
                if (savejson)
                {
                    basedirectory = Path.Combine(path, storegroup, storecode, "json", worksheet);
                    var x = Directory.CreateDirectory(basedirectory);
                    Console.WriteLine(x.FullName);

                    jsonFileName = Path.Combine(basedirectory, "wsheet", AKSConstant.PurchaseInvoice);
                    x = Directory.CreateDirectory(Path.GetDirectoryName(jsonFileName));
                    Console.WriteLine(x.FullName);
                    x = Directory.CreateDirectory(Path.Combine(basedirectory, AKSConstant.ImportedObjects));
                }
                //var jsondata = await this.ConvertExcelToJson<PurchaseInvoiceItem>(path, excelfilename, worksheet, range, jsonFileName, savejson);

                // Convert to Purchase Invoice, item, and stock
                //var data = ImportDataHelper.JsonToObject<PurchaseInvoiceItem>(jsondata);
                var data = ImportDataHelper.ReadExcel<PurchaseInvoiceItem>(Path.Combine(path, "Excel"), excelfilename, worksheet, range);

                //Create ProductItem,
                var productitems = data.DistinctBy(c => c.Barcode).Select(c => new ProductItem
                {
                    Barcode = c.Barcode,
                    HSNCode = c.HSNCODE,
                    StoreGroupId = storegroup,
                    StyleCode = c.StyleCode,
                    TaxType = TaxType.GST,
                    Unit = StringToUnit(c.Unit),
                    Description = c.ProductDescription,
                    Name = c.ProductName,
                    MRP = c.UnitMRP,
                    Brand = null,
                    ProductCategory = ToProductCategory(c.ProductCategory),
                    BrandCode = ToBrandCode(c.StyleCode, c.ProductCategory),
                    ProductType = null,
                    StoreGroup = null,
                    Size = ToSize(c.Size),
                    ProductTypeId = GetProductType(c.ProductName),
                    SubCategory = GetSubCategoryId(c.ProductName),
                    ProductSubCategory = null
                }).ToList();
                // Create purchase Invoice

                var purchaseInvoice = data.GroupBy(c => c.InvoiceNumber).Select(c => new ProductPurchase
                {
                    EntryStatus = EntryStatus.Added,
                    InvoiceNo = c.Key,
                    FreeQty = 0,
                    InvoiceType = PurchaseInvoiceType.Purchase,
                    StoreId = MapStoreCode(c.Select(x => x.StoreCode).First()),
                    InwardDate = c.Select(x => x.InwardDate).First(),
                    InwardNumber = c.Select(x => x.InwardNumber).First(),
                    IsReadOnly = true,
                    MarkedDeleted = false,
                    OnDate = c.Select(x => x.InvoiceDate).First(),
                    Paid = true,
                    TaxType = TaxType.IGST,
                    UserId = "AutoAdmin",
                    Warehouse = c.Select(x => x.SupplierName).First(),
                    BillQty = c.Sum(x => x.Quantity),
                    Count = c.Count(x => x.Quantity > 0),
                    ShippingCost = 0,
                    DiscountAmount = 0,
                    TaxAmount = c.Sum(x => x.IGST_CGSTAmount),
                    TotalAmount = c.Sum(x => x.Amount),
                    TotalQty = c.Sum(x => x.Quantity),
                    Store = null,
                    Vendor = null,
                    Items = null,
                    VendorId = GetVendorId(c.Select(x => x.SupplierName).First()),
                    BasicAmount = c.Sum(x => x.CostValue),
                }).ToList();

                //Creating purchase Item
                var invs = data.Select(c => new PurchaseItem
                {
                    Barcode = c.Barcode,
                    Unit = StringToUnit(c.Unit),
                    CostPrice = c.UnitCost,
                    CostValue = c.CostValue,
                    DiscountValue = 0,
                    FreeQty = 0,
                    InwardNumber = c.InwardNumber,
                    Qty = c.Quantity,
                    TaxAmount = c.IGST_CGSTAmount,
                    ProductItem = null,
                    PurchaseProduct = null,
                    Id = 0,
                }).ToList();



                //Create Stock Item
                //filter stock at adding to db for duplicate stock item.
                var stocks = data.Select(c => new Stock
                {
                    StoreId = MapStoreCode(c.StoreCode),
                    Barcode = c.Barcode,
                    CostPrice = c.UnitCost,
                    HoldQty = 0,
                    EntryStatus = EntryStatus.Added,
                    IsReadOnly = true,
                    MarkedDeleted = false,
                    MRP = c.UnitMRP,
                    SoldQty = 0,
                    MultiPrice = false,
                    UserId = "AutoAdmin",
                    Unit = StringToUnit(c.Unit),
                    PurchaseQty = c.Quantity,
                    Store = null,
                    Product = null,
                    Id = Guid.NewGuid(),
                }).ToList();


                //Convert all Data and Save to json File
                await ImportDataHelper.ObjectToJsonFileAsync(data, jsonFileName);
                await ImportDataHelper.ObjectToJsonFileAsync(purchaseInvoice, Path.Combine(basedirectory, AKSConstant.ImportedObjects, AKSConstant.ProductPurchase));
                await ImportDataHelper.ObjectToJsonFileAsync(stocks, Path.Combine(basedirectory, AKSConstant.ImportedObjects, AKSConstant.Stocks));
                await ImportDataHelper.ObjectToJsonFileAsync(productitems, Path.Combine(basedirectory, AKSConstant.ImportedObjects, AKSConstant.ProductItems));
                await ImportDataHelper.ObjectToJsonFileAsync(invs, Path.Combine(basedirectory, AKSConstant.ImportedObjects, AKSConstant.PurchaseItems));

                return basedirectory;
            }
            catch (Exception ex)
            {
                return $"#Error#Msg#{ex.Message}";
            }
        }

        protected void UpdateProductType(List<ProductType> productType)
        {
            if (_typeCategories == null)
            {
                _typeCategories = productType;
            }
            else
            {
                _typeCategories.AddRange(productType);
                _typeCategories = _typeCategories.DistinctBy(c => c.ProductTypeName).ToList();
            }
        }

        protected void UpdateSubCategory(List<ProductSubCategory> category)
        {
            if (_subCategories == null)
            {
                _subCategories = category;
            }
            else
            {
                _subCategories.AddRange(category);
                _subCategories = _subCategories.DistinctBy(c => c.SubCategory).ToList();
            }
        }

        private static string MapStoreCode(string tascode)
        {
            if (tascode.Trim().EndsWith("14")) return "ARJ";
            else if (tascode.Trim().EndsWith("06")) return "ARD";
            else return "ARD";
        }

        /// <summary>
        /// set Unit for item
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Unit SetUnitFromProductName(string name)
        {
            if (name.StartsWith("Apparel")) { return Unit.Pcs; }
            else if (name.StartsWith("Promo") || name.StartsWith("Suit Cover")) { return Unit.Nos; }
            else if (name.StartsWith("Shirting") || name.StartsWith("Suiting")) { return Unit.Meters; }
            return Unit.NoUnit;
        }
        /// <summary>
        /// Map Vendor from Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        private static string VendorMapping(string supplier)
        {
            string id = supplier switch
            {
                "TAS RMG Warehouse - Bangalore" => "ARD/VIN/0003",
                "TAS - Warhouse -FOFO" => "ARD/VIN/0003",
                "Bangalore WH" => "ARD/VIN/0003",
                "Arvind Brands Limited" => "ARD/VIN/0002",
                "TAS RTS -Warhouse" => "ARD/VIN/0002",
                "Arvind Limited" => "ARD/VIN/0001",
                "Khush" => "ARD/VIN/0005",
                "Safari Industries India Ltd" => "ARD/VIN/0004",
                "DTR Packed WH" => "ARD/VIN/0002",
                "DTR - TAS Warehouse" => "ARD/VIN/0002",
                "Aprajita Retails - Jamshedpur" => "ARD/VIN/0007",
                "The Arvind Store - Jamshedpur CO" => "ARD/VIN/0009",
                "Aprajita Retails - Dumka" => "ARD/VIN/0008",
                "TAS - Dumka FOFO" => "ARD/VIN/0008",
                "Satish Mandal, Dhandbad" => "ARD/VIN/0006",
                _ => "ARD/VIN/0010",
            };
            return id;
        }

        private ProductCategory GetProductCategory(string cat) => ToProductCategory(cat);

        private string GetProductType(string product)
        {
            var pt = product.Split("/")[1].Trim();
            if (_typeCategories == null)
            {
                _typeCategories = new List<ProductType> { new ProductType { ProductTypeName = pt, ProductTypeId = "PT0001" } };
                return "PT0001";
            }
            else
            {
                var type = _typeCategories.FirstOrDefault(c => c.ProductTypeName == pt);
                if (type == null)
                {
                    var p = new ProductType { ProductTypeName = pt, ProductTypeId = $"PT00{(_typeCategories.Count + 1)}" };
                    _typeCategories.Add(p);
                    return p.ProductTypeId;
                }
                else
                {
                    return type.ProductTypeId;
                }
            }
        }

        private string GetSubCategoryId(string cat)
        {
            var pt = cat.Split("/");
            if (_typeCategories == null)
            {
                _subCategories = new List<ProductSubCategory> { new ProductSubCategory { SubCategory = pt[2].Trim(), ProductCategory = GetProductCategory(pt[0].Trim()) } };
                return "PT0001";
            }
            else
            {
                var type = _subCategories.FirstOrDefault(c => c.SubCategory == pt[2].Trim());

                if (type == null)
                {
                    var p = new ProductSubCategory { SubCategory = pt[2].Trim(), ProductCategory = GetProductCategory(pt[0].Trim()) };
                    _subCategories.Add(p);
                    return p.SubCategory;
                }
                else
                {
                    return type.SubCategory;
                }
            }
        }

        private string GetVendorId(string sup)
        {
            return VendorMapping(sup);
        }

        private Size ToSize(string sz)
        {
            Size size = Size.NOTVALID;
            int x = 0;
            if (Int32.TryParse(sz, out _))
            {
                x = sizeList.IndexOf($"C{sz}");

            }
            else
            {
                x = sizeList.IndexOf(sz);
            }
            return (Size)x;

        }

        protected Size MapToSize2(Size2 size)
        {
            switch (size)
            {
                case Size2.S:
                case Size2.M:

                case Size2.L:

                case Size2.XL:

                case Size2.XXL:

                case Size2.XXXL:
                    var jj = size.ToString();
                    return (Size)sizeList.IndexOf(jj);
                    break;
                case Size2.FreeSize:
                    return Size.FreeSize;
                    break;
                case Size2.NS:
                    return Size.NS;
                    break;
                case Size2.NOTVALID:
                    return Size.NOTVALID;
                    break;


                case Size2.T28:

                case Size2.T30:

                case Size2.T32:

                case Size2.T34:

                case Size2.T36:

                case Size2.T38:

                case Size2.T40:

                case Size2.T41:

                case Size2.T42:

                case Size2.T44:

                case Size2.T46:

                case Size2.T48:

                case Size2.B36:

                case Size2.B38:

                case Size2.B40:

                case Size2.B42:

                case Size2.B44:

                case Size2.B46:

                case Size2.B96:

                case Size2.B100:

                case Size2.B104:

                case Size2.B108:

                    var jj2 = size.ToString().Remove(0, 1);
                    return (Size)sizeList.IndexOf($"C{jj2}");
                    break;
                default:
                    return Size.NOTVALID;
                    break;
            }
        }


        
        /// <summary>
        /// Set Size based on style code and Category
        /// </summary>
        /// <param name="style"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        
        private Size SetSize(string style, string category)
        {
            Size size = Size.NOTVALID;
            var name = style.Substring(style.Length - 4, 4);

            // Jeans and Trousers

            if (category.Contains("Boxer") || category.Contains("Socks") || category.Contains("H-Shorts") || category.Contains("Shirt") || category.Contains("Vests") || category.Contains("Briefs") || category.Contains("Jackets") || category.Contains("Sweat Shirt") || category.Contains("Sweater") || category.Contains("T shirts"))
            {
                if (name.EndsWith(Size.XXXL.ToString())) size = Size.XXXL;
                else if (name.EndsWith(Size.XXL.ToString())) size = Size.XXL;
                else if (name.EndsWith(Size.XL.ToString())) size = Size.XL;
                else if (name.EndsWith(Size.L.ToString())) size = Size.L;
                else if (name.EndsWith(Size.M.ToString())) size = Size.M;
                else if (name.EndsWith(Size.S.ToString())) size = Size.S;
                else if (name.EndsWith("FS")) size = Size.FreeSize;
                else
                {
                    var nn = name.Substring(name.Length - 2).Trim();
                    int nx = 0;
                    if (Int32.TryParse(nn, out nx))
                    {
                        size = nx switch
                        {
                            39 => Size.S,
                            40 => Size.M,
                            42 => Size.L,
                            44 => Size.XL,
                            46 => Size.XXL,
                            48 => Size.XXXL,
                            _ => Size.NOTVALID,
                        };
                    }
                    else
                    {
                    }
                }
            }
            else if (category.Contains("Shorts") || category.Contains("Jeans") || category.Contains("Trouser") || category.Contains("Trousers"))
            {
                int x = sizeList.IndexOf($"C{name[2]}{name[3]}");
                size = (Size)x;
            }
            else if (category.Contains("Bundis") || category.Contains("Blazer") || category.Contains("Blazers") || category.Contains("Suits"))
            {
                int x = sizeList.IndexOf($"C{name[2]}{name[3]}");
                if (x == -1)
                {
                    x = sizeList.IndexOf($"C{name[1]}{name[2]}{name[3]}");
                }
                if (x == -1)
                {
                    size = Size.NOTVALID;
                }
                else
                    size = (Size)x;
            }
            else if (category.Contains("Accessories"))
            {
                size = Size.NS;
            }
            else
            {
                size = Size.NOTVALID;
            }
            return size;
        }

        /// <summary>
        /// Set Unit name fromm String Name
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Unit StringToUnit(string str)
        {
            if (str.ToLower() == "pcs") return Unit.Pcs;
            else if (str.ToLower() == "mtrs") return Unit.Meters;
            else if (str.ToLower() == "nos") return Unit.Nos;
            else return Unit.NoUnit;
        }

        private string ToBrandCode(string style, string type)
        {
            string bcode = "";
            if (type == "Readmade")
            {
                if (style.StartsWith("FM"))
                {
                    bcode = "FM";
                }
                else if (style.StartsWith("ARI")) bcode = "ADR";
                else if (style.StartsWith("HA")) bcode = "HAN";
                else if (style.StartsWith("AA")) bcode = "ARN";
                else if (style.StartsWith("AF")) bcode = "ARR";
                else if (style.StartsWith("US")) bcode = "USP";
                else if (style.StartsWith("AB")) bcode = "ARR";
                else if (style.StartsWith("AK")) bcode = "ARR";
                else if (style.StartsWith("AN")) bcode = "ARR";
                else if (style.StartsWith("ARE")) bcode = "ARR";
                else if (style.StartsWith("ARG")) bcode = "ARR";
                else if (style.StartsWith("AS")) bcode = "ARS";
                else if (style.StartsWith("AT")) bcode = "ARR";
                else if (style.StartsWith("F2")) bcode = "FM";
                else if (style.StartsWith("UD")) bcode = "UD";
            }
            else if (type == "Fabric") { }
            else if (type == "Promo")
            {
                bcode = "ARP";
            }
            else
            {
                bcode = "ARD";
            }

            return bcode;
        }

        private ProductCategory ToProductCategory(string str)
        {
            if (str == "Readmade" || str == "Readymade") return ProductCategory.Apparel;
            else if (str == "Fabric") return ProductCategory.Fabric;
            else if (str == "Promo") return ProductCategory.PromoItems;
            else if (str == "Tailoring") return ProductCategory.Tailoring;
            else return ProductCategory.Others;
        }

        //private Size ToSize(string size)
        //{
        //    //TODO: Implemenet Size
        //    return Size.S;
        //}
    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}