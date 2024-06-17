using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using AprajitaRetails.Importer;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.Constants;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.ViewModels;
using AprajitaRetails.Shared.ViewModels.Imports;

using Microsoft.AspNetCore.Routing.Constraints;
using AprajitaRetails.Server.BL.Imports;
namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportsController : ControllerBase
    {
        private IWebHostEnvironment hostingEnv;
        private ARDBContext aRDB;

        public ImportsController(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env;
            aRDB = db;
        }
        // GET: ImportsController
        public ActionResult Index()
        {
            return Ok("Feature not implemented");
        }

        [HttpPost("PurchaseImport")]
        public async Task<ActionResult<bool>> PostImportPurchaseData(string storeid, string filename, string sheetName, string range)
        {
            PurchaseImport import = new PurchaseImport(aRDB);

            return await import.ImportPurchaseAsync(storeid, filename, sheetName, range);

        }
        [HttpPost("PurchaseUpload")]
        public async Task<ActionResult<bool>> PostImportPurchaseData(PurchaseUploadVM upload)
        {
              PurchaseImport pi = new PurchaseImport(aRDB);
            return await pi.ImportPurchaseAsync(upload.StoreId, upload.PurchaseData);
        }


    }
}
