﻿using System.IO;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("[controller]")]
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
        public async Task<ActionResult> GetSaleRepAsync(string storeid="ARD", int year=2023, int month=3)
        {
            var dataFile = SaleReport.GenerateSaleReport(aRDB, storeid, month,year);
            dataFile.Position = 0;
            return File(dataFile, "application/ms-excel", "SaleReport.xlsx");
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