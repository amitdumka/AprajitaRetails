using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Syncfusion.ExcelExport;
using Syncfusion.XlsIO;
using System.Data;
using System.Reflection;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{

    //SN	Date	InvoiceNo	Customer 	Mobile	PayMode	BillAmount
    public class NewSaleInfo
    {
        // [Key]
        public int? SN { set; get; }
        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }
        public decimal? BillAmount { get; set; }
        public string? PayMode { get; set; }
    }
    public class NewSale
    {//SN	Date	Invoice No	Customer	Mobile	Barcode	MRP	QTY	Discount	LineTotal	BillAmount	PayMode
        //[Key]
        public int? SN { set; get; }

        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }
        public string? Barcode { get; set; }
        public decimal? MRP { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Discount { get; set; }
        public decimal? LineTotal { get; set; }
        public decimal? BillAmount { get; set; }
        public string? PayMode { get; set; }
    }

    public class NewProfitLoss //: NewSale
    {
        //Date	InvoiceNo	Barcode	Quantity	MRP	CostPrice	
        //Discount %	DiscountAmount	BasicPrice	TaxAmount	SalePrice	RoundOff	BilAmount	Profit/Loss
        // [Key]
        public int? SN { set; get; }
        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        //public string? Customer { get; set; }
        //public string? Mobile { get; set; }
        public string? Barcode { get; set; }
        public decimal? MRP { get; set; }
        public decimal? Quantity { get; set; }

        public decimal? Discount { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? BillAmount { get; set; }
        //public string? PayMode { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? ProfitLoss { get; set; }
    }

    public class ImportNewExcel
    {
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
        public static List<T>? JsonToObject<T>(string json)
        {
            try
            {
                // using StreamReader reader = new StreamReader(filename);
                //var json = reader.ReadToEnd();
                //reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static async Task<bool> NewData(string path, ARDBContext db)
        {

            // var data = ImportData(path, "InvoiceList", "O1:U127", false);
            // var data2 = ImportData(path, "InvoiceList", "A1:L274", false);
            // var data3 = ImportData(path, "PofitLoss", "A1:N564", false);
            try
            {


                //var InvInfo = JsonToObject<NewSaleInfo>(ImportData(path, "InvoiceList", "O1:U127", false));
                //var Invsale = JsonToObject<NewSaleInfo>(ImportData(path, "InvoiceList", "A1:L274", false));
                //var InvProfit = JsonToObject<NewSaleInfo>(ImportData(path, "PofitLoss", "A1:N564", false));

                var InvInfo = ImportData<NewSaleInfo>(path, "InvoiceList", "O1:U126", false);
                var Invsale = ImportData<NewSale>(path, "InvoiceList", "A1:L261", false);
                var InvProfit = ImportData<NewProfitLoss>(path, "ProfitLoss", "A1:N547", false);
                // InvList present in invinfo and sale
                var invs = InvInfo.Select(c => c.InvoiceNo).ToList();

                var x = InvInfo.Select(c => c.InvoiceNo).Except(Invsale.Select(c => c.InvoiceNo).Distinct()).ToList();
                var invs2 = Invsale.Select(c => c.InvoiceNo).Distinct().Except(invs).ToList();
                var miss = InvInfo.Select(c => c.InvoiceNo).Except(InvProfit.Select(c => c.InvoiceNo).Distinct().ToList()).ToList();

                var JSONFILE = JsonSerializer.Serialize<List<string>>(x);
                using StreamWriter writer = new StreamWriter(Path.Combine(path, "Data/invsale.json"));
                await writer.WriteAsync(JSONFILE);
                writer.Close();

                JSONFILE = JsonSerializer.Serialize<List<string>>(invs2);
                using StreamWriter writer2 = new StreamWriter(Path.Combine(path, "Data/inv2.json"));
                await writer2.WriteAsync(JSONFILE);
                writer.Close();

                JSONFILE = JsonSerializer.Serialize<List<string>>(miss);
                using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/miss.json"));
                await writer1.WriteAsync(JSONFILE);
                writer.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewSaleInfo>>(InvInfo);
                using StreamWriter writer11 = new StreamWriter(Path.Combine(path, "Data/InvInfo.json"));
                await writer11.WriteAsync(JSONFILE);
                writer.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewSale>>(Invsale);
                using StreamWriter writer12 = new StreamWriter(Path.Combine(path, "Data/InvDetail.json"));
                await writer12.WriteAsync(JSONFILE);
                writer.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewProfitLoss>>(InvProfit);
                using StreamWriter writer13 = new StreamWriter(Path.Combine(path, "Data/InvProfitLoss.json"));
                await writer13.WriteAsync(JSONFILE);
                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //private IWebHostEnvironment hostingEnv;
        public static List<T>? ImportData<T>(string path, string worksheetName, string rangeI, bool isSchema = false)
        {
            //Excel import
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                var filename = Path.Combine(path, @"Data/gstdata.xlsm");
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

                var objList = ConvertDataTable<T>(dt);
                return objList;
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    //Save the created Excel document to MemoryStream
                //    //if (option == "Workbook")
                //    //    workbook.SaveAsJson(stream, isSchema);
                //    //else if (option == "Worksheet")
                //    //    workbook.SaveAsJson(stream, worksheet, isSchema);
                //    //else if (option == "Range")
                //    //    workbook.SaveAsJson(stream, range, isSchema);
                //    workbook.SaveAsJson(stream, range, true);
                //    byte[] json = new byte[stream.Length];
                //    stream.Position = 0;
                //    stream.Read(json, 0, (int)stream.Length);
                //    string jsonString = Encoding.UTF8.GetString(json);
                //    stream.Position = 0;
                //    JObject j = JObject.Parse(jsonString);
                //    var jstr = j[worksheetName].ToString();
                //  var x4=  JsonSerializer.Serialize(jstr);
                //    //var tx = j[worksheetName].ToObject<List<T>>();
                //   // return tx;
                //     return JsonToObject<T>(x4);
                //}
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                try
                {


                    if (((string)dr[column.ColumnName]) != null || dr[column.ColumnName] != typeof(DBNull))
                    {
                        foreach (PropertyInfo pro in temp.GetProperties())
                        {
                            if (pro.Name == column.ColumnName)
                            {
                                switch (column.ColumnName)
                                {
                                    case "Amount":
                                    case "BillAmount":
                                    case "Qty":
                                    case "Quantity":
                                    case "MRP":
                                    case "LineTotal":
                                    case "SaleAmount":
                                    case "CostPrice":
                                    case "TaxAmount":
                                    case "BasicPrice":
                                    case "RoundOff":
                                    case "ProfitLoss":

                                    case "Discount":
                                    case "DiscountAmount":
                                        pro.SetValue(obj, decimal.Parse((string)dr[column.ColumnName]), null);
                                        break;
                                    case "Date":
                                    case "OnDate":
                                        pro.SetValue(obj, DateTime.Parse((string)dr[column.ColumnName]), null);
                                        break;
                                    case "EntryStatus":
                                        //case "PayMode":
                                        pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                        break;
                                    case "IsDue":
                                    case "ManualBill":
                                    case "SalesReturn":
                                    case "TailoringBill":
                                    case "IsReadOnly":
                                    case "MarkedDeleted":


                                        pro.SetValue(obj, bool.Parse((string)dr[column.ColumnName]), null);
                                        break;
                                    case "EDCTerminalId":
                                        pro.SetValue(obj, null, null);
                                        break;
                                    case "SN":
                                        pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                        break;
                                    case "Customer":
                                    case "Mobile":
                                    case "PayMode":
                                    case "InvoiceNo":
                                    default:
                                        if (!string.IsNullOrEmpty((string)dr[column.ColumnName]))
                                            pro.SetValue(obj, (string)dr[column.ColumnName], null);
                                        break;
                                }

                            }
                            else
                                continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }
            return obj;

        }

        private decimal DisAmt(decimal mrp, decimal dis)
        {
            return mrp * (dis / 100);
        }
        private static decimal GetBasicAmt(decimal amt, Unit unit)
        {
            decimal TaxRate = 5;
            if (unit != Unit.Meters && amt > 999) TaxRate = 12;
            //Need to implement for jacket and other then 12 % option
            TaxRate = TaxRate / 100;
            var Basic = amt / (1 + TaxRate);
            return Basic;
        }

        // Generate Sale Inv from New Sale
        public static void GenerateSaleInv(string json, ARDBContext db)
        {
            var sales = JsonToObject<NewSale>(json);
            List<ProductSale> pSale = new List<ProductSale>();
            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (var im in sales)
            {
                SaleItem si = new SaleItem
                {
                    Adjusted = false,
                    Barcode = im.Barcode,
                    BilledQty = (decimal)im.Qty,
                    DiscountAmount = (decimal)im.Discount / 100,
                    FreeQty = 0,
                    InvoiceNumber = im.InvoiceNo,
                    LastPcs = false,
                    Value = (decimal)im.LineTotal,
                    TaxType = TaxType.GST,
                    Unit = Unit.NoUnit,
                    InvoiceType = (decimal)im.Qty > 0 ? InvoiceType.Sales : InvoiceType.SalesReturn,
                    BasicAmount = 0,
                    TaxAmount = 0,
                };
                si.Unit = (decimal)im.Qty % 1 == 0 ? Unit.Meters : Unit.NoUnit;
                if (si.Unit == Unit.Meters)
                {
                    si.BasicAmount = GetBasicAmt(si.Value, Unit.Meters);
                    si.TaxAmount = si.Value - si.BasicAmount;
                }
                saleItems.Add(si);
            }

            var pis = db.ProductItems.Select(c => new { c.Barcode, c.Unit, c.MRP }).ToList();

            foreach (var im in saleItems)
            {
                var s = pis.Where(c => c.Barcode == im.Barcode).First();
                if (s != null)
                {
                    im.Unit = s.Unit;
                    im.DiscountAmount = s.MRP * im.DiscountAmount;
                    if (im.Unit == Unit.Meters)
                    {
                        im.BasicAmount = GetBasicAmt(im.Value, Unit.Meters);
                        im.TaxAmount = im.Value - im.BasicAmount;
                    }
                }
                else
                {
                    var x = sales.Where(c => c.Barcode == im.Barcode && c.InvoiceNo == im.InvoiceNumber).First();

                    ProductItem p = new ProductItem
                    {
                        HSNCode = "",
                        Description = "",
                        BrandCode = "",
                        Barcode = im.Barcode,
                        MRP = x.MRP.Value,
                        Name = "#MISSINGINFO",
                        Unit = Unit.NoUnit,
                        TaxType = TaxType.GST,
                        SubCategory = "",
                        StyleCode = "",
                        Size = Size.NOTVALID,
                        ProductTypeId = "",
                        ProductCategory = ProductCategory.Others

                    };
                    // Productitem as Reject then confirm when item is added.
                    im.DiscountAmount = x.MRP.Value * im.DiscountAmount;
                    if (im.Unit == Unit.Meters)
                    {
                        im.BasicAmount = GetBasicAmt(im.Value, Unit.Meters);
                        im.TaxAmount = im.Value - im.BasicAmount;
                    }
                    db.ProductItems.Add(p);

                }
            }


            var ins = saleItems.GroupBy(c => c.InvoiceNumber).
                Select(c => new ProductSale
                {
                    Adjusted = false,
                    EntryStatus = EntryStatus.Added,
                    FreeQty = 0,
                    InvoiceNo = c.Key,
                    IsReadOnly = true,
                    MarkedDeleted = false,
                    Taxed = true,
                    StoreId = "ARD",
                    Paid = true,
                    Tailoring = false,
                    UserId = "AutoAdmin",
                    SalesmanId = "ARD/SM/0001",
                    OnDate = sales.Where(x => x.InvoiceNo == c.Key).First().Date.Value,
                    BilledQty = c.Sum(x => x.BilledQty),
                    TotalBasicAmount = c.Sum(x => x.BasicAmount),
                    TotalDiscountAmount = c.Sum(x => x.DiscountAmount),
                    TotalTaxAmount = c.Sum(x => x.TaxAmount),
                    TotalMRP = c.Sum(x => x.DiscountAmount + x.Value),
                    InvoiceType = c.Select(x => x.InvoiceType).First(),
                    TotalPrice = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value,
                    RoundOff = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value - c.Sum(x => x.Value)
                }).ToList();

            var forP = sales.Where(c => string.IsNullOrEmpty(c.PayMode) == false)
           .Select(c => new SalePaymentDetail
           {
               InvoiceNumber = c.InvoiceNo,
               PaidAmount = c.BillAmount.Value,
               RefId = "Missing",
               PayMode = PayModeType(c.PayMode)
           }).ToList();

            foreach(var im in forP.Where(c => c.PayMode == PayMode.Card))
            {
                CardPaymentDetail cd = new CardPaymentDetail {
                    AuthCode=0, Card=Card.DebitCard, CardLastDigit=-1,
                    CardType=CardType.Rupay, InvoiceNumber=im.InvoiceNumber,
                     PaidAmount=im.PaidAmount, EDCTerminalId=null, 

                };
                db.CardPaymentDetails.Add(cd);
            }

        }

        private static PayMode PayModeType(string p) {

            switch (p.ToLower())
            {
                case "cash": return PayMode.Cash;
                case "card": return PayMode.Card;
                case "upi":return PayMode.UPI;
                case "mix": return PayMode.MixPayments;
                case "icicipine": return PayMode.Card;
                case "icicipineupi": return PayMode.UPI;

                default:
                    if (p.ToLower().Contains("mix")) return PayMode.MixPayments;
                    else return PayMode.Others;
                   
            }
            
        }
        public static void FillMissingInvInProfitList(string pathfileName, string invListRange, string profitRange)
        {

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                var filename = pathfileName;// Path.Combine(path, @"Data/gstdata.xlsm");

                // using StreamReader reader = new StreamReader(filename);
                using FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);

                //Opening the encrypted Workbook
                IWorkbook workbook = application.Workbooks.Open(reader, ExcelParseOptions.Default);
                reader.Close();

                //Accessing first worksheet in the workbook
                IWorksheet wsProfitLoss = workbook.Worksheets["ProfitLoss"];
                IWorksheet wsInvList = workbook.Worksheets["InvoiceList"];

                IRange rangePL = wsProfitLoss.Range[profitRange];
                IRange rangeIL = wsInvList.Range[invListRange];
                //Save the document as a stream and return the stream

                var dtPL = wsProfitLoss.ExportDataTable(rangePL, ExcelExportDataTableOptions.ColumnNames);
                var dtIL = wsInvList.ExportDataTable(rangeIL, ExcelExportDataTableOptions.ColumnNames);

                //var objList = ConvertDataTable<T>(dt);
                //return objList;

            }
        }

    }
}