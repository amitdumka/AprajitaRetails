using System.IO;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.Constants;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportHelperController : ControllerBase
    {
        private IWebHostEnvironment hostingEnv;
        private ARDBContext aRDB;

        public ImportHelperController(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env;
            aRDB = db;
        }
        //TODO: this is only for test remove this from prod.
        [HttpGet("purchaseimport")]
        public async Task<ActionResult<string>> GetPurchaseImport(string sc)
        {
            var sg= aRDB.Stores.Find(sc).StoreGroupId ?? "";
            var imp = new ExcelToDB(aRDB, sc,sg);

            // Need to import excel and convert to json file and store in server 
            ExcelFile ef=null;

            if (sc == "ARD")
            {
                ef = AKSConstant.Dumka;
            }else if(sc == "ARJ")
            {
                ef = AKSConstant.Jamshedpur;
            }else ef= AKSConstant.Dumka;


            var fileanme = await imp.ImportPurchaseInvoiceAsync( Path.Combine(hostingEnv.WebRootPath, "Data","ImportData"), "TheArvindStorePurchaseData.xlsx", ef.SheetName,ef.Range, ef.StoreCode, sg, true);
            return fileanme;
        }

        [HttpGet("JsonDataFromFile")]
        public async Task<ActionResult<string>> GetPurchaseImorptedTempData(string filename)
        {
            return ImportDataHelper.ReadJsonFile(filename);
        }



        [HttpGet("StockUpdate")]
        public async Task<ActionResult<bool>> GetStiockUpdate(string storeid="ARD")
        {
            var im = new ImportData(hostingEnv, aRDB);
            StockImporter stockImporter = new StockImporter(hostingEnv, aRDB, storeid);
            return await stockImporter.StockUpdate();
        }

        [HttpGet("Newsale")]
        public async Task<ActionResult<bool>> GetNewSale()
        {
            var im = await ImportNewExcel.NewData(hostingEnv.WebRootPath, aRDB);
            // StockImporter stockImporter = new StockImporter(hostingEnv, aRDB, storeid);
            return im;
        }

        [HttpGet("NewSaleAdd")]
        public async Task<ActionResult<bool>> GetNewSaleAddAsync()
        {
            return await ImportNewExcel.GetSaleReportFromExcelSheetAsync(hostingEnv.WebRootPath, aRDB);
        }

        [HttpGet("SaleRP")]
        public async Task<ActionResult> GetSaleRepAsync(string storeid="ARD", int year=2023, int month=3, bool pl=false)
        {
            if (pl)
            {
                var dataFile = SaleReport.GenerateProfitLossReport(aRDB, storeid, month, year);
                dataFile.Position = 0;
                return File(dataFile, "application/ms-excel", "SaleReportPL.xlsx");
            }
            else
            {
                var dataFile = SaleReport.GenerateSaleReport(aRDB, storeid, month, year);
                dataFile.Position = 0;
                return File(dataFile, "application/ms-excel", "SaleReport.xlsx");
            }
        }

        [HttpGet]
        public ActionResult<List<FileModel>> GetFiles()
        {
            return new ImportData(hostingEnv, aRDB).ListFiles();
        }

        [HttpGet("Add")]
        public async Task<ActionResult<bool>> GetAddTable(string path)
        {
            var im = new ImportData(hostingEnv, aRDB);
            return await im.ImportTableAsync(path);
        }
    }
}