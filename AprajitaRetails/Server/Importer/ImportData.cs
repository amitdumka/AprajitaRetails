using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
using PluralizeService.Core;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{
    public class ImportData
    {
        private IWebHostEnvironment hostingEnv;
        private ARDBContext aRDB;

        public ImportData(IWebHostEnvironment env, ARDBContext db)
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
                var flag = await RemoveDataAsync(className);
                //if (!flag) return false;
                //return true;
                return await AddDataAsync(path, className);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<bool> RemoveDataAsync(string className)
        {
            try
            {
                switch (className)
                {
                    case "Store":
                        aRDB.Stores.RemoveRange(aRDB.Stores.ToList()); break;
                    case "Bank":
                        aRDB.Banks.RemoveRange(aRDB.Banks.ToList()); break;

                    case "Employee": aRDB.Employees.RemoveRange(aRDB.Employees.ToList()); break;
                    case "EmployeeDetail": aRDB.EmployeeDetails.RemoveRange(aRDB.EmployeeDetails.ToList()); break;
                    case "BankAccount": aRDB.BankAccounts.RemoveRange(aRDB.BankAccounts.ToList()); break;
                    case "VendorBankAccount": aRDB.VendorBankAccounts.RemoveRange(aRDB.VendorBankAccounts.ToList()); break;
                    case "Party": aRDB.Parties.RemoveRange(aRDB.Parties.ToList()); break;
                    case "LedgerGroup": aRDB.LedgerGroups.RemoveRange(aRDB.LedgerGroups.ToList()); break;
                    case "LedgerMaster": aRDB.LedgerMasters.RemoveRange(aRDB.LedgerMasters.ToList()); break;
                    case "TranscationMode": aRDB.TransactionModes.RemoveRange(aRDB.TransactionModes.ToList()); break;
                    case "Attendance": aRDB.Attendances.RemoveRange(aRDB.Attendances.ToList()); break;
                    case "MonthlyAttendance": aRDB.MonthlyAttendances.RemoveRange(aRDB.MonthlyAttendances.ToList()); break;
                    case "Salesman": aRDB.Salesmen.RemoveRange(aRDB.Salesmen.ToList()); break;
                    case "Customer": aRDB.Customers.RemoveRange(aRDB.Customers.ToList()); break;
                    case "Contact": aRDB.Contacts.RemoveRange(aRDB.Contacts.ToList()); break;
                    case "PettyCashSheet": aRDB.PettyCashSheets.RemoveRange(aRDB.PettyCashSheets.ToList()); break;
                    case "Voucher": aRDB.Vouchers.RemoveRange(aRDB.Vouchers.ToList()); break;
                    case "CashVoucher": aRDB.CashVouchers.RemoveRange(aRDB.CashVouchers.ToList()); break;
                    case "CashDetail": aRDB.CashDetails.RemoveRange(aRDB.CashDetails.ToList()); break;
                    case "TimeSheet": aRDB.TimeSheets.RemoveRange(aRDB.TimeSheets.ToList()); break;
                    case "Salary": aRDB.Salaries.RemoveRange(aRDB.Salaries.ToList()); break;
                    case "PaySlip": aRDB.PaySlips.RemoveRange(aRDB.PaySlips.ToList()); break;
                    case "SalaryPayment": aRDB.SalaryPayments.RemoveRange(aRDB.SalaryPayments.ToList()); break;
                    case "StaffAdvanceReceipt": aRDB.StaffAdvanceReceipts.RemoveRange(aRDB.StaffAdvanceReceipts.ToList()); break;
                    case "BankAccountList": aRDB.AccountLists.RemoveRange(aRDB.AccountLists.ToList()); break;
                    default:
                        return false;
                }
                return await aRDB.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private async Task<bool> AddDataAsync(string path, string className)
        {
            try
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
                        return await aRDB.SaveChangesAsync() > 0;
                    //return await JSonToDBAsync<Employee>(path));  break;
                    case "EmployeeDetail":
                        await aRDB.AddRangeAsync(JsonToObject<EmployeeDetails>(path)); break;
                    case "BankAccount":
                        await aRDB.AddRangeAsync(JsonToObject<BankAccount>(path)); break;
                    case "VendorBankAccount":
                        await aRDB.AddRangeAsync(JsonToObject<VendorBankAccount>(path)); break;
                    case "Party":
                        await aRDB.AddRangeAsync(JsonToObject<Party>(path)); break;
                    case "LedgerGroup":
                        await aRDB.AddRangeAsync(JsonToObject<LedgerGroup>(path)); break;
                    case "LedgerMaster":
                        await aRDB.AddRangeAsync(JsonToObject<LedgerMaster>(path)); break;
                    case "TranscationMode":
                        await aRDB.AddRangeAsync(JsonToObject<TransactionMode>(path)); break;
                    case "Attendance":
                        await aRDB.AddRangeAsync(JsonToObject<Attendance>(path)); break;
                    case "MonthlyAttendance":
                        await aRDB.AddRangeAsync(JsonToObject<MonthlyAttendance>(path)); break;
                    case "Salesman":
                        await aRDB.AddRangeAsync(JsonToObject<Salesman>(path)); break;
                    case "Customer":
                        await aRDB.AddRangeAsync(JsonToObject<Customer>(path)); break;
                    case "Contact":
                        await aRDB.AddRangeAsync(JsonToObject<Contact>(path)); break;
                    case "PettyCashSheet":
                        await aRDB.AddRangeAsync(JsonToObject<PettyCashSheet>(path)); break;
                    case "Voucher":
                        await aRDB.AddRangeAsync(JsonToObject<Voucher>(path)); break;
                    case "CashVoucher":
                        await aRDB.AddRangeAsync(JsonToObject<CashVoucher>(path)); break;
                    case "CashDetail":
                        await aRDB.AddRangeAsync(JsonToObject<CashDetail>(path)); break;
                    case "TimeSheet":
                        await aRDB.AddRangeAsync(JsonToObject<TimeSheet>(path)); break;
                    case "Salary":
                        await aRDB.AddRangeAsync(JsonToObject<Salary>(path)); break;
                    case "PaySlip":
                        await aRDB.AddRangeAsync(JsonToObject<PaySlip>(path)); break;
                    case "SalaryPayment":
                        await aRDB.AddRangeAsync(JsonToObject<SalaryPayment>(path)); break;
                    case "StaffAdvanceReceipt":
                        await aRDB.AddRangeAsync(JsonToObject<StaffAdvanceReceipt>(path)); break;
                    case "BankAccountList":
                        await aRDB.AddRangeAsync(JsonToObject<BankAccountList>(path)); break;
                    case "DailySale":
                        await aRDB.AddRangeAsync(JsonToObject<DailySale>(path)); break;
                    case "EDCMachine":
                        await aRDB.AddRangeAsync(JsonToObject<EDCTerminal>(path)); break;
                    case "CustomerDue":
                        await aRDB.AddRangeAsync(JsonToObject<CustomerDue>(path)); break;
                    case "DueRecovery":
                        await aRDB.AddRangeAsync(JsonToObject<DueRecovery>(path)); break;
                    default:
                        return false;
                }
                return await aRDB.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}