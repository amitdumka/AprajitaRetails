using Syncfusion.XlsIO;

namespace AprajitaRetails.Server.Importer
{
    public class ImportExcel
    {
        public static List<T>? ImportData<T>(string path, string worksheetName, string rangeI, bool isSchema = false)
        {
            //Excel import
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                var filename = Path.Combine(path, @"Data/SaleData2023.xlsm");
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

                var objList =DocIO.ConvertDataTable<T>(dt);
                return objList;

            }
        }

    }

}