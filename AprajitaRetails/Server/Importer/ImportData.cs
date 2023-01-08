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

        

        private async Task<bool> AddDataAsync(string path, string className)
        {
            switch (className)
            {
                case "Store":
                    await aRDB.AddRangeAsync(JsonToObject<Store>(path));
                    return await aRDB.SaveChangesAsync() > 0;
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
                    return await aRDB.SaveChangesAsync()>0;
                //return await JSonToDBAsync<Employee>(path));  break;
                case "EmployeeDetail":
                  await aRDB.AddRangeAsync(JsonToObject<EmployeeDetails>(path));  break;
                case "BankAccount":
                  await aRDB.AddRangeAsync(JsonToObject<BankAccount>(path));  break;
                case "VendorBankAccount":
                  await aRDB.AddRangeAsync(JsonToObject<VendorBankAccount>(path));  break;
                case "Party":
                  await aRDB.AddRangeAsync(JsonToObject<Party>(path));  break;
                case "LedgerGroup":
                  await aRDB.AddRangeAsync(JsonToObject<LedgerGroup>(path));  break;
                case "LedgerMaster":
                  await aRDB.AddRangeAsync(JsonToObject<LedgerMaster>(path));  break;
                case "TranscationMode":
                  await aRDB.AddRangeAsync(JsonToObject<TransactionMode>(path));  break;
                case "Attendance":
                  await aRDB.AddRangeAsync(JsonToObject<Attendance>(path));  break;
                case "MonthlyAttendance":
                  await aRDB.AddRangeAsync(JsonToObject<MonthlyAttendance>(path));  break;
                case "Salesman":
                  await aRDB.AddRangeAsync(JsonToObject<Salesman>(path));  break;
                case "Customer":
                  await aRDB.AddRangeAsync(JsonToObject<Customer>(path));  break;
                case "Contact":
                  await aRDB.AddRangeAsync(JsonToObject<Contact>(path));  break;
                case "PettyCashSheet":
                  await aRDB.AddRangeAsync(JsonToObject<PettyCashSheet>(path));  break;
                case "Voucher":
                  await aRDB.AddRangeAsync(JsonToObject<Voucher>(path));  break;
                case "CashVoucher":
                  await aRDB.AddRangeAsync(JsonToObject<CashVoucher>(path));  break;
                case "CashDetail":
                  await aRDB.AddRangeAsync(JsonToObject<CashDetail>(path));  break;
                case "TimeSheet":
                  await aRDB.AddRangeAsync(JsonToObject<TimeSheet>(path));  break;
                case "Salary":
                  await aRDB.AddRangeAsync(JsonToObject<Salary>(path));  break;
                case "PaySlip":
                  await aRDB.AddRangeAsync(JsonToObject<PaySlip>(path));  break;
                case "SalaryPayment":
                  await aRDB.AddRangeAsync(JsonToObject<SalaryPayment>(path));  break;
                case "StaffAdvanceReceipt":
                  await aRDB.AddRangeAsync(JsonToObject<StaffAdvanceReceipt>(path));  break;
                case "BankAccountList":
                  await aRDB.AddRangeAsync(JsonToObject<BankAccountList>(path));  break;
                default:
                    return false;
                    break;
            }
            return await aRDB.SaveChangesAsync() > 0;
        }


    }
}

