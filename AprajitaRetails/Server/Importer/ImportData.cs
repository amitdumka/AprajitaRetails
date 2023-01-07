using System;
using System.IO;
using System.Reflection;
using AprajitaRetails.Shared.ViewModels;
using System.Text.Json;
using AprajitaRetails.Server.Data;
using PluralizeService.Core;
using System.Collections.Generic;

namespace AprajitaRetails.Server.Importer
{

    public class ImportData
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv;
        private ARDBContext aRDB;
        public ImportData(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env; aRDB = db;
        }
        public List<FileModel> ListFiles()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(this.hostingEnv.WebRootPath, "Tables/"));
            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { Path = filePath, FileName = Path.GetFileName(filePath) });
            }
            return files;
        }

        public void ImportTable(string path)
        {

            var tableName = path.Replace(Path.Combine(this.hostingEnv.WebRootPath, "Tables/"), "");
            if (tableName.StartsWith("V1")) { tableName.Replace("V1_", ""); }
            var className = PluralizationProvider.Singularize(path);
            var jsonData = ReadJsonFile(path);
        }
        public string ReadJsonFile(string path)
        {
            //var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var filePath = Path.Combine(buildDir, filepath);
            return System.IO.File.ReadAllText(path);
        }





    }
}

