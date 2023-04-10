using System.Data;
using System.Reflection;
using System.Text.Json;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using Syncfusion.Drawing;
using Syncfusion.XlsIO;

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
        public decimal? QTY { get; set; }
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
        public static async Task<MemoryStream> GetSaleReportFromExcelSheetAsync(string path, ARDBContext db)
        {
            try
            {
                var Invsale = ImportData<NewSale>(path, "InvoiceList", "A1:L261", false);

                var JSONFILE = JsonSerializer.Serialize<List<NewSale>>(Invsale);
                using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/InvDetail.json"));
                await writer1.WriteAsync(JSONFILE);
                writer1.Close();

                return GenerateSaleInv(JSONFILE, db);
            }
            catch (Exception ex)
            {
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
                writer2.Close();

                JSONFILE = JsonSerializer.Serialize<List<string>>(miss);
                using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/miss.json"));
                await writer1.WriteAsync(JSONFILE);
                writer1.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewSaleInfo>>(InvInfo);
                using StreamWriter writer11 = new StreamWriter(Path.Combine(path, "Data/InvInfo.json"));
                await writer11.WriteAsync(JSONFILE);
                writer11.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewSale>>(Invsale);
                using StreamWriter writer12 = new StreamWriter(Path.Combine(path, "Data/InvDetail.json"));
                await writer12.WriteAsync(JSONFILE);
                writer12.Close();

                JSONFILE = JsonSerializer.Serialize<List<NewProfitLoss>>(InvProfit);
                using StreamWriter writer13 = new StreamWriter(Path.Combine(path, "Data/InvProfitLoss.json"));
                await writer13.WriteAsync(JSONFILE);
                writer13.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
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
                                    case "QTY":
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
            return Math.Round(mrp * (dis / 100), 2) ;
        }
        private static decimal GetBasicAmt(decimal amt, Unit unit)
        {
            decimal TaxRate = 5;
            if (unit != Unit.Meters && amt > 999) TaxRate = 12;
            //Need to implement for jacket and other then 12 % option
            TaxRate = TaxRate / 100;
            var Basic = amt / (1 + TaxRate);
            return Math.Round(Basic,2);
        }
        // Generate Sale Inv from New Sale
        public static MemoryStream GenerateSaleInv(string json, ARDBContext db)
        {
            var sales = JsonToObject<NewSale>(json);
            List<ProductSale> pSale = new List<ProductSale>();
            List<SaleItem> saleItems = new List<SaleItem>();
            int xx = 0;
            try
            {
                foreach (var im in sales)
                {
                    SaleItem si = new SaleItem
                    {
                        Adjusted = false,
                        Barcode = im.Barcode,
                        BilledQty = (decimal)im.QTY.Value,
                        DiscountAmount = (decimal)im.Discount.Value / 100,
                        FreeQty = 0,
                        InvoiceNumber = im.InvoiceNo,
                        LastPcs = false,
                        Value = (decimal)im.LineTotal.Value,
                        TaxType = TaxType.GST,
                        Unit = Unit.NoUnit,
                        InvoiceType = (decimal)im.QTY.Value > 0 ? InvoiceType.Sales : InvoiceType.SalesReturn,
                        BasicAmount = 0,
                        TaxAmount = 0,
                    };
                    si.Unit = (decimal)im.QTY % 1 == 0 ? Unit.Meters : Unit.NoUnit;
                    if (si.Unit == Unit.Meters)
                    {
                        si.BasicAmount = GetBasicAmt(si.Value, Unit.Meters);
                        si.TaxAmount = si.Value - si.BasicAmount;
                    }
                    saleItems.Add(si);
                    xx++;
                }
            }
            catch (Exception ex)
            {
                xx++;
                return null;
            }
            var pis = db.ProductItems.Select(c => new { c.Barcode, c.Unit, c.MRP }).ToList();
            foreach (var im in saleItems)
            {
                var s = pis.Where(c => c.Barcode == im.Barcode).FirstOrDefault();
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
                    if(db.ProductItems.Local.Where(c=>c.Barcode==p.Barcode).Count()==0)
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
            foreach (var im in forP.Where(c => c.PayMode == PayMode.Card))
            {
                CardPaymentDetail cd = new CardPaymentDetail
                {
                    AuthCode = 0,
                    Card = Card.DebitCard,
                    CardLastDigit = -1,
                    CardType = CardType.Rupay,
                    InvoiceNumber = im.InvoiceNumber,
                    PaidAmount = im.PaidAmount,
                    EDCTerminalId = null,

                };
                db.CardPaymentDetails.Add(cd);
            }
            DataTable dt = new DataTable();
            dt.TableName = "SaleReport";
            dt = ToDataTable<SaleItem>(saleItems);
            return CreateExcelfile(dt);

        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static MemoryStream CreateExcelfile(DataTable dt)
        {
            string Period = "Jan-March/2023";
            DateTime SDate = DateTime.Today.Date;
            DateTime EDate = DateTime.Today.Date;

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Disable gridlines in the worksheet
                worksheet.IsGridLinesVisible = false;

                //Enter values to the cells from A3 to A5
                worksheet.Range["D2"].Text = "Aprajita Retails";
                worksheet.Range["D3"].Text = "Bhagalpur Road, Dumka";
                worksheet.Range["D5"].Text = "GSTIN: 20AJHPA7396P";

                worksheet.Range["B7"].Text = "Period";
                worksheet.Range["C7"].Text = Period;

                //Make the text bold
                worksheet.Range["D2:D5"].CellStyle.Font.Bold = true;

                //Merge cells
                worksheet.Range["D9:F9"].Merge();

                //Enter text to the cell D1 and apply formatting
                worksheet.Range["D9"].Text = "GST Sale Report";
                worksheet.Range["D9"].CellStyle.Font.Bold = true;
                worksheet.Range["D9"].CellStyle.Font.RGBColor = Color.FromArgb(42, 118, 189);
                worksheet.Range["D9"].CellStyle.Font.Size = 14;

                //Apply alignment in the cell D1
                worksheet.Range["D9"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                worksheet.Range["D9"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;
                //Enter values to the cells from D5 to E8

                worksheet.Range["D10:e10"].Merge();
                worksheet.Range["F10:G10"].Merge();
                worksheet.Range["I10:J10"].Merge();
                worksheet.Range["D10"].Text = "Sale Date From";
                worksheet.Range["F10"].DateTime = SDate.Date;
                worksheet.Range["H10"].Text = "To";
                worksheet.Range["I10"].DateTime = EDate.Date;

                dt.Columns.Remove("Id");
                dt.Columns.Remove("Adjusted");
                dt.Columns.Remove("FreeQty");
                dt.Columns.Remove("LastPcs");
                dt.Columns.Remove("ProductSale");
                dt.Columns.Remove("ProductItem");

                int rows=  worksheet.ImportDataTable(dt, true, 11, 1, true);
                worksheet.Range[$"A11:P{11+rows}"].CellStyle.Font.Bold = true;
                worksheet.Range[$"A11:P{11 + rows}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range[$"A11:P{11 + rows}"].BorderAround();
                worksheet.Range[$"A11:P{11 + rows}"].BorderInside();
                worksheet.Range[$"A11:P{11 + rows}"].AutofitColumns();

               // int lr = 11 + 2 + rows;
               // worksheet.Range[$"D{lr}"].SubTotal(4,ConsolidationFunction.Sum,) ;

                //Save the document as a stream and retrun the stream.
                MemoryStream stream = new MemoryStream();
                    //Save the created Excel document to MemoryStream
                    workbook.SaveAs(stream);
                    return stream;
                

            }
        }
        public static PayMode PayModeType(string p)
        {

            switch (p.ToLower())
            {
                case "cash": return PayMode.Cash;
                case "card": return PayMode.Card;
                case "upi": return PayMode.UPI;
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


    //public class SaleReportFromExcel
    //{
    //    public static List<T>? JsonToObject<T>(MemoryStream filename)
    //    {
    //        try
    //        {
    //            using StreamReader reader = new StreamReader(filename);
    //            var json = reader.ReadToEnd();
    //            reader.Close();
    //            // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
    //            return JsonSerializer.Deserialize<List<T>>(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            return null;
    //        }
    //    }
    //    public static List<T>? JsonToObject<T>(string json)
    //    {
    //        try
    //        {
    //            // using StreamReader reader = new StreamReader(filename);
    //            //var json = reader.ReadToEnd();
    //            //reader.Close();
    //            // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
    //            return JsonSerializer.Deserialize<List<T>>(json);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            return null;
    //        }
    //    }


    //    private static T GetItem<T>(DataRow dr)
    //    {

    //        Type temp = typeof(T);
    //        T obj = Activator.CreateInstance<T>();

    //        foreach (DataColumn column in dr.Table.Columns)
    //        {
    //            try
    //            {


    //                if (((string)dr[column.ColumnName]) != null || dr[column.ColumnName] != typeof(DBNull))
    //                {
    //                    foreach (PropertyInfo pro in temp.GetProperties())
    //                    {
    //                        if (pro.Name == column.ColumnName)
    //                        {
    //                            switch (column.ColumnName)
    //                            {
    //                                case "Amount":
    //                                case "BillAmount":
    //                                case "Qty":
    //                                case "Quantity":
    //                                case "MRP":
    //                                case "LineTotal":
    //                                case "SaleAmount":
    //                                case "CostPrice":
    //                                case "TaxAmount":
    //                                case "BasicPrice":
    //                                case "RoundOff":
    //                                case "ProfitLoss":

    //                                case "Discount":
    //                                case "DiscountAmount":
    //                                    pro.SetValue(obj, decimal.Parse((string)dr[column.ColumnName]), null);
    //                                    break;
    //                                case "Date":
    //                                case "OnDate":
    //                                    pro.SetValue(obj, DateTime.Parse((string)dr[column.ColumnName]), null);
    //                                    break;
    //                                case "EntryStatus":
    //                                    //case "PayMode":
    //                                    pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
    //                                    break;
    //                                case "IsDue":
    //                                case "ManualBill":
    //                                case "SalesReturn":
    //                                case "TailoringBill":
    //                                case "IsReadOnly":
    //                                case "MarkedDeleted":


    //                                    pro.SetValue(obj, bool.Parse((string)dr[column.ColumnName]), null);
    //                                    break;
    //                                case "EDCTerminalId":
    //                                    pro.SetValue(obj, null, null);
    //                                    break;
    //                                case "SN":
    //                                    pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
    //                                    break;
    //                                case "Customer":
    //                                case "Mobile":
    //                                case "PayMode":
    //                                case "InvoiceNo":
    //                                default:
    //                                    if (!string.IsNullOrEmpty((string)dr[column.ColumnName]))
    //                                        pro.SetValue(obj, (string)dr[column.ColumnName], null);
    //                                    break;
    //                            }

    //                        }
    //                        else
    //                            continue;
    //                    }
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //            }
    //            catch (Exception)
    //            {

    //                continue;
    //            }
    //        }
    //        return obj;

    //    }

    //    private decimal DisAmt(decimal mrp, decimal dis)
    //    {
    //        return mrp * (dis / 100);
    //    }
    //    private static decimal GetBasicAmt(decimal amt, Unit unit)
    //    {
    //        decimal TaxRate = 5;
    //        if (unit != Unit.Meters && amt > 999) TaxRate = 12;
    //        //Need to implement for jacket and other then 12 % option
    //        TaxRate = TaxRate / 100;
    //        var Basic = amt / (1 + TaxRate);
    //        return Basic;
    //    }

    //    // Generate Sale Inv from New Sale
    //    public static MemoryStream GenerateSaleInv(string json, ARDBContext db)
    //    {
    //        var sales = JsonToObject<NewSale>(json);
    //        List<ProductSale> pSale = new List<ProductSale>();
    //        List<SaleItem> saleItems = new List<SaleItem>();
    //        foreach (var im in sales)
    //        {
    //            SaleItem si = new SaleItem
    //            {
    //                Adjusted = false,
    //                Barcode = im.Barcode,
    //                BilledQty = (decimal)im.Qty,
    //                DiscountAmount = (decimal)im.Discount / 100,
    //                FreeQty = 0,
    //                InvoiceNumber = im.InvoiceNo,
    //                LastPcs = false,
    //                Value = (decimal)im.LineTotal,
    //                TaxType = TaxType.GST,
    //                Unit = Unit.NoUnit,
    //                InvoiceType = (decimal)im.Qty > 0 ? InvoiceType.Sales : InvoiceType.SalesReturn,
    //                BasicAmount = 0,
    //                TaxAmount = 0,
    //            };
    //            si.Unit = (decimal)im.Qty % 1 == 0 ? Unit.Meters : Unit.NoUnit;
    //            if (si.Unit == Unit.Meters)
    //            {
    //                si.BasicAmount = GetBasicAmt(si.Value, Unit.Meters);
    //                si.TaxAmount = si.Value - si.BasicAmount;
    //            }
    //            saleItems.Add(si);
    //        }
    //        var pis = db.ProductItems.Select(c => new { c.Barcode, c.Unit, c.MRP }).ToList();
    //        foreach (var im in saleItems)
    //        {
    //            var s = pis.Where(c => c.Barcode == im.Barcode).First();
    //            if (s != null)
    //            {
    //                im.Unit = s.Unit;
    //                im.DiscountAmount = s.MRP * im.DiscountAmount;
    //                if (im.Unit == Unit.Meters)
    //                {
    //                    im.BasicAmount = GetBasicAmt(im.Value, Unit.Meters);
    //                    im.TaxAmount = im.Value - im.BasicAmount;
    //                }
    //            }
    //            else
    //            {
    //                var x = sales.Where(c => c.Barcode == im.Barcode && c.InvoiceNo == im.InvoiceNumber).First();

    //                ProductItem p = new ProductItem
    //                {
    //                    HSNCode = "",
    //                    Description = "",
    //                    BrandCode = "",
    //                    Barcode = im.Barcode,
    //                    MRP = x.MRP.Value,
    //                    Name = "#MISSINGINFO",
    //                    Unit = Unit.NoUnit,
    //                    TaxType = TaxType.GST,
    //                    SubCategory = "",
    //                    StyleCode = "",
    //                    Size = Size.NOTVALID,
    //                    ProductTypeId = "",
    //                    ProductCategory = ProductCategory.Others

    //                };
    //                // Productitem as Reject then confirm when item is added.
    //                im.DiscountAmount = x.MRP.Value * im.DiscountAmount;
    //                if (im.Unit == Unit.Meters)
    //                {
    //                    im.BasicAmount = GetBasicAmt(im.Value, Unit.Meters);
    //                    im.TaxAmount = im.Value - im.BasicAmount;
    //                }
    //                db.ProductItems.Add(p);

    //            }
    //        }

    //        var ins = saleItems.GroupBy(c => c.InvoiceNumber).
    //            Select(c => new ProductSale
    //            {
    //                Adjusted = false,
    //                EntryStatus = EntryStatus.Added,
    //                FreeQty = 0,
    //                InvoiceNo = c.Key,
    //                IsReadOnly = true,
    //                MarkedDeleted = false,
    //                Taxed = true,
    //                StoreId = "ARD",
    //                Paid = true,
    //                Tailoring = false,
    //                UserId = "AutoAdmin",
    //                SalesmanId = "ARD/SM/0001",
    //                OnDate = sales.Where(x => x.InvoiceNo == c.Key).First().Date.Value,
    //                BilledQty = c.Sum(x => x.BilledQty),
    //                TotalBasicAmount = c.Sum(x => x.BasicAmount),
    //                TotalDiscountAmount = c.Sum(x => x.DiscountAmount),
    //                TotalTaxAmount = c.Sum(x => x.TaxAmount),
    //                TotalMRP = c.Sum(x => x.DiscountAmount + x.Value),
    //                InvoiceType = c.Select(x => x.InvoiceType).First(),
    //                TotalPrice = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value,
    //                RoundOff = sales.Where(x => x.InvoiceNo == c.Key).Sum(z => z.BillAmount).Value - c.Sum(x => x.Value)
    //            }).ToList();
    //        var forP = sales.Where(c => string.IsNullOrEmpty(c.PayMode) == false)
    //       .Select(c => new SalePaymentDetail
    //       {
    //           InvoiceNumber = c.InvoiceNo,
    //           PaidAmount = c.BillAmount.Value,
    //           RefId = "Missing",
    //           PayMode = PayModeType(c.PayMode)
    //       }).ToList();
    //        foreach (var im in forP.Where(c => c.PayMode == PayMode.Card))
    //        {
    //            CardPaymentDetail cd = new CardPaymentDetail
    //            {
    //                AuthCode = 0,
    //                Card = Card.DebitCard,
    //                CardLastDigit = -1,
    //                CardType = CardType.Rupay,
    //                InvoiceNumber = im.InvoiceNumber,
    //                PaidAmount = im.PaidAmount,
    //                EDCTerminalId = null,

    //            };
    //            db.CardPaymentDetails.Add(cd);
    //        }
    //        DataTable dt = new DataTable();
    //        dt.TableName = "SaleReport";
    //        dt = ToDataTable<SaleItem>(saleItems);
    //        return CreateExcelfile(dt);

    //    }
    //    public static async Task<MemoryStream> GetSaleReportFromExcelSheetAsync(string path, ARDBContext db)
    //    {
    //        try
    //        {
    //            //var InvInfo = ImportData<NewSaleInfo>(path, "InvoiceList", "O1:U126", false);
    //            var Invsale = ImportData<NewSale>(path, "InvoiceList", "A1:L261", false);

    //            //var JSONFILE = JsonSerializer.Serialize<List<NewSaleInfo>>(InvInfo);
    //            //using StreamWriter writer = new StreamWriter(Path.Combine(path, "Data/InvInfo.json"));
    //            //await writer.WriteAsync(JSONFILE);
    //            //writer.Close();

    //            var JSONFILE = JsonSerializer.Serialize<List<NewSale>>(Invsale);
    //            using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/InvDetail.json"));
    //            await writer1.WriteAsync(JSONFILE);
    //            writer1.Close();

    //            return GenerateSaleInv(JSONFILE, db);
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }
    //    public static List<T>? ImportData<T>(string path, string worksheetName, string rangeI, bool isSchema = false)
    //    {
    //        //Excel import
    //        using (ExcelEngine excelEngine = new ExcelEngine())
    //        {
    //            //Step 2 : Instantiate the excel application object
    //            IApplication application = excelEngine.Excel;
    //            application.DefaultVersion = ExcelVersion.Excel2016;
    //            var filename = Path.Combine(path, @"Data/gstdata.xlsm");
    //            // using StreamReader reader = new StreamReader(filename);
    //            using FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);

    //            //Opening the encrypted Workbook
    //            IWorkbook workbook = application.Workbooks.Open(reader, ExcelParseOptions.Default);
    //            reader.Close();

    //            //Accessing first worksheet in the workbook
    //            IWorksheet worksheet = workbook.Worksheets[worksheetName];
    //            IRange range = worksheet.Range[rangeI];
    //            //Save the document as a stream and return the stream

    //            var dt = worksheet.ExportDataTable(range, ExcelExportDataTableOptions.ColumnNames);

    //            var objList = ConvertDataTable<T>(dt);
    //            return objList;

    //        }
    //    }
    //    private static List<T> ConvertDataTable<T>(DataTable dt)
    //    {
    //        List<T> data = new List<T>();
    //        foreach (DataRow row in dt.Rows)
    //        {
    //            T item = GetItem<T>(row);
    //            data.Add(item);
    //        }
    //        return data;
    //    }


    //}

}