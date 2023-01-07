using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ImportHelperController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpGet]
        public async Task<ActionResult<List<FileModel>>> GetFiles()
        {
            return new ImportData(hostingEnv).ListFiles();

        }
    }
}

