using Syncfusion.XlsIO;
using System.Text.Json;
using Path = System.IO.Path;

namespace AprajitaRetails.Server.Importer
{
  

    public class ImportDataHelper
    {

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
        public static Stream WriteExcel<T>(string path, string fn, string worksheetName,   List<T> data,bool isNew = false)
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



    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}