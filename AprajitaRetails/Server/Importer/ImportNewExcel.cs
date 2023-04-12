using AprajitaRetails.Server.Data;
using Syncfusion.XlsIO;
using System.Data;
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
    {   //[Key]
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
        // [Key]
        public int? SN { set; get; }

        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }

        public string? Barcode { get; set; }

        public decimal? MRP { get; set; }
        public decimal? Quantity { get; set; }

        public decimal? Discount { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? BillAmount { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? DiscountAmount { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? ProfitLoss { get; set; }
    }

    public class ImportNewExcel
    {
        public static async Task<bool> GetSaleReportFromExcelSheetAsync(string path, ARDBContext db)
        {
            try
            {
                var Invsale = ImportExcel.ImportData<NewSale>(path, "InvoiceList", "A1:L287", false);
                var JSONFILE = JsonSerializer.Serialize<List<NewSale>>(Invsale);
                using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/InvDetails.json"));
                await writer1.WriteAsync(JSONFILE);
                writer1.Close();
                return SaleReport.GenerateSaleInv(JSONFILE, db);
            }
            catch (Exception ex)
            {
                return false;
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

                var InvInfo = ImportExcel.ImportData<NewSaleInfo>(path, "InvoiceList", "O1:U126", false);
                var Invsale = ImportExcel.ImportData<NewSale>(path, "InvoiceList", "A1:L261", false);
                var InvProfit = ImportExcel.ImportData<NewProfitLoss>(path, "ProfitLoss", "A1:N547", false);
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