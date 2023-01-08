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

        public async Task<bool> ImportTableAsync(string path)
        {
            try
            {
                var tableName = path.Replace(Path.Combine(this.hostingEnv.WebRootPath, "Tables/"), "");
                if (tableName.StartsWith("V1"))
                {
                    tableName = tableName.Replace("V1_", "");
                }
                var className = PluralizationProvider.Singularize(tableName);
                return await AddDataAsync(path, className);
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
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private async Task<bool> Save<T>(List<T> listData)
        {
            try
            {
                if (listData != null)
                   await aRDB.AddRangeAsync(listData);
                int a = await aRDB.SaveChangesAsync();
                return (a > 0);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private async Task<bool> AddDataAsync(string path, string className)
        {
            switch (className)
            {
                case "Store": return false; break;
                case "Bank":
                    var list = JsonToObject<Bank>(path);
                    return await Save<Bank>(list);
                case "Employee":
                    return await Save(JsonToObject<Employee>(path));
                case "EmployeeDetails":
                    return await Save(JsonToObject<EmployeeDetails>(path));
                case "BankAccount":
                    return await Save(JsonToObject<BankAccount>(path));
                case "VendorBankAccount":
                    return await Save(JsonToObject<VendorBankAccount>(path));
                case "Party":
                    return await Save(JsonToObject<Party>(path));
                case "LedgerGroup":
                    return await Save(JsonToObject<LedgerGroup>(path));
                case "LedgerMaster":
                    return await Save(JsonToObject<LedgerMaster>(path));
                case "TranscationMode":
                    return await Save(JsonToObject<TransactionMode>(path));
                case "Attendance":
                    return await Save(JsonToObject<Attendance>(path));
                case "MonthlyAttendance":
                    return await Save(JsonToObject<MonthlyAttendance>(path));
                case "Salesman":
                    return await Save(JsonToObject<Salesman>(path));
                case "Customer":
                    return await Save(JsonToObject<Customer>(path));
                case "Contact":
                    return await Save(JsonToObject<Contact>(path));
                case "PettyCashSheet":
                    return await Save(JsonToObject<PettyCashSheet>(path));
                case "Voucher":
                    return await Save(JsonToObject<Voucher>(path));
                case "CashVoucher":
                    return await Save(JsonToObject<CashVoucher>(path));
                case "CashDetail":
                    return await Save(JsonToObject<CashDetail>(path));
                case "TimeSheet":
                    return await Save(JsonToObject<TimeSheet>(path));
                case "Salary":
                    return await Save(JsonToObject<Salary>(path));
                case "PaySlip":
                    return await Save(JsonToObject<PaySlip>(path));
                case "SalaryPayment":
                    return await Save(JsonToObject<SalaryPayment>(path));
                case "StaffAdvanceReceipt":
                    return await Save(JsonToObject<StaffAdvanceReceipt>(path));
                case "BankAccountList":
                    return await Save(JsonToObject<BankAccountList>(path));
                default:
                    return false;
                    break;
            }
        }


    }
}

