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
using System.Collections;

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

        private bool Save<T>(List<T>? listData)
        {
            if (listData != null)
                aRDB.AddRange(listData);
            return aRDB.SaveChanges() > 0;
        }
        private bool AddData(string path, string className)
        {
            switch (className)
            {
                case "Store": return false; break;
                case "Bank":
                    var list = JsonToObject<Bank>(path);
                    return Save<Bank>(list);
                case "Employee":
                    return Save(JsonToObject<Employee>(path));
                case "EmployeeDetails":
                    return Save(JsonToObject<EmployeeDetails>(path));
                case "BankAccount":
                    return Save(JsonToObject<BankAccount>(path));
                case "VendorBankAccount":
                    return Save(JsonToObject<VendorBankAccount>(path));
                case "Party":
                    return Save(JsonToObject<Party>(path));
                case "LedgerGroup":
                    return Save(JsonToObject<LedgerGroup>(path));
                case "LedgerMaster":
                    return Save(JsonToObject<LedgerMaster>(path));
                case "TranscationMode":
                    return Save(JsonToObject<TransactionMode>(path));
                case "Attendance":
                    return Save(JsonToObject<Attendance>(path));
                case "MonthlyAttendance":
                    return Save(JsonToObject<MonthlyAttendance>(path));
                case "Salesman":
                    return Save(JsonToObject<Salesman>(path));
                case "Customer":
                    return Save(JsonToObject<Customer>(path));
                case "Contact":
                    return Save(JsonToObject<Contact>(path));
                case "PettyCashSheet":
                    return Save(JsonToObject<PettyCashSheet>(path));
                case "Voucher":
                    return Save(JsonToObject<Voucher>(path));
                case "CashVoucher":
                    return Save(JsonToObject<CashVoucher>(path));
                case "CashDetail":
                    return Save(JsonToObject<CashDetail>(path));
                case "TimeSheet":
                    return Save(JsonToObject<TimeSheet>(path));
                case "Salary":
                    return Save(JsonToObject<Salary>(path));
                case "PaySlip":
                    return Save(JsonToObject<PaySlip>(path));
                case "SalaryPayment":
                    return Save(JsonToObject<SalaryPayment>(path));
                case "StaffAdvanceReceipt":
                    return Save(JsonToObject<StaffAdvanceReceipt>(path));
                case "BankAccountList":
                    return Save(JsonToObject<BankAccountList>(path));
                default:
                    return false;
                    break;
            }
        }


    }
}

