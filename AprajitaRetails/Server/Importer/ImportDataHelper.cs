using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Syncfusion.XlsIO;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{
    public class ImportHelper
    {
        private IWebHostEnvironment hostingEnv;
        private ARDBContext aRDB;

        public ImportHelper(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env; aRDB = db;
        }

        public DbContext GetContact()
        { return aRDB; }

        public IWebHostEnvironment GetHostEnvironment()
        { return hostingEnv; }
    }

    public class ImportDataHelper
    {
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
    }

    public class ExcelToDB : ExcelToJson
    {
        private ARDBContext _db;

        public ExcelToDB(ARDBContext db)
        {
            _db = db;
        }
    }

    public class ExcelToJson
    {
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



        private string SetBrandCode(string style, string cat, string type)
        {
            string bcode = "";
            if (cat == "Apparel")
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
            else if (cat == "Shirting" || cat == "Suiting")
            {
                bcode = "ARD";
            }
            else

            if (cat == "Promo")
            {
                if (type == "Free GV") { bcode = "AGV"; }
                else bcode = "ARP";
            }
            else if (cat == "Suit Cover")
            {
                bcode = "ARA";
            }
            return bcode;
        }

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
        public Size ToSize(string size)
        {
            return Size.S;
        }

        public Unit StringToUnit(string str)
        {
            if (str.ToLower() == "pcs") return Unit.Pcs;
            else if (str.ToLower() == "mtrs") return Unit.Meters;
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
                var jsondata = await this.ConvertExcelToJson<PurchaseInvoiceItem>(path, excelfilename, worksheet, range, jsonFileName, savejson);

                // Convert to Purchase Invoice, item, and stock
                var data = ImportDataHelper.JsonToObject<PurchaseInvoiceItem>(jsondata);

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
                }).ToList();

                // Create purchase Invoice


                var purchaseInvoice = data.Select(c => new ProductPurchase
                {
                    EntryStatus = EntryStatus.Added,
                    InvoiceNo = c.InvoiceNumber,
                    FreeQty = 0,
                    InvoiceType = PurchaseInvoiceType.Purchase,
                    StoreId = storecode,
                    InwardDate = c.InwardDate,
                    InwardNumber = c.InvoiceNumber,
                    IsReadOnly = true,
                    MarkedDeleted = false,
                    OnDate = c.InvoiceDate,
                    Paid = true,
                    TaxType = TaxType.IGST,
                    UserId = "AutoAdmin",
                    Warehouse = c.SupplierName,

                }).ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    class PurchaseInvoiceItem
    {
        [Key]
        public int SN { get; set; }
        public string InwardNumber { get; set; }
        public DateTime InwardDate { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string StoreCode { get; set; }
        public string ProductCategory { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string StyleCode { get; set; }
        public string ProductDescription { get; set; }
        public string HSNCODE { get; set; }
        public string Size { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitMRP { get; set; }
        public decimal MRPValue { get; set; }
        public decimal UnitCost { get; set; }
        public decimal CostValue { get; set; }
        public decimal IGST_CGSTRate { get; set; }
        public decimal SGSTRate { get; set; }
        public decimal IGST_CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal RoundOff { get; set; }
        public decimal BillAmount { get; set; }
    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}