using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Server.Importer;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("[controller]")]
    [ApiController]
    public class ImportHelperController : ControllerBase
    {
        private IHostingEnvironment hostingEnv;
        private ARDBContext aRDB;
        public ImportHelperController(IHostingEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env;
            aRDB = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<FileModel>>> GetFiles()
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

