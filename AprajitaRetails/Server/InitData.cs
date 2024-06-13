using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Shared.Models.Vouchers;

namespace AprajitaRetails.Server.InitData
{
    public class InitCompany
    {

        public string MoveEmployee(ARDBContext db)
        {
            Salesman salesman = new Salesman
            {
                EmployeeId = "SM",
                EntryStatus = EntryStatus.Added,
                IsActive = true,
                IsReadOnly = true,
                MarkedDeleted = false,
                Name = "Manager",
                SalesmanId = "MBO-2023-SM-1",
                StoreId = "MBO",
                UserId = "AutoADMIN"
            };
            db.Salesmen.Add(salesman);
            var emps = db.Employees.Where(c => c.IsWorking).ToList();
            foreach (var item in emps)
            {
                item.StoreId = "MBO";

            }
            db.Employees.UpdateRange(emps);
            int y = db.SaveChanges();
            return $"Moved   Emp and salesman {y}";
        }
        public static int AddInitCompany(ARDBContext db)
        {

            AppClient client = new()
            {
                AppClientId = Guid.NewGuid(),
                ClientAddress = "Bhalagpur Road Dumka",
                ClientName = "Aadwika Fashion",
                StartDate = new DateTime(2024, 04, 01),
                City = "Dumka",
                MobileNumber = "9334799099"
            };
            StoreGroup group = new()
            {
                AppClientId = client.AppClientId,
                GroupName = "Aadwika Fashion MBO",
                Remarks = "New MBO",
                StoreGroupId = "MBO",
                AppClient = client
            };
            Store store = new()
            {
                AppClientId = client.AppClientId,
                BeginDate = new DateTime(2024, 4, 1),
                City = "Dumka",
                Country = "India",
                EndDate = null,
                AppClient = client,
                GSTIN = "20AJHPA7396P1ZV",
                IsActive = true,
                MarkedDeleted = false,
                PanNo = "AJPHA7396P",
                State = "Jharkhand",
                StoreCode = "MBO001",
                StoreEmailId = "aadwikafashion.mbo@gmail.com",
                StoreGroup = group,
                StoreGroupId = "MBO",
                StoreId = "MBO",
                StoreManager = "Alok Kumar",
                StoreManagerContactNo = "",
                StoreName = "Aadwika Fashion MBO",
                StorePhoneNumber = "06434224461",
                VatNo = "NA",
                ZipCode = "814101"

            };
            Salesman salesman = new Salesman
            {
                EmployeeId = "SM",
                EntryStatus = EntryStatus.Added,
                IsActive = true,
                IsReadOnly = true,
                MarkedDeleted = false,
                Name = "Manager",
                SalesmanId = "MBO-2023-SM-1",
                StoreId = "MBO",
                UserId = "AutoADMIN"
            };
            TransactionMode m1 = new TransactionMode
            {
                TransactionId = "HE",
                TransactionName = "Home Expenses"

            };
            TransactionMode m2 = new TransactionMode
            {
                TransactionId = "CI",
                TransactionName = "Cash In"

            };
            TransactionMode m3 = new TransactionMode
            {
                TransactionId = "CO",
                TransactionName = "Cash out"

            };
            TransactionMode m4 = new TransactionMode
            {
                TransactionId = "PE",
                TransactionName = "Petty Expenses"

            };
            TransactionMode m5 = new TransactionMode
            {
                TransactionId = "AE",
                TransactionName = "Amit Kumar Expenses"

            };



            //db.AppClients.Add(client);
            //db.StoreGroups.Add(group);
            //db.Stores.Add(store);

            int x = db.SaveChanges();

            db.TransactionModes.Add(m1);

            db.TransactionModes.Add(m2);

            db.TransactionModes.Add(m3);

            db.TransactionModes.Add(m4);

            db.TransactionModes.Add(m5);
            db.Salesmen.Add(salesman);
            x = db.SaveChanges();

            return x;

        }
    }
}