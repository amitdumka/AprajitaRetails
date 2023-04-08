using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
using Newtonsoft.Json.Linq;
using PluralizeService.Core;
using Syncfusion.XlsIO;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace AprajitaRetails.Server.Importer
{

    //SN	Date	InvoiceNo	Customer 	Mobile	PayMode	BillAmount
    public class NewSaleInfo
    {
       // [Key]
        public int? SN { set; get; }
        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }
        public decimal? BillAmount { get; set; }
        public string? PayMode { get; set; }
    }
    public class NewSale
    {//SN	Date	Invoice No	Customer	Mobile	Barcode	MRP	QTY	Discount	LineTotal	BillAmount	PayMode
        //[Key]
        public int? SN   { set; get; }

        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Customer { get; set; }
        public string? Mobile { get; set; }
        public string? Barcode { get; set; }
        public decimal? MRP { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Discount { get; set; }
        public decimal? LineTotal { get; set; }
        public decimal? BillAmount { get; set; }
        public string? PayMode { get; set; }
    }

    public class NewProfitLoss //: NewSale
    {
        //Date	InvoiceNo	Barcode	Quantity	MRP	CostPrice	
        //Discount %	DiscountAmount	BasicPrice	TaxAmount	SalePrice	RoundOff	BilAmount	Profit/Loss
       // [Key]
        public int ?SN { set; get; }
        public DateTime? Date { get; set; }
        public string? InvoiceNo { get; set; }
        //public string? Customer { get; set; }
        //public string? Mobile { get; set; }
        public string? Barcode { get; set; }
        public decimal? MRP { get; set; }
        public decimal? Quantity { get; set; }

        public decimal? Discount { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? BillAmount { get; set; }
        //public string? PayMode { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? BasicPrice { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? RoundOff { get; set; }
        public decimal? ProfitLoss { get; set; }
    }

    public class ImportNewExcel
    {
        public static List<T>? JsonToObject<T>(MemoryStream filename)
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
        public static List<T>? JsonToObject<T>(string  json)
        {
            try
            {
               // using StreamReader reader = new StreamReader(filename);
                //var json = reader.ReadToEnd();
                //reader.Close();
                // JsonSerializerOptions options = new CustomJsonConverterForNullableDateTime();
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static async Task<bool> NewData(string path, ARDBContext db)
        {

            // var data = ImportData(path, "InvoiceList", "O1:U127", false);
            // var data2 = ImportData(path, "InvoiceList", "A1:L274", false);
            // var data3 = ImportData(path, "PofitLoss", "A1:N564", false);
            try
            {

            
          // var InvInfo = JsonToObject<NewSaleInfo>(ImportData(path, "InvoiceList", "O1:U127", false));
           //var Invsale = JsonToObject<NewSaleInfo>(ImportData(path, "InvoiceList", "A1:L274", false));
           //var InvProfit = JsonToObject<NewSaleInfo>(ImportData(path, "PofitLoss", "A1:N564", false));

                var InvInfo = ImportData<NewSaleInfo>(path, "InvoiceList", "O1:U127", false);
                var Invsale =  ImportData<NewSale>(path, "InvoiceList", "A1:L274", false);
                var InvProfit =  ImportData<NewProfitLoss>(path, "PofitLoss", "A1:N564", false);


                // InvList present in invinfo and sale

                var invs = InvInfo.Select(c => c.InvoiceNo).ToList();

           var x = InvInfo.Select(c => c.InvoiceNo).Except(Invsale.Select(c => c.InvoiceNo).Distinct()).ToList();
           var invs2 = Invsale.Select(c => c.InvoiceNo).Distinct().Except(invs).ToList();
           var miss = InvInfo.Select(c => c.InvoiceNo).Except(InvProfit.Select(c => c.InvoiceNo).Distinct().ToList()).ToList();

            var JSONFILE = JsonSerializer.Serialize<List<string>>(x);
            using StreamWriter writer = new StreamWriter(Path.Combine(path, "Data/invsale.json"));
            await writer.WriteAsync(JSONFILE);
            writer.Close();

            JSONFILE = JsonSerializer.Serialize<List<string>>(invs2);
            using StreamWriter writer2 = new StreamWriter(Path.Combine(path, "Data/inv2.json"));
            await writer2.WriteAsync(JSONFILE);
            writer.Close();

            JSONFILE = JsonSerializer.Serialize<List<string>>(miss);
            using StreamWriter writer1 = new StreamWriter(Path.Combine(path, "Data/miss.json"));
            await writer1.WriteAsync(JSONFILE);
            writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //private IWebHostEnvironment hostingEnv;
        public static List<T>? ImportData<T>(string path, string worksheetName, string rangeI, bool isSchema = false)
        {
            //Excel import
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                var filename = Path.Combine(path, @"Data/gstdata.xlsm");
               // using StreamReader reader = new StreamReader(filename);
                using FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);

                //Opening the encrypted Workbook
                IWorkbook workbook = application.Workbooks.Open(reader, ExcelParseOptions.Default);
                reader.Close();

                //Accessing first worksheet in the workbook
                IWorksheet worksheet = workbook.Worksheets[worksheetName];
                IRange range = worksheet.Range[rangeI];
                //Save the document as a stream and return the stream

               var dt= worksheet.ExportDataTable(range, ExcelExportDataTableOptions.ColumnNames);

                var objList = ConvertDataTable<T>(dt);
                return objList;
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    //Save the created Excel document to MemoryStream
                //    //if (option == "Workbook")
                //    //    workbook.SaveAsJson(stream, isSchema);
                //    //else if (option == "Worksheet")
                //    //    workbook.SaveAsJson(stream, worksheet, isSchema);
                //    //else if (option == "Range")
                //    //    workbook.SaveAsJson(stream, range, isSchema);
                //    workbook.SaveAsJson(stream, range, true);
                //    byte[] json = new byte[stream.Length];
                //    stream.Position = 0;
                //    stream.Read(json, 0, (int)stream.Length);
                //    string jsonString = Encoding.UTF8.GetString(json);
                //    stream.Position = 0;
                //    JObject j = JObject.Parse(jsonString);
                //    var jstr = j[worksheetName].ToString();
                //  var x4=  JsonSerializer.Serialize(jstr);
                //    //var tx = j[worksheetName].ToObject<List<T>>();
                //   // return tx;
                //     return JsonToObject<T>(x4);
                //}
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                if(dr[column.ColumnName] !=null)
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        switch (column.ColumnName)
                        {
                            case "Amount":
                            case "BillAmount":
                            case "Qty":
                            case "Quantity":
                            case "MRP":
                            case "LineTotal":
                            case "SaleAmount":
                            case "CostPrice":
                            case "TaxAmount":
                            case "BasicPrice":
                            case "RoundOff":
                            case "ProfitLoss":

                            case "Discount":
                            case "DiscountAmount":
                                pro.SetValue(obj, decimal.Parse((string)dr[column.ColumnName]), null);
                                break;
                            case "Date":
                            case "OnDate":
                                pro.SetValue(obj, DateTime.Parse((string)dr[column.ColumnName]), null);
                                break;
                            case "EntryStatus":
                            //case "PayMode":
                                pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                break;
                            case "IsDue":
                            case "ManualBill":
                            case "SalesReturn":
                            case "TailoringBill":
                            case "IsReadOnly":
                            case "MarkedDeleted":


                                pro.SetValue(obj, bool.Parse((string)dr[column.ColumnName]), null);
                                break;
                            case "EDCTerminalId":
                                pro.SetValue(obj, null, null);
                                break;
                            case "SN":
                                pro.SetValue(obj, int.Parse((string)dr[column.ColumnName]), null);
                                break;
                            default:
                                if (dr[column.ColumnName] != null)
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                                break;
                        }

                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }

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
                    case "Tax":
                        aRDB.Taxes.RemoveRange(aRDB.Taxes.ToList()); break;
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
                    case "ProductType": aRDB.ProductTypes.RemoveRange(aRDB.ProductTypes.ToList()); break;
                    case "Product": aRDB.ProductItems.RemoveRange(aRDB.ProductItems.ToList()); break;
                    case "Brand": aRDB.Brands.RemoveRange(aRDB.Brands.ToList()); break;
                    case "Stock": aRDB.Stocks.RemoveRange(aRDB.Stocks.ToList()); break;
                    case "ProductSubCategory": aRDB.ProductSubCategories.RemoveRange(aRDB.ProductSubCategories.ToList()); break;
                    case "PurchaseItem": aRDB.PurchaseItems.RemoveRange(aRDB.PurchaseItems.ToList()); break;
                    case "PurchaseProduct": aRDB.ProductPurchases.RemoveRange(aRDB.ProductPurchases.ToList()); break;
                    case "Vendor": aRDB.Vendors.RemoveRange(aRDB.Vendors.ToList()); break;
                    case "SaleItem": aRDB.SaleItems.RemoveRange(aRDB.SaleItems.ToList()); break;
                    case "ProductSale": aRDB.ProductSales.RemoveRange(aRDB.ProductSales.ToList()); break;
                    case "SalaryLedger": aRDB.SalaryLedgers.RemoveRange(aRDB.SalaryLedgers.ToList()); break;

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
                    case "Tax":
                        await aRDB.AddRangeAsync(JsonToObject<Tax>(path));
                        return await aRDB.SaveChangesAsync() > 0;

                    case "SalaryLedger":
                        await aRDB.AddRangeAsync(JsonToObject<SalaryLedger>(path));
                        return await aRDB.SaveChangesAsync() > 0;

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
                        var data = JsonToObject<PettyCashSheet>(path);
                        foreach (var item in data)
                        {
                            item.UserId = "AutoID";
                            item.EntryStatus = EntryStatus.Added;
                            item.IsReadOnly = true;
                            item.MarkedDeleted = false;
                            item.StoreId = "ARD";
                        }
                        await aRDB.AddRangeAsync(data); break;
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
                    case "ProductType": await aRDB.AddRangeAsync(JsonToObject<ProductType>(path)); break;
                    case "ProductSubCategory": await aRDB.AddRangeAsync(JsonToObject<ProductSubCategory>(path)); break;
                    case "Product": await aRDB.AddRangeAsync(JsonToObject<ProductItem>(path)); break;
                    case "Brand": await aRDB.AddRangeAsync(JsonToObject<Brand>(path)); break;
                    case "Stock":
                        var stocks = JsonToObject<Stock>(path);

                        await aRDB.AddRangeAsync(stocks);
                        break;

                    default:
                        return false;

                    case "PurchaseItem":
                        var items = JsonToObject<PurchaseItem>(path)
                            .Select(c => new PurchaseItem
                            {
                                Id = 0,
                                Barcode = c.Barcode,
                                CostPrice = c.CostPrice,
                                CostValue = c.CostValue,
                                DiscountValue = c.DiscountValue,
                                FreeQty = c.FreeQty,
                                InwardNumber = c.InwardNumber,
                                Qty = c.Qty,
                                TaxAmount = c.TaxAmount,
                                Unit = c.Unit,
                            });
                        // foreach (var item in items)
                        //{
                        //    item.Id = 0;
                        //}
                        await aRDB.AddRangeAsync(items); break;
                    case "PurchaseProduct": await aRDB.AddRangeAsync(JsonToObject<ProductPurchase>(path)); break;
                    case "Vendor": await aRDB.AddRangeAsync(JsonToObject<Vendor>(path)); break;
                    case "SaleItem":
                        var sItems = JsonToObject<SaleItem>(path);
                        var npath = path.Replace(className, "ProductSale");
                        var psl = JsonToObject<PSale>(npath);
                        foreach (var item in sItems)
                        {
                            item.Id = 0;
                            item.InvoiceNumber = psl.Where(c => c.InvoiceCode == item.InvoiceNumber).FirstOrDefault().InvoiceNo;
                        }
                        await aRDB.AddRangeAsync(sItems); break;
                    case "ProductSale":
                        var psale = JsonToObject<ProductSale>(path);

                        await aRDB.AddRangeAsync(psale); break;
                    case "CardPaymentDetail":
                        var cpd = JsonToObject<CardPaymentDetail>(path);
                        var npath2 = path.Replace(className, "ProductSale");
                        var psl2 = JsonToObject<PSale>(npath2);
                        foreach (var item in cpd)
                        {
                            item.Id = 0;
                            item.InvoiceNumber = psl2.Where(c => c.InvoiceCode == item.InvoiceNumber).FirstOrDefault().InvoiceNo;
                        }
                        await aRDB.AddRangeAsync(cpd); break;

                    case "SalePaymentDetail":

                        var spd = JsonToObject<SalePaymentDetail>(path);
                        var npath3 = path.Replace(className, "ProductSale");
                        var psl3 = JsonToObject<PSale>(npath3);
                        foreach (var item in spd)
                        {
                            item.Id = 0;
                            item.InvoiceNumber = psl3.Where(c => c.InvoiceCode == item.InvoiceNumber).FirstOrDefault().InvoiceNo;
                        }
                        await aRDB.AddRangeAsync(spd); break; ;
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