using System;
using System.IO;
using System.Reflection;
using AprajitaRetails.Shared.ViewModels;
using AprajitaRetails.Shared.Models;
using AprajitaRetails.Shared.Models.Auth;
using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;


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
            files = files.OrderBy(c => c.FileName).ToList(); ;
            return files;
        }

        public bool ImportTable(string path)
        {
            try
            {
                var tableName = path.Replace(Path.Combine(this.hostingEnv.WebRootPath, "Tables/"), "");
                if (tableName.StartsWith("V1"))
                {
                    tableName = tableName.Replace("V1_", "");
                }
                var className = PluralizationProvider.Singularize(tableName);
                //var t = Type.GetType(className.ToString());

                //var val = Type.GetType(className);
                //var listdata = JsonToObject(path, val);

                //if (listdata != null)
                //    aRDB.AddRange(listdata);
                //return aRDB.SaveChanges() > 0;
                return AddData(path, className);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static List<T>? JsonToObject<T>(string filename, T v)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static List<T>? JsonToObject<T>(string filename)
        {
            using StreamReader reader = new StreamReader(filename);
            var json = reader.ReadToEnd();
            reader.Close();
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        private bool AddData(string path, string className)
        {
            switch (className)
            {
                case "Store": return false; break;
                case "Bank":
                    var list = JsonToObject<Bank>(path);
                    if (list != null)
                        aRDB.AddRange(list);
                    int a = aRDB.SaveChanges();
                    return a > 0;
                    break;
                default:
                    return false;
                    break;
            }
        }


    }
}

