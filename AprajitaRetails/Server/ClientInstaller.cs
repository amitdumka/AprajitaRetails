using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using AprajitaRetails.Server.Models;

using AprajitaRetails.Shared.Models.Banking;

using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace AprajitaRetails.Server
{
    public class ClientInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GSTIN { get; set; }
        public string PanNo { get; set; }
        public DateTime StartDate { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobile { get; set; }
        public string OwnerName { get; set; }
        public string StoreCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSCode { get; set; }

    }
    public class RegisteredClient
    {
        public AppClient Client { get; set; }
        public List<StoreGroup> Groups { get; set; }
        public List<Store> Stores { get; set; }
        public string RegisterAdminUserName { get; set; }
        public string DefaultPassword { get; set; }
        public string DefaultOwnerPassword { get; set; }
        public string Remarks { get; set; }
        public Employee Owner { get; set; }
        public int Count { get; set; }
    }

}

//TODO: Items need to created for First Run
/*
    1. AppClinet
    2. StoreGroup
    3. Store
    4. Owner Employee 
    5. Owner Username
    6. StoreManager Employee
    7. Admin User
    8. Bank
    9. Bank Account
    10. Transcation
    11. LedgerGroup
    12. Party
    
*/


namespace AprajitaRetails.Server
{
    //TODO: Implement this in fullcontext so it can be use any place 
    public class ClientInstaller
    {
        public static RegisteredClient RegisterClient(ARDBContext db, ApplicationDbContext context, ClientInfo info)
        {

            var client = CreateStore(db, context, info);
            //Creating Owner Employee Account
            client = CreateDefaultOptions(db, context, info, client);

            return client;
        }
        //Create Store, Client and Store Group        
        private static RegisteredClient CreateStore(ARDBContext db, ApplicationDbContext context, ClientInfo info)
        {

            AppClient client = new AppClient
            {
                AppClientId = Guid.NewGuid(),
                ClientName = "Aadwika Fashion",
                ClientAddress = "Bhagalpur Road, Near TATA Showroom,Dumka",
                MobileNumber = "06434224461",
                City = "Dumka",
                StartDate = new DateTime(2024, 04, 01),
                ExpireDate = null
            };
            StoreGroup group = new StoreGroup
            {
                AppClientId = client.AppClientId,
                GroupName = "Addwika Fashion MBO",
                Remarks = "Convert to MBO",
                StoreGroupId = "MBO",

            };
            Store store = new Store
            {
                AppClientId = client.AppClientId,
                BeginDate = new DateTime(2024, 4, 1),
                City = "Dumka",
                Country = "India",
                EndDate = null,
                AppClient = null,
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
                StoreName = "Aadwika Fashion",
                StorePhoneNumber = "06434224461",
                VatNo = "",
                ZipCode = "814101"

            };
            db.AppClients.Add(client);
            db.StoreGroups.Add(group);
            db.Stores.Add(store);

            int result = db.SaveChanges();
            return new RegisteredClient
            {
                Client = client,
                Groups = new List<StoreGroup> { group },
                Stores = new List<Store> { store },
                RegisterAdminUserName = "Admin",
                DefaultPassword = "Admin@1234",
                Count = result
            };
        }

        //Create Default Options and Other entites
        private static RegisteredClient CreateDefaultOptions(ARDBContext db, ApplicationDbContext context, ClientInfo info, RegisteredClient client)
        {
            //Creatng Owner
            client.Owner = new Employee
            {
                EmployeeId = $"OWN-{info.StartDate.Year}-0001",
                EmpId = 1,
                JoiningDate = new DateTime(2015, 10, 1),
                IsWorking = true,
                Category = EmpType.Owner,
                MarkedDeleted = false,
                Gender = Gender.Male,
                DOB = new DateTime(1982, 07, 24),
                Title = "Mr.",
                City = info.City,
                State = info.State,
                Country = info.Country,
                StreetName = info.Address,
                ZipCode = info.PinCode,
                StoreId = info.StoreCode,
                FirstName = info.OwnerName.Split(' ')[0],
                LastName = info.OwnerName.Split(' ')[1],

            };
            db.Employees.Add(client.Owner);
            client.Count += db.SaveChanges();
            client.Remarks += $"#Owner Employee  Created[EmpId:{client.Owner.EmployeeId}];";
            DateTime defDate = info.StartDate;

            var smEmp = new Employee
            {
                EmployeeId = $"{info.StoreCode}-SM-{info.StartDate.Year}-0001",
                EmpId = 2,
                JoiningDate = info.StartDate,
                IsWorking = true,
                Category = EmpType.StoreManager,
                MarkedDeleted = false,
                Gender = Gender.Male,
                DOB = info.StartDate.AddYears(-20),
                Title = "Mr.",
                City = info.City,
                State = info.State,
                Country = info.Country,
                StreetName = info.Address,
                ZipCode = info.PinCode,
                StoreId = info.StoreCode,
                FirstName = info.OwnerName.Split(' ')[0],
                LastName = info.OwnerName.Split(' ')[1],

            };
            db.Employees.Add(smEmp);
            client.Count += db.SaveChanges();
            client.Remarks += $"Store Manger Employee  Created[EmpId:{smEmp.EmployeeId}];";

            //Create Bank Name
            var banks = new List<Bank>{ new Bank{BankId="SBI",Name="State Bank Of India"},
            new Bank{BankId="HDFC",Name="HDFC Bank"}, new Bank{BankId="ICICI",Name="ICICI Bank"},
            new Bank{BankId="AXIS",Name="Axis Bank"}, new Bank{BankId="KOTAK",Name="Kotak Mahindra Bank"},
            new Bank{BankId="BOB",Name="Bank Of Baroda"}, new Bank{BankId="PUNJAB",Name="Punjab National Bank"},
            new Bank{BankId="IDBI",Name="IDBI Bank"}, new Bank{BankId="FEDERAL",Name="Federal Bank"},
            new Bank{BankId="IDFC",Name="IDFC Bank"}, new Bank{BankId="INDIAN",Name="Indian Bank"},
            new Bank{BankId="CANARA",Name="Canara Bank"}, new Bank{BankId="RBL",Name="RBL Bank"},
            new Bank{BankId="DBS",Name="DBS Bank"},          new Bank{BankId="UNION",Name="Union Bank"},
            new Bank{BankId="CITI",Name="Citi Bank"},          new Bank{BankId="YES",Name="Yes Bank"},
            new Bank{BankId="OTHERS",Name="Others" }, new Bank{BankId="HSBC",Name="HSBC Bank"}
            };
            db.Banks.AddRange(banks);
            client.Count +=  db.SaveChanges();

            client.Remarks += $"#Created {client.Count} Banks;";

            //Creating Default Bank Account
            BankAccount bankAccount = new BankAccount
            {
                AccountNumber = info.BankAccountNumber,
                DefaultBank = true,
                SharedAccount = true,
                OpeningBalance = 0,
                CurrentBalance = 0,
                OpeningDate = info.StartDate,
                StoreId = info.StoreCode,
                StoreGroupId = info.StoreCode,
                MarkedDeleted = false,
                AppClientId = client.Client.AppClientId,
                IsActive = true,
                AccountType = AccountType.Current,
                AccountHolderName = info.Name,
                BranchName = info.BranchName,
                IFSCCode = info.IFSCode,
                BankId = db.Banks.Where(c => c.Name == info.BankName).FirstOrDefault().BankId ?? "",
            };

            db.BankAccounts.Add(bankAccount);
            client.Count += db.SaveChanges();
            client.Remarks += $"#Created {client.Count} Bank Account;";

            //TransactionMode

            var TransactionModes = new List<TransactionMode>
            {
                new TransactionMode{TransactionId="CI",TransactionName="Cash In"},
                new TransactionMode{TransactionId="CO",TransactionName="CashOut"},
                new TransactionMode{TransactionId="PE",TransactionName="Petty Cash Expenses"},
                new TransactionMode{TransactionId="AE",TransactionName="Amit Expense"},
                new TransactionMode{TransactionId="HE",TransactionName="Home Expense"},
                new TransactionMode{TransactionId="VE",TransactionName="Vehicle Expense"},
                new TransactionMode{TransactionId="TE",TransactionName="Telephone Expense"},
                new TransactionMode{TransactionId="ME",TransactionName="Miscellaneous Expense"},
                new TransactionMode{TransactionId="PE",TransactionName="Petty Cash Income"},
                new TransactionMode{TransactionId="BL",TransactionName="Breakfast & Lunch"},
                new TransactionMode{TransactionId="TC",TransactionName="Tea & Coffee"},
                new TransactionMode{TransactionId="OP",TransactionName="Online Purhcase"},
                new TransactionMode{TransactionId="SU",TransactionName="Suspense"},
                new TransactionMode{TransactionId="ST",TransactionName="Stationary"},
                new TransactionMode{TransactionId="SC",TransactionName="Short In Cash"},
                new TransactionMode{TransactionId="PU",TransactionName="Puja Expenses"},

        };

            db.TransactionModes.AddRange(TransactionModes);
            client.Count += db.SaveChanges();

            client.Remarks += $"#Created {client.Count} Transaction Modes;";

            // Default Party Ledgers

            var LedgerGroup = new List<LedgerGroup>{
                new LedgerGroup{LedgerGroupId="NOPARTY",GroupName="No Party", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="CASH",GroupName="Cash", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="BANK",GroupName="Bank", Category=LedgerCategory.Bank},
                new LedgerGroup{LedgerGroupId="CRD",GroupName="Credit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="DBT",GroupName="Debit", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="SLY",GroupName="Salary", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="PUR",GroupName="Purchase", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="SAL",GroupName="Sales", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="INC",GroupName="Income", Category=LedgerCategory.Income},
                new LedgerGroup{LedgerGroupId="EXO",GroupName="Expense", Category=LedgerCategory.Expenses},
                new LedgerGroup{LedgerGroupId="OTH",GroupName="Others", Category=LedgerCategory.Others},
                new LedgerGroup{LedgerGroupId="IDINC",GroupName="Indirect Income", Category=LedgerCategory.Assets},
                new LedgerGroup{LedgerGroupId="IDEXP",GroupName="Indirect Expense", Category=LedgerCategory.Expenses},

            };

            db.LedgerGroups.AddRange(LedgerGroup);
            client.Count += db.SaveChanges();

            client.Remarks += $"#Created {client.Count} Ledger Groups;";

            var partyLedgers = new List<Party>{
                new Party{PartyId="NOPARTY",PartyName="No Party", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Others, LedgerGroupId="NOPARTY"},
                new Party{PartyId="TIE",PartyName="Telephone & Internet", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNB",PartyName="Snacks & Beverages", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},
                new Party{PartyId="EB",PartyName="Eletricity Bill", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},
                new Party{PartyId="SNP",PartyName="Stationary & Printing", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},
                new Party{PartyId="ASAL",PartyName="Salary Adavances", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="SLY"},
                new Party{PartyId="FRC",PartyName="Frieght Charges", OpeningDate=defDate,
                ClosingBalance=0,OpeningBalance=0,Category=LedgerCategory.Expenses, LedgerGroupId="IDEXP"},

                //TODO: Need to add Party Ledger for basic accounting.
            };

            db.Parties.AddRange(partyLedgers);
            client.Count += db.SaveChanges();

            client.Remarks += $"#Created {client.Count} Ledgers;";
            return client;

        }


    }//end of class
}

