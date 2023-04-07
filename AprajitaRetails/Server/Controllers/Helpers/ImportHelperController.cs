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