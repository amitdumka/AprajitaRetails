using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.ViewModels;
using Blazor.AdminLte;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Syncfusion.Blazor.RichTextEditor;
using Syncfusion.XlsIO;
using System.Net.WebSockets;
using System.Text.Json; 
using Path = System.IO.Path;

namespace AprajitaRetails.Server.BL.Imports
{
    /// <summary>
    /// Purchase Import 
    ///     This is regular purchase import from excel  or json file. 
    /// </summary>
    public class PurchaseImport
    {
        //Read Excel File 
        //Read Json File

        private readonly ARDBContext _db;
        private string StoreId = "MBO";
        private string GroupId = "MBO";
        public PurchaseImport(ARDBContext context)
        {
            _db = context;
        }

        public async Task<bool> ImportPurchaseAsync(string storeId, string filename, string sheetName, string range)
        {
            StoreId = storeId;
            GroupId = _db.Stores.Find(storeId).StoreGroupId ?? "MBO";

            var path = Path.GetPathRoot(filename);
            var fn = Path.GetFileName(path);
            var jsonfilename = Path.GetFileNameWithoutExtension(path) + ".json";
            //Reading Excel file and storing in json file for future use. 
            var json = await ImportHelper.ConvertExcelToJson<PurchaseData>(path, fn, sheetName, range, jsonfilename, true);
            //Passing json object to furhter processing
            var purchaseList = JsonSerializer.Deserialize<List<PurchaseData>>(json);

            //Forwaring to object to create Product Item 
            if(PurchaseToDB(purchaseList)>0) return true;
            else return false;

        }
        private bool AddOrUpdateSupplier(List<string> suppliers)
        {

            foreach (var sup in suppliers)
            {
                if (_db.Suppliers.Where(c => c.SupplierName == sup).Count() == 0)
                {
                    Supplier s = new Supplier { SupplierName = sup, Warehouse = sup };
                    _db.Suppliers.Add(s);
                }
            }

            return _db.SaveChanges() > 0;
        }

        private bool AddOrUpdateProductItem(List<ProductItem> products)
        {

            foreach (var product in products)
            {
                if (_db.ProductItems.Any(c => c.Barcode == product.Barcode) == false)
                {
                    _db.ProductItems.Add(product);
                }
            }

            return _db.SaveChanges() > 0;
        }

        private bool AddOrUpdateStock(List<Stock> stocks)
        {
            foreach (var stock in stocks)
            {
                if (_db.Stocks.Any(c => c.Barcode == stock.Barcode && c.StoreId == stock.StoreId))
                {
                    var s = _db.Stocks.Where(c => c.Barcode == stock.Barcode && c.StoreId == stock.StoreId).First();
                    s.PurchaseQty += stock.PurchaseQty;
                    if (s.MRP < stock.MRP)
                    {
                        s.MRP = stock.MRP;
                    }
                    _db.Stocks.Update(s);
                }
                else
                {

                    _db.Stocks.Add(stock);
                }
            }

            return _db.SaveChanges() > 0;

        }

        private bool AddOrUpdateCat(List<string> cats)
        {
            foreach (var cat in cats)
            {
                if (_db.ProductTypes.Any(c => c.ProductTypeId == cat) == false)
                {
                    ProductType pt = new ProductType { ProductTypeId = cat, ProductTypeName = cat };
                    ProductSubCategory catSubCategory = new ProductSubCategory
                    {
                        SubCategory = cat

                    };
                    _db.ProductSubCategories.Add(catSubCategory);
                    _db.ProductTypes.Add(pt);
                }
            }
            return _db.SaveChanges() > 0;
        }
        /// <summary>
        /// Processing Purchase List
        /// </summary>
        /// <param name="purchaseList"></param>
        private int PurchaseToDB(List<PurchaseData> purchaseList)
        {

            List<ProductPurchase> products;//= new List<ProductPurchase>();
            List<PurchaseItem> purchaseItems = new List<PurchaseItem>();
            List<ProductItem> productsItem = new List<ProductItem>();

            var catList = purchaseList.GroupBy(x => x.Category).Select(c => c.Key).Distinct().ToList();
            AddOrUpdateCat(catList);
            var supList = purchaseList.GroupBy(x => x.SupplierName).Select(c => c.Key).Distinct().ToList();
            AddOrUpdateSupplier(supList);

            //Creating Purchase Item
            foreach (var item in purchaseList)
            {
                PurchaseItem pi = new PurchaseItem
                {
                    Barcode = item.Barcode,
                    FreeQty = 0,
                    Qty = item.Quantity,
                    CostPrice = item.Rate,
                    CostValue = item.CostValue,
                    InwardNumber = $"{StoreId}-{item.InwardDate.Year}-{item.InwardDate.Month}-{item.InwardDate.Day}",
                    Unit = Unit.Meters,
                    TaxAmount = (item.Rate * item.TaxRate * item.Quantity) / 100,
                    DiscountValue = item.Discount > 0 ? item.Rate - (item.Rate * item.Discount / 100) : 0,
                };
                purchaseItems.Add(pi);
                ProductItem p = new ProductItem
                {
                    Barcode = item.Barcode,
                    BrandCode = item.Brand,
                    HSNCode = item.HSNCode,
                    MRP = item.UnitMRP,
                    Name = item.StyleCode,
                    StoreGroupId = GroupId,
                    StyleCode = item.StyleCode,
                    Size = Size.FreeSize,
                    Description = item.Category,
                    ProductCategory = ProductCategory.Fabric,
                    TaxType = TaxType.GST,
                    Unit = Unit.Meters,
                    SubCategory = item.Category,
                    ProductTypeId = item.Category,
                };
                productsItem.Add(p);
            }

            //Creating Purchase Invoice
            products = purchaseList.GroupBy(c => c.InvoiceNumber)
                .Select(c => new ProductPurchase
                {
                    Count = c.Count(),
                    InvoiceNo = c.Key,
                    MarkedDeleted = false,
                    OnDate = c.Select(x => x.InvoiceDate).First(),
                    Paid = false,
                    IsReadOnly = true,
                    EntryStatus = EntryStatus.Added,
                    FreeQty = 0,
                    BillQty = c.Sum(x => x.Quantity),
                    InvoiceType = PurchaseInvoiceType.Purchase,
                    InwardDate = c.Select(x => x.InwardDate).First(),
                    UserId = "AutoAdmin",
                    ShippingCost = 0,
                    StoreId = StoreId,
                    InwardNumber = $"{StoreId}-{c.Select(x => x.InwardDate).First().Year}-{c.Select(x => x.InwardDate).First().Month}-{c.Select(x => x.InwardDate).First().Day}",
                    TaxType = TaxType.GST,
                    TotalQty = c.Sum(x => x.Quantity),
                    Warehouse = c.Select(x => x.SupplierName).First(),
                    VendorId = _db.Vendors.Where(x => x.VendorName == c.Select(y => y.SupplierName).First()).First().VendorId,
                    BasicAmount = c.Sum(x => x.BasicValue),
                    TaxAmount = c.Sum(x => x.TaxAmount),
                    TotalAmount = c.Sum(x => x.CostValue),
                    DiscountAmount = c.Sum(x => x.DiscountAmount),

                })
                .ToList();
            //Creating Stock

            var stocklist = purchaseList.GroupBy(c => c.Barcode)
                .Select(c => new Stock
                {
                    Barcode = c.Key,
                    StoreId = StoreId,
                    HoldQty = 0,
                    EntryStatus = EntryStatus.Added,
                    IsReadOnly = false,
                    MarkedDeleted = false,
                    MultiPrice = false,
                    SoldQty = 0,
                    Unit = Unit.Meters,
                    UserId = "autoAdmin",
                    PurchaseQty = c.Sum(x => x.Quantity),
                    CostPrice = c.Sum(x => x.CostValue),
                    MRP = c.Select(x => x.UnitMRP).First(),
                    Id = Guid.NewGuid(),
                })
                .ToList();
            //Removing Duplicate ProductItem 

            productsItem = productsItem.GroupBy(c => c.Barcode)
                .Select(c => new ProductItem
                {
                    Barcode = c.Key,
                    BrandCode = c.Select(x => x.BrandCode).First(),
                    Description = c.Select(x => x.Description).First(),
                    HSNCode = c.Select(x => x.HSNCode).First(),
                    MRP = c.Select(x => x.MRP).First(),
                    Unit = Unit.Meters,
                    Size = Size.FreeSize,
                    StoreGroupId = GroupId,
                    TaxType = TaxType.GST,
                    ProductCategory = ProductCategory.Fabric,
                    StyleCode = c.Select(x => x.StyleCode).First(),
                    Name = c.Select(c => c.Name).First(),
                    SubCategory = c.Select(x => x.SubCategory).First(),
                    ProductTypeId = c.Select(x => x.ProductTypeId).First()

                })
                .ToList();


            AddOrUpdateProductItem(productsItem);
            _db.ProductPurchases.AddRange(products);
            _db.PurchaseItems.AddRange(purchaseItems);
            var x = _db.SaveChanges();
            if (x > 0)
            {
                AddOrUpdateStock(stocklist);
            }
            return x;

        }

    }

    public class ImportHelper
    {
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
        public static async Task<string> ConvertExcelToJson<T>(string path, string filename, string worksheet, string range, string jsonfilename, bool savejson)
        {
            try
            {
                var data = ReadExcel<T>(path, filename, worksheet, range);
                if (savejson)
                {
                    var json = await ObjectToJsonFileAsync(data, jsonfilename);
                    return json;
                }
                else
                {
                    var json = ObjectToJson<T>(data);
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

        public static string ReadJsonFile(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return json;// JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


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
        public static T? JsonToObjectSingle<T>(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
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
        { return JsonSerializer.Serialize<List<T>>(lists); }

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
        /// <returns>save to json file and return json string</returns>
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
        public static List<T>? ReadExcel<T>(
            string path,
            string fn,
            string worksheetName,
            string rangeI,
            bool isSchema = false)
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
        public static Stream WriteExcel<T>(string path, string fn, string worksheetName, List<T> data, bool isNew = false)
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


                //Accessing first worksheet in the workbook
                IWorksheet worksheet;//= workbook.Worksheets[worksheetName];
                if (isNew)
                {
                    worksheet = workbook.Worksheets.Create(worksheetName);
                }
                else
                {
                    worksheet = workbook.Worksheets[worksheetName];
                }

                //Save the document as a stream and return the stream
                var dt = DocIO.ToDataTable(data);
                worksheet.ImportDataTable(dt, true, 1, 1, true);
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream
                    workbook.SaveAs(reader);
                    workbook.SaveAs(stream);
                    reader.Close();
                    return stream;
                }
            }
        }
    }




    
}
