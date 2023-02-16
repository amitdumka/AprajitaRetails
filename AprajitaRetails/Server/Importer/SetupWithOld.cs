using AprajitaRetails.Server.Data;

namespace AprajitaRetails.Server.Importer
{
    public class SetupWithOld
    {
        private IWebHostEnvironment hostingEnv;
        private ARDBContext aRDB;
        private ImportData ImportData;
        public SetupWithOld(IWebHostEnvironment env, ARDBContext db)
        {
            this.hostingEnv = env; aRDB = db;
            ImportData = new ImportData(env, db);
        }

        public async void Start()
        {
            var fileList = ImportData.ListFiles();
            var viFileList = fileList.Where(c => c.FileName.StartsWith("V1_")).ToList();
            bool flag = true;
            // Import Store
            flag = await ImportData.ImportTableAsync(viFileList.Where(c=>c.FileName=="V1_Stores").FirstOrDefault().Path);
            if (!flag) return;
            // Import Employee
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Employees").FirstOrDefault().Path);
            if (!flag) return;
            // Import Attendances
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Attendances").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Banks").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_MonthlyAttendances").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Salaries").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_BankAccounts").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Brands").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_CardPaymentDetails").FirstOrDefault().Path);


            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_CashDetails").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_CustomerDues").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_DailySales").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_EDCMachine").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Parties").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_LedgerMasters").FirstOrDefault().Path);

            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_PettyCashSheets").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Products").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_ProductSales").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_PurchaseItems").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_PaySlips").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Salesmen").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_TranscationModes").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "V1_Vendors").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "CashVouchers").FirstOrDefault().Path);
            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "Vouchers").FirstOrDefault().Path);

            flag = await ImportData.ImportTableAsync(viFileList.Where(c => c.FileName == "EmployeeDetails").FirstOrDefault().Path);
        }

    }
}