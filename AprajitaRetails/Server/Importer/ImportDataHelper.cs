using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Syncfusion.XlsIO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{
    public class ExcelToDB : ExcelToJson
    {
        private ARDBContext _db;

        public ExcelToDB(ARDBContext db, string sc, string sg)
        {
            _db = db;
            _storeCode = sc; _storeGroup = sg;
            UpdateCat();
            sizeList = Enum.GetNames(typeof(Size)).ToList();
        }

        public async void UpdateCat()
        {
            //TODO: implementing StoreGroup conpect here
            var subcats = await _db.ProductSubCategories.ToListAsync();
            var ptypes = await _db.ProductTypes.ToListAsync();
            this.UpdateSubCategory(subcats);
            this.UpdateProductType(ptypes);
        }
        public static bool SeedBasicVendor(ARDBContext db)
        {
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
            vendors.Add(v1);
            vendors.Add(v2);
            vendors.Add(v3);
            vendors.Add(v4);
            vendors.Add(v5);
            vendors.Add(v6);
            vendors.Add(v7);
            vendors.Add(v8);

            db.Vendors.AddRange(vendors);
            return (db.SaveChanges() == 7);
        }
    }

    public class ExcelToJson
    {
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

        public ProductCategory GetProductCategory(string cat) => ToProductCategory(cat);

        public string GetProductType(string product)
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

        public string GetSubCategoryId(string cat)
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

        public string GetVendorId(string sup)
        {

            return VendorMapping(sup);
        }
        /// <summary>
        /// Map Vendor from Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static string VendorMapping(string supplier)
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
                "Aprajita Retails - Dumka" => "ARD/VIN/0008",
                _ => "ARD/VIN/0002",
            };
            return id;
        }
        public async Task ImportPurchaseInvoiceAsync(string path, string excelfilename, string worksheet, string range, string storecode, string storegroup, bool savejson)
        {
            string jsonFileName = "";
            try
            {
                if (savejson)
                {
                    jsonFileName = Path.Combine(path, storegroup, storecode, $@"json/{worksheet}/PurchaseInvoice.json");
                    Directory.CreateDirectory(Path.GetDirectoryName(jsonFileName));
                }
                //var jsondata = await this.ConvertExcelToJson<PurchaseInvoiceItem>(path, excelfilename, worksheet, range, jsonFileName, savejson);

                // Convert to Purchase Invoice, item, and stock
                //var data = ImportDataHelper.JsonToObject<PurchaseInvoiceItem>(jsondata);
                var data = ImportDataHelper.ReadExcel<PurchaseInvoiceItem>(path, excelfilename, worksheet, range);

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
                }).ToList();

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

                //Create Stock Item
                //filter stock at adding to db for duplicate stock item.
                var stocks = data.Select(c => new Stock
                {
                    StoreId = storecode,
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
                }).ToList();

                // Create purchase Invoice

                var purchaseInvoice = data.GroupBy(c => c.InvoiceNumber).Select(c => new ProductPurchase
                {
                    EntryStatus = EntryStatus.Added,
                    InvoiceNo = c.Key,
                    FreeQty = 0,
                    InvoiceType = PurchaseInvoiceType.Purchase,
                    StoreId = storecode,
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
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Set Unit name fromm String Name
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Unit StringToUnit(string str)
        {
            if (str.ToLower() == "pcs") return Unit.Pcs;
            else if (str.ToLower() == "mtrs") return Unit.Meters;
            else if (str.ToLower() == "nos") return Unit.Nos;
            else return Unit.NoUnit;
        }

        public ProductCategory ToProductCategory(string str)
        {
            if (str == "Readmade") return ProductCategory.Apparel;
            else if (str == "Fabric") return ProductCategory.Fabric;
            else if (str == "Promo") return ProductCategory.PromoItems;
            else if (str == "Tailoring") return ProductCategory.Tailoring;
            else return ProductCategory.Others;
        }

        public Size ToSize(string size)
        {
            //TODO: Implemenet Size 
            return Size.S;
        }
        
        /// <summary>
        /// set Unit for item
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Unit SetUnitFromProductName(string name)
        {
            if (name.StartsWith("Apparel")) { return Unit.Pcs; }
            else if (name.StartsWith("Promo") || name.StartsWith("Suit Cover")) { return Unit.Nos; }
            else if (name.StartsWith("Shirting") || name.StartsWith("Suiting")) { return Unit.Meters; }
            return Unit.NoUnit;
        }

        public void UpdateProductType(List<ProductType> productType)
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

        public void UpdateSubCategory(List<ProductSubCategory> category)
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


        /// <summary>
        /// Set Size based on style code and Category
        /// </summary>
        /// <param name="style"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public Size SetSize(string style, string category)
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
                int x = sizeList.IndexOf($"T{name[2]}{name[3]}");
                size = (Size)x;
            }
            else if (category.Contains("Bundis") || category.Contains("Blazer") || category.Contains("Blazers") || category.Contains("Suits"))
            {
                int x = sizeList.IndexOf($"B{name[2]}{name[3]}");
                if (x == -1)
                {
                    x = sizeList.IndexOf($"B{name[1]}{name[2]}{name[3]}");
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
    }

    public class ImportDataHelper
    {
        /// <summary>
        /// Convert Json File to Object List
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <param name="filename">Json File with full path</param>
        /// <returns></returns>
        public static List<T>? JsonToObject<T>(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Convert Json Memomry Steam to list of Data Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename">Memory Stream</param>
        /// <returns></returns>
        public static List<T>? JsonToObject<T>(MemoryStream filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Serialize or convert to json string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static string ObjectToJson<T>(List<T> lists)
        {
            return JsonSerializer.Serialize<List<T>>(lists);
        }

        /// <summary>
        /// Serialize or convert to json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lists"></param>
        /// <param name="path">file name with full path</param>
        /// <returns></returns>
        public static async Task<string> ObjectToJsonFileAsync<T>(List<T> lists, string path)
        {
            var JSONFILE = JsonSerializer.Serialize<List<T>>(lists);
            using StreamWriter writer = new StreamWriter(path);
            await writer.WriteAsync(JSONFILE);
            writer.Close();
            return JSONFILE;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="path">file name with full path</param>
        /// <returns>save to json file and return json string </returns>
        public static async Task<string> ObjectToJsonFileAsync<T>(T obj, string path)
        {
            var JSONFILE = JsonSerializer.Serialize<T>(obj);
            using StreamWriter writer = new StreamWriter(path);
            await writer.WriteAsync(JSONFILE);
            writer.Close();
            return JSONFILE;
        }

        /// <summary>
        /// Import Excel File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Base Path</param>
        /// <param name="fn">Excel Filename and extra path</param>
        /// <param name="worksheetName">Worksheet Name</param>
        /// <param name="rangeI">Range For Importing data</param>
        /// <param name="isSchema">IsSchema need to follow</param>
        /// <returns>List of Data  In  Type Format</returns>
        public static List<T>? ReadExcel<T>(string path, string fn, string worksheetName, string rangeI, bool isSchema = false)
        {
            //Excel import
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                var filename = Path.Combine(path, fn);
                // using StreamReader reader = new StreamReader(filename);
                using FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);

                //Opening the encrypted Workbook
                IWorkbook workbook = application.Workbooks.Open(reader, ExcelParseOptions.Default);
                reader.Close();

                //Accessing first worksheet in the workbook
                IWorksheet worksheet = workbook.Worksheets[worksheetName];
                IRange range = worksheet.Range[rangeI];
                //Save the document as a stream and return the stream

                var dt = worksheet.ExportDataTable(range, ExcelExportDataTableOptions.ColumnNames);

                var objList = DocIO.ConvertDataTable<T>(dt);
                return objList;
            }
        }
    }

    public class ImportHelper
    {
        private ARDBContext aRDB;
        private IWebHostEnvironment hostingEnv;

        public ImportHelper(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env; aRDB = db;
        }

        public DbContext GetContact()
        { return aRDB; }

        public IWebHostEnvironment GetHostEnvironment()
        { return hostingEnv; }
    }

    internal class PurchaseInvoiceItem
    {
        public decimal Amount { get; set; }

        public string Barcode { get; set; }

        public decimal BillAmount { get; set; }

        public decimal CostValue { get; set; }

        public string HSNCODE { get; set; }

        public decimal IGST_CGSTAmount { get; set; }

        public decimal IGST_CGSTRate { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InwardDate { get; set; }

        public string InwardNumber { get; set; }

        public decimal MRPValue { get; set; }

        public string ProductCategory { get; set; }

        public string ProductDescription { get; set; }

        public string ProductName { get; set; }

        public decimal Quantity { get; set; }

        public decimal RoundOff { get; set; }

        public decimal SGSTAmount { get; set; }

        public decimal SGSTRate { get; set; }

        public string Size { get; set; }

        [Key]
        public int SN { get; set; }

        public string StoreCode { get; set; }
        public string StyleCode { get; set; }
        public string SupplierName { get; set; }
        public string Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitMRP { get; set; }
    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}