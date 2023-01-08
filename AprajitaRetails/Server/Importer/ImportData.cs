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

        public async Task<bool> JSonToDBAsync<T>(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                reader.Close();
                var listdata= JsonSerializer.Deserialize<List<T>>(json);
                await aRDB.AddRangeAsync(listdata);
                return  await aRDB.SaveChangesAsync()>0;
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
                    if (list != null)
                        await aRDB.AddRangeAsync(list);
                    int a = await aRDB.SaveChangesAsync();
                    return (a > 0);
                case "Employee":
                    var list2 = JsonToObject<Employee>(path);
                    if (list2 != null)
                        await aRDB.AddRangeAsync(list2);
                    int a2 = await aRDB.SaveChangesAsync();
                    return (a2 > 0);
                //return await JSonToDBAsync<Employee>(path);
                case "EmployeeDetails":
                   return await JSonToDBAsync<EmployeeDetails>(path);
                case "BankAccount":
                   return await JSonToDBAsync<BankAccount>(path);
                case "VendorBankAccount":
                   return await JSonToDBAsync<VendorBankAccount>(path);
                case "Party":
                   return await JSonToDBAsync<Party>(path);
                case "LedgerGroup":
                   return await JSonToDBAsync<LedgerGroup>(path);
                case "LedgerMaster":
                   return await JSonToDBAsync<LedgerMaster>(path);
                case "TranscationMode":
                   return await JSonToDBAsync<TransactionMode>(path);
                case "Attendance":
                   return await JSonToDBAsync<Attendance>(path);
                case "MonthlyAttendance":
                   return await JSonToDBAsync<MonthlyAttendance>(path);
                case "Salesman":
                   return await JSonToDBAsync<Salesman>(path);
                case "Customer":
                   return await JSonToDBAsync<Customer>(path);
                case "Contact":
                   return await JSonToDBAsync<Contact>(path);
                case "PettyCashSheet":
                   return await JSonToDBAsync<PettyCashSheet>(path);
                case "Voucher":
                   return await JSonToDBAsync<Voucher>(path);
                case "CashVoucher":
                   return await JSonToDBAsync<CashVoucher>(path);
                case "CashDetail":
                   return await JSonToDBAsync<CashDetail>(path);
                case "TimeSheet":
                   return await JSonToDBAsync<TimeSheet>(path);
                case "Salary":
                   return await JSonToDBAsync<Salary>(path);
                case "PaySlip":
                   return await JSonToDBAsync<PaySlip>(path);
                case "SalaryPayment":
                   return await JSonToDBAsync<SalaryPayment>(path);
                case "StaffAdvanceReceipt":
                   return await JSonToDBAsync<StaffAdvanceReceipt>(path);
                case "BankAccountList":
                   return await JSonToDBAsync<BankAccountList>(path);
                default:
                    return false;
                    break;
            }
        }


    }
}

