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